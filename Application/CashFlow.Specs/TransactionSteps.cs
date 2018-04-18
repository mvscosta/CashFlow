using System;
using System.Globalization;
using System.Runtime.Remoting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using CashFlow.Handler;
using CashFlow.Role;

namespace CashFlow.Specs
{
    [Binding]
    public class TransactionSteps
    {
        [Given(@"Resource ""(.*)"" add a transaction")]
        public void GivenResourceAddTransaction(string resourceName, Table table)
        {
            // validate resource
        }

        [When(@"Add by resource ""(.*)"" transaction description ""(.*)"" amount (.*) type ""(.*)""")]
        public void AddByResourceTransactionWithDescriptionAmountAndType(string resourceName, string description, decimal amount, string type)
        {
            // simulate a new transaction 
        }

        [Then(@"Result will be transaction id not empty")]
        public void ThenResultWillBeTransactionIdNotEmpty()
        {
            // asset the result
        }

    }
}
