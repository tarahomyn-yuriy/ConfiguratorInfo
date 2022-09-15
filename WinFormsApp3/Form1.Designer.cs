namespace WinFormsApp3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridViewRecords = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecords)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewRecords
            // 
            this.dataGridViewRecords.AllowUserToAddRows = false;
            this.dataGridViewRecords.AllowUserToDeleteRows = false;
            this.dataGridViewRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewRecords.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRecords.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewRecords.Location = new System.Drawing.Point(5, 33);
            this.dataGridViewRecords.Name = "dataGridViewRecords";
            this.dataGridViewRecords.RowHeadersVisible = false;
            this.dataGridViewRecords.RowTemplate.Height = 25;
            this.dataGridViewRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRecords.Size = new System.Drawing.Size(883, 575);
            this.dataGridViewRecords.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonRefresh,
            this.toolStripButtonAdd,
            this.toolStripButtonCopy,
            this.toolStripButtonDelete});
            this.toolStrip1.Location = new System.Drawing.Point(5, 5);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(883, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRefresh.Image")));
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(82, 22);
            this.toolStripButtonRefresh.Text = "Обновити";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAdd.Image")));
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(66, 22);
            this.toolStripButtonAdd.Text = "Додати";
            this.toolStripButtonAdd.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
            // 
            // toolStripButtonCopy
            // 
            this.toolStripButtonCopy.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCopy.Image")));
            this.toolStripButtonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopy.Name = "toolStripButtonCopy";
            this.toolStripButtonCopy.Size = new System.Drawing.Size(85, 22);
            this.toolStripButtonCopy.Text = "Копіювати";
            this.toolStripButtonCopy.Click += new System.EventHandler(this.toolStripButtonCopy_Click);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDelete.Image")));
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(79, 22);
            this.toolStripButtonDelete.Text = "Видалити";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 613);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dataGridViewRecords);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecords)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridViewRecords;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonAdd;
        private ToolStripButton toolStripButtonCopy;
        private ToolStripButton toolStripButtonDelete;
        private ToolStripButton toolStripButtonRefresh;
    }
}