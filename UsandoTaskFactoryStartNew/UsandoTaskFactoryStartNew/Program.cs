using System;
using System.Threading.Tasks;

internal class Program
{
    static async Task Main()
    {
        Task task = Task.Factory.StartNew(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Tarea ejecutándose: {i}");
                Task.Delay(500).Wait(); 
            }
        }, TaskCreationOptions.LongRunning);

        // Necesitamos esperar a que la tarea termine para mostrar el mensaje de que la tarea fue completada
        await task;

        Console.WriteLine("Tarea completada.");
    }
}