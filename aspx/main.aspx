<%@ Page Title="" Language="C#" MasterPageFile="~/aspx/site.Master" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="ProjectWebForm.aspx.main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .jumbotron{
            background-image : url('/images/code-944499_1280.jpg');
            color:white;
            margin-top: 30px;
        }
        .container{
            width: inherit;
        }
    </style>


    <section class="container">
        <div class="jumbotron">
            <h1 class="display-4">Hello, world!</h1>
            <p class="lead">This is a simple hero unit, a simple jumbotron-style component for calling extra attention to featured content or information.</p>
            <hr class="my-4">
            <p>It uses utility classes for typography and spacing to space content out within the larger container.</p>
            <a class="btn btn-primary btn-lg" href="#" role="button">Learn more</a>
        </div>
    </section>

</asp:Content>


