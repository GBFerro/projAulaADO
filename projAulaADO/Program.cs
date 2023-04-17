using projAulaADO.Controllers;
using projAulaADO.Model;
using projAulaADO.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Proj MVC - ADO.NET");

        Console.WriteLine("Teste Inclusão de dados");



        Airplane airplane = new()
        {
            Description = "Para testes",
            Name = "TOP TURBO",
            NumberOfPassengers = 20,
            Engine = new Engine()
            {
                Description = "Motor Turbo 3000"
            }
        };

        if (new AirplaneController().Insert(airplane))
            Console.WriteLine("Sucesso!! Registro inserido!");
        else
            Console.WriteLine("Erro ao inserir registro");

        new AirplaneController().FindAll().ForEach(Console.WriteLine);
    }
}