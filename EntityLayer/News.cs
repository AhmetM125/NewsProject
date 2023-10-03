using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer
{
    [System.ComponentModel.DataAnnotations.Schema.Table("News")]
    public class News
    {
        [Dapper.Contrib.Extensions.Key]
        [System.ComponentModel.DataAnnotations.Key]
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
        [Computed]
        public Files Files { get; set; } = default!;
    }
}
