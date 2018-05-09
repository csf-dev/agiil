
create table IF NOT EXISTS label (
  label_id  integer primary key autoincrement,
  name TEXT unique
);

create table IF NOT EXISTS ticket_to_label (
  label_id BIGINT not null,
  ticket_id BIGINT not null,
  primary key (ticket_id, label_id),
  constraint fk_label_has_ticket foreign key (ticket_id) references ticket,
  constraint fk_ticket_has_label foreign key (label_id) references label
);

create index IF NOT EXISTS idx_unique_label_name on label (name);
