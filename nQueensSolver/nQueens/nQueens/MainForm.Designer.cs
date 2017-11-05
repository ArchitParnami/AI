namespace nQueens
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.inputUpDown = new System.Windows.Forms.NumericUpDown();
            this.generateButton = new System.Windows.Forms.Button();
            this.conflictTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.stepButton = new System.Windows.Forms.Button();
            this.RunButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.maxIterBox = new System.Windows.Forms.NumericUpDown();
            this.algoComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.randomRestartComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.stepsUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.movesTextBox = new System.Windows.Forms.TextBox();
            this.iterationsTextBox = new System.Windows.Forms.TextBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.inputUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxIterBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepsUpDown)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Queens:";
            // 
            // inputUpDown
            // 
            this.inputUpDown.Location = new System.Drawing.Point(85, 118);
            this.inputUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inputUpDown.Name = "inputUpDown";
            this.inputUpDown.Size = new System.Drawing.Size(34, 20);
            this.inputUpDown.TabIndex = 5;
            this.inputUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.inputUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(135, 118);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(71, 28);
            this.generateButton.TabIndex = 6;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // conflictTextBox
            // 
            this.conflictTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.conflictTextBox.Location = new System.Drawing.Point(457, 42);
            this.conflictTextBox.Name = "conflictTextBox";
            this.conflictTextBox.ReadOnly = true;
            this.conflictTextBox.Size = new System.Drawing.Size(38, 20);
            this.conflictTextBox.TabIndex = 0;
            this.conflictTextBox.TabStop = false;
            this.conflictTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(383, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Conflicts:";
            // 
            // stepButton
            // 
            this.stepButton.Location = new System.Drawing.Point(212, 118);
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(62, 28);
            this.stepButton.TabIndex = 7;
            this.stepButton.Text = "Step";
            this.stepButton.UseVisualStyleBackColor = true;
            this.stepButton.Click += new System.EventHandler(this.stepButton_Click);
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(284, 118);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(66, 28);
            this.RunButton.TabIndex = 8;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Maximum Iterations";
            // 
            // maxIterBox
            // 
            this.maxIterBox.Location = new System.Drawing.Point(297, 77);
            this.maxIterBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.maxIterBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxIterBox.Name = "maxIterBox";
            this.maxIterBox.Size = new System.Drawing.Size(53, 20);
            this.maxIterBox.TabIndex = 4;
            this.maxIterBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maxIterBox.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // algoComboBox
            // 
            this.algoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.algoComboBox.FormattingEnabled = true;
            this.algoComboBox.Location = new System.Drawing.Point(85, 36);
            this.algoComboBox.Name = "algoComboBox";
            this.algoComboBox.Size = new System.Drawing.Size(121, 21);
            this.algoComboBox.TabIndex = 1;
            this.algoComboBox.SelectedIndexChanged += new System.EventHandler(this.algoComboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Algorithm";
            // 
            // randomRestartComboBox
            // 
            this.randomRestartComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.randomRestartComboBox.FormattingEnabled = true;
            this.randomRestartComboBox.Location = new System.Drawing.Point(116, 76);
            this.randomRestartComboBox.Name = "randomRestartComboBox";
            this.randomRestartComboBox.Size = new System.Drawing.Size(48, 21);
            this.randomRestartComboBox.TabIndex = 3;
            this.randomRestartComboBox.SelectedIndexChanged += new System.EventHandler(this.randomRestartComboBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Random Restart";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(234, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Max Steps";
            // 
            // stepsUpDown
            // 
            this.stepsUpDown.Location = new System.Drawing.Point(297, 39);
            this.stepsUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.stepsUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stepsUpDown.Name = "stepsUpDown";
            this.stepsUpDown.Size = new System.Drawing.Size(53, 20);
            this.stepsUpDown.TabIndex = 2;
            this.stepsUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.stepsUpDown.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(394, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Moves:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(383, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Iterations:";
            // 
            // movesTextBox
            // 
            this.movesTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.movesTextBox.Location = new System.Drawing.Point(457, 80);
            this.movesTextBox.Name = "movesTextBox";
            this.movesTextBox.ReadOnly = true;
            this.movesTextBox.Size = new System.Drawing.Size(38, 20);
            this.movesTextBox.TabIndex = 0;
            this.movesTextBox.TabStop = false;
            this.movesTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // iterationsTextBox
            // 
            this.iterationsTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.iterationsTextBox.Location = new System.Drawing.Point(457, 117);
            this.iterationsTextBox.Name = "iterationsTextBox";
            this.iterationsTextBox.ReadOnly = true;
            this.iterationsTextBox.Size = new System.Drawing.Size(38, 20);
            this.iterationsTextBox.TabIndex = 0;
            this.iterationsTextBox.TabStop = false;
            this.iterationsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(212, 148);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(62, 28);
            this.resetButton.TabIndex = 9;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(383, 153);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 13);
            this.statusLabel.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(534, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShowShortcutKeys = false;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(534, 190);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.iterationsTextBox);
            this.Controls.Add(this.movesTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.stepsUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.randomRestartComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.algoComboBox);
            this.Controls.Add(this.maxIterBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.stepButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.conflictTextBox);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.inputUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "n-Queens Solver";
            ((System.ComponentModel.ISupportInitialize)(this.inputUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxIterBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stepsUpDown)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown inputUpDown;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.TextBox conflictTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button stepButton;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown maxIterBox;
        private System.Windows.Forms.ComboBox algoComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox randomRestartComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown stepsUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox movesTextBox;
        private System.Windows.Forms.TextBox iterationsTextBox;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

