INSERT INto "User"("Name", "Surname", "DateOfBirth", "Email")
VALUES ('Name', 'Surname', '2020-06-1', 'Email');

INSERT INto "User"("Name", "Surname", "DateOfBirth", "Email")
VALUES ('Name1', 'Surname1', '2020-06-1', 'Email');

INSERT INto "User"("Name", "Surname", "DateOfBirth", "Email")
VALUES ('Name2', 'Surname2', '2020-06-1', 'Email');

INSERT INto "Tutor"("UserId","ScientificTitle", "TutoId", "EmploymentDate")
VALUES (13, 'Title', 1, '2020-1-1');


SELECT * FROM "User";
SELECT * FROM "Tutor";
INSERT INto "Position"("TutorId", "InChairFrom","PositionTypes", "HoursOfLecture", "HoursOfTutorials")
VALUES (13, '2020-1-1', 'Lecturer',  1, 1);
SELECT * FROM "Position";


INSERT INto "Theses" ("Title")
VALUES ('Title');

INSERT INTO "Course"("CourseTag", "CourseDescription", "CourseProgram","IdPosition")
VALUES ('ML', 'Description 1', 'Program 1',3);


INSERT INTO "Course"("CourseTag", "CourseDescription", "CourseProgram", "IdPosition")
VALUES ('DB', 'Description 2', 'Program 2', 3);

INSERT INTO "Course"("CourseTag", "CourseDescription", "CourseProgram", "IdPosition")
VALUES ('BE', 'Description 3', 'Program 3', 3);

SELECT * FROM "Course";

INSERT INTO "Subject"("Name", "Type", "Topics")
VALUES ('Machine Vision',1, 'Topic 1');

INSERT INTO "Subject"("Name", "Type", "Topics")
VALUES ('Data cleaning',2, 'Topic 2');

INSERT INTO "Subject"("Name", "Type", "Topics")
VALUES ('ERD',1, 'Topic 3');

INSERT INTO "Subject"("Name", "Type", "Topics")
VALUES ('Normal forms',1, 'Topic 4');

INSERT INTO "Subject"("Name", "Type", "Topics")
VALUES ('Java',1, 'Topic 5');

INSERT INTO "Subject"("Name", "Type", "Topics")
VALUES ('C#',1, 'Topic 6');

SELECT * FROM "Subject";

INSERT INTO "Schedule" ("Date", "Room", "CourseId", "SubjectId")
VALUES ('2020-1-1', 'B110', 5 ,1);

INSERT INTO "Schedule" ("Date", "Room", "CourseId", "SubjectId")
VALUES ('2020-1-1', 'B111', 5 ,2);

INSERT INTO "Schedule" ("Date", "Room", "CourseId", "SubjectId")
VALUES ('2020-1-1', 'B110', 6 ,3);

INSERT INTO "Schedule" ("Date", "Room", "CourseId", "SubjectId")
VALUES ('2020-1-1', 'B111', 6 ,4);

SELECT * FROM "Schedule";

INSERT INTO "Assignment" ("Name","Description", "StartDate", "EndDate", "MaxPoints","SubjectId","Points")
VALUES ('OpenCV','Description 1', '2012-1-1', '2012-3-1', 10, 1, 9);

INSERT INTO "Assignment" ("Name","Description", "StartDate", "EndDate", "MaxPoints","SubjectId","Points")
VALUES ('TensorFlow','Description 1', '2012-1-1', '2012-3-1', 10, 1, 5);

SELECT * FROM "Assignment";

SELECT s."SubjectId", s."Name", s."Type", s."Topics" 
FROM "Subject" as s 
INNER JOIN "Schedule" as sh 
on s."SubjectId" = sh."SubjectId" 
INNER JOIN "Course" as c 
ON sh."CourseId" = c."CourseId" 
Where c."CourseId" = 5;

SELECT s."SubjectId", a."AssignmentId", a."Name", a."Description", a."StartDate", a."EndDate", a."MaxPoints", a."Points" 
FROM "Assignment" as a 
INNER JOIN "Subject" as s 
ON a."SubjectId" = s."SubjectId" 
WHERE s."SubjectId" = 1;


DROP SCHEMA public CASCADE;
CREATE SCHEMA public;
SELECT * FROM "Position"