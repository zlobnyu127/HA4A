using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADB
{
    public partial class firstavto : Form
    {
        public firstavto()
        {
            InitializeComponent();
            
        }
        int sum = 1;
        private void button1_Click(object sender, EventArgs e)
        {

            if (sum >= 1)
            {
                sum--;
                DB db = new DB();
                db.openConnection();
                MySqlCommand command = new MySqlCommand("SELECT image FROM avto WHERE a_id = @sum", db.getConnection());
                command.Parameters.Add("@sum", MySqlDbType.Int64).Value = sum;
                MySqlDataReader Reader = command.ExecuteReader();
                Reader.Read();
                if (Reader.HasRows)
                {
                    byte[] img = (byte[])(Reader[0]);
                    if (img == null)
                    {                       
                        pictureBox1.Image = null;
                    }
                    else
                    {                       
                        MemoryStream ms = new MemoryStream(img);
                        pictureBox1.Image = Image.FromStream(ms);
                        
                    }
                }
                

                else { MessageBox.Show(" Конец "); sum++; }
                db.closeConnection();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (sum < 10)
            {
                sum++;
                DB db = new DB();
                db.openConnection();
                MySqlCommand command = new MySqlCommand("Select image from avto WHERE a_id = @sum ", db.getConnection());
                command.Parameters.Add("@sum", MySqlDbType.Int64).Value = sum;
                MySqlDataReader Reader = command.ExecuteReader();
                Reader.Read();
                if (Reader.HasRows)
                {
                    
                    byte[] img = (byte[])(Reader[0]);
                    if (img == null)
                    {
                        pictureBox1.Image = null;
                    }
                    else
                    {

                        MemoryStream ms = new MemoryStream(img);
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                    
                }
                
                else { MessageBox.Show(" Конец "); sum--; }
                db.closeConnection();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void firstavto_Load(object sender, EventArgs e)
        {
            DB db = new DB();
            db.openConnection();
            MySqlCommand command = new MySqlCommand("Select image from avto WHERE a_id = @sum ", db.getConnection());
            command.Parameters.Add("@sum", MySqlDbType.Int64).Value = sum;
            MySqlDataReader Reader = command.ExecuteReader();
            Reader.Read();
            if (Reader.HasRows)
            {
                sum++;
                byte[] img = (byte[])(Reader[0]);
                if (img == null)
                {
                    pictureBox1.Image = null;
                }
                else
                {

                    MemoryStream ms = new MemoryStream(img);
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
            else { MessageBox.Show(" Конец "); sum--; }
            db.closeConnection();
        }
    }
}
