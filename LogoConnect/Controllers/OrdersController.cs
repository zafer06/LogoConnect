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
            try
            {
                var orders = await _wooService.GetOrdersAsync(perPage: 20, page: page);
                return View(orders);
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya gösterilebilir. Prod uygulamada logging ekle.
                ViewBag.Error = ex.Message;
                return View(new List<Models.WooOrder>());
            }
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
                bool result = false;    // _logoService.SendOrder(order);
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
                // Durumu DB'ye kaydetmek istersen burada yapabilirsin
            }

            return Json(new { message = $"Gönderim tamamlandı. Başarılı: {successCount}, Hatalı: {failCount}" });
        }
    }
}
