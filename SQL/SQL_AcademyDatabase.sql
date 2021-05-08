-- Creating database
--CREATE DATABASE SpartaAcademy;

-- Use selected database
--USE SpartaAcademy;

-- Delete table if they exist.
DROP TABLE IF EXISTS Trainees;
DROP TABLE IF EXISTS Trainers;
DROP TABLE IF EXISTS TrainersCoursesLink;
DROP TABLE IF EXISTS TrainersStreamsLink;
DROP TABLE IF EXISTS Courses;
DROP TABLE IF EXISTS Streams;
DROP TABLE IF EXISTS Locations;
-- Create a tables
CREATE TABLE Locations
(
	city VARCHAR(25) PRIMARY KEY,
	postcode VARCHAR(25),
);

CREATE TABLE Streams
(
	stream VARCHAR(25) PRIMARY KEY,
	years_run INT,
);

CREATE TABLE Courses
(
	course VARCHAR(25) PRIMARY KEY,
	stream VARCHAR(25) FOREIGN KEY REFERENCES Streams (stream),
	start_date DATE
);

CREATE TABLE Trainers
(
	trainer_id INT IDENTITY(1,1) PRIMARY KEY,
	first_name VARCHAR(25),
	last_name VARCHAR(25),
	years_of_experience INT,
	location VARCHAR(25) FOREIGN KEY REFERENCES Locations (city)
);

CREATE TABLE Trainees
(
	trainee_id INT IDENTITY(1,1) PRIMARY KEY,
	first_name VARCHAR(25),
	last_name VARCHAR(25),
	date_of_birth DATE,
	trainer_id INT FOREIGN KEY REFERENCES Trainers (trainer_id),
	stream VARCHAR(25) FOREIGN KEY REFERENCES Streams (stream),
	course VARCHAR(25) FOREIGN KEY REFERENCES Courses (course),
	location VARCHAR(25) FOREIGN KEY REFERENCES Locations (city)
);

CREATE TABLE TrainersStreamsLink
(
	pk INT IDENTITY(1,1) PRIMARY KEY,
	trainer_id INT NOT NULL FOREIGN KEY REFERENCES Trainers (trainer_id),
	stream VARCHAR(25) NOT NULL FOREIGN KEY REFERENCES Streams (stream)
);

CREATE TABLE TrainersCoursesLink
(
	pk INT IDENTITY(1,1) PRIMARY KEY,
	trainer_id INT NOT NULL FOREIGN KEY REFERENCES Trainers (trainer_id),
	course VARCHAR(25) NOT NULL FOREIGN KEY REFERENCES Courses (course)
);

INSERT INTO Streams
VALUES
('Business',1),
('Engineering',2),
('Data',3)
;

INSERT INTO Courses
VALUES
('Business_60', 'Business','2021-04-06'),
('Engineering_86', 'Engineering','2021-04-12'),
('Data_20', 'Data','2021-03-28')
;

INSERT INTO Locations
VALUES
('London','LN67 7RF'),
('Birmingham','BR89 8KJ')
;

INSERT INTO Trainers
(first_name, last_name, years_of_experience, location)
VALUES
('Bob','Dugless', 10, 'London'),
('Sue','Sally', 4, 'Birmingham'),
('Git','Hub', 2, 'London')
;

INSERT INTO TrainersCoursesLink
VALUES
(1,'Engineering_86'),
(1,'Business_60'),
(2,'Business_60'),
(2,'Data_20'),
(3,'Data_20'),
(3,'Engineering_86')
;

INSERT INTO TrainersStreamsLink
VALUES
(1,'Engineering'),
(1,'Business'),
(2,'Business'),
(2,'Data'),
(3,'Data'),
(3,'Engineering')
;

INSERT INTO Trainees
(first_name, last_name, date_of_birth, trainer_id, stream, course, location)
VALUES
('Uzair','Khan', '1997-05-11', 1, 'Engineering', 'Engineering_86', 'London'),
('Billy','Smith', '1996-02-07', 2, 'Business', 'Business_60', 'Birmingham'),
('Duncan','Smith', '1993-11-29', 3, 'Data', 'Data_20', 'London'),
('William','Butterfingers', '1998-09-30', 1, 'Business', 'Business_60', 'London'),
('Chloe','Forge', '1992-03-01', 2, 'Data', 'Data_20', 'Birmingham'),
('Saif','Abdullah', '1997-01-16', 3, 'Engineering', 'Engineering_86', 'London')
;

SELECT * FROM Trainees;
SELECT * FROM Trainers;
SELECT * FROM Locations;
SELECT * FROM Courses;
SELECT * FROM Streams;
SELECT * FROM TrainersCoursesLink;
SELECT * FROM TrainersStreamsLink;

SELECT Trainees.first_name + ' ' + Trainees.last_name + ' : ' + Trainers.first_name + ' ' + Trainers.last_name + ' : ' + Trainees.course + ' : ' + Trainees.stream AS 'Students : Teachers : Course : Stream'--+ ' in the course: ' + Courses.course
FROM Trainees
INNER JOIN Trainers ON Trainees.trainer_id = Trainers.trainer_id;

SELECT Trainers.first_name, Trainers.last_name, Courses.course, Courses.start_date
FROM TrainersCoursesLink
INNER JOIN Trainers ON TrainersCoursesLink.trainer_id = Trainers.trainer_id
INNER JOIN Courses ON TrainersCoursesLink.course = Courses.course;

SELECT Trainers.first_name, Trainers.last_name, Streams.stream, Streams.years_run
FROM TrainersStreamsLink
INNER JOIN Trainers ON TrainersStreamsLink.trainer_id = Trainers.trainer_id
INNER JOIN Streams ON TrainersStreamsLink.stream = Streams.stream;