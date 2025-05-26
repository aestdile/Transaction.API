using Transaction.API.Services;

namespace Transaction.API.Unit.Tests;

public class AccountNummberValidationTest
{
    private readonly AccountNumberValidationService validationSvc;
    public AccountNummberValidationTest() => validationSvc = new AccountNumberValidationService();

    [Fact]
    public void IsValidAccountNumberReturnsTrue()
    {
        Assert.True(validationSvc.IsValid("123-1234567890-98"));
    }

    [Theory]
    [InlineData("13-1234567890-98")]
    [InlineData("1234-1234567890-98")]
    [InlineData("1-1234567890-98")]
    public void IsValidFirstPartIsWrongReturnsFalse(string accountNumber)
    {
        Assert.False(validationSvc.IsValid(accountNumber));
    }

    [Theory]
    [InlineData("123-12345678lldmqk90-98")]
    [InlineData("123-123490-98")]
    public void IsValidMiddlePartIsWrongReturnsFalse(string accountNumber)
    {
        Assert.False(validationSvc.IsValid(accountNumber));
    }

    [Theory]
    [InlineData("123-1234567890-9qkdnkqjdw8")]
    [InlineData("123-1234567890-8")]
    [InlineData("123-1234567890-98lqwmdl")]
    public void IsValidLastPartIsWrongReturnsFalse(string accountNumber)
    {
        Assert.False(validationSvc.IsValid(accountNumber));
    }

    [Theory]
    [InlineData("123-1234567890 98")]
    [InlineData("124+1234567890-98")]
    [InlineData("123-1234567890_98")]
    [InlineData("123 1234567890-98")]
    public void IsValidInValidDelimetersThrowsArgementException(string accountNumber)
    {
        Assert.Throws<ArgumentException>(() => validationSvc.IsValid(accountNumber));
    }
}