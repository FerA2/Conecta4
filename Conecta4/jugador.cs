using System;
using System.Collections.Generic;
using System.Text;

namespace Conecta4
{
    class Jugador
    {
        public Jugador(string nombre, char letra)
        {
            this.nombre = nombre;
            this.letra = letra;
            ganador = false;
        }
        public string getNombre()
        {
            return nombre;
        }
        public char getLetra()
        {
            return letra;
        }
        public bool getGanador()
        {
            return ganador;
        }
        public void setGanador()
        {
            ganador =true;
        }
        public void Disparo(char letra,bool ganador, Tablero campo)
        {
            this.ganador = ganador;
            Console.WriteLine("Elige una columna");          
            try
            {
                //Columnas de 1 a 7
                int columna = int.Parse(Console.ReadLine())-1;
                if (columna >= 0 && columna < 7)//7
                {
                    for (int i = 5; i >= 0; i--)//5
                    {
                        if (campo.getValorTablero(i, columna) == ' ')
                        {
                            campo.setValorTablero(i, columna, letra);
                            if (Ganador(i, columna, letra, campo))
                            {
                                setGanador();
                            }
                            break;//Si rellena la casilla corta el for.
                        }
                        else if (i==0)
                        {
                            Console.WriteLine("Columna llena");
                            Disparo(letra,ganador, campo);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Columna no valida");
                    Disparo(letra,ganador, campo);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Columna no valida");
                Disparo(letra,ganador, campo);
            }
        }

        public bool Ganador(int fila, int col, char letra, Tablero campo)
        {
            bool ganador = false;

            int contador = 0;
            //Horizontal
            contador = ContadorHorizontal(fila, col, letra, campo);
            if (contador >= 4) ganador = true;
            //Vertical
            contador = ContadorVertical(fila, col, letra, campo);
            if (contador >= 4) ganador = true;
            //DiagonalAsc
            contador = ContadorDiagonalAsc(fila, col, letra, campo);
            if (contador >= 4) ganador = true;
            //DiagonalDesc
            contador = ContadorDiagonalDesc(fila, col, letra, campo);
            if (contador >= 4) ganador = true;


            return ganador;
        }
        public static int ContadorHorizontal(int fila, int col,char letra, Tablero campo)
        {
            int contador = 0;
            for (int i = 0; i < 7; i++)
            {
                if (campo.getValorTablero(fila, i) == letra)
                {
                    contador++;
                    //Console.WriteLine(contador);
                    //Console.ReadKey();
                    if (contador == 4) break;
                }
                else contador = 0;
            }
            return contador;
        }
        public static int ContadorVertical(int fila, int col, char letra, Tablero campo)
        {
            int contador = 0;
            for (int i = 0; i < 6; i++)
            {
                if (campo.getValorTablero(i, col) == letra)
                {
                    contador++;
                    //Console.WriteLine(contador);
                    //Console.ReadKey();
                    if (contador == 4) break;
                }
                else contador = 0;
            }
            return contador;
        }
        public static int ContadorDiagonalAsc(int fila, int col, char letra, Tablero campo)
        {
            int contador = 0;
            //Busco el limite por la izquierda o por abajo
            while(fila<5 && col>0)
            {
                fila++;
                col--;
            }
            //Limite derecha y arriba
            while (fila>0&&col<7)
            {
                if (campo.getValorTablero(fila, col) == letra)
                {
                    contador++;
                    //Console.WriteLine(contador);
                    //Console.ReadKey();
                    if (contador == 4) break;
                }
                else contador = 0;
                fila--;
                col++;
            }          
            return contador;
        }
        public static int ContadorDiagonalDesc(int fila, int col, char letra, Tablero campo)
        {
            int contador = 0;
            //Busco el limite por la izquierda o por abajo
            while (fila > 0 && col > 0)
            {
                fila--;
                col--;
            }
            //Limite derecha y arriba
            while (fila < 6 && col < 7)
            {
                if (campo.getValorTablero(fila, col) == letra)
                {
                    contador++;
                    //Console.WriteLine(contador);
                    //Console.ReadKey();
                    if (contador == 4) break;
                }
                else contador = 0;
                fila++;
                col++;
            }
            return contador;
        }
        private string nombre;
        private char letra;
        private bool ganador;
    }
}

