using Asp.net_Core_Codes.Models;

namespace Asp.net_Core_Codes.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            List<BookModel> books = new List<BookModel>();
            try
            {
                books = BookDataSource();
                return books;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<BookModel> GetBookById(int id)
        {
            List<BookModel> book = new List<BookModel>();
            try
            {
                book = BookDataSource().Where(s=>s.Bookno == id).ToList();
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

    }
}
