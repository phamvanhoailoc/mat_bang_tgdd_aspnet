# CQRS + MediatR and Repository Pattern with ASP.NET Core Web Api
## Mô tả
- Mục tiêu của dự án này là để cấu trúc thư mục, định hình style code để có thể mở rộng sau này.
- Dự án này là một ứng dụng ASP.NET Core API xây dựng trên kiến trúc CQRS (Command Query Responsibility Segregation) và sử dụng thư viện MediatR để quản lý các yêu cầu và trả về. Các thao tác với cơ sở dữ liệu được thực hiện thông qua Repository Pattern và kết nối với SQL Server bằng ADO.NET và Entity Framework.
## Tính Năng Chính
- CQRS và MediatR: Tận dụng kiến trúc CQRS để phân tách lớp command và query. Sử dụng thư viện MediatR để xử lý các yêu cầu và trả về.

- Repository Pattern: Sử dụng Repository Pattern để truy cập và thực hiện thao tác với cơ sở dữ liệu một cách dễ dàng và tái sử dụng mã.

- ADO.NET và Entity Framework: Kết hợp sử dụng ADO.NET và Entity Framework để kết nối và tương tác với cơ sở dữ liệu SQL Server.

## Cài Đặt
Hướng dẫn cài đặt và chạy dự án trên máy cục bộ.
- git clone https://gitlab.com/phamvanhoailoc/cqrs-mediatr-and-repository-pattern-with-asp.net-core-web-api.git
- cd WebAPI-project-banhang
- dotnet restore
- dotnet run
## Yêu Cầu
- .NET Core 5

## Sử Dụng
#### Sử dụng Swagger UI
- POST /api/product/filter 
- POST /api/users/login
- POST /api/users/register


## Cấu Trúc Dự Án
Giải thích cấu trúc thư mục và mô tả ngắn về từng phần chính của dự án.

- /WebAPI-project-banhang
- | /Modules
- |- /M_Users
- |-- /Controllers
- |-- /Models
- |-- /Services
- |-- /Repositories
- |-- /Commands
- |-- /Queries
- |-- /DependencyInjection
- | /M_Products
- | /...

### Giải Thích Cấu Trúc Thư Mục:
#### Trong dự án này tôi chia thành nhiều modules, mỗi module sẽ chứa controllers, models, services,... của riêng module đó.
#### Tất cả service, repository, queries, command trong 1 module phải được khai báo ở file DependencyInjection.cs
![](https://gitlab.com/phamvanhoailoc/cqrs-mediatr-and-repository-pattern-with-asp.net-core-web-api/uploads/1345c15189432def39199aaaa52b328e/Screenshot_2023-11-14_205420.png)
#### Cuối cùng phải khai báo file DependencyInjection ở trong file startup của dự án
![](https://gitlab.com/phamvanhoailoc/cqrs-mediatr-and-repository-pattern-with-asp.net-core-web-api/uploads/1c6fb74dbeaf948a8a41f4d7f201e31d/Screenshot_2023-11-14_205502.png)


## Sơ Đồ Flow
![](https://gitlab.com/phamvanhoailoc/cqrs-mediatr-and-repository-pattern-with-asp.net-core-web-api/uploads/04a59f68415e2f12dc190299e2486546/Screenshot_2023-11-11_190329.png)


## Đóng Góp
Nếu bạn muốn đóng góp vào dự án, hãy tạo một Pull Request và mô tả rõ ràng về những thay đổi bạn đã thực hiện.

## Liên Hệ
- Hãy liên hệ với tôi qua email hoailocphamvan@gmail.com
