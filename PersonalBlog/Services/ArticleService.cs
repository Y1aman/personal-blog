using PersonalBlog.Models;

namespace PersonalBlog.Services
{
    public class ArticleService
    {
        private readonly string _path;

        public ArticleService()
        {
            _path = Path.Combine(Directory.GetCurrentDirectory(), "articles");
            EnsureDirectory();
        }

        private void EnsureDirectory()
        {
            if (!Directory.Exists(_path))
            {
                Directory.CreateDirectory(_path);
            }
        }
        public List<Article> GetAllArticles()
        {
            var articles = new List<Article>();
            var files = Directory.GetFiles(_path, "*.json");
            foreach (var file in files)
            {
                var json = File.ReadAllText(file);
                var article = System.Text.Json.JsonSerializer.Deserialize<Article>(json);

                if (article != null)
                {
                    articles.Add(article);
                }
            }
            return articles;
        }
        public Article? GetArticleById(int id)
        {
            var filePath = Path.Combine(_path, $"{id}.json");
            if (!File.Exists(filePath))
            {
                return null;
            }
            var json = File.ReadAllText(filePath);

            var article = System.Text.Json.JsonSerializer.Deserialize<Article>(json);

            return article;
        }

    }
}
