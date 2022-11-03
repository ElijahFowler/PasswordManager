using System.Text.RegularExpressions;

namespace PasswordManager;

public class PasswordManager
{
	private readonly Regex regex = new(@"\s-\w", RegexOptions.Compiled | RegexOptions.IgnoreCase);
	private readonly List<Password> passwords = new();


	public PasswordManager()
	{
		// Do EF stuff
	}


	public void Listen()
	{
		Console.Write("Enter Record Name: ");

		var input = Console.ReadLine()?.Trim();

		if (string.IsNullOrWhiteSpace(input))
		{
			Console.WriteLine("Must input a valid record name.");
			Listen();

			return;
		}

		if (input.ToLower() == "list")
		{
			List();
			Listen();

			return;
		}

		if (input.ToLower() == "exit")
		{
			return;
		}

		string name = input.Replace(" ", "_");
		
		var matches = regex.Matches(input);

		name = name[..(name.IndexOf("_-") == -1 ? name.Length : name.IndexOf("_-"))];

		var record = Get(name);

		if (record == null)
		{
			Console.WriteLine("Record does not exist, would you like to create it instead? Y or n:");

			var doCreate = Console.ReadLine();

			if (doCreate?.ToLower() == "y")
			{
				var newRecord = Create(name);

				Console.WriteLine($"New record created: {newRecord}");
				Listen();
			}
			else
			{
				Listen();
			}
		}
	}


	private Password? Get(string name) => passwords.SingleOrDefault(x => x.Name.ToLower() == name.ToLower());


	private Password? Create(string name, List<string> flags = null!)
	{
		var password = new Password
		{
			Name = name.Trim(),
		};

		passwords.Add(password);

		return password;
	}


	private void List()
	{
		foreach (var record in passwords)
		{
			Console.WriteLine(record);
		}
	}
}
