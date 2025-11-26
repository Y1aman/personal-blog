using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ArticleService _service;

        public List<Article> Articles { get; set; } = new List<Article>();

        public IndexModel(ArticleService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            Articles = _service.GetAllArticles();
        }
    }
}
