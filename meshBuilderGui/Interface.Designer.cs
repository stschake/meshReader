namespace meshBuilderGui
{
    partial class Interface
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
            this.buildDisplay1 = new meshBuilderGui.BuildDisplay();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.startXBox = new System.Windows.Forms.TextBox();
            this.startYBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.countXBox = new System.Windows.Forms.TextBox();
            this.countYBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buildDisplay1
            // 
            this.buildDisplay1.Location = new System.Drawing.Point(12, 12);
            this.buildDisplay1.Name = "buildDisplay1";
            this.buildDisplay1.Size = new System.Drawing.Size(262, 262);
            this.buildDisplay1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 20);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start Build";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 280);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Start Tile X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 334);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Start Tile Y";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // startXBox
            // 
            this.startXBox.Location = new System.Drawing.Point(74, 306);
            this.startXBox.Name = "startXBox";
            this.startXBox.Size = new System.Drawing.Size(62, 20);
            this.startXBox.TabIndex = 5;
            // 
            // startYBox
            // 
            this.startYBox.Location = new System.Drawing.Point(74, 331);
            this.startYBox.Name = "startYBox";
            this.startYBox.Size = new System.Drawing.Size(62, 20);
            this.startYBox.TabIndex = 6;
            this.startYBox.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(142, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Count";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 334);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Count";
            // 
            // countXBox
            // 
            this.countXBox.Location = new System.Drawing.Point(183, 306);
            this.countXBox.Name = "countXBox";
            this.countXBox.Size = new System.Drawing.Size(91, 20);
            this.countXBox.TabIndex = 9;
            // 
            // countYBox
            // 
            this.countYBox.Location = new System.Drawing.Point(183, 331);
            this.countYBox.Name = "countYBox";
            this.countYBox.Size = new System.Drawing.Size(91, 20);
            this.countYBox.TabIndex = 10;
            // 
            // Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 360);
            this.Controls.Add(this.countYBox);
            this.Controls.Add(this.countXBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.startYBox);
            this.Controls.Add(this.startXBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buildDisplay1);
            this.Name = "Interface";
            this.Text = "Mesh Builder Interface";
            this.Load += new System.EventHandler(this.Interface_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BuildDisplay buildDisplay1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox startXBox;
        private System.Windows.Forms.TextBox startYBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox countXBox;
        private System.Windows.Forms.TextBox countYBox;


    }
}

