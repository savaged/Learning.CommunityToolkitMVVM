using CommunityToolkitMVVM.Models;
using CommunityToolkitMVVM.ViewModels;
using CommunityToolkitMVVM.ViewModels.Messages;
using CommunityToolkit.Mvvm.Messaging;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using CommunityToolkitMVVM.Services;

namespace CommunityToolkitMVVM.SpecFlow.Support
{
    public abstract class IndexAndSelectedItemStepDefinitionBase
        <TModel, TIndexAndSelectedItemViewModel>
        where TModel : class, IModel, new()
        where TIndexAndSelectedItemViewModel
        : class, IIndexAndSelectedItemViewModel<TModel>
    {
        private readonly IServiceProvider _serviceProvider;
        private bool _isModelSaved;

        public IndexAndSelectedItemStepDefinitionBase()
        {
            _serviceProvider = new TestingBootstrapper().ConfigureServices();
            IndexAndSelectedItemViewModel =
                _serviceProvider.GetService<MainViewModel>() as TIndexAndSelectedItemViewModel;

            var fakeSystemDialogService =
                _serviceProvider.GetService<ISystemDialogService>()
                as FakeSystemDialogService;
            fakeSystemDialogService?.Init((m) => MessageBoxCaption = m);

            _isModelSaved = true;
            PopulateTemplateModel();
            WeakReferenceMessenger.Default.Register<ModelSavedMessage<TModel>>(
                this, (r, m) => OnModelSaved(m));
        }

        protected static TModel TemplateModel => new TModel();

        protected abstract void PopulateTemplateModel();

        protected void SaveSelectedItem()
        {
            PrepForModelSave();
            SelectedItemViewModel!.SaveCmd.Execute(null);
            WaitForModelSaveCompleted();
        }

        protected TIndexAndSelectedItemViewModel? IndexAndSelectedItemViewModel
        { get; set; }

        protected IIndexViewModel<TModel>? IndexViewModel =>
            IndexAndSelectedItemViewModel?.IndexViewModel;

        protected ISelectedItemViewModel<TModel>? SelectedItemViewModel =>
            IndexAndSelectedItemViewModel?.SelectedItemViewModel;

        protected string? MessageBoxCaption { get; set; }

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

        private void PrepForModelSave() => _isModelSaved = false;

        private void WaitForModelSaveCompleted()
        {
            while (!_isModelSaved)
            {
                Thread.Sleep(500);
            }
        }

        private void SetMessageBoxCaption(string msg)
        {
            MessageBoxCaption = msg;
        }

        private void OnModelSaved(ModelSavedMessage<TModel> m)
        {
            _isModelSaved = true;
        }

    }
}
