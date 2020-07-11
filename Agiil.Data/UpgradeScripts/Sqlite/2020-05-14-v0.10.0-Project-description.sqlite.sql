BEGIN TRANSACTION;

-- Description: Add a text description for a project; this
-- will be markdown-rendered text.

ALTER TABLE project
    ADD COLUMN description TEXT NOT NULL DEFAULT '';

COMMIT TRANSACTION;