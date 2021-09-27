
namespace Lab1Tablouri1D
{
    partial class ModelChanger
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
            this.listArray = new System.Windows.Forms.ListView();
            this.Elemente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textFrom = new System.Windows.Forms.TextBox();
            this.textTo = new System.Windows.Forms.TextBox();
            this.textSize = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblValori = new System.Windows.Forms.Label();
            this.lblSizeDetail = new System.Windows.Forms.Label();
            this.lblToDetail = new System.Windows.Forms.Label();
            this.lblFromDetail = new System.Windows.Forms.Label();
            this.lblF2Info = new System.Windows.Forms.Label();
            this.lblInsInfo = new System.Windows.Forms.Label();
            this.lblAInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listArray
            // 
            this.listArray.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Elemente});
            this.listArray.HideSelection = false;
            this.listArray.LabelEdit = true;
            this.listArray.Location = new System.Drawing.Point(12, 29);
            this.listArray.Name = "listArray";
            this.listArray.Size = new System.Drawing.Size(156, 387);
            this.listArray.TabIndex = 0;
            this.listArray.UseCompatibleStateImageBehavior = false;
            this.listArray.View = System.Windows.Forms.View.Details;
            this.listArray.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listArray_AfterLabelEdit);
            this.listArray.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listArray_KeyUp);
            // 
            // Elemente
            // 
            this.Elemente.Text = "Elemente";
            this.Elemente.Width = 131;
            // 
            // textFrom
            // 
            this.textFrom.Location = new System.Drawing.Point(339, 37);
            this.textFrom.Name = "textFrom";
            this.textFrom.Size = new System.Drawing.Size(100, 22);
            this.textFrom.TabIndex = 1;
            this.textFrom.TextChanged += new System.EventHandler(this.textFrom_TextChanged);
            this.textFrom.Validating += new System.ComponentModel.CancelEventHandler(this.textFrom_Validating);
            // 
            // textTo
            // 
            this.textTo.Location = new System.Drawing.Point(339, 65);
            this.textTo.Name = "textTo";
            this.textTo.Size = new System.Drawing.Size(100, 22);
            this.textTo.TabIndex = 2;
            this.textTo.TextChanged += new System.EventHandler(this.textTo_TextChanged);
            this.textTo.Validating += new System.ComponentModel.CancelEventHandler(this.textTo_Validating);
            // 
            // textSize
            // 
            this.textSize.Location = new System.Drawing.Point(339, 93);
            this.textSize.Name = "textSize";
            this.textSize.Size = new System.Drawing.Size(100, 22);
            this.textSize.TabIndex = 3;
            this.textSize.TextChanged += new System.EventHandler(this.textSize_TextChanged);
            this.textSize.Validating += new System.ComponentModel.CancelEventHandler(this.textSize_Validating);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(210, 40);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(120, 17);
            this.lblFrom.TabIndex = 5;
            this.lblFrom.Text = "Valoare minimală:";
            this.lblFrom.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(207, 68);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(123, 17);
            this.lblTo.TabIndex = 6;
            this.lblTo.Text = "Valoare maximală:";
            this.lblTo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.Location = new System.Drawing.Point(194, 96);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(136, 17);
            this.lblSize.TabIndex = 7;
            this.lblSize.Text = "Număr de elemente:";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblValori
            // 
            this.lblValori.AutoSize = true;
            this.lblValori.Location = new System.Drawing.Point(12, 9);
            this.lblValori.Name = "lblValori";
            this.lblValori.Size = new System.Drawing.Size(44, 17);
            this.lblValori.TabIndex = 8;
            this.lblValori.Text = "Valori";
            // 
            // lblSizeDetail
            // 
            this.lblSizeDetail.AutoSize = true;
            this.lblSizeDetail.Location = new System.Drawing.Point(463, 96);
            this.lblSizeDetail.Name = "lblSizeDetail";
            this.lblSizeDetail.Size = new System.Drawing.Size(140, 17);
            this.lblSizeDetail.TabIndex = 9;
            this.lblSizeDetail.Text = "(de la 5 până la 100)";
            // 
            // lblToDetail
            // 
            this.lblToDetail.AutoSize = true;
            this.lblToDetail.Location = new System.Drawing.Point(463, 68);
            this.lblToDetail.Name = "lblToDetail";
            this.lblToDetail.Size = new System.Drawing.Size(264, 17);
            this.lblToDetail.TabIndex = 10;
            this.lblToDetail.Text = "(de la Valăare minimală + 1 până la 500)";
            // 
            // lblFromDetail
            // 
            this.lblFromDetail.AutoSize = true;
            this.lblFromDetail.Location = new System.Drawing.Point(463, 40);
            this.lblFromDetail.Name = "lblFromDetail";
            this.lblFromDetail.Size = new System.Drawing.Size(248, 17);
            this.lblFromDetail.TabIndex = 11;
            this.lblFromDetail.Text = "(de la 5 până la Valăare maximală - 1)";
            // 
            // lblF2Info
            // 
            this.lblF2Info.AutoSize = true;
            this.lblF2Info.Location = new System.Drawing.Point(174, 366);
            this.lblF2Info.Name = "lblF2Info";
            this.lblF2Info.Size = new System.Drawing.Size(195, 17);
            this.lblF2Info.TabIndex = 12;
            this.lblF2Info.Text = "F2: Edităm valoarea selectată";
            // 
            // lblInsInfo
            // 
            this.lblInsInfo.AutoSize = true;
            this.lblInsInfo.Location = new System.Drawing.Point(174, 383);
            this.lblInsInfo.Name = "lblInsInfo";
            this.lblInsInfo.Size = new System.Drawing.Size(373, 17);
            this.lblInsInfo.TabIndex = 13;
            this.lblInsInfo.Text = "INS: Înserăm o valoare nouă înainte de valoarea selectate";
            // 
            // lblAInfo
            // 
            this.lblAInfo.AutoSize = true;
            this.lblAInfo.Location = new System.Drawing.Point(174, 400);
            this.lblAInfo.Name = "lblAInfo";
            this.lblAInfo.Size = new System.Drawing.Size(281, 17);
            this.lblAInfo.TabIndex = 14;
            this.lblAInfo.Text = "A: Adăugăm o valoare nouă în capătul listei";
            // 
            // ModelChanger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblAInfo);
            this.Controls.Add(this.lblInsInfo);
            this.Controls.Add(this.lblF2Info);
            this.Controls.Add(this.lblFromDetail);
            this.Controls.Add(this.lblToDetail);
            this.Controls.Add(this.lblSizeDetail);
            this.Controls.Add(this.lblValori);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.textSize);
            this.Controls.Add(this.textTo);
            this.Controls.Add(this.textFrom);
            this.Controls.Add(this.listArray);
            this.Name = "ModelChanger";
            this.Text = "ModelChanger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModelChanger_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listArray;
        private System.Windows.Forms.TextBox textFrom;
        private System.Windows.Forms.TextBox textTo;
        private System.Windows.Forms.ColumnHeader Elemente;
        private System.Windows.Forms.TextBox textSize;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblValori;
        private System.Windows.Forms.Label lblSizeDetail;
        private System.Windows.Forms.Label lblToDetail;
        private System.Windows.Forms.Label lblFromDetail;
        private System.Windows.Forms.Label lblF2Info;
        private System.Windows.Forms.Label lblInsInfo;
        private System.Windows.Forms.Label lblAInfo;
    }
}