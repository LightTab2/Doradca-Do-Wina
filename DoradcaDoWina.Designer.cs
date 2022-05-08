using System.Drawing;

namespace DoradcaDoWina
{
    partial class DoradcaDoWina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoradcaDoWina));
            this.autoTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.choicesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.prevButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.autoTableLayoutPanel.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // autoTableLayoutPanel
            // 
            this.autoTableLayoutPanel.AutoSize = true;
            this.autoTableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.autoTableLayoutPanel.BackColor = System.Drawing.Color.Maroon;
            this.autoTableLayoutPanel.BackgroundImage = global::DoradcaDoWina.Properties.Resources.bg;
            this.autoTableLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.autoTableLayoutPanel.ColumnCount = 1;
            this.autoTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.autoTableLayoutPanel.Controls.Add(this.choicesPanel, 0, 1);
            this.autoTableLayoutPanel.Controls.Add(this.buttonsPanel, 0, 2);
            this.autoTableLayoutPanel.Controls.Add(this.messageLabel, 0, 0);
            this.autoTableLayoutPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.autoTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.autoTableLayoutPanel.Name = "autoTableLayoutPanel";
            this.autoTableLayoutPanel.RowCount = 3;
            this.autoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 68.62745F));
            this.autoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.92513F));
            this.autoTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.269162F));
            this.autoTableLayoutPanel.Size = new System.Drawing.Size(784, 561);
            this.autoTableLayoutPanel.TabIndex = 0;
            this.autoTableLayoutPanel.TabStop = true;
            // 
            // choicesPanel
            // 
            this.choicesPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.choicesPanel.AutoSize = true;
            this.choicesPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.choicesPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.choicesPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.choicesPanel.Font = new System.Drawing.Font("Fantasque Sans Mono", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.choicesPanel.ForeColor = System.Drawing.Color.Lime;
            this.choicesPanel.Location = new System.Drawing.Point(390, 444);
            this.choicesPanel.Name = "choicesPanel";
            this.choicesPanel.Size = new System.Drawing.Size(4, 4);
            this.choicesPanel.TabIndex = 2;
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonsPanel.AutoSize = true;
            this.buttonsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonsPanel.BackColor = System.Drawing.Color.Transparent;
            this.buttonsPanel.Controls.Add(this.prevButton);
            this.buttonsPanel.Controls.Add(this.nextButton);
            this.buttonsPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.buttonsPanel.Location = new System.Drawing.Point(8, 515);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Size = new System.Drawing.Size(768, 38);
            this.buttonsPanel.TabIndex = 1;
            // 
            // prevButton
            // 
            this.prevButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.prevButton.BackColor = System.Drawing.Color.PapayaWhip;
            this.prevButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.prevButton.Enabled = false;
            this.prevButton.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.prevButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Wheat;
            this.prevButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Bisque;
            this.prevButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevButton.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.prevButton.ForeColor = System.Drawing.Color.DarkRed;
            this.prevButton.Location = new System.Drawing.Point(3, 3);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(378, 32);
            this.prevButton.TabIndex = 0;
            this.prevButton.Tag = "Prev";
            this.prevButton.Text = "Poprzednie";
            this.prevButton.UseVisualStyleBackColor = false;
            this.prevButton.Click += new System.EventHandler(this.PrevButtonClick);
            // 
            // nextButton
            // 
            this.nextButton.BackColor = System.Drawing.Color.PapayaWhip;
            this.nextButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nextButton.FlatAppearance.BorderColor = System.Drawing.Color.YellowGreen;
            this.nextButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Wheat;
            this.nextButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Bisque;
            this.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextButton.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.nextButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.nextButton.Location = new System.Drawing.Point(387, 3);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(378, 32);
            this.nextButton.TabIndex = 1;
            this.nextButton.Tag = "Next";
            this.nextButton.Text = "Następne";
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.NextButtonClick);
            // 
            // messageLabel
            // 
            this.messageLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.messageLabel.AutoSize = true;
            this.messageLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.messageLabel.Cursor = System.Windows.Forms.Cursors.No;
            this.messageLabel.Font = new System.Drawing.Font("Segoe UI Black", 44F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.messageLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.messageLabel.Location = new System.Drawing.Point(296, 162);
            this.messageLabel.Margin = new System.Windows.Forms.Padding(40, 0, 40, 0);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(191, 60);
            this.messageLabel.TabIndex = 0;
            this.messageLabel.Text = "Pytanie";
            this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DoradcaDoWina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.autoTableLayoutPanel);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "DoradcaDoWina";
            this.Text = "Doradca do wina";
            this.autoTableLayoutPanel.ResumeLayout(false);
            this.autoTableLayoutPanel.PerformLayout();
            this.buttonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel autoTableLayoutPanel;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.FlowLayoutPanel buttonsPanel;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.FlowLayoutPanel choicesPanel;
    }
}

