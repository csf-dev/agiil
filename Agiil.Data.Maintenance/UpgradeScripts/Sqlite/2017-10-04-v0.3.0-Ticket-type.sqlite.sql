create table IF NOT EXISTS ticket_type (
  ticket_type_id  integer primary key autoincrement,
  name TEXT
);

INSERT INTO ticket_type (ticket_type_id, name)
VALUES
(1, 'Bug'),
(2, 'Story'),
(3, 'Task'),
(4, 'Epic');

ALTER TABLE ticket
  ADD COLUMN ticket_type_id BIGINT
  DEFAULT(3)
  CONSTRAINT fk_ticket_has_type REFERENCES ticket_type (ticket_type_id);