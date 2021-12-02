
namespace ModuleSoanDe
{
    partial class uscMCAInput
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMakeCorrect = new System.Windows.Forms.Button();
            this.btnDeleteA = new System.Windows.Forms.Button();
            this.btnUpdateA = new System.Windows.Forms.Button();
            this.btnAddA = new System.Windows.Forms.Button();
            this.listBoxAnswers = new System.Windows.Forms.ListBox();
            this.txtCorrectAnswer = new System.Windows.Forms.TextBox();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.lbListOfA = new System.Windows.Forms.Label();
            this.lbCorrectIndex = new System.Windows.Forms.Label();
            this.lbAnswer = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnMakeCorrect);
            this.groupBox1.Controls.Add(this.btnDeleteA);
            this.groupBox1.Controls.Add(this.btnUpdateA);
            this.groupBox1.Controls.Add(this.btnAddA);
            this.groupBox1.Controls.Add(this.listBoxAnswers);
            this.groupBox1.Controls.Add(this.txtCorrectAnswer);
            this.groupBox1.Controls.Add(this.txtAnswer);
            this.groupBox1.Controls.Add(this.lbListOfA);
            this.groupBox1.Controls.Add(this.lbCorrectIndex);
            this.groupBox1.Controls.Add(this.lbAnswer);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(769, 369);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnMakeCorrect
            // 
            this.btnMakeCorrect.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnMakeCorrect.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnMakeCorrect.Location = new System.Drawing.Point(578, 99);
            this.btnMakeCorrect.Name = "btnMakeCorrect";
            this.btnMakeCorrect.Size = new System.Drawing.Size(177, 34);
            this.btnMakeCorrect.TabIndex = 15;
            this.btnMakeCorrect.Text = "Make Correct";
            this.btnMakeCorrect.UseVisualStyleBackColor = true;
            this.btnMakeCorrect.Click += new System.EventHandler(this.btnMakeCorrect_Click);
            // 
            // btnDeleteA
            // 
            this.btnDeleteA.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDeleteA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteA.Location = new System.Drawing.Point(578, 149);
            this.btnDeleteA.Name = "btnDeleteA";
            this.btnDeleteA.Size = new System.Drawing.Size(177, 34);
            this.btnDeleteA.TabIndex = 15;
            this.btnDeleteA.Text = "Delete Answer";
            this.btnDeleteA.UseVisualStyleBackColor = true;
            this.btnDeleteA.Click += new System.EventHandler(this.btnDeleteA_Click);
            // 
            // btnUpdateA
            // 
            this.btnUpdateA.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUpdateA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUpdateA.Location = new System.Drawing.Point(373, 149);
            this.btnUpdateA.Name = "btnUpdateA";
            this.btnUpdateA.Size = new System.Drawing.Size(183, 34);
            this.btnUpdateA.TabIndex = 14;
            this.btnUpdateA.Text = "Update Answer";
            this.btnUpdateA.UseVisualStyleBackColor = true;
            this.btnUpdateA.Click += new System.EventHandler(this.btnUpdateA_Click);
            // 
            // btnAddA
            // 
            this.btnAddA.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddA.Location = new System.Drawing.Point(175, 149);
            this.btnAddA.Name = "btnAddA";
            this.btnAddA.Size = new System.Drawing.Size(179, 34);
            this.btnAddA.TabIndex = 13;
            this.btnAddA.Text = "Add Answer";
            this.btnAddA.UseVisualStyleBackColor = true;
            this.btnAddA.Click += new System.EventHandler(this.btnAddA_Click);
            // 
            // listBoxAnswers
            // 
            this.listBoxAnswers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxAnswers.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxAnswers.FormattingEnabled = true;
            this.listBoxAnswers.HorizontalScrollbar = true;
            this.listBoxAnswers.ItemHeight = 25;
            this.listBoxAnswers.Location = new System.Drawing.Point(11, 200);
            this.listBoxAnswers.Name = "listBoxAnswers";
            this.listBoxAnswers.ScrollAlwaysVisible = true;
            this.listBoxAnswers.Size = new System.Drawing.Size(744, 154);
            this.listBoxAnswers.TabIndex = 12;
            this.listBoxAnswers.SelectedIndexChanged += new System.EventHandler(this.listBoxAnswers_SelectedIndexChanged);
            // 
            // txtCorrectAnswer
            // 
            this.txtCorrectAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCorrectAnswer.Enabled = false;
            this.txtCorrectAnswer.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCorrectAnswer.Location = new System.Drawing.Point(175, 94);
            this.txtCorrectAnswer.Name = "txtCorrectAnswer";
            this.txtCorrectAnswer.Size = new System.Drawing.Size(381, 39);
            this.txtCorrectAnswer.TabIndex = 11;
            // 
            // txtAnswer
            // 
            this.txtAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnswer.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAnswer.Location = new System.Drawing.Point(175, 32);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(580, 39);
            this.txtAnswer.TabIndex = 11;
            // 
            // lbListOfA
            // 
            this.lbListOfA.AutoSize = true;
            this.lbListOfA.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbListOfA.Location = new System.Drawing.Point(11, 149);
            this.lbListOfA.Name = "lbListOfA";
            this.lbListOfA.Size = new System.Drawing.Size(158, 30);
            this.lbListOfA.TabIndex = 9;
            this.lbListOfA.Text = "List of answers";
            // 
            // lbCorrectIndex
            // 
            this.lbCorrectIndex.AutoSize = true;
            this.lbCorrectIndex.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbCorrectIndex.Location = new System.Drawing.Point(6, 99);
            this.lbCorrectIndex.Name = "lbCorrectIndex";
            this.lbCorrectIndex.Size = new System.Drawing.Size(163, 30);
            this.lbCorrectIndex.TabIndex = 10;
            this.lbCorrectIndex.Text = "Correct Answer";
            // 
            // lbAnswer
            // 
            this.lbAnswer.AutoSize = true;
            this.lbAnswer.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbAnswer.Location = new System.Drawing.Point(83, 37);
            this.lbAnswer.Name = "lbAnswer";
            this.lbAnswer.Size = new System.Drawing.Size(86, 30);
            this.lbAnswer.TabIndex = 10;
            this.lbAnswer.Text = "Answer";
            // 
            // uscMCAInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "uscMCAInput";
            this.Size = new System.Drawing.Size(775, 389);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDeleteA;
        private System.Windows.Forms.Button btnUpdateA;
        private System.Windows.Forms.Button btnAddA;
        private System.Windows.Forms.ListBox listBoxAnswers;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Label lbListOfA;
        private System.Windows.Forms.Label lbAnswer;
        private System.Windows.Forms.Button btnMakeCorrect;
        private System.Windows.Forms.TextBox txtCorrectAnswer;
        private System.Windows.Forms.Label lbCorrectIndex;
    }
}
