using CommunityToolkitMVVM.Models;
using CommunityToolkitMVVM.ViewModels;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace CommunityToolkitMVVM.SpecFlow.Support
{
    public abstract class IndexAndSelectedItemStepDefinitionBase
        <TModel, TIndexAndSelectedItemViewModel>
        where TModel : class, IModel, new()
        where TIndexAndSelectedItemViewModel
        : class, IIndexAndSelectedItemViewModel<TModel>
    {
        public IndexAndSelectedItemStepDefinitionBase()
        {
            PopulateExistingModel();
        }

        protected static TModel ExistingModel => new TModel { Id = 999 };

        protected abstract void PopulateExistingModel();

        protected TIndexAndSelectedItemViewModel? IndexAndSelectedItemViewModel
        { get; set; }

        protected IIndexViewModel<TModel>? IndexViewModel =>
            IndexAndSelectedItemViewModel?.IndexViewModel;

        protected ISelectedItemViewModel<TModel>? SelectedItemViewModel =>
            IndexAndSelectedItemViewModel?.SelectedItemViewModel;

        protected void IndexViewModelIsSetup()
        {
            IndexAndSelectedItemViewModelIsSetup();
            if (IndexViewModel == null)
                throw new InvalidOperationException(
                    nameof(IIndexAndSelectedItemViewModel<TModel>.IndexViewModel) +
                    " is null. You likely forgot a setup step.");
        }

        protected void IndexIsSetup()
        {
            IndexViewModelIsSetup();
            if (IndexViewModel!.Index == null) throw new InvalidOperationException(
                $"{nameof(IndexViewModel.Index)} is null. " +
                "You likely forgot a setup step.");
        }

        protected void SelectedItemViewModelIsSetup()
        {
            IndexAndSelectedItemViewModelIsSetup();
            if (SelectedItemViewModel == null) throw new InvalidOperationException(
                $"{nameof(SelectedItemViewModel)} is null. " +
                "You likely forgot a setup step.");
        }

        protected void SelectedItemIsSetup()
        {
            SelectedItemViewModelIsSetup();
            if (SelectedItemViewModel!.SelectedItem == null)
                throw new InvalidOperationException(
                    $"{nameof(ISelectedItemViewModel<TModel>.SelectedItem)} is null." +
                    "You likely forgot a Given step to set it.");
        }

        protected void AssertIndexIsNotNull()
        {
            IndexViewModelIsSetup();
            Assert.That(IndexViewModel!.Index, Is.Not.Null);
        }

        protected void AssertSelectedItemIsNotNull()
        {
            Assert.That(SelectedItemViewModel, Is.Not.Null);
        }

        protected void AssertSelectedItemIsNotNew()
        {
            Assert.That(SelectedItemViewModel!.SelectedItem!.Id, Is.GreaterThan(0));
        }

        private void IndexAndSelectedItemViewModelIsSetup()
        {
            if (IndexAndSelectedItemViewModel == null)
                    throw new InvalidOperationException(
                    $"{nameof(IndexAndSelectedItemViewModel)} is null. " +
                    "You likely forgot a setup step.");
        }

    }
}
