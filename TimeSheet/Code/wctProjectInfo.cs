//---------------------------------------------------------------------------
// Author : AWAS JSC
// Created Date : Sunday, November 29, 2015
//---------------------------------------------------------------------------


using System;

namespace TimeSheet
{
    public class wctProjectInfo
    {
        #region Constructor
        public wctProjectInfo()
        {

        }

        #endregion

        #region Vars
        private int _ID = 0;
        private string _XCode = "";
        private string _ProjectName = "";
        private string _Description = "";
        #endregion

        #region Property
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string XCode
        {
            get { return _XCode; }
            set { _XCode = value; }
        }
        public string ProjectName
        {
            get { return _ProjectName; }
            set { _ProjectName = value; }
        }
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        #endregion

    }
}
