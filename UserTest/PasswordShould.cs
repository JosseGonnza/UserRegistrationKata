using FluentAssertions;
using UserRegistration.Controllers;
using UserRegistration.ValueObjects;

namespace UserTest;

public class PasswordShould
{
    [Fact(DisplayName = "contains at least 8 characters")]
    public void contains_at_least_8_characters()
    {
        var password = "_";

        var result = () => Password.Create(password);

        result.Should().Throw<ArgumentException>().WithMessage("Password must contains at least 8 characters.");
    }
    
    [Fact(DisplayName = "contains one underscore")]
    public void contains_one_underscore()
    {
        var password = "12345678";

        var result = () => Password.Create(password);

        result.Should().Throw<ArgumentException>().WithMessage("Password must contains one underscore.");
    }

    [Fact(DisplayName = "be valid")]
    public void be_valid()
    {
        var password = "1234567_";

        var result = Password.Create(password);

        result.Value.Should().Be(password);
    }
}