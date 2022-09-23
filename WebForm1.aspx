<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="crudoperation.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <asp:TextBox ID="txtrollno" runat="server"></asp:TextBox>
                                    <asp:TextBox ID="txtcontact" runat="server"></asp:TextBox>
            <asp:RadioButtonList ID="rblgender" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                <asp:ListItem Text="FeMale" Value="2"></asp:ListItem>

            </asp:RadioButtonList>

            <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"></asp:DropDownList>

            <asp:DropDownList ID="ddlstate" runat="server"></asp:DropDownList>

            <asp:Button ID="btnSave" runat="server" Text="Submit" OnClick="btnSave_Click" />




            <br />
            <br />
            <br />
            <hr />


            <asp:GridView ID="grdStudent" runat="server" AutoGenerateColumns="false" OnRowCommand="grdStudent_RowCommand" >
                <Columns>
                    <asp:TemplateField HeaderText="Student Name" >
                        <ItemTemplate>
                           <%#Eval("StuName") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Roll No">
                        <ItemTemplate>
                           <%#Eval("RollNo") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Mobile">
                        <ItemTemplate>
                           <%#Eval("contacno") %>
                        </ItemTemplate>
                    </asp:TemplateField>


                      <asp:TemplateField HeaderText="Gender">
                        <ItemTemplate>

                            <asp:Label ID="lblgender" runat="server" Text='<%#Eval("gender").Equals(1) ? "Male" : "Female" %>'></asp:Label>

                           
                        </ItemTemplate>
                    </asp:TemplateField>


                      <asp:TemplateField HeaderText="Country">
                        <ItemTemplate>
                           <%#Eval("cname") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                       <asp:TemplateField HeaderText="State">
                        <ItemTemplate>
                           <%#Eval("sname") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    
                       <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                           <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditRecord"  Text="Edit" CommandArgument='<%#Eval("StuId") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>


            </asp:GridView>





        </div>
    </form>
</body>
</html>
