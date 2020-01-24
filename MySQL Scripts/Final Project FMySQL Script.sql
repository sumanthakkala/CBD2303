
create database CBD2303FinalProject; #Create Database
use CBD2303FinalProject; #Setting the default database

#Create Users Table
CREATE TABLE Users (
    UserId long NOT NULL,
    Email varchar(255) NOT NULL,
    PasswordHash varchar(255) NOT NULL,
    FullName varchar(255) NOT NULL,
    DOB date NOT NULL,
    City varchar(255) NOT NULL,
    Country varchar(255) NOT NULL,
    PRIMARY KEY (UserID)
);

#Create Relationships Table
CREATE TABLE Relationships (
    RelationshipId long NOT NULL,
    FollowerID long NOT NULL,
    FollowingID long NOT NULL,
    TimeStamp datetime NOT NULL,
    PRIMARY KEY (RelationshipID),
    FOREIGN KEY (FollowerID) REFERENCES Users(UserID),
    FOREIGN KEY (FollowingID) REFERENCES Users(UserID)
);

#Create StatusTexts Table
CREATE TABLE StatusTexts (
    StatusId long NOT NULL,
    UserID long NOT NULL,
    StatusText varchar(255),
    PRIMARY KEY (StatusID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

#Create Likes Table
CREATE TABLE Likes (
    LikeId long NOT NULL,
    StatusID long NOT NULL,
    UserID long NOT NULL,
    PRIMARY KEY (LikeID),	
	FOREIGN KEY (StatusID) REFERENCES StatusTexts(StatusID),
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

/*
For immediate demonstration purpose, we are dumping some dummy users into the DB.
We are also establishing the relationships between users directly by inserting records into the Relationships table.
This is because we have't implemented user authentication system to our application.
*/

#Insering dummy users into the DB
INSERT INTO Users(UserId,Email, PasswordHash, FullName, DOB, City, Country)
VALUES (1,'sumanth.akkala@gmail.com','123456', 'Nirmal Sumanth', str_to_date('16-05-1997', '%d-%m-%Y'), 'Hyderabad', 'India');

INSERT INTO Users(UserId,Email, PasswordHash, FullName, DOB, City, Country)
VALUES (2,'kushwanthn6@gmail.com','123456', 'Kushwanth', str_to_date('06-04-1997', '%d-%m-%Y'), 'Vijayawada', 'India');

INSERT INTO Users(UserId,Email, PasswordHash, FullName, DOB, City, Country)
VALUES (3,'malay@gmail.com','123456', 'Malay', str_to_date('16-05-1997', '%d-%m-%Y'), 'Hyderabad', 'India');

INSERT INTO Users(UserId,Email, PasswordHash, FullName, DOB, City, Country)
VALUES (4,'dil@gmail.com','123456', 'Diljit', str_to_date('16-05-1997', '%d-%m-%Y'), 'Hyderabad', 'India');

#Inserting Relationships between the above inserted users
INSERT INTO Relationships(RelationshipId, FollowerID, FollowingID, TimeStamp)
Values(1,1,2,CURDATE());
INSERT INTO Relationships(RelationshipId, FollowerID, FollowingID, TimeStamp)
Values(2,2,1,CURDATE());
INSERT INTO Relationships(RelationshipId, FollowerID, FollowingID, TimeStamp)
Values(3,3,4,CURDATE());
INSERT INTO Relationships(RelationshipId, FollowerID, FollowingID, TimeStamp)
Values(4,4,3,CURDATE())
