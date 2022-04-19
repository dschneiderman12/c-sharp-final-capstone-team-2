USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username nvarchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL
	CONSTRAINT [PK_user] PRIMARY KEY (user_id)
)
CREATE TABLE courses(
	course_id int IDENTITY (1,1) NOT NULL,
	course_name NVARCHAR(100) NOT NULL,
	address NVARCHAR(100) NOT NULL
	CONSTRAINT [pk_courseId] PRIMARY KEY (course_id)

)
CREATE TABLE leagues(
	league_id int IDENTITY(1,1) NOT NULL,
	league_name NVARCHAR(100) NOT NULL,
	organizer_id int NOT NULL,
	course_id int NOT NULL

	CONSTRAINT [pk_leagueId] PRIMARY KEY (league_id),
	CONSTRAINT [fk_organizerId] FOREIGN KEY (organizer_id) REFERENCES users(user_id),
	CONSTRAINT [fk_courseId] FOREIGN KEY (course_id) REFERENCES courses(course_id)
)
CREATE TABLE matches (
	match_id  int IDENTITY (1,1) NOT NULL,
	match_name NVARCHAR(100) NOT NULL,
	league_id  int NOT NULL,
	start_time SMALLDATETIME NOT NULL
	CONSTRAINT [pk_matchId] PRIMARY KEY (match_id)
	CONSTRAINT [fk_league_id_match] FOREIGN KEY(league_id) REFERENCES leagues(league_id)

)

CREATE TABLE user_league(
	user_id int NOT NULL,
	league_id int NOT NULL
	CONSTRAINT [pk_user_league] PRIMARY KEY (user_id, league_id)
	CONSTRAINT [fk_user_id] FOREIGN KEY (user_id) REFERENCES users(user_id),
	CONSTRAINT [fk_league_id] FOREIGN KEY (league_id) REFERENCES leagues(league_id)
)
CREATE TABLE user_match(
	user_id int NOT NULL,
	match_id int NOT NULL,
	score int NULL,
	tee_time SMALLDATETIME NOT NULL
	CONSTRAINT [pk_user_match] PRIMARY KEY (user_id, match_id),
	CONSTRAINT [fk_user_id_match] FOREIGN KEY (user_id) REFERENCES users(user_id),
	CONSTRAINT [fk-match_id] FOREIGN KEY (match_id) REFERENCES matches(match_id),
)
--CREATE TABLE league_match(
--	league_id int NOT NULL,
--	match_id int NOT NULL,
--	CONSTRAINT [pk_league_match] PRIMARY KEY (league_id, match_id),
--	CONSTRAINT [fk_league_id_match] FOREIGN KEY(league_id) REFERENCES leagues(league_id),
--	
--)
CREATE TABLE invites (
	invite_id int NOT NULL IDENTITY(1,1),
	invite_status varchar(30) NOT NULL,
	to_user int NOT NULL,
	to_league int NOT NULL
	CONSTRAINT [pk_invite] PRIMARY KEY (invite_id),
	CONSTRAINT [fk_to_user] FOREIGN KEY(to_user) REFERENCES users(user_id),
	CONSTRAINT [fk_league_invite] FOREIGN KEY(to_league) REFERENCES leagues(league_id)
)
--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');
INSERT INTO courses (course_name, address) VALUES ('TEST COURSE 1', '1234 Test Lane Cleveland, OH');
INSERT INTO leagues(league_name,organizer_id,course_id) VALUES ('TEST LEAGUE 1', 2, 1);
INSERT INTO courses (course_name, address) VALUES ('Wildcard Golf National Challenge', '1234 Test Lane Cleveland, OH');
INSERT INTO leagues (league_name,organizer_id,course_id) VALUES ('All Users',2,2);
INSERT INTO invites (invite_status, to_user, to_league) VALUES ('pending', 1, 1); 
-- UNCOMMENT AND RUN LINES 82-86 AFTER CREATING 3rd USER PER INSTRUCTIONS ON MERGE REQUEST

--INSERT INTO user_league (user_id, league_id) VALUES (1,1), (3,1), (2,1);
--INSERT INTO user_match (user_id, match_id, score, tee_time) VALUES
--(1, 1, 0, '2022-04-20 12:05:00'),
--(2, 1, 0, '2022-04-20 12:20:00'),
--(3, 1, 0, '2022-04-20 12:35:00');
GO

