create database  newdbforlearnsp;

use newdbforlearnsp;

create table users(
	id int identity(1,1) primary key,
	firstname varchar(100) not null,
	lastname varchar(100) ,
	birthdate  date,
	isActive bit default 1
);

drop table users;

select * from information_schema.tables;

insert into users(firstname,lastname,birthdate, isactive) values ('nameone','lastnameone','12-8-2001',1);

select * from users;


-- CREATEING DUMMY DATA
with Numbers as (
	select top (1000) row_number() over (order by (select null)) as n
	from sys.all_columns a
	cross join sys.all_columns b
)
insert into users (firstname, lastname,birthdate,isactive)
select
	'Name'+cast(n as nvarchar(10)),
	'lastName'+cast(n as nvarchar(10)), --  cast disini digunakkan untuk conversi tipe data yang awalnya dalam bentuk int menjadi nvarchar
	dateadd(day, -n, getdate()), -- dia akan mengambil tanggal hari ini dan mengurangi nilai nya dalam bentuk hari
	-- jadi ketika nilai dari n adalah 2 maka tanggal yang di ambil adalah 2 hari sebelum tanggal sekarang
	n%2 -- dia mengambil nilai n dan mengambil nilai modulo nya sebagai pengisi dari data contoh angka yang di  dapat 2 => jadi 2%2 modulonya adalah 0
	-- dan 3%2 modulonya adalah 1
from numbers

select * from users;

delete from users;
delete from users where isactive = 0;

-- counting 1-1000
select top (1000) -- untuk mengambil 1000 angkat teratas
row_number() -- memberikan nomer urut untuk setiap baris 
over (order by (select null)) as n -- tidak menggunakkan urutan tertentu karena data select dinyatakan null jadi tidak bergantung dengan pengurutan data dari column tertentu
from sys.all_columns a
cross join sys.all_columns b -- 

-- counting 

-- cross join
/**
Tabel SetA
Value
1
2
Tabel SetB
Value
A
B
Menggunakan CROSS JOIN untuk menghasilkan semua kombinasi:

sql
Copy code
SELECT SetA.Value AS ValueA, SetB.Value AS ValueB
FROM SetA
CROSS JOIN SetB;
Hasil
ValueA	ValueB
1		A
1		B
2		A
2		B
Kesimpulan
CROSS JOIN di SQL Server sangat berguna untuk menghasilkan semua kombinasi dari dua set data, membuat data dummy, atau melakukan analisis kombinasi. Karena menghasilkan produk Cartesian dari dua tabel, penggunaannya harus hati-hati terutama pada tabel besar karena hasilnya bisa sangat besar.


/