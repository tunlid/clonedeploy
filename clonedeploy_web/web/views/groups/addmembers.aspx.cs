﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI.WebControls;
using BasePages;
using Helpers;
using Models;

public partial class views_groups_addmembers : Groups
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) return;
        if (Settings.DefaultHostView == "all")
            PopulateGrid();
    }

    protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
    {
        ChkAll(gvHosts);
    }

    

    protected void gridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        PopulateGrid();
        List<Computer> listHosts = (List<Computer>)gvHosts.DataSource;
        switch (e.SortExpression)
        {
            case "Name":
                listHosts = GetSortDirection(e.SortExpression) == "Asc" ? listHosts.OrderBy(h => h.Name).ToList() : listHosts.OrderByDescending(h => h.Name).ToList();
                break;
            case "Mac":
                listHosts = GetSortDirection(e.SortExpression) == "Asc" ? listHosts.OrderBy(h => h.Mac).ToList() : listHosts.OrderByDescending(h => h.Mac).ToList();
                break;
          
        }


        gvHosts.DataSource = listHosts;
        gvHosts.DataBind();
    }

    protected void PopulateGrid()
    {
      
        var listOfComputers = BLL.Computer.SearchComputersForUser(CloneDeployCurrentUser.Id, txtSearch.Text);
        listOfComputers.AddRange(BLL.Computer.ComputersWithoutGroup());
      
        gvHosts.DataSource = listOfComputers.GroupBy(c => c.Id).Select(g => g.First()).ToList(); ;
        gvHosts.DataBind();

        lblTotal.Text = gvHosts.Rows.Count + " Result(s) / " + BLL.Computer.TotalCount() + " Total Host(s)";
    }

    protected void search_Changed(object sender, EventArgs e)
    {
        PopulateGrid();
    }

   

    protected void btnAddSelected_OnClick(object sender, EventArgs e)
    {
        var memberships = (from GridViewRow row in gvHosts.Rows
            let cb = (CheckBox) row.FindControl("chkSelector")
            where cb != null && cb.Checked
            select gvHosts.DataKeys[row.RowIndex]
            into dataKey
            where dataKey != null
            select new Models.GroupMembership
            {
                ComputerId = Convert.ToInt32(dataKey.Value), GroupId = Group.Id
            }).ToList();
        EndUserMessage = BLL.GroupMembership.AddMembership(memberships) ? "Successfully Added Group Members" : "Could Not Add Group Members";
    }
}