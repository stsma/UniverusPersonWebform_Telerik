using DotNet.Highcharts;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.HtmlChart.Enums;
using Telerik.Web.UI.HtmlChart;
//using Telerik.Web.UI;

public partial class Grid : System.Web.UI.Page
{
    protected void Page_Load(object sender, System.EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            HttpResponseMessage response = sharedClient.GetAsync("m4ur1c1o86/codetest/persons").Result;
            if (response.IsSuccessStatusCode)
            {
                // Get the response
                var peopleJsonString = response.Content.ReadAsStringAsync().Result;
                personResponse = JsonConvert.DeserializeObject<List<PersonApi>>(peopleJsonString);
            }
        ApplyConfiguratorsValues();
        }

    }

    public List<PersonApi> personResponse { get; set; }

    private void ApplyConfiguratorsValues()
    {
        var grp = personResponse.GroupBy(g => g.Age);

        AreaSeries areaSeries = AreaChart.PlotArea.Series[0] as AreaSeries;

        if (areaSeries != null)
        {
            areaSeries.SeriesItems.Clear();
            var s = personResponse.Select(p => (int)p.Age);

            var sersiess = new List<CategorySeriesItem>();
            var axess = new List<AxisItem>();
            foreach (var item in grp)
            {
                sersiess.Add(new CategorySeriesItem()
                {
                    Y = item.Key,
                    BackgroundColor = System.Drawing.Color.DarkBlue
                });

                axess.Add(new AxisItem()
                {
                    LabelText = item.Count().ToString()
                });
            }

            areaSeries.SeriesItems.AddRange(sersiess);
            AreaChart.PlotArea.XAxis.Items.AddRange(axess);
            AreaChart.PlotArea.YAxis.MinValue = 0;
            AreaChart.PlotArea.YAxis.MaxValue = sersiess.Max(x => x.Y) + 10;
            AreaChart.PlotArea.YAxis.Step = 5;
            
        }
    }

    private static System.Net.Http.HttpClient sharedClient = new System.Net.Http.HttpClient()
    {
        BaseAddress = new Uri("https://my-json-server.typicode.com"),
    };

}

public class PersonApi
{
    [JsonProperty("ID")]
    public long Id { get; set; }

    [JsonProperty("Name")]
    public string Name { get; set; }

    [JsonProperty("Age")]
    public long Age { get; set; }

    [JsonProperty("PersonTypeID")]
    public long PersonTypeId { get; set; }
}
