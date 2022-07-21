select * from project1.userlogin;
select * from project1.ticket; 


-- adding one case to the tables
insert into project1.userlogin (username, password, user_role) values ('pen3f', 'password', 'admin');
insert into project1.userlogin (username, password, user_role) values ('john333', 'password', 'client'); 
INSERT INTO project1.ticket (author_fk,resolver_fk,description,status,amount) VALUES ('john333', 'pen3f', 'catman','Pending' , 51.12);


select * from project1.userlogin where username = 'joe123';

select * from project1.ticket where author_fk = 'joe123';
select * from project1.ticket where resolver_fk = 'ksp223';

update project1.ticket set status = 'Rejected' where id = 1;
update project1.ticket set status = 'Rejected' where author_fk = 'joe123' and resolver_fk = 'ksp223';
update project1.ticket set resolver_fk = 'pen3f' where author_fk = 'joe123' and resolver_fk = 'ksp223';

select * from project1.ticket where author_fk =
(SELECT username FROM project1.userlogin WHERE userId = 2);

