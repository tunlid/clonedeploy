﻿<%@ Page Title="" Language="C#" MasterPageFile="~/views/masters/User.master" AutoEventWireup="true" Inherits="views.users.ResetPass" CodeFile="resetpass.aspx.cs" %>

<%@ MasterType VirtualPath="~/views/masters/User.master" %>
<%@ Reference virtualPath="~/views/masters/Site.master" %>

<asp:Content ID="Content" ContentPlaceHolderID="SubContent" runat="Server">
    <h4 style="margin-bottom: 20px;">Change Password</h4>
    <div class="size-4 column">
        New Password:
    </div>
    <div class="size-5 column">
        <asp:TextBox ID="txtUserPwd" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
    </div>
    <br class="clear"/>
    <div class="size-4 column">
        Confirm Password:
    </div>
    <div class="size-5 column">
        <asp:TextBox ID="txtUserPwdConfirm" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
    </div>
    <br class="clear"/>
    <div class="size-4 column">
        &nbsp;
    </div>
    <div class="size-5 column">
        <asp:LinkButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Change Password" CssClass="submits"/>
    </div>
    <br class="clear"/>
</asp:Content>