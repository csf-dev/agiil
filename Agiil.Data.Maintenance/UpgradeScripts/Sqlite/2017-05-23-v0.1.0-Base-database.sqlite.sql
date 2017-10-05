
create table IF NOT EXISTS user (
    user_id  integer primary key autoincrement,
   username TEXT,
   serialized_credentials TEXT
);

create table IF NOT EXISTS ticket (
    ticket_id  integer primary key autoincrement,
   title TEXT,
   description TEXT,
   user_id BIGINT,
   creation_timestamp DATETIME,
   project_id BIGINT,
   ticket_number BIGINT,
   closed BOOL default False  not null,
   constraint fk_ticket_has_user foreign key (user_id) references user,
   constraint fk_ticket_has_project foreign key (project_id) references project
);

create table IF NOT EXISTS comment (
    comment_id  integer primary key autoincrement,
   ticket_id BIGINT,
   creation_timestamp DATETIME,
   last_edit_timestamp DATETIME,
   user_id BIGINT,
   body TEXT,
   constraint fk_comment_has_ticket foreign key (ticket_id) references ticket,
   constraint fk_comment_has_user foreign key (user_id) references user
);

create table IF NOT EXISTS project (
    project_id  integer primary key autoincrement,
   name TEXT,
   code TEXT,
   next_available_ticket_number BIGINT
);

create index IF NOT EXISTS idx_ticket_user_id on ticket (user_id);

create index IF NOT EXISTS idx_ticket_project_id on ticket (project_id);

create index IF NOT EXISTS idx_comment_ticket_id on comment (ticket_id);

create index IF NOT EXISTS idx_comment_user_id on comment (user_id);
