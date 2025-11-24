using EFCore.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Service
{
    public class GroupService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public static ObservableCollection<Group> Groups { get; set; } = new();
        public void GetAll()
        {
            var groups = _db.Groups.ToList();
            Groups.Clear();
            foreach (var group in groups)
            {
                Groups.Add(group);
            }
        }

        public int Commit() => _db.SaveChanges();
        public GroupService()
        {
            GetAll();
        }

        public void Remove(Group group)
        {
            _db.Remove(group);
            if (Commit() > 0)
                Groups.Remove(group);
        }
    }
}
