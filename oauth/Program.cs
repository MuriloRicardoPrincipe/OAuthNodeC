// See https://aka.ms/new-console-template for more information
using oauth.Modelo;

internal class Program
{
    private static void Main(string[] args)
    {

        AuthService auth = new AuthService();


        Console.WriteLine("Vamos no autenticar!");

        seAutenticando();

        void seAutenticando(string login, string password)
        {
            Console.WriteLine("Digite o login:");
            login = Console.ReadLine();

            Console.WriteLine("Digite a senha:");
            password = Console.ReadLine();

            Console.WriteLine("Vamos no autenticar!");
        }

    }
}