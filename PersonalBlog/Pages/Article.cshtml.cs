using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Pages
{
    public class ArticleModel : PageModel
    {
        private readonly ArticleService _service;

        public Article? Article { get; set; }

        public ArticleModel(ArticleService service)
        {
            _service = service;
        }

        public IActionResult OnGet(int id)
        {
            Article = _service.GetArticleById(id);

            if (Article == null)
            {
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}
