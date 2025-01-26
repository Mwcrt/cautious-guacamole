using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Task task = await Task.Factory.StartNew(async () =>
        {
            Console.WriteLine("Tarea principal ejecutándose.");
            await Task.Delay(1000);
            Console.WriteLine("Tarea principal terminada.");
        });

        // Tarea0
        await task.ContinueWith(t =>
        {
            Console.WriteLine("Tarea0 de continuación ejecutándose.");
        });

        // Tarea1
        await task.ContinueWith(t =>
        {
            Console.WriteLine("Tarea1 de continuación ejecutándose.");
        });

        // Tarea2
        await task.ContinueWith(t =>
        {
            Console.WriteLine("Tarea2 de continuación ejecutándose.");
        }, TaskContinuationOptions.OnlyOnRanToCompletion);

        // Tarea hermano, se ejecuta en paralelo a las demas.
        var taskBrother = task.ContinueWith(t =>
        {
            Console.WriteLine("Tarea hermano ejecutandose.");
        });

        // Espera a que la tarea principal termine para ejecutar la tarea hermano.
        await taskBrother;
    }
}
