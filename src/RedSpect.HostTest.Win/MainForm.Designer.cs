namespace RedSpect.HostTest.Win
{
    partial class MainForm
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
            this._textConsole = new System.Windows.Forms.TextBox();
            this._buttonClose = new System.Windows.Forms.Button();
            this._buttonAddText = new System.Windows.Forms.Button();
            this._textXValue = new System.Windows.Forms.TextBox();
            this._buttonSetValue = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _textConsole
            // 
            this._textConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._textConsole.BackColor = System.Drawing.Color.Black;
            this._textConsole.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._textConsole.ForeColor = System.Drawing.Color.White;
            this._textConsole.Location = new System.Drawing.Point(12, 12);
            this._textConsole.Multiline = true;
            this._textConsole.Name = "_textConsole";
            this._textConsole.ReadOnly = true;
            this._textConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this._textConsole.Size = new System.Drawing.Size(508, 263);
            this._textConsole.TabIndex = 0;
            // 
            // _buttonClose
            // 
            this._buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonClose.Location = new System.Drawing.Point(445, 281);
            this._buttonClose.Name = "_buttonClose";
            this._buttonClose.Size = new System.Drawing.Size(75, 23);
            this._buttonClose.TabIndex = 1;
            this._buttonClose.Text = "&Close";
            this._buttonClose.UseVisualStyleBackColor = true;
            this._buttonClose.Click += new System.EventHandler(this._buttonClose_Click);
            // 
            // _buttonAddText
            // 
            this._buttonAddText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonAddText.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonAddText.Location = new System.Drawing.Point(12, 281);
            this._buttonAddText.Name = "_buttonAddText";
            this._buttonAddText.Size = new System.Drawing.Size(75, 23);
            this._buttonAddText.TabIndex = 2;
            this._buttonAddText.Text = "&Add Text";
            this._buttonAddText.UseVisualStyleBackColor = true;
            this._buttonAddText.Click += new System.EventHandler(this._buttonAddText_Click);
            // 
            // _textXValue
            // 
            this._textXValue.Location = new System.Drawing.Point(93, 284);
            this._textXValue.Name = "_textXValue";
            this._textXValue.Size = new System.Drawing.Size(100, 20);
            this._textXValue.TabIndex = 3;
            // 
            // _buttonSetValue
            // 
            this._buttonSetValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonSetValue.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonSetValue.Location = new System.Drawing.Point(199, 282);
            this._buttonSetValue.Name = "_buttonSetValue";
            this._buttonSetValue.Size = new System.Drawing.Size(89, 23);
            this._buttonSetValue.TabIndex = 4;
            this._buttonSetValue.Text = "&Set Value of X";
            this._buttonSetValue.UseVisualStyleBackColor = true;
            this._buttonSetValue.Click += new System.EventHandler(this._buttonSetValue_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._buttonClose;
            this.ClientSize = new System.Drawing.Size(532, 316);
            this.Controls.Add(this._buttonSetValue);
            this.Controls.Add(this._textXValue);
            this.Controls.Add(this._buttonAddText);
            this.Controls.Add(this._buttonClose);
            this.Controls.Add(this._textConsole);
            this.Name = "MainForm";
            this.Text = "Host Test - Windows";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _textConsole;
        private System.Windows.Forms.Button _buttonClose;
        private System.Windows.Forms.Button _buttonAddText;
        private System.Windows.Forms.TextBox _textXValue;
        private System.Windows.Forms.Button _buttonSetValue;
    }
}

