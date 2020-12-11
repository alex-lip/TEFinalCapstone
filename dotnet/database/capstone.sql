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
	user_id INT IDENTITY(1,1) NOT NULL,
	username VARCHAR(50) NOT NULL UNIQUE,
	password_hash VARCHAR(200) NOT NULL,
	salt VARCHAR(200) NOT NULL,
	user_role VARCHAR(50) NOT NULL,
	verification_status INT DEFAULT 0,
	CONSTRAINT PK_user PRIMARY KEY (user_id),
)

CREATE TABLE verification_code (
	user_id INT NOT NULL,
	code INT NOT NULL,
	FOREIGN KEY (user_id) REFERENCES users(user_id)
)

CREATE TABLE units(
	unit_id INTEGER IDENTITY PRIMARY KEY,
	location_name VARCHAR(200) NOT NULL,
	unit_number INTEGER UNIQUE NOT NULL,
	unit_size VARCHAR(200) NOT NULL,
	pictures_unitnumber INTEGER,
	high_bid MONEY NOT NULL,
	unit_notes VARCHAR(1000),
	auction_end DATETIME,
	CONSTRAINT units_location_name_check CHECK ((location_name = 'Columbus, OH') OR (location_name = 'New York, NY') OR (location_name = 'Cleveland, OH')),
	CONSTRAINT units_unit_size_check CHECK ((unit_size = '5x10') OR (unit_size = '10x10') OR (unit_size = '10x15') OR (unit_size = '10x20') OR (unit_size = '10x30'))
)

CREATE TABLE pictures(
	picture_id INTEGER IDENTITY PRIMARY KEY,
	unit_id INTEGER,
	picture_srclink VARCHAR(200) NOT NULL,
	FOREIGN KEY (unit_id) REFERENCES units(unit_id)
)

CREATE TABLE bids(
	bid_id INTEGER IDENTITY PRIMARY KEY,
	unit_id INTEGER NOT NULL,
	user_id VARCHAR(50) NOT NULL,
	bid_amount MONEY NOT NULL,
	bid_placed DATETIME NOT NULL,
)

--populate default data: 'password'
INSERT INTO users (username, password_hash, salt, user_role, verification_status) VALUES ('user@user.com','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user', 1);
INSERT INTO users (username, password_hash, salt, user_role, verification_status) VALUES ('admin@admin.com','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin', 1);


INSERT INTO units (location_name, unit_number, unit_size, pictures_unitnumber, high_bid) VALUES ('Columbus, OH', '1000', '5x10', 4, 900);
INSERT INTO units (location_name, unit_number, unit_size, pictures_unitnumber, high_bid) VALUES ('New York, NY', '55', '10x10', 33, 1);

ALTER TABLE bids ADD FOREIGN KEY (user_id) REFERENCES users(user_id);
ALTER TABLE bids ADD FOREIGN KEY (unit_id) REFERENCES units(unit_id);

GO
--COMMIT TRANSACTION (There is no "BEGIN TRANSACTION")



