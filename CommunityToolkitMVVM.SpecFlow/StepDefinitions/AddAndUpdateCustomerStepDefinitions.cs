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
        public async Task WhenIClickSave()
        {
            SelectedItemViewModelIsSetup();
            await SaveSelectedItem();
        }

        [Then(@"the Customer is listed")]
        public void ThenTheCustomerIsListed()
        {
            IndexViewModelIsSetup();
            AssertIndexIsNotNull();
            Assert.That(IndexViewModel!.Index!.Contains(ModelJustBeforeSaveAction!));
        }

        [Given(@"an exsiting Customer")]
        public async Task GivenAnExsitingCustomer()
        {
            SelectedItemViewModelIsSetup();
            SelectedItemViewModel!.SelectedItem = TemplateModel;
            await SaveSelectedItem();
            SelectedItemViewModel!.SelectedItem = ModelJustBeforeSaveAction;
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

        [When(@"I click Delete")]
        public async Task WhenIClickDelete()
        {
            SelectedItemViewModelIsSetup();
            await DeleteSelectedItem();
        }

        [Then(@"the Customer is not listed")]
        public void ThenTheCustomerIsNotListed()
        {
            IndexViewModelIsSetup();
            AssertIndexIsNotNull();
            Assert.That(IndexViewModel!.Index!.Contains(ModelJustBeforeSaveAction!), Is.False);
        }

    }
}
