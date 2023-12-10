<%@ Page Language="C#" Title="Registration" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="BankApplication1.RegistrationForm" %>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">



<div class="form-group "  style="margin-top: 100px;">
    <h3>WealthWave Bank Registration Form</h3>

</div>
    <div class="container">
        <!-- User Information -->
        <div class="row">
            <div class="col-md-6">
                 <div class="form-group" style="margin-top: 50px;">
                    <label for="firstName">First Name:</label>
                    <asp:TextBox ID="firstName" runat="server" CssClass="form-control" />
                </div>
            </div>
            
            <div class="col-md-6">
                 <div class="form-group" style="margin-top: 50px;">
                    <label for="lastName">Last Name:</label>
                    <asp:TextBox ID="lastName" runat="server" CssClass="form-control" />
                </div>
            </div>
        </div>
        
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="email">Email:</label>
                    <asp:TextBox ID="email" runat="server" TextMode="Email" CssClass="form-control" />
                </div>
            </div>
            
            <div class="col-md-6">
                <div class="form-group">
                    <label for="phone">Phone Number:</label>
                    <asp:TextBox ID="phone" runat="server" TextMode="Phone" CssClass="form-control" />
                </div>
            </div>
        </div>
        
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="sex">Gender:</label>
                    <asp:TextBox ID="sex" runat="server" CssClass="form-control" />
                </div>
            </div>
            
            <div class="col-md-6">
                <div class="form-group">
                    <label for="MaritialStatus">Marital Status:</label>
                    <asp:TextBox ID="MaritialStatus" runat="server" CssClass="form-control" />
                </div>
            </div>
        </div>
        
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="CountryStatus">Country Status:</label>
                    <asp:TextBox ID="CountryStatus" runat="server" CssClass="form-control" />
                </div>
            </div>
            
            <div class="col-md-6">
                <div class="form-group">
                    <label for="Address">Address:</label>
                    <asp:TextBox ID="Address" runat="server" CssClass="form-control" />
                </div>
            </div>
        </div>
        
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="DateOfBirth">Date Of Birth:</label>
                    <asp:TextBox ID="DateOfBirth" runat="server" TextMode="Date" CssClass="form-control" />
                </div>
            </div>
            
            <div class="col-md-6">
                <div class="form-group">
                    <label for="sinNumber">SinNumber:</label>
                    <asp:TextBox ID="sinNumber" runat="server" CssClass="form-control" />
                </div>
            </div>
        </div>

        <!-- Additional User Information -->
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="username">Username:</label>
                    <asp:TextBox ID="username" runat="server" CssClass="form-control" />
                </div>
            </div>

            <div class="col-md-6">
                <div class="form-group">
                    <label for="password">Password:</label>
                    <asp:TextBox ID="password" runat="server" TextMode="Password" CssClass="form-control" />
                </div>
            </div>
        </div>
        
        <!-- Terms and Conditions -->
       <div class="form-group" style="margin-bottom: 50px; margin-top: 50px;">
            <input type="checkbox" id="agreeToTerms" name="agreeToTerms" required />
            <label for="agreeToTerms">I agree to the terms and conditions </label>
        </div>
        
        <!-- Submit Button -->
        <div class="form-group" style="margin-top: 50px;">
            <asp:Button Text="Register" runat="server" class="btn btn-primary" style="background-color: darkblue; font-family: 'Times New Roman', Times, serif; font-weight: bold; font-size: 16px; color: white;" OnClick="RegisterButton_Click" />
        </div>

        <!--lbel for Error message-->
        <div>
            <asp:Label ID="ShowErrorMessage" runat="server" ForeColor="Red" Text=""></asp:Label>

        </div>

    </div>
</asp:Content>

