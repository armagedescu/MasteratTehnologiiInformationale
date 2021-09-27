using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1Tablouri1D
{
    public partial class ModelChanger : Form
    {
        public ModelChanger()
        {
            InitializeComponent();
        }
        public ModelChanger(SortModel model)
        {
            InitializeComponent();
            this.model = model;
            model.OnChange += reloadData;
            reloadData();
        }

        SortModel model { get; set; }
        void reloadData()
        {
            textFrom.Text = model.from.ToString();
            textTo.Text = model.to.ToString();
            textSize.Text = model.arr.Length.ToString();
            listArray.Items.Clear();
            for (int i = 0; i < model.arr.Length; i++)
                listArray.Items.Add(new ListViewItem(new[] { model.arr[i].ToString() }));

        }

        private void listArray_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (!model.ValidateArrValue(e.Label))
            {
                e.CancelEdit = true;
                return;
            }
            model.setItem(e.Item, int.Parse(e.Label));
            listArray.Items[e.Item].Selected = true;
            listArray.Items[e.Item].Focused = true;
        }

        private void textFrom_TextChanged(object sender, EventArgs e)
        {
            if (!model.ValidateFrom(textFrom.Text)) return;
            model.from = int.Parse(textFrom.Text);
        }

        private void textTo_TextChanged(object sender, EventArgs e)
        {
            if (!model.ValidateTo(textTo.Text)) return;
            model.to = int.Parse(textTo.Text);
        }

        private void textSize_TextChanged(object sender, EventArgs e)
        {
            if (!model.ValidateSize(textSize.Text)) return;
            model.Realloc(int.Parse(textSize.Text));
            reloadData();
        }

        private void textFrom_Validating(object sender, CancelEventArgs e)
        {
            if (!model.ValidateFrom(textFrom.Text)) e.Cancel = true;
            else reloadData();
        }

        private void textTo_Validating(object sender, CancelEventArgs e)
        {
            if (!model.ValidateTo(textTo.Text)) e.Cancel = true;
            else reloadData();
        }

        private void textSize_Validating(object sender, CancelEventArgs e)
        {
            if (!model.ValidateSize(textSize.Text)) e.Cancel = true;
        }

        private void listArray_KeyUp(object sender, KeyEventArgs e)
        {
            if (listArray.SelectedItems.Count <= 0) return;
            int selectedIndex = listArray.SelectedItems[0].Index;
            Keys key = (Keys)e.KeyValue;
            switch (key)
            {
                case Keys.Delete:
                    if (!model.ValidateSize(listArray.Items.Count - 1)) return;
                    listArray.Items.Remove(listArray.SelectedItems[0]);
                    onItemDeleted();
                    Console.WriteLine("delete");
                    break;
                case Keys.Insert:
                    listArray.Items.Insert(listArray.SelectedItems[0].Index, model.Build().ToString());
                    onItemInserted();
                    break;
                case Keys.F2:
                    listArray.Items[listArray.SelectedItems[0].Index].BeginEdit();
                    break;
                case Keys.A:
                    listArray.Items.Add(model.Build().ToString()).BeginEdit();
                    onItemInserted();
                    break;
            }
            if (selectedIndex < listArray.Items.Count)
            {
                listArray.Items[selectedIndex].Selected = true;
                listArray.Items[selectedIndex].Focused = true;
            }
        }
        void onItemDeleted()
        {
            int[] arr = new int[listArray.Items.Count];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = int.Parse(listArray.Items[i].SubItems[0].Text);
            model.arr = arr;
            model.Reinit();
            textSize.Text = listArray.Items.Count.ToString();
        } 
        void onItemInserted()
        {
            int[] arr = new int[listArray.Items.Count];
            for (int i = 0; i < arr.Length; i++)
                arr[i] = int.Parse(listArray.Items[i].SubItems[0].Text);
            model.arr = arr;
            model.Reinit();
            textSize.Text = listArray.Items.Count.ToString();
        }

        private void ModelChanger_FormClosing(object sender, FormClosingEventArgs e)
        {
            model.OnChange -= reloadData;
        }
    }
}
