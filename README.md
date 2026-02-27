# WinForms CRUD Users (MS Access)

## 📌 Project Overview
This is a simple Windows Forms CRUD (Create, Read, Update, Delete) application using:
- C#
- .NET 7 / .NET 8 (Windows)
- MS Access Database (.accdb)
- OleDb Connection

---

## 🛠 Requirements
- Visual Studio 2022 or later
- .NET Desktop Development workload installed
- Microsoft Access Database Engine (ACE.OLEDB.12.0)

---

## 🗂 Database Setup

Create a database file named:

```
MyDatabase.accdb
```

Create a table named:

```
users
```

Structure:

| Field     | Data Type     |
|-----------|--------------|
| id        | AutoNumber (Primary Key) |
| name      | Short Text   |
| email     | Short Text   |
| password  | Short Text   |
| active    | Yes/No       |

Place the database file in the project root directory.

---

## ▶ How To Run

1. Open the project in Visual Studio
2. Restore NuGet packages (if required)
3. Build the solution
4. Run the project

---

## ⚙ Change Target Platform

### For x64:

1. Right-click project → Properties
2. Go to Build tab
3. Platform target → Select **x64**
4. Uncheck "Prefer 32-bit"
5. Rebuild project

### For x86:

1. Platform target → Select **x86**
2. Rebuild project

> ⚠ If ACE.OLEDB driver gives error, match your platform with installed Access Engine version.

---

## 📦 Publish (Optional)

1. Right-click project → Publish
2. Select Folder
3. Choose target runtime (win-x64 / win-x86)
4. Publish

---

## 👨‍💻 Author
Developed for CRUD learning using WinForms + MS Access.
