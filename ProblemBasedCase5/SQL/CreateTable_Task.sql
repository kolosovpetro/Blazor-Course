CREATE TABLE task (
	task_id serial PRIMARY KEY,
	taskname VARCHAR(200) NOT NULL,
	supervisor VARCHAR(60) NOT NULL,
	email_supervisor VARCHAR(255) NOT NULL,
	responsible VARCHAR(60) NOT NULL,
	email_responsible VARCHAR(255) NOT NULL,
	created_on TIMESTAMP NOT NULL,
	deadline TIMESTAMP NOT NULL,
	first_delivaring TIMESTAMP NOT NULL,
	first_revising TIMESTAMP NOT NULL,
	estimate_hours INT NOT NULL,
	effective_hours INT NOT NULL,
	status Task_Status NOT NULL
);