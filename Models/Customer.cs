namespace SupermarketWeb.Models
{
	public class Customer
	{
		public int Id { get; set; }
		public int document_number { get; set; }
		public string firts_name { get; set; }
		public string last_name { get; set; }
		public string address { get; set; }
		public DateTime birthday { get; set; }
		public int phone_numbers { get; set; }
		public string email { get; set; }
	}

}

