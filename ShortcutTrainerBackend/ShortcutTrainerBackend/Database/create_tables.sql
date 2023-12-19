
drop table if exists user_answer;
drop table if exists user_course;
drop table if exists answer;
drop table if exists question;
drop table if exists course_tag;
drop table if exists course;
drop table if exists _user;

create table _user (
    id char(36) primary key,
    name varchar(128) not null,
    email varchar(320) not null,
    prefered_language varchar(128) not null default 'de-DE',
    prefered_layout varchar(128) not null default 'QWERTZ',
    prefered_operating_system varchar(128) not null default 'Windows 10'
);

create table course (
    id serial primary key,
    title varchar(128) not null,
    language char(5) not null default 'de-DE',
    description text not null,
    image_url varchar(128),
    subscription varchar(16) not null default 'free' check (subscription in ('free', 'other'))
);

create index ix_course_language on course (id, language);

create table course_tag (
    course_id int references course(id) on delete cascade,
    tag varchar(50) not null,
    constraint pk_course_tag primary key (course_id, tag)
);

create table question (
    id serial primary key,
    course_id int not null,
    content varchar(128) not null,
    constraint fk_question_course foreign key (course_id) references course(id) on delete cascade
);

create table answer (
    id serial primary key,
    question_id int,
    system varchar(16) not null,
    shortcut varchar(255) not null, -- JSON-Array of integers: "[1,2,3]"
    constraint fk_answer_question foreign key (question_id) references question(id) on delete cascade
);

alter table answer alter column shortcut type varchar(255);

create index ix_answer_question on answer (id, question_id);

create table user_course (
     user_id char(36) not null,
     course_id int not null,
     favorite boolean not null default false,
     constraint fk_user_course_user foreign key (user_id) references _user(id) on delete cascade,
     constraint fk_user_course_course foreign key (course_id) references course(id) on delete cascade,
     constraint pk_user_course primary key (user_id, course_id)
);

create table user_answer (
     user_id char(36) not null,
     answer_id int not null,
     question_status varchar(32) not null default 'Unanswered' check (question_status in ('Correct', 'Incorrect', 'Unanswered')),
     constraint fk_user_answer_user foreign key (user_id) references _user(id) on delete cascade,
     constraint fk_user_answer_answer foreign key (answer_id) references answer(id) on delete cascade,
     constraint pk_user_answer primary key (user_id, answer_id)
);