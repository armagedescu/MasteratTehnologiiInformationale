using System;
using System.Drawing;
using System.Windows.Forms;
namespace USM.ProgramareVisuala.Lab1
{
    partial class FloareDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
			FloareModel.saveFloareDb ();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeViewFlori = new System.Windows.Forms.TreeView();
            this.listViewFlori = new System.Windows.Forms.ListView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageDetaliiFloare = new System.Windows.Forms.TabPage();
            this.panelFloare = new System.Windows.Forms.Panel();
            this.pictureBoxFloare = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxPret = new System.Windows.Forms.TextBox();
            this.textBoxLungimeMaxima = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxLungimeMedie = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxLongevitate = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxRamificatie = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboTulpina = new System.Windows.Forms.ComboBox();
            this.textBoxNumarDePetale = new System.Windows.Forms.TextBox();
            this.textBoxUtilizare = new System.Windows.Forms.TextBox();
            this.textBoxClasaBiologica = new System.Windows.Forms.TextBox();
            this.textBoxDenumireStiintifica = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSetariAvansate = new System.Windows.Forms.GroupBox();
            this.buttonInchideFaraASalva = new System.Windows.Forms.Button();
            this.buttonReincarcaDinBaza = new System.Windows.Forms.Button();
            this.buttonReinitializeazaBaza = new System.Windows.Forms.Button();
            this.buttonRescrieBaza = new System.Windows.Forms.Button();
            this.checkBoxSetariAvansate = new System.Windows.Forms.CheckBox();
            this.textBoxDenumire = new System.Windows.Forms.TextBox();
            this.groupBoxAfisare = new System.Windows.Forms.GroupBox();
            this.radioButtonDupaUtilizare = new System.Windows.Forms.RadioButton();
            this.radioButtonDupaClasa = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonSalveazaOCopieCa = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageDetaliiFloare.SuspendLayout();
            this.panelFloare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFloare)).BeginInit();
            this.groupBoxSetariAvansate.SuspendLayout();
            this.groupBoxAfisare.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewFlori
            // 
            this.treeViewFlori.Location = new System.Drawing.Point(5, 5);
            this.treeViewFlori.Name = "treeViewFlori";
            this.treeViewFlori.Size = new System.Drawing.Size(345, 145);
            this.treeViewFlori.TabIndex = 0;
            // 
            // listViewFlori
            // 
            this.listViewFlori.FullRowSelect = true;
            this.listViewFlori.GridLines = true;
            this.listViewFlori.Location = new System.Drawing.Point(5, 156);
            this.listViewFlori.Name = "listViewFlori";
            this.listViewFlori.Size = new System.Drawing.Size(345, 339);
            this.listViewFlori.TabIndex = 1;
            this.listViewFlori.UseCompatibleStateImageBehavior = false;
            this.listViewFlori.View = System.Windows.Forms.View.Details;
            this.listViewFlori.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewFlori_ItemSelectionChanged);
            this.listViewFlori.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewFlori_KeyUp);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageDetaliiFloare);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(356, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(448, 483);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FloareDialog_KeyDown);
            // 
            // tabPageDetaliiFloare
            // 
            this.tabPageDetaliiFloare.Controls.Add(this.panelFloare);
            this.tabPageDetaliiFloare.Controls.Add(this.label12);
            this.tabPageDetaliiFloare.Controls.Add(this.label11);
            this.tabPageDetaliiFloare.Controls.Add(this.textBoxPret);
            this.tabPageDetaliiFloare.Controls.Add(this.textBoxLungimeMaxima);
            this.tabPageDetaliiFloare.Controls.Add(this.label10);
            this.tabPageDetaliiFloare.Controls.Add(this.textBoxLungimeMedie);
            this.tabPageDetaliiFloare.Controls.Add(this.label9);
            this.tabPageDetaliiFloare.Controls.Add(this.comboBoxLongevitate);
            this.tabPageDetaliiFloare.Controls.Add(this.label8);
            this.tabPageDetaliiFloare.Controls.Add(this.comboBoxRamificatie);
            this.tabPageDetaliiFloare.Controls.Add(this.label7);
            this.tabPageDetaliiFloare.Controls.Add(this.label6);
            this.tabPageDetaliiFloare.Controls.Add(this.label5);
            this.tabPageDetaliiFloare.Controls.Add(this.label4);
            this.tabPageDetaliiFloare.Controls.Add(this.label3);
            this.tabPageDetaliiFloare.Controls.Add(this.label2);
            this.tabPageDetaliiFloare.Controls.Add(this.comboTulpina);
            this.tabPageDetaliiFloare.Controls.Add(this.textBoxNumarDePetale);
            this.tabPageDetaliiFloare.Controls.Add(this.textBoxUtilizare);
            this.tabPageDetaliiFloare.Controls.Add(this.textBoxClasaBiologica);
            this.tabPageDetaliiFloare.Controls.Add(this.textBoxDenumireStiintifica);
            this.tabPageDetaliiFloare.Controls.Add(this.label1);
            this.tabPageDetaliiFloare.Controls.Add(this.groupBoxSetariAvansate);
            this.tabPageDetaliiFloare.Controls.Add(this.checkBoxSetariAvansate);
            this.tabPageDetaliiFloare.Controls.Add(this.textBoxDenumire);
            this.tabPageDetaliiFloare.Controls.Add(this.groupBoxAfisare);
            this.tabPageDetaliiFloare.Location = new System.Drawing.Point(4, 22);
            this.tabPageDetaliiFloare.Name = "tabPageDetaliiFloare";
            this.tabPageDetaliiFloare.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDetaliiFloare.Size = new System.Drawing.Size(440, 457);
            this.tabPageDetaliiFloare.TabIndex = 0;
            this.tabPageDetaliiFloare.Text = "Detaii Floare";
            this.tabPageDetaliiFloare.UseVisualStyleBackColor = true;
            this.tabPageDetaliiFloare.Click += new System.EventHandler(this.tabPageDetaliiFloare_Click);
            this.tabPageDetaliiFloare.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.tabPageDetaliiFloare_PreviewKeyDown);
            // 
            // panelFloare
            // 
            this.panelFloare.Controls.Add(this.pictureBoxFloare);
            this.panelFloare.Location = new System.Drawing.Point(296, 217);
            this.panelFloare.Name = "panelFloare";
            this.panelFloare.Size = new System.Drawing.Size(116, 110);
            this.panelFloare.TabIndex = 28;
            // 
            // pictureBoxFloare
            // 
            this.pictureBoxFloare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxFloare.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxFloare.Name = "pictureBoxFloare";
            this.pictureBoxFloare.Size = new System.Drawing.Size(108, 108);
            this.pictureBoxFloare.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFloare.TabIndex = 26;
            this.pictureBoxFloare.TabStop = false;
            this.pictureBoxFloare.Click += new System.EventHandler(this.pictureBoxFloare_Click);
            this.pictureBoxFloare.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBoxFloare_DragDrop);
            this.pictureBoxFloare.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFloare_MouseDown);
            this.pictureBoxFloare.MouseEnter += new System.EventHandler(this.pictureBoxFloare_MouseEnter);
            this.pictureBoxFloare.MouseLeave += new System.EventHandler(this.pictureBoxFloare_MouseLeave);
            this.pictureBoxFloare.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxFloare_MouseMove);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(232, 218);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 27;
            this.label12.Text = "Imagine";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(232, 194);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Pret";
            // 
            // textBoxPret
            // 
            this.textBoxPret.Location = new System.Drawing.Point(331, 191);
            this.textBoxPret.Name = "textBoxPret";
            this.textBoxPret.Size = new System.Drawing.Size(100, 20);
            this.textBoxPret.TabIndex = 24;
            // 
            // textBoxLungimeMaxima
            // 
            this.textBoxLungimeMaxima.Location = new System.Drawing.Point(331, 163);
            this.textBoxLungimeMaxima.Name = "textBoxLungimeMaxima";
            this.textBoxLungimeMaxima.Size = new System.Drawing.Size(100, 20);
            this.textBoxLungimeMaxima.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(232, 167);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Lungime Maxima";
            // 
            // textBoxLungimeMedie
            // 
            this.textBoxLungimeMedie.Location = new System.Drawing.Point(331, 136);
            this.textBoxLungimeMedie.Name = "textBoxLungimeMedie";
            this.textBoxLungimeMedie.Size = new System.Drawing.Size(103, 20);
            this.textBoxLungimeMedie.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(232, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Lungime Medie";
            // 
            // comboBoxLongevitate
            // 
            this.comboBoxLongevitate.FormattingEnabled = true;
            this.comboBoxLongevitate.Items.AddRange(new object[] {
            "Anuala",
            "Bianuala",
            "Perena"});
            this.comboBoxLongevitate.Location = new System.Drawing.Point(316, 110);
            this.comboBoxLongevitate.Name = "comboBoxLongevitate";
            this.comboBoxLongevitate.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLongevitate.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(232, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Longevitate";
            // 
            // comboBoxRamificatie
            // 
            this.comboBoxRamificatie.FormattingEnabled = true;
            this.comboBoxRamificatie.Items.AddRange(new object[] {
            "Neramificat",
            "Dihotomic",
            "Opus",
            "Alternativ"});
            this.comboBoxRamificatie.Location = new System.Drawing.Point(108, 275);
            this.comboBoxRamificatie.Name = "comboBoxRamificatie";
            this.comboBoxRamificatie.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRamificatie.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Ramificare";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Tulpina";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Numar De Petale";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Utilizare";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Clasa Biologica";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Denumire Stiintifica";
            // 
            // comboTulpina
            // 
            this.comboTulpina.FormattingEnabled = true;
            this.comboTulpina.Items.AddRange(new object[] {
            "Erecta",
            "Taratoare",
            "Volubila",
            "Agataroare"});
            this.comboTulpina.Location = new System.Drawing.Point(108, 245);
            this.comboTulpina.Name = "comboTulpina";
            this.comboTulpina.Size = new System.Drawing.Size(121, 21);
            this.comboTulpina.TabIndex = 10;
            // 
            // textBoxNumarDePetale
            // 
            this.textBoxNumarDePetale.Location = new System.Drawing.Point(108, 218);
            this.textBoxNumarDePetale.Name = "textBoxNumarDePetale";
            this.textBoxNumarDePetale.Size = new System.Drawing.Size(118, 20);
            this.textBoxNumarDePetale.TabIndex = 9;
            // 
            // textBoxUtilizare
            // 
            this.textBoxUtilizare.Location = new System.Drawing.Point(108, 191);
            this.textBoxUtilizare.Name = "textBoxUtilizare";
            this.textBoxUtilizare.Size = new System.Drawing.Size(118, 20);
            this.textBoxUtilizare.TabIndex = 8;
            // 
            // textBoxClasaBiologica
            // 
            this.textBoxClasaBiologica.Location = new System.Drawing.Point(108, 164);
            this.textBoxClasaBiologica.Name = "textBoxClasaBiologica";
            this.textBoxClasaBiologica.Size = new System.Drawing.Size(118, 20);
            this.textBoxClasaBiologica.TabIndex = 7;
            // 
            // textBoxDenumireStiintifica
            // 
            this.textBoxDenumireStiintifica.Location = new System.Drawing.Point(108, 137);
            this.textBoxDenumireStiintifica.Name = "textBoxDenumireStiintifica";
            this.textBoxDenumireStiintifica.Size = new System.Drawing.Size(118, 20);
            this.textBoxDenumireStiintifica.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Denumire";
            // 
            // groupBoxSetariAvansate
            // 
            this.groupBoxSetariAvansate.Controls.Add(this.buttonInchideFaraASalva);
            this.groupBoxSetariAvansate.Controls.Add(this.buttonReincarcaDinBaza);
            this.groupBoxSetariAvansate.Controls.Add(this.buttonReinitializeazaBaza);
            this.groupBoxSetariAvansate.Controls.Add(this.buttonRescrieBaza);
            this.groupBoxSetariAvansate.Location = new System.Drawing.Point(9, 333);
            this.groupBoxSetariAvansate.Name = "groupBoxSetariAvansate";
            this.groupBoxSetariAvansate.Size = new System.Drawing.Size(425, 118);
            this.groupBoxSetariAvansate.TabIndex = 3;
            this.groupBoxSetariAvansate.TabStop = false;
            this.groupBoxSetariAvansate.Text = "Setari Avansate";
            // 
            // buttonInchideFaraASalva
            // 
            this.buttonInchideFaraASalva.Location = new System.Drawing.Point(234, 21);
            this.buttonInchideFaraASalva.Name = "buttonInchideFaraASalva";
            this.buttonInchideFaraASalva.Size = new System.Drawing.Size(148, 23);
            this.buttonInchideFaraASalva.TabIndex = 26;
            this.buttonInchideFaraASalva.Text = "Inchide Fara A Salva";
            this.buttonInchideFaraASalva.UseVisualStyleBackColor = true;
            this.buttonInchideFaraASalva.Click += new System.EventHandler(this.buttonInchideFaraASalva_Click);
            // 
            // buttonReincarcaDinBaza
            // 
            this.buttonReincarcaDinBaza.Location = new System.Drawing.Point(15, 80);
            this.buttonReincarcaDinBaza.Name = "buttonReincarcaDinBaza";
            this.buttonReincarcaDinBaza.Size = new System.Drawing.Size(184, 23);
            this.buttonReincarcaDinBaza.TabIndex = 2;
            this.buttonReincarcaDinBaza.Text = "Reincarca Din Baza";
            this.buttonReincarcaDinBaza.UseVisualStyleBackColor = true;
            this.buttonReincarcaDinBaza.Click += new System.EventHandler(this.buttonReincarcaDinBaza_Click);
            // 
            // buttonReinitializeazaBaza
            // 
            this.buttonReinitializeazaBaza.Location = new System.Drawing.Point(15, 50);
            this.buttonReinitializeazaBaza.Name = "buttonReinitializeazaBaza";
            this.buttonReinitializeazaBaza.Size = new System.Drawing.Size(184, 23);
            this.buttonReinitializeazaBaza.TabIndex = 1;
            this.buttonReinitializeazaBaza.Text = "Reinitializeaza Baza";
            this.buttonReinitializeazaBaza.UseVisualStyleBackColor = true;
            this.buttonReinitializeazaBaza.Click += new System.EventHandler(this.buttonReinitializeazaBaza_Click);
            // 
            // buttonRescrieBaza
            // 
            this.buttonRescrieBaza.Location = new System.Drawing.Point(15, 21);
            this.buttonRescrieBaza.Name = "buttonRescrieBaza";
            this.buttonRescrieBaza.Size = new System.Drawing.Size(184, 23);
            this.buttonRescrieBaza.TabIndex = 0;
            this.buttonRescrieBaza.Text = "Rescrie Baza";
            this.buttonRescrieBaza.UseVisualStyleBackColor = true;
            this.buttonRescrieBaza.Click += new System.EventHandler(this.buttonRescrieBaza_Click);
            // 
            // checkBoxSetariAvansate
            // 
            this.checkBoxSetariAvansate.AutoSize = true;
            this.checkBoxSetariAvansate.Location = new System.Drawing.Point(9, 310);
            this.checkBoxSetariAvansate.Name = "checkBoxSetariAvansate";
            this.checkBoxSetariAvansate.Size = new System.Drawing.Size(65, 17);
            this.checkBoxSetariAvansate.TabIndex = 2;
            this.checkBoxSetariAvansate.Text = "Avansat";
            this.checkBoxSetariAvansate.UseVisualStyleBackColor = true;
            // 
            // textBoxDenumire
            // 
            this.textBoxDenumire.Location = new System.Drawing.Point(108, 110);
            this.textBoxDenumire.Name = "textBoxDenumire";
            this.textBoxDenumire.Size = new System.Drawing.Size(118, 20);
            this.textBoxDenumire.TabIndex = 1;
            // 
            // groupBoxAfisare
            // 
            this.groupBoxAfisare.Controls.Add(this.radioButtonDupaUtilizare);
            this.groupBoxAfisare.Controls.Add(this.radioButtonDupaClasa);
            this.groupBoxAfisare.Location = new System.Drawing.Point(8, 6);
            this.groupBoxAfisare.Name = "groupBoxAfisare";
            this.groupBoxAfisare.Size = new System.Drawing.Size(200, 100);
            this.groupBoxAfisare.TabIndex = 0;
            this.groupBoxAfisare.TabStop = false;
            this.groupBoxAfisare.Text = "Afisare";
            // 
            // radioButtonDupaUtilizare
            // 
            this.radioButtonDupaUtilizare.AutoSize = true;
            this.radioButtonDupaUtilizare.Location = new System.Drawing.Point(26, 55);
            this.radioButtonDupaUtilizare.Name = "radioButtonDupaUtilizare";
            this.radioButtonDupaUtilizare.Size = new System.Drawing.Size(91, 17);
            this.radioButtonDupaUtilizare.TabIndex = 1;
            this.radioButtonDupaUtilizare.TabStop = true;
            this.radioButtonDupaUtilizare.Text = "Dupa Utilizare";
            this.radioButtonDupaUtilizare.UseVisualStyleBackColor = true;
            this.radioButtonDupaUtilizare.CheckedChanged += new System.EventHandler(this.radioButtonDupaUtilizare_CheckedChanged);
            // 
            // radioButtonDupaClasa
            // 
            this.radioButtonDupaClasa.AutoSize = true;
            this.radioButtonDupaClasa.Location = new System.Drawing.Point(26, 31);
            this.radioButtonDupaClasa.Name = "radioButtonDupaClasa";
            this.radioButtonDupaClasa.Size = new System.Drawing.Size(80, 17);
            this.radioButtonDupaClasa.TabIndex = 0;
            this.radioButtonDupaClasa.TabStop = true;
            this.radioButtonDupaClasa.Text = "Dupa Clasa";
            this.radioButtonDupaClasa.UseVisualStyleBackColor = true;
            this.radioButtonDupaClasa.CheckedChanged += new System.EventHandler(this.radioButtonDupaClasa_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonSalveazaOCopieCa);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(440, 457);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Optiuni Suplimentare";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonSalveazaOCopieCa
            // 
            this.buttonSalveazaOCopieCa.Location = new System.Drawing.Point(39, 23);
            this.buttonSalveazaOCopieCa.Name = "buttonSalveazaOCopieCa";
            this.buttonSalveazaOCopieCa.Size = new System.Drawing.Size(151, 23);
            this.buttonSalveazaOCopieCa.TabIndex = 0;
            this.buttonSalveazaOCopieCa.Text = "Salveaza O Copie Ca";
            this.buttonSalveazaOCopieCa.UseVisualStyleBackColor = true;
            // 
            // FloareDialog
            // 
            this.ClientSize = new System.Drawing.Size(816, 500);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.treeViewFlori);
            this.Controls.Add(this.listViewFlori);
            this.Name = "FloareDialog";
            this.Text = "Main Floare Dialog";
            this.Load += new System.EventHandler(this.FloareDialog_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageDetaliiFloare.ResumeLayout(false);
            this.tabPageDetaliiFloare.PerformLayout();
            this.panelFloare.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFloare)).EndInit();
            this.groupBoxSetariAvansate.ResumeLayout(false);
            this.groupBoxAfisare.ResumeLayout(false);
            this.groupBoxAfisare.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewFlori;
        private System.Windows.Forms.TreeView treeViewFlori;
        private TabControl tabControl1;
        private TabPage tabPageDetaliiFloare;
        private GroupBox groupBoxAfisare;
        private RadioButton radioButtonDupaUtilizare;
        private RadioButton radioButtonDupaClasa;
        private TabPage tabPage2;
        private Label label1;
        private GroupBox groupBoxSetariAvansate;
        private Button buttonReincarcaDinBaza;
        private Button buttonReinitializeazaBaza;
        private Button buttonRescrieBaza;
        private CheckBox checkBoxSetariAvansate;
        private TextBox textBoxDenumire;
        private Button buttonSalveazaOCopieCa;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox comboTulpina;
        private TextBox textBoxNumarDePetale;
        private TextBox textBoxUtilizare;
        private TextBox textBoxClasaBiologica;
        private TextBox textBoxDenumireStiintifica;
        private Label label6;
        private Label label5;
        private ComboBox comboBoxLongevitate;
        private Label label8;
        private ComboBox comboBoxRamificatie;
        private Label label7;
        private Label label11;
        private TextBox textBoxPret;
        private TextBox textBoxLungimeMaxima;
        private Label label10;
        private TextBox textBoxLungimeMedie;
        private Label label9;
        private Button buttonInchideFaraASalva;
        private Label label12;
        private PictureBox pictureBoxFloare;
        private Panel panelFloare;
    }
}

