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

        public BookModel GetBookById(int id)
        {
            BookModel book = new BookModel();
            try
            {
                book = BookDataSource().Where(s=>s.Bookno == id).FirstOrDefault();
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
                new BookModel(){Bookno=10 , Bookdesc="Book D1" , BookTitle="T1" , BookAuthor="A1"},
                new BookModel(){Bookno=11 , Bookdesc="Book D2" , BookTitle="T2" , BookAuthor="A2"},
                new BookModel(){Bookno=12, Bookdesc="Book D3" ,BookTitle="T3" , BookAuthor="A3"},
                new BookModel(){Bookno=13 , Bookdesc="Book D4" , BookTitle="T4" , BookAuthor="A4"},

            };
        }

    }
}
