using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly ArticleService _service;

        public List<Article> Articles { get; set; } = new List<Article>();

        public DashboardModel(ArticleService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            var loggedIn = HttpContext.Session.GetString("LoggedIn");

            if (loggedIn != "true")
                return RedirectToPage("/Login");

            Articles = _service.GetAllArticles();

            return Page();
        }
    }
}
