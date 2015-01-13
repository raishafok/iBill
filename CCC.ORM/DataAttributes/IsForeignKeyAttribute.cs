﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCC.ORM.DataAttributes
{
    /// <summary>
    /// This attribute tells the Repository that it's associated property resembles a Database Table Foreign Key.
    /// </summary>

    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class IsForeignKeyAttribute : Attribute
    {
        public bool Status { get; private set; }

        public IsForeignKeyAttribute(bool status = true) 
        {
            this.Status = status;
        }
    }
}