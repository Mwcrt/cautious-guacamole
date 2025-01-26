using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        // Tarea Padre preparar el platillo
        Task parentTask = Task.Factory.StartNew(() =>
        {
            Console.WriteLine("El chef preparará un platillo culinario.");

            // Tarea hija Cortar las verduras
            var task1 = Task.Factory.StartNew(async () =>
            {
                Console.WriteLine("El chef ha empezado a cortar las verduras.");
                await Task.Delay(1000);
                Console.WriteLine("El chef ha terminado de cortar las verduras.");
            }, TaskCreationOptions.AttachedToParent);

            // Tarea hija Cocinar la pasta
            var task2 = Task.Factory.StartNew(async () =>
            {
                Console.WriteLine("El chef ha puesto a cocer la pasta.");
                await Task.Delay(2000);
                Console.WriteLine("El chef ha terminado de cocer la pasta.");
            }, TaskCreationOptions.AttachedToParent);

            // Tarea hija Preparar la salsa
            var task3 = Task.Factory.StartNew(async () =>
            {
                Console.WriteLine("El chef ha empezado a preparar la salsa.");
                await Task.Delay(1500);
                Console.WriteLine("El chef ha terminado la salsa.");
            }, TaskCreationOptions.AttachedToParent);

            // Espera a que las tareas hijas terminen
            Task.WaitAll(task1.Unwrap(), task2.Unwrap(), task3.Unwrap());
        });

        // Espera que la tarea padre y las hijas terminen
        await parentTask;

        Console.WriteLine("El chef ha terminado de preparar el platillo.");
    }
}
