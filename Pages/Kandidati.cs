using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadaca
{
    public partial class Kandidati : Form
    {
        private string username;
        public Kandidati(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void Dash_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'glasanjeDataSet1.Kandidati' table. You can move, or remove it, as needed.
            this.kandidatiTableAdapter.Fill(this.glasanjeDataSet1.Kandidati);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Master nazad = new Master(username);
            this.Hide();
            nazad.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void kandidatiBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.kandidatiBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.glasanjeDataSet1);

        }
    }
}
