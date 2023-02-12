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
using System.Drawing.Text;
using System.Runtime.InteropServices;

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
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_aplikacija.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void login_Load(object sender, EventArgs e)
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            pfc.AddFontFile("lemon.ttf");
            foreach(Control c in this.Controls)
            {
                c.Font = new Font(pfc.Families[0], 15, FontStyle.Regular);
               
            }
        }

        public void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            string login = "SELECT * FROM tb_korisnici WHERE username= '" + username.Text + "' and password ='" + lozinka.Text + "'";
            cmd = new OleDbCommand(login, con);
            OleDbDataReader dr = cmd.ExecuteReader();
            user = username.Text;
            dash form = new dash();

            if (username.Text == "admin" && lozinka.Text == "admin1234")
            {
                this.Hide();
                new masterPage().Show();


            }

            else if (dr.Read() == true)
            {
                string str = username.Text;
                new dash().Show();
                this.Hide();
            }


            else if (username.Text == "" || lozinka.Text == "")
            {
                MessageBox.Show("Nedostaje korisnicko ime ili sifra", "Prijava neuspjesna", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Pogresno korisnicko ime ili sifra, pokusajte ponovo", "Prijava neuspjesna", MessageBoxButtons.OK, MessageBoxIcon.Error);
                username.Text = "";
                lozinka.Text = "";
                username.Focus();
            }
            con.Close();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            new registar().Show();
            this.Hide();
        }

   


        public static string user = "";
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

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

        private void Login_Load_1(object sender, EventArgs e)
        {

        }
    }
}
