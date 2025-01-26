using System;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Iniciando la carrera...");

        // Creacion los vehiculos para la carrera
        var raceCars = new[]
        {
            new RaceCar("Ferrari 488 pista"),
            new RaceCar("lamborghini svj performance"),
            new RaceCar("Bmw m5 cs"),
            new RaceCar("Mclaren 720s")
            
        };

        // Creacion de las tareas para cada vehiculo que se ejecutara en paralelo
        var raceTasks = raceCars.Select(car => Task.Run(() => car.Race())).ToArray();

        // Aqui esperamos a que la primera tarea termine que es cuando el primer vehiculo recorre la distancia establecida primero
        var winnerTask = Task.WhenAny(raceTasks);

        // Aqui esperamos que se termine la carrera para imprimir el vechiculo ganador
        var winner = await winnerTask;
        Console.WriteLine("");
        Console.WriteLine($"La carrera ha terminado. ¡El ganador es {winner.Result.Name}!");
        Console.WriteLine("");


        // Esperamos a que los demas vehiculos recorran la distancia establecida
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
        int distanciaTotal = 10; //variable que indica la distancia ha recorrer de los vehiculos
        int distanciarecorrida = 0;

        Console.WriteLine($"{Name} ha comenzado la carrera.");

        // Aqui simula el avance de los vehiculos
        while (distanciarecorrida < distanciaTotal)
        {
            await Task.Delay(random.Next(500, 1000)); // Simula el tiempo que tarda en avanzar
            int distanciaMovimiento = random.Next(1, 5);  // distancia que avanza cada vehiculo
            distanciarecorrida += distanciaMovimiento;

            // Aseguramos de que no se pasen los metros o distancia establecida
            if (distanciarecorrida > distanciaTotal)
                distanciarecorrida = distanciaTotal;

            Console.WriteLine($"{Name} ha recorrido {distanciarecorrida}/{distanciaTotal} metros.");

        }

        Console.WriteLine($"{Name} ha llegado a la meta.");
        return this; // Devuelve el auto que ha llegado a la meta
    }
}
