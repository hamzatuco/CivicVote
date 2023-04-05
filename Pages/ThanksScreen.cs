using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Data.SqlClient;



namespace Zadaca
{
    public partial class ThanksScreen : Form
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
        private string jmbg;
        public ThanksScreen(string jmbg)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            this.jmbg = jmbg;
            // Set the initial text of the label to "5"
            label2.Text = "5";

            // Create a new Timer with an interval of 1 second
            Timer timer = new Timer();
            timer.Interval = 1000;

            // Set the Tick event handler for the Timer
            timer.Tick += (sender, e) =>
            {
                // Decrement the value of the label
                int count = int.Parse(label2.Text);
                count--;
                label2.Text = count.ToString();

                // If the countdown is complete, stop the Timer and redirect to the login screen
                if (count == 0)
                {
                    timer.Stop();
                    this.Hide();
                    Login login = new Login();
                    login.Show();
                }
            };

            // Start the Timer
            timer.Start();
        }



        private void Login_Load(object sender, EventArgs e)
        {

            label1.Font = new Font("Poppins Black", 20);
            label1.Location = new Point((this.ClientSize.Width - label1.Size.Width) / 2, label1.Location.Y);
            label5.Location = new Point((this.ClientSize.Width - label5.Size.Width) / 2, label5.Location.Y);


            button2.Font = new Font("Poppins SemiBold", 9);
            label2.Font = new Font("Poppins SemiBold", 12);
            label3.Font = new Font("Poppins Black", 13);


       
            button2.Location = new Point((this.ClientSize.Width - button2.Size.Width) / 2, button2.Location.Y);
            button2.Text = "Odmah se vrati";

            string connString = @"Data Source = HAMZA-MAINPC\SQLEXPRESS;" +
                              "Initial Catalog = Glasanje;" +
                              "Integrated Security = SSPI;";
            // Create a SqlConnection object
            using (SqlConnection conn = new SqlConnection(connString))
            {
                // Open the database connection
                conn.Open();

                // Create a SqlCommand object to execute the update query
                using (SqlCommand cmd = new SqlCommand("UPDATE Glasaci SET Glasao = @Glasao WHERE JMBG = @JMBG", conn))
                {
                    // Set the values of the parameters in the SqlCommand object
                    cmd.Parameters.AddWithValue("@Glasao", true);
                    cmd.Parameters.AddWithValue("@JMBG", jmbg);

                    // Execute the update query
                    int rowsAffected = cmd.ExecuteNonQuery();

                    // Check if any rows were affected
                    if (rowsAffected > 0)
                    {
                        // The update was successful
                        Console.WriteLine("Record updated successfully.");
                    }
                    else
                    {
                        // No rows were affected
                        Console.WriteLine("No records found matching the JMBG value.");
                    }
                }
            }



        }



        private void label6_Click(object sender, EventArgs e)
        {
            new registar().Show();
            this.Hide();
        }

   


        public static string user = "";
        

       

       

       

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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login odjava = new Login();
            this.Hide();
            odjava.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }
    }
}
