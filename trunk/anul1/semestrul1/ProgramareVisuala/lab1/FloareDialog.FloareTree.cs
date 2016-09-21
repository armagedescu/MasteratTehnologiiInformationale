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
            IncarcaFloriInArbore(floareSelector[FloareModel.SelectMetoda]);
		}
        void IncarcaFloriInArbore<TKey>(Func<Floare, TKey> groupby)
		{
            clearFloareControls();
            TreeNode treeNode = treeViewFlori.Nodes.Add("Toate Florile");

			foreach (Floare floare in FloareModel.Flori.Where(f => !f.Sters).GroupBy(groupby).Select(x => x.First())  )
			{
                var categorieNode = treeNode.Nodes.Add(groupby(floare).ToString());
                foreach (Floare ifloare in FloareModel.Flori.Where(f => !f.Sters).Where(g => groupby(g).Equals(groupby(floare))))
                    categorieNode.Nodes.Add(ifloare.Denumire).Tag = ifloare;
			}
			treeNode.Expand();
		}

    }
}
