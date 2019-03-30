
create table ticket_work_log (
  ticket_work_log_id  integer primary key autoincrement,
  user_id BIGINT,
  ticket_id BIGINT,
  time_started DATETIME,
  minutes_spent INT,
  constraint fk_ticket_work_log_has_user foreign key (user_id) references user,
  constraint fk_ticket_work_log_has_ticket foreign key (ticket_id) references ticket
);

create index idx_ticket_work_log_user_id on ticket_work_log (user_id);

create index idx_ticket_work_log_ticket_id on ticket_work_log (ticket_id);
