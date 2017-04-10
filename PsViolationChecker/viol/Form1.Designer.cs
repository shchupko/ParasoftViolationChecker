namespace viol
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
            this.components = new System.ComponentModel.Container();
            this.LogRText = new System.Windows.Forms.RichTextBox();
            this.contextMenuLog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenuLog_LoadFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // LogRText
            // 
            this.LogRText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogRText.ContextMenuStrip = this.contextMenuLog;
            this.LogRText.Location = new System.Drawing.Point(2, 22);
            this.LogRText.Name = "LogRText";
            this.LogRText.Size = new System.Drawing.Size(1328, 361);
            this.LogRText.TabIndex = 2;
            this.LogRText.Text = "";
            this.LogRText.TextChanged += new System.EventHandler(this.LogRText_TextChanged);
            // 
            // contextMenuLog
            // 
            this.contextMenuLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuLog_LoadFile,
            this.toolStripSeparator2});
            this.contextMenuLog.Name = "contextMenuClient";
            this.contextMenuLog.ShowCheckMargin = true;
            this.contextMenuLog.Size = new System.Drawing.Size(144, 32);
            // 
            // tsMenuLog_LoadFile
            // 
            this.tsMenuLog_LoadFile.Name = "tsMenuLog_LoadFile";
            this.tsMenuLog_LoadFile.Size = new System.Drawing.Size(143, 22);
            this.tsMenuLog_LoadFile.Text = "Load File";
            this.tsMenuLog_LoadFile.Click += new System.EventHandler(this.tsMenuLog_LoadFile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(140, 6);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "log";
            this.openFileDialog.InitialDirectory = "D:\\Program files\\NICE Systems\\CTI\\Log";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 395);
            this.Controls.Add(this.LogRText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.contextMenuLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox LogRText;
        private System.Windows.Forms.ContextMenuStrip contextMenuLog;
        private System.Windows.Forms.ToolStripMenuItem tsMenuLog_LoadFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

