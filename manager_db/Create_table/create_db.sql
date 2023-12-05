USE mat-bang-tgdd

DROP TABLE users

--bảng người dùng
CREATE TABLE users(
    user_id INT PRIMARY KEY IDENTITY(1,1),
    info NVARCHAR(MAX),
    user_name NVARCHAR(100) UNIQUE NOT NULL,
    hash_password NVARCHAR(200) NOT NULL,
    created_at DATE,
    updated_at DATE,
);


DROP TABLE products

--bảng sản phẩm
CREATE TABLE products(
    product_id INT PRIMARY KEY IDENTITY(1,1),
    info NVARCHAR(MAX),
    category NVARCHAR(MAX),
    key_product NVARCHAR(100),
    current_status VARCHAR,
    created_at DATE,
    updated_at DATE,
);

DROP TABLE file_system

--bảng lưu thông tin file upload
CREATE TABLE file_system(
    file_system_id INT PRIMARY KEY IDENTITY(1,1),
    file_type VARCHAR(255),
    client_filename VARCHAR(255),
    server_filename VARCHAR(255),
    file_group VARCHAR(255),
    file_path VARCHAR(255),
    file_ext VARCHAR(255),
    view_type VARCHAR(255),
    url_file VARCHAR(500),
    user_create VARCHAR(128),
    user_update VARCHAR(128),
    file_size FLOAT,
    time_create DATE,
    time_update DATE
);
