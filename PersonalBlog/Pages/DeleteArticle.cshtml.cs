using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Services;

namespace PersonalBlog.Pages
{
    public class DeleteArticleModel : PageModel
    {
        private readonly ArticleService _service;

        public DeleteArticleModel(ArticleService service)
        {
            _service = service;
        }

        public IActionResult OnGet(int id)
        {
            var loggedIn = HttpContext.Session.GetString("LoggedIn");
            if (loggedIn != "true")
                return RedirectToPage("/Login");

            _service.DeleteArticle(id);

            return RedirectToPage("/Dashboard");
        }
    }
}
