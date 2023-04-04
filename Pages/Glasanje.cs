
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


        public Glasanje(string imeGlasanje)
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            this.ImeZaGlasanje = imeGlasanje;


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
            // Disable blinking cursor and hide selection
            richTextBox1.ReadOnly = true;
            richTextBox1.TabStop = false;
            richTextBox1.HideSelection = true;


            label3.Font = new Font("Poppins Black", 20);
            label3.Text = "GLASANJE ZA PREDSJEDNIKA RAZREDA";


            label5.Font = new Font("Poppins SemiBold", 11);
            label2.Font = new Font("Poppins SemiBold", 10);
            label4.Font = new Font("Poppins SemiBold", 10);
            button1.Font = new Font("Poppins SemiBold", 9);
            button1.Location = new Point((this.ClientSize.Width - button1.Size.Width) / 2, button1.Location.Y);
            button1.Text = "Glasaj poslije";


            label1.Font = new Font("Poppins SemiBold", 12);




            label1.Location = new Point((this.ClientSize.Width - label1.Size.Width) / 2, label1.Location.Y);

            label5.Location = new Point((this.ClientSize.Width - label5.Size.Width) / 2, label5.Location.Y);

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



    }
}
