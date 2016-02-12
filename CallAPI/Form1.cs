using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using MobileBO;

namespace CallAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAllProducts();
        }

        private async void GetAllProducts()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:3199/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP POST
                ChartRequest Data = new ChartRequest { ChartId = 1, FilterDetails = new List<FilterData> { new FilterData { FilterId = 1, SelectedFilterIDs = new List<int>(new int[] { 1, 2, 3 }) } } };
                var response = await client.PostAsJsonAsync("getFilteredChart/Data", Data);
                if (response.IsSuccessStatusCode)
                {
                    var productJsonString = await response.Content.ReadAsStringAsync();
                    // MobileBO.Chart c = JsonConvert.DeserializeObject<MobileBO.Chart>(productJsonString);

                    richTextBox1.Text = JsonConvert.DeserializeObject(productJsonString).ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetChart(1);
            //GetChart/{ID}
        }
        public async void GetChart(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:3199/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync("GetChart/"+id.ToString());
                if (response.IsSuccessStatusCode)
                {
                    var productJsonString = await response.Content.ReadAsStringAsync();
                    // MobileBO.Chart c = JsonConvert.DeserializeObject<MobileBO.Chart>(productJsonString);

                    richTextBox2.Text = JsonConvert.DeserializeObject(productJsonString).ToString();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Init();
        }

        public async void Init()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:3199/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync("Init");
                if (response.IsSuccessStatusCode)
                {
                    var productJsonString = await response.Content.ReadAsStringAsync();
                    // MobileBO.Chart c = JsonConvert.DeserializeObject<MobileBO.Chart>(productJsonString);

                    richTextBox3.Text = JsonConvert.DeserializeObject(productJsonString).ToString();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GetChart(112);
        }
    }
}
