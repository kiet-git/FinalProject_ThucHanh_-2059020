
namespace ModuleThi
{
    partial class FormLamBai
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
            this.panelAnswer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelAnswer
            // 
            this.panelAnswer.AutoScroll = true;
            this.panelAnswer.AutoScrollMargin = new System.Drawing.Size(0, 500);
            this.panelAnswer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAnswer.Location = new System.Drawing.Point(259, 137);
            this.panelAnswer.Name = "panelAnswer";
            this.panelAnswer.Size = new System.Drawing.Size(529, 301);
            this.panelAnswer.TabIndex = 0;
            // 
            // FormLamBai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panelAnswer);
            this.Name = "FormLamBai";
            this.Text = "FormLamBai";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAnswer;
    }
}