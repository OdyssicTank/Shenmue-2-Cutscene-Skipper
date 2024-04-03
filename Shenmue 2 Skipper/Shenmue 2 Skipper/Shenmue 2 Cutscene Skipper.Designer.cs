namespace Shenmue_2_Skipper
{
    partial class ShenmueForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblGameProcess = new System.Windows.Forms.Label();
            this.btnToggleSkipper = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGameProcess
            // 
            this.lblGameProcess.AutoSize = true;
            this.lblGameProcess.Location = new System.Drawing.Point(12, 9);
            this.lblGameProcess.Name = "lblGameProcess";
            this.lblGameProcess.Size = new System.Drawing.Size(0, 20);
            this.lblGameProcess.TabIndex = 0;
            this.lblGameProcess.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnToggleSkipper
            // 
            this.btnToggleSkipper.Enabled = false;
            this.btnToggleSkipper.Location = new System.Drawing.Point(60, 67);
            this.btnToggleSkipper.Name = "btnToggleSkipper";
            this.btnToggleSkipper.Size = new System.Drawing.Size(313, 77);
            this.btnToggleSkipper.TabIndex = 1;
            this.btnToggleSkipper.Text = "Enable Cutscene Skipper";
            this.btnToggleSkipper.UseVisualStyleBackColor = true;
            this.btnToggleSkipper.Click += new System.EventHandler(this.btnToggleSkipper_Click);
            // 
            // ShenmueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 171);
            this.Controls.Add(this.btnToggleSkipper);
            this.Controls.Add(this.lblGameProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ShenmueForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shenmue 2 Cutscene Skipper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblGameProcess;
        private Button btnToggleSkipper;
    }
}