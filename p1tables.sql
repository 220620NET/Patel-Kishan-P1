create schema project1;
drop schema project1;
drop table project1.userlogin;
drop table project1.ticket;

create table project1.userlogin(
	username varchar(100) unique not null,
	password varchar(100) not null,
	user_role varchar(10) not null,
	primary key(username)
);

create table project1.ticket(
	id int identity,
	author_fk varchar(100) foreign key references project1.userlogin(username) not null,
	resolver_fk varchar(100) foreign key references project1.userlogin(username)  not null,
	description varchar(1000) not null,
	status varchar(10) not null,
	amount double precision not null,
	primary key(id)
);


	

