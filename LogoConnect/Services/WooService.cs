using LogoConnect.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace LogoConnect.Services
{
    public interface IWooService
    {
        Task<IEnumerable<WooOrder>> GetOrdersAsync(int perPage = 20, int page = 1, CancellationToken ct = default);
        Task<List<WooOrder>> GetOrdersByIdsAsync(List<int> selectedIds);
    }

    public class WooService : IWooService
    {
        private readonly HttpClient _client;
        private readonly WooOptions _options;

        public WooService(HttpClient client, IOptions<WooOptions> options)
        {
            _client = client;
            _options = options.Value;
        }

        public async Task<IEnumerable<WooOrder>> GetOrdersAsync(int perPage = 20, int page = 1, CancellationToken ct = default)
        {
            // Build URL (Aynı kalır)
            var url = $"orders?per_page={perPage}&page={page}&consumer_key={Uri.EscapeDataString(_options.ConsumerKey)}&consumer_secret={Uri.EscapeDataString(_options.ConsumerSecret)}";

            var res = await _client.GetAsync(url, ct);

            if (!res.IsSuccessStatusCode)
            {
                var body = await res.Content.ReadAsStringAsync(ct);
                throw new ApplicationException($"Woo API error: {(int)res.StatusCode} {res.ReasonPhrase} - {body}");
            }

            // ⭐️ System.Text.Json Kullanımı ⭐️
            // Response Content'i doğrudan List<WooOrder> tipine deserileştiriyoruz.
            // ReadAsStreamAsync kullanmak, büyük yanıtlar için daha performanslıdır.
            using var contentStream = await res.Content.ReadAsStreamAsync(ct);

            // Deserialize<T> metoduna beklediğimiz tipi List<WooOrder> olarak veriyoruz.
            // NOT: WooOrder modelinizin JSON property isimleriyle eşleştiğinden emin olun.
            var jsonOptions = new JsonSerializerOptions();
            jsonOptions.PropertyNameCaseInsensitive = true;
            jsonOptions.NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString;
            jsonOptions.UnmappedMemberHandling = System.Text.Json.Serialization.JsonUnmappedMemberHandling.Skip;

            var orders = await JsonSerializer.DeserializeAsync<List<WooOrder>>(contentStream, jsonOptions, ct);

            // Deserileştirme başarısız olursa (örn. null dönerse), boş bir liste döndür.
            return orders ?? new List<WooOrder>();
        }

        // Seçili siparişleri çek
        public async Task<List<WooOrder>> GetOrdersByIdsAsync(List<int> selectedIds)
        {
            var orders = new List<WooOrder>();

            foreach (var id in selectedIds)
            {
                // Build URL (Aynı kalır)
                var url = $"orders/{id}?consumer_key={Uri.EscapeDataString(_options.ConsumerKey)}&consumer_secret={Uri.EscapeDataString(_options.ConsumerSecret)}";

                try
                {
                    var response = await _client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    var json = await response.Content.ReadAsStringAsync();
                    var order = JsonSerializer.Deserialize<WooOrder>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (order != null)
                        orders.Add(order);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Sipariş {id} çekilemedi: {ex.Message}");
                    // Hata loglayabilir veya atlayabilirsiniz
                }
            }

            return orders;
        }
    }
}
