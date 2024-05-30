<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeFile="Page1.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content0" ContentPlaceHolderID="head" Runat="Server">
    <link href="styles/grid.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
<div class="demo-containers" />
       <%-- <telerik:RadWindowManager RenderMode="Lightweight" ID="RadWindowManager1" runat="server" EnableShadow="true">
        </telerik:RadWindowManager>--%>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" ClientEvents-OnRequestStart="onRequestStart" runat="server" CssClass="grid_wrapper">
        <telerik:RadGrid ID="RadGrid1" runat="server" PageSize="10" OnItemDataBound="RadGrid1_ItemDataBound" PagerStyle-PageButtonCount="5"
            OnNeedDataSource="RadGrid1_NeedDataSource" AutoGenerateColumns="true"
            OnUpdateCommand="RadGrid1_UpdateCommand" OnInsertCommand="RadGrid1_InsertCommand" OnDeleteCommand="RadGrid1_DeleteCommand"
            AllowPaging="True" AllowSorting="true" ShowGroupPanel="false" RenderMode="Auto">
            <GroupingSettings ShowUnGroupButton="false" />
            <ExportSettings ExportOnlyData="true" IgnorePaging="true"></ExportSettings>
            <MasterTableView AutoGenerateColumns="False"
                AllowFilteringByColumn="false" TableLayout="Fixed"
                DataKeyNames="ID" CommandItemDisplay="Top"
                InsertItemPageIndexAction="ShowItemOnFirstPage">
                <Columns>
                    <telerik:GridBoundColumn DataField="ID" ReadOnly="true" HeaderText="ID" SortExpression="ID" UniqueName="ID">
                        <HeaderStyle Width="150px" />
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Name" HeaderText="Name" SortExpression="Name" UniqueName="Name" HtmlEncode="true">
                        <HeaderStyle Width="150px" />
                        <ColumnValidationSettings EnableRequiredFieldValidation="true" runat="server" RequiredFieldValidator-Text=" Required"  RequiredFieldValidator-ForeColor="Red" RequiredFieldValidator-BorderColor="Red" />
                    </telerik:GridBoundColumn>
                    <telerik:GridNumericColumn DataField="Age" HeaderText="Age" SortExpression="Age" UniqueName="Age" HtmlEncode="true">
                        <HeaderStyle Width="150px" />
                        <ColumnValidationSettings EnableRequiredFieldValidation="true" runat="server" RequiredFieldValidator-Text=" Required"  RequiredFieldValidator-ForeColor="Red" RequiredFieldValidator-BorderColor="Red" />
                    </telerik:GridNumericColumn>
                    <telerik:GridDropDownColumn HeaderText="Person Type" UniqueName="type" DataField="type" DropDownControlType="RadComboBox">
                        <HeaderStyle Width="150px" />
                        <ColumnValidationSettings EnableRequiredFieldValidation="true" runat="server" RequiredFieldValidator-Text=" Required"  RequiredFieldValidator-ForeColor="Red" RequiredFieldValidator-BorderColor="Red" />
                    </telerik:GridDropDownColumn>
                    <telerik:GridEditCommandColumn UniqueName="EditColumn" HeaderText="Edit">
                        <HeaderStyle Width="70px" />
                    </telerik:GridEditCommandColumn>
                    <telerik:GridButtonColumn CommandName="Delete" Text="Delete" UniqueName="DeleteColumn" HeaderText="Delete">
                        <HeaderStyle Width="70px" />
                    </telerik:GridButtonColumn>
                    <telerik:GridImageColumn UniqueName="Open" ImageUrl="images/Thumbnails/Tulips.jpg" ImageHeight="40px">
                        <HeaderStyle Width="70px" />
                    </telerik:GridImageColumn>
                </Columns>
            </MasterTableView>
            <ClientSettings AllowColumnsReorder="true" AllowColumnHide="true" AllowDragToGroup="true">
                <Selecting CellSelectionMode="SingleCell" />
                <ClientEvents OnCellSelected="cellSelected" />
                <Scrolling AllowScroll="true" UseStaticHeaders="true" />
            </ClientSettings>
        </telerik:RadGrid>
    </telerik:RadAjaxPanel>
    <telerik:RadCodeBlock runat="server">
        <script type="text/javascript">
            function onRequestStart(sender, args) {
                if (args.get_eventTarget().indexOf("Button") >= 0) {
                    args.set_enableAjax(false);
                }
            }

            function cellSelected(sender, args) {
                var selectedColumn = args.get_column();
                var dataItem = args.get_gridDataItem();

                if (selectedColumn.get_uniqueName() === "Open") {
                    let row = args.row[0]
                    let d = row.getElementsByTagName("td")[3]
                    if (d.innerText == 'Teacher') {
                        let name = row.getElementsByTagName("td")[1].innerText;
                        let age = row.getElementsByTagName("td")[2].innerText;
                        let type = d.innerText;
                        window.location = "Page2.aspx?name=" + name + "&age?=" + age + "&type=" + type;
                        //HttpContext.Current.Response.Redirect("https://demos.telerik.com/aspnet-ajax/window/examples/browserdialogboxes/defaultcs.aspx");
                        //radalert('Radalert is called from the client!', 330, 180, 'Client RadAlert', alertCallBackFn, $dialogsDemo.imgUrl)
                    }
                }   
            }

            (function (global, undefined) {
                var demo = {};

                function alertCallBackFn(arg) {
                    radalert();
                }
                Sys.Application.add_load(function () {
                    // attach a handler to radio buttons to update global variable holding image url
                    $telerik.$('input:radio').bind('click', function () {
                        demo.imgUrl = $telerik.$(this).val();
                    });
                });

                global.alertCallBackFn = alertCallBackFn;

                global.$dialogsDemo = demo;
            })(window);


        </script>
    </telerik:RadCodeBlock>
</asp:Content>


