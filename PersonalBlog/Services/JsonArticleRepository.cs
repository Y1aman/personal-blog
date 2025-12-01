using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using PersonalBlog.Models;

public class JsonArticleRepository : IArticleRepository
{
    private readonly string _path;

    public JsonArticleRepository()
    {
        _path = Path.Combine(Directory.GetCurrentDirectory(), "articles");
        if(!Directory.Exists(_path))
        {
            Directory.CreateDirectory(_path);
        }
    }
    public List<Article> GetAll()
    {
        var files = Directory.GetFiles(_path, "*.json");
        var articles = new List<Article>();

        foreach(var file in files)
        {
            var json = File.ReadAllText(file);
            var article = JsonSerializer.Deserialize<Article>(json);
            if(article != null)
            {
                articles.Add(article);
            }
            return articles.OrderByDescending(a => a.PublishDate).ToList();
        }
    }
    public Article? GetById(int id)
    {
        var filePath = Path.Combine(_path, $"{id}.json");
        if(!File.Exists(filePath))
        {
            return null;
        }
        var json = File.ReadAllText(filePath);
        var article = JsonSerializer.Deserialize<Article>(json);
        return article;
    }
    public void Save(Article article)
    {
        var filePath = Path.Combine(_path, $"{article.Id}.json");
        var json = JsonSerializer.Serialize(article, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
    public void DeleteById(int id)
    {
        var filePath = Path.Combine(_path, $"{id}.json");
        if(File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
    public int GenerateId()
    {
        var files = Directory.GetFiles(_path, "*.json");
        if(files.Length == 0)
        {
            return 1;
        }
        var ids= files.Select(file => 
        {
            var fileName = Path.GetFileNameWithoutExtension(file);
            return int.TryParse(fileName, out var id) ? id : 0;
        });
        return ids.Max() + 1;
    }
}