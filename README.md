# Personal Blog 📝  
A simple personal blog built using **ASP.NET Core Razor Pages**, following the project requirements from roadmap.sh.  
Visitors can read articles, while the admin can add, edit, and delete them.  
The application supports **two storage modes: JSON files and SQLite**, configurable from `appsettings.json`.

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

## 📂 Storage Modes

The project supports **two interchangeable storage modes**, selected from `appsettings.json`.

### 🗂️ JSON (File-based)
Each article is saved as its own `.json` file inside:

Articles/
1.json
2.json
3.json


Example JSON file:

```json
{
  "Id": 3,
  "Title": "Example Article",
  "Content": "Lorem ipsum...",
  "PublishDate": "2024-07-21T00:00:00"
}
No database is required in this mode.

🗄️ SQLite (Database-based)
Articles can also be stored in a SQLite database using Entity Framework Core.

Database file: blog.db

Created automatically on first run

Data stored in an Articles table

No manual setup or migrations required for basic usage

⚙️ Storage Configuration
Storage mode is selected from appsettings.json:

"StorageMode": "Json"
or

"StorageMode": "Sqlite"
The application uses a repository pattern with IArticleRepository to switch storage implementations automatically at runtime.

🛠️ Technologies Used
ASP.NET Core 8 Razor Pages

C#

Entity Framework Core (SQLite)

Sessions (admin authentication)

JSON file storage

HTML/CSS (default Razor layout)

📦 Project Structure
/Models
   Article.cs

/Services
   ArticleService.cs
   IArticleRepository.cs
   JsonArticleRepository.cs
   SqliteArticleRepository.cs

/Pages
   Index.cshtml
   Article.cshtml
   Login.cshtml
   Dashboard.cshtml
   AddArticle.cshtml
   EditArticle.cshtml
   DeleteArticle.cshtml
   Logout.cshtml
🔧 Article Repository Methods
GetAll() → returns all articles

GetById(id) → loads one article

Save(article) → creates or updates an article

DeleteById(id) → deletes an article

GenerateId() → returns next available ID (JSON mode)

🔐 Default Admin Login
username: admin
password: 123
▶️ How to Run
Clone or download the repository

Open the project in Visual Studio

Configure StorageMode in appsettings.json

Run the project

Visit:

/Login
Log in and manage all articles from the Dashboard

📘 License
Free to use and modify.

🔗 Project URL
https://roadmap.sh/projects/personal-blog
