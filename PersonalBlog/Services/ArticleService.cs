using PersonalBlog.Models;

namespace PersonalBlog.Services
{
    public class ArticleService
    {
        private readonly IArticleRepository _repository;

        public ArticleService(IArticleRepository repository)
        {
            _repository = repository;
        }

        public List<Article> GetAllArticles()
        {
            return _repository.GetAll();
        }

        public Article? GetArticleById(int id)
        {
            return _repository.GetById(id);
        }

        public void SaveArticle(Article article)
        {
            _repository.Save(article);
        }

        public void DeleteArticle(int id)
        {
            _repository.DeleteById(id);
        }

        public int GenerateNewId()
        {
            return _repository.GenerateId();
        }
    }
}
