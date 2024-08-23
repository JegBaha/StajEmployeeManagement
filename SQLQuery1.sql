CREATE TABLE employees(
 id INT PRIMARY KEY IDENTITY(1,1),
 eName VARCHAR(MAX) NULL,
 ePass VARCHAR(MAX) NULL,
 registerDate DATE NULL
)


SELECT * FROM employees


CREATE TABLE employeesThing(
	id INT PRIMARY KEY IDENTITY(1,1),
	employeeID VARCHAR(MAX) NULL,
	fullName VARCHAR(MAX) NULL,
	gender VARCHAR(MAX) NULL,
	email VARCHAR(MAX) NULL,
	departman VARCHAR(MAX) NULL,
	salary INT,
	insertDATE DATE NULL,
	updateDate DATE NULL,
	deleteDate DATE NULL
)

SELECT * FROM employeesThing


ALTER TABLE employeesThing
ADD status VARCHAR(MAX) Null