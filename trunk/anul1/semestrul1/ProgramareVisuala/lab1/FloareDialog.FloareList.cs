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
            listViewFlori.Items.Add(
                new ListViewItem(
                    new[] 
                    {
                        floare.Denumire, floare.ClasaBiologica, floare.Utilizare 
                    })).Tag = floare;
		}
		void incarcaFloriInLista(Floare floare)
		{
            incarcaFloriInLista(new[] { floare });
        }
		void incarcaFloriInLista(IEnumerable<Floare> flori)
		{
			listViewFlori.Items.Clear();
			foreach (Floare floare in flori) adaugaFloareLista(floare);
		}
		void incarcaFloriInLista<TKey>(string categorie, Func<Floare, TKey> groupby)
		{
			incarcaFloriInLista(FloareModel.Flori.Where(f => !f.Sters).Where(g => groupby(g).Equals(categorie)));
		}

    }
}
