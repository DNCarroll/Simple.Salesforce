using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simple.Salesforce.Test {
    /// <summary>
    /// Summary description for TestSalesForce
    /// </summary>
    [TestClass]
    public class TestSalesForce {
      

        [TestMethod]
        public void GetAnAccount() {
            var success = false;            
            var clientIdResults = Dialog.QuestionDialog.GetAnAnswerTo("Salesforce ClientId?");
            if (clientIdResults.Item1 == System.Windows.Forms.DialogResult.OK &&
                !string.IsNullOrEmpty(clientIdResults.Item2)) {
                var userNameResults = Dialog.QuestionDialog.GetAnAnswerTo("Salesforce Login?");
                if (userNameResults.Item1 == System.Windows.Forms.DialogResult.OK &&
                    !string.IsNullOrEmpty(userNameResults.Item2)) {
                    var passwordResults = Dialog.QuestionDialog.GetAnAnswerTo("Salesforce Password?", true);
                    if (passwordResults.Item1 == System.Windows.Forms.DialogResult.OK &&
                        !string.IsNullOrEmpty(passwordResults.Item2)) {
                        var clientSecret = Dialog.QuestionDialog.GetAnAnswerTo("Client Secret?");
                        if (clientIdResults.Item1 == System.Windows.Forms.DialogResult.OK) {
                            var idToLookFor = Dialog.QuestionDialog.GetAnAnswerTo("AccountId to lookup");
                            if (idToLookFor.Item1 == System.Windows.Forms.DialogResult.OK &&
                                !string.IsNullOrEmpty(idToLookFor.Item2)) {
                                Configuration.SalesforceClientId = clientIdResults.Item2;
                                Configuration.SalesforcePassword = passwordResults.Item2;
                                Configuration.SalesforceUsername = userNameResults.Item2;
                                Configuration.SalesforceSecret = clientSecret.Item2;
                                var taskForAccount = $"SELECT Id, Name FROM Account WHERE Id = '{idToLookFor.Item2}'".FirstOrDefault<Account>();
                                taskForAccount.Wait();
                                var firstAccount = taskForAccount.Result;
                                success = firstAccount != null && !string.IsNullOrEmpty(firstAccount.Name);
                            }
                        }
                    }
                }
            }
            Assert.IsTrue(success);
        }
    }
}
