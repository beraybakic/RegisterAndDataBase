using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

       




        public Form1()
        {
            InitializeComponent();


        }
        
        OleDbConnection dbConnection = new OleDbConnection("provider = Microsoft.ACE.OLEDB.12.0; Data source = Database1.accdb");
        private void VerileriCek()

        {
            listView1.Items.Clear();
            dbConnection.Open();
            OleDbCommand dbCommand = new OleDbCommand("Select * from Deneme", dbConnection);

            OleDbDataReader dataReader = dbCommand.ExecuteReader();

            while (dataReader.Read())
            {
                ListViewItem viewItem = new ListViewItem();
                viewItem.Text = dataReader["ID"].ToString();
                viewItem.SubItems.Add(dataReader["Ad"].ToString());
                viewItem.SubItems.Add(dataReader["Soyad"].ToString());
                viewItem.SubItems.Add(dataReader["Eposta"].ToString());
                viewItem.SubItems.Add(dataReader["Sifre"].ToString());
                viewItem.SubItems.Add(dataReader["Tarih"].ToString());
                viewItem.SubItems.Add(dataReader["Yas"].ToString());

                listView1.Items.Add(viewItem);
            }
            dbConnection.Close();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            VerileriCek();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dbConnection.Open();
            OleDbCommand command = new OleDbCommand("insert into DENEME (Ad,Soyad,Eposta,Sifre,Tarih,Yas) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')",dbConnection);
            command.ExecuteNonQuery();
            dbConnection.Close();
            VerileriCek();
        }
    }
}
