using System;
using System.Collections.Generic;
using System.IO;

namespace UniversitySystem
{
    class Student
    {
        public double Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string College { get; set; }
        public List<Course> Courses { get; set; }

        public Student()
        {
            Courses = new List<Course>();
        }
    }

    class Course
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public double Grade { get; set; }
    }

    class Program
    {
        static List<Student> students = new List<Student>();
        static List<Course> courses = new List<Course>();
        static string studentsFile = "students.txt";
        static string coursesFile = "courses.txt";

        static void Main(string[] args)
        {
            Console.WriteLine(@"
                          ███████╗███╗   ██╗ █████╗  ██████╗████████╗██╗   ██╗███████╗
                          ██╔════╝████╗  ██║██╔══██╗██╔════╝╚══██╔══╝██║   ██║██╔════╝
                          █████╗  ██╔██╗ ██║███████║██║        ██║   ██║   ██║███████╗
                          ██╔══╝  ██║╚██╗██║██╔══██║██║        ██║   ██║   ██║╚════██║
                          ███████╗██║ ╚████║██║  ██║╚██████╗   ██║   ╚██████╔╝███████║
                          ╚══════╝╚═╝  ╚═══╝╚═╝  ╚═╝ ╚═════╝   ╚═╝    ╚═════╝ ╚══════╝

                                   Welcome to Enactus ANU University System
");

            Console.WriteLine("Please Select Your Language");
            Console.WriteLine("Arabic  = 1 ");
            Console.WriteLine("English = 2 ");
            Console.WriteLine("Dutch   = 3 ");
            Console.WriteLine("French  = 4 ");
            int.Parse(Console.ReadLine());

            LoadData();
            Console.WriteLine("Choose Your Fav Background Color Pls:");
            Console.WriteLine("1. Yellow");
            Console.WriteLine("2. Blue");
            Console.WriteLine("3. Green");
            Console.WriteLine("4. White");
            Console.Write("Your choice: ");
            string bgChoice = Console.ReadLine();

            ConsoleColor background = ConsoleColor.Yellow;
            switch (bgChoice)
            {
                case "1":
                    background = ConsoleColor.Yellow;
                    break;
                case "2":
                    background = ConsoleColor.Blue;
                    break;
                case "3":
                    background = ConsoleColor.Green;
                    break;
                case "4":
                    background = ConsoleColor.White;
                    break;
                default:
                    Console.WriteLine("Invalid choice! Using default yellow background.");
                    break;
            }

            Console.WriteLine("\nChoose Your Fav Text Color Pls:");
            Console.WriteLine("1. Black");
            Console.WriteLine("2. Red");
            Console.WriteLine("3. DarkBlue");
            Console.WriteLine("4. DarkGreen");
            Console.Write("Your choice: ");
            string fgChoice = Console.ReadLine();

            ConsoleColor foreground = ConsoleColor.Black;
            switch (fgChoice)
            {
                case "1":
                    foreground = ConsoleColor.Black;
                    break;
                case "2":
                    foreground = ConsoleColor.Red;
                    break;
                case "3":
                    foreground = ConsoleColor.DarkBlue;
                    break;
                case "4":
                    foreground = ConsoleColor.DarkGreen;
                    break;
                default:
                    Console.WriteLine("Invalid choice! Using default black text.");
                    break;
            }

            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
            Console.Clear();
            Console.WriteLine(@"
                          ███████╗███╗   ██╗ █████╗  ██████╗████████╗██╗   ██╗███████╗
                          ██╔════╝████╗  ██║██╔══██╗██╔════╝╚══██╔══╝██║   ██║██╔════╝
                          █████╗  ██╔██╗ ██║███████║██║        ██║   ██║   ██║███████╗
                          ██╔══╝  ██║╚██╗██║██╔══██║██║        ██║   ██║   ██║╚════██║
                          ███████╗██║ ╚████║██║  ██║╚██████╗   ██║   ╚██████╔╝███████║
                          ╚══════╝╚═╝  ╚═══╝╚═╝  ╚═╝ ╚═════╝   ╚═╝    ╚═════╝ ╚══════╝

");

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("                                     Welcome to Enactus ANU University");
                Console.WriteLine("");
                Console.WriteLine("Welcome to the University System!");
                Console.WriteLine("Please Tell Us Are you:");
                Console.WriteLine("1. Student");
                Console.WriteLine("2. Parent");
                Console.WriteLine("3. Quit");
                Console.Write("Choose: ");
                string userType = Console.ReadLine();

                if (userType == "1")
                {
                    StudentMenu();
                }
                else if (userType == "2")
                {
                    ParentMenu();
                }
                else if (userType == "3")
                {
                    Console.WriteLine("Exiting... Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice! Please try again.");
                }
            }

            SaveData();
        }

        static void StudentMenu()
        {
            while (true)
            {
                Console.WriteLine("\n===== Student Menu =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Remove Student");
                Console.WriteLine("3. Edit Student");
                Console.WriteLine("4. Add Course");
                Console.WriteLine("5. Register Student in Course");
                Console.WriteLine("6. Remove Course");
                Console.WriteLine("7. Add Grade");
                Console.WriteLine("8. Display Students");
                Console.WriteLine("9. Return to Main Menu");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        RemoveStudent();
                        break;
                    case "3":
                        EditStudent();
                        break;
                    case "4":
                        AddCourse();
                        break;
                    case "5":
                        RegisterStudentInCourse();
                        break;
                    case "6":
                        RemoveCourse();
                        break;
                    case "7":
                        AddGrade();
                        break;
                    case "8":
                        DisplayStudents();
                        break;
                    case "9":
                        break; // This breaks out of the loop and returns to the Main Menu
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
                if (choice == "9")
                    break; // This ensures you exit the loop and go back to the Main Menu
            }
        }

        static void ParentMenu()
        {
            while (true)
            {
                Console.WriteLine("\n===== Parent Menu =====");
                Console.WriteLine("1. Display Students");
                Console.WriteLine("2. Return to Main Menu");
                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayStudents();
                        break;
                    case "2":
                        break; // This breaks out of the loop and returns to the Main Menu
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
                if (choice == "2")
                    break; // This ensures you exit the loop and go back to the Main Menu
            }
        }



        static void SaveData()
        {
            using (StreamWriter studentWriter = new StreamWriter(studentsFile))
            {
                foreach (var student in students)
                {
                    studentWriter.WriteLine($"{student.Id},{student.Name},{student.Email},{student.College}");
                    foreach (var course in student.Courses)
                    {
                        studentWriter.WriteLine($"  {course.Code},{course.Name},{course.Grade}");
                    }
                }
            }

            using (StreamWriter courseWriter = new StreamWriter(coursesFile))
            {
                foreach (var course in courses)
                {
                    courseWriter.WriteLine($"{course.Code},{course.Name}");
                }
            }
        }

        static void LoadData()
        {
            if (File.Exists(studentsFile))
            {
                var studentLines = File.ReadAllLines(studentsFile);
                Student currentStudent = null;

                foreach (var line in studentLines)
                {
                    if (line.StartsWith("  "))
                    {
                        var courseData = line.Trim().Split(',');
                        var course = new Course
                        {
                            Code = int.Parse(courseData[0]),
                            Name = courseData[1],
                            Grade = double.Parse(courseData[2])
                        };
                        currentStudent?.Courses.Add(course);
                    }
                    else
                    {
                        var studentData = line.Split(',');
                        currentStudent = new Student
                        {
                            Id = double.Parse(studentData[0]),
                            Name = studentData[1],
                            Email = studentData[2],
                            College = studentData[3]
                        };
                        students.Add(currentStudent);
                    }
                }
            }

            if (File.Exists(coursesFile))
            {
                var courseLines = File.ReadAllLines(coursesFile);
                foreach (var line in courseLines)
                {
                    var courseData = line.Split(',');
                    var course = new Course
                    {
                        Code = int.Parse(courseData[0]),
                        Name = courseData[1]
                    };
                    courses.Add(course);
                }
            }
        }

        static void AddStudent()
        {
            Console.Write("Enter Student ID: ");
            if (!double.TryParse(Console.ReadLine(), out double id))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            if (students.Exists(s => s.Id == id))
            {
                Console.WriteLine("A student with this ID already exists.");
                return;
            }

            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            string email;
            while (true)
            {
                Console.Write("Enter Email (must end with @gmail.com): ");
                email = Console.ReadLine();
                if (email.EndsWith("@gmail.com"))
                    break;
                else
                    Console.WriteLine("Invalid email format. Please try again.");
            }

            Console.WriteLine("Select College:");
            Console.WriteLine("1. Computer Science");
            Console.WriteLine("2. Commerce");
            Console.WriteLine("3. Medicine");
            Console.WriteLine("4. Pharmacy");
            Console.Write("Choose: ");
            string collegeChoice = Console.ReadLine();
            string college = string.Empty;

            switch (collegeChoice)
            {
                case "1":
                    college = "Computer Science";
                    break;
                case "2":
                    college = "Commerce";
                    break;
                case "3":
                    college = "Medicine";
                    break;
                case "4":
                    college = "Pharmacy";
                    break;
                default:
                    Console.WriteLine("Invalid college choice.");
                    return;
            }

            Student student = new Student
            {
                Id = id,
                Name = name,
                Email = email,
                College = college
            };

            students.Add(student);
            Console.WriteLine("Student added successfully!");
        }

        static void RemoveStudent()
        {
            Console.Write("Enter Student ID to remove: ");
            if (!double.TryParse(Console.ReadLine(), out double id))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            var student = students.Find(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine("Student removed successfully!");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        static void EditStudent()
        {
            Console.Write("Enter Student ID to edit: ");
            if (!double.TryParse(Console.ReadLine(), out double id))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            var student = students.Find(s => s.Id == id);
            if (student != null)
            {
                Console.Write("Enter new name (or press enter to keep current): ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newName))
                {
                    student.Name = newName;
                }

                Console.Write("Enter new email (or press enter to keep current): ");
                string newEmail = Console.ReadLine();
                if (!string.IsNullOrEmpty(newEmail))
                {
                    student.Email = newEmail;
                }

                Console.Write("Enter new college (or press enter to keep current): ");
                string newCollege = Console.ReadLine();
                if (!string.IsNullOrEmpty(newCollege))
                {
                    student.College = newCollege;
                }

                Console.WriteLine("Student updated successfully!");
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        static void AddCourse()
        {
            Console.Write("Enter Course Code: ");
            if (!int.TryParse(Console.ReadLine(), out int code))
            {
                Console.WriteLine("Invalid code format.");
                return;
            }

            if (courses.Exists(c => c.Code == code))
            {
                Console.WriteLine("A course with this code already exists.");
                return;
            }

            Console.Write("Enter Course Name: ");
            string name = Console.ReadLine();

            Course course = new Course
            {
                Code = code,
                Name = name
            };

            courses.Add(course);
            Console.WriteLine("Course added successfully!");
        }

        static void RegisterStudentInCourse()
        {
            Console.Write("Enter Student ID: ");
            if (!double.TryParse(Console.ReadLine(), out double id))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            var student = students.Find(s => s.Id == id);
            if (student != null)
            {
                Console.WriteLine("Available Courses:");
                foreach (var course in courses)
                {
                    Console.WriteLine($"Code: {course.Code}, Name: {course.Name}");
                }

                Console.Write("Enter Course Code to register: ");
                if (!int.TryParse(Console.ReadLine(), out int courseCode))
                {
                    Console.WriteLine("Invalid course code.");
                    return;
                }

                var courseToRegister = courses.Find(c => c.Code == courseCode);
                if (courseToRegister != null)
                {
                    student.Courses.Add(courseToRegister);
                    Console.WriteLine("Course registered successfully!");
                }
                else
                {
                    Console.WriteLine("Course not found!");
                }
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        static void RemoveCourse()
        {
            Console.Write("Enter Student ID: ");
            if (!double.TryParse(Console.ReadLine(), out double id))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            var student = students.Find(s => s.Id == id);
            if (student != null)
            {
                Console.WriteLine("Enrolled Courses:");
                foreach (var course in student.Courses)
                {
                    Console.WriteLine($"Code: {course.Code}, Name: {course.Name}");
                }

                Console.Write("Enter Course Code to remove: ");
                if (!int.TryParse(Console.ReadLine(), out int courseCode))
                {
                    Console.WriteLine("Invalid course code.");
                    return;
                }

                var courseToRemove = student.Courses.Find(c => c.Code == courseCode);
                if (courseToRemove != null)
                {
                    student.Courses.Remove(courseToRemove);
                    Console.WriteLine("Course removed successfully!");
                }
                else
                {
                    Console.WriteLine("Course not found!");
                }
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        static void AddGrade()
        {
            Console.Write("Enter Student ID: ");
            if (!double.TryParse(Console.ReadLine(), out double id))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            var student = students.Find(s => s.Id == id);
            if (student != null)
            {
                Console.WriteLine("Enrolled Courses:");
                foreach (var course in student.Courses)
                {
                    Console.WriteLine($"Code: {course.Code}, Name: {course.Name}");
                }

                Console.Write("Enter Course Code to add grade: ");
                if (!int.TryParse(Console.ReadLine(), out int courseCode))
                {
                    Console.WriteLine("Invalid course code.");
                    return;
                }

                var courseToGrade = student.Courses.Find(c => c.Code == courseCode);
                if (courseToGrade != null)
                {
                    Console.Write("Enter Grade: ");
                    if (double.TryParse(Console.ReadLine(), out double grade))
                    {
                        courseToGrade.Grade = grade;
                        Console.WriteLine("Grade added successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid grade format.");
                    }
                }
                else
                {
                    Console.WriteLine("Course not found!");
                }
            }
            else
            {
                Console.WriteLine("Student not found!");
            }
        }

        static void DisplayStudents()
        {
            Console.WriteLine("\n===== Students List =====");
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Email: {student.Email}, College: {student.College}");
                foreach (var course in student.Courses)
                {
                    Console.WriteLine($"   Course Code: {course.Code}, Course Name: {course.Name}, Grade: {course.Grade}");
                }
            }
        }
    }
}