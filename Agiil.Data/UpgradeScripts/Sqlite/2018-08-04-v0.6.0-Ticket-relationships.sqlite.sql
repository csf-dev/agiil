create table relationship (
   relationship_id  integer primary key autoincrement,
   type TEXT not null,
   primary_summary TEXT,
   secondary_summary TEXT
);

create table ticket_relationship (
   ticket_relationship_id  integer primary key autoincrement,
   relationship_id BIGINT,
   primary_ticket_id BIGINT,
   secondary_ticket_id BIGINT,
   constraint fk_ticket_relationship_has_relationship foreign key (relationship_id) references relationship,
   constraint fk_ticket_relationship_has_primary_ticket foreign key (primary_ticket_id) references ticket,
   constraint fk_ticket_relationship_has_secondary_ticket foreign key (secondary_ticket_id) references ticket
);

create index IF NOT EXISTS idx_ticket_relationship_relationship_id on ticket_relationship (relationship_id);

create index IF NOT EXISTS idx_ticket_relationship_primary_ticket on ticket_relationship (primary_ticket_id);

create index IF NOT EXISTS idx_ticket_relationship_secondary_ticket on ticket_relationship (secondary_ticket_id);

INSERT INTO relationship (relationship_id, type, primary_summary, secondary_summary)
VALUES (
  1,
  'NonDirectional',
  'Relates to',
  NULL
),(
  2,
  'Directional',
  'Blocks',
  'Is blocked by'
);