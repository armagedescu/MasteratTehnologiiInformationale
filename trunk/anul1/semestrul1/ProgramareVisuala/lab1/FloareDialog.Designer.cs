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
			mainApp.saveFloareDb (floareSet);
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
            //this.SuspendLayout();
            // 
            // treeViewFlori
            // 
            this.treeViewFlori.Location = new System.Drawing.Point(5, 5);
            this.treeViewFlori.Name = "treeViewFlori";
            this.treeViewFlori.Size = new System.Drawing.Size(345, 145);
            this.treeViewFlori.TabIndex = 0;
			treeViewFlori.AfterSelect += TreeViewFlori_AfterSelect;
            // 
            // listViewFlori
            // 
            this.listViewFlori.Location = new System.Drawing.Point(5, 150);
            this.listViewFlori.Name = "listViewFlori";
            this.listViewFlori.Size = new System.Drawing.Size(345, 345);
            this.listViewFlori.TabIndex = 1;
			listViewFlori.View = View.Details;
			listViewFlori.Columns.Add("Denumire", 100);
			listViewFlori.Columns.Add("Clasa", 100);
            listViewFlori.GridLines = true;
            listViewFlori.FullRowSelect = true;
            // 
            // Form1
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 500);
            this.Controls.Add(this.treeViewFlori);
            this.Controls.Add(this.listViewFlori);
            this.Name = "Floare Dialog";
            this.Text = "Main Floare Dialog";
            this.Load += new System.EventHandler(this.FloareDialog_Load);
            //this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewFlori;
        private System.Windows.Forms.TreeView treeViewFlori;
    }
}

