using Microsoft.EntityFrameworkCore;

namespace Asp.net_Core_Codes.Asp.net_Core_Codes_Database
{
    /*Here we are creating our db context class and its because we are inheriting DbContext over here*/
    public class BookNestContext : DbContext
    {
        public BookNestContext(DbContextOptions<BookNestContext> booknest) : base(booknest)
        {

        }

        /*Name which we will give over here , table will get created with this name and columns are those which in Book.cs file*/
        public DbSet<Book> Books { get; set; }

        // This is because to connect db with class which we have created 
        // Here we are overriding to configure this method
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
            /*Here we are getting sql server because we are using package for sql server*/
            // Integrated Security=True :- this is because we are using windows authentication
        //    optionsBuilder.UseSqlServer("Server=.;Database=BookNest;Integrated Security=True;");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
