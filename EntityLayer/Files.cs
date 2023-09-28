using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
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
