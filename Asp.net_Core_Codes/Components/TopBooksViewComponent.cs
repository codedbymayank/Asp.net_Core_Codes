using Asp.net_Core_Codes.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Asp.net_Core_Codes.Components
{
    public class TopBooksViewComponent : ViewComponent
    {
        private readonly BookRepository _repository = null;

        public TopBooksViewComponent(BookRepository repository)
        {
            //If are using same variable name , then u have to use this keyword
            _repository = repository;
        }
        //If u need sync , then this async is not required 
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var books = await _repository.GetTopBooksAsync();
            return View(books);
        }
    }
}
