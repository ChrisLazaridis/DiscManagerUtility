namespace Disc_Manager_Utility
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            progressBar2 = new ProgressBar();
            checkBox1 = new CheckBox();
            label3 = new Label();
            label2 = new Label();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            tabPage2 = new TabPage();
            panel4 = new Panel();
            treeView1 = new TreeView();
            panel3 = new Panel();
            button3 = new Button();
            label6 = new Label();
            comboBox4 = new ComboBox();
            label9 = new Label();
            label8 = new Label();
            comboBox3 = new ComboBox();
            label7 = new Label();
            progressBar1 = new ProgressBar();
            button2 = new Button();
            textBox2 = new TextBox();
            comboBox2 = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            comboBox1 = new ComboBox();
            label10 = new Label();
            label11 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            tabPage2.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 450);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel2);
            tabPage1.Controls.Add(panel1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 422);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Search";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(208, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(581, 416);
            panel2.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Resizable = DataGridViewTriState.True;
            dataGridView1.Size = new Size(581, 416);
            dataGridView1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(progressBar2);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dateTimePicker2);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(205, 416);
            panel1.TabIndex = 1;
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(0, 329);
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(100, 23);
            progressBar2.TabIndex = 18;
            progressBar2.Visible = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(0, 284);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(72, 19);
            checkBox1.TabIndex = 17;
            checkBox1.Text = "Use Date";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(0, 162);
            label3.Name = "label3";
            label3.Size = new Size(22, 15);
            label3.TabIndex = 16;
            label3.Text = "To:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(0, 115);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 15;
            label2.Text = "From:";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(0, 180);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 14;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(0, 133);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 13;
            dateTimePicker1.Value = new DateTime(1889, 12, 31, 0, 0, 0, 0);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 64);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 12;
            label1.Text = "File Name:";
            // 
            // button1
            // 
            button1.Location = new Point(0, 246);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 11;
            button1.Text = "Search";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(0, 82);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(185, 23);
            textBox1.TabIndex = 10;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel4);
            tabPage2.Controls.Add(panel3);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 422);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Disc Management";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(treeView1);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(269, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(520, 416);
            panel4.TabIndex = 2;
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new Point(0, 0);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(520, 416);
            treeView1.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(button3);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(comboBox4);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(comboBox3);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(progressBar1);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(comboBox2);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(comboBox1);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(266, 416);
            panel3.TabIndex = 1;
            // 
            // button3
            // 
            button3.Location = new Point(3, 99);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 28;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(132, 52);
            label6.Name = "label6";
            label6.Size = new Size(47, 15);
            label6.TabIndex = 27;
            label6.Text = "Sort By:";
            label6.Visible = false;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Items.AddRange(new object[] { "Default", "Alphabetical", "Date" });
            comboBox4.Location = new Point(132, 70);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(121, 23);
            comboBox4.TabIndex = 26;
            comboBox4.Visible = false;
            comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(175, 52);
            label9.Name = "label9";
            label9.Size = new Size(76, 15);
            label9.TabIndex = 25;
            label9.Text = "Loading Files";
            label9.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(5, 10);
            label8.Name = "label8";
            label8.Size = new Size(47, 15);
            label8.TabIndex = 24;
            label8.Text = "Sort By:";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Default", "Alphabetical", "Date" });
            comboBox3.Location = new Point(5, 26);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(121, 23);
            comboBox3.TabIndex = 23;
            comboBox3.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(5, 287);
            label7.Name = "label7";
            label7.Size = new Size(94, 15);
            label7.TabIndex = 22;
            label7.Text = "Saving Changes:";
            label7.Visible = false;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(5, 305);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(100, 23);
            progressBar1.TabIndex = 21;
            progressBar1.Visible = false;
            // 
            // button2
            // 
            button2.Location = new Point(5, 256);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 20;
            button2.Text = "Add";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(5, 189);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 19;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(3, 218);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 18;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 148);
            label5.Name = "label5";
            label5.Size = new Size(119, 15);
            label5.TabIndex = 17;
            label5.Text = "Add New Disc Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(5, 52);
            label4.Name = "label4";
            label4.Size = new Size(66, 15);
            label4.TabIndex = 16;
            label4.Text = "Select Disc:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(5, 70);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 15;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(3, 384);
            label10.Name = "label10";
            label10.Size = new Size(195, 15);
            label10.TabIndex = 1;
            label10.Text = "Copyright © 2024 Christos Lazaridis";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(3, 399);
            label11.Name = "label11";
            label11.Size = new Size(129, 15);
            label11.TabIndex = 19;
            label11.Text = "clazaridis7@gmail.com";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panel1;
        private ProgressBar progressBar2;
        private CheckBox checkBox1;
        private Label label3;
        private Label label2;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private Button button1;
        private TextBox textBox1;
        private Panel panel2;
        private DataGridView dataGridView1;
        private Panel panel3;
        private Label label6;
        private ComboBox comboBox4;
        private Label label9;
        private Label label8;
        private ComboBox comboBox3;
        private Label label7;
        private ProgressBar progressBar1;
        private Button button2;
        private TextBox textBox2;
        private ComboBox comboBox2;
        private Label label5;
        private Label label4;
        private ComboBox comboBox1;
        private Panel panel4;
        private TreeView treeView1;
        private Button button3;
        private Label label11;
        private Label label10;
    }
}
