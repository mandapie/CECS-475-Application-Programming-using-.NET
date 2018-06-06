using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class BusinessLayer : IBusinessLayer
    {
        SchoolDBEntities S = new SchoolDBEntities();
        private readonly ITeacherRepository _teacherRepository;
        private readonly ICourseRepository _courseRepository;

        /// <summary>
        /// constructor
        /// </summary>
        public BusinessLayer()
        {
            _teacherRepository = new TeacherRepository(S);
            _courseRepository = new CourseRepository(S);
        }

        /// <summary>
        /// teacher functions
        /// </summary>
        /// <returns></returns>
        public IList<Teacher> GetAllTeacher()
        {
            return _teacherRepository.GetAll().ToList();
        }

        public Teacher GetTeacherByID(int id)
        {
            return _teacherRepository.GetById(id);
        }

        public Teacher GetTeacherByName(string name)
        {
            return _teacherRepository.GetSingle(t => t.TeacherName.Equals(name));
        }

        public void AddTeacher(Teacher t)
        {
            _teacherRepository.Insert(t);
        }

        public void UpdateTeacher(Teacher t)
        {
            _teacherRepository.Update(t);
        }

        public void RemoveTeacher(Teacher t)
        {
            _teacherRepository.Delete(t);
        }

        /// <summary>
        /// course functions
        /// </summary>
        /// <returns></returns>
        public IList<Course> GetAllCourse()
        {
            return _courseRepository.GetAll().ToList();
        }

        public Course GetCourseByID(int id)
        {
            return _courseRepository.GetById(id);
        }

        public Course GetCourseByName(string name)
        {
            return _courseRepository.GetSingle(c => c.CourseName.Equals(name));
        }

        public void AddCourse(Course c)
        {
            _courseRepository.Insert(c);
        }

        public void UpdateCourse(Course c)
        {
            _courseRepository.Update(c);
        }

        public void RemoveCourse(Course c)
        {
            _courseRepository.Delete(c);
        }
    }
}
