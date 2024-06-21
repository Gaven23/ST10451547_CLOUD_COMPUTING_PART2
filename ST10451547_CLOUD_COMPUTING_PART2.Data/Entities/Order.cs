namespace ST10451547_CLOUD_COMPUTING_PART2.Data.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public string UserFriendlyOrderCode { get; set; }
        public int OrderTypeID { get; set; }
        public int CustomerID { get; set; }
        public DateTime? DateCompleted { get; set; }
        public decimal TotalPrice { get; set; }
		public decimal TotalQuantity { get; set; }
		public decimal AdjustedProfitAmount { get; set; }
        public decimal? FudgingAmount { get; set; }
        public bool IsOrderReadyForAdjustments { get; set; }
        public int StatusID { get; set; }
        public decimal? StorePaidAmount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
