using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1Tablouri1D
{
    public partial class SortForm : Form
    {
        public SortForm()
        {
            InitializeComponent();
        }
        public SortForm(SortModel model) : this ()
        {
            this.model = model;
            this.model.OnChange += reloadData;

            this.model.sorter[0].onAfterCmp += (s, a, b, result) => { drawAfterCmp(pictureBubbleSort,    s, a, b, result); };
            this.model.sorter[1].onAfterCmp += (s, a, b, result) => { drawAfterCmp(pictureSelectionSort, s, a, b, result); };
            this.model.sorter[2].onAfterCmp += (s, a, b, result) => { drawAfterCmp(pictureInsertionSort, s, a, b); };
        }
        public SortModel model { get; set; }

        void reloadData()
        {
            drawArrayDefault(pictureBubbleSort,    model.sorter[0]);
            drawArrayDefault(pictureSelectionSort, model.sorter[1]);
            drawArrayDefault(pictureInsertionSort, model.sorter[2]);
        }
        void drawAfterCmp(PictureBox box, Sorter<int> s, int a, int b, bool result)
        {
            Rectangle rc = new Rectangle(0, 0, box.Width, box.Height);
            Bitmap buffer = new Bitmap(rc.Width, rc.Height);
            Graphics g = Graphics.FromImage(buffer);

            Pen penBlue = new Pen(Color.Blue, 1);
            Pen penWhite = new Pen(Color.White, 1);
            Pen penOrange = new Pen(Color.Orange, 1);
            int width = rc.Width - 2;
            int height = rc.Height - 2;

            g.Clear(box.BackColor);
            g.DrawRectangle(penBlue, 1, 1, width, height);

            float w1 = (float)width / s.Length;
            int max = s.Mex((t1, t2) => t1 > t2);

            float coef = (float)height / max;
            Matrix matrix = new Matrix(1f, 0f, 0f, -1f, 0f, rc.Height);
            //matrix.Scale(w1, coef);
            g.Transform = matrix;

            for (int i = 0; i < s.Length; i++)
            {
                if (i == a || i == b)
                {
                    if (result)
                        g.DrawRectangle(penOrange, i * w1 + 1, 1, w1, coef * s[i]);
                    else
                        g.DrawRectangle(penWhite, i * w1 + 1, 1, w1, coef * s[i]);
                }
                else
                    g.DrawRectangle(penBlue, i * w1 + 1, 1, w1, coef * s[i]);
            }
            box.Invoke(new DrawDelegate(drawGraphic), new object[] { box, buffer });
            if (result)
                Thread.Sleep(200);
            else
                Thread.Sleep(10);
        }
        void drawAfterCmp(PictureBox box, Sorter<int> s, int a, int b)
        {
            Rectangle rc = new Rectangle(0, 0, box.Width, box.Height);
            Bitmap buffer = new Bitmap(rc.Width, rc.Height);
            Graphics g = Graphics.FromImage(buffer);

            Pen penBlue = new Pen(Color.Blue, 1);
            Pen penOrange = new Pen(Color.Orange, 1);
            int width = rc.Width - 2;
            int height = rc.Height - 2;


            g.Clear(box.BackColor);
            g.DrawRectangle(penBlue, 1, 1, width, height);

            float w1 = (float)width / s.Length;
            int max = s.Mex((t1, t2) => t1 > t2);

            float coef = (float)height / max;
            Matrix matrix = new Matrix(1f, 0f, 0f, -1f, 0f, rc.Height);
            //matrix.Scale(w1, coef);
            g.Transform = matrix;

            for (int i = 0; i < s.Length; i++)
            {
                if (i == a || i == b)
                    g.DrawRectangle(penOrange, i * w1 + 1, 1, w1, coef * s[i]);
                else
                    g.DrawRectangle(penBlue, i * w1 + 1, 1, w1, coef * s[i]);
            }
            box.Invoke(new DrawDelegate(drawGraphic), new object[] { box, buffer });
            Thread.Sleep(70);
        }
        delegate void DrawDelegate(PictureBox box, Bitmap buffer);
        void drawGraphic(PictureBox box, Bitmap buffer)
        {
            Graphics g = Graphics.FromHwnd(box.Handle);
            g.DrawImageUnscaled(buffer, 0, 0);
        }


        private void drawArrayDefault(PictureBox box, Sorter<int> sorter)
        {
            Graphics g = Graphics.FromHwnd(box.Handle);
            Rectangle rc = new Rectangle(0, 0, box.Width, box.Height);
            Bitmap buffer = new Bitmap(rc.Width, rc.Height);
            Graphics gb = Graphics.FromImage(buffer);

            drawArrayDefault(gb, rc, sorter);
            //g.DrawImageUnscaled(buffer, 0, 0);
            box.Invoke(new DrawDelegate(drawGraphic), new object[] { box, buffer });
        }
        private void drawArrayDefault (Graphics g, Rectangle rc, Sorter<int> sorter)
        {
            Pen myPen = new Pen(Color.Blue, 1);
            int width = rc.Width - 2;
            int height = rc.Height - 2;

            g.Clear(pictureBubbleSort.BackColor);
            g.DrawRectangle(myPen, 1, 1, width, height);

            float w1 = (float)width / sorter.Length;
            int max = sorter.Mex((a, b) => a > b);

            float coef = (float)height / max;
            Matrix matrix = new Matrix(1f, 0f, 0f, -1f, 0f, rc.Height);
            //matrix.Scale(w1, coef);
            g.Transform = matrix;

            for (int i = 0; i < sorter.Length; i++)
            {
                g.DrawRectangle(myPen, i * w1 + 1, 1, w1, coef * sorter[i]);
                //e.Graphics.DrawRectangle(myPen, (float)i, 1f, 0.01f, (float)s1[i]);
            }
        }

        private void pictureBubbleSort_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            drawArrayDefault(e.Graphics, e.ClipRectangle, model.sorter[0]);
        }
        private void pictureSelectionSort_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            drawArrayDefault(e.Graphics, e.ClipRectangle, model.sorter[1]);
        }
        private void pictureInsertionSort_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            drawArrayDefault(e.Graphics, e.ClipRectangle, model.sorter[2]);
        }

        private void sortAsc_Click(object sender, EventArgs e)
        {
            model.Autosort((a, b) => a < b);
        }
        private void sortDesc_Click(object sender, EventArgs e)
        {
            model.Autosort((a, b) => a > b );
        }
        private void btnReinit_Click(object sender, EventArgs e)
        {
            model.Reinit();
            drawArrayDefault(pictureBubbleSort,    model.sorter[0]);
            drawArrayDefault(pictureInsertionSort, model.sorter[1]);
            drawArrayDefault(pictureSelectionSort, model.sorter[2]);
        }

        private void SortForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            model.OnChange -= reloadData;
            try { model.Stop(); } catch (Exception) { }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            (new ModelChanger(model)).ShowDialog();
        }
    }
}
