using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBusinessLayer
    {
        IList<Teacher> GetAllTeacher();
        Teacher GetTeacherByID(int id);
        Teacher GetTeacherByName(string name);
        void AddTeacher(Teacher t);
        void UpdateTeacher(Teacher t);
        void RemoveTeacher(Teacher t);

        IList<Course> GetAllCourse();
        Course GetCourseByID(int id);
        Course GetCourseByName(string name);
        void AddCourse(Course c);
        void UpdateCourse(Course c);
        void RemoveCourse(Course c);
    }
}
