
    PRAGMA foreign_keys = OFF

    drop table if exists User

    PRAGMA foreign_keys = ON

    create table User (
        id BIGINT not null,
       Username TEXT,
       AuthenticationInfo TEXT,
       primary key (id)
    )
