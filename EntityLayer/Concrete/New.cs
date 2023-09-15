using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class New
	{
        [Key]
        public int New_Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Publish_Date { get; set; }
        //
        public string CategoryId { get; set; }
        public string Source { get; set; }

    }
}
