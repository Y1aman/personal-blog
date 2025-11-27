# Personal Blog 📝  
A simple personal blog built using **ASP.NET Core Razor Pages**, following the project requirements from roadmap.sh.  
Visitors can read articles, while the admin can add, edit, and delete them — all stored as JSON files without any database.

---

## 🚀 Features

### 👤 Visitor Section
- **Home Page:** Lists all articles (title + publish date)
- **Article Page:** Displays the full content of any article

### 🔐 Admin Section
- **Login Page:** Simple hardcoded authentication
- **Dashboard:** View all articles with actions (Add/Edit/Delete)
- **Add Article:** Create a new article
- **Edit Article:** Update an existing article
- **Delete Article:** Remove an article permanently
- **Logout:** Ends admin session

---

## 📂 Storage (File-based)

Every article is saved as its own `.json` file inside:

```
articles/
   1.json
   2.json
   3.json
```

Example JSON:

```json
{
  "Id": 3,
  "Title": "Example Article",
  "Content": "Lorem ipsum...",
  "PublishDate": "2024-07-21T00:00:00"
}
```

No database is used — everything is stored in the file system.

---

## 🛠️ Technologies Used
- ASP.NET Core 8 Razor Pages  
- C#  
- Sessions (admin auth)  
- JSON file storage  
- HTML/CSS (default Razor layout)

---

## 📦 Project Structure

```
/Models
   Article.cs

/Services
   ArticleService.cs

/Pages
   Index.cshtml
   Article.cshtml
   Login.cshtml
   Dashboard.cshtml
   AddArticle.cshtml
   EditArticle.cshtml
   DeleteArticle.cshtml
   Logout.cshtml
```

---

## 🔧 ArticleService Methods
- **GetAllArticles()** → returns all articles  
- **GetArticleById(id)** → loads one article  
- **SaveArticle(article)** → creates or updates JSON file  
- **DeleteArticle(id)** → deletes JSON file  
- **GenerateId()** → returns next available ID  

---

## 🔐 Default Admin Login

```
username: admin
password: 123
```

---

## ▶️ How to Run

1. Clone or download repository  
2. Open in Visual Studio  
3. Run the project  
4. Visit:

```
/Login
```

5. Log in → manage all articles from Dashboard

---

## 📘 License
Free to use and modify.

## Project URL
https://roadmap.sh/projects/personal-blog
