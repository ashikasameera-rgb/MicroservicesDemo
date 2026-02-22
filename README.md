# **Enterprise Microservices Prototype – Product & Order Services**

## **Overview**
This is a **microservices prototype** built using the **.NET 8 ecosystem**.  
It demonstrates:  

- **Clean Architecture**  
- **JWT Authentication**  
- **Event-driven communication** with **RabbitMQ** between `ProductService` and `OrderService`.  

This project is intended as a **learning and portfolio project** to showcase microservices architecture in a real-world-like setup.

---

## **Architecture**

```text
EnterpriseMicroservices/
│
├─ ProductService/
│   ├─ API/                # ASP.NET Core Web API
│   ├─ Application/        # Service interfaces, events
│   ├─ Domain/             # Entities
│   └─ Infrastructure/     # EF Core, Repositories
│
├─ OrderService/
│   ├─ API/
│   ├─ Application/
│   ├─ Domain/
│   └─ Infrastructure/
│
├─ EnterpriseMicroservices.slnx
└─ README.md
```

## **Architecture Highlights**

- **Clean Architecture** separates **API**, **Application**, **Domain**, and **Infrastructure**.  
- **Event-driven communication:** Orders trigger events consumed by ProductService via RabbitMQ.  
- **JWT Authentication:** Secure endpoints for both services. 
## **Features**

-  **Product CRUD** in ProductService  
-  **Order creation** in OrderService  
-  **Automatic product stock reduction** when an order is created  
-  **RabbitMQ consumer** in ProductService for order events  
-  **JWT authentication** for secure APIs  
-  **Entity Framework Core** with SQL Server for persistence  
-  **Clean Architecture structure**  

---

## **Tech Stack**

- **.NET 8 (ASP.NET Core)**  
- **Entity Framework Core + SQL Server**  
- **RabbitMQ** (for service-to-service events)  
- **JWT Authentication**  
- **Visual Studio 2026 / VS Code**  

--- 


## **Setup Instructions**
**1. Clone Repository**
```text
git clone https://github.com/ashikasameera-rgb/MicroservicesDemo.git
cd EnterpriseMicroservices
```
**2. Update Database**

For ProductService:
```text
cd ProductService.API
dotnet ef migrations add InitialCreate
dotnet ef database update
```
For OrderService:
```text
cd ../../OrderService.API
dotnet ef migrations add InitialCreate
dotnet ef database update
```
Ensure your appsettings.Development.json has the correct SQL Server connection strings.

**3. Run Services**

Start ProductService:
```text
dotnet run --project ProductService.API
```
Start OrderService:
```text
dotnet run --project OrderService.API
```
**Future Improvements / Extensions**

Implement API Gateway for routing



