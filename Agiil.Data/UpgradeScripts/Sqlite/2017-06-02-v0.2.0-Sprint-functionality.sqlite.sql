ALTER TABLE ticket
  ADD COLUMN sprint_id BIGINT
  CONSTRAINT fk_ticket_has_sprint REFERENCES sprint (sprint_id);

create table IF NOT EXISTS sprint (
  sprint_id  integer primary key autoincrement,
  name TEXT,
  description TEXT,
  project_id BIGINT,
  creation_date DATETIME,
  start_date DATETIME,
  end_date DATETIME,
  closed BOOL default False  not null,
  constraint fk_sprint_has_project foreign key (project_id) references project
);

create index IF NOT EXISTS idx_ticket_sprint_id on ticket (sprint_id);

create index IF NOT EXISTS idx_sprint_project_id on sprint (project_id);
