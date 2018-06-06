using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessLayer BL = new BusinessLayer();
            int choice, option, id;
            string answer;
            bool exit = false;
            Teacher teach = new Teacher();
            Course course = new Course();

            Console.WriteLine("Repository Application Menu");
                        
            while(exit == false)
            {
                Console.WriteLine("\n1. Add a Teacher\n" +
                              "2. Update a Teacher\n" +
                              "3. Delete a Teacher\n" +
                              "4. Courses taught by Teacher(input ID)\n" +
                              "5. Display all Teachers\n\n" +
                              "6. Add a Course\n" +
                              "7. Update a Course\n" +
                              "8. Delete a Course\n" +
                              "9. Display all Courses\n" +
                              "0. Exit\n");
                choice = Convert.ToInt32(Console.ReadLine());
                try
                {
                    switch (choice)
                    {
                        case 0: //exit
                            exit = true;
                            break;
                        case 1: //add teach
                            Console.WriteLine("add a Teacher's name: ");
                            teach.TeacherName = Console.ReadLine();
                            BL.AddTeacher(teach);
                            break;
                        case 2: //update teach
                            Console.WriteLine("Search by:\n1. ID\n2. name");
                            option = Convert.ToInt32(Console.ReadLine());
                            if (option == 1) //search by ID
                            {
                                Console.WriteLine("Enter ID: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                teach = BL.GetTeacherByID(id);
                            }
                            else if (option == 2) //search by name
                            {
                                Console.WriteLine("Enter Name: ");
                                string name = Console.ReadLine();
                                teach = BL.GetTeacherByName(name);
                            }
                            Console.WriteLine("Current name: {0} with id: {1}", teach.TeacherName, teach.TeacherId);
                            Console.WriteLine("Change name: ");
                            teach.TeacherName = Console.ReadLine();
                            BL.UpdateTeacher(teach);
                            break;
                        case 3: //delete teach
                            Console.WriteLine("Search by:\n1. ID\n2. name");
                            option = Convert.ToInt32(Console.ReadLine());
                            if (option == 1) //search by ID
                            {
                                Console.WriteLine("Enter ID: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                teach = BL.GetTeacherByID(id);
                            }
                            else if (option == 2) //search by name
                            {
                                Console.WriteLine("Enter Name: ");
                                string name = Console.ReadLine();
                                teach = BL.GetTeacherByName(name);
                            }
                            Console.WriteLine("Current name: {0} with id: {1}", teach.TeacherName, teach.TeacherId);
                            Console.WriteLine("Delete this? (Y/N)");
                            while (exit == false) //confirm deletion
                            {
                                answer = Console.ReadLine();
                                if (answer == "y" || answer == "Y")
                                {
                                    BL.RemoveTeacher(teach);
                                    exit = true;
                                }
                                else if (answer == "n" || answer == "N")
                                    exit = true;
                                else
                                    Console.WriteLine("only y or n");
                            }
                            exit = false;
                            break;
                        case 4: //courses taught by teacher
                            BL.GetAllCourse();
                            Console.WriteLine("Enter a teacher ID: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            teach = BL.GetTeacherByID(id);
                            Console.WriteLine("Teacher name: {0}\nCourse(s) teaching:\n", teach.TeacherName);
                            foreach (Course c in teach.Courses)
                            {
                                Console.WriteLine(c.CourseName);
                            }
                            break;
                        case 5: //all teachers
                            Console.WriteLine("{0}\t{1}", "Teacher Name", "Teacher ID");
                            Console.WriteLine("___________________________");
                            foreach (Teacher t in BL.GetAllTeacher())
                            {
                                Console.WriteLine("{0}\t{1}", t.TeacherName, t.TeacherId);
                            }
                            break;
                        case 6: //add course
                            Console.WriteLine("add a Course name: ");
                            course.CourseName = Console.ReadLine();
                            Console.WriteLine("Who teaches this course?(Enter ID)\n");
                            course.TeacherId = Convert.ToInt32(Console.ReadLine());
                            BL.AddCourse(course);
                            break;
                        case 7: //update course
                            Console.WriteLine("Search by:\n1. ID\n2. name");
                            option = Convert.ToInt32(Console.ReadLine());
                            if (option == 1) //search by ID
                            {
                                Console.WriteLine("Enter ID: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                BL.GetCourseByID(id); ;
                            }
                            else if (option == 2) //search by name
                            {
                                Console.WriteLine("Enter Name: ");
                                string name = Console.ReadLine();
                                BL.GetCourseByName(name);
                            }
                            Console.WriteLine("Current name: {0} with id: {1}", course.CourseName, course.CourseId);
                            Console.WriteLine("Change name: ");
                            course.CourseName = Console.ReadLine();
                            BL.UpdateCourse(course);
                            break;
                        case 8: //delete course
                            Console.WriteLine("Search by:\n1. ID\n2. name");
                            option = Convert.ToInt32(Console.ReadLine());
                            if (option == 1) //search by ID
                            {
                                Console.WriteLine("Enter ID: ");
                                id = Convert.ToInt32(Console.ReadLine());
                                course = BL.GetCourseByID(id);
                            }
                            else if (option == 2) //search by name
                            {
                                Console.WriteLine("Enter Name: ");
                                string name = Console.ReadLine();
                                course = BL.GetCourseByName(name);
                            }
                            Console.WriteLine("Current name: {0} with id: {1}", course.CourseName, course.CourseId);
                            Console.WriteLine("Delete this? (Y/N)");
                            while (exit == false) //confirm deletion
                            {
                                answer = Console.ReadLine();
                                if (answer == "y" || answer == "Y")
                                {
                                    BL.RemoveCourse(course);
                                    exit = true;
                                }
                                else if (answer == "n" || answer == "N")
                                    exit = true;
                                else
                                    Console.WriteLine("only y or n");
                            }
                            exit = false;
                            break;
                        case 9: //all courses
                            Console.WriteLine("{0}\t{1}", "Course Name", "Course ID");
                            Console.WriteLine("___________________________");
                            foreach (Course c in BL.GetAllCourse())
                            {
                                Console.WriteLine("{0}\t\t{1}", c.CourseName, c.CourseId);
                            }
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Item does not exist");
                }
            }
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey();
        }
    }
}
