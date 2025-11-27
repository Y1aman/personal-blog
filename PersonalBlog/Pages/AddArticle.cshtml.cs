using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Pages
{
    public class AddArticleModel : PageModel
    {
        private readonly ArticleService _service;

        [BindProperty]
        public string Title { get; set; } = string.Empty;

        [BindProperty]
        public string Content { get; set; } = string.Empty;

        [BindProperty]
        public DateTime PublishDate { get; set; } = DateTime.Now;

        public AddArticleModel(ArticleService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            var loggedIn = HttpContext.Session.GetString("LoggedIn");
            if (loggedIn != "true")
                return RedirectToPage("/Login");

            return Page();
        }

        public IActionResult OnPost()
        {
            var newArticle = new Article
            {
                Id = _service.GenerateNewId(),
                Title = this.Title,
                Content = this.Content,
                PublishDate = this.PublishDate
            };

            _service.SaveArticle(newArticle);

            return RedirectToPage("/Dashboard");
        }
    }
}
