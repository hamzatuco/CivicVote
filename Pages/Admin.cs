using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Data.SqlClient;


namespace Zadaca
{
    public partial class Admin : Form
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
        public Admin()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            

        }
       

        private void Admin_Load(object sender, EventArgs e)
        {
            username.Font = new Font("Poppins Medium", 10);
            lozinka.Font = new Font("Poppins Medium", 10);

            label1.Font = new Font("Poppins Black", 20);
            label1.Text = "PRIJAVITE SE KAO ADMIN";
            label7.Font = new Font("Poppins SemiBold", 12);
            label2.Font = new Font("Poppins SemiBold", 12);
            label6.Font = new Font("Poppins SemiBold", 11);
            button3.Font = new Font("Poppins SemiBold", 13);
            prikazSifre.Font = new Font("Poppins SemiBold", 11);


            button3.Location = new Point((this.ClientSize.Width - button3.Size.Width) / 2, button3.Location.Y);
            label6.Location = new Point((this.ClientSize.Width - label6.Size.Width) / 2, label6.Location.Y);


        }
        
        public void button3_Click(object sender, EventArgs e)
        {
            // Define connection string
            string connString = @"Data Source = HAMZA-MAINPC\SQLEXPRESS;" +
                                "Initial Catalog = Glasanje;" +
                                "Integrated Security = SSPI;";

            // Connect to database
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();

            // Get user input from the email and password textboxes
            string username = this.username.Text;
            string password = this.lozinka.Text;

            
            // Query database for user with entered email
            SqlCommand command = new SqlCommand("SELECT * FROM Administratori WHERE Username=@Username", connection);
            command.Parameters.AddWithValue("@Username", username);

            SqlDataReader reader = command.ExecuteReader();

            // Check if a user with the entered email exists in the database
            if (reader.Read())
            {
                // Get stored password and "Glasao" value for the user
                string storedPassword = reader["Password"].ToString();
                

                // Check if the entered password matches the stored password
                if (password == storedPassword)
                {
                    
                        string user = this.username.Text;
                        Master dashForm = new Master(user);
                        dashForm.Show();
                        this.Hide();

                    
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

        private void label6_Click(object sender, EventArgs e)
        {
            new Login().Show();
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
