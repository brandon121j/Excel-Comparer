namespace Excel_Comparer.Custom_Controls
{
    partial class CompareCriteriaControl
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
            bodyPN = new Panel();
            removeCriteriaBT = new Button();
            criteriaLB = new Label();
            panel1 = new Panel();
            excel2LB = new ListBox();
            excel1LB = new ListBox();
            addCriteriaBT = new Button();
            comparisonLV = new ListView();
            excel1HD = new ColumnHeader();
            excel2HD = new ColumnHeader();
            headerLB = new Label();
            bodyPN.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // bodyPN
            // 
            bodyPN.BackColor = Color.Transparent;
            bodyPN.Controls.Add(removeCriteriaBT);
            bodyPN.Controls.Add(criteriaLB);
            bodyPN.Controls.Add(panel1);
            bodyPN.Controls.Add(comparisonLV);
            bodyPN.Controls.Add(headerLB);
            bodyPN.Dock = DockStyle.Fill;
            bodyPN.Location = new Point(0, 0);
            bodyPN.Margin = new Padding(0);
            bodyPN.Name = "bodyPN";
            bodyPN.Padding = new Padding(25);
            bodyPN.Size = new Size(670, 465);
            bodyPN.TabIndex = 3;
            // 
            // removeCriteriaBT
            // 
            removeCriteriaBT.BackColor = Color.Transparent;
            removeCriteriaBT.Cursor = Cursors.Hand;
            removeCriteriaBT.FlatAppearance.BorderColor = Color.FromArgb(29, 111, 66);
            removeCriteriaBT.FlatStyle = FlatStyle.Flat;
            removeCriteriaBT.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            removeCriteriaBT.ForeColor = Color.FromArgb(29, 111, 66);
            removeCriteriaBT.Location = new Point(60, 395);
            removeCriteriaBT.Name = "removeCriteriaBT";
            removeCriteriaBT.Size = new Size(550, 33);
            removeCriteriaBT.TabIndex = 6;
            removeCriteriaBT.Text = "Remove Selected Criteria";
            removeCriteriaBT.UseVisualStyleBackColor = false;
            removeCriteriaBT.Click += RemoveCriteriaBT_Click;
            // 
            // criteriaLB
            // 
            criteriaLB.AutoSize = true;
            criteriaLB.BackColor = Color.Transparent;
            criteriaLB.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            criteriaLB.ForeColor = Color.FromArgb(29, 111, 66);
            criteriaLB.Location = new Point(270, 258);
            criteriaLB.Name = "criteriaLB";
            criteriaLB.Size = new Size(131, 21);
            criteriaLB.TabIndex = 5;
            criteriaLB.Text = "Selected Criteria";
            criteriaLB.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(excel2LB);
            panel1.Controls.Add(excel1LB);
            panel1.Controls.Add(addCriteriaBT);
            panel1.Location = new Point(60, 60);
            panel1.Name = "panel1";
            panel1.Size = new Size(550, 185);
            panel1.TabIndex = 4;
            // 
            // excel2LB
            // 
            excel2LB.BorderStyle = BorderStyle.FixedSingle;
            excel2LB.Dock = DockStyle.Right;
            excel2LB.FormattingEnabled = true;
            excel2LB.ItemHeight = 15;
            excel2LB.Location = new Point(350, 0);
            excel2LB.Name = "excel2LB";
            excel2LB.Size = new Size(200, 185);
            excel2LB.TabIndex = 9;
            excel2LB.DoubleClick += Excel2LB_DoubleClick;
            // 
            // excel1LB
            // 
            excel1LB.BorderStyle = BorderStyle.FixedSingle;
            excel1LB.Dock = DockStyle.Left;
            excel1LB.FormattingEnabled = true;
            excel1LB.ItemHeight = 15;
            excel1LB.Location = new Point(0, 0);
            excel1LB.Name = "excel1LB";
            excel1LB.Size = new Size(200, 185);
            excel1LB.TabIndex = 8;
            excel1LB.DoubleClick += Excel1LB_DoubleClick;
            // 
            // addCriteriaBT
            // 
            addCriteriaBT.BackColor = Color.Transparent;
            addCriteriaBT.Cursor = Cursors.Hand;
            addCriteriaBT.FlatAppearance.BorderColor = Color.FromArgb(29, 111, 66);
            addCriteriaBT.FlatStyle = FlatStyle.Flat;
            addCriteriaBT.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            addCriteriaBT.ForeColor = Color.FromArgb(29, 111, 66);
            addCriteriaBT.Location = new Point(225, 76);
            addCriteriaBT.Name = "addCriteriaBT";
            addCriteriaBT.Size = new Size(100, 33);
            addCriteriaBT.TabIndex = 3;
            addCriteriaBT.Text = "Compare";
            addCriteriaBT.UseVisualStyleBackColor = false;
            addCriteriaBT.Click += AddCriteriaBT_Click;
            // 
            // comparisonLV
            // 
            comparisonLV.BorderStyle = BorderStyle.FixedSingle;
            comparisonLV.Columns.AddRange(new ColumnHeader[] { excel1HD, excel2HD });
            comparisonLV.FullRowSelect = true;
            comparisonLV.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            comparisonLV.Location = new Point(60, 283);
            comparisonLV.Name = "comparisonLV";
            comparisonLV.Size = new Size(550, 106);
            comparisonLV.TabIndex = 2;
            comparisonLV.UseCompatibleStateImageBehavior = false;
            comparisonLV.View = View.Details;
            comparisonLV.DoubleClick += ComparisonLV_DoubleClick;
            // 
            // excel1HD
            // 
            excel1HD.Text = "Excel1";
            excel1HD.Width = 275;
            // 
            // excel2HD
            // 
            excel2HD.Text = "Excel2";
            excel2HD.Width = 275;
            // 
            // headerLB
            // 
            headerLB.BackColor = Color.Transparent;
            headerLB.Dock = DockStyle.Top;
            headerLB.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            headerLB.ForeColor = Color.FromArgb(29, 111, 66);
            headerLB.Location = new Point(25, 25);
            headerLB.Name = "headerLB";
            headerLB.Size = new Size(620, 25);
            headerLB.TabIndex = 0;
            headerLB.Text = "Select Comparison Criteria";
            headerLB.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CompareCriteriaControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(bodyPN);
            Name = "CompareCriteriaControl";
            Size = new Size(670, 465);
            VisibleChanged += CompareCriteriaControl_VisibleChanged;
            bodyPN.ResumeLayout(false);
            bodyPN.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel bodyPN;
        private Label headerLB;
        private Panel panel1;
        private Button addCriteriaBT;
        private Label criteriaLB;
        private Button removeCriteriaBT;
        private ColumnHeader excel1HD;
        private ColumnHeader excel2HD;
        private ListView comparisonLV;
        private ListBox excel2LB;
        private ListBox excel1LB;
    }
}
