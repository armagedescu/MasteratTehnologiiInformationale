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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSetariAvansate = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxSetariAvansate = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBoxAfisare = new System.Windows.Forms.GroupBox();
            this.radioButtonDupaUtilizare = new System.Windows.Forms.RadioButton();
            this.radioButtonDupaClasa = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPageDetaliiFloare.SuspendLayout();
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
            this.listViewFlori.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewFlori_KeyUp);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageDetaliiFloare);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(356, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(332, 483);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPageDetaliiFloare
            // 
            this.tabPageDetaliiFloare.Controls.Add(this.label1);
            this.tabPageDetaliiFloare.Controls.Add(this.groupBoxSetariAvansate);
            this.tabPageDetaliiFloare.Controls.Add(this.checkBoxSetariAvansate);
            this.tabPageDetaliiFloare.Controls.Add(this.textBox1);
            this.tabPageDetaliiFloare.Controls.Add(this.groupBoxAfisare);
            this.tabPageDetaliiFloare.Location = new System.Drawing.Point(4, 22);
            this.tabPageDetaliiFloare.Name = "tabPageDetaliiFloare";
            this.tabPageDetaliiFloare.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDetaliiFloare.Size = new System.Drawing.Size(324, 457);
            this.tabPageDetaliiFloare.TabIndex = 0;
            this.tabPageDetaliiFloare.Text = "Detaii Floare";
            this.tabPageDetaliiFloare.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Clasa";
            // 
            // groupBoxSetariAvansate
            // 
            this.groupBoxSetariAvansate.Controls.Add(this.button3);
            this.groupBoxSetariAvansate.Controls.Add(this.button2);
            this.groupBoxSetariAvansate.Controls.Add(this.button1);
            this.groupBoxSetariAvansate.Location = new System.Drawing.Point(9, 333);
            this.groupBoxSetariAvansate.Name = "groupBoxSetariAvansate";
            this.groupBoxSetariAvansate.Size = new System.Drawing.Size(228, 118);
            this.groupBoxSetariAvansate.TabIndex = 3;
            this.groupBoxSetariAvansate.TabStop = false;
            this.groupBoxSetariAvansate.Text = "Setari Avansate";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(15, 80);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(202, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Reincarca Din Baza";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 50);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(202, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Reinitializeaza Baza";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(202, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Rescrie Baza";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(45, 106);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
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
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(324, 457);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(39, 23);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // FloareDialog
            // 
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.treeViewFlori);
            this.Controls.Add(this.listViewFlori);
            this.Name = "FloareDialog";
            this.Text = "Main Floare Dialog";
            this.Load += new System.EventHandler(this.FloareDialog_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageDetaliiFloare.ResumeLayout(false);
            this.tabPageDetaliiFloare.PerformLayout();
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
        private Button button3;
        private Button button2;
        private Button button1;
        private CheckBox checkBoxSetariAvansate;
        private TextBox textBox1;
        private Button button4;
    }
}

