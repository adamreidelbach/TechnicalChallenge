namespace HPATechChallenge
{
    partial class Form1
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
            this.userInt1 = new System.Windows.Forms.TextBox();
            this.userInt2 = new System.Windows.Forms.TextBox();
            this.mathOperations = new System.Windows.Forms.ComboBox();
            this.equalsButton = new System.Windows.Forms.Button();
            this.mathResult = new System.Windows.Forms.Label();
            this.userResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // userInt1
            // 
            this.userInt1.Location = new System.Drawing.Point(12, 44);
            this.userInt1.Name = "userInt1";
            this.userInt1.Size = new System.Drawing.Size(100, 20);
            this.userInt1.TabIndex = 0;
            this.userInt1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // userInt2
            // 
            this.userInt2.Location = new System.Drawing.Point(172, 44);
            this.userInt2.Name = "userInt2";
            this.userInt2.Size = new System.Drawing.Size(100, 20);
            this.userInt2.TabIndex = 1;
            this.userInt2.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // mathOperations
            // 
            this.mathOperations.FormattingEnabled = true;
            this.mathOperations.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/"});
            this.mathOperations.Location = new System.Drawing.Point(78, 100);
            this.mathOperations.Name = "mathOperations";
            this.mathOperations.Size = new System.Drawing.Size(121, 21);
            this.mathOperations.TabIndex = 2;
            this.mathOperations.Text = "Select An Operation";
            this.mathOperations.SelectedIndexChanged += new System.EventHandler(this.MathResult_Click);
            // 
            // equalsButton
            // 
            this.equalsButton.Location = new System.Drawing.Point(105, 147);
            this.equalsButton.Name = "equalsButton";
            this.equalsButton.Size = new System.Drawing.Size(75, 23);
            this.equalsButton.TabIndex = 3;
            this.equalsButton.Text = "=";
            this.equalsButton.UseVisualStyleBackColor = true;
            this.equalsButton.Click += new System.EventHandler(this.EqualsButton_Click);
            // 
            // mathResult
            // 
            this.mathResult.AutoSize = true;
            this.mathResult.Location = new System.Drawing.Point(137, 205);
            this.mathResult.Name = "mathResult";
            this.mathResult.Size = new System.Drawing.Size(0, 13);
            this.mathResult.TabIndex = 4;
            this.mathResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mathResult.Click += new System.EventHandler(this.MathResult_Click);
            // 
            // userResult
            // 
            this.userResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userResult.AutoSize = true;
            this.userResult.Location = new System.Drawing.Point(137, 205);
            this.userResult.Name = "userResult";
            this.userResult.Size = new System.Drawing.Size(13, 13);
            this.userResult.TabIndex = 5;
            this.userResult.Text = "4";
            this.userResult.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.userResult.Click += new System.EventHandler(this.Label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.userResult);
            this.Controls.Add(this.mathResult);
            this.Controls.Add(this.equalsButton);
            this.Controls.Add(this.mathOperations);
            this.Controls.Add(this.userInt2);
            this.Controls.Add(this.userInt1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userInt1;
        private System.Windows.Forms.TextBox userInt2;
        private System.Windows.Forms.ComboBox mathOperations;
        private System.Windows.Forms.Button equalsButton;
        private System.Windows.Forms.Label mathResult;
        private System.Windows.Forms.Label userResult;
    }
}

