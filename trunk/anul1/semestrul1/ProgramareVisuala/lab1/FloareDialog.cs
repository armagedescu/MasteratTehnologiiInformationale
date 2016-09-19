using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace USM.ProgramareVisuala.Lab1
{
    public partial class FloareDialog : Form
    {
        Dictionary<SelectMetoda, Func<Floare, object>> floareSelector =
            new Dictionary<SelectMetoda, Func<Floare, object>>
            {
                {SelectMetoda.DupaClasa, x => x.ClasaBiologica},
                {SelectMetoda.DupaUtilizare, x => x.Utilizare}
            };
        FloareModel FloareModel { get; set; }
        public FloareDialog(FloareModel floareModel)
        {
            this.FloareModel = floareModel;
            InitializeComponent();
			
			this.treeViewFlori.AfterSelect += this.TreeViewFlori_AfterSelect;
			this.checkBoxSetariAvansate.CheckedChanged += this.checkBoxSetariAvansate_CheckedChanged;
			groupBoxSetariAvansate.Hide();
            listViewFlori.Columns.Add("Denumire", 100);
            listViewFlori.Columns.Add("Clasa", 100);
            listViewFlori.Columns.Add("Utilizare", 100);
            switch (FloareModel.FloareSet.SelectMetoda)
			{
			case SelectMetoda.DupaUtilizare:
				radioButtonDupaUtilizare.Checked = true;
				break;
			case SelectMetoda.DupaClasa:
				radioButtonDupaClasa.Checked = true;
				break;
			}
			IncarcaFloriInArbore();
        }

		private void TreeViewFlori_AfterSelect(System.Object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
            switch (e.Node.Level)
            {
                case 0:
                    incarcaFloriInLista(FloareModel.Flori);
                    break;
                case 1:
                    incarcaFloriInLista(e.Node.Text, floareSelector[FloareModel.SelectMetoda]);
                    break;
                case 2:
                    incarcaFloriInLista((Floare)e.Node.Tag);
                    break;
            }

		}
		
        private void FloareDialog_Load(object sender, EventArgs e)
        {

        }

        private void checkBoxSetariAvansate_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
				groupBoxSetariAvansate.Show();
			else
				groupBoxSetariAvansate.Hide();
        }

        private void radioButtonDupaUtilizare_CheckedChanged(object sender, EventArgs e)
		{
            if (((RadioButton)sender).Checked) FloareModel.SelectMetoda = SelectMetoda.DupaUtilizare;
			IncarcaFloriInArbore();
		}
        private void radioButtonDupaClasa_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked) FloareModel.SelectMetoda = SelectMetoda.DupaClasa;
			IncarcaFloriInArbore();

        }


        private void listViewFlori_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.F2:
                    break;
                case Keys.Insert:
                    break;
                case Keys.Delete:
                    break;
            }
        }
        void clearFloareControls()
        {
            listViewFlori.Items.Clear();
            treeViewFlori.Nodes.Clear();
        }

        private void tabPageDetaliiFloare_Click(object sender, EventArgs e)
        {

        }

        private void buttonRescrieBaza_Click(object sender, EventArgs e)
        {

        }

        private void buttonReinitializeazaBaza_Click(object sender, EventArgs e)
        {

        }

        private void buttonReincarcaDinBaza_Click(object sender, EventArgs e)
        {

        }

        private void buttonInchideFaraASalva_Click(object sender, EventArgs e)
        {

        }
    }
}
