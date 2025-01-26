using System;
using System.Threading.Tasks;

namespace Task_Run
{
    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Tarea iniciada.");

            Task task = Task.Run(() =>
            {
                long sum = 0;
                Console.WriteLine("Iniciando");
                for (int i = 0; i < 10; i++)
                {
                    sum += i * 2;
                }
                Console.WriteLine($"Se ha finalizado con la suma total a: {sum}");
            });

            await task; // Espera a que la tarea termine

            Console.WriteLine("Tarea completada.");
        }
    }
}
