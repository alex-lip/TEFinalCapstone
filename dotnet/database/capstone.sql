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
	pictures TEXT,
	high_bid MONEY NOT NULL,
	unit_notes VARCHAR(1000),
	auction_end DATETIME NOT NULL,
	CONSTRAINT units_location_name_check CHECK ((location_name = 'Village Mini Storage South') OR (location_name = 'Village Mini Storage North') OR (location_name = 'Millersport Storage') OR (location_name = 'Stow-away') OR (location_name = '204 Self-Storage') OR (location_name = 'Pickaway Self-Storage')),
	CONSTRAINT units_facility_address_check CHECK((facility_address = '1001 S Main St. Baltimore, OH 43105') OR (facility_address = '67290 Lancaster St. Millersport, OH 43046') OR (facility_address = '806 E. Findlay St. Carey, OH 43316') OR (facility_address = 'State Route 182/531 Raybestos Upper Sandusky, OH 43351') OR (facility_address = '1815 E. Mansfield St. Bucyrus, OH 44820') OR (facility_address = 'State Route 235 Ada, OH 45810') OR (facility_address = '1379 State Route 68 N Dunkirk, OH 45836') OR (facility_address = '13450 State Route 68 S Kenton, OH 43326') OR (facility_address = '1143 County Rd. 130 Bellefontaine, OH 43311') OR (facility_address = '1345 N. Main St. Urbana, OH 43078') OR (facility_address = '1471 Milford Rd. Marysville, OH 43040') OR (facility_address = '4750 Cottonville Rd. Jamestown, OH 45335') OR (facility_address = '10445 Blacklick-Eastern Rd. NW Pickerington 43147') OR (facility_address = '500 Hill Rd N, Pickerington, OH 43147') OR (facility_address = '80773 Lancaster-Kirkersville Rd NW, Baltimore, OH 43105')),
	CONSTRAINT units_unit_size_check CHECK ((unit_size = '5x10') OR (unit_size = '5x5') OR (unit_size = '10x10') OR (unit_size = '10x15') OR (unit_size = '10x20') OR (unit_size = '10x30') OR (unit_size = '10x25') OR (unit_size = '10x35') OR (unit_size = '10x40'))
)

-- We may no longer need this table. (MARKED FOR DELETE)
--CREATE TABLE pictures(
--	picture_id INTEGER IDENTITY PRIMARY KEY,
--	unit_id INTEGER NOT NULL,
--	picture_srclink VARCHAR(200) NOT NULL,
--	FOREIGN KEY (unit_id) REFERENCES units(unit_id)
--)

CREATE TABLE bids(
	bid_id INTEGER IDENTITY PRIMARY KEY,
	unit_id INT NOT NULL,
	user_id INT NOT NULL,
	bid_amount MONEY NOT NULL,
	bid_placed DATETIME NOT NULL,
)

--populate default data: 'password'
INSERT INTO users (username, password_hash, salt, user_role, verification_status) VALUES ('user@user.com','$1$EUvs3PSP$/UzuFwVtAw8Jy7LmNLSWg.','EUvs3PSP','user', 1);
INSERT INTO users (username, password_hash, salt, user_role, verification_status) VALUES ('admin@admin.com','$1$134yCG9J$G76s/n34SqxR8raAmvalj0', '134yCG9J','admin', 1);
INSERT INTO users (username, password_hash, salt, user_role, verification_status) VALUES ('buyer@user.com','$1$htIdMA6P$Saji4X8qopJLkQfvzgxap/', 'htIdMA6P','user', 1);
INSERT INTO users (username, password_hash, salt, user_role, verification_status) VALUES ('purchaser@user.com','$1$66Hvgceg$uSSS8VuGXi9224.mCsV8N/', '66Hvgceg','user', 1);
INSERT INTO users (username, password_hash, salt, user_role, verification_status) VALUES ('auctioneer@user.com','$1$/4JYKhqu$iJ0Gm4h6d/EPbyAK5i54N1', '/4JYKhqu','user', 1);
INSERT INTO users (username, password_hash, salt, user_role, verification_status) VALUES ('shopper@user.com','$1$vHi14GKN$rQPTqxv98LbsPGVRsK8.Z0', 'vHi14GKN','user', 1);

INSERT INTO units (location_name, facility_address, unit_number, unit_size, pictures, high_bid, auction_end, unit_notes) VALUES ('Village Mini Storage South', '1001 S Main St. Baltimore, OH 43105', '106', '5x10', 'https://i.imgur.com/dc1PU8j.jpg', 900, '20210319 23:59', 'Clean unit!');
INSERT INTO units (location_name, facility_address, unit_number, unit_size, pictures, high_bid, auction_end, unit_notes) VALUES ('Village Mini Storage North', '80773 Lancaster-Kirkersville Rd NW, Baltimore, OH 43105', '162', '10x10', 'https://i.imgur.com/AZoU33k.jpg', 150, '20210404 23:59');
INSERT INTO units (location_name, facility_address, unit_number, unit_size, pictures, high_bid, auction_end, unit_notes) VALUES ('Millersport Storage', '67290 Lancaster St. Millersport, OH 43046', '49', '10x10', 'https://i.imgur.com/u4qSjQL.jpg', 1, '20210225 11:59', 'Minor water damage!');
INSERT INTO units (location_name, facility_address, unit_number, unit_size, pictures, high_bid, auction_end, unit_notes) VALUES ('204 Self-Storage', '10445 Blacklick-Eastern Rd. NW Pickerington 43147', '25', '10x20', 'https://i.imgur.com/5HKsazo.jpg', 320, '20210128 11:59');
INSERT INTO units (location_name, facility_address, unit_number, unit_size, pictures, high_bid, auction_end, unit_notes) VALUES ('Pickaway Self-Storage', '500 Hill Rd N, Pickerington, OH 43147', '42', '10x30', 'https://i.imgur.com/WhAh9xF.jpg', 640, '20210601 11:59');
INSERT INTO units (location_name, facility_address, unit_number, unit_size, pictures, high_bid, auction_end, unit_notes) VALUES ('Stow-Away', '806 E. Findlay St. Carey, OH 43316', '28', '10x10', 'https://i.imgur.com/gQi54t4.jpg', 80, '20210412 11:59');
INSERT INTO units (location_name, facility_address, unit_number, unit_size, pictures, high_bid, auction_end, unit_notes) VALUES ('Stow-Away', '1815 E. Mansfield St. Bucyrus, OH 44820', '36', '5x10', 'https://i.imgur.com/LVMnCRE.jpg', 100, '20210516 11:59');
INSERT INTO units (location_name, facility_address, unit_number, unit_size, pictures, high_bid, auction_end, unit_notes) VALUES ('Stow-Away', '1345 N. Main St. Urbana, OH 43078', '62', '10x15', 'https://i.imgur.com/ICoVAmu.jpg', 120, '20210710 11:59');


--INSERT INTO pictures(unit_id, picture_srclink) VALUES (1, 'https://i.imgur.com/epMSRQH.png');
--INSERT INTO pictures(unit_id, picture_srclink) VALUES (2, 'https://i.imgur.com/dc1PU8j.jpg');
--INSERT INTO pictures(unit_id, picture_srclink) VALUES (2, 'https://i.imgur.com/u4qSjQL.jpg');

ALTER TABLE bids ADD FOREIGN KEY (user_id) REFERENCES users(user_id);
ALTER TABLE bids ADD FOREIGN KEY (unit_id) REFERENCES units(unit_id);

INSERT INTO bids (unit_id, user_id, bid_amount, bid_placed) VALUES (1, 1, 900, '20200319 23:59');
INSERT INTO bids (unit_id, user_id, bid_amount, bid_placed) VALUES (2, 1, 100, '20200319 23:59');
INSERT INTO bids (unit_id, user_id, bid_amount, bid_placed) VALUES (3, 1, 1, '20200319 23:59');
INSERT INTO bids (unit_id, user_id, bid_amount, bid_placed) VALUES (2, 3, 150, '20200610 23:59');
INSERT INTO bids (unit_id, user_id, bid_amount, bid_placed) VALUES (1, 3, 400, '20200211 23:59');
INSERT INTO bids (unit_id, user_id, bid_amount, bid_placed) VALUES (4, 3, 200, '20200211 23:59');
INSERT INTO bids (unit_id, user_id, bid_amount, bid_placed) VALUES (4, 4, 320, '20200502 23:59');
INSERT INTO bids (unit_id, user_id, bid_amount, bid_placed) VALUES (1, 4, 500, '20200212 23:59');
INSERT INTO bids (unit_id, user_id, bid_amount, bid_placed) VALUES (5, 4, 300, '20200615 23:59');
INSERT INTO bids (unit_id, user_id, bid_amount, bid_placed) VALUES (5, 5, 640, '20200718 23:59');
INSERT INTO bids (unit_id, user_id, bid_amount, bid_placed) VALUES (1, 5, 640, '20200214 23:59');
INSERT INTO bids (unit_id, user_id, bid_amount, bid_placed) VALUES (2, 5, 120, '20200410 23:59');
INSERT INTO bids (unit_id, user_id, bid_amount, bid_placed) VALUES (6, 6, 80, '20201022 23:59');
INSERT INTO bids (unit_id, user_id, bid_amount, bid_placed) VALUES (7, 6, 100, '202001113 23:59');
INSERT INTO bids (unit_id, user_id, bid_amount, bid_placed) VALUES (8, 6, 120, '202001209 23:59');

GO
--COMMIT TRANSACTION (There is no "BEGIN TRANSACTION")



