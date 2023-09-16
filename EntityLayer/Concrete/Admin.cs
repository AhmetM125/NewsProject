using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class Admin
	{
		[Key]
		public Guid User_Guid_Id { get; set; }
        public string Name { get; set; } = default!;
        public string Surname { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;

    }
}
