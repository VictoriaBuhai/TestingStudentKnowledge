CREATE TABLE Users
(
    Login varchar(30) PRIMARY KEY,
    Password CHARACTER VARYING(30),
    FirstName CHARACTER VARYING(15),
    LastName CHARACTER VARYING(15),
    isAdmin bool
);

CREATE TABLE Questions
(
    Id SERIAL PRIMARY KEY,
	Question text
);

CREATE TABLE Answers
(
    Id SERIAL PRIMARY KEY,
	Answer text
);
CREATE TABLE Tests
(
    Id SERIAL PRIMARY KEY,
	Title CHARACTER VARYING(30),
    TimeLimit SMALLINT,
    TestOwner CHARACTER VARYING(30),
	FOREIGN KEY (TestOwner) REFERENCES Users (Login)
);

CREATE TABLE questions_answ_r
(
    QId int,
    AId int,
	
	FOREIGN KEY (QId) REFERENCES Questions(id),
	FOREIGN KEY (AId) REFERENCES Answers(id),
	primary key (QId,AId)
);

CREATE TABLE questions_true_answ_r
(
    QId int,
    AId int,
	
	FOREIGN KEY (QId) REFERENCES Questions(id),
	FOREIGN KEY (AId) REFERENCES Answers(id),
	primary key (QId)
);

CREATE TABLE tests_questions_r
(
    QId int,
    TId int,
	
	FOREIGN KEY (QId) REFERENCES Questions(id),
	FOREIGN KEY (TId) REFERENCES Tests(id),
	primary key (TId,QId)
);

CREATE TABLE users_tests_r
(
    ULogin varchar(30),
    TId int,
	
	FOREIGN KEY (ULogin) REFERENCES Users(Login),
	FOREIGN KEY (TId) REFERENCES Tests(id),
	primary key (TId,ULogin)
);


