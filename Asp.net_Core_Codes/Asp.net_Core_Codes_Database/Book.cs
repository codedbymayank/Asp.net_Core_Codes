namespace Asp.net_Core_Codes.Asp.net_Core_Codes_Database
{
    public class Book
    {
        public int Bookno { get; set; }
        public string Bookdesc { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public string Action { get; set; }
        public int NoOfPages { get; set; }
        public string BookLanaguage { get; set; }

        public DateTime ? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
