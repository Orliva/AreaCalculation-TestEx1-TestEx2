--CREATE DATABASE EX2

use EX2

drop table HelpTable
drop table Product
drop table Category

CREATE TABLE Product
(
Id int identity primary key,
[Name] nvarchar(50) NULL,
)

CREATE TABLE Category
(
Id int identity primary key,
[Name] nvarchar(50) NULL
)

CREATE TABLE HelpTable
(
ProdId int references Product(Id) on delete cascade,
CategoryId int references Category(Id) on delete cascade,
primary key(ProdId, CategoryId)
)

insert into Product values
('prod1'),
('prod2'),
('prod3'),
('prod4')

insert into Category values
('cat1'),
('cat2'),
('cat3'),
('cat4'),
('cat5')

insert into HelpTable values
(1, 1),
(1, 3),
(2, 1),
(2, 4),
(3, 4),
(1, 5)

select * from HelpTable

