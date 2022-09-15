namespace CommunityToolkitMVVM.Models
{
    internal class Customer : ModelBase
    {
        private string _firstName = string.Empty;
        private string _surname = string.Empty;

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        public string Surname
        {
            get => _surname;
            set => SetProperty(ref _surname, value);
        }

    }
}
