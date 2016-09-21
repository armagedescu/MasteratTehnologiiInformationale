using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

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
            InitializeComponent();
			
            this.FloareModel = floareModel;

			this.treeViewFlori.AfterSelect += this.TreeViewFlori_AfterSelect;
			this.checkBoxSetariAvansate.CheckedChanged += this.checkBoxSetariAvansate_CheckedChanged;
            this.pictureBoxFloare.MouseWheel += this.pictureBoxFloare_MouseWheel;


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
                    if (listViewFlori.SelectedItems.Count > 0)
                    {
                        pictureBoxFloare.Image = null;
                        Floare floare = (Floare)listViewFlori.SelectedItems[0].Tag;
                        floare.Sters = true;
                        listViewFlori.Items.Remove(listViewFlori.SelectedItems[0]);
                    }

                    break;
            }
        }
        void clearFloareControls()
        {
            floareClear();
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

        private void pictureBoxFloare_Click(object sender, EventArgs e)
        {
            if (listViewFlori.SelectedItems.Count <= 0) return;
            Floare floare = (Floare)listViewFlori.SelectedItems[0].Tag;

            MouseEventArgs me = (MouseEventArgs) e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                OpenFileDialog openFloareDialog = new OpenFileDialog();

                openFloareDialog.InitialDirectory = ".";
                openFloareDialog.Filter = "jpeg files (*.jpg)|*.jpg|All files (*.*)|*.*";
                openFloareDialog.FilterIndex = 2;
                openFloareDialog.RestoreDirectory = true;

                if (openFloareDialog.ShowDialog() == DialogResult.OK)
                {
                    imageClear();
                    floare.Imagine = new Imagine()
                    {
                        SystemPath = openFloareDialog.FileName,
                        Location = pictureBoxFloare.Location,
                        Size = pictureBoxFloare.Size
                    };


                    pictureBoxFloare.Image = FloareModel.GetImage(floare.Imagine);
                }
            }
            if (me.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Console.WriteLine(Guid.NewGuid());
            }
        }

        private void pictureBoxFloare_DragDrop(object sender, DragEventArgs e)
        {

        }
        private void pictureBoxFloare_MouseWheel(object sender, MouseEventArgs e)
        {
            if (listViewFlori.SelectedItems.Count <= 0) return;
            Floare floare = (Floare)listViewFlori.SelectedItems[0].Tag;

            Size sz = pictureBoxFloare.Size;
            Console.WriteLine("wheel: " + e.Delta);
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                Console.WriteLine("Wheel:Ctrl!");
                sz.Height = (int)((float)sz.Height * (float)(1f + .05f * (e.Delta / 120f)));
                sz.Width = (int)((float)sz.Width * (float)(1f + .05f * (e.Delta / 120f)));
                pictureBoxFloare.Size = sz;
                floare.Imagine.Size = pictureBoxFloare.Size;
            }

        }

        private void pictureBoxFloare_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxFloare.Focus();
        }

        private void pictureBoxFloare_MouseLeave(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void tabPageDetaliiFloare_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void pictureBoxFloare_MouseMove(object sender, MouseEventArgs e)
        {
            if (listViewFlori.SelectedItems.Count <= 0) return;
            Floare floare = (Floare)listViewFlori.SelectedItems[0].Tag;
            if (floare.Imagine == null) return;
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pictureBoxFloare.Left = e.X + pictureBoxFloare.Left - MouseDownLocation.X;
                pictureBoxFloare.Top = e.Y + pictureBoxFloare.Top - MouseDownLocation.Y;
                floare.Imagine.Location = pictureBoxFloare.Location;
            }
        }
        private Point MouseDownLocation;
        private void pictureBoxFloare_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void listViewFlori_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (!e.IsSelected)
            {
                floareClear();
                return;
            }
            Floare floare = (Floare)e.Item.Tag;
            floareToForm(floare);
        }
        void floareToForm(Floare floare)
        {
            textBoxDenumire.Text = floare.Denumire;
            comboTulpina.Text = floare.Tulpina.ToString();
            textBoxNumarDePetale.Text = floare.NumarDePetale.ToString();
            textBoxUtilizare.Text = floare.Utilizare;
            textBoxClasaBiologica.Text = floare.ClasaBiologica;
            textBoxDenumireStiintifica.Text = floare.DenumireStiintifica;
            comboBoxLongevitate.Text = floare.Longevitate.ToString();
            comboBoxRamificatie.Text = floare.Ramificare.ToString();
            textBoxPret.Text = floare.Pret.ToString();
            textBoxLungimeMaxima.Text = floare.LungimeMaxima.ToString();
            textBoxLungimeMedie.Text = floare.LungimeMedie.ToString();
            floareToImage(floare);
        }
        public static object ParseEnum<T>(string value)
        {
            try { return Enum.Parse(typeof(T), value, true); }
            catch(Exception){return null;}
        }
        void formToFloare()
        {
            Console.WriteLine("save");
            if (listViewFlori.SelectedItems.Count <= 0) return;
            formToFloare((Floare)listViewFlori.SelectedItems[0].Tag);
        }
        void formToFloare(Floare floare)
        {
            floare.Denumire = textBoxDenumire.Text;
            floare.Tulpina = (Tulpina?)ParseEnum<Tulpina>(comboTulpina.Text);;
            floare.NumarDePetale = int.Parse("0" + textBoxNumarDePetale.Text);
            floare.Utilizare = textBoxUtilizare.Text;
            floare.ClasaBiologica = textBoxClasaBiologica.Text;
            floare.DenumireStiintifica = textBoxDenumireStiintifica.Text;
            floare.Longevitate = (Longevitate?)ParseEnum<Longevitate> (comboBoxLongevitate.Text);
            floare.Ramificare = (Ramificare?) ParseEnum<Ramificare> (comboBoxRamificatie.Text);
            floare.Pret = float.Parse("0" + textBoxPret.Text, CultureInfo.InvariantCulture.NumberFormat); ;
            floare.LungimeMaxima = int.Parse("0" + textBoxLungimeMaxima.Text);
            floare.LungimeMedie = int.Parse("0" + textBoxLungimeMedie.Text);
            //floareToImage(floare);
        }
        void floareToImage(Floare floare)
        {
            imageClear();
            if (floare == null || floare.Imagine == null) return;

            pictureBoxFloare.Image = FloareModel.GetImage(floare);
            pictureBoxFloare.Location = floare.Imagine.Location;
            pictureBoxFloare.Size = floare.Imagine.Size;
        }
        void floareClear()
        { 
            textBoxDenumire.Text = "";
            comboTulpina.Text = "";
            textBoxNumarDePetale.Text = "";
            textBoxUtilizare.Text = "";
            textBoxClasaBiologica.Text = "";
            textBoxDenumireStiintifica.Text = "";
            comboBoxLongevitate.Text = "";
            comboBoxRamificatie.Text = "";
            textBoxPret.Text = "";
            textBoxLungimeMaxima.Text = "";
            textBoxLungimeMedie.Text = "";
            imageClear();
        }
        void imageClear()
        {
            pictureBoxFloare.Image = null;
            pictureBoxFloare.Location = new Point(0, 0);
            pictureBoxFloare.Size = new Size(panelFloare.Width, panelFloare.Height);
        }



        private void FloareDialog_KeyDown(object sender, KeyEventArgs e)
        {
            
            switch (e.KeyCode)
            { 
                case Keys.Escape:
                    Dispose();
                    break;
                case Keys.S:
                    if (ModifierKeys.HasFlag(Keys.Control))
                        formToFloare();
                    break;
            }
        }


    }
}
