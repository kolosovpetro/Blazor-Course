CREATE TABLE programming_language (
	language_id serial PRIMARY KEY,
	language_name VARCHAR(200) NOT NULL,
	language_enum Language_Enum NOT NULL
);