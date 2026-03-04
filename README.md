# 📋 Leave Management System

Leave Management System built using **ASP.NET Core Web API + ASP.NET Core MVC + Entity Framework Core**.

This system allows users to apply for leave, manage leave requests, and track leave status history.

---

# 📌 Project Overview

The Leave Management System is a **two-tier application** consisting of:

- Backend REST API
- Frontend MVC UI

It allows:

- Users to apply for leave
- Admin to manage leave requests
- Track leave status history
- Maintain structured leave records

---

# 🏗️ Solution Architecture

This solution contains **2 Projects**

---

## 1️⃣ Leave_ManagementAPI (Backend - Web API)

Responsible for:

- REST APIs
- Business logic
- Database operations
- Entity Framework Core integration

### Main Structure

```
Controllers/
Models/
LeaveManagementDbContext.cs
Program.cs
```

### Controllers

- LeaveRequestController.cs  
- LeaveStatusHistoryController.cs  
- UserController.cs  

### Models

- User.cs  
- LeaveRequest.cs  
- LeaveStatusHistory.cs  
- LeaveManagementDbContext.cs  

---

## 2️⃣ UILeave_Management (Frontend - MVC)

Responsible for:

- Razor Views
- User Interface
- API Integration
- Displaying Leave Records

### Main Structure

```
Controllers/
Models/
Views/
wwwroot/
```

### MVC Controllers

- HomeController.cs  
- LeaveRequestMVCController.cs  
- LeaveStatusHistoryMVCController.cs  
- UserMVCController.cs  

---

# 🗄️ Database

- SQL Server
- Entity Framework Core
- Code First Approach

### Main Tables

- Users
- LeaveRequests
- LeaveStatusHistories

---

# 🛠️ Technologies Used

- ASP.NET Core Web API
- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQL Server
- Bootstrap

---

# ⚙️ How to Run

## 1️⃣ Clone Repository

```
git clone https://github.com/Amitdangebtl/Leave-Management.git
```

---

## 2️⃣ Configure Database

Update **appsettings.json** in API project:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=LeaveManagementDB;Trusted_Connection=True;"
}
```

---

## 3️⃣ Apply Migrations

```
dotnet ef database update
```

---

## 4️⃣ Run API

```
dotnet run --project Leave_ManagementAPI
```

---

## 5️⃣ Run MVC UI

```
dotnet run --project UILeave_Management
```

---

# 📌 Features

✔ Apply for Leave  
✔ View Leave Requests  
✔ Track Leave Status History  
✔ Manage Users  
✔ Clean MVC + API Architecture  
✔ EF Core Code First Implementation  

---

# 📷 Application Screenshots

## 🔹 Leave Management Dashboard

![Dashboard](https://raw.githubusercontent.com/Amitdangebtl/Leave-Management/main/Leave%20Management%20System%20DeshBoard.png)

---

## 🔹 User List

![User List](https://raw.githubusercontent.com/Amitdangebtl/Leave-Management/main/User%20List.png)

---

## 🔹 Add User

![Add User](https://raw.githubusercontent.com/Amitdangebtl/Leave-Management/main/Add%20User.png)

---

## 🔹 Update User

![Update User](https://raw.githubusercontent.com/Amitdangebtl/Leave-Management/main/Update%20User.png)

---

## 🔹 Apply for Leave

![Apply Leave](https://raw.githubusercontent.com/Amitdangebtl/Leave-Management/main/Apply%20for%20Leave.png)

---

## 🔹 Leave Requests

![Leave Requests](https://raw.githubusercontent.com/Amitdangebtl/Leave-Management/main/Leave%20Requests.png)

---

## 🔹 Leave Details

![Leave Details](https://raw.githubusercontent.com/Amitdangebtl/Leave-Management/main/Leave%20Details.png)

---

## 🔹 Edit Leave

![Edit Leave](https://raw.githubusercontent.com/Amitdangebtl/Leave-Management/main/Edit%20Leave.png)

---

## 🔹 Leave Status History

![Leave Status History](https://raw.githubusercontent.com/Amitdangebtl/Leave-Management/main/Leave%20Status%20History.png)

---

## 🔹 Add Leave Status History

![Add Leave Status](https://raw.githubusercontent.com/Amitdangebtl/Leave-Management/main/Add%20Leave%20Status%20History.png)

---

## 🔹 History Details

![History Details](https://raw.githubusercontent.com/Amitdangebtl/Leave-Management/main/History%20Detail.png)

---

# 🎯 Key Highlights

✔ Two-project architecture (UI + API)  
✔ Clean separation of concerns  
✔ Entity Framework Core integration  
✔ RESTful API design  
✔ Structured leave tracking system  

---

# 👨‍💻 Author

**Amit Dange**  
.NET Developer
