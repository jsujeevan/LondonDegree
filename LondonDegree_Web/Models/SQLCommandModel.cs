//System libraries
using System;
using System.Collections.Generic;
using System.Linq;
//Web/MVC libraries
using System.Web;

namespace LondonDegree_Web.Models
{
    public class SQLCommandModel
    {
        //Stored procedure name
        public string SQL_Name { get; set; }

        //Parameter list
        public List<SQLParameterModel> SQL_ParameterList { get; set; }
    }
}