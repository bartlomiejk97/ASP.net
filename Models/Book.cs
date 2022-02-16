using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp_Gr3.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [Range(1, 20, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int NumberInStock { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public int NumberAvailable { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string Author { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public int PublicationYear { get; set; }

        [Required(ErrorMessage = "The field is required")]
        public string PublishingHouse { get; set; }
    }
}
