
using System.Diagnostics;
using System.Drawing;
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace Zadaca
{
    public partial class Glasanje : Form
    {
        private string jmbg;
        private string ImeZaGlasanje;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
    (
        int nLeftRect,
        int nTopRect,
        int nRightRect,
        int nBottomRect,
        int nWidthEllipse,
        int nHeightEllipse
    );


        public Glasanje(string imeGlasanje,string jmbg)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            this.ImeZaGlasanje = imeGlasanje;
            this.jmbg = jmbg;

        }



        private void label6_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }





        private void potvrdaLozinke_KeyDown(object sender, EventArgs e)
        {

        }



        private void Glasanje_Load(object sender, EventArgs e)
        {
            

            // Connect to database
            

            // Disable blinking cursor and hide selection
            richTextBox1.ReadOnly = true;
            richTextBox1.TabStop = false;
            richTextBox1.HideSelection = true;


            label3.Font = new Font("Poppins Black", 20);
            label3.Text = "GLASANJE ZA PREDSJEDNIKA RAZREDA";


            label5.Font = new Font("Poppins SemiBold", 11);
            label2.Font = new Font("Poppins SemiBold", 10);
            label4.Font = new Font("Poppins SemiBold", 10);
            label6.Font = new Font("Poppins SemiBold", 13);
            label8.Font = new Font("Poppins SemiBold", 13);
            label7.Font = new Font("Poppins SemiBold", 13);
            button1.Font = new Font("Poppins SemiBold", 9);
            button2.Font = new Font("Poppins SemiBold", 12);
            button2.Location = new Point((this.ClientSize.Width - button2.Size.Width) / 2, button2.Location.Y);
            button1.Text = "Glasaj poslije";


            label1.Font = new Font("Poppins SemiBold", 12);




            label1.Location = new Point((this.ClientSize.Width - label1.Size.Width) / 2, label1.Location.Y);
            richTextBox1.Location = new Point((this.ClientSize.Width - richTextBox1.Size.Width) / 2, richTextBox1.Location.Y);


            // Set the text of the RichTextBox control with HTML tags
            richTextBox1.Rtf = "{\\rtf1\\ansi\\deff0{\\colortbl ;\\red0\\green0\\blue255;}" +
                                "Dobrodosli {\\cf1 " + ImeZaGlasanje + "} }";

            // Set the font of the entire text
            richTextBox1.Font = new Font("Poppins SemiBold", 15);

            // Find the position of the username and set its color and font
            richTextBox1.BackColor = Color.White;

            int startIndex = richTextBox1.Find(ImeZaGlasanje);
            richTextBox1.SelectionStart = startIndex;
            richTextBox1.SelectionLength = ImeZaGlasanje.Length;
            richTextBox1.SelectionColor = Color.FromArgb(50, 137, 200);
            richTextBox1.SelectionFont = new Font("Poppins SemiBold", 15);
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;


            string connString = @"Data Source = HAMZA-MAINPC\SQLEXPRESS;" +
                               "Initial Catalog = Glasanje;" +
                               "Integrated Security = SSPI;";

            string query = "SELECT Ime_kandidata, Prezime_kandidata FROM Kandidati WHERE Kandidat_ID = @Kandidat_ID";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command1 = new SqlCommand(query, connection))
                {
                    connection.Open();

                    // Retrieve the data for label6 by setting the parameter value to 1
                    command1.Parameters.AddWithValue("@Kandidat_ID", 1);
                    using (SqlDataReader reader1 = command1.ExecuteReader())
                    {
                        if (reader1.HasRows)
                        {
                            reader1.Read();
                            label6.Text = reader1.GetString(0) + " " + reader1.GetString(1);
                        }
                    }

                    // Retrieve the data for label7 by setting the parameter value to 2
                    command1.Parameters["@Kandidat_ID"].Value = 2;
                    using (SqlDataReader reader2 = command1.ExecuteReader())
                    {
                        if (reader2.HasRows)
                        {
                            reader2.Read();
                            label7.Text = reader2.GetString(0) + " " + reader2.GetString(1);
                        }
                    }

                    command1.Parameters["@Kandidat_ID"].Value = 3;
                    using (SqlDataReader reader3 = command1.ExecuteReader())
                    {
                        if (reader3.HasRows)
                        {
                            reader3.Read();
                            label8.Text = reader3.GetString(0) + " " + reader3.GetString(1);
                        }
                    }

                    command1.Parameters["@Kandidat_ID"].Value = 4;
                    using (SqlDataReader reader4 = command1.ExecuteReader())
                    {
                        if (reader4.HasRows)
                        {
                            reader4.Read();
                            label22.Text = reader4.GetString(0) + " " + reader4.GetString(1);
                        }
                    }
                    command1.Parameters["@Kandidat_ID"].Value = 5;
                    using (SqlDataReader reader5 = command1.ExecuteReader())
                    {
                        if (reader5.HasRows)
                        {
                            reader5.Read();
                            label23.Text = reader5.GetString(0) + " " + reader5.GetString(1);
                        }
                    }
                    command1.Parameters["@Kandidat_ID"].Value = 6;
                    using (SqlDataReader reader6 = command1.ExecuteReader())
                    {
                        if (reader6.HasRows)
                        {
                            reader6.Read();
                            label24.Text = reader6.GetString(0) + " " + reader6.GetString(1);
                        }
                    }
                }

            }

            

            // Create a new SqlConnection object with the connection string
            using (SqlConnection connection = new SqlConnection(connString))
            {
                // Fetch the Stranke from Kandidati table where Kandidat_ID is 1
                string query1 = "SELECT Stranka FROM Kandidati WHERE Kandidat_ID = 1";
                // Fetch the Stranke from Kandidati table where id is 2
                string query2 = "SELECT Stranka FROM Kandidati WHERE Kandidat_ID = 2";
                // Fetch the Stranke from Kandidati table where id is 3
                string query3 = "SELECT Stranka FROM Kandidati WHERE Kandidat_ID = 3";

                // Create a new SqlCommand object with the SQL query and the SqlConnection object for label12
                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    // Open the SqlConnection
                    connection.Open();

                    // Execute the SQL query and retrieve the data using a SqlDataReader object
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if there is data to read
                        if (reader.HasRows)
                        {
                            // Read the first row of data
                            reader.Read();

                            // Set the label12 text to the Stranke value
                            label12.Text = reader.GetString(0);
                        }
                    }
                }

                // Create a new SqlCommand object with the SQL query and the SqlConnection object for label13
                using (SqlCommand command = new SqlCommand(query2, connection))
                {
                    // Execute the SQL query and retrieve the data using a SqlDataReader object
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if there is data to read
                        if (reader.HasRows)
                        {
                            // Read the first row of data
                            reader.Read();

                            // Set the label13 text to the Stranke value
                            label13.Text = reader.GetString(0);
                        }
                    }
                }

                // Create a new SqlCommand object with the SQL query and the SqlConnection object for label14
                using (SqlCommand command = new SqlCommand(query3, connection))
                {
                    // Execute the SQL query and retrieve the data using a SqlDataReader object
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if there is data to read
                        if (reader.HasRows)
                        {
                            // Read the first row of data
                            reader.Read();

                            // Set the label14 text to the Stranke value
                            label14.Text = reader.GetString(0);
                        }
                    }
                }
            }

         

            // Retrieve propaganda for candidate with Kandidat_ID 1
            string query4 = "SELECT Propaganda FROM Kandidati WHERE Kandidat_ID = 1";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query4, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            richTextBox3.Text = reader.GetString(0);
                            richTextBox2.SelectionAlignment = HorizontalAlignment.Center;

                        }
                    }
                }
            }

            // Retrieve propaganda for candidate with id 2
            string query5 = "SELECT Propaganda FROM Kandidati WHERE Kandidat_ID = 2";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query5, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            richTextBox2.Text = reader.GetString(0);
                            richTextBox2.SelectionAlignment = HorizontalAlignment.Center;

                        }
                    }
                }
            }

            // Retrieve propaganda for candidate with id 3
            string query6 = "SELECT Propaganda FROM Kandidati WHERE Kandidat_ID = 3";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query6, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            richTextBox4.SelectionAlignment = HorizontalAlignment.Center;

                            richTextBox4.Text = reader.GetString(0);
                        }
                    }
                }
            }

            string query15 = "SELECT Propaganda FROM Kandidati WHERE Kandidat_ID = 4";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query15, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            label25.Text = reader.GetString(0);

                        }
                    }
                }
            }

            string query16 = "SELECT Propaganda FROM Kandidati WHERE Kandidat_ID = 5";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query16, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            label26.Text = reader.GetString(0);

                        }
                    }
                }
            }

            string query17 = "SELECT Propaganda FROM Kandidati WHERE Kandidat_ID = 6";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query17, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            label27.Text = reader.GetString(0);

                        }
                    }
                }
            }


            // Retrieve Broj_glasova for candidate with Kandidat_ID 1
            string query7 = "SELECT Broj_glasova FROM Kandidati WHERE Kandidat_ID = 1";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query7, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            label17.Text = reader.GetInt32(0).ToString();
                        }
                    }
                }
            }

            // Retrieve Broj_glasova for candidate with Kandidat_ID 2
            string query8 = "SELECT Broj_glasova FROM Kandidati WHERE Kandidat_ID = 2";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query8, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            label16.Text = reader.GetInt32(0).ToString();
                        }
                    }
                }
            }

            // Retrieve Broj_glasova for candidate with Kandidat_ID 3
            string query9 = "SELECT Broj_glasova FROM Kandidati WHERE Kandidat_ID = 3";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query9, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            label19.Text = reader.GetInt32(0).ToString();
                        }
                    }
                }
            }

            string query91 = "SELECT Broj_glasova FROM Kandidati WHERE Kandidat_ID = 4";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query91, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            label28.Text = reader.GetInt32(0).ToString();
                        }
                    }
                }
            }

            string query92 = "SELECT Broj_glasova FROM Kandidati WHERE Kandidat_ID = 5";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query92, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            label30.Text = reader.GetInt32(0).ToString();
                        }
                    }
                }
            }

            string query93 = "SELECT Broj_glasova FROM Kandidati WHERE Kandidat_ID = 6";
            using (SqlConnection connection = new SqlConnection(connString))
            {
                using (SqlCommand command = new SqlCommand(query93, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            label32.Text = reader.GetInt32(0).ToString();
                        }
                    }
                }
            }




        }


        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Glasate na način da checkirate svog kandidata za kojeg želite da glasate. \nUkoliko se predomislite, možete slobodno mjenjati svoj izbor sve dok ne kliknete dugme glasaj. Nakon klika tog dugmeta nećete imati mogućnost promjene glasa. \n\nVaš glas se sprema u bazu podataka i konačan je.", "Kratko uputstvo za upotrebu", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {

            }
            if (res == DialogResult.Cancel)
            {

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login odjava = new Login();
            this.Hide();
            odjava.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Get the checkbox that was just checked
           
        }

        private CheckBox lastClicked;

        private void checkBox_CheckedChanged_1(object sender, EventArgs e)
        {
        }


        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox clickedBox = sender as CheckBox;

            if (clickedBox.Checked)
            {
                if (lastClicked != null && lastClicked != clickedBox)
                {
                    lastClicked.Checked = false;
                }
                lastClicked = clickedBox;
            }
            else
            {
                lastClicked = null;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox clickedBox = sender as CheckBox;

            if (clickedBox.Checked)
            {
                if (lastClicked != null && lastClicked != clickedBox)
                {
                    lastClicked.Checked = false;
                }
                lastClicked = clickedBox;
            }
            else
            {
                lastClicked = null;
            }
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

            CheckBox clickedBox = sender as CheckBox;

            if (clickedBox.Checked)
            {
                if (lastClicked != null && lastClicked != clickedBox)
                {
                    lastClicked.Checked = false;
                }
                lastClicked = clickedBox;
            }
            else
            {
                lastClicked = null;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox clickedBox = sender as CheckBox;

            if (clickedBox.Checked)
            {
                if (lastClicked != null && lastClicked != clickedBox)
                {
                    lastClicked.Checked = false;
                }
                lastClicked = clickedBox;
            }
            else
            {
                lastClicked = null;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox clickedBox = sender as CheckBox;

            if (clickedBox.Checked)
            {
                if (lastClicked != null && lastClicked != clickedBox)
                {
                    lastClicked.Checked = false;
                }
                lastClicked = clickedBox;
            }
            else
            {
                lastClicked = null;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox clickedBox = sender as CheckBox;

            if (clickedBox.Checked)
            {
                if (lastClicked != null && lastClicked != clickedBox)
                {
                    lastClicked.Checked = false;
                }
                lastClicked = clickedBox;
            }
            else
            {
                lastClicked = null;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string connString = @"Data Source = HAMZA-MAINPC\SQLEXPRESS;" +
                               "Initial Catalog = Glasanje;" +
                               "Integrated Security = SSPI;";

            if (lastClicked == checkBox5)
            {
                string query = "UPDATE Kandidati SET Broj_glasova = Broj_glasova + 1 WHERE Kandidat_ID = 1";
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    ThanksScreen hvala = new ThanksScreen(jmbg);
                    this.Close();
                    hvala.Show();
                }
            }
            else if (lastClicked == checkBox4)
            {
                string query = "UPDATE Kandidati SET Broj_glasova = Broj_glasova + 1 WHERE Kandidat_ID = 2";
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    ThanksScreen hvala = new ThanksScreen(jmbg);
                    this.Close();
                    hvala.Show();
                }
            }
            else if (lastClicked == checkBox6)
            {
                string query = "UPDATE Kandidati SET Broj_glasova = Broj_glasova + 1 WHERE Kandidat_ID = 3";
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    ThanksScreen hvala = new ThanksScreen(jmbg);
                    this.Close();
                    hvala.Show();
                }
            }
            else if (lastClicked == checkBox1)
            {
                string query = "UPDATE Kandidati SET Broj_glasova = Broj_glasova + 1 WHERE Kandidat_ID = 4";
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    ThanksScreen hvala = new ThanksScreen(jmbg);
                    this.Close();
                    hvala.Show();
                }
            }
            else if (lastClicked == checkBox3)
            {
                string query = "UPDATE Kandidati SET Broj_glasova = Broj_glasova + 1 WHERE Kandidat_ID = 5";
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    ThanksScreen hvala = new ThanksScreen(jmbg);
                    this.Close();
                    hvala.Show();
                }
            }
            else if (lastClicked == checkBox2)
            {
                string query = "UPDATE Kandidati SET Broj_glasova = Broj_glasova + 1 WHERE Kandidat_ID = 6";
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    ThanksScreen hvala = new ThanksScreen(jmbg);
                    this.Close();
                    hvala.Show();
                }
            }
        }
    }
}
