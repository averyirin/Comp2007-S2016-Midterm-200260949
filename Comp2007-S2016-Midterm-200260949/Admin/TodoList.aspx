<%@ Page Title="Todo List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="Comp2007_S2016_Midterm_200260949.TodoList" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                <h1>Todo List</h1>
                <!--Add Student Button-->
                <a href="/Admin/TodoDetails.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus"></i> Add Todo</a>
                <!--Pagination 4 Bonus Marks -->
                 <div>
                    <label for="TodoSizeDropDownList">Records per Page: </label>
                    <asp:DropDownList ID="TodoSizeDropDownList" runat="server"
                        AutoPostBack="true" CssClass="btn btn-default bt-sm dropdown-toggle"
                        OnSelectedIndexChanged="TodoSizeDropDownList_SelectedIndexChanged">
                        <asp:ListItem Text="3" Value="3" />
                        <asp:ListItem Text="5" Value="5" />
                        <asp:ListItem Text="10" Value="10" />
                        <asp:ListItem Text="All" Value="10000" />
                    </asp:DropDownList>
                </div>
                
                <!--Count Display 2 Bonus Marks -->
                <h3>
                    
                    <label for="TodoCount">Total todo: </label>
                    <asp:Label runat="server" ID="TodoCount" CssClass="label label-default">5</asp:Label>
                </h3>
                <!--Sorting 4 Bonus Marks -->                
                <!-- Grid View-->
                <asp:GridView runat="server"
                    CssClass="table table-bordered table-striped table-hover"
                    ID="TodoGridView" AutoGenerateColumns="false" DataKeyNames="TodoID"
                     OnRowDeleting="TodoGridView_RowDeleting" AllowPaging="true" PageSize="3" OnPageIndexChanging="TodoGridView_PageIndexChanging" AllowSorting="true"
                     OnSorting="TodoGridView_Sorting" OnRowDataBound="TodoGridView_RowDataBound" PagerStyle-CssClass="pagination-ys"
                    >
                    <Columns>
                        <asp:BoundField DataField="TodoName" HeaderText="Todo" Visible="true" SortExpression="TodoName"/>
                        <asp:BoundField DataField="TodoNotes" HeaderText="Notes" Visible="true" SortExpression="TodoNotes"/>
                        <asp:CheckBoxField DataField="Completed" HeaderText="Completed" Visible="true" SortExpression="Completed"/>
                        
                        <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'></i> Edit" 
                            NavigateUrl="~/Admin/TodoDetails.aspx.cs" ControlStyle-CssClass="btn btn-primary btn-sm" runat="server"
                            DataNavigateUrlFields="TodoID" DataNavigateUrlFormatString="TodoDetails.aspx?TodoID={0}" />
                        <asp:CommandField  HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete"
                            ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>

    </div>
</asp:Content>
