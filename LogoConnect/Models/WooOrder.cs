using System.Text.Json.Serialization;

namespace LogoConnect.Models
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);

    public class WooOrder
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("parent_id")]
        public int ParentId { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("order_key")]
        public string OrderKey { get; set; }

        [JsonPropertyName("created_via")]
        public string CreatedVia { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("date_created")]
        public DateTime? DateCreated { get; set; }

        [JsonPropertyName("date_created_gmt")]
        public DateTime? DateCreatedGmt { get; set; }

        [JsonPropertyName("date_modified")]
        public DateTime? DateModified { get; set; }

        [JsonPropertyName("date_modified_gmt")]
        public DateTime? DateModifiedGmt { get; set; }

        [JsonPropertyName("discount_total")]
        public string DiscountTotal { get; set; }

        [JsonPropertyName("discount_tax")]
        public string DiscountTax { get; set; }

        [JsonPropertyName("shipping_total")]
        public string ShippingTotal { get; set; }

        [JsonPropertyName("shipping_tax")]
        public string ShippingTax { get; set; }

        [JsonPropertyName("cart_tax")]
        public string CartTax { get; set; }

        [JsonPropertyName("total")]
        public string Total { get; set; }

        [JsonPropertyName("total_tax")]
        public string TotalTax { get; set; }

        [JsonPropertyName("prices_include_tax")]
        public bool PricesIncludeTax { get; set; }

        [JsonPropertyName("customer_id")]
        public int CustomerId { get; set; }

        [JsonPropertyName("customer_ip_address")]
        public string CustomerIpAddress { get; set; }

        [JsonPropertyName("customer_user_agent")]
        public string CustomerUserAgent { get; set; }

        [JsonPropertyName("customer_note")]
        public string CustomerNote { get; set; }

        [JsonPropertyName("billing")]
        public Billing Billing { get; set; }

        [JsonPropertyName("shipping")]
        public Shipping Shipping { get; set; }

        [JsonPropertyName("payment_method")]
        public string PaymentMethod { get; set; }

        [JsonPropertyName("payment_method_title")]
        public string PaymentMethodTitle { get; set; }

        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }

        [JsonPropertyName("date_paid")]
        public DateTime? DatePaid { get; set; }

        [JsonPropertyName("date_paid_gmt")]
        public DateTime? DatePaidGmt { get; set; }

        [JsonPropertyName("date_completed")]
        public object DateCompleted { get; set; }

        [JsonPropertyName("date_completed_gmt")]
        public object DateCompletedGmt { get; set; }

        [JsonPropertyName("cart_hash")]
        public string CartHash { get; set; }

        [JsonPropertyName("meta_data")]
        public List<MetaData> MetaData { get; set; }

        [JsonPropertyName("line_items")]
        public List<LineItem> LineItems { get; set; }

        [JsonPropertyName("tax_lines")]
        public List<TaxLine> TaxLines { get; set; }

        [JsonPropertyName("shipping_lines")]
        public List<ShippingLine> ShippingLines { get; set; }

        [JsonPropertyName("fee_lines")]
        public List<object> FeeLines { get; set; }

        [JsonPropertyName("coupon_lines")]
        public List<object> CouponLines { get; set; }

        [JsonPropertyName("refunds")]
        public List<object> Refunds { get; set; }
    }

    public class Billing
    {
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("address_1")]
        public string Address1 { get; set; }

        [JsonPropertyName("address_2")]
        public string Address2 { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("postcode")]
        public string Postcode { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }
    }

    public class LineItem
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("product_id")]
        public int ProductId { get; set; }

        [JsonPropertyName("variation_id")]
        public int VariationId { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("tax_class")]
        public string TaxClass { get; set; }

        [JsonPropertyName("subtotal")]
        public string Subtotal { get; set; }

        [JsonPropertyName("subtotal_tax")]
        public string SubtotalTax { get; set; }

        [JsonPropertyName("total")]
        public string Total { get; set; }

        [JsonPropertyName("total_tax")]
        public string TotalTax { get; set; }

        [JsonPropertyName("taxes")]
        public List<Taxis> Taxes { get; set; }

        [JsonPropertyName("meta_data")]
        public List<MetaData> MetaData { get; set; }

        [JsonPropertyName("sku")]
        public string Sku { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }

    public class MetaData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class Shipping
    {
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("address_1")]
        public string Address1 { get; set; }

        [JsonPropertyName("address_2")]
        public string Address2 { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("postcode")]
        public string Postcode { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }
    }

    public class ShippingLine
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("method_title")]
        public string MethodTitle { get; set; }

        [JsonPropertyName("method_id")]
        public string MethodId { get; set; }

        [JsonPropertyName("total")]
        public string Total { get; set; }

        [JsonPropertyName("total_tax")]
        public string TotalTax { get; set; }

        [JsonPropertyName("taxes")]
        public List<object> Taxes { get; set; }

        [JsonPropertyName("meta_data")]
        public List<object> MetaData { get; set; }
    }

    public class Taxis
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("total")]
        public string Total { get; set; }

        [JsonPropertyName("subtotal")]
        public string Subtotal { get; set; }
    }

    public class TaxLine
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("rate_code")]
        public string RateCode { get; set; }

        [JsonPropertyName("rate_id")]
        public int RateId { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("compound")]
        public bool Compound { get; set; }

        [JsonPropertyName("tax_total")]
        public string TaxTotal { get; set; }

        [JsonPropertyName("shipping_tax_total")]
        public string ShippingTaxTotal { get; set; }

        [JsonPropertyName("meta_data")]
        public List<object> MetaData { get; set; }
    }
}
