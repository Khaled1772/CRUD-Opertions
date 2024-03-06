﻿using MVCProject1.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProject1.BLL.InterFaces
{
    public interface IDepartementRepository
    {
        IEnumerable<Department> GetAll();
        Department GetById(int id);
        int Add(Department department);
        int Update(Department department);
        int Delete(Department department);

    }
}
