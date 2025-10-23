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

---

## 🛠️ Tech Stack

| Backend | .NET 9.0, ASP.NET Core, Blazor Server |
|---------|----------------------------------------|
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
   http://localhost:5112
   ```

### 🔑 Login Credentials
- **Username:** `admin`
- **Password:** `admin123`

---

## 📱 Screenshots

<div align="center">

### 🏠 Home Page
![Home Page](https://via.placeholder.com/800x400/007bff/ffffff?text=Welcome+to+InternDB)

### 📊 Dashboard
![Dashboard](https://via.placeholder.com/800x400/28a745/ffffff?text=Analytics+Dashboard)

### 👥 Interns Management
![Interns](https://via.placeholder.com/800x400/ffc107/000000?text=Intern+Management)

</div>

---

## 🏗️ Project Structure

```
InternDB/
├── Data/                    # Entity models and DbContext
├── Pages/                   # Blazor pages (Home, Login, Dashboard, Interns)
├── Services/                # Business logic and authentication
├── Shared/                  # Layout and navigation components
└── wwwroot/                 # Static files (CSS, JS)
```

---

## 📊 Dashboard Features

- **Total Interns Count** - Real-time count of all registered interns
- **Recent Additions** - Latest 3 interns with join dates
- **Department Analytics** - Top 3 departments with intern counts
- **Status Tracking** - Active and completed intern statuses

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
