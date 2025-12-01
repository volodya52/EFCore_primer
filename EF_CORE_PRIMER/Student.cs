using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore
{
    public class Student:ObservableService
    {
        private int _id;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private DateTime _birthday;
        private Passport _passport;
        private int _group_Id;
        private Group _group;
        private ObservableCollection<CourseStudent> _courseStudents;

        public int Id 
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }
        public string MiddleName
        {
            get => _middleName;
            set => SetProperty(ref _middleName, value);
        }
        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }
        public DateTime Birthday
        {
            get => _birthday;
            set => SetProperty(ref _birthday, value);
        }

        public Passport Passport
        {
            get => _passport;
            set => SetProperty(ref _passport, value);
        }

        public int GroupId
        {
            get => _group_Id;
            set => SetProperty(ref _group_Id, value);
        }

        public Group Group
        {
            get => _group;
            set => SetProperty(ref _group, value);
        }

        public ObservableCollection<CourseStudent> CourseStudents
        {
            get => _courseStudents;
            set => SetProperty(ref _courseStudents, value);
        }
    }
}
