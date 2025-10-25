# 🎓 InternDB - Intern Management System

<div align="center">
  <img src="https://img.shields.io/badge/.NET-9.0-blue" alt=".NET 9.0">
  <img src="https://img.shields.io/badge/Blazor-Server-purple" alt="Blazor Server">
  <img src="https://img.shields.io/badge/Entity%20Framework-Core-green" alt="Entity Framework Core">
  <img src="https://img.shields.io/badge/SQL%20Server-Database-red" alt="SQL Server">
</div>

<div align="center">
  <h3>🚀 Modern intern management system built with .NET Core and Blazor Server</h3>
</div>

---

## ✨ Features

- **👤 Admin Dashboard** - Real-time analytics with total interns, recent additions, and department statistics
- **👥 Intern Management** - Complete CRUD operations for intern data
- **🏢 Department Filtering** - IT, CRC, Biomedical, HR, and Quality departments
- **🔍 Search & Filter** - Quick search and advanced filtering capabilities
- **📱 Responsive Design** - Works on desktop, tablet, and mobile
- **🔒 Secure Authentication** - Cookie-based admin login system
- **📊 Data Export** - Export intern data to Excel format for reporting and analysis

---

## 🛠️ Tech Stack

| Backend | .NET 9.0, ASP.NET Core, Blazor Server |
| Database | SQL Server, Entity Framework Core |
| Frontend | Razor Pages, Bootstrap 5.0 |
| Authentication | Custom Cookie-based Authentication |

---

## 🚀 Quick Start

### Prerequisites
- .NET 9.0 SDK
- SQL Server or SQL Server LocalDB
- Visual Studio 2022 or VS Code

### Installation

1. **Clone and navigate**
   ```bash
   git clone https://github.com/shantanu-84/InternDB.git
   cd InternDB/InternDB
   ```

2. **Restore and run**
   ```bash
   dotnet restore
   dotnet ef database update
   dotnet run
   ```

3. **Access the application**
   ```
   http://localhost:5112/login
   ```

### 🔑 Login Credentials
- **Username:** `admin`
- **Password:** `admin123`

---
## 🏗️ Project Structure

```
InternDB/
├── 📁 Data/
│   ├── Intern.cs                 # Intern entity model
│   ├── InternDbContext.cs        # Database context
│   └── Migrations/               # Entity Framework migrations
├── 📁 Pages/
│   ├── Home.razor               # Landing page
│   ├── Login.razor              # Authentication
│   ├── SimpleAdminDashboard.razor # Analytics dashboard
│   ├── Interns.razor            # Intern management
│   └── AddIntern.razor          # Add new intern
├── 📁 Services/
│   ├── InternService.cs         # Business logic
│   └── SimpleAuthenticationStateProvider.cs # Auth provider
├── 📁 Shared/
│   ├── MainLayout.razor         # Main layout
│   └── NavMenu.razor            # Navigation menu
└── 📁 wwwroot/
    ├── css/                     # Stylesheets
    └── js/                      # JavaScript files
```

---

## 📊 Dashboard Features

- **Total Interns Count** - Real-time count of all registered interns
- **Recent Additions** - Latest 3 interns with join dates
- **Department Analytics** - Top 3 departments with intern counts
- **Status Tracking** - Active and completed intern statuses

---

## 🌐 Web Access

The application is hosted at:
```
https://vs53z7cz-7090.inc1.devtunnels.ms/
```

⚠️ **Important Note:** The webapp is not directly accessible. You need to contact me first as the application needs to be running on the server side. Please reach out to get access.

---

## 🛡️ Security

- Secure cookie-based authentication
- Input validation and SQL injection protection
- Session management with automatic timeout

---

## 🚀 Future Enhancements

- Email notifications
- Report generation (PDF export)
- Advanced analytics with charts
- RESTful API endpoints
- Mobile application

---

## 👥 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

---

## 📄 License

This project is licensed under the MIT License.

---

## 👨‍💻 Author

**Shantanu Rathod**
- GitHub: [@shantanu-84](https://github.com/shantanu-84)
- Email: shantanurathod3864@gmail.com

---

<div align="center">
  <h3>⭐ If you found this project helpful, please give it a star! ⭐</h3>
  <p>Made with ❤️ by <a href="https://github.com/shantanu-84">Shantanu Rathod</a></p>
</div>


