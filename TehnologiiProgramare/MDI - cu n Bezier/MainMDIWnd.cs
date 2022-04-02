using System;
using System.Windows.Forms;
using System.Drawing;
class MainMDIWnd : Form
{

    private MainMenu m_MainMenu;

    private MenuItem m_MenuFile;
    private MenuItem m_MenuFileNew;
    private MenuItem m_MenuFileOpen;
    private MenuItem m_MenuFileClose;
    private MenuItem m_MenuFileExit;

    private MenuItem m_MenuWindow;
    private MenuItem m_MenuWindowCascade;
    private MenuItem m_MenuWindowHorizontally;
    private MenuItem m_MenuWindowVertically;

    public MainMDIWnd()
    {
        //Setãm textul în antetul ferestrei
        Text = "Multiple Document Interface Application";
        //Setãm poziþia iniþialã ºi dimensiunea ferestrei implicite
        StartPosition = FormStartPosition.WindowsDefaultBounds;
        IsMdiContainer = true;

        m_MainMenu = new MainMenu();

        m_MenuFile = new MenuItem("&File");

        m_MenuFileNew = new MenuItem("&New", new EventHandler(MenuFileNew_OnClick));
        m_MenuFileNew.Shortcut = Shortcut.CtrlN;
        //        m_MenuFileNew.ShowShortcut = false;

        m_MenuFileOpen = new MenuItem("&Open...");
        m_MenuFileOpen.Click += new EventHandler(MenuFileOpen_OnClick);
        m_MenuFileOpen.Shortcut = Shortcut.CtrlO;
        m_MenuFileOpen.ShowShortcut = true;

        m_MenuFileClose = new MenuItem("&Close", new EventHandler(MenuFileClose_OnClick));

        m_MenuFileExit = new MenuItem("E&xit", new EventHandler(MenuFileExit_OnClick));


        m_MenuFile.MenuItems.Add(m_MenuFileNew);
        m_MenuFile.MenuItems.Add("-");

        m_MenuFile.MenuItems.Add(m_MenuFileOpen);
        m_MenuFile.MenuItems.Add("-");

        m_MenuFile.MenuItems.Add(m_MenuFileClose);

        m_MenuFile.MenuItems.Add("-");
        m_MenuFile.MenuItems.Add(m_MenuFileExit);


        m_MenuWindow = new MenuItem("&Window");
        //m_MenuWindow.MdiList = true;
        m_MenuWindowCascade = new MenuItem("&Cascade", new EventHandler(MenuWindowCascade_OnClick));
        m_MenuWindowHorizontally = new MenuItem("&Horizontally", new EventHandler(MenuWindowHorizontally_OnClick));
        m_MenuWindowVertically = new MenuItem("&Vertically", new EventHandler(MenuWindowVertically_OnClick));
        m_MenuWindow.MenuItems.Add(m_MenuWindowCascade);
        m_MenuWindow.MenuItems.Add(m_MenuWindowHorizontally);
        m_MenuWindow.MenuItems.Add(m_MenuWindowVertically);

        m_MainMenu.MenuItems.Add(m_MenuFile);
        m_MainMenu.MenuItems.Add(m_MenuWindow);

        Menu = m_MainMenu;

    }


    private void MenuFileNew_OnClick(Object sender, EventArgs e)
    {
        ChildMDIWnd ChildWnd = new ChildMDIWnd();
        ChildWnd.MdiParent = this;
        ChildWnd.Show();
    }

    private void MenuFileOpen_OnClick(Object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        //În cazul când valoarea este true, pentru obþinerea denumirilor
        //ale fiºierelor trebuie sã utilizãm proprietatea FileNames
        openFileDialog.Multiselect = false;
        openFileDialog.Filter =
        "bmp files (*.bmp)|*.bmp|jpg files (*.jpg)|*.jpg";
        openFileDialog.FilterIndex = 1;
        if (openFileDialog.ShowDialog(this) == DialogResult.OK)
        {
            ChildMDIWnd ChildWnd = new ChildMDIWnd();
            ChildWnd.MdiParent = this;
            ChildWnd.SetImage(openFileDialog.FileName);
            ChildWnd.Show();
        }
        openFileDialog.Dispose();
    }

    private void MenuFileClose_OnClick(Object sender, EventArgs e)
    {
        if (ActiveMdiChild != null)
        {
            //ChildMDIWnd ChildWnd = (ChildMDIWnd)ActiveMdiChild;
            //ChildWnd.Close();
            ((ChildMDIWnd)ActiveMdiChild).Close();
        }
    }

    private void MenuFileExit_OnClick(Object sender, EventArgs e)
    {
        //Metoda Exit a clasei Application informeazã pe toate cozile de mesaje
        //ca trebuie sã se opreascã ºi apoi, dupã ce toate mesajele
        //vor fi prelucrate, închide pe toate ferestre ale aplicaþiei
        Application.Exit();
    }


    private void MenuWindowCascade_OnClick(Object sender, EventArgs e)
    {
        LayoutMdi(MdiLayout.Cascade); 
    }

    private void MenuWindowHorizontally_OnClick(Object sender, EventArgs e)
    { LayoutMdi(MdiLayout.TileHorizontal); }

    private void MenuWindowVertically_OnClick(Object sender, EventArgs e)
    { LayoutMdi(MdiLayout.TileVertical); }



}
