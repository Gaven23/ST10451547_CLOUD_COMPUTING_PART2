namespace ST10451547_CLOUD_COMPUTING_PART2.Data.Entities
{
    public class LineItem
    {
        public int Id { get; set; }
        public int? Quantity { get; set; } = 1;
        public int? Price { get; set; }
        public string ProductId { get; set; } = "2";

    }
}
