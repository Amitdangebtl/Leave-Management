# 📋 Leave Management System

Leave Management System built using **ASP.NET Core Web API + ASP.NET Core MVC + Entity Framework Core**.

This system allows users to apply for leave, track leave status, and manage leave history.

---

## 📌 Project Overview

The Leave Management System is a two-tier application consisting of:

- Backend REST API
- Frontend MVC UI

It allows:

- Users to apply for leave
- Admin to manage leave requests
- Track leave status history
- Maintain structured leave records

---

## 🏗️ Solution Architecture

This solution contains **2 Projects**:

---

### 1️⃣ Leave_ManagementAPI (Backend - Web API)

Responsible for:

- REST APIs
- Business logic
- Database operations
- Entity Framework Core integration

**Main Structure:**

```
Controllers/
Models/
LeaveManagementDbContext.cs
Program.cs
```

**Controllers:**

- LeaveRequestController.cs  
- LeaveStatusHistoryController.cs  
- UserController.cs  

**Models:**

- User.cs  
- LeaveRequest.cs  
- LeaveStatusHistory.cs  
- LeaveManagementDbContext.cs  

---

### 2️⃣ UILeave_Management (Frontend - MVC)

Responsible for:

- Razor Views
- User interface
- API integration
- Displaying leave records

**Main Structure:**

```
Controllers/
Models/
Views/
wwwroot/
```

**MVC Controllers:**

- HomeController.cs  
- LeaveRequestMVCController.cs  
- LeaveStatusHistoryMVCController.cs  
- UserMVCController.cs  

---

## 🗄️ Database

- SQL Server  
- Entity Framework Core  
- Code First Approach  

Main Tables:

- Users  
- LeaveRequests  
- LeaveStatusHistories  

---

## 🛠️ Technologies Used

- ASP.NET Core Web API  
- ASP.NET Core MVC  
- C#  
- Entity Framework Core  
- SQL Server  
- Bootstrap  

---

## ⚙️ How to Run

### 1️⃣ Clone Repository

```
git clone https://github.com/Amitdangebtl/Leave-Management.git
```

---

### 2️⃣ Configure Database

Update `appsettings.json` in API project:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=LeaveManagementDB;Trusted_Connection=True;"
}
```

---

### 3️⃣ Apply Migrations

```
dotnet ef database update
```

---

### 4️⃣ Run API

```
dotnet run --project Leave_ManagementAPI
```

---

### 5️⃣ Run MVC UI

```
dotnet run --project UILeave_Management
```

---

## 📌 Features

✔ Apply for Leave  
✔ View Leave Requests  
✔ Track Leave Status History  
✔ Manage Users  
✔ Clean MVC + API Architecture  
✔ EF Core Code First Implementation  

---

## 🎯 Key Highlights

- Two-project architecture (UI + API)  
- Clean separation of concerns  
- Entity Framework Core integration  
- RESTful API design  
- Structured leave tracking system  

---

## 👨‍💻 Author

**Amit Dange**  
.NET Developer  
