using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper_Demo
{
    interface IProductRepository 
    {

        IEnumerable<Department> GetAllProducts();

        
        void InsertDepartment(string newDepartmentName);




    }
}
