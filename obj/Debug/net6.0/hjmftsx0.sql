CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Items" (
    "Id" uuid NOT NULL,
    "TaskName" text NOT NULL,
    "TaskDescription" text NOT NULL,
    "Status" text NOT NULL,
    "Attachement" text NOT NULL,
    CONSTRAINT "PK_Items" PRIMARY KEY ("Id")
);

CREATE TABLE "Users" (
    "UserName" text NOT NULL,
    "Id" uuid NOT NULL,
    "Password" text NOT NULL,
    CONSTRAINT "PK_Users" PRIMARY KEY ("UserName")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20230517110636_InitialMigration', '7.0.5');

COMMIT;

