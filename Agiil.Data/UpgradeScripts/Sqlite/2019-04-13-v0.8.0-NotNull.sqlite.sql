PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;

-- Description: This script modifies many columns to make them defailt NOT NULL
-- where previous database versions have permitted nulls.

-- ---------------------------
-- ticket_work_log
-- ---------------------------
create table ticket_work_log_new (
  ticket_work_log_id  integer primary key autoincrement,
  user_id BIGINT not null,
  ticket_id BIGINT not null,
  time_started DATETIME not null,
  minutes_spent INT not null,
  constraint fk_ticket_work_log_has_user foreign key (user_id) references user,
  constraint fk_ticket_work_log_has_ticket foreign key (ticket_id) references ticket
);
INSERT INTO ticket_work_log_new (
  ticket_work_log_id,
  user_id,
  ticket_id,
  time_started,
  minutes_spent
)
SELECT
  ticket_work_log_id,
  user_id,
  ticket_id,
  time_started,
  minutes_spent
FROM ticket_work_log;
DROP TABLE ticket_work_log;
ALTER TABLE ticket_work_log_new RENAME TO ticket_work_log;
create index idx_ticket_work_log_user_id on ticket_work_log (user_id);
create index idx_ticket_work_log_ticket_id on ticket_work_log (ticket_id);

-- ---------------------------
-- label
-- ---------------------------
create table label_new (
    label_id  integer primary key autoincrement,
    name TEXT not null unique
);
INSERT INTO label_new (
  label_id,
  name
)
SELECT
  label_id,
  name
FROM label;
DROP TABLE label;
ALTER TABLE label_new RENAME TO label;
create index idx_unique_label_name on label (name);

-- ---------------------------
-- sprint
-- ---------------------------
create table sprint_new (
    sprint_id  integer primary key autoincrement,
    name TEXT not null,
    description TEXT,
    project_id BIGINT not null,
    creation_date DATETIME not null,
    start_date DATETIME,
    end_date DATETIME,
    closed BOOL default False  not null,
    constraint fk_sprint_has_project foreign key (project_id) references project
);
INSERT INTO sprint_new (
    sprint_id,
    name,
    description,
    project_id,
    creation_date,
    start_date,
    end_date,
    closed
)
SELECT
    sprint_id,
    name,
    description,
    project_id,
    creation_date,
    start_date,
    end_date,
    closed
FROM sprint;
DROP TABLE sprint;
ALTER TABLE sprint_new RENAME TO sprint;
create index idx_sprint_project_id on sprint (project_id);

-- ---------------------------
-- project
-- ---------------------------
create table project_new (
    project_id  integer primary key autoincrement,
    name TEXT not null,
    code TEXT not null,
    next_available_ticket_number BIGINT not null
);
INSERT INTO project_new (
    project_id,
    name,
    code,
    next_available_ticket_number
)
SELECT
    project_id,
    name,
    code,
    next_available_ticket_number
FROM project;
DROP TABLE project;
ALTER TABLE project_new RENAME TO project;

-- ---------------------------
-- ticket
-- ---------------------------
create table ticket_new (
    ticket_id  integer primary key autoincrement,
    title TEXT not null,
    description TEXT,
    creation_timestamp DATETIME not null,
    ticket_number BIGINT not null,
    closed BOOL default False  not null,
    story_points INT,
    user_id BIGINT not null,
    project_id BIGINT not null,
    sprint_id BIGINT,
    ticket_type_id BIGINT not null,
    constraint fk_ticket_has_user foreign key (user_id) references user,
    constraint fk_ticket_has_project foreign key (project_id) references project,
    constraint fk_ticket_has_sprint foreign key (sprint_id) references sprint,
    constraint fk_ticket_has_ticket_type foreign key (ticket_type_id) references ticket_type
);
INSERT INTO ticket_new (
    ticket_id,
    title,
    description,
    creation_timestamp,
    ticket_number,
    closed,
    story_points,
    user_id,
    project_id,
    sprint_id,
    ticket_type_id
)
SELECT
    ticket_id,
    title,
    description,
    creation_timestamp,
    ticket_number,
    closed,
    story_points,
    user_id,
    project_id,
    sprint_id,
    ticket_type_id
FROM ticket;
DROP TABLE ticket;
ALTER TABLE ticket_new RENAME TO ticket;
create index idx_ticket_user_id on ticket (user_id);
create index idx_ticket_project_id on ticket (project_id);
create index idx_ticket_sprint_id on ticket (sprint_id);
create index idx_ticket_ticket_type_id on ticket (ticket_type_id);

-- ---------------------------
-- comment
-- ---------------------------
create table comment_new (
    comment_id  integer primary key autoincrement,
    ticket_id BIGINT not null,
    creation_timestamp DATETIME not null,
    last_edit_timestamp DATETIME not null,
    user_id BIGINT not null,
    body TEXT not null,
    constraint fk_comment_has_ticket foreign key (ticket_id) references ticket,
    constraint fk_comment_has_user foreign key (user_id) references user
);
INSERT INTO comment_new (
    comment_id,
    ticket_id,
    creation_timestamp,
    last_edit_timestamp,
    user_id,
    body
)
SELECT
    comment_id,
    ticket_id,
    creation_timestamp,
    last_edit_timestamp,
    user_id,
    body
FROM comment;
DROP TABLE comment;
ALTER TABLE comment_new RENAME TO comment;
create index idx_comment_ticket_id on comment (ticket_id);
create index idx_comment_user_id on comment (user_id);

-- ---------------------------
-- ticket_type
-- ---------------------------
create table ticket_type_new (
    ticket_type_id  integer primary key autoincrement,
    name TEXT not null
);
INSERT INTO ticket_type_new (
    ticket_type_id,
    name
)
SELECT
    ticket_type_id,
    name
FROM ticket_type;
DROP TABLE ticket_type;
ALTER TABLE ticket_type_new RENAME TO ticket_type;

-- ---------------------------
-- relationship
-- ---------------------------
create table relationship_new (
    relationship_id  integer primary key autoincrement,
    type TEXT not null,
    primary_summary TEXT not null,
    secondary_summary TEXT
);
INSERT INTO relationship_new (
    relationship_id,
    type,
    primary_summary,
    secondary_summary
)
SELECT
    relationship_id,
    type,
    primary_summary,
    secondary_summary
FROM relationship;
DROP TABLE relationship;
ALTER TABLE relationship_new RENAME TO relationship;

-- ---------------------------
-- ticket_relationship
-- ---------------------------
create table ticket_relationship_new (
    ticket_relationship_id  integer primary key autoincrement,
    relationship_id BIGINT not null,
    primary_ticket_id BIGINT not null,
    secondary_ticket_id BIGINT not null,
    constraint fk_ticket_relationship_has_relationship foreign key (relationship_id) references relationship,
    constraint fk_ticket_relationship_has_primary_ticket foreign key (primary_ticket_id) references ticket,
    constraint fk_ticket_relationship_has_secondary_ticket foreign key (secondary_ticket_id) references ticket
);
INSERT INTO ticket_relationship_new (
    ticket_relationship_id,
    relationship_id,
    primary_ticket_id,
    secondary_ticket_id
)
SELECT
    ticket_relationship_id,
    relationship_id,
    primary_ticket_id,
    secondary_ticket_id
FROM ticket_relationship;
DROP TABLE ticket_relationship;
ALTER TABLE ticket_relationship_new RENAME TO ticket_relationship;
create index idx_ticket_relationship_relationship_id on ticket_relationship (relationship_id);
create index idx_ticket_relationship_primary_ticket on ticket_relationship (primary_ticket_id);
create index idx_ticket_relationship_secondary_ticket on ticket_relationship (secondary_ticket_id);

-- ---------------------------
-- user
-- ---------------------------
create table user_new (
    user_id  integer primary key autoincrement,
    username TEXT not null,
    serialized_credentials TEXT not null
);
INSERT INTO user_new (
    user_id,
    username,
    serialized_credentials
)
SELECT
    user_id,
    username,
    serialized_credentials
FROM user;
DROP TABLE user;
ALTER TABLE user_new RENAME TO user;

-- To test this script interactively, un-comment the two following
-- lines and comment-out the COMMIT TRANSACTION line.
-- PRAGMA foreign_key_check;
-- ROLLBACK TRANSACTION;
COMMIT TRANSACTION;

PRAGMA foreign_keys=ON;

-- This is a large operation which deletes a lot of dead data,
-- VACUUM will optimise the SQLite file.
VACUUM;