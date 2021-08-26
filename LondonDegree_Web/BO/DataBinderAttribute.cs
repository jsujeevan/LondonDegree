//System libraries
using System;
using System.Collections.Generic;
using System.Linq;
//Web/MVC libraries
using System.Web;

namespace LondonDegree_Web.BO
{
    //Create an attribute class to hold name of the field in stored procedure/table
    public class DataBinderAttribute : Attribute
    {
        public string DataBinderName { get; set; }
    }
}