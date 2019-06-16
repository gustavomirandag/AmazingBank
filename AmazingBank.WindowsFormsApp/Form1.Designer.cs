namespace AmazingBank.WindowsFormsApp
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
            this.btnProcessSomething = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProcessSomething
            // 
            this.btnProcessSomething.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessSomething.Location = new System.Drawing.Point(120, 179);
            this.btnProcessSomething.Name = "btnProcessSomething";
            this.btnProcessSomething.Size = new System.Drawing.Size(243, 74);
            this.btnProcessSomething.TabIndex = 0;
            this.btnProcessSomething.Text = "Process Something";
            this.btnProcessSomething.UseVisualStyleBackColor = true;
            this.btnProcessSomething.Click += new System.EventHandler(this.btnProcessSomething_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 458);
            this.Controls.Add(this.btnProcessSomething);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProcessSomething;
    }
}

