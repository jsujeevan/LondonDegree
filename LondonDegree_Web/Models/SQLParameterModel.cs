//System libraries
using System;
using System.Collections.Generic;
using System.Linq;
//Web/MVC libraries
using System.Web;
//SQL/Data libraries
using System.Data;

namespace LondonDegree_Web.Models
{
    public class SQLParameterModel
    {
        //Paremeter name
        public string Parameter_Name { get; set; }

        //Parameter value
        public Object Parameter_Value { get; set; }

        //Parameter type
        public SqlDbType SqlDbType { get; set; }
    }
}