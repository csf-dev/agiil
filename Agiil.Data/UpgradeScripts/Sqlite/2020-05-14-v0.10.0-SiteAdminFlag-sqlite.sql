BEGIN TRANSACTION;

-- Description: Adds a new site_administrator column to the user table, to
-- indicate users who are super-admins on the site.

ALTER TABLE user
    ADD COLUMN site_administrator BIT NOT NULL DEFAULT 0;
    
COMMIT TRANSACTION;