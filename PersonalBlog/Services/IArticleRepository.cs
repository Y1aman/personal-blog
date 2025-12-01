using System.Collections.Generic;
using PersonalBlog.Models;

public interface IArticleRepository
{
    List<Article> GetAll();
    Article? GetById(int id);
    void Save(Article article);
    void DeleteById(int id);
    void GenerateId();
}