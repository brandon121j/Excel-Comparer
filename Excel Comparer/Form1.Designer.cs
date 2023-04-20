namespace Excel_Comparer
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
            headerPN = new Panel();
            buttonsPN = new Panel();
            minimizeBT = new Common.CircularButton();
            exitBT = new Common.CircularButton();
            sidePN = new Panel();
            selectedPN = new Panel();
            generateBT = new Button();
            criteriaBT = new Button();
            import2BT = new Button();
            import1BT = new Button();
            logoPN = new Panel();
            logoLB = new Label();
            logoPB = new PictureBox();
            compareCriteriaControl = new Custom_Controls.CompareCriteriaControl();
            panel1 = new Panel();
            importFile1Control = new Custom_Controls.ImportFile1Control();
            generateComparisonControl = new Custom_Controls.GenerateComparisonControl();
            importFile2Control = new Custom_Controls.ImportFile2Control();
            headerPN.SuspendLayout();
            buttonsPN.SuspendLayout();
            sidePN.SuspendLayout();
            logoPN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPB).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // headerPN
            // 
            headerPN.BackColor = Color.FromArgb(29, 111, 66);
            headerPN.Controls.Add(buttonsPN);
            headerPN.Dock = DockStyle.Top;
            headerPN.Location = new Point(180, 0);
            headerPN.Name = "headerPN";
            headerPN.Size = new Size(670, 35);
            headerPN.TabIndex = 0;
            headerPN.MouseDown += HeaderPN_MouseDown;
            // 
            // buttonsPN
            // 
            buttonsPN.Controls.Add(minimizeBT);
            buttonsPN.Controls.Add(exitBT);
            buttonsPN.Dock = DockStyle.Right;
            buttonsPN.Location = new Point(595, 0);
            buttonsPN.Name = "buttonsPN";
            buttonsPN.Size = new Size(75, 35);
            buttonsPN.TabIndex = 5;
            // 
            // minimizeBT
            // 
            minimizeBT.Cursor = Cursors.Hand;
            minimizeBT.FlatAppearance.BorderSize = 0;
            minimizeBT.FlatAppearance.MouseDownBackColor = Color.Transparent;
            minimizeBT.FlatAppearance.MouseOverBackColor = Color.Transparent;
            minimizeBT.FlatStyle = FlatStyle.Flat;
            minimizeBT.Image = Properties.Resources.macOS_minimize_32;
            minimizeBT.Location = new Point(2, 1);
            minimizeBT.Name = "minimizeBT";
            minimizeBT.Size = new Size(32, 32);
            minimizeBT.TabIndex = 4;
            minimizeBT.UseVisualStyleBackColor = true;
            minimizeBT.Click += MinimizeBT_Click;
            minimizeBT.MouseEnter += MinimizeBT_MouseEnter;
            minimizeBT.MouseLeave += MinimizeBT_MouseLeave;
            // 
            // exitBT
            // 
            exitBT.Cursor = Cursors.Hand;
            exitBT.FlatAppearance.BorderSize = 0;
            exitBT.FlatAppearance.MouseDownBackColor = Color.Transparent;
            exitBT.FlatAppearance.MouseOverBackColor = Color.Transparent;
            exitBT.FlatStyle = FlatStyle.Flat;
            exitBT.Image = Properties.Resources.macOS_close_red_32;
            exitBT.Location = new Point(40, 1);
            exitBT.Name = "exitBT";
            exitBT.Size = new Size(32, 32);
            exitBT.TabIndex = 3;
            exitBT.UseVisualStyleBackColor = true;
            exitBT.Click += ExitBT_Click;
            exitBT.MouseEnter += ExitBT_MouseEnter;
            exitBT.MouseLeave += ExitBT_MouseLeave;
            // 
            // sidePN
            // 
            sidePN.BackColor = Color.FromArgb(29, 111, 66);
            sidePN.Controls.Add(selectedPN);
            sidePN.Controls.Add(generateBT);
            sidePN.Controls.Add(criteriaBT);
            sidePN.Controls.Add(import2BT);
            sidePN.Controls.Add(import1BT);
            sidePN.Controls.Add(logoPN);
            sidePN.Dock = DockStyle.Left;
            sidePN.Location = new Point(0, 0);
            sidePN.Name = "sidePN";
            sidePN.Size = new Size(180, 500);
            sidePN.TabIndex = 1;
            // 
            // selectedPN
            // 
            selectedPN.BackColor = Color.White;
            selectedPN.Location = new Point(0, 163);
            selectedPN.Name = "selectedPN";
            selectedPN.Size = new Size(3, 50);
            selectedPN.TabIndex = 0;
            // 
            // generateBT
            // 
            generateBT.Cursor = Cursors.Hand;
            generateBT.Dock = DockStyle.Top;
            generateBT.FlatAppearance.BorderSize = 0;
            generateBT.FlatStyle = FlatStyle.Flat;
            generateBT.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            generateBT.ForeColor = Color.White;
            generateBT.Image = (Image)resources.GetObject("generateBT.Image");
            generateBT.Location = new Point(0, 313);
            generateBT.Name = "generateBT";
            generateBT.Size = new Size(180, 50);
            generateBT.TabIndex = 2;
            generateBT.Text = "   Compare Excel Files";
            generateBT.TextImageRelation = TextImageRelation.ImageBeforeText;
            generateBT.UseVisualStyleBackColor = true;
            generateBT.Click += GenerateBT_Click;
            // 
            // criteriaBT
            // 
            criteriaBT.Cursor = Cursors.Hand;
            criteriaBT.Dock = DockStyle.Top;
            criteriaBT.FlatAppearance.BorderSize = 0;
            criteriaBT.FlatStyle = FlatStyle.Flat;
            criteriaBT.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            criteriaBT.ForeColor = Color.White;
            criteriaBT.Image = (Image)resources.GetObject("criteriaBT.Image");
            criteriaBT.Location = new Point(0, 263);
            criteriaBT.Name = "criteriaBT";
            criteriaBT.Size = new Size(180, 50);
            criteriaBT.TabIndex = 3;
            criteriaBT.Text = "   Comparison Criteria";
            criteriaBT.TextImageRelation = TextImageRelation.ImageBeforeText;
            criteriaBT.UseVisualStyleBackColor = true;
            criteriaBT.Click += CriteriaBT_Click;
            // 
            // import2BT
            // 
            import2BT.Cursor = Cursors.Hand;
            import2BT.Dock = DockStyle.Top;
            import2BT.FlatAppearance.BorderSize = 0;
            import2BT.FlatStyle = FlatStyle.Flat;
            import2BT.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            import2BT.ForeColor = Color.White;
            import2BT.Image = Properties.Resources.icons8_import_file_32;
            import2BT.Location = new Point(0, 213);
            import2BT.Name = "import2BT";
            import2BT.Size = new Size(180, 50);
            import2BT.TabIndex = 1;
            import2BT.Text = "   Import Excel File 2";
            import2BT.TextImageRelation = TextImageRelation.ImageBeforeText;
            import2BT.UseVisualStyleBackColor = true;
            import2BT.Click += Import2BT_Click;
            // 
            // import1BT
            // 
            import1BT.Cursor = Cursors.Hand;
            import1BT.Dock = DockStyle.Top;
            import1BT.FlatAppearance.BorderSize = 0;
            import1BT.FlatStyle = FlatStyle.Flat;
            import1BT.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            import1BT.ForeColor = Color.White;
            import1BT.Image = Properties.Resources.icons8_import_file_32;
            import1BT.Location = new Point(0, 163);
            import1BT.Name = "import1BT";
            import1BT.Size = new Size(180, 50);
            import1BT.TabIndex = 0;
            import1BT.Text = "   Import Excel File 1";
            import1BT.TextImageRelation = TextImageRelation.ImageBeforeText;
            import1BT.UseVisualStyleBackColor = true;
            import1BT.Click += Import1BT_Click;
            // 
            // logoPN
            // 
            logoPN.Controls.Add(logoLB);
            logoPN.Controls.Add(logoPB);
            logoPN.Dock = DockStyle.Top;
            logoPN.Location = new Point(0, 0);
            logoPN.Name = "logoPN";
            logoPN.Size = new Size(180, 163);
            logoPN.TabIndex = 0;
            // 
            // logoLB
            // 
            logoLB.AutoSize = true;
            logoLB.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            logoLB.ForeColor = Color.White;
            logoLB.Location = new Point(28, 131);
            logoLB.Name = "logoLB";
            logoLB.Size = new Size(124, 21);
            logoLB.TabIndex = 0;
            logoLB.Text = "Excel Comparer";
            logoLB.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // logoPB
            // 
            logoPB.Image = (Image)resources.GetObject("logoPB.Image");
            logoPB.Location = new Point(40, 15);
            logoPB.Name = "logoPB";
            logoPB.Size = new Size(100, 100);
            logoPB.SizeMode = PictureBoxSizeMode.CenterImage;
            logoPB.TabIndex = 0;
            logoPB.TabStop = false;
            // 
            // compareCriteriaControl
            // 
            compareCriteriaControl.Location = new Point(0, 0);
            compareCriteriaControl.Name = "compareCriteriaControl";
            compareCriteriaControl.Size = new Size(670, 465);
            compareCriteriaControl.TabIndex = 4;
            compareCriteriaControl.Visible = false;
            // 
            // panel1
            // 
            panel1.AllowDrop = true;
            panel1.Controls.Add(importFile1Control);
            panel1.Controls.Add(generateComparisonControl);
            panel1.Controls.Add(importFile2Control);
            panel1.Controls.Add(compareCriteriaControl);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(180, 35);
            panel1.Name = "panel1";
            panel1.Size = new Size(670, 465);
            panel1.TabIndex = 2;
            // 
            // importFile1Control
            // 
            importFile1Control.AllowDrop = true;
            importFile1Control.BackColor = Color.Transparent;
            importFile1Control.Dock = DockStyle.Fill;
            importFile1Control.Location = new Point(0, 0);
            importFile1Control.Name = "importFile1Control";
            importFile1Control.Size = new Size(670, 465);
            importFile1Control.TabIndex = 0;
            // 
            // generateComparisonControl
            // 
            generateComparisonControl.Dock = DockStyle.Fill;
            generateComparisonControl.Location = new Point(0, 0);
            generateComparisonControl.Name = "generateComparisonControl";
            generateComparisonControl.Size = new Size(670, 465);
            generateComparisonControl.TabIndex = 4;
            generateComparisonControl.Visible = false;
            // 
            // importFile2Control
            // 
            importFile2Control.AllowDrop = true;
            importFile2Control.BackColor = Color.Transparent;
            importFile2Control.Dock = DockStyle.Fill;
            importFile2Control.Location = new Point(0, 0);
            importFile2Control.Name = "importFile2Control";
            importFile2Control.Size = new Size(670, 465);
            importFile2Control.TabIndex = 1;
            importFile2Control.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(235, 239, 241);
            ClientSize = new Size(850, 500);
            Controls.Add(panel1);
            Controls.Add(headerPN);
            Controls.Add(sidePN);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(850, 500);
            Name = "Form1";
            Text = "Excel Comparer";
            headerPN.ResumeLayout(false);
            buttonsPN.ResumeLayout(false);
            sidePN.ResumeLayout(false);
            logoPN.ResumeLayout(false);
            logoPN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logoPB).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel headerPN;
        private Panel buttonsPN;
        private Panel sidePN;
        private Button criteriaBT;
        private Panel selectedPN;
        private Button generateBT;
        private Button import2BT;
        private Button import1BT;
        private Panel logoPN;
        private Label logoLB;
        private PictureBox logoPB;
        private Panel panel1;
        private Common.CircularButton exitBT;
        private Common.CircularButton minimizeBT;
        private Custom_Controls.ImportFile1Control importFile1Control;
        private Custom_Controls.ImportFile2Control importFile2Control;
        private Custom_Controls.CompareCriteriaControl compareCriteriaControl;
        private Custom_Controls.GenerateComparisonControl generateComparisonControl;
    }
}