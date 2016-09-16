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
		FloareSet floareSet;
		MainApp mainApp;
        public FloareDialog(FloareSet _floareSet, MainApp _mainApp)
        {
			this.floareSet = _floareSet;
			this.mainApp = _mainApp;
            InitializeComponent();
			
			this.treeViewFlori.AfterSelect += this.TreeViewFlori_AfterSelect;
			this.checkBoxSetariAvansate.CheckedChanged += this.checkBoxSetariAvansate_CheckedChanged;
			groupBoxSetariAvansate.Hide();
            listViewFlori.Columns.Add("Denumire", 100);
            listViewFlori.Columns.Add("Clasa", 100);
            listViewFlori.Columns.Add("Utilizare", 100);
			switch (floareSet.SelectMetoda)
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
			Console.WriteLine("clicked: " + e.Node.Text + "; Level: " + e.Node.Level);
			if (e.Node.Level == 0)
				incarcaFloriInLista (floareSet.Flori);
			else if (e.Node.Level == 1)
				switch (floareSet.SelectMetoda)
				{
				case SelectMetoda.DupaClasa:
					incarcaFloriInLista( e.Node.Text,  x => x.ClasaBiologica);
					break;
				case SelectMetoda.DupaUtilizare:
					incarcaFloriInLista( e.Node.Text,  x => x.Utilizare);
					break;
				}
			else if (e.Node.Level == 2)
				incarcaFloriInLista((Floare)e.Node.Tag);
		}
		
        private void FloareDialog_Load(object sender, EventArgs e)
        {

        }

        private void checkBoxSetariAvansate_CheckedChanged(object sender, EventArgs e)
        {
			Console.WriteLine("checkBoxSetariAvansate_CheckedChanged");
			CheckBox checkBox = (CheckBox) sender;
			if (checkBox.Checked)
				groupBoxSetariAvansate.Show();
			else
				groupBoxSetariAvansate.Hide();
        }

        private void radioButtonDupaUtilizare_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton radioButton = (RadioButton) sender;
			if (radioButton.Checked) floareSet.SelectMetoda = SelectMetoda.DupaUtilizare;
			IncarcaFloriInArbore();
		}
        private void radioButtonDupaClasa_CheckedChanged(object sender, EventArgs e)
        {
			RadioButton radioButton = (RadioButton) sender;
			if (radioButton.Checked) floareSet.SelectMetoda = SelectMetoda.DupaClasa;
			IncarcaFloriInArbore();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
