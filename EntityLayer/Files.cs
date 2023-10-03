using Dapper.Contrib.Extensions;

namespace EntityLayer
{
    [Dapper.Contrib.Extensions.Table("Files")]
    public class Files
    {
        [Dapper.Contrib.Extensions.Key]
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
