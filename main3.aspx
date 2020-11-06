<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main3.aspx.cs" Inherits="ProjectWebForm.main3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link rel="canonical" href="https://getbootstrap.com/docs/4.5/examples/cover/" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/cover.css" rel="stylesheet" />
    <style>
        .bd-placeholder-img {
            font-size: 1.125rem;
            text-anchor: middle;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
        }

        @media (min-width: 768px) {
            .bd-placeholder-img-lg {
                font-size: 3.5rem;
            }
        }
    </style>
</head>

<body class="text-center">
    <div class="cover-container d-flex w-100 h-100 p-3 mx-auto flex-column">
        <header class="masthead mb-auto">
            <div class="inner">
                <h3 class="masthead-brand">Cover</h3>
                <nav class="nav nav-masthead justify-content-center">
                    <a class="nav-link active" href="main2.aspx">Home</a>
                    <a class="nav-link active" href="Board.aspx">Board</a>
                    <a class="nav-link active" href="Company.aspx">Company</a>
                    <asp:LinkButton ID="lbtnlogout" class="nav-link active" runat="server" OnClick="lbtnlogout_Click">Logout</asp:LinkButton>
                </nav>
            </div>
        </header>
    </div>
    <div>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>
</body>
</html>
