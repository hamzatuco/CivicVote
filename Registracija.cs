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
using System.Runtime.InteropServices;

namespace Zadaca
{
    public partial class registar : Form
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


        public registar()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));



        }
        


        private void label6_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }


        public static string ime1 = "";
       

        private void prikazSifre_CheckedChanged(object sender, EventArgs e)
        {
            if (prikazSifre.Checked)
            {
                lozinka.PasswordChar = '\0';
                potvrdaLozinke.PasswordChar = '\0';
            }
            else
            {
                potvrdaLozinke.PasswordChar = '•';
                lozinka.PasswordChar = '•';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            username.Text = "";
            lozinka.Text = "";
            potvrdaLozinke.Text = "";
            ime.Focus();
        }

     
        private void potvrdaLozinke_KeyDown(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void regButton_Click(object sender, EventArgs e)
        {

            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_aplikacija.mdb");
            OleDbCommand cmd = new OleDbCommand();
            OleDbDataAdapter da = new OleDbDataAdapter();
            ime1 = ime.Text;



            if (username.Text == "" && lozinka.Text == "" && potvrdaLozinke.Text == "")
            {
                MessageBox.Show("Molimo Vas da unesete korisničko ime i šifru", "Registracija neuspjela", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            else if (lozinka.Text == potvrdaLozinke.Text)
            {
                con.Open();
                string register = "INSERT INTO tb_korisnici VALUES('" + ime.Text + "','" + username.Text + "','" + lozinka.Text + "',0,Now())";
                cmd = new OleDbCommand(register, con);
                cmd.ExecuteNonQuery();
                con.Close();

                username.Text = "";
                lozinka.Text = "";
                potvrdaLozinke.Text = "";

                MessageBox.Show("Vaš račun je uspješno kreiran", "Registarija je uspjela", MessageBoxButtons.OK, MessageBoxIcon.Information);

                new Login().Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Lozinke se ne podudaraju, molimo probajte ponovo", "Registarija neuspješna", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lozinka.Text = "";
                potvrdaLozinke.Text = "";
                lozinka.Focus();



            }
        }

        private void registar_Load(object sender, EventArgs e)
        {

        }
    }
}
