namespace Transaction.API.Services
{
    public class AccountNumberValidationService : IAccountNumberValidationService
    {
        private const int startingPartLength = 3;
        private const int middlePartLength = 10;
        private const int lastPartLength = 2;

        public bool IsValid(string accountNumber)
        {
            if (accountNumber.Count(c => c == '-') != 2)
                throw new ArgumentException("Invalid delimiters. Expected exactly 2 hyphens.");

            var parts = accountNumber.Split('-');

            if (parts.Length != 3)
                throw new ArgumentException("Invalid account number format.");

            var firstPart = parts[0];
            var middlePart = parts[1];
            var lastPart = parts[2];

            if (firstPart.Length != startingPartLength || !firstPart.All(char.IsDigit))
                return false;

            if (middlePart.Length != middlePartLength || !middlePart.All(char.IsDigit))
                return false;

            if (lastPart.Length != lastPartLength || !lastPart.All(char.IsDigit))
                return false;

            return true;
        }
    }
}
