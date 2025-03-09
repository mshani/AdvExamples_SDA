using ORMSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMSchool.Services
{
    internal class DepartmentService
    {
        private readonly SchoolContext _context;
        public DepartmentService() { 
            _context = new SchoolContext();
        }

        public Department? GetDepartmentById(int id)
        {
            var result = _context.Departments
                .FirstOrDefault(x => x.Id == id);
            return result;
        }
    }
}
