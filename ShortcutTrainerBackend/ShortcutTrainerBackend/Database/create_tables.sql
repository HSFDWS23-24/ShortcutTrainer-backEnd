create table _user (
    id char(36) primary key, -- id as guid
    name varchar(128) not null,
    email varchar(320) not null,
    prefered_language varchar(128) not null default 'de-DE',
    prefered_layout varchar(128) not null default 'QWERTZ',
    prefered_operating_system varchar(128) not null default 'Windows 10'
);

create type subscription_type as enum ('free', 'other');

create table course (
    id serial primary key,
    title varchar(128) not null,
    language char(2) not null default 'de-DE', -- language codes according to ISO 629 ('de' = german, 'en' = english, 'es' = spanish)
    description text not null,
    image_url varchar(128),
    subscription subscription_type not null default 'free'
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
    shortcut json not null, -- JSON-Array of integers: "[1,2,3]"
    constraint fk_answer_question foreign key (question_id) references question(id) on delete cascade
);

create index ix_answer_question on answer (id, question_id);

create table user_course (
    user_id char(36) not null,
    course_id int not null,
    favorite boolean not null default false,
    constraint fk_user_course_user foreign key (user_id) references _user(id) on delete cascade,
    constraint fk_user_course_course foreign key (course_id) references course(id) on delete cascade,
    constraint pk_user_course primary key (user_id, course_id)
);

create type question_status_type as enum ('Correct', 'Incorrect', 'Unanswered');

create table user_answer (
    user_id char(36) not null,
    answer_id int not null,
    question_status question_status_type not null default 'Unanswered',
    constraint fk_user_answer_user foreign key (user_id) references _user(id) on delete cascade,
    constraint fk_user_answer_answer foreign key (answer_id) references answer(id) on delete cascade,
    constraint pk_user_answer primary key (user_id, answer_id)
);