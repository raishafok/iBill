﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

using LyncBillingBase.DataAccess;
using LyncBillingBase.DataModels;

namespace LyncBillingBase.DataMappers
{
    public class SitesDataMapper : DataAccess<Site>
    {
        private DataAccess<Department> Departments = new DataAccess<Department>();
        private DataAccess<SiteDepartment> SitesDepartments = new DataAccess<SiteDepartment>();

        
    }
}