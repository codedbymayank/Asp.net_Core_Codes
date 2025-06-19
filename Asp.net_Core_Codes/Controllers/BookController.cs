using Asp.net_Core_Codes.Models;
using Asp.net_Core_Codes.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Asp.net_Core_Codes.Controllers
{
    public class BookController : Controller
    {
        //Basically to use a method of class which have into another class
        private readonly BookRepository _bookrepo =null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;

        //Here we are using Dependency Injection & asp.net core supports DI bydefault
        public BookController(BookRepository book , IWebHostEnvironment webHostEnvironment)
        {
            //acc to DI we should not create a instance of a class by using new keyword
            //_bookrepo = new BookRepository();

            //Dependency is created in program.cs class

            _bookrepo = book;
            _webHostEnvironment = webHostEnvironment;
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

        public ViewResult AddNewBook(bool IsSuccess = false)
        {
            ViewBag.bookdesc = new List<string>() { "D1" , "D2" , "D3"};
            ViewBag.BookDescrpt = new SelectList(GetDesc(), "Id", "Text");
            BookModel obj = new BookModel();
            obj.BookLanaguage = "Some Custom Lang";
            ViewBag.SuccessProp = IsSuccess;
            return View();
        }

        [HttpPost]
        //If we are using IActionresult then we can return any type of data
        public async Task<IActionResult> AddNewBook(BookModel bookdata)
        {
            ViewBag.bookdesc = new List<string>() { "D1", "D2", "D3" };
            //This will validate each field 
             if(bookdata.ImageUrl!=null)
            {
                string folder = "BookUploadImage/CoverImage/";
                bookdata.ImgPath = await UploadImage(folder , bookdata.ImageUrl);
               
            }
            if (bookdata.GalleryFiles != null)
            {
                string folder = "BookUploadImage/gallery/";
                bookdata.galleryprop = new List<GalleryModel>();
                foreach(var gallerydata in bookdata.GalleryFiles)
                {
                    var gallery = new GalleryModel()
                    {
                       Name = gallerydata.Name,
                       URL = await UploadImage(folder, gallerydata)
                    };
                   bookdata.galleryprop.Add(gallery);
                }
               

            }

            if (bookdata.bookPdf != null)
            {
                string folder = "BookUploadImage/pdf/";
                bookdata.BookPdfUrl = await UploadImage(folder, bookdata.bookPdf);

            }

            if (await _bookrepo.AddBookData(bookdata))
                {
                    //return RedirectToAction("AddNewBook");
                    //OR
                    return RedirectToAction(nameof(AddNewBook), new { IsSuccess = true }); // this method will get as a string because of nameof
                }
            
            // This we are doing for text and value 
            ViewBag.BookDescrpt = new SelectList(GetDesc(), "Id", "Text");
            //ViewBag.BookDescription = new SelectListItem
            //Adding custom validation message , along with property validation message
            ModelState.AddModelError("","This is my custom message");
            ViewBag.SuccessProp = false;
            return View();
        }

        private async Task<string> UploadImage(string folderpath , IFormFile file)
        {
           
            //Here after adding guid , it will add some unique characters all time for all files
            folderpath += Guid.NewGuid().ToString() + '_' + file.FileName;
            //webrootpath we are using to take a path of our local folder
            string serverfolder = Path.Combine(_webHostEnvironment.WebRootPath, folderpath);
            await file.CopyToAsync(new FileStream(serverfolder, FileMode.Create));
            return "/"+folderpath;
        }

        private List<DescModel> GetDesc()
        {
            return new List<DescModel> {
               new DescModel() {Id = 10 , Text="Desc 1"},
               new DescModel() {Id = 11 , Text="Desc 2"},
               new DescModel() {Id = 12 , Text="Desc 3"},
               new DescModel() {Id = 13 , Text="Desc 4"}

           };
        }
    }
}
