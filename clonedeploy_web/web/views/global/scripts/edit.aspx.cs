﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Global;
using Models;
using Image = Models.Image;

public partial class views_admin_scripts_edit : System.Web.UI.Page
{
    public Script Script { get { return ReadProfile(); } }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) PopulateForm();
    }

    protected void btnSubmit_OnClick(object sender, EventArgs e)
    {
        var script = new Script
        {
            Id = Script.Id,
            Name = txtScriptName.Text,
            Priority = Convert.ToInt32(txtPriority.Text),
            Description = txtScriptDesc.Text
        };
        var fixedLineEnding = scriptEditor.Value.Replace("\r\n", "\n");
        script.Contents = fixedLineEnding;
        new BLL.Script().UpdateScript(script);
        new Utility().Msgbox(Utility.Message);
    }

    protected void PopulateForm()
    {
        txtScriptName.Text = Script.Name;
        txtPriority.Text = Script.Priority.ToString();
        txtScriptDesc.Text = Script.Description;
        scriptEditor.Value = Script.Contents;
    }

    private Script ReadProfile()
    {
        return new BLL.Script().GetScript(Convert.ToInt32(Request.QueryString["scriptid"]));

    }
}