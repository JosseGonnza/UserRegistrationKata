namespace UserRegistration.ValueObjects;

public class Password
{
    public string Value { get; }

    private Password(string value)
    {
        Value = value;
    }

    public static Password Create(string value)
    {
        if (value.Length < 8)
        {
            throw new ArgumentException("Password must contains at least 8 characters.");
        }

        if (!value.Contains('_'))
        {
            throw new ArgumentException("Password must contains one underscore.");
        }
        return new Password(value);
    }
}