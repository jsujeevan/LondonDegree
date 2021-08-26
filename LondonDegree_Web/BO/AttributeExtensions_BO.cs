//System libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
//Web/MVC libraries
using System.Web;
//App libraries
using LondonDegree_Web.Models;

namespace LondonDegree_Web.BO
{
    public class AttributeExtensions_BO
    {
        //Get attribute of the property
        //Parameters
        //a)PropertyInfo prop - Example PersonID(property) of the person class
        //b)Func<TAttribute, TValue> - Attribute name of the property Example [DataBinder(DataBinderName = "Org_ID_s")]
        public static TValue GetPropertyValue<TAttribute, TValue>(PropertyInfo cp_property_o, Func<TAttribute, TValue> cp_attributeValue_o) where TAttribute : Attribute
        {
            try
            {
                //Get attribute based on the type
                var vl_attribute_o = cp_property_o.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;

                //If it is not null get the value
                if (vl_attribute_o != null)
                {
                    return cp_attributeValue_o(vl_attribute_o);
                }
            }
            catch(Exception cp_exception_o)
            {
                throw (cp_exception_o);
            }

            //Else pass default value
            return default(TValue);
        }




        //Get property based on the property name
        //Parameters
        //a)Expression<Func<T, object>> cp_lamdaProperty_o: AttributeExtensions_BO.GetPropertyInfo<PersonModel>(x => x.Person_Status_ID_i))
        public static PropertyInfo GetPropertyInfo<T>(Expression<Func<T, object>> cp_lamdaProperty_o)
        {
            MemberExpression vl_memberExp_o = null;

            //this line is necessary, because sometimes the expression comes in as Convert(originalexpression)
            if (cp_lamdaProperty_o.Body is UnaryExpression)
            {
                var vl_unExp_o = (UnaryExpression)cp_lamdaProperty_o.Body;
                if (vl_unExp_o.Operand is MemberExpression)
                {
                    vl_memberExp_o = (MemberExpression)vl_unExp_o.Operand;
                }
                else
                    throw new ArgumentException();
            }
            else if (cp_lamdaProperty_o.Body is MemberExpression)
            {
                vl_memberExp_o = (MemberExpression)cp_lamdaProperty_o.Body;
            }
            else
            {
                throw new ArgumentException();
            }

            return (PropertyInfo)vl_memberExp_o.Member;
        }


    }
}