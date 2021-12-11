using System.ComponentModel.DataAnnotations;

namespace bibliotecaAPI.InputModels
{
    public class BooksInputModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public long ISBN { get; set; }
        [Required]
        public int PublishingYear { get; set; }
        [Required]
        public int AuthorId { get; set; }
    }
}
