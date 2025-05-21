# 📁 Secure Document Storage System

A secure, versioned document storage system built with ASP.NET Core Web API.
This solution enables authenticated users to upload, retrieve, and manage documents securely, 
with support for version history and user-specific access control.

---

## 🚀 Features

- 🔐 JWT-based authentication
- 🧾 File versioning (automatic on re-upload with same name)
- 👤 User-specific document access
- 💾 Document storage as BLOBs in SQL Server
- 🧪 Unit tests using xUnit + InMemory EF Core
- 🧠 Clean architecture with dependency injection and SOLID principles

---

## 🛠️ Tech Stack

| Component       | Technology            |
|----------------|------------------------|
| Backend         | ASP.NET Core 8 (Web API) |
| Auth            | JWT (JSON Web Token)    |
| Database        | SQL Server (BLOB support) |
| ORM             | Entity Framework Core   |
| Testing         | xUnit, Moq              |

---

## ⚙️ Setup Instructions

1. **Clone the repo**

   ```bash
   git clone https://github.com/muzzafr/SecureDocStorage/tree/main/SecureDocStorage
   cd SecureDocStorage
