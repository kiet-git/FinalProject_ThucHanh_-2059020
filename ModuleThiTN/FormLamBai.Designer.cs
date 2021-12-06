
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
            this.lbQuestion = new System.Windows.Forms.Label();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnHighlight = new System.Windows.Forms.Button();
            this.btnUnhighlight = new System.Windows.Forms.Button();
            this.uscClock1 = new ModuleThiTN.uscClock();
            this.SuspendLayout();
            // 
            // lvwQuestion
            // 
            this.lvwQuestion.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.lvwQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwQuestion.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lvwQuestion.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lvwQuestion.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            this.lvwQuestion.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvwQuestion.Location = new System.Drawing.Point(12, 12);
            this.lvwQuestion.MultiSelect = false;
            this.lvwQuestion.Name = "lvwQuestion";
            this.lvwQuestion.Size = new System.Drawing.Size(232, 423);
            this.lvwQuestion.TabIndex = 1;
            this.lvwQuestion.TileSize = new System.Drawing.Size(600, 30);
            this.lvwQuestion.UseCompatibleStateImageBehavior = false;
            this.lvwQuestion.View = System.Windows.Forms.View.Tile;
            this.lvwQuestion.SelectedIndexChanged += new System.EventHandler(this.lvwQuestion_SelectedIndexChanged);
            this.lvwQuestion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvwQuestion_MouseClick);
            // 
            // lbQuestion
            // 
            this.lbQuestion.AutoSize = true;
            this.lbQuestion.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbQuestion.Location = new System.Drawing.Point(250, 83);
            this.lbQuestion.Name = "lbQuestion";
            this.lbQuestion.Size = new System.Drawing.Size(0, 30);
            this.lbQuestion.TabIndex = 2;
            // 
            // btnFinish
            // 
            this.btnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinish.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFinish.Location = new System.Drawing.Point(613, 450);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(169, 34);
            this.btnFinish.TabIndex = 5;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnNext.Location = new System.Drawing.Point(438, 450);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(169, 34);
            this.btnNext.TabIndex = 4;
            this.btnNext.TabStop = false;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrev.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnPrev.Location = new System.Drawing.Point(263, 450);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(169, 34);
            this.btnPrev.TabIndex = 3;
            this.btnPrev.Text = "Previous";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnHighlight
            // 
            this.btnHighlight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHighlight.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnHighlight.Location = new System.Drawing.Point(12, 450);
            this.btnHighlight.Name = "btnHighlight";
            this.btnHighlight.Size = new System.Drawing.Size(110, 34);
            this.btnHighlight.TabIndex = 1;
            this.btnHighlight.Text = "Highlight";
            this.btnHighlight.UseVisualStyleBackColor = true;
            this.btnHighlight.Click += new System.EventHandler(this.btnHighlight_Click);
            // 
            // btnUnhighlight
            // 
            this.btnUnhighlight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnhighlight.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnUnhighlight.Location = new System.Drawing.Point(128, 450);
            this.btnUnhighlight.Name = "btnUnhighlight";
            this.btnUnhighlight.Size = new System.Drawing.Size(116, 34);
            this.btnUnhighlight.TabIndex = 2;
            this.btnUnhighlight.Text = "Unhighlight";
            this.btnUnhighlight.UseVisualStyleBackColor = true;
            this.btnUnhighlight.Click += new System.EventHandler(this.btnUnhighlight_Click);
            // 
            // uscClock1
            // 
            this.uscClock1._mm = 0;
            this.uscClock1._ss = 0;
            this.uscClock1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uscClock1.Location = new System.Drawing.Point(428, 12);
            this.uscClock1.Name = "uscClock1";
            this.uscClock1.Size = new System.Drawing.Size(229, 39);
            this.uscClock1.TabIndex = 6;
            // 
            // FormLamBai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 496);
            this.Controls.Add(this.uscClock1);
            this.Controls.Add(this.btnUnhighlight);
            this.Controls.Add(this.btnHighlight);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.lbQuestion);
            this.Controls.Add(this.lvwQuestion);
            this.Name = "FormLamBai";
            this.Text = "FormLamBai";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLamBai_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLamBai_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvwQuestion;
        private System.Windows.Forms.Label lbQuestion;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnHighlight;
        private System.Windows.Forms.Button btnUnhighlight;
        private uscClock uscClock1;
    }
}