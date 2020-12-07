USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT PK_user PRIMARY KEY (user_id)
)

CREATE TABLE units(
	unit_id INTEGER IDENTITY PRIMARY KEY,
	location_name VARCHAR(200) NOT NULL,
	unit_number INTEGER UNIQUE NOT NULL,
	unit_size VARCHAR(200) NOT NULL,
	pictures_unitnumber INTEGER,
	high_bid MONEY NOT NULL,
)

CREATE TABLE pictures(
	picture_id INTEGER IDENTITY PRIMARY KEY,
	picture_unitnumber INTEGER,
	picture_srclink VARCHAR(200) NOT NULL,
)

--populate default data: 'password'
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user@user.com','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin@admin.com','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');


INSERT INTO units (location_name, unit_number, unit_size, pictures_unitnumber, high_bid) VALUES ('Columbus, OH', '1000', '30 sqft', 4, 900);
INSERT INTO units (location_name, unit_number, unit_size, pictures_unitnumber, high_bid) VALUES ('New York, NY', '55', '50 sqft', 33, 1);

ALTER TABLE units ADD FOREIGN KEY (pictures_unitnumber) REFERENCES pictures(picture_unitnumber)


GO
--COMMIT TRANSACTION (There is no "BEGIN TRANSACTION")