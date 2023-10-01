using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer
{
    [Table("Files")]
    public class Files
    {
        [Key]
        public Guid Id { get; set; }
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
        public string? Extention { get; set; }
        public byte[]? Content { get; set; }
        public byte? Size { get; set; }

        public ICollection<News> News { get; }
    }
}
