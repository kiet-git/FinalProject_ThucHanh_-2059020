
namespace ModuleThiTN
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("1");
            this.lvwQuestion = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvwQuestion
            // 
            this.lvwQuestion.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.lvwQuestion.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lvwQuestion.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lvwQuestion.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            this.lvwQuestion.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvwQuestion.Location = new System.Drawing.Point(12, 65);
            this.lvwQuestion.Name = "lvwQuestion";
            this.lvwQuestion.Size = new System.Drawing.Size(232, 373);
            this.lvwQuestion.TabIndex = 1;
            this.lvwQuestion.UseCompatibleStateImageBehavior = false;
            this.lvwQuestion.View = System.Windows.Forms.View.List;
            this.lvwQuestion.SelectedIndexChanged += new System.EventHandler(this.lvwQuestion_SelectedIndexChanged);
            this.lvwQuestion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvwQuestion_MouseClick);
            // 
            // FormLamBai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvwQuestion);
            this.Name = "FormLamBai";
            this.Text = "FormLamBai";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView lvwQuestion;
    }
}