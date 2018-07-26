namespace ProgramDama2
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
            this.HraciPlocha = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.HracSitovy = new System.Windows.Forms.Button();
            this.HracLokalni = new System.Windows.Forms.Button();
            this.LabelHrac = new System.Windows.Forms.Label();
            this.IPadresaTextbox = new System.Windows.Forms.TextBox();
            this.HraciPlocha.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // HraciPlocha
            // 
            this.HraciPlocha.Controls.Add(this.panel1);
            this.HraciPlocha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HraciPlocha.Location = new System.Drawing.Point(0, 0);
            this.HraciPlocha.Name = "HraciPlocha";
            this.HraciPlocha.Size = new System.Drawing.Size(886, 753);
            this.HraciPlocha.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.IPadresaTextbox);
            this.panel1.Controls.Add(this.HracSitovy);
            this.panel1.Controls.Add(this.HracLokalni);
            this.panel1.Controls.Add(this.LabelHrac);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(686, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 753);
            this.panel1.TabIndex = 0;
            // 
            // HracSitovy
            // 
            this.HracSitovy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.HracSitovy.Location = new System.Drawing.Point(29, 146);
            this.HracSitovy.Name = "HracSitovy";
            this.HracSitovy.Size = new System.Drawing.Size(132, 44);
            this.HracSitovy.TabIndex = 2;
            this.HracSitovy.Text = "HracSitovy";
            this.HracSitovy.UseVisualStyleBackColor = true;
            this.HracSitovy.Click += new System.EventHandler(this.HracSitovy_Click);
            // 
            // HracLokalni
            // 
            this.HracLokalni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.HracLokalni.Location = new System.Drawing.Point(29, 101);
            this.HracLokalni.Name = "HracLokalni";
            this.HracLokalni.Size = new System.Drawing.Size(132, 39);
            this.HracLokalni.TabIndex = 1;
            this.HracLokalni.Text = "HracLokalni";
            this.HracLokalni.UseVisualStyleBackColor = true;
            this.HracLokalni.Click += new System.EventHandler(this.HracLokalni_Click);
            // 
            // LabelHrac
            // 
            this.LabelHrac.AutoSize = true;
            this.LabelHrac.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LabelHrac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LabelHrac.Location = new System.Drawing.Point(29, 70);
            this.LabelHrac.Margin = new System.Windows.Forms.Padding(1);
            this.LabelHrac.Name = "LabelHrac";
            this.LabelHrac.Size = new System.Drawing.Size(60, 27);
            this.LabelHrac.TabIndex = 0;
            this.LabelHrac.Text = "Hraje";
            // 
            // IPadresaTextbox
            // 
            this.IPadresaTextbox.Location = new System.Drawing.Point(29, 314);
            this.IPadresaTextbox.Name = "IPadresaTextbox";
            this.IPadresaTextbox.Size = new System.Drawing.Size(132, 22);
            this.IPadresaTextbox.TabIndex = 3;
            this.IPadresaTextbox.Text = "pokud jsi sitovy hra jsem zadej IPserveru";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(886, 753);
            this.Controls.Add(this.HraciPlocha);
            this.Name = "Form1";
            this.Text = "Form1";
            this.HraciPlocha.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel HraciPlocha;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LabelHrac;
        private System.Windows.Forms.Button HracLokalni;
        private System.Windows.Forms.Button HracSitovy;
        private System.Windows.Forms.TextBox IPadresaTextbox;
    }
}

