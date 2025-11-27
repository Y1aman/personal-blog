using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PersonalBlog.Models;
using PersonalBlog.Services;

namespace PersonalBlog.Pages
{
    public class EditArticleModel : PageModel
    {
        private readonly ArticleService _service;

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string Title { get; set; } = string.Empty;

        [BindProperty]
        public string Content { get; set; } = string.Empty;

        [BindProperty]
        public DateTime PublishDate { get; set; }

        public EditArticleModel(ArticleService service)
        {
            _service = service;
        }

        public IActionResult OnGet(int id)
        {
            var loggedIn = HttpContext.Session.GetString("LoggedIn");
            if (loggedIn != "true")
                return RedirectToPage("/Login");

            var article = _service.GetArticleById(id);
            if (article == null)
                return RedirectToPage("/Dashboard");

            Id = article.Id;
            Title = article.Title;
            Content = article.Content;
            PublishDate = article.PublishDate;

            return Page();
        }

        public IActionResult OnPost()
        {
            var updated = new Article
            {
                Id = this.Id,
                Title = this.Title,
                Content = this.Content,
                PublishDate = this.PublishDate
            };

            _service.SaveArticle(updated);

            return RedirectToPage("/Dashboard");
        }
    }
}
