
namespace ModuleSoanDe
{
    partial class FormTaoDe
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
            this.listBoxQIn = new System.Windows.Forms.ListBox();
            this.lbHub = new System.Windows.Forms.Label();
            this.listBoxQOut = new System.Windows.Forms.ListBox();
            this.btnAddQ = new System.Windows.Forms.Button();
            this.lbFinal = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNofQ = new System.Windows.Forms.TextBox();
            this.btnRandom = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.txtAvailable = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbMonth = new System.Windows.Forms.Label();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.lbYear = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBoxQIn
            // 
            this.listBoxQIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxQIn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxQIn.FormattingEnabled = true;
            this.listBoxQIn.HorizontalScrollbar = true;
            this.listBoxQIn.ItemHeight = 21;
            this.listBoxQIn.Location = new System.Drawing.Point(12, 93);
            this.listBoxQIn.Name = "listBoxQIn";
            this.listBoxQIn.ScrollAlwaysVisible = true;
            this.listBoxQIn.Size = new System.Drawing.Size(303, 256);
            this.listBoxQIn.TabIndex = 0;
            // 
            // lbHub
            // 
            this.lbHub.AutoSize = true;
            this.lbHub.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbHub.Location = new System.Drawing.Point(62, 56);
            this.lbHub.Name = "lbHub";
            this.lbHub.Size = new System.Drawing.Size(175, 30);
            this.lbHub.TabIndex = 17;
            this.lbHub.Text = "List of questions";
            // 
            // listBoxQOut
            // 
            this.listBoxQOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxQOut.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBoxQOut.FormattingEnabled = true;
            this.listBoxQOut.HorizontalScrollbar = true;
            this.listBoxQOut.ItemHeight = 21;
            this.listBoxQOut.Location = new System.Drawing.Point(475, 93);
            this.listBoxQOut.Name = "listBoxQOut";
            this.listBoxQOut.ScrollAlwaysVisible = true;
            this.listBoxQOut.Size = new System.Drawing.Size(303, 256);
            this.listBoxQOut.TabIndex = 0;
            // 
            // btnAddQ
            // 
            this.btnAddQ.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddQ.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAddQ.Location = new System.Drawing.Point(330, 179);
            this.btnAddQ.Name = "btnAddQ";
            this.btnAddQ.Size = new System.Drawing.Size(129, 34);
            this.btnAddQ.TabIndex = 6;
            this.btnAddQ.Text = "Add Question";
            this.btnAddQ.UseVisualStyleBackColor = true;
            this.btnAddQ.Click += new System.EventHandler(this.btnAddQ_Click);
            // 
            // lbFinal
            // 
            this.lbFinal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFinal.AutoSize = true;
            this.lbFinal.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbFinal.Location = new System.Drawing.Point(583, 56);
            this.lbFinal.Name = "lbFinal";
            this.lbFinal.Size = new System.Drawing.Size(104, 30);
            this.lbFinal.TabIndex = 17;
            this.lbFinal.Text = "Final Test";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.Location = new System.Drawing.Point(330, 232);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(129, 34);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 30);
            this.label1.TabIndex = 17;
            this.label1.Text = "Number of Questions";
            // 
            // txtNofQ
            // 
            this.txtNofQ.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNofQ.Location = new System.Drawing.Point(243, 12);
            this.txtNofQ.Name = "txtNofQ";
            this.txtNofQ.Size = new System.Drawing.Size(147, 39);
            this.txtNofQ.TabIndex = 1;
            this.txtNofQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnRandom
            // 
            this.btnRandom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRandom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRandom.Location = new System.Drawing.Point(597, 9);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(181, 42);
            this.btnRandom.TabIndex = 2;
            this.btnRandom.Text = "Randomize";
            this.btnRandom.UseVisualStyleBackColor = true;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClear.Location = new System.Drawing.Point(330, 285);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(129, 34);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(475, 357);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(144, 34);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save to file";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExit.Location = new System.Drawing.Point(636, 357);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(142, 34);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnView
            // 
            this.btnView.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnView.Location = new System.Drawing.Point(330, 126);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(129, 34);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "View Question";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // txtAvailable
            // 
            this.txtAvailable.Enabled = false;
            this.txtAvailable.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAvailable.Location = new System.Drawing.Point(432, 12);
            this.txtAvailable.Name = "txtAvailable";
            this.txtAvailable.Size = new System.Drawing.Size(147, 39);
            this.txtAvailable.TabIndex = 2;
            this.txtAvailable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(396, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 47);
            this.label2.TabIndex = 17;
            this.label2.Text = "/";
            // 
            // lbMonth
            // 
            this.lbMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbMonth.AutoSize = true;
            this.lbMonth.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbMonth.Location = new System.Drawing.Point(12, 357);
            this.lbMonth.Name = "lbMonth";
            this.lbMonth.Size = new System.Drawing.Size(80, 30);
            this.lbMonth.TabIndex = 17;
            this.lbMonth.Text = "Month";
            // 
            // txtMonth
            // 
            this.txtMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMonth.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtMonth.Location = new System.Drawing.Point(98, 352);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(71, 39);
            this.txtMonth.TabIndex = 3;
            this.txtMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbYear
            // 
            this.lbYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbYear.AutoSize = true;
            this.lbYear.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbYear.Location = new System.Drawing.Point(183, 357);
            this.lbYear.Name = "lbYear";
            this.lbYear.Size = new System.Drawing.Size(54, 30);
            this.lbYear.TabIndex = 17;
            this.lbYear.Text = "Year";
            // 
            // txtYear
            // 
            this.txtYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtYear.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtYear.Location = new System.Drawing.Point(243, 352);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(71, 39);
            this.txtYear.TabIndex = 4;
            this.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormTaoDe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 403);
            this.Controls.Add(this.txtAvailable);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtMonth);
            this.Controls.Add(this.txtNofQ);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRandom);
            this.Controls.Add(this.btnAddQ);
            this.Controls.Add(this.lbFinal);
            this.Controls.Add(this.lbYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbMonth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbHub);
            this.Controls.Add(this.listBoxQOut);
            this.Controls.Add(this.listBoxQIn);
            this.Name = "FormTaoDe";
            this.Text = "FormTaoDe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTaoDe_FormClosing);
            this.Load += new System.EventHandler(this.FormTaoDe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxQIn;
        private System.Windows.Forms.Label lbHub;
        private System.Windows.Forms.ListBox listBoxQOut;
        private System.Windows.Forms.Button btnAddQ;
        private System.Windows.Forms.Label lbFinal;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNofQ;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.TextBox txtAvailable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbMonth;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.Label lbYear;
        private System.Windows.Forms.TextBox txtYear;
    }
}