using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestfulAPI
{
    public partial class Form1 : Form
    {
        private List<Class1> categories;
        private int nextOne = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private  void button1_Click(object sender, EventArgs e)
        {
            
            if (nextOne< categories.Count)
            {
                label1.Text = nextOne.ToString();
                pictureBox1.Image = Utils.byteToImg(categories[nextOne].category_image);
                pictureBox2.Image = Utils.byteToImg(categories[nextOne].category_image);
                nextOne++;
            }
            else
            {
                nextOne = 0;

            }
       
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Utils.BASE_URL);
            HttpResponseMessage responseMessage = await client.GetAsync("categories?token_id=464685648465A468464qw8A544688648W6REEWT6V");

            string result = await responseMessage.Content.ReadAsStringAsync();
            categories = JsonConvert.DeserializeObject<List<Class1>>(result);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
         
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
          
        }
    }
}
