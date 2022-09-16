using CommunityToolkitMVVM.Models;
using CommunityToolkitMVVM.ViewModels;
using CommunityToolkitMVVM.ViewModels.Messages;
using CommunityToolkitMVVM.SpecFlow.Support;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using System;
using TechTalk.SpecFlow;

namespace CommunityToolkitMVVM.SpecFlow.StepDefinitions
{
    [Binding]
    public class AddAndUpdateCustomerStepDefinitions
        : IndexAndSelectedItemStepDefinitionBase<Customer, MainViewModel>
    {
        public AddAndUpdateCustomerStepDefinitions() : base()
        {
            IServiceProvider? serviceProvider = Bootstrapper.ConfigureServices();
            IndexAndSelectedItemViewModel = serviceProvider?.GetService<MainViewModel>();
        }

        protected override void PopulateTemplateModel()
        {
            TemplateModel.FirstName = "Vic";
            TemplateModel.Surname = "Reeves";
        }

        [Given(@"a new Customer")]
        public void GivenANewCustomer()
        {
            SelectedItemViewModelIsSetup();
            SelectedItemViewModel!.SelectedItem = new Customer();
        }

        [Given(@"the Customer Firstname is '(.*)'")]
        public void GivenTheCustomerFirstnameIs(string firstname)
        {
            SelectedItemIsSetup();
            SelectedItemViewModel!.SelectedItem!.FirstName = firstname;
        }

        [Given(@"the Customer Surname is '(.*)'")]
        public void GivenTheCustomerSurnameIs(string surname)
        {
            SelectedItemIsSetup();
            SelectedItemViewModel!.SelectedItem!.Surname = surname;
        }

        [When(@"I click Save")]
        public void WhenIClickSave()
        {
            SelectedItemViewModelIsSetup();
            SaveSelectedItem();
        }

        [Then(@"the Customer is saved")]
        public void ThenTheCustomerIsSaved()
        {
            SelectedItemViewModelIsSetup();
            AssertSelectedItemIsNotNull();
            AssertSelectedItemIsNotNew();
        }

        [Then(@"the Customer is listed")]
        public void ThenTheCustomerIsListed()
        {
            IndexViewModelIsSetup();
            AssertIndexIsNotNull();
            AssertSelectedItemIsNotNull();
            Assert.That(IndexViewModel!.Index!.Contains(SelectedItemViewModel!.SelectedItem!));
        }

        [Given(@"an exsiting Customer")]
        public void GivenAnExsitingCustomer()
        {
            SelectedItemViewModelIsSetup();
            SelectedItemViewModel!.SelectedItem = TemplateModel;
            SaveSelectedItem();
        }

        [Given(@"the Customer is listed")]
        public void GivenTheCustomerIsListed()
        {
            IndexViewModelIsSetup();
            IndexIsSetup();
            IndexViewModel!.Index!.Add(TemplateModel);
        }

        [When(@"I change the Customer Firstname to '(.*)'")]
        public void WhenIChangeTheCustomerFirstnameTo(string firstname)
        {
            SelectedItemIsSetup();
            SelectedItemViewModel!.SelectedItem!.FirstName = firstname;
        }

        [When(@"I change the Customer Surname to '(.*)'")]
        public void WhenIChangeTheCustomerSurnameTo(string surname)
        {
            SelectedItemIsSetup();
            SelectedItemViewModel!.SelectedItem!.Surname = surname;
        }

    }
}
