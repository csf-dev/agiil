BEGIN TRANSACTION;

-- Description: Introduces a new behaviour column to the relationship table.
-- Also adds a new parent/child relationship type.

ALTER TABLE relationship
  ADD COLUMN behaviour TEXT NOT NULL DEFAULT '';


COMMIT TRANSACTION;

BEGIN TRANSACTION;

INSERT INTO relationship (
    type,
    primary_summary,
    secondary_summary,
    behaviour
)
VALUES (
  'Directional',
  'Parent of',
  'Child of',
  '{"ProhibitCircularRelationship":True,"ProhibitMultipleSecondaryRelationships":True}'
);


COMMIT TRANSACTION;