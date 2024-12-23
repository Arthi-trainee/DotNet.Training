<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productDetails.aspx.cs" Inherits="Assessment_1.productDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Display</title>
    <style>
        .product-image {
            width: 300px;
            height: 300px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Product Selection</h1>
            
            <!-- Dropdown for Products -->
            <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">
                <asp:ListItem Text="Select a product" Value="0" />
                <asp:ListItem Text="Product 1" Value="1" />
                <asp:ListItem Text="Product 2" Value="2" />
                <asp:ListItem Text="Product 3" Value="3" />
                <asp:ListItem Text="Product 4" Value="4" />
            </asp:DropDownList>
 
            <br /><br />
 
            <!-- Image control to display the product image -->
            <asp:Image ID="imgProduct" runat="server" CssClass="product-image" Visible="false" />
 
            <br /><br />
 
            <!-- Button to fetch the price -->
            <asp:Button ID="btnGetPrice" runat="server" Text="Get Price" OnClick="btnGetPrice_Click" />
            
            <br /><br />
            
            <!-- Label to display the price -->
            <asp:Label ID="lblPrice" runat="server" Text="Price: $" Visible="false" />
        </div>
    </form>
</body>
</html>
