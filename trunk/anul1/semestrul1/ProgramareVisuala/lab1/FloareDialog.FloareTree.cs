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
				var categorieNode = new TreeNode(groupby(floare).ToString());
				treeNode.Nodes.Add(categorieNode);
				foreach (Floare ifloare in floareSet.Flori.Where(g => groupby(g).ToString() == groupby(floare).ToString()))
				{
					TreeNode node = categorieNode.Nodes.Add(ifloare.Denumire);
					node.Tag = ifloare;
				}
			}
			treeNode.Expand();
		}

    }
}
