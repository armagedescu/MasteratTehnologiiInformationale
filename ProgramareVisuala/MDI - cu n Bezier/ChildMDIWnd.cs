using System;
using System.Windows.Forms;
using System.Drawing;
//Declarãm clasa ferestrei MDI fiu
class ChildMDIWnd : Form
{
    Image m_Image;
    String m_FileName;
    PictureBox m_PictureBox;

    int N;

    float cpx;
    float cpy;
    int maxx;
    int maxy;

    int mpx;
    int mpy;

    Point[] p;

    private ContextMenu m_ContextMenu;


    //Constructorul ferestrei de reprezentare
    public ChildMDIWnd()
    {
        AutoScroll = true;
        m_PictureBox = new PictureBox();
        m_PictureBox.Location = new System.Drawing.Point(0, 0);
        m_PictureBox.Size = new System.Drawing.Size(0, 0);
        m_PictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
        SetImage(null);
        Controls.Add(m_PictureBox);

        m_ContextMenu = new ContextMenu();
        //m_ContextMenu.Popup += new EventHandler(ContextMenu_Popup);
        this.ContextMenu = m_ContextMenu;

        MenuItem ContextMenuOpen = new MenuItem("Open",
            new EventHandler(MenuOpen_OnClick));
        m_ContextMenu.MenuItems.Add(ContextMenuOpen);


        this.MouseMove += new MouseEventHandler(My_MouseMove);
        
        N = 13;

        p = new Point[N];

        for (int i = 0; i < N; i++)
        {
            p[i].X = 50 + i * 50;
            p[i].Y = 200;
        }

        maxx = this.ClientRectangle.Width - 1;
        maxy = this.ClientRectangle.Height - 1;

        cpx = maxx * 0.5f;
        cpy = maxy * 0.5f;

        mydraw(); 

    }


    public void SetImage(String FileName)
    {
        if (FileName != null)
        {
            m_FileName = new String(FileName.ToCharArray());
            m_Image = Image.FromFile(FileName);
        }
        else
        {
            m_FileName = "untitled";
            m_Image = null;
        }
        m_PictureBox.Image = m_Image;
        Text = m_FileName;
    }

    //private void ContextMenu_Popup(Object sender, EventArgs e)
    //{
    //    MenuItem ContextMenuOpen = new MenuItem("Open",
    //        new EventHandler(MenuOpen_OnClick));
    //    m_ContextMenu.MenuItems.Clear();
    //   m_ContextMenu.MenuItems.Add(ContextMenuOpen);
    // }


    private void MenuOpen_OnClick(Object sender, EventArgs e)
    {

        OpenFileDialog openFileDialog = new OpenFileDialog();
        //În cazul când valoarea este true, pentru obþinerea denumirilor
        //ale fiºierelor trebuie sã utilizãm proprietatea FileNames
        openFileDialog.Multiselect = false;
        openFileDialog.Filter = "bmp files (*.bmp)|*.bmp|jpg files (*.jpg)|*.jpg";
        openFileDialog.FilterIndex = 1;
        if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            this.SetImage(openFileDialog.FileName);
//            ChildWnd.Show();
        openFileDialog.Dispose();
    }
    float f(int n)
    {
        long factorial = 1;
        for (int i = 2; i <= n; i++)
        {
            factorial *= i; 
        }
        return (float) factorial;
    }
    float combinatii(int n, int i)
    {
        return f(n)/f(i)/f(n-i);
    }

    float B(int n, int i, float t)
    {
        return combinatii(n, i) * (float)Math.Pow(t, i) * (float)Math.Pow(1 - t, n - i);
    }

    void MyBeziern(Pen pen, Point[] p, int np)
    {

        Graphics g = Graphics.FromHwnd(this.Handle);

        float x1, y1, x2, y2;
        float t;
        float step = 1/(float)(np - 1);
        x1 = p[0].X;
        y1 = p[0].Y;
        float b;

        for (t = step; t < 1.0f + step; t+=step)
        {
            if (t < 1.0f)
            {
                x2 = 0;
                y2 = 0;
                for (int i = 0; i < N; i++)
                {
                    b = B(N - 1, i, t);
                    x2 += p[i].X * b;
                    y2 += p[i].Y * b;
                }
                
                
            }
            else
            {
                x2 = p[N - 1].X;
                y2 = p[N - 1].Y;
            }
            g.DrawLine(pen, x1, y1, x2, y2);
            x1 = x2;
            y1 = y2;
            
        }
    
    }




    private void mydraw()
    {
        if (maxx > 40 && maxy > 40)
        {
            Graphics g = Graphics.FromHwnd(this.Handle);

            int i;

            Brush myTextBrush;
            Pen myPen;
            Font myFont;

            // Chenar
            myPen = new Pen(Color.Blue, 1);
            g.DrawRectangle(myPen, 0, 0, maxx, maxy);

            // Antet
            myTextBrush = new SolidBrush(Color.FromArgb(128, 255, 0));
            myFont = new Font("Courier New", 16.0f, FontStyle.Bold);
            g.DrawString("B E Z I E R", myFont, myTextBrush, cpx - 100.0f, 1.0f);

            Brush myBrush = new SolidBrush(Color.Black);
            Pen myBezierPen = new Pen(Color.Red, 2);

            myPen = new Pen(Color.Black, 1);
            myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            for (i = 0; i < N - 1; i++)
                g.DrawLine(myPen, p[i].X, p[i].Y, p[i + 1].X, p[i + 1].Y);

            for (i = 0; i < N; i++)
            {
                g.FillEllipse(myBrush, p[i].X - 2, p[i].Y - 2, 5, 5);
            }

            MyBeziern(myBezierPen, p, 50);
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        mydraw();
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);

        maxx = this.ClientRectangle.Width - 1;
        maxy = this.ClientRectangle.Height - 1;

        cpx = maxx * 0.5f;
        cpy = maxy * 0.5f;

        Invalidate();
    }

    private void My_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            mpx = e.X;
            mpy = e.Y;
            int i;
            bool found = false;

            for (i = 0; (i < N) && !found; i++)
                if (Math.Abs(mpx - p[i].X) < 20 && Math.Abs(mpy - p[i].Y) < 20)
                {
                    p[i].X = mpx;
                    p[i].Y = mpy;
                    found = true;
                    Invalidate();
                }
        }
    }

}
