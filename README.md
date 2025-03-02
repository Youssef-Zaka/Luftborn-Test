# Luftborn Test
 
# 📖 Bookmarted - Online Bookstore

## 📚 Project Overview
Bookmarted is a simple yet robust online bookstore application developed using:
- **Backend:** ASP.NET Core with a **Clean Architecture** approach.
- **Frontend:** Angular with a **single-page application** (SPA) design.
- **Database:** SQL Server with **Entity Framework Core** for **ORM**.
- **Automatic Seeding:** The database is automatically seeded with **mock data** upon application startup.

---

## 🛠 Features
- **Full CRUD Operations** for **Books**, **Stores**, and **Book Availability**.
- **Automatic Data Seeding** to populate the **database** with **sample data**.
- **RESTful API** with **Swagger** documentation.
- **Angular Frontend** with a clean **UI** to browse books by **store**.
- **Cross-Origin Resource Sharing (CORS)** enabled for **frontend-backend communication**.

---

## 🚀 Getting Started

### 🖥️ Prerequisites
- **.NET SDK** (7.0 or later)
- **Node.js** (v14+ recommended)
- **Angular CLI** (`npm install -g @angular/cli`)
- **SQL Server** instance (e.g., **SQL Server Express**)

---

### 📂 Project Structure
```plaintext
Bookmarted
├─ Application          # Business logic & Services
├─ Domain               # Entities & Enums
├─ Infrastructure       # Data access, Repositories, Seeding
└─ WebAPI               # ASP.NET Core API
bookmarted-frontend  # Angular Frontend
README.md
```
---

# 🛠️ Backend Setup

### 1. Configure the Database Connection
- **Edit `appsettings.json`:**

```json
"ConnectionStrings": {
  "DefaultConnection": "data source=YOUR_SERVER_NAME;initial catalog=BookmartedDb;trusted_connection=true"
}
```
### 2. Apply Migrations and Seed Data
- Automatic Seeding: The DataSeeder class automatically applies migrations and seeds data when the application starts.

### 3. Run the Backend API
```plaintext
cd Bookmarted
dotnet run
```
- Access the API at: https://localhost:7008/swagger
---
# 💻 Frontend Setup (bookmarted-frontend)
### 1. Install Dependencies
```plaintext
cd Bookmarted/bookmarted-frontend
npm install
```
### 2. Run the Angular Application
```plaintext
ng serve --open
```
- The frontend will be available at: http://localhost:4200
---
# 📄 License

This project is licensed under the MIT License.
