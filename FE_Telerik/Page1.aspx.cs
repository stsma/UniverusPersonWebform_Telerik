using Newtonsoft.Json;
using Polly;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Windows.Documents.Spreadsheet.Expressions.Functions;

public partial class _Default : System.Web.UI.Page
{
    public DataTable Sellers { get; set; }

    private static HttpClient sharedClient = new HttpClient()
    {
        BaseAddress = new Uri("https://localhost:7066/"),
    };


    private PersonTypes rawPersonTypes = new PersonTypes();
    public async Task<DataTable> GetPeople()
    {
        var retry = Policy
            .Handle<Exception>()
            .WaitAndRetryAsync(3, _ => TimeSpan.FromSeconds(3));

        var timeout = Policy.TimeoutAsync(TimeSpan.FromSeconds(3));
        var policy = Policy.WrapAsync(retry, timeout);

        var rawPeople = new People();
        await policy.ExecuteAsync(async () =>
        {
            HttpResponseMessage response = sharedClient.GetAsync("api/Person/GetAll").Result;
            if (response.IsSuccessStatusCode)
            {
                // Get the response
                var peopleJsonString = await response.Content.ReadAsStringAsync();
                rawPeople = JsonConvert.DeserializeObject<People>(peopleJsonString);
            }

            HttpResponseMessage typeResponse = sharedClient.GetAsync("api/PersonType/GetAll").Result;
            if (typeResponse.IsSuccessStatusCode)
            {
                // Get the response
                var personTypeJsonString = await typeResponse.Content.ReadAsStringAsync();
                rawPersonTypes = JsonConvert.DeserializeObject<PersonTypes>(personTypeJsonString);
            }
        });

        DataTable dataTable = new DataTable();
        dataTable.Columns.Add("ID", typeof(int));
        dataTable.Columns.Add("Name", typeof(string));
        dataTable.Columns.Add("Age", typeof(int));
        dataTable.Columns.Add("Type", typeof(int));

        DataColumn[] keyColumns = new DataColumn[1];
        keyColumns[0] = dataTable.Columns["ID"];
        dataTable.PrimaryKey = keyColumns;


        foreach (var item in rawPeople.people)
        {
            dataTable.Rows.Add(item.id, item.name, item.age, item.type);
        }

        return dataTable;
    }

    protected void RadGrid1_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
    {
        RadGrid1.DataSource = GetPeople().Result;
    }

    protected void RadGrid1_UpdateCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
        Hashtable table = new Hashtable();
        (e.Item as GridEditableItem).ExtractValues(table);

        DataRow row = GetPeople().Result.Rows.Find((e.Item as GridEditableItem).GetDataKeyValue("ID"));

        var p = new Person();
        foreach (string key in table.Keys)
        {
            row[key] = table[key];

            p.id = (int)row["id"];

            switch (key)
            {
                case "type":
                    p.type = int.Parse(table[key].ToString()); break;
                case "Name":
                    p.name = (string)table[key]; break;
                case "Age":
                    p.age = int.Parse(table[key].ToString()); break;
            }
        }

        if (p.id > 0)
        {
            var person = CallUpdatePerson(p);

            RadGrid1.DataBind();
        }
    }

    private Person CallUpdatePerson(Person p)
    {
        var person = new Person();
        var response = sharedClient.PutAsJsonAsync("api/person/update", new { Person = p }).Result;
        if (response.IsSuccessStatusCode)
        {
            // Get the response
            var personJsonString = response.Content.ReadAsStringAsync().Result;
            person = JsonConvert.DeserializeObject<Person>(personJsonString);
        }

        return person;
    }

    protected void RadGrid1_InsertCommand(object sender, GridCommandEventArgs e)
    {
        Hashtable table = new Hashtable();
        (e.Item as GridEditableItem).ExtractValues(table);
        var tb = GetPeople().Result;
        DataRow row = tb.NewRow();

        var person = new Person();
        foreach (string key in table.Keys)
        {
            if (table[key] != null)
            {
                row[key] = table[key];
            }
        }
        int id = tb.Rows.Count + 1;
        row["ID"] = id;
        person.id = id;
        person.age = int.Parse(row["Age"].ToString());
        person.name = row["Name"].ToString();
        person.type = int.Parse(row["type"].ToString());

        AddNewPerson(person);

        tb.Rows.InsertAt(row, 0);
        RadGrid1.DataBind();
    }

    private Person AddNewPerson(Person person)
    {
        var response = sharedClient.PostAsJsonAsync("api/person/Add", new { Person = person }).Result;
        if (response.IsSuccessStatusCode)
        {
            // Get the response
            var personJsonString = response.Content.ReadAsStringAsync().Result;
            person = JsonConvert.DeserializeObject<Person>(personJsonString);
        }

        return person;
    }

    protected void RadGrid1_DeleteCommand(object sender, GridCommandEventArgs e)
    {
        Hashtable table = new Hashtable();
        (e.Item as GridEditableItem).ExtractValues(table);

        var row = GetPeople().Result.Rows.Find((e.Item as GridEditableItem).RowIndex);

        var person = GetPeople().Result.Rows.Find((e.Item as GridEditableItem).GetDataKeyValue("ID"));

        DataTable tb = GetPeople().Result;
        RadGrid1.DataBind();

        tb.Rows.RemoveAt(e.Item.ItemIndex);

        if (DeleteItem(int.Parse(person["ID"].ToString())))
            RadGrid1.DataBind();
    }

    private bool DeleteItem(int id)
    {
        var response = sharedClient.DeleteAsync("api/Person/delete?id=" + id).Result;
        return response.IsSuccessStatusCode;
    }

    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item is GridEditableItem && e.Item.IsInEditMode)
        {
            GridEditableItem editedItem = e.Item as GridEditableItem;
            GridEditManager editMan = editedItem.EditManager;
            GridDropDownListColumnEditor editor = (GridDropDownListColumnEditor)(editMan.GetColumnEditor("type"));
            var ddList = editor.ComboBoxControl;

            if (ddList != null)
            {
                ddList.DataSource = rawPersonTypes.personTypes;
                ddList.DataTextField = "description";
                ddList.DataValueField = "id";
                if ((e.Item.DataItem as DataRowView) == null)
                {
                    e.Item.DataItem = ddList;
                    ddList.DataBind();
                    return;
                };
                DataRowView row = (DataRowView)e.Item.DataItem;

                var id = (int)row["type"];
                ddList.SelectedIndex = id - 1;

                ddList.DataBind();
            }
        }

        if (e.Item is GridDataItem)
        {
            GridDataItem item = (GridDataItem)e.Item;
            DataRowView row = (DataRowView)e.Item.DataItem;

            var rawP = rawPersonTypes.personTypes.Where(p => p.id == (int)row["type"]).FirstOrDefault();

            if (rawP != null)
            {
                item["Type"].Text = rawP.description;
                var id = (int)row["type"];

                if (id != 1)
                {
                    var openBtn = item["Open"];
                    openBtn.Visible = false;
                }
            }
        }
    }
}