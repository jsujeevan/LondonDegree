using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using LondonDegree_Web.Models;

namespace LondonDegree_Web.BO
{
    public class Object_BO
    {
        public List<ObjectModel> SearchObject(ObjectModel in_object_o)
        {
            List<ObjectModel> vl_objectList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_Object_ID_s", Parameter_Value = in_object_o.PK_Object_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@Object_s", Parameter_Value = in_object_o.Object_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Object_Controller_s", Parameter_Value = in_object_o.Object_Controller_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Object_Action_s", Parameter_Value = in_object_o.Object_Action_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Object_Label_s", Parameter_Value = in_object_o.Object_Label_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Object_Thumbnail_s", Parameter_Value = in_object_o.Object_Thumbnail_s, SqlDbType = SqlDbType.VarChar },
                new SQLParameterModel { Parameter_Name = "@Object_Order_i", Parameter_Value = in_object_o.Object_Order_i, SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@FK_ObjectType_ID_i", Parameter_Value = in_object_o.FK_ObjectType_ID_i, SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@FK_Object_Parent_ID_s", Parameter_Value = in_object_o.FK_Object_Parent_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier }
            };

            vl_sqlcmd_o.SQL_Name = "Object_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_objectList_o = vl_dataBinder_o.GetGenericModel(typeof(ObjectModel), vl_sqlcmd_o).Cast<ObjectModel>().ToList();
            return vl_objectList_o;
        }

        public List<ObjectPermissionModel> SearchObjectPermission(ObjectPermissionModel in_objectPermission_o)
        {
            List<ObjectPermissionModel> vl_objectPermissionList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_ObjectPermission_ID_s", Parameter_Value = in_objectPermission_o.PK_ObjectPermission_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_Object_ID_s", Parameter_Value = in_objectPermission_o.FK_Object_ID_gu, SqlDbType = SqlDbType.UniqueIdentifier },
                new SQLParameterModel { Parameter_Name = "@FK_ObjectRole_ID_i", Parameter_Value = in_objectPermission_o.FK_ObjectRole_ID_i, SqlDbType = SqlDbType.Int },
            };

            vl_sqlcmd_o.SQL_Name = "ObjectPermission_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_objectPermissionList_o = vl_dataBinder_o.GetGenericModel(typeof(ObjectPermissionModel), vl_sqlcmd_o).Cast<ObjectPermissionModel>().ToList();
            return vl_objectPermissionList_o;
        }

        public List<ObjectRoleModel> SearchObjectRole(ObjectRoleModel in_objectRole_o)
        {
            List<ObjectRoleModel> vl_objectRoleList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {

                new SQLParameterModel { Parameter_Name = "@PK_ObjectRole_ID_i", Parameter_Value = in_objectRole_o.PK_ObjectRole_ID_i, SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@ObjectRole_s", Parameter_Value = in_objectRole_o.ObjectRole_s, SqlDbType = SqlDbType.VarChar },
            };

            vl_sqlcmd_o.SQL_Name = "ObjectRole_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_objectRoleList_o = vl_dataBinder_o.GetGenericModel(typeof(ObjectRoleModel), vl_sqlcmd_o).Cast<ObjectRoleModel>().ToList();
            return vl_objectRoleList_o;
        }

        public List<ObjectTypeModel> SearchObjectRole(ObjectTypeModel in_objectType_o)
        {
            List<ObjectTypeModel> vl_objectTypeList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PK_ObjectType_ID_i", Parameter_Value = in_objectType_o.PK_ObjectType_ID_i, SqlDbType = SqlDbType.Int },
                new SQLParameterModel { Parameter_Name = "@ObjectType_s", Parameter_Value = in_objectType_o.ObjectType_s, SqlDbType = SqlDbType.VarChar },
            };

            vl_sqlcmd_o.SQL_Name = "ObjectType_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_objectTypeList_o = vl_dataBinder_o.GetGenericModel(typeof(ObjectTypeModel), vl_sqlcmd_o).Cast<ObjectTypeModel>().ToList();
            return vl_objectTypeList_o;
        }

        #region Custom Methods

        public List<ObjectModel> SearchObjectMenuItemsByRole(int in_personRole_i)
        {
            List<ObjectModel> vl_objectList_o = null;
            DataBinder_BO vl_dataBinder_o = new DataBinder_BO();
            SQLCommandModel vl_sqlcmd_o = new SQLCommandModel();
            List<SQLParameterModel> vl_paramList = new List<SQLParameterModel>()
            {
                new SQLParameterModel { Parameter_Name = "@PersonRole_ID_i", Parameter_Value = in_personRole_i, SqlDbType = SqlDbType.Int },
            };

            vl_sqlcmd_o.SQL_Name = "Object_ObjectPermission_PersonRole_SELECT";
            vl_sqlcmd_o.SQL_ParameterList = vl_paramList;
            vl_objectList_o = vl_dataBinder_o.GetGenericModel(typeof(ObjectModel), vl_sqlcmd_o).Cast<ObjectModel>().ToList();
            return vl_objectList_o;
        }

        public LinkedList<ObjectModel> GetNavigationMenu(List<ObjectModel> in_objectItems_o)
        {
            /*
                public string Object_Controller_s { get; set; }
                public string Object_Action_s { get; set; }
                public string Object_Label_s { get; set; }
                public string Object_Thumbnail_s { get; set; }
                public LinkedList<NavigationMenuItem> Children { get; set; }
             */
            LinkedList<ObjectModel> vl_menuItems_o = new LinkedList<ObjectModel>();
            List<ObjectModel> in_parentObjectItems_o = in_objectItems_o.Where(m => m.FK_Object_Parent_ID_gu == Guid.Empty).OrderBy(m=>m.Object_Order_i).ToList();
            foreach (ObjectModel in_parentObjectModel_o in in_parentObjectItems_o)
            {
                ObjectModel vl_parent_o =  BuildNavigationMenu(in_parentObjectModel_o, in_objectItems_o);
                vl_menuItems_o.AddLast(vl_parent_o);
            }
            return vl_menuItems_o;
        }

        private ObjectModel BuildNavigationMenu(ObjectModel in_currentItem_o, List<ObjectModel> in_AllObjectItems_o)
        {
            if (in_currentItem_o.Children == null) {
                in_currentItem_o.Children = new LinkedList<ObjectModel>();
            }

            bool vl_itemHasChildren_z = in_AllObjectItems_o.Exists(m => m.FK_Object_Parent_ID_gu == in_currentItem_o.PK_Object_ID_gu);

            if (vl_itemHasChildren_z)
            {
                foreach (ObjectModel in_currentObjectModel_o in in_AllObjectItems_o.Where(m => m.FK_Object_Parent_ID_gu == in_currentItem_o.PK_Object_ID_gu).OrderBy(m => m.Object_Order_i))
                {
                    in_currentItem_o.Children.AddLast(in_currentObjectModel_o);
                    BuildNavigationMenu(in_currentObjectModel_o, in_AllObjectItems_o);
                }
            }
            return in_currentItem_o;
        }

        #endregion

    }
}