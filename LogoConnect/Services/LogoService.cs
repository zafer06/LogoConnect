using LogoConnect.Models;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogoConnect.Services
{
    public interface ILogoService
    {
        bool SendOrder(WooOrder order);
    }

    public class LogoService: ILogoService
    {
        public bool SendOrder(WooOrder order)
        {
            try
            {
                /*
                // COM nesnesi oluştur
                Data unity = new Data();
                Data siparis = unity.NewDataObject(DataObjectType.doSalesOrderSlip);
                siparis.New();

                // Sipariş başlığı
                siparis.DataFields.FieldByName("NUMBER").Value = order.OrderKey;
                siparis.DataFields.FieldByName("DATE").Value = order.DateCreated?.ToString("yyyy-MM-dd");
                siparis.DataFields.FieldByName("TIME").Value = order.DateCreated?.ToString("HH:mm");
                siparis.DataFields.FieldByName("ARP_CODE").Value = order.CustomerId;
                siparis.DataFields.FieldByName("TOTAL_NET").Value = order.Total;
                siparis.DataFields.FieldByName("SALESMAN_CODE").Value = "WooCommerce";
                siparis.DataFields.FieldByName("NOTES1").Value = order.CustomerNote ?? "";

                // Ödeme ve durum
                siparis.DataFields.FieldByName("ORDER_STATUS").Value = 4; // Ödeme
                siparis.DataFields.FieldByName("WITH_PAYMENT").Value = 1; // Ödeme

                // Satırlar
                Lines detay = siparis.DataFields.FieldByName("TRANSACTIONS").Lines;
                foreach (var li in order.LineItems)
                {
                    if (detay.AppendLine())
                    {
                        detay[0].FieldByName("TYPE").Value = 4; // Hizmet / ürün tipi
                        detay[0].FieldByName("MASTER_CODE").Value = li.Sku;
                        detay[0].FieldByName("QUANTITY").Value = li.Quantity;
                        detay[0].FieldByName("PRICE").Value = li.Price;
                        detay[0].FieldByName("TOTAL").Value = li.Price * li.Quantity;
                        detay[0].FieldByName("UNIT_CODE").Value = "Adet";
                        detay[0].FieldByName("PC_PRICE").Value = li.Price;
                        detay[0].FieldByName("TOTAL_NET").Value = li.Price * li.Quantity;
                        detay[0].FieldByName("VAT_RATE").Value = li.TaxClass;
                        detay[0].FieldByName("VAT_INCLUDED").Value = li.TaxClass ? 1 : 0;
                    }
                }

                siparis.DataFields.FieldByName("ITEXT").Value = order.ExtraNotes ?? "";

                // Validate
                ValidateErrors err = siparis.ValidateErrors;

                bool result = siparis.Post();

                if (!result)
                {
                    for (int i = 0; i < err.Count; i++)
                    {
                        Console.WriteLine("{0} - {1};", err[i].Error, err[i].ID);
                    }
                }

                Marshal.ReleaseComObject(siparis);
                Marshal.ReleaseComObject(unity);

                return result;
                */
            }
            catch (COMException ex)
            {
                Console.WriteLine("Logo Lobject COM Hatası: " + ex.Message);
                return false;
            }

            return true;
        }
    }
}