namespace ConductorManager
{
    partial class SettingsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewsFolder = new System.Windows.Forms.TextBox();
            this.btnBrowsNewsFolder = new System.Windows.Forms.Button();
            this.btnTestDeleteWebPath = new System.Windows.Forms.Button();
            this.txtDeleteWebPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.dgSourceDestination = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.nmProcessingList = new System.Windows.Forms.NumericUpDown();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.btnBrowsSelectedItems = new System.Windows.Forms.Button();
            this.txtSelectedItems = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nmDateOffset = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnNoLocaling = new System.Windows.Forms.Button();
            this.txtNoLocaling = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDateModifiedBrows = new System.Windows.Forms.Button();
            this.txtDateModified = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgSourceDestination)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmProcessingList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDateOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "News List Folder";
            // 
            // txtNewsFolder
            // 
            this.txtNewsFolder.Location = new System.Drawing.Point(122, 27);
            this.txtNewsFolder.Name = "txtNewsFolder";
            this.txtNewsFolder.Size = new System.Drawing.Size(413, 23);
            this.txtNewsFolder.TabIndex = 1;
            // 
            // btnBrowsNewsFolder
            // 
            this.btnBrowsNewsFolder.Location = new System.Drawing.Point(541, 27);
            this.btnBrowsNewsFolder.Name = "btnBrowsNewsFolder";
            this.btnBrowsNewsFolder.Size = new System.Drawing.Size(33, 23);
            this.btnBrowsNewsFolder.TabIndex = 3;
            this.btnBrowsNewsFolder.Text = "...";
            this.btnBrowsNewsFolder.UseVisualStyleBackColor = true;
            this.btnBrowsNewsFolder.Click += new System.EventHandler(this.btnBrowsNewsFolder_Click);
            // 
            // btnTestDeleteWebPath
            // 
            this.btnTestDeleteWebPath.Location = new System.Drawing.Point(541, 64);
            this.btnTestDeleteWebPath.Name = "btnTestDeleteWebPath";
            this.btnTestDeleteWebPath.Size = new System.Drawing.Size(33, 23);
            this.btnTestDeleteWebPath.TabIndex = 6;
            this.btnTestDeleteWebPath.Text = "...";
            this.btnTestDeleteWebPath.UseVisualStyleBackColor = true;
            this.btnTestDeleteWebPath.Click += new System.EventHandler(this.btnTestDeleteWebPath_Click);
            // 
            // txtDeleteWebPath
            // 
            this.txtDeleteWebPath.Location = new System.Drawing.Point(122, 64);
            this.txtDeleteWebPath.Name = "txtDeleteWebPath";
            this.txtDeleteWebPath.Size = new System.Drawing.Size(413, 23);
            this.txtDeleteWebPath.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Delete Web Path";
            // 
            // btnOK
            // 
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.ImageIndex = 0;
            this.btnOK.ImageList = this.imageList1;
            this.btnOK.Location = new System.Drawing.Point(493, 486);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(81, 32);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "&OK";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "_active__yes.png");
            this.imageList1.Images.SetKeyName(1, "_active__no.png");
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.ImageIndex = 1;
            this.btnCancel.ImageList = this.imageList1;
            this.btnCancel.Location = new System.Drawing.Point(351, 486);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 32);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgSourceDestination
            // 
            this.dgSourceDestination.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSourceDestination.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgSourceDestination.Location = new System.Drawing.Point(122, 247);
            this.dgSourceDestination.Name = "dgSourceDestination";
            this.dgSourceDestination.Size = new System.Drawing.Size(452, 223);
            this.dgSourceDestination.TabIndex = 9;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Source";
            this.Column1.Name = "Column1";
            this.Column1.Width = 190;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Destination";
            this.Column2.Name = "Column2";
            this.Column2.Width = 190;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Processing List";
            // 
            // nmProcessingList
            // 
            this.nmProcessingList.Location = new System.Drawing.Point(122, 218);
            this.nmProcessingList.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmProcessingList.Name = "nmProcessingList";
            this.nmProcessingList.Size = new System.Drawing.Size(79, 23);
            this.nmProcessingList.TabIndex = 11;
            this.nmProcessingList.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAutoStart.Location = new System.Drawing.Point(489, 219);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(85, 20);
            this.chkAutoStart.TabIndex = 12;
            this.chkAutoStart.Text = "Auto Start";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            // 
            // btnBrowsSelectedItems
            // 
            this.btnBrowsSelectedItems.Location = new System.Drawing.Point(542, 101);
            this.btnBrowsSelectedItems.Name = "btnBrowsSelectedItems";
            this.btnBrowsSelectedItems.Size = new System.Drawing.Size(33, 23);
            this.btnBrowsSelectedItems.TabIndex = 15;
            this.btnBrowsSelectedItems.Text = "...";
            this.btnBrowsSelectedItems.UseVisualStyleBackColor = true;
            this.btnBrowsSelectedItems.Click += new System.EventHandler(this.btnBrowsSelectedItems_Click);
            // 
            // txtSelectedItems
            // 
            this.txtSelectedItems.Location = new System.Drawing.Point(123, 101);
            this.txtSelectedItems.Name = "txtSelectedItems";
            this.txtSelectedItems.Size = new System.Drawing.Size(413, 23);
            this.txtSelectedItems.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Selected Items";
            // 
            // nmDateOffset
            // 
            this.nmDateOffset.Location = new System.Drawing.Point(347, 218);
            this.nmDateOffset.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmDateOffset.Name = "nmDateOffset";
            this.nmDateOffset.Size = new System.Drawing.Size(79, 23);
            this.nmDateOffset.TabIndex = 17;
            this.nmDateOffset.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Date Offset(Hour)";
            // 
            // btnNoLocaling
            // 
            this.btnNoLocaling.Location = new System.Drawing.Point(542, 138);
            this.btnNoLocaling.Name = "btnNoLocaling";
            this.btnNoLocaling.Size = new System.Drawing.Size(33, 23);
            this.btnNoLocaling.TabIndex = 20;
            this.btnNoLocaling.Text = "...";
            this.btnNoLocaling.UseVisualStyleBackColor = true;
            this.btnNoLocaling.Click += new System.EventHandler(this.btnNoLocaling_Click);
            // 
            // txtNoLocaling
            // 
            this.txtNoLocaling.Location = new System.Drawing.Point(123, 138);
            this.txtNoLocaling.Name = "txtNoLocaling";
            this.txtNoLocaling.Size = new System.Drawing.Size(413, 23);
            this.txtNoLocaling.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "Not Localong";
            // 
            // btnDateModifiedBrows
            // 
            this.btnDateModifiedBrows.Location = new System.Drawing.Point(542, 177);
            this.btnDateModifiedBrows.Name = "btnDateModifiedBrows";
            this.btnDateModifiedBrows.Size = new System.Drawing.Size(33, 23);
            this.btnDateModifiedBrows.TabIndex = 23;
            this.btnDateModifiedBrows.Text = "...";
            this.btnDateModifiedBrows.UseVisualStyleBackColor = true;
            this.btnDateModifiedBrows.Click += new System.EventHandler(this.btnDateModifiedBrows_Click);
            // 
            // txtDateModified
            // 
            this.txtDateModified.Location = new System.Drawing.Point(123, 177);
            this.txtDateModified.Name = "txtDateModified";
            this.txtDateModified.Size = new System.Drawing.Size(413, 23);
            this.txtDateModified.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(15, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 37);
            this.label7.TabIndex = 21;
            this.label7.Text = "Date Modified File Path";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(595, 522);
            this.Controls.Add(this.btnDateModifiedBrows);
            this.Controls.Add(this.txtDateModified);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnNoLocaling);
            this.Controls.Add(this.txtNoLocaling);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nmDateOffset);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnBrowsSelectedItems);
            this.Controls.Add(this.txtSelectedItems);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkAutoStart);
            this.Controls.Add(this.nmProcessingList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgSourceDestination);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnTestDeleteWebPath);
            this.Controls.Add(this.txtDeleteWebPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowsNewsFolder);
            this.Controls.Add(this.txtNewsFolder);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.Text = "Settings ...";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSourceDestination)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmProcessingList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDateOffset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewsFolder;
        private System.Windows.Forms.Button btnBrowsNewsFolder;
        private System.Windows.Forms.Button btnTestDeleteWebPath;
        private System.Windows.Forms.TextBox txtDeleteWebPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgSourceDestination;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nmProcessingList;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.Button btnBrowsSelectedItems;
        private System.Windows.Forms.TextBox txtSelectedItems;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nmDateOffset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnNoLocaling;
        private System.Windows.Forms.TextBox txtNoLocaling;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDateModifiedBrows;
        private System.Windows.Forms.TextBox txtDateModified;
        private System.Windows.Forms.Label label7;
    }
}