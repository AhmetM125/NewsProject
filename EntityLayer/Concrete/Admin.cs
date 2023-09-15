using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class Admin
	{
		[Key]
		public Guid User_Guid_Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
