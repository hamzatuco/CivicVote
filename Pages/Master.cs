using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Data.SqlClient;



namespace Zadaca
{
    public partial class Master : Form
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
        private string username;
        public Master(string username)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            this.username = username;

        }
       

        private void Login_Load(object sender, EventArgs e)
        {

            label1.Font = new Font("Poppins Black", 20);
            label1.Text = "IZABERITE UPRAVLJANJE";
            label1.Location = new Point((this.ClientSize.Width - label1.Size.Width) / 2, label1.Location.Y);

            
            button3.Font = new Font("Poppins SemiBold", 13);
            button1.Font = new Font("Poppins SemiBold", 13);
            button2.Font = new Font("Poppins SemiBold", 9);


            button3.Location = new Point((this.ClientSize.Width - button3.Size.Width) / 2, button3.Location.Y);
       
            button1.Location = new Point((this.ClientSize.Width - button1.Size.Width) / 2, button1.Location.Y);
            button2.Location = new Point((this.ClientSize.Width - button2.Size.Width) / 2, button2.Location.Y);
            button2.Text = "Odjavite se";


            // Set the text of the RichTextBox control with HTML tags
            richTextBox1.Rtf = "{\\rtf1\\ansi\\deff0{\\colortbl ;\\red0\\green0\\blue255;}" +
                                "Ulogovani ste kao: {\\cf1 " + username + "} }";

            // Set the font of the entire text
            richTextBox1.Font = new Font("Poppins SemiBold", 12);
            
            // Find the position of the username and set its color and font
            int startIndex = richTextBox1.Find(username);
            richTextBox1.SelectionStart = startIndex;
            richTextBox1.SelectionLength = username.Length;
            richTextBox1.SelectionColor = Color.FromArgb(50,137,200);
            richTextBox1.SelectionFont = new Font("Poppins SemiBold", 12);
            richTextBox1.Location = new Point((this.ClientSize.Width - richTextBox1.Size.Width) / 2, richTextBox1.Location.Y);
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;



        }

        public void button3_Click(object sender, EventArgs e)
        {
            Dash glasaci = new Dash(username);
            this.Hide();
            glasaci.Show();


         
            



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

        private void button1_Click(object sender, EventArgs e)
        {
            Kandidati kandidati = new Kandidati(username);
            this.Close();
            kandidati.Show();
        }
    }
}
