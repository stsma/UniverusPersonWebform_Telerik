<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeFile="Page2.aspx.cs" Inherits="Grid" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="styles/grid.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadSkinManager ID="RadSkinManager1" runat="server" ShowChooser="true" />
    <div class="demo-container size-wide">
        <telerik:RadHtmlChart runat="server" ID="AreaChart" Width="800" Height="500" Skin="Silk">
            <PlotArea>
                <Series>
                    <telerik:AreaSeries Name="No. of Students with same age">
                        <LabelsAppearance Visible="false"></LabelsAppearance>
                        <LineAppearance Width="3"></LineAppearance>
                        <MarkersAppearance MarkersType="Circle" BackgroundColor="White" Size="6" BorderColor="Blue"
                            BorderWidth="2"></MarkersAppearance>
                        <TooltipsAppearance Color="White"></TooltipsAppearance>
                    </telerik:AreaSeries>
                </Series>
                <Appearance>
                    <FillStyle BackgroundColor="Transparent"></FillStyle>
                </Appearance>
                <YAxis AxisCrossingValue="0" Color="black" MajorTickSize="4" MajorTickType="Outside"
                    MaxValue="1400" MinorTickType="None" MinValue="0" Reversed="false"
                    Step="200">
                    <LabelsAppearance DataFormatString="{0}" RotationAngle="0" Skip="0" Step="1">
                    </LabelsAppearance>
                    <TitleAppearance RotationAngle="0" Position="Center" Text="Age"></TitleAppearance>
                </YAxis>
            </PlotArea>
            <Appearance>
                <FillStyle BackgroundColor="Transparent"></FillStyle>
            </Appearance>
            <ChartTitle Text="Age VS Students Comparison">
                <Appearance Align="Center" BackgroundColor="Transparent" Position="Top">
                </Appearance>
            </ChartTitle>
            <Legend>
                <Appearance BackgroundColor="Transparent" Position="Bottom">
                </Appearance>   
            </Legend>
        </telerik:RadHtmlChart>
    </div>
    <br />
    <br />
    <telerik:RadAjaxLoadingPanel runat="server" ID="RadAjaxLoadingPanel1" Skin="Silk">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="Configuratorpanel1">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="AreaChart" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <ConfiguratorPanel ID="Configuratorpanel1" runat="server">
        <Views>
            <View>
            </View>
        </Views>
    </ConfiguratorPanel>


</asp:Content>


