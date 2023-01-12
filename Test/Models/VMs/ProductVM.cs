using Microsoft.AspNetCore.Mvc;

namespace Test.Models.VMs
{
    public class ProductVM
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public int Price { get; set; }
		public int Inventory { get; set; }
		public DateTime AddTime { get; set; }

		public IEnumerable<IFormFile> ProductPhotos { get; set; }
	}
}
