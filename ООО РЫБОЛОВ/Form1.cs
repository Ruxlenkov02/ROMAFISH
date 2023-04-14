using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace ООО_РЫБОЛОВ
{
    public partial class Form1 : Form
    {
        List<string[]> list = new List<string[]>();
        public Form1()
        {
            InitializeComponent();
        }
        int a = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string qwery = $"select * from [User] where password='{textBox2.Text}' and login='{textBox1.Text}'";
            SqlConnection bd = new SqlConnection(@"Data Source=DESKTOP-UR3TSU2\SQLEXPRESS;Initial Catalog=User02; Integrated Security=True;");
            bd.Open();
            SqlCommand Avtorizacia = new SqlCommand(qwery, bd);

            SqlDataReader izvlech = Avtorizacia.ExecuteReader();
            if (izvlech.Read())
            {
                a++;
            }
            if (a >= 1)
            {
                Form2 perexod = new Form2(); 
                perexod.ShowDialog();
                this.Hide();
            }
            bd.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }

