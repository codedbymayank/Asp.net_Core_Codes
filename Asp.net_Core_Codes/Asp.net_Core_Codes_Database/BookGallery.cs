﻿namespace Asp.net_Core_Codes.Asp.net_Core_Codes_Database
{
    public class BookGallery
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }

        public Book Book { get; set; }
    }
}
