using Asp.net_Core_Codes.Models;
using Asp.net_Core_Codes.Repository;
using Microsoft.AspNetCore.Mvc;


namespace Asp.net_Core_Codes.Controllers
{
    public class BookController : Controller
    {
        //Basically to use a method of class which have into another class
        private readonly BookRepository _bookrepo =null;
        public BookController(BookRepository book)
        {
            //acc to DI we should not create a instance of a class by using new keyword
            //_bookrepo = new BookRepository();

            //Dependency is created in program.cs class

            _bookrepo = book;
        }
        public ViewResult GetAllBookData()
        {
            var getallbookdata = _bookrepo.GetAllBooks().ToList();
            ViewData["BookData"] = "All Books Data";
            return View(getallbookdata);
        }
        public ViewResult GetAllBookDataById(int id)
        {
            var getallbookdatabyid = _bookrepo.GetBookById(id).ToList();
            ViewBag.DataById = "Below data is of book no ";
            //Here property type is anonymous 
            ViewBag.bookid = new { id = 1000 };
            return View(getallbookdatabyid);
        }

        public BookModel SearchBookByNameAndAuthor(string title, string authorname)
        {
            var searchbookbynameandauthor = _bookrepo.SearchBook(title, authorname).FirstOrDefault();
            return searchbookbynameandauthor;
        }

        public ViewResult AddNewBook()
        {

            return View();
        }

        [HttpPost]
        public ViewResult SubmitBookData(BookModel bookdata)
        {
            _bookrepo.AddBookData(bookdata);
            return View();
        }
    }
}
