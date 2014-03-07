namespace PinterestGet100
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
            this.btnGet = new System.Windows.Forms.Button();
            this.btnChooseDir = new System.Windows.Forms.Button();
            this.tbxDir = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lbxOutput = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxAmount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGet
            // 
            this.btnGet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGet.Location = new System.Drawing.Point(672, 40);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(100, 23);
            this.btnGet.TabIndex = 0;
            this.btnGet.Text = "Save images";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.GetImages);
            // 
            // btnChooseDir
            // 
            this.btnChooseDir.Location = new System.Drawing.Point(13, 12);
            this.btnChooseDir.Name = "btnChooseDir";
            this.btnChooseDir.Size = new System.Drawing.Size(100, 23);
            this.btnChooseDir.TabIndex = 2;
            this.btnChooseDir.Text = "Choose directory";
            this.btnChooseDir.UseVisualStyleBackColor = true;
            this.btnChooseDir.Click += new System.EventHandler(this.ChooseDir);
            // 
            // tbxDir
            // 
            this.tbxDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxDir.Enabled = false;
            this.tbxDir.Location = new System.Drawing.Point(119, 14);
            this.tbxDir.Name = "tbxDir";
            this.tbxDir.Size = new System.Drawing.Size(653, 20);
            this.tbxDir.TabIndex = 3;
            // 
            // lbxOutput
            // 
            this.lbxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxOutput.FormattingEnabled = true;
            this.lbxOutput.HorizontalScrollbar = true;
            this.lbxOutput.Location = new System.Drawing.Point(13, 69);
            this.lbxOutput.Name = "lbxOutput";
            this.lbxOutput.Size = new System.Drawing.Size(760, 485);
            this.lbxOutput.TabIndex = 4;
            this.lbxOutput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SpacePress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Amount of Images";
            // 
            // tbxAmount
            // 
            this.tbxAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxAmount.Location = new System.Drawing.Point(119, 42);
            this.tbxAmount.MaxLength = 4;
            this.tbxAmount.Name = "tbxAmount";
            this.tbxAmount.Size = new System.Drawing.Size(547, 20);
            this.tbxAmount.TabIndex = 6;
            this.tbxAmount.Text = "100";
            this.tbxAmount.Validating += new System.ComponentModel.CancelEventHandler(this.TbxAmountValidating);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tbxAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxOutput);
            this.Controls.Add(this.tbxDir);
            this.Controls.Add(this.btnChooseDir);
            this.Controls.Add(this.btnGet);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Popular on pinterest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnChooseDir;
        private System.Windows.Forms.TextBox tbxDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ListBox lbxOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxAmount;
    }
}

