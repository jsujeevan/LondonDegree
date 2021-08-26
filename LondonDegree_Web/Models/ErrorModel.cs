using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LondonDegree_Web.Models
{
    public class ErrorModel
    {
        public string Action { get; set; }

        public string Controller { get; set; }

        public Exception Exception { get; set; }

        public Guid Reference { get; set; }
    }
}