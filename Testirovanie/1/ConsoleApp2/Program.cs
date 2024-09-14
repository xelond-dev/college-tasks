namespace ConsoleApp2;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(CheckPassword("safaas2asFSdfd2!s"));
    }

    public static int CheckPassword(string password) {
        int score = 0;

        if (password.Any(char.IsDigit)) score++;
        if (password.Any(char.IsLower)) score++;
        if (password.Any(char.IsUpper)) score++;
        if (password.Any(ch => !char.IsLetterOrDigit(ch))) score++;
        if (password.Length > 7) score++;

        return score;
    }
}