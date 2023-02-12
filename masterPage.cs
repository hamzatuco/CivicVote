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
    public partial class masterPage : Form
    {
        public masterPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void tb_korisniciBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tb_korisniciBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.db_aplikacijaDataSet);

        }

        private void masterPage_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'db_aplikacijaDataSet.tb_korisnici' table. You can move, or remove it, as needed.
            this.tb_korisniciTableAdapter.Fill(this.db_aplikacijaDataSet.tb_korisnici);
            // TODO: This line of code loads data into the 'db_aplikacijaDataSet.tb_korisnici' table. You can move, or remove it, as needed.
            this.tb_korisniciTableAdapter.Fill(this.db_aplikacijaDataSet.tb_korisnici);

        }

        private void tb_korisniciBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void tb_korisniciBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.tb_korisniciBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.db_aplikacijaDataSet);

        }
    }
}
