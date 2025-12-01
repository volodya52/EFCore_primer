using EFCore.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Service
{
    public class CourseService
    {
        private readonly AppDbContext _db=BaseDbService.Instance.Context;

        public static ObservableCollection<Course> Courses { get; set; } = new();

        public int Commit()=>_db.SaveChanges();

        public void Add(Course course)
        {
            var _course = new Course
            {
                Id = course.Id,
                Title = course.Title,
            };
            _db.Add<Course>(course);
            Commit();
            Courses.Add(_course);
        }

        public void GetAll()
        {
            var courses=_db.Courses.ToList();
            Courses.Clear();
            foreach (var course in courses)
            {
                Courses.Add(course);
            }
        }

        public CourseService()
        {
            GetAll();
        }

        public void Remove(Course course)
        {
            _db.Remove<Course>(course);
            if(Commit()>0)
                if(Courses.Contains(course))
                    Courses.Remove(course);
        }
    }
}
