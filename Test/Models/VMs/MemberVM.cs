namespace Test.Models.VMs
{
    public class MemberVM
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Account { get; set; }
		public string Password { get; set; }
		public ICollection<Photo> Photos { get; set; }
	}
}
