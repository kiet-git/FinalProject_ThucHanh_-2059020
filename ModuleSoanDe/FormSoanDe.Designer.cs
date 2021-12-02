namespace ModuleSoanDe
{
    partial class FormSoanDe
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
            this.btnCreateQuestion = new System.Windows.Forms.Button();
            this.btnCreateTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreateQuestion
            // 
            this.btnCreateQuestion.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCreateQuestion.Location = new System.Drawing.Point(105, 26);
            this.btnCreateQuestion.Name = "btnCreateQuestion";
            this.btnCreateQuestion.Size = new System.Drawing.Size(348, 83);
            this.btnCreateQuestion.TabIndex = 0;
            this.btnCreateQuestion.Text = "Create Question";
            this.btnCreateQuestion.UseVisualStyleBackColor = true;
            this.btnCreateQuestion.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCreateTest
            // 
            this.btnCreateTest.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCreateTest.Location = new System.Drawing.Point(105, 129);
            this.btnCreateTest.Name = "btnCreateTest";
            this.btnCreateTest.Size = new System.Drawing.Size(348, 83);
            this.btnCreateTest.TabIndex = 0;
            this.btnCreateTest.Text = "Create Test";
            this.btnCreateTest.UseVisualStyleBackColor = true;
            this.btnCreateTest.Click += new System.EventHandler(this.btnCreateTest_Click);
            // 
            // FormSoanDe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 378);
            this.Controls.Add(this.btnCreateTest);
            this.Controls.Add(this.btnCreateQuestion);
            this.Name = "FormSoanDe";
            this.Text = "FormSoanDe";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCreateQuestion;
        private System.Windows.Forms.Button btnCreateTest;
    }
}