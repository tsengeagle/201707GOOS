using System;
using FluentAutomation;
using GOOS_SampleTests.PageObjects;
using TechTalk.SpecFlow;

namespace GOOS_SampleTests
{
    [Binding]
    [Scope(Feature = "SetAccount")]
    public class SetAccountSteps:FluentTest
    {
        private AccountSetPage page;

        public SetAccountSteps()
        {
            page=new AccountSetPage(this);
        }

        [Given(@"go to adding account page")]
        public void GivenGoToAddingAccountPage()
        {
            page.Go();
            }

        [When(@"I add a account with account id = ""(.*)"" and account name = ""(.*)""")]
        public void WhenIAddAAccountWithAccountIdAndAccountName(string accountId, string accountName)
        {
            page.AccountId(accountId).AccountName(accountName).AddAccount();
        }

        [Then(@"it should display ""(.*)""")]
        public void ThenItShouldDisplay(string message)
        {
            page.ShouldDisplay(message);
        }
    }

    internal class AccountSetPage : PageObject<AccountSetPage>
    {
        public AccountSetPage(FluentTest test) : base(test)
        {
            this.Url = $"{PageContext.Domain}/Account/Set";
        }

        public AccountSetPage AccountId(string accountId)
        {
            I.Enter(accountId).In("#accountId");
            return this;
        }

        public AccountSetPage AccountName(string accountName)
        {
            I.Enter(accountName).In("#accountName");
            return this;
        }

        public void AddAccount()
        {
            I.Click($"input[type=\"submit\"");
            return;
        }

        public void ShouldDisplay(string message)
        {
            I.Assert.Text(message).In("#message");
        }
    }
}
