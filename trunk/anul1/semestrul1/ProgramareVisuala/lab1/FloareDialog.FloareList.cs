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
		void adaugaFloareLista(Floare floare)
		{
			ListViewItem listItemView = new ListViewItem(new []{floare.Denumire, floare.ClasaBiologica, floare.Utilizare});
			listItemView.Tag = floare;
			listViewFlori.Items.Add(listItemView);
		}
		void incarcaFloriInLista(Floare floare)
		{
			listViewFlori.Items.Clear();
			adaugaFloareLista(floare);
		}
		void incarcaFloriInLista(IEnumerable<Floare> flori)
		{
			listViewFlori.Items.Clear();
			foreach (Floare floare in flori) adaugaFloareLista(floare);
		}
		void incarcaFloriInLista<TKey>(string categorie, Func<Floare, TKey> groupby)
		{
			incarcaFloriInLista(floareSet.Flori.Where(g => groupby(g).ToString() == categorie));
		}

    }
}
