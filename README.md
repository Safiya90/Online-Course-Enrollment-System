# Online Course Enrollment System

Concepts Used: Enum, Indexer, List, OOP, Polymorphism
Description:
Create an enum `Level` with values: Beginner, Intermediate, Advanced
Create a base class `Course` with:
- Name, Instructor, Level
Create two derived classes:
- VideoCourse (extra: Duration in hours)
- LiveSession (extra: DateTime Schedule)
Create a class `CourseCatalog` that uses an indexer to access courses by level:
- catalog[Level.Beginner] → returns all beginner-level courses
Demonstrate adding various courses to the catalog and print course details by level.
