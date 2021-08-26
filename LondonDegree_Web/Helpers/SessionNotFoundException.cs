using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LondonDegree_Web.Helpers
{
    public class SessionNotFoundException : Exception
    {
        public SessionNotFoundException()
        {
        }

        public SessionNotFoundException(string message)
            : base(message)
        {
        }

        public SessionNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}