using EFCore.Data;
using EFCore.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore
{
    public class StudentService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public ObservableCollection<Student> Students { get; set; } = new( );

        public StudentService ()
        {
            GetAll( );
        }
        public void Add(Student student)
        {
            var _student = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                MiddleName = student.MiddleName,
                Birthday = student.Birthday,
                Passport=student.Passport,
                GroupId=student.GroupId,
                Group=student.Group
            };
            _db.Add<Student>(_student);
            Commit( );
            Students.Add(_student);
        }

        public void GetAll ()
        {
            var students = _db.Students
                .Include(s => s.Passport)
                .Include(s=>s.Group)
                .ToList( );
            Students.Clear( );
            foreach(var student in students)
            {
                Students.Add(student);
            }
        }
        public int Commit () => _db.SaveChanges( );

        public void Remove(Student student)
        {
            _db.Remove<Student>(student);
            if (Commit( ) > 0)
            {
                if (Students.Contains(student))
                    Students.Remove(student);
            }
        }
    }
}
