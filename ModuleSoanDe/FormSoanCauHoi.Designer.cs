namespace ModuleSoanDe
{
    partial class FormSoanCauHoi
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
            this.btnDeleteQ = new System.Windows.Forms.Button();
            this.btnUpdateQ = new System.Windows.Forms.Button();
            this.btnAddQ = new System.Windows.Forms.Button();
            this.listBoxQuestions = new System.Windows.Forms.ListBox();
            this.lbListOfQ = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDeleteQ
            // 
            this.btnDeleteQ.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDeleteQ.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteQ.Location = new System.Drawing.Point(581, 78);
            this.btnDeleteQ.Name = "btnDeleteQ";
            this.btnDeleteQ.Size = new System.Drawing.Size(177, 34);
            this.btnDeleteQ.TabIndex = 3;
            this.btnDeleteQ.Text = "Delete Question";
            this.btnDeleteQ.UseVisualStyleBackColor = true;
            this.btnDeleteQ.Click += new System.EventHandler(this.btnDeleteQ_Click);
            // 
            // btnUpdateQ
            // 
            this.btnUpdateQ.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUpdateQ.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUpdateQ.Location = new System.Drawing.Point(396, 78);
            this.btnUpdateQ.Name = "btnUpdateQ";
            this.btnUpdateQ.Size = new System.Drawing.Size(179, 34);
            this.btnUpdateQ.TabIndex = 2;
            this.btnUpdateQ.Text = "Update Question";
            this.btnUpdateQ.UseVisualStyleBackColor = true;
            this.btnUpdateQ.Click += new System.EventHandler(this.btnUpdateQ_Click);
            // 
            // btnAddQ
            // 
            this.btnAddQ.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddQ.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddQ.Location = new System.Drawing.Point(217, 78);
            this.btnAddQ.Name = "btnAddQ";
            this.btnAddQ.Size = new System.Drawing.Size(173, 34);
            this.btnAddQ.TabIndex = 1;
            this.btnAddQ.Text = "Add Question";
            this.btnAddQ.UseVisualStyleBackColor = true;
            this.btnAddQ.Click += new System.EventHandler(this.btnAddQ_Click);
            // 
            // listBoxQuestions
            // 
            this.listBoxQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxQuestions.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxQuestions.FormattingEnabled = true;
            this.listBoxQuestions.HorizontalScrollbar = true;
            this.listBoxQuestions.ItemHeight = 25;
            this.listBoxQuestions.Location = new System.Drawing.Point(24, 129);
            this.listBoxQuestions.Name = "listBoxQuestions";
            this.listBoxQuestions.ScrollAlwaysVisible = true;
            this.listBoxQuestions.Size = new System.Drawing.Size(744, 204);
            this.listBoxQuestions.TabIndex = 17;
            this.listBoxQuestions.SelectedIndexChanged += new System.EventHandler(this.listBoxQuestions_SelectedIndexChanged);
            // 
            // lbListOfQ
            // 
            this.lbListOfQ.AutoSize = true;
            this.lbListOfQ.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbListOfQ.Location = new System.Drawing.Point(25, 78);
            this.lbListOfQ.Name = "lbListOfQ";
            this.lbListOfQ.Size = new System.Drawing.Size(175, 30);
            this.lbListOfQ.TabIndex = 16;
            this.lbListOfQ.Text = "List of questions";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExit.Location = new System.Drawing.Point(408, 348);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(362, 34);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(24, 348);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(378, 34);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save to file";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(453, 30);
            this.label1.TabIndex = 16;
            this.label1.Text = "Question bank path: bank\\dataQuestion.xml";
            // 
            // FormSoanCauHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 403);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDeleteQ);
            this.Controls.Add(this.btnUpdateQ);
            this.Controls.Add(this.btnAddQ);
            this.Controls.Add(this.listBoxQuestions);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbListOfQ);
            this.Name = "FormSoanCauHoi";
            this.Text = "FormSoanCauHoi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSoanCauHoi_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteQ;
        private System.Windows.Forms.Button btnUpdateQ;
        private System.Windows.Forms.Button btnAddQ;
        private System.Windows.Forms.ListBox listBoxQuestions;
        private System.Windows.Forms.Label lbListOfQ;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
    }
}