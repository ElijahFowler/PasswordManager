namespace PasswordManager;

public class Program
{
	private static void Main(string[] args)
	{
		var passwordManager = new PasswordManager();

		passwordManager.Listen();
	}
}