using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace EntityLayer
{
    public class News
    {
        [Key]
        public int New_Id { get; set; }

        [Required(ErrorMessage = "Title cannot be empty")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content cannot be empty")]
        [MaxLength(1000)]
        public string Content { get; set; }

        [MaxLength(30)]
        public string? Author { get; set; }
        public string PublishDate { get; set; }

        public string? CategoryId { get; set; }

        [MaxLength(50)]
        public string? Source { get; set; }



        public Guid? FilesId { get; set; }
        public Files Files { get; set; }
    }
}
