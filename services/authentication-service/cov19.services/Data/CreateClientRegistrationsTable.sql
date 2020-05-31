CREATE TABLE public."ClientRegistrations"
(
    "ClientId" text COLLATE pg_catalog."default" NOT NULL,
    "ClientSecret" text COLLATE pg_catalog."default" NOT NULL,
    "ScopeId" text COLLATE pg_catalog."default",
    "ScopeName" text COLLATE pg_catalog."default",
    CONSTRAINT "PK_ClientRegistrations" PRIMARY KEY ("ClientId")
);