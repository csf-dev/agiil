BEGIN TRANSACTION;

-- Description: Adds a pair of many-to-many tables to indicate contributors
-- and administrators of projects.
-- This is the first-pass at a permissions mechanism.  It probably won't last
-- too long, because I'd like to use role-based permissions in the long-term.
-- However, I don't want to put the design of that mechanism ahead of basic
-- permissions.  So this is a short-term solution to be refined later.

CREATE TABLE project_to_contributor_user (
    project_id BIGINT NOT NULL,
    user_id BIGINT NOT NULL,
    PRIMARY KEY (user_id, project_id),
    CONSTRAINT fk_project_has_contributors FOREIGN KEY (user_id) REFERENCES user,
    CONSTRAINT fk_user_has_contributor_to FOREIGN KEY (project_id) REFERENCES project
);

CREATE TABLE project_to_administrator_user (
    project_id BIGINT NOT NULL,
    user_id BIGINT NOT NULL,
    PRIMARY KEY (user_id, project_id),
    CONSTRAINT fk_project_has_administrators FOREIGN KEY (user_id) REFERENCES user,
    CONSTRAINT fk_user_has_administrator_of FOREIGN KEY (project_id) REFERENCES project
);

COMMIT TRANSACTION;