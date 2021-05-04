-- Creating database
-- CREATE DATABASE Eng86;

-- Use selected database
-- USE Eng86;

-- Create a table
--CREATE TABLE films_table
--(
--	film_name VARCHAR(10),
--	film_genre VARCHAR(6),
--  film_time INT CHECK (film_time >= 30)
--)

-- DML: Data Manipulation Language, used to manage the data in the database (SELECT, INSERT, DELETE, UPDATE)
-- DDL: Data Definition Language, used to change the structure of the database (CREATE, DROP, TRUNCATE, ALTER)
-- DCL: Data Control Language, used to grant and revoke admin rights (GRANT, REVOKE)
-- TCL: Transaction Control Language, used for version control (COMMIT, ROLLBACK, SAVEPOINT)

-- Droping (deleting) a table
DROP TABLE IF EXISTS films_table; -- Using IF EXISTS will stop an error popping up which stops the whole script.

CREATE TABLE films_table
(
	film_name VARCHAR(50) NOT NULL DEFAULT 'Film Name Missing',
	film_genre VARCHAR(10),
	date_of_release DATE,
	director VARCHAR(30),
	writer VARCHAR(30),
	star VARCHAR(30),
	film_language VARCHAR(20),
	official_website VARCHAR(MAX),
	plot_summary VARCHAR(MAX)
);

-- Adding columns you forgot to add
ALTER TABLE films_table
ADD film_id INT IDENTITY(1,1) PRIMARY KEY;

-- Deleting columns
ALTER TABLE films_table
DROP COLUMN plot_summary;

-- Inserting values into the table
INSERT INTO films_table
(film_name, film_genre, date_of_release, director, writer, star, film_language, official_website)
VALUES
('Spider-Man: Far From Home', 'Action', '2019-07-02', 'Jon Watts', 'Chris McKenna', 'Tom Holland', 'English', 'www.sonypictures.com/movies/spidermanfarfromhome'),
('Spider-Man: Far From Home', 'Action', '2019-07-02', 'Jon Watts', 'Chris McKenna', 'Tom Holland', 'English', 'www.sonypictures.com/movies/spidermanfarfromhome');

-- Updating a cell
UPDATE films_table
SET film_genre = 'Comedy'
WHERE film_name = 'Spider-Man: Far From Home';

-- Delete a row
DELETE FROM films_table
WHERE film_id = 1;

-- Deletes all values in a table, faster than delete.
TRUNCATE TABLE film_table;

-- Show table.
SELECT * FROM films_table;