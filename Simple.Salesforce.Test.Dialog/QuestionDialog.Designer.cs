namespace Simple.Salesforce.Test.Dialog {
    partial class QuestionDialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.Question = new System.Windows.Forms.Label();
            this.QuestionResults = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Question
            // 
            this.Question.AutoSize = true;
            this.Question.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Question.Location = new System.Drawing.Point(42, 9);
            this.Question.Name = "Question";
            this.Question.Size = new System.Drawing.Size(46, 17);
            this.Question.TabIndex = 0;
            this.Question.Text = "label1";
            // 
            // QuestionResults
            // 
            this.QuestionResults.Location = new System.Drawing.Point(45, 65);
            this.QuestionResults.Multiline = true;
            this.QuestionResults.Name = "QuestionResults";
            this.QuestionResults.Size = new System.Drawing.Size(394, 123);
            this.QuestionResults.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(364, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(45, 211);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 32);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // QuestionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 255);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.QuestionResults);
            this.Controls.Add(this.Question);
            this.MaximizeBox = false;
            this.Name = "QuestionDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Question;
        public System.Windows.Forms.TextBox QuestionResults;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

