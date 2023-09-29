using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
    public class News
    {
        [Key]
        public int New_Id { get; set; }

        [Required(ErrorMessage = "Title cannot be empty")]
        public string Title { get; set; } = default!;

            [Required(ErrorMessage = "Content cannot be empty")]
        [MaxLength(1000)]
        public string Content { get; set; } = default!;

        [MaxLength(30)]
        public string? Author { get; set; }

        //Data type will fix to DateTime
        public string PublishDate { get; set; } = default!;

        public string? CategoryId { get; set; }

        [MaxLength(50)]
        public string? Source { get; set; }



        //FK

        public Guid? FilesId { get; set; }
        public Files Files { get; set; } = default!;
    }
}
