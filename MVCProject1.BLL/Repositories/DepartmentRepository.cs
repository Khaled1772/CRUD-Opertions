using MVCProject1.BLL.InterFaces;
using MVCProject1.DAL.DbContexts;
using MVCProject1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject1.BLL.Repositories
{
    public class DepartmentRepository : IDepartementRepository
    {
        private MvcAppDbContext _dbContext;
        public DepartmentRepository(MvcAppDbContext dbContext)
        {
            _dbContext= dbContext;
        }
        public int Add(Department department)
        {
            _dbContext.Add(department);
            return _dbContext.SaveChanges();
        }

        public int Delete(Department department)
        {
           _dbContext.Remove(department);
            return _dbContext.SaveChanges();    
        }

        public IEnumerable<Department> GetAll()
        {
            return _dbContext.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return _dbContext.Departments.Find(id);
        }

        public int Update(Department department)
        {
            _dbContext.Update(department);
            return _dbContext.SaveChanges();      
        }
    }
}
