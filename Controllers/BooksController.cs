using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibApp_Gr3.Models;
using LibApp_Gr3.ViewModels;
using LibApp_Gr3.Services;
using Microsoft.AspNetCore.Authorization;

namespace LibApp_Gr3.Controllers
{
    public class BooksController : Controller
    {
        protected BookService BookService { get; }
        public BooksController(BookService bookService)
        {
            BookService = bookService;
        }

        [Authorize(Roles = "User, StoreManager, Owner")]
        public IActionResult Random()
        {
            var firstBook = new Book() { Name = "English dictionary" };

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomBookViewModel
            {
                Book = firstBook,
                Customers = customers
            };

            return View(viewModel);
        }

        
        [Authorize(Roles = "User, StoreManager, Owner")]
        public IActionResult Index()
        {
            var books = GetBooks();

            return View(books);
        }

        [Authorize(Roles = "StoreManager, Owner")]
        public IActionResult Form(int? id)
        {
            if (id.HasValue)
            {
                var _entity = BookService.GetItem(id.Value);
                return View(new BookFormViewModel(_entity));
            }
            else
            {
                return View(new BookFormViewModel());
            }
        }

        [Authorize(Roles = "User, StoreManager, Owner")]
        public IActionResult Details(int id)
        {
            var _entity = BookService.GetItem(id);

            return View(_entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "StoreManager, Owner")]
        public IActionResult Save(Book book)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BookFormViewModel(book);

                return View("CustomerForm", viewModel);
            }

            if (book.Id == 0)
            {
                BookService.Insert(book);
            }
            else
            {
                BookService.Update(book.Id, book);
            }

            return RedirectToAction("Index", "Books");
        }

        [Route("books/released/{year:regex(^\\d{{4}}$)}/{month:range(1, 12)}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        private IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book {Id = 1, Name = "Hamlet"},
                new Book {Id = 2, Name = "Ulysses"}
            };
        }
    }
}