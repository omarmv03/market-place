CREATE TABLE IF NOT EXISTS Users (
	Id INTEGER PRIMARY KEY AUTOINCREMENT,
	Email VARCHAR(100) NOT NULL,
	Name VARCHAR(30) NOT NULL,
	Lastname VARCHAR(30) NOT NULL,
	Password VARCHAR(30) NOT NULL,
	IsAdmin	BIT DEFAULT 0,
	Token NVARCHAR(5000),
	LastLogin DATETIME
);
CREATE TABLE IF NOT EXISTS Products (
	Id INTEGER PRIMARY KEY AUTOINCREMENT,
	Title VARCHAR(30) NOT NULL,
	Description VARCHAR(50) NOT NULL,
	Price DECIMAL(6,3) NOT NULL,
	Image NVARCHAR(400) NOT NULL
);
CREATE TABLE IF NOT EXISTS ShoppingCart (
	Id INTEGER PRIMARY KEY AUTOINCREMENT,
	IdProduct INTEGER NOT NULL,
	Quantity INTEGER NOT NULL,
	Date DATETIME NOT NULL,
	IdUser INTEGER NOT NULL,
	Total DECIMAL(6,3) NOT NULL,
	FOREIGN KEY (IdProduct) REFERENCES Products(Id),
	FOREIGN KEY (IdUser) REFERENCES Users(Id)
);