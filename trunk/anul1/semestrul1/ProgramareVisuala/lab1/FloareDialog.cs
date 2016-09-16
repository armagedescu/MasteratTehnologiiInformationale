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
			IncarcaFloriInArbore();
        }
		void IncarcaFloriInArbore()
		{
			switch (floareSet.SelectMetoda)
			{
			case SelectMetoda.DupaClasa:
				IncarcaFloriInArbore (x => x.ClasaBiologica);
				break;
			case SelectMetoda.DupaUtilizare:
				IncarcaFloriInArbore (x => x.Utilizare);
				break;
			}

		}
		void IncarcaFloriInArbore<TKey>(Func<Floare, TKey> groupby)
		{
			treeViewFlori.Nodes.Clear();
			TreeNode treeNode = new TreeNode("Toate Florile");
			treeViewFlori.Nodes.Add(treeNode);
			foreach (Floare floare in floareSet.Flori.GroupBy(groupby).Select(x => x.First())  )
			{
				var clasaNode = new TreeNode(groupby(floare).ToString());
				treeNode.Nodes.Add(clasaNode);
				foreach (Floare ifloare in floareSet.Flori.Where(g => groupby(g).ToString() == groupby(floare).ToString()))
				{
					TreeNode node = clasaNode.Nodes.Add(ifloare.Denumire);
					node.Tag = ifloare;
				}
			}
			treeNode.Expand();
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
				incarcaFloareLista((Floare)e.Node.Tag);
		}

		void adaugaFloareLista(Floare floare)
		{
			ListViewItem listItemView = new ListViewItem(new []{floare.Denumire, floare.ClasaBiologica, floare.Utilizare});
			listViewFlori.Items.Add(listItemView);
		}
		void incarcaFloareLista(Floare floare)
		{
			listViewFlori.Items.Clear();
			adaugaFloareLista(floare);
		}
		void incarcaFloriInLista(IEnumerable<Floare> flori)
		{
			listViewFlori.Items.Clear();
			foreach (Floare floare in flori) adaugaFloareLista(floare);
		}
		void incarcaFloriInLista<TKey>(string clasa, Func<Floare, TKey> groupby)
		{
			incarcaFloriInLista(floareSet.Flori.Where(g => groupby(g).ToString() == clasa).Select(x=>x));
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
