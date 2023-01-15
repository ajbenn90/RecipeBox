namespace IngredientScraper
{
    partial class IngredientScraperForm
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
            this.scrapeButton = new System.Windows.Forms.Button();
            this.toTxtButton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // scrapeButton
            // 
            this.scrapeButton.Location = new System.Drawing.Point(710, 46);
            this.scrapeButton.Name = "scrapeButton";
            this.scrapeButton.Size = new System.Drawing.Size(75, 23);
            this.scrapeButton.TabIndex = 0;
            this.scrapeButton.Text = "Scrape";
            this.scrapeButton.UseVisualStyleBackColor = true;
            this.scrapeButton.Click += new System.EventHandler(this.scrapeButton_Click);
            // 
            // toCsvButton
            // 
            this.toTxtButton.Location = new System.Drawing.Point(710, 86);
            this.toTxtButton.Name = "toCsvButton";
            this.toTxtButton.Size = new System.Drawing.Size(75, 23);
            this.toTxtButton.TabIndex = 1;
            this.toTxtButton.Text = "To csv";
            this.toTxtButton.UseVisualStyleBackColor = true;
            this.toTxtButton.Click += new System.EventHandler(this.toTxtButton_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(12, 12);
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.Size = new System.Drawing.Size(692, 426);
            this.logTextBox.TabIndex = 2;
            this.logTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.toTxtButton);
            this.Controls.Add(this.scrapeButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button scrapeButton;
        private Button toTxtButton;
        private RichTextBox logTextBox;
    }
}