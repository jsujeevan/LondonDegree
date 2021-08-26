//System libraries
using System;
using System.Collections.Generic;
using System.Linq;
//Web/MVC libraries
using System.Web;
//Application libraries
using LondonDegree_Web.Models;
//SQL/Data libraries
using System.Data.SqlClient;
using System.Data;
using System.Reflection;


namespace LondonDegree_Web.BO
{
    public class DataBinder_BO
    {

        //Get model using attributes and reflection
        public List<GenericModel> GetGenericModel(Type vl_modelType_o, SQLCommandModel vl_sqlCommand_o)
        {
            //Varibale - Declaration
            Object vl_returnValue_o = null;
            List<String> vl_columnList_o = null;
            SqlDataReader vl_sqlReader_o = null;

            //Varibale - Instantitation
            LinkedList<GenericModel> vl_genericModelList_o = new LinkedList<GenericModel>();

            //Get connection string
            string vl_conString_s = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection vl_sqlCon_o = new SqlConnection(vl_conString_s);

            try
            {
                vl_sqlCon_o.Open();
                // SP call - Get name and parameters including the type of parameters
                SqlCommand cmd = new SqlCommand(vl_sqlCommand_o.SQL_Name, vl_sqlCon_o);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (var param in vl_sqlCommand_o.SQL_ParameterList)
                {
                    // Add the input parameter and set its properties.
                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = param.Parameter_Name;
                    parameter.SqlDbType = param.SqlDbType;
                    parameter.Value = param.Parameter_Value;


                    //Do null checks (against SqlDbType)
                    switch (parameter.SqlDbType.ToString())
                    {
                        case "DateTime":
                            if ((DateTime)parameter.Value == new DateTime()) { parameter.Value = DBNull.Value; }
                            break;
                        case "UniqueIdentifier":
                            if ((Guid)parameter.Value == Guid.Empty) { parameter.Value = DBNull.Value; }
                            break;
                        case "VarChar":
                            if ((String)parameter.Value == null) { parameter.Value = DBNull.Value; }
                            break;
                        case "Int":
                            if ((int)parameter.Value == 0) { parameter.Value = DBNull.Value; }
                            break;
                    }



                    cmd.Parameters.Add(parameter);
                }


                // Execute the reader
                vl_sqlReader_o = cmd.ExecuteReader();
                //Get all columns
                vl_columnList_o = Enumerable.Range(0, vl_sqlReader_o.FieldCount)
                        .Select(vl_sqlReader_o.GetName)
                        .ToList();

                //Iterate resultset
                while (vl_sqlReader_o.Read())
                {
                    //Create a generic object instance based on the type (Ex PersonModel person = new PersonModel())
                    GenericModel vl_genericModel_o = (GenericModel)Activator.CreateInstance(vl_modelType_o);
                    //Get properties of object type (Ex - personID from person object) 
                    foreach (var prop in vl_modelType_o.GetProperties())
                    {
                        //Get name of the Data binder attribute (Ex - [DataBinder(DataBinderName = "Per_ID_s")])
                        string value = AttributeExtensions_BO.GetPropertyValue(prop, (DataBinderAttribute a) => a.DataBinderName);


                        //Column exist in the stored procedure ?
                        if (vl_columnList_o.Contains(value))
                        {
                            //Handle null values
                            if (vl_sqlReader_o[value] != DBNull.Value)
                            {
                                //Automatically convert into the property type(Example - If PersonID type is GUID then convert it into GUID)
                                vl_returnValue_o = Convert.ChangeType(vl_sqlReader_o[value], prop.PropertyType);
                            }
                            else
                            {
                                vl_returnValue_o = null;
                            }
                            //Set value to the property at run time (Example - Assign value {E77A4E26-10CB-432F-8E2E-50574D6BF980} to PersonID)
                            prop.SetValue(vl_genericModel_o, vl_returnValue_o, null);
                        }

                    }
                    //Add object into the list
                    if (vl_genericModelList_o.Count > 0)
                    {
                        vl_genericModelList_o.AddBefore(vl_genericModelList_o.First, vl_genericModel_o);
                    }
                    else
                    {
                        vl_genericModelList_o.AddFirst(vl_genericModel_o);
                    }

                }

            }
            catch (Exception vl_error_o)
            {
                throw (vl_error_o);
            }
            finally
            {
                //Release resources
                vl_sqlReader_o.Close();
                vl_sqlCon_o.Close();
            }
            //Return list
            return vl_genericModelList_o.ToList();

        }


        //Get dropdown list
        public Dictionary<string, string> GetDropdownList(PropertyInfo cp_property_o)
        {
            string vl_binderName_s = "";
            string vl_key_s = "";
            string vl_value_s = "";
            Dictionary<string, string> vl_dropdownList_di = new Dictionary<string, string>();
            vl_binderName_s = AttributeExtensions_BO.GetPropertyValue(cp_property_o, (DataBinderAttribute a) => a.DataBinderName);

            string vl_conString_s = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection vl_sqlCon_o = new SqlConnection(vl_conString_s);
            SqlDataReader vl_sqlReader_o = null;
            try
            {
                vl_sqlCon_o.Open();
                // SP call
                SqlCommand cmd = new SqlCommand("Lookup_Values__SEL", vl_sqlCon_o);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Key_Field_s", vl_binderName_s));

                // Execute the reader
                vl_sqlReader_o = cmd.ExecuteReader();
                while (vl_sqlReader_o.Read())
                {
                    //Get key and values
                    vl_key_s = vl_sqlReader_o["ID_"].ToString();
                    vl_value_s = vl_sqlReader_o["Value_"].ToString();
                    vl_dropdownList_di.Add(vl_key_s, vl_value_s);
                }
            }
            catch (Exception vl_error_o)
            {
                //throw error
                throw (vl_error_o);
            }
            finally
            {
                vl_sqlReader_o.Close();
                vl_sqlCon_o.Close();
            }


            return vl_dropdownList_di;
        }

        //Get dropdown list
        public Dictionary<string, string> GetMETADropdownList(string cp_CommandText_s)
        {
            Dictionary<string, string> vl_dropdownList_di = new Dictionary<string, string>();

            string vl_conString_s = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection vl_sqlCon_o = new SqlConnection(vl_conString_s);
            SqlDataReader vl_sqlReader_o = null;
            try
            {
                vl_sqlCon_o.Open();
                
                SqlCommand cmd = new SqlCommand(cp_CommandText_s, vl_sqlCon_o);
                cmd.CommandType = CommandType.StoredProcedure;

                // Execute the reader
                vl_sqlReader_o = cmd.ExecuteReader();
                while (vl_sqlReader_o.Read())
                {                    
                    vl_dropdownList_di.Add(vl_sqlReader_o["ID_"].ToString(), vl_sqlReader_o["Value_"].ToString());
                }
            }
            catch (Exception vl_error_o)
            {
                //throw error
                throw (vl_error_o);
            }
            finally
            {
                vl_sqlReader_o.Close();
                vl_sqlCon_o.Close();
            }

            return vl_dropdownList_di;
        }

        //Insert or update model using reflection and attributes
        public bool InsertOrUpdateGenericModel(GenericModel vl_model_o, SQLCommandModel vl_sqlCommand_o)
        {
            //Varibale - Declaration
            int vl_result_i = 0;
            bool vl_result_z = false;
            String vl_propertyType_s = "";
            

            //Get connection string
            string vl_conString_s = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection vl_sqlCon_o = new SqlConnection(vl_conString_s);

            try
            {
                vl_sqlCon_o.Open();
                // SP call - Get name and parameters including the type of parameters
                SqlCommand cmd = new SqlCommand(vl_sqlCommand_o.SQL_Name, vl_sqlCon_o);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (var param in vl_sqlCommand_o.SQL_ParameterList)
                {
                    // Add input parameter and set value for the param.
                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = param.Parameter_Name;
                    parameter.SqlDbType = param.SqlDbType;
                    parameter.Value = param.Parameter_Value;

                    if (vl_model_o != null)
                    {
                        //Get all properties of the model
                        foreach (var prop in vl_model_o.GetType().GetProperties())
                        {
                            //Get name of the Data binder attribute (Example - [DataBinder(DataBinderName = "Per_ID_s")])
                            string value = AttributeExtensions_BO.GetPropertyValue(prop, (DataBinderAttribute a) => a.DataBinderName);

                            //Check to make sure sql parameter name equals to data binder name of the model
                            if (parameter.ParameterName.Equals(string.Concat("@", value)))
                            {
                                //Get value
                                parameter.Value = prop.GetValue(vl_model_o, null);
                                vl_propertyType_s = prop.PropertyType.Name;

                                //Do null checks (against c# types)
                                switch (vl_propertyType_s)
                                {
                                    case "DateTime":
                                        if ((DateTime)parameter.Value == new DateTime()) { parameter.Value = DBNull.Value; }
                                        break;
                                    case "Guid":
                                        if ((Guid)parameter.Value == Guid.Empty) { parameter.Value = DBNull.Value; }
                                        break;
                                    case "String":
                                        if ((String)parameter.Value == null) { parameter.Value = DBNull.Value; }
                                        break;
                                }

                                break;
                            }
                        }
                    }

                    cmd.Parameters.Add(parameter);
                }

                /*
                bool vl_containsUserId_z = false;
                foreach (SqlParameter vl_sqlParam_o in cmd.Parameters)
                {
                    if (vl_sqlParam_o.ParameterName == "@User_Person_ID_s")
                    {
                        vl_containsUserId_z = true;
                    }
                }

                if (!vl_containsUserId_z)
                {
                    Support_BO vl_support_bo = new Support_BO();
                    SqlParameter vl_UserParameter_o = new SqlParameter();
                    vl_UserParameter_o.ParameterName = "@User_Person_ID_s";
                    vl_UserParameter_o.SqlDbType = SqlDbType.UniqueIdentifier;
                    vl_UserParameter_o.Value = vl_support_bo.getCurrentUser();
                    cmd.Parameters.Add(vl_UserParameter_o);
                }
                */

                // Check for User ID                
                /*
                if (!cmd.Parameters.Contains(vl_UserParameter_o))
                {
                    cmd.Parameters.Add(vl_UserParameter_o);
                }
                */

                // Execute query
                vl_result_i = cmd.ExecuteNonQuery();

                if (vl_result_i != 0)
                {
                    vl_result_z = true;
                }

            }
            catch (Exception vl_error_o)
            {
                //Log error
                //Support_BO.logError(vl_error_o);
                throw (vl_error_o);
            }
            finally
            {
                //Release resources
                vl_sqlCon_o.Close();
            }
            //Return
            return vl_result_z;
        }



        //Insert or update model using reflection and attributes (Use this method if you like to apply transaction scope - Need an open connection)
        public bool InsertOrUpdateGenericModel_TransactionSafe(GenericModel vl_model_o, SQLCommandModel vl_sqlCommand_o, SqlConnection vl_sqlCon_o)
        {
            //Varibale - Declaration
            int vl_result_i = 0;
            bool vl_result_z = false;
            String vl_propertyType_s = "";

            try
            {
                // SP call - Get name and parameters including the type of parameters
                SqlCommand cmd = new SqlCommand(vl_sqlCommand_o.SQL_Name, vl_sqlCon_o);
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (var param in vl_sqlCommand_o.SQL_ParameterList)
                {
                    // Add input parameter and set value for the param.
                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = param.Parameter_Name;
                    parameter.SqlDbType = param.SqlDbType;
                    parameter.Value = param.Parameter_Value;

                    if (vl_model_o != null)
                    {
                        //Get all properties of the model
                        foreach (var prop in vl_model_o.GetType().GetProperties())
                        {
                            //Get name of the Data binder attribute (Example - [DataBinder(DataBinderName = "Per_ID_s")])
                            string value = AttributeExtensions_BO.GetPropertyValue(prop, (DataBinderAttribute a) => a.DataBinderName);

                            //Check to make sure sql parameter name equals to data binder name of the model
                            if (parameter.ParameterName.Equals(string.Concat("@", value)))
                            {
                                //Get value
                                parameter.Value = prop.GetValue(vl_model_o, null);
                                vl_propertyType_s = prop.PropertyType.Name;

                                //Do null checks (against c# types)
                                switch (vl_propertyType_s)
                                {
                                    case "DateTime":
                                        if ((DateTime)parameter.Value == new DateTime()) { parameter.Value = DBNull.Value; }
                                        break;
                                    case "Guid":
                                        if ((Guid)parameter.Value == Guid.Empty) { parameter.Value = DBNull.Value; }
                                        break;
                                    case "String":
                                        if ((String)parameter.Value == null) { parameter.Value = DBNull.Value; }
                                        break;
                                }

                                break;
                            }
                        }
                    }

                    cmd.Parameters.Add(parameter);
                }
                /*
                bool vl_containsUserId_z = false;
                foreach (SqlParameter vl_sqlParam_o in cmd.Parameters)
                {
                    if (vl_sqlParam_o.ParameterName == "@User_Person_ID_s")
                    {
                        vl_containsUserId_z = true;
                    }
                }

                if (!vl_containsUserId_z)
                {
                    Support_BO vl_support_bo = new Support_BO();
                    SqlParameter vl_UserParameter_o = new SqlParameter();
                    vl_UserParameter_o.ParameterName = "@User_Person_ID_s";
                    vl_UserParameter_o.SqlDbType = SqlDbType.UniqueIdentifier;
                    vl_UserParameter_o.Value = vl_support_bo.getCurrentUser();
                    cmd.Parameters.Add(vl_UserParameter_o);
                }
                */

                // Check for User ID                
                /*
                if (!cmd.Parameters.Contains(vl_UserParameter_o))
                {
                    cmd.Parameters.Add(vl_UserParameter_o);
                }
                */

                // Execute query
                vl_result_i = cmd.ExecuteNonQuery();

                if (vl_result_i != 0)
                {
                    vl_result_z = true;
                }

            }
            catch (Exception vl_error_o)
            {
                throw (vl_error_o);
            }

            return vl_result_z;
        }


    }
}