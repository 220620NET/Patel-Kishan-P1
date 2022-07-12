select * from project1.userlogin;
select * from project1.ticket; 


-- adding one case to the tables
insert into project1.userlogin (username, password, user_role) values ('pen3f', 'password', 'client');
insert into project1.userlogin (username, password, user_role) values ('john333', 'password', 'client'); 
delete from project1.userlogin where username = 'ksp223';
insert into project1.ticket (author_fk,resolver_fk,description,status,amount) values ('joe123','pen3f','Batman broke through the window','Pending',593.98);


select * from project1.userlogin where username = 'joe123';

select * from project1.ticket where author_fk = 'joe123';
select * from project1.ticket where resolver_fk = 'ksp223';

update project1.ticket set status = 'Rejected' where id = 1;
update project1.ticket set status = 'Rejected' where author_fk = 'joe123' and resolver_fk = 'ksp223';
update project1.ticket set resolver_fk = 'pen3f' where author_fk = 'joe123' and resolver_fk = 'ksp223';
