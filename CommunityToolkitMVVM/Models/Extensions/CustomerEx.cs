namespace CommunityToolkitMVVM.Models.Extensions
{
    internal static class CustomerEx
    {
        public static bool IsValid(this Customer? self)
        {
            return !string.IsNullOrEmpty(self?.FirstName) && !string.IsNullOrEmpty(self?.Surname);
        }

        public static bool IsNullOrNew(this Customer? self)
        {
            return self?.Id == 0;
        }

    }

}
