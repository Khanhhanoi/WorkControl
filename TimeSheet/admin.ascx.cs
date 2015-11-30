using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TimeSheet
{
    public partial class admin : DotNetNuke.Entities.Modules.PortalModuleBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lnkProject.NavigateUrl = Utils.LinkUrl(this.TabId, this.ModuleId, "project");
            lnkMember.NavigateUrl = Utils.LinkUrl(this.TabId, this.ModuleId, "member");
        }
    }
}