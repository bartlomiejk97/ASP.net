using System.ComponentModel.DataAnnotations;

namespace LibApp_Gr3.Models.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }

        [Required]
        public int NumberAvailable { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public int PublicationYear { get; set; }

        [Required]
        public string PublishingHouse { get; set; }
    }
}
