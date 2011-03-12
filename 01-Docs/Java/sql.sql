create table POST
(
POST_ID INT PRIMARY KEY,
POST_NAME VARCHAR2(50)
);

create table WORKER
(
WORKER_ID INT PRIMARY KEY,
FIRST_NAME VARCHAR2(25),
LAST_NAME VARCHAR2(25),
AGE INT,
POST_ID INT references POST(POST_ID)
);

insert into POST values(1,'None');
insert into POST values(2,'Manager');
insert into POST values(3,'Administrator');

insert into WORKER values (1,'Alen','Pelin',25,2);
insert into WORKER values (2,'Yulia','Filatova',23,1);
insert into WORKER values (3,'Sergey','Bauman',29,3);
insert into WORKER values (4,'Maxim','Eremenok',32,1);

select * from POST inner join WORKER on POST.POST_ID = WORKER.POST_ID;
select * from WORKER;
select * from POST;



