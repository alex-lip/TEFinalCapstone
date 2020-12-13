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
	facility_address VARCHAR(200) NOT NULL,
	unit_number INTEGER UNIQUE NOT NULL,
	unit_size VARCHAR(200) NOT NULL,
	pictures_unitnumber INTEGER,
	high_bid MONEY NOT NULL,
	unit_notes VARCHAR(1000),
	auction_end DATETIME NOT NULL,
	CONSTRAINT units_location_name_check CHECK ((location_name = 'Village Mini Storage') OR (location_name = 'Millersport Storage') OR (location_name = 'Stow-away') OR (location_name = '204 Self-Storage') OR (location_name = 'Pickaway Self-Storage')),
	CONSTRAINT units_facility_address_check CHECK((facility_address = '1001 S Main St. Baltimore, OH 43105') OR (facility_address = '67290 Lancaster St. Millersport, OH 43046') OR (facility_address = '806 E. Findlay St. Carey, OH 43316') OR (facility_address = 'State Route 182/531 Raybestos Upper Sandusky, OH 43351') OR (facility_address = '1815 E. Mansfield St. Bucyrus, OH 44820') OR (facility_address = 'State Route 235 Ada, OH 45810') OR (facility_address = '1379 State Route 68 N Dunkirk, OH 45836') OR (facility_address = '13450 State Route 68 S Kenton, OH 43326') OR (facility_address = '1143 County Rd. 130 Bellefontaine, OH 43311') OR (facility_address = '1345 N. Main St. Urbana, OH 43078') OR (facility_address = '1471 Milford Rd. Marysville, OH 43040') OR (facility_address = '4750 Cottonville Rd. Jamestown, OH 45335') OR (facility_address = '10445 Blacklick-Eastern Rd. NW Pickerington 43147') OR (facility_address = '500 Hill Rd N, Pickerington, OH 43147') OR (facility_address = '80773 Lancaster-Kirkersville Rd NW, Baltimore, OH 43105')),
	CONSTRAINT units_unit_size_check CHECK ((unit_size = '5x10') OR (unit_size = '5x5') OR (unit_size = '10x10') OR (unit_size = '10x15') OR (unit_size = '10x20') OR (unit_size = '10x30') OR (unit_size = '10x25') OR (unit_size = '10x35') OR (unit_size = '10x40'))
)

CREATE TABLE pictures(
	picture_id INTEGER IDENTITY PRIMARY KEY,
	unit_id INTEGER,
	picture_srclink VARCHAR(200) NOT NULL,
	FOREIGN KEY (unit_id) REFERENCES units(unit_id)
)

CREATE TABLE bids(
	bid_id INTEGER IDENTITY PRIMARY KEY,
	unit_id INT NOT NULL,
	user_id INT NOT NULL,
	bid_amount MONEY NOT NULL,
	bid_placed DATETIME NOT NULL,
)

--populate default data: 'password'
INSERT INTO users (username, password_hash, salt, user_role, verification_status) VALUES ('user@user.com','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user', 1);
INSERT INTO users (username, password_hash, salt, user_role, verification_status) VALUES ('admin@admin.com','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin', 1);


INSERT INTO units (location_name, facility_address, unit_number, unit_size, pictures_unitnumber, high_bid, auction_end, unit_notes) VALUES ('Village Mini Storage', '1001 S Main St. Baltimore, OH 43105', '106', '5x10', 4, 900, '20210319 23:59', 'Clean unit!');
INSERT INTO units (location_name, facility_address, unit_number, unit_size, pictures_unitnumber, high_bid, auction_end, unit_notes) VALUES ('Millersport Storage', '67290 Lancaster St. Millersport, OH 43046', '49', '10x10', 33, 1, '20210225 11:59', 'Minor water damage!');


ALTER TABLE bids ADD FOREIGN KEY (user_id) REFERENCES users(user_id);
ALTER TABLE bids ADD FOREIGN KEY (unit_id) REFERENCES units(unit_id);

GO
--COMMIT TRANSACTION (There is no "BEGIN TRANSACTION")



