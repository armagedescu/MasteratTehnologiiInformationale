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

        private void pictureBoxFloare_Click(object sender, EventArgs e)
        {
            if (listViewFlori.SelectedItems.Count <= 0) return;


            Floare floare = (Floare)listViewFlori.SelectedItems[0].Tag;

            //MessageBox.Show("click");
            MouseEventArgs me = (MouseEventArgs) e;
            if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = ".";
                openFileDialog1.Filter = "jpeg files (*.jpg)|*.jpg|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxFloare.Image = new Bitmap(openFileDialog1.FileName);
                    
                    //pictureBoxFloare.AutoScrollOffset.X = 100;
                    //pictureBoxFloare.Location = new Point(20, 100);
                    //Console.WriteLine(openFileDialog1.FileName);
                    
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
            Size sz = pictureBoxFloare.Size;
            Point location = pictureBoxFloare.Location;
            Console.WriteLine("wheel: " + e.Delta);
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                Console.WriteLine("Wheel:Ctrl!");
                //pictureBoxFloare.Size = 
                sz.Height = (int)((float)sz.Height * (float)(e.Delta + (e.Delta > 0 ? 5 : -5)) / 120);
                sz.Width *= (int)((float)sz.Width * (float)(e.Delta + (e.Delta > 0 ? 5 : -5)) / 120);
                pictureBoxFloare.Size = sz;
                pictureBoxFloare.Location = location;
            }
            //MessageBox.Show("wheel");
        }

        private void pictureBoxFloare_MouseEnter(object sender, EventArgs e)
        {
            //pictureBoxFloare.Capture = true;
            pictureBoxFloare.Focus();
        }

        private void pictureBoxFloare_MouseLeave(object sender, EventArgs e)
        {
            //pictureBoxFloare.Capture = false;
            this.ActiveControl = null;
        }

        private void tabPageDetaliiFloare_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void pictureBoxFloare_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                pictureBoxFloare.Left = e.X + pictureBoxFloare.Left - MouseDownLocation.X;
                pictureBoxFloare.Top = e.Y + pictureBoxFloare.Top - MouseDownLocation.Y;
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
    }
}
