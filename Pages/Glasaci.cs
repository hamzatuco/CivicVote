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
    public partial class Dash : Form
    {
        private string username;
        public Dash(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void Dash_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'glasanjeDataSet.Glasaci' table. You can move, or remove it, as needed.
            this.glasaciTableAdapter.Fill(this.glasanjeDataSet.Glasaci);
            // TODO: This line of code loads data into the 'glasanjeDataSet.Glasaci' table. You can move, or remove it, as needed.
            this.glasaciTableAdapter.Fill(this.glasanjeDataSet.Glasaci);
            // TODO: This line of code loads data into the 'glasanjeDataSet1.Glasaci' table. You can move, or remove it, as needed.
           

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void glasaciBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.glasaciBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.glasanjeDataSet);

        }
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Get the index of the newly added row
            int rowIndex = e.RowIndex;

            // Set the value of the ID column to a positive integer
            glasaciDataGridView.Rows[rowIndex].Cells["ID"].Value = GetNewID();
        }

        // This method returns a new positive integer ID
        private int GetNewID()
        {
            // Your code to get the next available ID goes here
            // For example, you could query the database to get the highest existing ID
            // and add 1 to it to get the new ID
            return 1;
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
    }
}
