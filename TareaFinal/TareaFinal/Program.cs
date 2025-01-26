using System;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Iniciando la carrera...");

        // Crear los autos para la carrera
        var raceCars = new[]
        {
            new RaceCar("Ferrari 488 pista"),
            new RaceCar("lamborghini svj performance"),
            new RaceCar("Bmw m5 cs"),
            new RaceCar("Mclaren 720s")
            
        };

        // Crear las tareas de la carrera para cada auto, cada tarea ejecuta la carrera de un auto en paralelo
        var raceTasks = raceCars.Select(car => Task.Run(() => car.Race())).ToArray();

        // Esperar a que termine la primera tarea (el primer auto en llegar a la meta)
        var winnerTask = Task.WhenAny(raceTasks);

        // Esperar a que la carrera termine completamente y obtener el ganador
        var winner = await winnerTask;
        Console.WriteLine("");
        Console.WriteLine($"La carrera ha terminado. ¡El ganador es {winner.Result.Name}!");
        Console.WriteLine("");


        // Esperar a que todas las tareas de carrera finalicen
        await Task.WhenAll(raceTasks);

        Console.WriteLine("¡Todos los autos han llegado a la meta!");
        Console.WriteLine("Carrera Finalizada");

    }
}

public class RaceCar
{
    public string Name { get; }
    private static Random random = new Random();

    public RaceCar(string name)
    {
        Name = name;
    }

    public async Task<RaceCar> Race()
    {
        int distanciaTotal = 10; // Distancia total de la carrera
        int distanciarecorrida = 0;

        Console.WriteLine($"{Name} ha comenzado la carrera.");

        // Simular el avance del auto en intervalos
        while (distanciarecorrida < distanciaTotal)
        {
            await Task.Delay(random.Next(500, 1000)); // Simula el tiempo que tarda en avanzar
            int distancePerMove = random.Next(1, 5);  // La cantidad de distancia que cubre en cada intervalo
            distanciarecorrida += distancePerMove;

            // Asegurarse de que no se sobrepasen los 100 metros
            if (distanciarecorrida > distanciaTotal)
                distanciarecorrida = distanciaTotal;

            Console.WriteLine($"{Name} ha recorrido {distanciarecorrida}/{distanciaTotal} metros.");

        }

        Console.WriteLine($"{Name} ha llegado a la meta.");
        return this; // Devuelve el auto que ha llegado a la meta
    }
}
