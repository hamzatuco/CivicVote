
using System.Drawing;
using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

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
                lozinkainput.PasswordChar = '\0';
                potvrdaLozinkeInput.PasswordChar = '\0';
            }
            else
            {
                potvrdaLozinkeInput.PasswordChar = '•';
                lozinkainput.PasswordChar = '•';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            emailInput.Text = "";
            lozinkainput.Text = "";
            potvrdaLozinkeInput.Text = "";
            imeInput.Focus();
        }

     
        private void potvrdaLozinke_KeyDown(object sender, EventArgs e)
        {

        }

       
        private void regButton_Click(object sender, EventArgs e)
        {
            string emailCheck = emailInput.Text;


            if (string.IsNullOrEmpty(emailCheck) || !emailCheck.Contains("@") || emailCheck.IndexOf("@") >= emailCheck.LastIndexOf(".") - 1)
            {
                MessageBox.Show("Unesite validnu e-mail adresu");
                return;
            }

            string lozinkaCheck = lozinkainput.Text;
            if (lozinkaCheck.Length < 8)
            {
                MessageBox.Show("Lozinka mora sadrzavati najmanje 8 karaktera");
                return;
            }

            string connectionString = @"Data Source = HAMZA-MAINPC\SQLEXPRESS;" +
                                "Initial Catalog = Glasanje;" +
                                "Integrated Security = SSPI;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string imeS = imeInput.Text;
                string prezimeS = prezimeInput.Text;
                string jmbgS = jmbgInput.Text;
                string emailS = emailInput.Text;
                string lozinkaS = lozinkainput.Text;

               


                if (lozinkainput.Text == potvrdaLozinkeInput.Text)
                {
                    // JMBG is unique, proceed with insert
                    SqlCommand insertCommand = new SqlCommand("INSERT INTO Glasaci (Ime, Prezime, JMBG, Glasao, Email, Lozinka) VALUES (@Ime, @Prezime, @JMBG, @Glasao, @Email, @Lozinka)", connection);
                    insertCommand.Parameters.AddWithValue("@Ime", imeS);
                    insertCommand.Parameters.AddWithValue("@Prezime", prezimeS);
                    insertCommand.Parameters.AddWithValue("@JMBG", jmbgS);
                    insertCommand.Parameters.AddWithValue("@Glasao", "0");
                    insertCommand.Parameters.AddWithValue("@Email", emailS);
                    insertCommand.Parameters.AddWithValue("@Lozinka", lozinkaS);

                    insertCommand.ExecuteNonQuery();

                    MessageBox.Show("Insert successful.");
                    
                    new Login().Show();
                    this.Hide();

                }
                else
                {
                    // JMBG already exists, show error message
                    MessageBox.Show("JMBG already exists in the table.");
                    lozinkainput.Text = "";
                    potvrdaLozinkeInput.Text = "";
                    lozinkainput.Focus();
                }
            }

            ime1 = imeInput.Text;



            if (emailInput.Text == "" && lozinkainput.Text == "" && potvrdaLozinkeInput.Text == "")
            {
                MessageBox.Show("Molimo Vas da unesete korisničko ime i šifru", "Registracija neuspjela", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



          
        }

        private void registar_Load(object sender, EventArgs e)
        {
            imeInput.Font = new Font("Poppins Medium", 10);
            prezimeInput.Font = new Font("Poppins Medium", 10);
            jmbgInput.Font = new Font("Poppins Medium", 10);
            jmbgInput.Font = new Font("Poppins Medium", 10);
            emailInput.Font = new Font("Poppins Medium", 10);
            lozinkainput.Font = new Font("Poppins Medium", 10);


            label3.Font = new Font("Poppins Black", 20);
            label3.Text = "REGISTRUJTE SE KAO GLASAČ";
            label7.Font = new Font("Poppins SemiBold", 12);
            regButton.Font = new Font("Poppins SemiBold", 13);
            
            button2.Font = new Font("Poppins SemiBold", 13);
            label5.Font = new Font("Poppins SemiBold", 11);
            label6.Font = new Font("Poppins SemiBold", 11);

            label8.Font = new Font("Poppins SemiBold", 12);
            label9.Font = new Font("Poppins SemiBold", 12);
            label2.Font = new Font("Poppins SemiBold", 12);
            label4.Font = new Font("Poppins SemiBold", 12);
            label1.Font = new Font("Poppins SemiBold", 12);
            prikazSifre.Font = new Font("Poppins SemiBold", 11);

            regButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            regButton.Location = new Point((this.ClientSize.Width - regButton.Size.Width) / 2, regButton.Location.Y);

          
            button2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button2.Location = new Point((this.ClientSize.Width - button2.Size.Width) / 2, button2.Location.Y);

            label5.Location = new Point((this.ClientSize.Width - label5.Size.Width) / 2, label5.Location.Y);
            label6.Location = new Point((this.ClientSize.Width - label6.Size.Width) / 2, label6.Location.Y);
            pictureBox13.Location = new Point((this.ClientSize.Width - pictureBox13.Size.Width) / 2, pictureBox13.Location.Y);





        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void jmbgInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void prezimeInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void potvrdaLozinkeInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lozinkainput_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void emailInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void imeInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox14_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Current= Cursors.Hand;
        }

       

        private void pictureBox14_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
        

        private void label6_MouseHover(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Hand;
        }
    }
}
