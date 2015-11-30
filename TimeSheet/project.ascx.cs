using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace TimeSheet
{
    public partial class project :  DotNetNuke.Entities.Modules.PortalModuleBase
    {
        private void LoadData()
        {
            string strSQL = @"SELECT     ID, XCode, ProjectName, Description
                            FROM         wctProject";
            DataTable dt = DataFactory.SelectTable(strSQL);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<list></list>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                XmlElement el = doc.CreateElement("item");
                doc.DocumentElement.AppendChild(el);
                Utils.AddNode(doc, el, "ID", dt.Rows[i]["ID"].ToString());
                Utils.AddNode(doc, el, "XCode", dt.Rows[i]["XCode"].ToString());
                Utils.AddNode(doc, el, "ProjectName", dt.Rows[i]["ProjectName"].ToString());
                Utils.AddNode(doc, el, "Description", dt.Rows[i]["Description"].ToString());

                string link = Utils.LinkUrl(this.TabId, this.ModuleId, "project", Convert.ToInt32(dt.Rows[i]["ID"]));
                Utils.AddNode(doc, el, "link", link);
            }
            lHtm.Text = Utils.Transform("/DesktopModules/TimeSheet/project.xslt", doc);
        }

        private void LoadInfo()
        {
            if (Request.QueryString["id"] != null)
            {
                wctProjectController db = new wctProjectController();
                wctProjectInfo inf = db.Load(Convert.ToInt32(Request.QueryString["id"]));

                txtDescription.Text = inf.Description;
                txtProjectName.Text = inf.ProjectName;
                txtXCode.Text = inf.XCode;

                btnDelete.Visible = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    LoadInfo();
                }
                this.Page.Header.Controls.Add(new LiteralControl(@"<link href='/DesktopModules/TimeSheet/workcontrolstyle.css' media='screen' type='text/css' rel='stylesheet' />"));
                LoadData();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            wctProjectInfo inf = new wctProjectInfo();
            inf.Description = txtDescription.Text.Trim();
            inf.ProjectName = txtProjectName.Text.Trim();
            inf.XCode = txtXCode.Text.Trim();

            wctProjectController db = new wctProjectController();
            if (Request.QueryString["id"] == null)
            {
                db.Insert(inf);
            }
            else
            {
                inf.ID = Convert.ToInt32(Request.QueryString["id"]);
                db.Update(inf);
            }

            string return_url = Utils.LinkUrl(this.TabId, this.ModuleId, "project");
            Response.Redirect(return_url);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            wctProjectController db = new wctProjectController();
            int _ID = Convert.ToInt32(Request.QueryString["id"]);
            db.Delete(_ID);
            string return_url = Utils.LinkUrl(this.TabId, this.ModuleId, "project");
            Response.Redirect(return_url);
        }
    }
}