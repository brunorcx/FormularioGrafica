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

namespace FormularioGrafica {

    public partial class Login : Form {

        public Login() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            this.Hide();
            // Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;
            //string connetionString;
            //SqlConnection cnn;
            //connetionString = @"Server=localhost\SQLEXPRESS;Database=master;Initial Catalog=banco1;User ID=mario;Password=123123";
            //cnn = new SqlConnection(connetionString);
            //cnn.Open();
            //MessageBox.Show("Connection Open  !");
            //cnn.Close();

            Form1 form = new Form1();
            form.Show();
        }
    }
}