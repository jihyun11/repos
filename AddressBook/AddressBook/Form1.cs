using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AddressBook
{
    public partial class Form1 : Form
    {
        string connStr = "Server=localhost;Database=address;Uid=root;Pwd=1234";


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtCheck() == true)
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    String sql = "INSERT INTO t_info " +
                                 "(name, phone, Job, age) " +
                                 "VALUES('" + txtName.Text + "', '" + txtTel.Text + "', '"
                                 + txtJob.Text + "', " + int.Parse(txtAge.Text) +")";
                    Console.WriteLine(sql);

                    MySqlCommand cmd = new MySqlCommand(sql, conn); 

                    int i = cmd.ExecuteNonQuery();
                    if(i == 1)
                    {
                        MessageBox.Show("정상적으로 테이터가 저장되었습니다.", "알림",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lvList_DB_View();
                        TxtClear();
                        txtName.Focus();
                    }
                }
            }
        }

        private void TxtClear()
        {
            txtName.Text = "";
            txtTel.Text = "";
            txtAge.Text = "";
            txtJob.Text = "";
        }

        private bool txtCheck()
        {
            if(txtName.Text == "")
            {
                txtName.Focus();
                return false;
            }
            if (txtAge.Text == "")
            {
                txtAge.Focus();
                return false;
            }
            if (txtTel.Text == "")
            {
                txtTel.Focus();
                return false;
            }
            if (txtJob.Text == "")
            {
                txtJob.Focus();
                return false;
            }
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lvList_DB_View();
            txtName.Focus();
        }

        private void lvList_DB_View()
        {
            lvList.Items.Clear();

            using(MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                String sql = "SELECT id, name, age, phone, job FROM t_info";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lvList.Items.Add(new ListViewItem(new String[]
                    {
                        dr[0].ToString(),
                        dr[1].ToString(),
                        dr[2].ToString(),
                        dr[3].ToString(),
                        dr[4].ToString()
                        }));
                }
                dr.Close();
                conn.Close();
            }
        }
    }
}
