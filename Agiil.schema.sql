
    PRAGMA foreign_keys = OFF

    drop table if exists User

    drop table if exists Ticket

    PRAGMA foreign_keys = ON

    create table User (
        id BIGINT not null,
       Username TEXT,
       SerializedCredentials TEXT,
       primary key (id)
    )

    create table Ticket (
        id BIGINT not null,
       Title TEXT,
       Description TEXT,
       primary key (id)
    )
