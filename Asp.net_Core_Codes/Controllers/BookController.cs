using Asp.net_Core_Codes.Models;
using Asp.net_Core_Codes.Repository;
using Microsoft.AspNetCore.Mvc;


namespace Asp.net_Core_Codes.Controllers
{
    public class BookController : Controller
    {
        //Bascically to use a method of class which have into another class
        private readonly BookRepository _bookrepo =null;
        public BookController()
        {
            _bookrepo = new BookRepository();
        }
        public ViewResult GetAllBookData()
        {
            var getallbookdata = _bookrepo.GetAllBooks().ToList();
            return View(getallbookdata);
        }
        public BookModel GetAllBookDataById(int id)
        {
            var getallbookdatabyid = _bookrepo.GetBookById(id);
            return getallbookdatabyid;
        }

        public BookModel SearchBookByNameAndAuthor(string title, string authorname)
        {
            var searchbookbynameandauthor = _bookrepo.SearchBook(title, authorname).FirstOrDefault();
            return searchbookbynameandauthor;
        }

    }
}
