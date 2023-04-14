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

namespace ООО_РЫБОЛОВ
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-UR3TSU2\SQLEXPRESS;Initial Catalog=User02; Integrated Security=True;";
            SqlConnection db = new SqlConnection(connectionString);
            string a;
            int b;
            int l;
            int j = 0;
            List<int> ff = new List<int>();

                db.Open();
                string table = "select  Product.ProductArticle,Product.ProductName,Unit.UnitName,Product.Cost,Product.Discount,Manufacture.ManufactureName,ProductProvider.ProviderName,Category.CategoryName,Product.NowDiscount,Product.Countinstock,Product.ProductDescription,Product.ProductImage from Product,Unit,Manufacture,ProductProvider,Category where Product.UnitId = Unit.UnitId and Product.ManufactureId = Manufacture.ManufactureId and Product.ProductProviderId = ProductProvider.ProviderId and Product.CategoryId = Category.CategoryId"; 
                SqlCommand command = new SqlCommand(table, db);
                SqlDataReader reader = command.ExecuteReader();

                List<string[]> data = new List<string[]>();

                while (reader.Read())
                {
                    data.Add(new string[12]);
                    ff.Add(0);

                    data[data.Count - 1][0] = reader[0].ToString();
                    data[data.Count - 1][1] = reader[1].ToString();
                    data[data.Count - 1][2] = reader[2].ToString();
                    data[data.Count - 1][3] = reader[3].ToString();
                    data[data.Count - 1][4] = reader[4].ToString();
                    data[data.Count - 1][5] = reader[5].ToString();
                    data[data.Count - 1][6] = reader[6].ToString();
                    data[data.Count - 1][7] = reader[7].ToString();
                    data[data.Count - 1][8] = reader[8].ToString();
                    data[data.Count - 1][9] = reader[9].ToString();
                    data[data.Count - 1][10] = reader[10].ToString();
                    data[data.Count - 1][11] = reader[11].ToString();

                //if (Convert.ToInt32(data[data.Count - 1][1]) < 4000)
                //    {
                //        ff[data.Count - 1] = 1;
                //    }
                }
                a = labelCount.Text;
                reader.Close();
                db.Close();

                foreach (string[] s in data)
                    dataGridView1.Rows.Add(s);
                b = dataGridView1.Rows.Count - 1;
                labelCount.Text = a + "\t" + data.Count + " из " + b;
                for (int i = 0; i < ff.Count; i++)
                    if (ff[i] == 1)
                    {
                        dataGridView1.Rows[i].Cells[1].Style.BackColor = Color.FromArgb(255, 0, 0);
                    }

            }
        }
    }
    //string connectionString = @"Data Source=DESKTOP-UR3TSU2\SQLEXPRESS;Initial Catalog=User02; Integrated Security=True;";
    //SqlConnection connection = new SqlConnection(connectionString);
    //connection.Open();

    //string query = "SELECT * FROM Product";
    //SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

    //DataTable table = new DataTable();
    //adapter.Fill(table);

    //connection.Close();

    //dataGridView1.DataSource = table;
//}
//    }
//}
