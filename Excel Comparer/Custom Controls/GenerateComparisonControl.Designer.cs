using System.ComponentModel;

namespace Excel_Comparer.Custom_Controls
{
    partial class GenerateComparisonControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(GenerateComparisonControl));
            ListViewItem listViewItem1 = new ListViewItem("None");
            ListViewItem listViewItem2 = new ListViewItem("None");
            panel1 = new Panel();
            loadingPN = new Panel();
            loadingLB = new Label();
            cancelBT = new Button();
            loadingPB = new PictureBox();
            generateBT = new Button();
            panel2 = new Panel();
            excel1LV = new ListView();
            excel2LV = new ListView();
            headerPN = new Panel();
            panel3 = new Panel();
            label1 = new Label();
            headerPNL = new Panel();
            excel1LB = new Label();
            headerLB = new Label();
            panel1.SuspendLayout();
            loadingPN.SuspendLayout();
            ((ISupportInitialize)loadingPB).BeginInit();
            panel2.SuspendLayout();
            headerPN.SuspendLayout();
            panel3.SuspendLayout();
            headerPNL.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(loadingPN);
            panel1.Controls.Add(generateBT);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(headerLB);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(25);
            panel1.Size = new Size(670, 465);
            panel1.TabIndex = 3;
            // 
            // loadingPN
            // 
            loadingPN.BackColor = Color.Transparent;
            loadingPN.Controls.Add(loadingLB);
            loadingPN.Controls.Add(cancelBT);
            loadingPN.Controls.Add(loadingPB);
            loadingPN.Dock = DockStyle.Fill;
            loadingPN.Location = new Point(25, 50);
            loadingPN.Name = "loadingPN";
            loadingPN.Size = new Size(620, 390);
            loadingPN.TabIndex = 5;
            loadingPN.Visible = false;
            // 
            // loadingLB
            // 
            loadingLB.BackColor = Color.Transparent;
            loadingLB.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            loadingLB.ForeColor = Color.FromArgb(29, 111, 66);
            loadingLB.Location = new Point(31, 275);
            loadingLB.Name = "loadingLB";
            loadingLB.Size = new Size(559, 25);
            loadingLB.TabIndex = 2;
            loadingLB.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cancelBT
            // 
            cancelBT.BackColor = Color.Transparent;
            cancelBT.Cursor = Cursors.Hand;
            cancelBT.FlatAppearance.BorderColor = Color.FromArgb(29, 111, 66);
            cancelBT.FlatStyle = FlatStyle.Flat;
            cancelBT.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            cancelBT.ForeColor = Color.FromArgb(29, 111, 66);
            cancelBT.Location = new Point(262, 348);
            cancelBT.Name = "cancelBT";
            cancelBT.Size = new Size(96, 30);
            cancelBT.TabIndex = 4;
            cancelBT.Text = "Cancel";
            cancelBT.UseVisualStyleBackColor = false;
            cancelBT.Click += CancelBT_Click;
            // 
            // loadingPB
            // 
            loadingPB.Cursor = Cursors.Hand;
            loadingPB.Image = (Image)resources.GetObject("loadingPB.Image");
            loadingPB.Location = new Point(262, 147);
            loadingPB.Name = "loadingPB";
            loadingPB.Size = new Size(96, 96);
            loadingPB.TabIndex = 3;
            loadingPB.TabStop = false;
            // 
            // generateBT
            // 
            generateBT.BackColor = Color.Transparent;
            generateBT.Cursor = Cursors.Hand;
            generateBT.FlatAppearance.BorderColor = Color.FromArgb(29, 111, 66);
            generateBT.FlatStyle = FlatStyle.Flat;
            generateBT.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            generateBT.ForeColor = Color.FromArgb(29, 111, 66);
            generateBT.Location = new Point(241, 363);
            generateBT.Name = "generateBT";
            generateBT.Size = new Size(189, 51);
            generateBT.TabIndex = 4;
            generateBT.Text = "Generate Comparison";
            generateBT.UseVisualStyleBackColor = false;
            generateBT.Click += GenerateBT_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(excel1LV);
            panel2.Controls.Add(excel2LV);
            panel2.Controls.Add(headerPN);
            panel2.Location = new Point(60, 53);
            panel2.Name = "panel2";
            panel2.Size = new Size(550, 269);
            panel2.TabIndex = 2;
            // 
            // excel1LV
            // 
            excel1LV.Activation = ItemActivation.OneClick;
            excel1LV.BorderStyle = BorderStyle.FixedSingle;
            excel1LV.CheckBoxes = true;
            excel1LV.FullRowSelect = true;
            listViewItem1.Checked = true;
            listViewItem1.StateImageIndex = 1;
            excel1LV.Items.AddRange(new ListViewItem[] { listViewItem1 });
            excel1LV.Location = new Point(0, 31);
            excel1LV.MultiSelect = false;
            excel1LV.Name = "excel1LV";
            excel1LV.Size = new Size(235, 235);
            excel1LV.TabIndex = 7;
            excel1LV.UseCompatibleStateImageBehavior = false;
            excel1LV.View = View.List;
            excel1LV.ItemCheck += Excel1LV_ItemCheck;
            // 
            // excel2LV
            // 
            excel2LV.Activation = ItemActivation.OneClick;
            excel2LV.BorderStyle = BorderStyle.FixedSingle;
            excel2LV.CheckBoxes = true;
            listViewItem2.Checked = true;
            listViewItem2.StateImageIndex = 1;
            excel2LV.Items.AddRange(new ListViewItem[] { listViewItem2 });
            excel2LV.Location = new Point(312, 31);
            excel2LV.MultiSelect = false;
            excel2LV.Name = "excel2LV";
            excel2LV.Size = new Size(235, 235);
            excel2LV.TabIndex = 6;
            excel2LV.UseCompatibleStateImageBehavior = false;
            excel2LV.View = View.List;
            excel2LV.ItemCheck += Excel2LV_ItemCheck;
            // 
            // headerPN
            // 
            headerPN.Controls.Add(panel3);
            headerPN.Controls.Add(headerPNL);
            headerPN.Dock = DockStyle.Top;
            headerPN.Location = new Point(0, 0);
            headerPN.Name = "headerPN";
            headerPN.Size = new Size(550, 30);
            headerPN.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(315, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(235, 30);
            panel3.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(29, 111, 66);
            label1.Location = new Point(64, 13);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 1;
            label1.Text = "Excel2 Primary Key";
            // 
            // headerPNL
            // 
            headerPNL.Controls.Add(excel1LB);
            headerPNL.Dock = DockStyle.Left;
            headerPNL.Location = new Point(0, 0);
            headerPNL.Name = "headerPNL";
            headerPNL.Size = new Size(235, 30);
            headerPNL.TabIndex = 0;
            // 
            // excel1LB
            // 
            excel1LB.AutoSize = true;
            excel1LB.ForeColor = Color.FromArgb(29, 111, 66);
            excel1LB.Location = new Point(64, 13);
            excel1LB.Name = "excel1LB";
            excel1LB.Size = new Size(106, 15);
            excel1LB.TabIndex = 0;
            excel1LB.Text = "Excel1 Primary Key";
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
            headerLB.Text = "Generate Comparison";
            headerLB.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GenerateComparisonControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "GenerateComparisonControl";
            Size = new Size(670, 465);
            VisibleChanged += GenerateComparisonControl_VisibleChanged;
            panel1.ResumeLayout(false);
            loadingPN.ResumeLayout(false);
            ((ISupportInitialize)loadingPB).EndInit();
            panel2.ResumeLayout(false);
            headerPN.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            headerPNL.ResumeLayout(false);
            headerPNL.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label headerLB;
        private Button generateBT;
        private ListView comparisonLV;
        private ColumnHeader excel1HD;
        private ColumnHeader excel1DT;
        private ColumnHeader excel2HD;
        private ColumnHeader excel2DT;
        private Panel headerPN;
        private Panel panel3;
        private Panel headerPNL;
        private Label excel1LB;
        private Label label1;
        private ComboBox excel2CB;
        private ComboBox excel1CB;
        private Label excel2LB;
        private ListView excel2LV;
        private ListView excel1LV;
        private Panel loadingPN;
        private Label loadingLB;
        private PictureBox loadingPB;
        private Button cancelBT;
    }
}
