using System;

namespace Conecta4
{
    class Program
    {
        static void Main(string[] args)
        {
            IniciaJuego();
        }

        public static void IniciaJuego()
        {
            // Creamos objetos iniciales: jugadores y tablero
            Console.WriteLine("Elige el nombre del jugador 1");
            string nombre1 = Console.ReadLine();
            Console.WriteLine("Elige el nombre del jugador 2");
            string nombre2 = Console.ReadLine();
            Jugador player1 = new Jugador(nombre1, 'O');
            Jugador player2 = new Jugador(nombre2, 'X');
            Tablero campo = new Tablero();
            campo.Rellena();
            // Iniciamos los turnos de juego.
            int casillasCompletas = 0;
            while (true)
            {
                Turno(player1, campo);
                if (player1.getGanador())
                {
                    campo.ImprimeTablero();
                    Console.WriteLine($"Ha ganado {player1.getNombre()}");
                    break;
                }
                casillasCompletas++;
                Turno(player2, campo);
                if (player2.getGanador())
                {
                    campo.ImprimeTablero();
                    Console.WriteLine($"Ha ganado {player2.getNombre()}");
                    break;
                }
                // Si se acaban las casillas empata y cierra.
                casillasCompletas++;
                if (casillasCompletas == 42)
                {
                    Console.WriteLine("Empate");
                    break;
                }
                Console.WriteLine(casillasCompletas);
            }
        }
        public static void Turno(Jugador player, Tablero campo)
        {
            campo.ImprimeTablero();
            Console.WriteLine($"Turno de {player.getNombre()}");
            player.Disparo(player.getLetra(),player.getGanador(), campo);
            Console.Clear();
        }
    }
}
      
     

        
        
    

    

   

