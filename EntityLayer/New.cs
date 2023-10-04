using Dapper.Contrib.Extensions;

namespace EntityLayer
{
    public class New
    {
        [Key]
        public int New_Id { get; set; }

        public string Title { get; set; } = default!;

        public string Content { get; set; } = default!;

        public string? Author { get; set; }

        //Data type will fix to DateTime
        public string PublishDate { get; set; } = default!;

        public string? CategoryId { get; set; }

        public string? Source { get; set; }



        //FK

        public Guid? FilesId { get; set; }
        [Computed]
        public File Files { get; set; } = default!;
    }
}
