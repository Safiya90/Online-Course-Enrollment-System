using System;

namespace Online_Course_Enrollment_System
{
    class Program
    {
        static void Main(string[] args)
        {
            CourseCatalog catalog = new CourseCatalog(10); 

            catalog.AddCourse(new VideoCourse("MATH", "Ali", Level.Beginner, 5));
            catalog.AddCourse(new LiveSession("ARABIC", "Muna", Level.Intermediate, "Monday 2 PM"));
            catalog.AddCourse(new VideoCourse("ISLAMIC", "Sara", Level.Advanced, 6));
            catalog.AddCourse(new LiveSession("IT", "Ahmed", Level.Beginner, "Sunday 10 AM"));

            Console.WriteLine("\nBeginner Courses:");
            foreach (var course in catalog[Level.Beginner])
                course?.ShowDetails();

            Console.WriteLine("\nIntermediate Courses:");
            foreach (var course in catalog[Level.Intermediate])
                course?.ShowDetails();

            Console.WriteLine("\nAdvanced Courses:");
            foreach (var course in catalog[Level.Advanced])
                course?.ShowDetails();
        }
    }
    enum Level
    {
        Beginner,
        Intermediate,
        Advanced
    }

    class Course
    {
        public string Name { get; set; }
        public string Instructor { get; set; }
        public Level CourseLevel { get; set; }

        public Course(string name, string instructor, Level level)
        {
            Name = name;
            Instructor = instructor;
            CourseLevel = level;
        }

        public virtual void ShowDetails()
        {
            Console.WriteLine($"Course: {Name}, Instructor: {Instructor}, Level: {CourseLevel}");
        }
    }

    class VideoCourse : Course
    {
        public int Duration { get; set; }

        public VideoCourse(string name, string instructor, Level level, int duration)
            : base(name, instructor, level)
        {
            Duration = duration;
        }

        public override void ShowDetails()
        {
            base.ShowDetails();
            Console.WriteLine($"Duration: {Duration} hours\n");
        }
    }

    class LiveSession : Course
    {
        public string Schedule { get; set; }

        public LiveSession(string name, string instructor, Level level, string schedule)
            : base(name, instructor, level)
        {
            Schedule = schedule;
        }

        public override void ShowDetails()
        {
            base.ShowDetails();
            Console.WriteLine($"Scheduled On: {Schedule}\n");
        }
    }

    class CourseCatalog
    {
        private Course[] courses;
        private int count;

        public CourseCatalog(int size)
        {
            courses = new Course[size];
            count = 0;
        }

        public void AddCourse(Course course)
        {
            if (count < courses.Length)
            {
                courses[count++] = course;
            }
            else
            {
                Console.WriteLine("Catalog is full!");
            }
        }

        public Course[] this[Level level]
        {
            get
            {
                Course[] result = new Course[courses.Length];
                int index = 0;
                for (int i = 0; i < count; i++)
                {
                    if (courses[i].CourseLevel == level)
                    {
                        result[index++] = courses[i];
                    }
                }
                return result;
            }
        }
    }
}
