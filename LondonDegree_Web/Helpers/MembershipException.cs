using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LondonDegree_Web.Helpers
{
    public class MembershipException : Exception
    {
        public MembershipException()
        {
        }

        public MembershipException(string message)
            : base(message)
        {
        }

        public MembershipException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}