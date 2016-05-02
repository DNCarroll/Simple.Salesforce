using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simple.Salesforce.Test {
    [TestClass]
    public class TestDialog {
        [TestMethod]
        public void UsernameTest() {
            var success = false;
            var results= Dialog.QuestionDialog.GetAnAnswerTo("Username?");
            if(results.Item1 == System.Windows.Forms.DialogResult.OK) {
                success = !string.IsNullOrEmpty(results.Item2);
            }
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void PasswordTest() {
            var success = false;
            var results = Dialog.QuestionDialog.GetAnAnswerTo("Password?", true);
            if (results.Item1 == System.Windows.Forms.DialogResult.OK) {
                success = !string.IsNullOrEmpty(results.Item2);
            }
            Assert.IsTrue(success);
        }

    }
}
