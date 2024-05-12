using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace temaMatrices
{
    class classMatriz
    {
        // Atributor *******************************
        const int maxFila = 50;
        const int maxColum = 50;
        private int[,] matriz;
        private int fila, colum;

        // constructor ****************************
        public classMatriz()
        {
            matriz = new int[maxFila, maxColum];
            fila = 0; colum = 0;
        }
 
        // los metodos de la clase Matriz *****************************
        // Cargar randomicamente la matriz
        public void setDateRandom(int numFila, int numColum, int min, int max)
        {
            Random rand = new Random();
            this.fila = numFila; this.colum = numColum;
            for(int fil = 1; fil <= this.fila; fil++)
            {
                for(int col = 1; col <= this.colum; col++)
                {
                    matriz[fil, col] = rand.Next(min, max + 1);
                }
            }
        }
        // Descargar la matriz 
        public string getDate()
        {
            string space = "";
            for(int fil = 1; fil <= this.fila; fil++)
            {
                for(int col = 1; col <= this.colum; col++)
                {
                    space = space + matriz[fil, col] + "\t";
                }
                space = space + "\x000d" + "\x000a";
            }
            return space;
        }

        // Cargar una serie de matrices
        public void cargarSerie(int numFila, int numColum, int number, int razon)
        {
            this.fila = numFila; this.colum = numColum;
            int idx = 0;
            for(int fil = 1; fil <= this.fila; fil++)
            {
                for(int col = 1; col <= this.colum; col++)
                {
                    idx++;
                    matriz[fil, col] = number + (idx - 1) * razon;
                }
            }
        }

        // Realizar el promedio de una matriz
        public double proMedio()
        {
            double suma = 0;
            for(int fil = 1; fil <= this.fila; fil++)
            {
                for(int col = 1; col <= this.colum; col++)
                {
                    suma = suma + matriz[fil, col];
                }
            }
            return suma / (this.fila * this.colum);
        }

        // Verificar el numero maximo
        public int numberMaximo()
        {
            int maximo = 0;
            for(int fil = 1; fil <= this.fila; fil++)
            {
                for(int col = 1; col <= this.colum; col++)
                {
                    if(matriz[fil,col] > maximo)
                    {
                        maximo = matriz[fil, col];
                    }
                }
            }
            return maximo;
        }

        // Encontra el numero Frecuente de la matriz
        public int numFrecuente(int number)
        {
            int frecu = 0;
            for(int fil = 1; fil <= this.fila; fil++)
            {
                for(int col = 1; col <= this.colum; col++)
                {
                    if(matriz[fil,col] == number)
                    {
                        frecu++;
                    }
                }
            }
            return frecu++;
        }

        // Cargar la matriz de abajo hacia arriba
        public void cargarAbjArr(int numFila, int numColum, int number, int ter)
        {
            int idx = 0;
            this.fila = numFila; this.colum = numColum;
            
            for (int col = 1; col <= this.colum; col++)
            {
                for (int fil = this.fila; fil >= 1; fil--)
                {
                    idx++;
                    matriz[fil, col] = number + (idx - 1) * ter;
                }
            }
        }

        // Suma de dos matrices
        public void sumaMatriz(classMatriz mtz2, ref classMatriz mtzRes)
        {
            for(int col = 1; col <= this.colum; col++)
            {
                for(int fil = this.fila; fil >= 1; fil--)
                {
                    mtzRes.matriz[fil, col] = matriz[fil, col] + mtz2.matriz[fil, col];
                }
            }
            mtzRes.fila = this.fila;
            mtzRes.colum = this.colum;
        }
    }
}
