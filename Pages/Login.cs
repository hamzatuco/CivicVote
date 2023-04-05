using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Data.SqlClient;


namespace Zadaca
{
    public partial class Login : Form
    {


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
        public Login()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            

        }
       

        private void Login_Load(object sender, EventArgs e)
        {
            emailInput.Font = new Font("Poppins Medium", 10);
            lozinka.Font = new Font("Poppins Medium", 10);

            label1.Font = new Font("Poppins Black", 20);
            label1.Text = "PRIJAVITE SE";
            label7.Font = new Font("Poppins SemiBold", 12);
            label2.Font = new Font("Poppins SemiBold", 12);
            label5.Font = new Font("Poppins SemiBold", 11);
            label6.Font = new Font("Poppins SemiBold", 11);
            label3.Font = new Font("Poppins SemiBold", 9);
            button3.Font = new Font("Poppins SemiBold", 13);
            prikazSifre.Font = new Font("Poppins SemiBold", 11);


            button3.Location = new Point((this.ClientSize.Width - button3.Size.Width) / 2, button3.Location.Y);
            label5.Location = new Point((this.ClientSize.Width - label5.Size.Width) / 2, label5.Location.Y);
            label6.Location = new Point((this.ClientSize.Width - label6.Size.Width) / 2, label6.Location.Y);
            label3.Location = new Point((this.ClientSize.Width - label3.Size.Width) / 2, label3.Location.Y);
            pictureBox1.Location = new Point((this.ClientSize.Width - pictureBox1.Size.Width) / 2, pictureBox1.Location.Y);


        }
        
        public void button3_Click(object sender, EventArgs e)
        {
            string emailCheck = emailInput.Text;

           
               

            




            // Define connection string
            string connString = @"Data Source = HAMZA-MAINPC\SQLEXPRESS;" +
                                "Initial Catalog = Glasanje;" +
                                "Integrated Security = SSPI;";

            // Connect to database
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();

            // Get user input from the email and password textboxes
            string email = emailInput.Text;
            string password = lozinka.Text;


            // Query database for user with entered email
            SqlCommand command = new SqlCommand("SELECT Ime, Lozinka, Glasao, JMBG FROM Glasaci WHERE Email=@Email", connection);

            command.Parameters.AddWithValue("@Email", email);

            SqlDataReader reader = command.ExecuteReader();

            if (email == "admin1" && password == "admin123")
            {
                Admin admin = new Admin();
                this.Hide();
                admin.Show();
                

            }
            else { 
            // Check if a user with the entered email exists in the database
            if (reader.Read())
            {
                    string jmbg = reader["JMBG"].ToString();

                    // Get stored password and "Glasao" value for the user
                    string storedPassword = reader["Lozinka"].ToString();
                int glasao = Convert.ToInt32(reader["Glasao"]);

                    string imeGlasanje = null;
                    if (password == storedPassword)
                    {
                        imeGlasanje = reader["Ime"].ToString();
                        if (glasao == 1)
                        {
                            MessageBox.Show("Vec ste glasali.");
                        }
                        else
                        {
                            string user = emailInput.Text;
                            Glasanje glasanje = new Glasanje(imeGlasanje,jmbg);
                            this.Hide();
                            glasanje.Show();
                        }
                    }

                    else
                    {
                    MessageBox.Show("Invalid email or password. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("Invalid email or password. Please try again.");
            }

            // Close database connection
            connection.Close();


            }





        }

        private void label6_Click(object sender, EventArgs e)
        {
            new registar().Show();
            this.Hide();
        }

   


        public static string user = "";
        

       

       

        private void prikazSifre_CheckedChanged(object sender, EventArgs e)
        {
            if (prikazSifre.Checked)
            {
                lozinka.PasswordChar = '\0';
                
            }
            else
            {
                
                lozinka.PasswordChar = '•';
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox14_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }



        private void pictureBox14_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
    }
}
