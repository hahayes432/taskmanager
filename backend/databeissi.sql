-- Database: taskmanager

-- DROP DATABASE IF EXISTS taskmanager;

CREATE DATABASE taskmanager
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'English_Finland.1252'
    LC_CTYPE = 'English_Finland.1252'
    LOCALE_PROVIDER = 'libc'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;
	
-- SCHEMA: public

-- DROP SCHEMA IF EXISTS public ;

CREATE SCHEMA IF NOT EXISTS public
    AUTHORIZATION pg_database_owner;

COMMENT ON SCHEMA public
    IS 'standard public schema';

GRANT USAGE ON SCHEMA public TO PUBLIC;

GRANT ALL ON SCHEMA public TO pg_database_owner;




-- Table: public.Activity

-- DROP TABLE IF EXISTS public."Activity";

CREATE TABLE IF NOT EXISTS public."Activity"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 9999 CACHE 1 ),
    "Title" text COLLATE pg_catalog."default" NOT NULL,
    "Description" text COLLATE pg_catalog."default" NOT NULL,
    "Url" text COLLATE pg_catalog."default" NOT NULL,
    "StartDate" date NOT NULL,
    "EndDate" date NOT NULL,
    "Status" integer NOT NULL,
    "Tags" integer,
    "ActivityType" integer NOT NULL,
    CONSTRAINT "Activity_pkey" PRIMARY KEY ("Id"),
    CONSTRAINT "ActivityType_fkey" FOREIGN KEY ("ActivityType")
        REFERENCES public."ActivityType" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID,
    CONSTRAINT "Status_fkey" FOREIGN KEY ("Status")
        REFERENCES public."Status" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID,
    CONSTRAINT "Tags_fkey" FOREIGN KEY ("Tags")
        REFERENCES public."Tag" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Activity"
    OWNER to postgres;
	
	
	
	
	-- Table: public.ActivityType

-- DROP TABLE IF EXISTS public."ActivityType";

CREATE TABLE IF NOT EXISTS public."ActivityType"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 9999 CACHE 1 ),
    "Name" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "ActivityType_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."ActivityType"
    OWNER to postgres;
	
	
	
	
	
	-- Table: public.Status

-- DROP TABLE IF EXISTS public."Status";

CREATE TABLE IF NOT EXISTS public."Status"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 9999 CACHE 1 ),
    "Title" text COLLATE pg_catalog."default" NOT NULL,
    "Style" text COLLATE pg_catalog."default",
    CONSTRAINT "Status_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Status"
    OWNER to postgres;
	
	
	
	
	
	-- Table: public.Tag

-- DROP TABLE IF EXISTS public."Tag";

CREATE TABLE IF NOT EXISTS public."Tag"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 9999 CACHE 1 ),
    "Name" text COLLATE pg_catalog."default" NOT NULL,
    "Color" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "Tag_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Tag"
    OWNER to postgres;
	
	
	
	
	
	-- Table: public.Task

-- DROP TABLE IF EXISTS public."Task";

CREATE TABLE IF NOT EXISTS public."Task"
(
    "Id" integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 9999 CACHE 1 ),
    "Name" text COLLATE pg_catalog."default" NOT NULL,
    "Content" text COLLATE pg_catalog."default",
    "StartDate" date NOT NULL,
    "EndDate" date NOT NULL,
    "ActivityId" integer NOT NULL,
    "Status" integer NOT NULL,
    "Tags" integer,
    CONSTRAINT "Task_pkey" PRIMARY KEY ("Id"),
    CONSTRAINT "ActivityId_fkey" FOREIGN KEY ("ActivityId")
        REFERENCES public."Activity" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID,
    CONSTRAINT "Status_fkey" FOREIGN KEY ("Status")
        REFERENCES public."Status" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID,
    CONSTRAINT "Tags_fkey" FOREIGN KEY ("Tags")
        REFERENCES public."Tag" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Task"
    OWNER to postgres;