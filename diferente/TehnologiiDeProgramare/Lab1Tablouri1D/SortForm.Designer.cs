
namespace Lab1Tablouri1D
{
    partial class SortForm
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
            this.pictureBubbleSort = new System.Windows.Forms.PictureBox();
            this.sortAsc = new System.Windows.Forms.Button();
            this.pictureSelectionSort = new System.Windows.Forms.PictureBox();
            this.pictureInsertionSort = new System.Windows.Forms.PictureBox();
            this.sortDesc = new System.Windows.Forms.Button();
            this.lblBula = new System.Windows.Forms.Label();
            this.lblSelectie = new System.Windows.Forms.Label();
            this.lblInsertion = new System.Windows.Forms.Label();
            this.btnReinit = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBubbleSort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSelectionSort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureInsertionSort)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBubbleSort
            // 
            this.pictureBubbleSort.Location = new System.Drawing.Point(29, 83);
            this.pictureBubbleSort.Name = "pictureBubbleSort";
            this.pictureBubbleSort.Size = new System.Drawing.Size(831, 108);
            this.pictureBubbleSort.TabIndex = 0;
            this.pictureBubbleSort.TabStop = false;
            this.pictureBubbleSort.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBubbleSort_Paint);
            // 
            // sortAsc
            // 
            this.sortAsc.Location = new System.Drawing.Point(29, 12);
            this.sortAsc.Name = "sortAsc";
            this.sortAsc.Size = new System.Drawing.Size(150, 36);
            this.sortAsc.TabIndex = 1;
            this.sortAsc.Text = "Sortează ascendent";
            this.sortAsc.UseVisualStyleBackColor = true;
            this.sortAsc.Click += new System.EventHandler(this.sortAsc_Click);
            // 
            // pictureSelectionSort
            // 
            this.pictureSelectionSort.Location = new System.Drawing.Point(29, 219);
            this.pictureSelectionSort.Name = "pictureSelectionSort";
            this.pictureSelectionSort.Size = new System.Drawing.Size(831, 116);
            this.pictureSelectionSort.TabIndex = 2;
            this.pictureSelectionSort.TabStop = false;
            this.pictureSelectionSort.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureSelectionSort_Paint);
            // 
            // pictureInsertionSort
            // 
            this.pictureInsertionSort.Location = new System.Drawing.Point(29, 367);
            this.pictureInsertionSort.Name = "pictureInsertionSort";
            this.pictureInsertionSort.Size = new System.Drawing.Size(831, 116);
            this.pictureInsertionSort.TabIndex = 3;
            this.pictureInsertionSort.TabStop = false;
            this.pictureInsertionSort.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureInsertionSort_Paint);
            // 
            // sortDesc
            // 
            this.sortDesc.Location = new System.Drawing.Point(185, 12);
            this.sortDesc.Name = "sortDesc";
            this.sortDesc.Size = new System.Drawing.Size(157, 36);
            this.sortDesc.TabIndex = 4;
            this.sortDesc.Text = "Sortează descendent";
            this.sortDesc.UseVisualStyleBackColor = true;
            this.sortDesc.Click += new System.EventHandler(this.sortDesc_Click);
            // 
            // lblBula
            // 
            this.lblBula.AutoSize = true;
            this.lblBula.Location = new System.Drawing.Point(37, 63);
            this.lblBula.Name = "lblBula";
            this.lblBula.Size = new System.Drawing.Size(176, 17);
            this.lblBula.TabIndex = 5;
            this.lblBula.Text = "Sortarea prin metoda bulei";
            // 
            // lblSelectie
            // 
            this.lblSelectie.AutoSize = true;
            this.lblSelectie.Location = new System.Drawing.Point(37, 199);
            this.lblSelectie.Name = "lblSelectie";
            this.lblSelectie.Size = new System.Drawing.Size(197, 17);
            this.lblSelectie.TabIndex = 6;
            this.lblSelectie.Text = "Sortarea prin metoda selecției";
            // 
            // lblInsertion
            // 
            this.lblInsertion.AutoSize = true;
            this.lblInsertion.Location = new System.Drawing.Point(37, 347);
            this.lblInsertion.Name = "lblInsertion";
            this.lblInsertion.Size = new System.Drawing.Size(195, 17);
            this.lblInsertion.TabIndex = 7;
            this.lblInsertion.Text = "Sortarea prin metoda inserției";
            // 
            // btnReinit
            // 
            this.btnReinit.Location = new System.Drawing.Point(348, 12);
            this.btnReinit.Name = "btnReinit";
            this.btnReinit.Size = new System.Drawing.Size(149, 36);
            this.btnReinit.TabIndex = 8;
            this.btnReinit.Text = "Reinițializare";
            this.btnReinit.UseVisualStyleBackColor = true;
            this.btnReinit.Click += new System.EventHandler(this.btnReinit_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(503, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(149, 36);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Date inițiale";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // SortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 508);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnReinit);
            this.Controls.Add(this.lblInsertion);
            this.Controls.Add(this.lblSelectie);
            this.Controls.Add(this.lblBula);
            this.Controls.Add(this.sortDesc);
            this.Controls.Add(this.pictureInsertionSort);
            this.Controls.Add(this.pictureSelectionSort);
            this.Controls.Add(this.sortAsc);
            this.Controls.Add(this.pictureBubbleSort);
            this.Name = "SortForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SortForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBubbleSort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSelectionSort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureInsertionSort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBubbleSort;
        private System.Windows.Forms.Button sortAsc;
        private System.Windows.Forms.PictureBox pictureSelectionSort;
        private System.Windows.Forms.PictureBox pictureInsertionSort;
        private System.Windows.Forms.Button sortDesc;
        private System.Windows.Forms.Label lblBula;
        private System.Windows.Forms.Label lblSelectie;
        private System.Windows.Forms.Label lblInsertion;
        private System.Windows.Forms.Button btnReinit;
        private System.Windows.Forms.Button btnEdit;
    }
}

