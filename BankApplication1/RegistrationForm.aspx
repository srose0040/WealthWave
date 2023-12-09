﻿<%@ Page Language="C#" Title="Registration" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="BankApplication1.RegistrationForm" %>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <!-- User Information -->
    <div class="form-group">
        <label for="firstName">First Name:</label>
        <input type="text" id="firstName" name="firstName" class="form-control" required />
    </div>
    
    <div class="form-group">
        <label for="lastName">Last Name:</label>
        <input type="text" id="lastName" name="lastName" class="form-control" required />
    </div>
    
    <div class="form-group">
        <label for="email">Email:</label>
        <input type="email" id="email" name="email" class="form-control" required />
    </div>
    
    <!-- Additional User Information we can add like username, password, confirm password stuffs here-->
    <!-- Optional Information -->
    <div class="form-group">
        <label for="phone">Phone Number:</label>
        <input type="tel" id="phone" name="phone" class="form-control" />
    </div>
    
    <!-- Terms and Conditions -->
    <div class="form-group">
        <input type="checkbox" id="agreeToTerms" name="agreeToTerms" required />
        <label for="agreeToTerms">I agree to the terms and conditions</label>
    </div>
    
    <!-- Submit Button -->
    <asp:Button Text="Register" runat="server" class="btn btn-primary" style="background-color: darkblue; font-family: 'Times New Roman', Times, serif; font-weight: bold; font-size: 16px; color: white;" OnClick="RegisterButton_Click" />

</asp:Content>