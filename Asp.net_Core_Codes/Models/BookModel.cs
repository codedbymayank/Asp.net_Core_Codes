using Asp.net_Core_Codes.Helper;
using System.ComponentModel.DataAnnotations;
namespace Asp.net_Core_Codes.Models
{
    public class BookModel
    {
        //Like DateTime there are multiple more datatypes which u can use 
        [DataType(DataType.DateTime)]
        public string CustomField { get; set; }
        public int Bookno { get; set; }
        //This is an attribute which is inbuilt inside dataannotation namespace 
        //Here we are adding our custom error message
        [Required(ErrorMessage = "Enter Book Description")]
        [StringLength(100)]
        public string Bookdesc { get; set; }
        //[Required]
        //Our Custom validation attribute
        [MyCustomValidation]
        public string BookTitle { get; set; }
        [Required]
        //This for displaying our custom message on UI 
        [Display(Name = "Author Name")]
        public string BookAuthor { get; set; }
        public string Action { get; set; }
       
        public int NoOfPages { get; set; }

        [Display(Name ="Book Language")]
        public string BookLanaguage { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        
        public IFormFile ImageUrl { get; set; }

        public string ImgPath { get; set; }
    }
}
