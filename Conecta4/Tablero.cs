using System;
using System.Collections.Generic;
using System.Text;

namespace Conecta4
{
    class Tablero
    {
        public void ImprimeTablero()
        {
            Console.SetCursorPosition(0, 4);
            for (int fila = 0; fila < tablero.GetLength(0); fila++)
            {
                Console.Write("\t");

                for (int columna = 0; columna < tablero.GetLength(1); columna++)
                {
                    Console.Write($"|{tablero[fila, columna]}|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\t|1||2||3||4||5||6||7|");
            Console.WriteLine();
        }
        public void Rellena()
        {
            for (int fila = 0; fila < tablero.GetLength(0); fila++)
            {
                for (int columna = 0; columna < tablero.GetLength(1); columna++)
                {
                    tablero[fila, columna] = ' ';
                }               
            }
        }
        public char getValorTablero(int fil, int col)
        {
            return tablero[fil,col];
        }
        public void setValorTablero(int fil, int col, char letra)
        {
            tablero[fil, col]=letra;
        }

        private char[,] tablero = new char[6, 7];
    }
}
