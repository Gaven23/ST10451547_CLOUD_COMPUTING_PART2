namespace ST10451547_CLOUD_COMPUTING_PART2.Data.Entities
{
	public class Order
	{
		public int OrderID { get; set; } = 1;
		public int TotalQuantity { get; set; }
		public int TotalPrice { get; set; }
		public string UserFriendlyOrderCode { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Address { get; set; }
		public string CardNumber { get; set; }
		public string CVV { get; set; }
	}
}
