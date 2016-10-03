using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void controllerBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.controllerBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.universityDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'universityDataSet.Controller' table. You can move, or remove it, as needed.
            this.controllerTableAdapter.Fill(this.universityDataSet.Controller);

        }
    }
}
