using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple.Salesforce.Test.Dialog {
    public partial class QuestionDialog : Form {

        public QuestionDialog(string question) {
            InitializeComponent();
            this.Text = "";
            this.Question.Text = question;
        }

        public static Tuple<DialogResult, string> GetAnAnswerTo(string question, bool sensitive = false) {
            var dl = new QuestionDialog(question);
            if(sensitive) {
                dl.QuestionResults.Multiline = false;
                dl.QuestionResults.PasswordChar = '*';
            }            
            var result = dl.ShowDialog();
            return new Tuple<DialogResult, string>(dl.DialogResult, dl.QuestionResults.Text);
        }
    }
}
