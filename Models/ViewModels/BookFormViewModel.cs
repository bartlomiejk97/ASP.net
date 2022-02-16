using LibApp_Gr3.Models;
using System.ComponentModel.DataAnnotations;

namespace LibApp_Gr3.ViewModels
{
    public class BookFormViewModel
    {
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

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Book" : "New Book";
            }
        }

        public BookFormViewModel()
        {

        }

        public BookFormViewModel(Book book)
        {
            Id = book.Id;
            Name = book.Name;
            NumberInStock = book.NumberInStock;
            NumberAvailable = book.NumberAvailable;
            Author = book.Author;
            PublicationYear = book.PublicationYear;
            PublishingHouse = book.PublishingHouse;
        }
    }
}
