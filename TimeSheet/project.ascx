<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="project.ascx.cs" Inherits="TimeSheet.project" %>


<div class="form-700">
    <div>
        XCode : <br />
        <asp:TextBox ID="txtXCode" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div>
        Project Name : <br />
        <asp:TextBox ID="txtProjectName" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div>
        Description : <br />
        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="6"></asp:TextBox>
    </div>


    <div>
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn" />
        <asp:Button ID="btnDelete" runat="server" CssClass="btn" Text="Delete" OnClientClick="if (!confirm('Are you sure delete?')) return false;" OnClick="btnDelete_Click" Visible="false" />
    </div>
</div>

<div class="form-700">
    <asp:Label ID="lHtm" runat="server"></asp:Label>
</div>