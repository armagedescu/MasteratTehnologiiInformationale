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
		enum SelectMetoda{DupaClasa};
		SelectMetoda selectMetoda = SelectMetoda.DupaClasa;
        public FloareDialog(FloareSet _floareSet, MainApp _mainApp)
        {
			this.floareSet = _floareSet;
			this.mainApp = _mainApp;
            InitializeComponent();
			IncarcaFloriInArobreDupaClasa();
        }
		void IncarcaFloriInArobreDupaClasa()
		{
			treeViewFlori.Nodes.Clear();
			TreeNode treeNode = new TreeNode("Toate Florile");
			treeViewFlori.Nodes.Add(treeNode);

			foreach (Floare floare in floareSet.Flori.GroupBy(g => g.ClasaBiologica).Select(x => x.First()) )
			{
				var clasaNode = new TreeNode(floare.ClasaBiologica);
				treeNode.Nodes.Add(clasaNode);
				//foreach (string denumire in floareSet.Flori.Where(g => g.ClasaBiologica == floare.ClasaBiologica).Select(x => x.Denumire))
				foreach (Floare ifloare in floareSet.Flori.Where(g => g.ClasaBiologica == floare.ClasaBiologica).Select(x => x))
				{
					TreeNode node = clasaNode.Nodes.Add(ifloare.Denumire);
					node.Tag = ifloare;
				}
			}
			treeNode.Expand();
		}
		private void TreeViewFlori_AfterSelect(System.Object sender, 
			System.Windows.Forms.TreeViewEventArgs e)
		{
			Console.WriteLine("clicked: " + e.Node.Text + "; Level: " + e.Node.Level);
			if (e.Node.Level == 0)
				incarcaToateFlorile();
			else if (e.Node.Level == 1)
			{
				//Console.WriteLine("clicked level 1" );
				switch (selectMetoda)
				{
				case SelectMetoda.DupaClasa:
					incarcaFloriDupaClasa( e.Node.Text );
					break;
				}
			}
			else if (e.Node.Level == 2)
			{
				incarcaFloareObiect((Floare)e.Node.Tag);
			}
		}
		void incarcaToateFlorile()
		{
			listViewFlori.Items.Clear();
			foreach (Floare floare in floareSet.Flori)
			{
				ListViewItem listItemView = new ListViewItem(new []{floare.Denumire, floare.ClasaBiologica});
				listViewFlori.Items.Add(listItemView);
			}
		}
		void incarcaFloareObiect(Floare floare)
		{
			listViewFlori.Items.Clear();
			ListViewItem listItemView = new ListViewItem(new []{floare.Denumire, floare.ClasaBiologica});
			listViewFlori.Items.Add(listItemView);
		}
		void incarcaFloriDupaClasa(string clasa)
		{
			listViewFlori.Items.Clear();
			foreach (Floare floare in floareSet.Flori.Where(g => g.ClasaBiologica == clasa).Select(x=>x))
			{
				ListViewItem listItemView = new ListViewItem(new []{floare.Denumire, floare.ClasaBiologica});
				listViewFlori.Items.Add(listItemView);
				Console.WriteLine("added " + floare.Denumire);
			}
			//listViewFlori
		}
        private void FloareDialog_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
