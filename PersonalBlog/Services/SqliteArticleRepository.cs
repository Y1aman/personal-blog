using PersonalBlog.Models;

public class SqliteArticleRepository : IArticleRepository
{
    private readonly AppDbContext _context;

    public SqliteArticleRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Article> GetAll()
    {
        return _context.Articles.ToList();
    }

    public Article? GetById(int id)
    {
        return _context.Articles.FirstOrDefault(a => a.Id == id);
    }

    public void Save(Article article)
    {
        if (article.Id == 0)
        {
            // مقال جديد
            _context.Articles.Add(article);
        }
        else
        {
            // تعديل مقال موجود
            _context.Articles.Update(article);
        }

        _context.SaveChanges();
    }

    public void DeleteById(int id)
    {
        var article = _context.Articles.Find(id);
        if (article != null)
        {
            _context.Articles.Remove(article);
            _context.SaveChanges();
        }
    }

    public int GenerateId()
    {
        // SQLite يعمل AutoIncrement
        return 0;
    }
}
