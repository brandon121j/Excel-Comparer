namespace Excel_Comparer.Custom_Controls
{
    partial class ImportFile2Control
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportFile2Control));
            panel1 = new Panel();
            loadingPB = new PictureBox();
            fileLB = new Label();
            importPB = new PictureBox();
            importLB = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)loadingPB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)importPB).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AllowDrop = true;
            panel1.Controls.Add(loadingPB);
            panel1.Controls.Add(fileLB);
            panel1.Controls.Add(importPB);
            panel1.Controls.Add(importLB);
            panel1.Location = new Point(110, 107);
            panel1.Name = "panel1";
            panel1.Size = new Size(450, 250);
            panel1.TabIndex = 3;
            panel1.DragDrop += Panel1_DragDrop;
            panel1.DragEnter += Panel1_DragEnter;
            // 
            // loadingPB
            // 
            loadingPB.Cursor = Cursors.Hand;
            loadingPB.Image = (Image)resources.GetObject("loadingPB.Image");
            loadingPB.Location = new Point(177, 77);
            loadingPB.Name = "loadingPB";
            loadingPB.Size = new Size(96, 96);
            loadingPB.TabIndex = 4;
            loadingPB.TabStop = false;
            loadingPB.Visible = false;
            // 
            // fileLB
            // 
            fileLB.BackColor = Color.Transparent;
            fileLB.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            fileLB.ForeColor = Color.FromArgb(29, 111, 66);
            fileLB.Location = new Point(-110, 225);
            fileLB.Name = "fileLB";
            fileLB.Size = new Size(670, 25);
            fileLB.TabIndex = 2;
            fileLB.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // importPB
            // 
            importPB.Cursor = Cursors.Hand;
            importPB.Image = Properties.Resources.icons8_add_file_96;
            importPB.Location = new Point(177, 77);
            importPB.Name = "importPB";
            importPB.Size = new Size(96, 96);
            importPB.TabIndex = 1;
            importPB.TabStop = false;
            importPB.Click += ImportPB_Click;
            // 
            // importLB
            // 
            importLB.BackColor = Color.Transparent;
            importLB.Dock = DockStyle.Top;
            importLB.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            importLB.ForeColor = Color.FromArgb(29, 111, 66);
            importLB.Location = new Point(0, 0);
            importLB.Name = "importLB";
            importLB.Size = new Size(450, 25);
            importLB.TabIndex = 0;
            importLB.Text = "Import Excel File 2";
            importLB.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ImportFile2Control
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(panel1);
            Name = "ImportFile2Control";
            Size = new Size(670, 465);
            VisibleChanged += ImportFile2Control_VisibleChanged;
            DragDrop += ImportFile2Control_DragDrop;
            DragEnter += ImportFile2Control_DragEnter;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)loadingPB).EndInit();
            ((System.ComponentModel.ISupportInitialize)importPB).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label fileLB;
        private PictureBox importPB;
        private Label importLB;
        private PictureBox loadingPB;
    }
}
