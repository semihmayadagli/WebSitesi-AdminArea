using HaftalikGorev.Data;
using Microsoft.AspNetCore.Mvc;

namespace HaftalikGorev.ViewComponents
{
    public class Categories:ViewComponent
    {
        private readonly Databasecontext _databasecontext;

        public Categories(Databasecontext databasecontext)
        {
            _databasecontext = databasecontext;
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            return View(_databasecontext.Categories.ToList());        
        }
    }
}
