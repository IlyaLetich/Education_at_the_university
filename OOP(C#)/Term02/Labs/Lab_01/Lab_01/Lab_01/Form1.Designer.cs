namespace Lab_01
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
            this.Number01 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Action = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Calculate = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Result = new System.Windows.Forms.TextBox();
            this.Number02 = new System.Windows.Forms.TextBox();
            this.TextNumber02 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Buffer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Number01
            // 
            this.Number01.Location = new System.Drawing.Point(7, 37);
            this.Number01.Name = "Number01";
            this.Number01.Size = new System.Drawing.Size(276, 27);
            this.Number01.TabIndex = 0;
            this.Number01.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Number01.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.Number01.Validating += new System.ComponentModel.CancelEventHandler(this.Number01_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(86, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select an action";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Action
            // 
            this.Action.FormattingEnabled = true;
            this.Action.Items.AddRange(new object[] {
            "plus",
            "sin",
            "cos",
            "tang",
            "sqrt",
            "square",
            "row power"});
            this.Action.Location = new System.Drawing.Point(7, 95);
            this.Action.Name = "Action";
            this.Action.Size = new System.Drawing.Size(276, 28);
            this.Action.TabIndex = 2;
            this.Action.SelectedIndexChanged += new System.EventHandler(this.action_SelectedIndexChanged);
            this.Action.Validating += new System.ComponentModel.CancelEventHandler(this.Action_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(94, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter number";
            this.label2.Click += new System.EventHandler(this.label1_Click);
            // 
            // Calculate
            // 
            this.Calculate.Location = new System.Drawing.Point(302, 14);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(110, 53);
            this.Calculate.TabIndex = 5;
            this.Calculate.Text = "Calculate";
            this.Calculate.UseVisualStyleBackColor = true;
            this.Calculate.Click += new System.EventHandler(this.buttom2_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(302, 73);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(110, 50);
            this.Clear.TabIndex = 6;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(478, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Result";
            this.label3.Click += new System.EventHandler(this.label3_Click_2);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(434, -75);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(112, 0);
            this.textBox2.TabIndex = 8;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Result
            // 
            this.Result.Enabled = false;
            this.Result.Location = new System.Drawing.Point(434, 37);
            this.Result.Multiline = true;
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(136, 86);
            this.Result.TabIndex = 9;
            this.Result.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // Number02
            // 
            this.Number02.Location = new System.Drawing.Point(7, 159);
            this.Number02.Name = "Number02";
            this.Number02.Size = new System.Drawing.Size(276, 27);
            this.Number02.TabIndex = 10;
            this.Number02.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Number02.Visible = false;
            this.Number02.TextChanged += new System.EventHandler(this.Number02_TextChanged);
            this.Number02.Validating += new System.ComponentModel.CancelEventHandler(this.Number02_Validating);
            // 
            // TextNumber02
            // 
            this.TextNumber02.AutoSize = true;
            this.TextNumber02.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.TextNumber02.Location = new System.Drawing.Point(86, 136);
            this.TextNumber02.Name = "TextNumber02";
            this.TextNumber02.Size = new System.Drawing.Size(36, 20);
            this.TextNumber02.TabIndex = 11;
            this.TextNumber02.Text = "Text";
            this.TextNumber02.Visible = false;
            this.TextNumber02.Click += new System.EventHandler(this.label4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(302, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 29);
            this.button1.TabIndex = 12;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(302, 171);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 29);
            this.button2.TabIndex = 13;
            this.button2.Text = "Export";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            this.button2.Validating += new System.ComponentModel.CancelEventHandler(this.button2_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(478, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Buffer";
            // 
            // Buffer
            // 
            this.Buffer.Enabled = false;
            this.Buffer.Location = new System.Drawing.Point(434, 159);
            this.Buffer.Name = "Buffer";
            this.Buffer.Size = new System.Drawing.Size(136, 27);
            this.Buffer.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(582, 211);
            this.Controls.Add(this.Buffer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TextNumber02);
            this.Controls.Add(this.Number02);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Calculate);
            this.Controls.Add(this.Action);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Number01);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox Number01;
        private Label label1;
        private ComboBox Action;
        private Label label2;
        private Button Calculate;
        private Button Clear;
        private Label label3;
        private TextBox textBox2;
        private TextBox Result;
        private TextBox Number02;
        private Label TextNumber02;
        private Button button1;
        private Button button2;
        private Label label4;
        private TextBox Buffer;
    }
}