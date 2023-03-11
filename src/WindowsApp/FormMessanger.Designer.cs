namespace WindowsApp
{
    partial class FormMessanger
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
            button1 = new Button();
            txtMessage = new TextBox();
            listBoxMessages = new ListBox();
            lblInstanceName = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 493);
            button1.Name = "button1";
            button1.Size = new Size(223, 34);
            button1.TabIndex = 0;
            button1.Text = "Send";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(12, 464);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(223, 23);
            txtMessage.TabIndex = 1;
            // 
            // listBoxMessages
            // 
            listBoxMessages.FormattingEnabled = true;
            listBoxMessages.ItemHeight = 15;
            listBoxMessages.Location = new Point(12, 71);
            listBoxMessages.Name = "listBoxMessages";
            listBoxMessages.Size = new Size(223, 379);
            listBoxMessages.TabIndex = 2;
            // 
            // lblInstanceName
            // 
            lblInstanceName.AutoSize = true;
            lblInstanceName.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point);
            lblInstanceName.Location = new Point(9, 10);
            lblInstanceName.Name = "lblInstanceName";
            lblInstanceName.Size = new Size(104, 20);
            lblInstanceName.TabIndex = 3;
            lblInstanceName.Text = "New Instance";
            // 
            // FormMessanger
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(247, 533);
            Controls.Add(lblInstanceName);
            Controls.Add(listBoxMessages);
            Controls.Add(txtMessage);
            Controls.Add(button1);
            Name = "FormMessanger";
            Text = "Form1";
            FormClosing += FormMessanger_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox txtMessage;
        private ListBox listBoxMessages;
        private Label lblInstanceName;
    }
}