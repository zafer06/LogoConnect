using System.Text.Json;

namespace LogoConnect
{
    using System.Text.Json;

    public class LogoOrderStatus
    {
        public string Status { get; set; } = "Pending";
        public string? ErrorMessage { get; set; }
    }

    public static class LogoStatusStore
    {
        private static readonly string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "logoStatus.json");

        // WooOrderId -> LogoOrderStatus
        public static Dictionary<int, LogoOrderStatus> Statuses { get; private set; } = new Dictionary<int, LogoOrderStatus>();

        // Uygulama başında JSON’dan yükle
        public static void Load()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                Statuses = JsonSerializer.Deserialize<Dictionary<int, LogoOrderStatus>>(json)
                            ?? new Dictionary<int, LogoOrderStatus>();
            }
        }

        // Durum ve hata mesajını güncelle
        public static void SetStatus(int orderId, string status, string? errorMessage = null)
        {
            Statuses[orderId] = new LogoOrderStatus
            {
                Status = status,
                ErrorMessage = errorMessage
            };
            Save();
        }

        private static void Save()
        {
            var json = JsonSerializer.Serialize(Statuses, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        // Belirli bir siparişin durumu
        public static LogoOrderStatus GetStatus(int orderId)
        {
            return Statuses.TryGetValue(orderId, out var s) ? s : new LogoOrderStatus();
        }
    }
}
