using Asp.net_Core_Codes.Asp.net_Core_Codes_Database;
using Asp.net_Core_Codes.Models;
using System.Threading.Tasks;

namespace Asp.net_Core_Codes.Repository
{
    public class BookRepository
    {
        //Entity framework with context class , that's why it needs to create a instance of context class
        private readonly BookNestContext _context = null;

        //Here we are using dependency injection
        public BookRepository(BookNestContext context)
        {
            _context = context;
        }
        public List<BookModel> GetAllBooks()
        {
            List<BookModel> books = new List<BookModel>();
            try
            {
                var data = _context.Books.ToList();
                foreach(var bookdata in data)
                {
                    BookModel obj = new BookModel();
                    obj.Action = bookdata.Action;
                    obj.NoOfPages = Convert.ToInt32(bookdata.NoOfPages);
                    obj.BookAuthor = bookdata.BookAuthor;
                    obj.Bookdesc = bookdata.Bookdesc;
                    obj.UpdatedDate = bookdata.UpdatedDate;
                    obj.BookTitle = bookdata.BookTitle;
                    obj.Bookno = bookdata.Bookno;
                    obj.BookLanaguage = bookdata.BookLanaguage;
                    obj.ImgPath = bookdata.ImgPath;
                    books.Add(obj);

                }
                return books;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<BookModel>> GetTopBooksAsync()
        {
            List<BookModel> books = new List<BookModel>();
            try
            {
                var data = _context.Books.ToList();
                foreach (var bookdata in data)
                {
                    BookModel obj = new BookModel();
                    obj.Action = bookdata.Action;
                    obj.NoOfPages = Convert.ToInt32(bookdata.NoOfPages);
                    obj.BookAuthor = bookdata.BookAuthor;
                    obj.Bookdesc = bookdata.Bookdesc;
                    obj.UpdatedDate = bookdata.UpdatedDate;
                    obj.BookTitle = bookdata.BookTitle;
                    obj.Bookno = bookdata.Bookno;
                    obj.BookLanaguage = bookdata.BookLanaguage;
                    obj.ImgPath = bookdata.ImgPath;
                    books.Add(obj);

                }
                return books;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BookModel> GetBookById(int id)
        {
            List<BookModel> book = new List<BookModel>();
            try
            {
                var data = _context.Books.Where(s=>s.Bookno == id).ToList();
                var gallerydata = _context.BookGallerys.Where(s=>s.BookId == id).ToList();
                int loop = 0;
                foreach(var bookdata in data)
                {

                    BookModel obj = new BookModel();
                    obj.Action = bookdata.Action;
                    obj.NoOfPages = Convert.ToInt32(bookdata.NoOfPages);
                    obj.BookAuthor = bookdata.BookAuthor;
                    obj.Bookdesc = bookdata.Bookdesc;
                    obj.UpdatedDate = bookdata.UpdatedDate;
                    obj.BookTitle = bookdata.BookTitle;
                    obj.Bookno = bookdata.Bookno;
                    obj.BookLanaguage = bookdata.BookLanaguage;
                    obj.ImgPath = bookdata.ImgPath;
                    obj.BookPdfUrl = bookdata.BookPdfUrl;
                    if(loop == 0 )
                    {
                        obj.galleryprop = new List<GalleryModel>();
                        foreach (var galleryd in gallerydata)
                        {
                            GalleryModel gallery = new GalleryModel();
                            gallery.Id = galleryd.Id;
                            gallery.Name = galleryd.Name;
                            gallery.URL = galleryd.URL;
                            obj.galleryprop.Add(gallery);
                            loop = 1;
                        }
                    }
                    book.Add(obj);
                }


                return book;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<BookModel> SearchBook(string title , string authorname)
        {
            List<BookModel> obj = new List<BookModel>();
            try
            {
                obj = BookDataSource().Where(s => s.BookTitle == title && s.BookAuthor == authorname).ToList();
                return obj;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private List<BookModel> BookDataSource()
        {
            return new List<BookModel>()
            {
            new BookModel(){ Bookno = 101, Bookdesc = "A thrilling mystery novel set in Victorian London.", BookTitle = "The Shadow in the Fog", BookAuthor = "Arthur W. Blake", Action = "Available", NoOfPages = 320, BookLanaguage = "English" },
new BookModel(){ Bookno = 102, Bookdesc = "An inspiring tale of resilience during World War II.", BookTitle = "Winds of Courage", BookAuthor = "Emily Hartman", Action = "Checked Out", NoOfPages = 280, BookLanaguage = "English" },
new BookModel(){ Bookno = 103, Bookdesc = "A deep dive into the secrets of the human brain.", BookTitle = "Neural Pathways", BookAuthor = "Dr. Susan Keller", Action = "Available", NoOfPages = 410, BookLanaguage = "English" },
new BookModel(){ Bookno = 104, Bookdesc = "A science fiction epic across galaxies and time.", BookTitle = "Stars Beyond Reach", BookAuthor = "J.T. Reynolds", Action = "Reserved", NoOfPages = 500, BookLanaguage = "English" },
new BookModel(){ Bookno = 105, Bookdesc = "A gripping courtroom drama filled with unexpected twists.", BookTitle = "The Final Verdict", BookAuthor = "Lana Everett", Action = "Available", NoOfPages = 384, BookLanaguage = "English" },
new BookModel(){ Bookno = 106, Bookdesc = "A poetic journey through love, loss, and self-discovery.", BookTitle = "Echoes of the Heart", BookAuthor = "Marcus Leone", Action = "Checked Out", NoOfPages = 210, BookLanaguage = "English" },
new BookModel(){ Bookno = 107, Bookdesc = "An illustrated guide to mastering digital photography.", BookTitle = "The Shutter's Edge", BookAuthor = "Clara Mendez", Action = "Available", NoOfPages = 276, BookLanaguage = "English" },
new BookModel(){ Bookno = 108, Bookdesc = "Historical insights into ancient civilizations of Asia.", BookTitle = "Dynasties of the East", BookAuthor = "Prof. Kenji Tanaka", Action = "Reserved", NoOfPages = 412, BookLanaguage = "Japanese" },
new BookModel(){ Bookno = 109, Bookdesc = "A coming-of-age story set in the rural hills of Spain.", BookTitle = "The Olive Tree Path", BookAuthor = "Sofia Ramirez", Action = "Available", NoOfPages = 330, BookLanaguage = "Spanish" }


            };
        }

        //Here we are using async and task because of savechangesasync
        public async Task<bool> AddBookData(BookModel book)
        {
            try
            {
                if(book.BookAuthor!=null)
                {
                    var data = new Book()
                    {
                        Bookno = book.Bookno,
                        Bookdesc = book.Bookdesc,
                        BookTitle = book.BookTitle,
                        BookAuthor = book.BookAuthor,
                        Action = book.Action,
                        NoOfPages = book.NoOfPages,
                        CreatedDate = book.CreatedDate,
                        UpdatedDate = book.UpdatedDate,
                        ImgPath = book.ImgPath,
                        BookPdfUrl = book.BookPdfUrl,
                        

                    };

                    var gallery = new List<BookGallery>();
                    foreach(var item in book.galleryprop)
                    {
                        gallery.Add(new BookGallery()
                        {
                            Name = item.Name,
                            URL = item.URL,
                        });

                    }
                    data.Gallery = gallery;

                    //Here now we are mapping book with our context class
                    await _context.Books.AddAsync(data);
                    
                    //Async is faster than normal one
                    //Whenever we use async , at that time we need to use await
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
