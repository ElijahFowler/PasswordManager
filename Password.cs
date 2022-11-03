namespace PasswordManager;

public class Password
{
	public string Name { get; set; } = null!;
	public string Value { get; set; } = null!;

	public override string ToString()
	{
		return $"Record Name: {Name}, Password: {Value}";
	}
}
