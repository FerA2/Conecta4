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
            Jugador[] players = new Jugador[2];
            for (int i = 0; i < 2; i++)
            { 
                players[i] = new Jugador();
                Console.WriteLine($"Elige el nombre del jugador {i+1}");
                players[i].Nombre = Console.ReadLine();
            }
            // Cambiamos las letras de cada player.
            players[0].Letra = 'O';
            players[1].Letra = 'X';
            Tablero campo = new Tablero();
            campo.Rellena();
            // Iniciamos los turnos de juego.
            int casillasCompletas = 0;
            while (!Fin(players[0],casillasCompletas)&& !Fin(players[1], casillasCompletas))
            {
                for (int i = 0; i < 2; i++)
                {
                    Turno(players[i], campo, ref casillasCompletas);
                    if (players[i].Ganador == true) break;
                }
            }
            campo.ImprimeTablero();
        }
        public static void Turno(Jugador player, Tablero campo,ref int casillasCompletas)
        {
            campo.ImprimeTablero();
            Console.WriteLine($"Turno de {player.Nombre}");
            player.Disparo(player, campo);
            Console.Clear();
            casillasCompletas++;
        }
        public static bool Fin(Jugador player, int contador)
        {
            if (player.Ganador)
            {
                Console.WriteLine($" Ha ganado {player.Nombre}");
                return true;
            }
            else if (contador == 42)
            {
                Console.WriteLine("Empate");
                return true;
            }
            else return false;
        }
    }

}
     
        
        
    

    

   

