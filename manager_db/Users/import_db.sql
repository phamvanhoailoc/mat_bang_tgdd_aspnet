USE web_ecommerce 

--thêm 10 người dùng 
INSERT INTO users (info, user_name, hash_password, created_at, updated_at)
VALUES
('{"name": "User1", "email": "user1@example.com"}', 'user1', HASHBYTES('SHA2_256','123456'), '2023-10-27', '2023-10-27'),
('{"name": "User2", "email": "user2@example.com"}', 'user2', HASHBYTES('SHA2_256','123456'), '2023-10-27', '2023-10-27'),
('{"name": "User3", "email": "user3@example.com"}', 'user3', HASHBYTES('SHA2_256','123456'), '2023-10-27', '2023-10-27')

GO