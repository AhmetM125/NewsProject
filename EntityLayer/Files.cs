using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer
{
    [System.ComponentModel.DataAnnotations.Schema.Table("Files")]
    public class Files
    {
        [Dapper.Contrib.Extensions.Key]
        [System.ComponentModel.DataAnnotations.Key]
        public Guid Id { get; set; }
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
        public string? Extention { get; set; }
        public byte[]? Content { get; set; }
        public byte? Size { get; set; }
        [Computed]
        public ICollection<News> News { get; }
    }
}
