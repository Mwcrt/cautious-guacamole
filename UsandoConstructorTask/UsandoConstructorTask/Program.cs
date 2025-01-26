using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.WriteLine("Iniciando tareas...");

        // Tarea que realiza la suma
        Task<int> task1 = new Task<int>(() =>
        {
            int sum = 0;
            for (int i = 1; i <= 10; i++)
            {
                sum += i;
            }
            Console.WriteLine("Tarea 1 completada (Suma de números).");
            return sum;
        });

        // Tarea que realiza la resta
        Task<int> task2 = new Task<int>(() =>
        {
            int difference = 100;
            for (int i = 1; i <= 10; i++)
            {
                difference -= i;
            }
            Console.WriteLine("Tarea 2 completada (Resta de números).");
            return difference;
        });

        // Tarea que realiza la multiplicacion 
        Task<int> task3 = new Task<int>(() =>
        {
            int product = 1;
            for (int i = 1; i <= 5; i++)
            {
                product *= i;
            }
            Console.WriteLine("Tarea 3 completada (Multiplicacion de numeros).");
            return product;
        });

        // Tarea que realiza la division 
        Task<int> task4 = new Task<int>(() =>
        {
            int division = 1000;
            for (int i = 2; i <= 5; i++)
            {
                division /= i;
            }
            Console.WriteLine("Tarea 4 completada (División de números).");
            return division;
        });

        task1.Start();
        task2.Start();
        task3.Start();
        task4.Start();

        Task.WaitAll(task1, task2, task3, task4);

        //resultados de las tareas
        int result1 = task1.Result;
        int result2 = task2.Result;
        int result3 = task3.Result;
        int result4 = task4.Result;

        // Suma de los resultados de las tareas
        int finalResult = result1 + result2 + result3 + result4;
        Console.WriteLine($"\nResultado final combinado: {finalResult}");

        Console.WriteLine("Todas las tareas completadas.");
    }
}
