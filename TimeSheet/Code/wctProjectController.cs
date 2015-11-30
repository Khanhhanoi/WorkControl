//---------------------------------------------------------------------------
// Author : AWAS JSC
// Created Date : Sunday, November 29, 2015
//---------------------------------------------------------------------------


using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
namespace TimeSheet
{
    public class wctProjectController
    {
        #region Constructor
        public wctProjectController() { }
        #endregion

        #region Function
        private const string INSERT_WCTPROJECT = "INSERT INTO wctProject (XCode, ProjectName, Description) "
         + " VALUES (@XCode, @ProjectName, @Description)";
        public int Insert(wctProjectInfo mywctProject)
        {
            int result = 0;
            try
            {
                ArrayList param = new ArrayList();
                param.Add(new SqlParameter("@XCode", mywctProject.XCode));
                param.Add(new SqlParameter("@ProjectName", mywctProject.ProjectName));
                param.Add(new SqlParameter("@Description", mywctProject.Description));
                result = DataFactory.Execute(INSERT_WCTPROJECT, param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        private const string UPDATE_WCTPROJECT = "UPDATE wctProject SET "
             + " XCode = @XCode, "
             + " ProjectName = @ProjectName, "
             + " Description = @Description "
             + " WHERE (ID = @ID)";
        public int Update(wctProjectInfo mywctProject)
        {
            int result = 0;
            try
            {
                ArrayList param = new ArrayList();
                param.Add(new SqlParameter("@XCode", mywctProject.XCode));
                param.Add(new SqlParameter("@ProjectName", mywctProject.ProjectName));
                param.Add(new SqlParameter("@Description", mywctProject.Description));
                param.Add(new SqlParameter("@ID", mywctProject.ID));
                result = DataFactory.Execute(UPDATE_WCTPROJECT, param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        private const string DELETE_WCTPROJECT = "DELETE FROM wctProject WHERE (ID = @ID)";
        public int Delete(int ID)
        {
            int result = 0;
            try
            {
                ArrayList param = new ArrayList();
                param.Add(new SqlParameter("@ID", ID));
                result = DataFactory.Execute(DELETE_WCTPROJECT, param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public wctProjectInfo Converting(DataRow drwctProject)
        {
            wctProjectInfo result = null;
            try
            {
                result = new wctProjectInfo();
                if (drwctProject["ID"] != DBNull.Value)
                    result.ID = Convert.ToInt32(drwctProject["ID"]);
                if (drwctProject["XCode"] != DBNull.Value)
                    result.XCode = Convert.ToString(drwctProject["XCode"]);
                if (drwctProject["ProjectName"] != DBNull.Value)
                    result.ProjectName = Convert.ToString(drwctProject["ProjectName"]);
                if (drwctProject["Description"] != DBNull.Value)
                    result.Description = Convert.ToString(drwctProject["Description"]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        private const string LOAD_WCTPROJECT = "SELECT * FROM wctProject WHERE (ID = @ID)";
        public wctProjectInfo Load(int ID)
        {
            wctProjectInfo result = null;
            try
            {
                ArrayList param = new ArrayList();
                param.Add(new SqlParameter("@ID", ID));
                DataTable dt = DataFactory.SelectTable(LOAD_WCTPROJECT, param);
                if (dt.Rows.Count > 0) result = Converting(dt.Rows[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        #endregion

    }
}
