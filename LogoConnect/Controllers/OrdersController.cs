using LogoConnect.Services;
using Microsoft.AspNetCore.Mvc;

namespace LogoConnect.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IWooService _wooService;

        public OrdersController(IWooService wooService)
        {
            _wooService = wooService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            int pageSize = 20;

            // WooCommerce API’den sayfa sayfa sipariş çek
            var orders = await _wooService.GetOrdersAsync(page);

            // Toplam sipariş sayısını da alabiliriz, örnek: _wooService.GetTotalOrdersCount()
            int totalOrders = await _wooService.GetTotalOrdersCountAsync();
            int totalPages = (int)Math.Ceiling((double)totalOrders / pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(orders);
        }

        // Seçilen siparişleri gönder
        [HttpPost]
        public async Task<IActionResult> SendSelectedOrders([FromBody] List<int> selectedIds)
        {
            if (selectedIds == null || selectedIds.Count == 0)
                return Json(new { message = "Lütfen en az bir sipariş seçin." });

            var orders = await _wooService.GetOrdersByIdsAsync(selectedIds);
            int successCount = 0;
            int failCount = 0;

            foreach (var order in orders)
            {
                try
                {
                    //bool result = _logoService.SendOrder(order);
                    
                    bool result = false;
                    if (result)
                    {
                        order.Status = "Success";
                        successCount++;
                    }
                    else
                    {
                        order.Status = "Failed";
                        failCount++;
                    }

                    if (result)
                        LogoStatusStore.SetStatus(order.Id, "Success");
                    else
                        LogoStatusStore.SetStatus(order.Id, "Failed", "Bilinmeyen hata");
                }
                catch (Exception ex)
                {
                    LogoStatusStore.SetStatus(order.Id, "Failed", ex.Message);
                }
            }

            return Json(new { message = $"Gönderim tamamlandı. Başarılı: {successCount}, Hatalı: {failCount}" });
        }
    }
}
