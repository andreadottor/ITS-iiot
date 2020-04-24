using Dottor.Earthquake.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dottor.Earthquake
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            lblResult.Text = "";
        }

        private void btnGetEarthquake_Click(object sender, EventArgs e)
        {
            // 1_ HttpWebRequest / HttpWebResponse
            // 2_ WebClient
            // 3_ HttpClient

            // Task, async, await

            var client = new WebClient();
            // GET
            var result = client.DownloadString("https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/2.5_day.geojson");

            var list = JsonConvert.DeserializeObject<EarthquakesGeoJsonResponse>(result);

            foreach (var item in list.Earthquakes)
            {
                System.Diagnostics.Debug.WriteLine(item.Properties.Place);
            }
            txtEarthquakeCount.Text = list.Earthquakes.Length.ToString();
            //txtEarthquakeCount.Text = list.Metadata.Count.ToString();
            
            grid.DataSource = list.Earthquakes;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            var user = new User
            {
                Name = txtName.Text,
                Surname = txtSurname.Text
            };
            // serializzo i dati in JSON
            var jsonData = JsonConvert.SerializeObject(user);
            var client = new WebClient();
            // POST
            client.UploadString("http://localhost:3000/users", "POST", jsonData);
            txtName.Name = "";
            txtSurname.Name = "";
            lblResult.Text = "caricamento eseguito con successo";
        }
    }
}
