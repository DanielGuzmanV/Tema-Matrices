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

        // Multiplicacion de matrices
        public void multiplicarMatriz(classMatriz mtz2, ref classMatriz mtzRespu)
        {
            for(int fil = 1; fil <= this.fila; fil++)
            {
                for(int col = 1; col <= mtz2.colum; col++)
                {
                    mtzRespu.matriz[fil, col] = 0;
                    for(int diCol = 1; diCol <= this.colum; diCol++)
                    {
                        mtzRespu.matriz[fil, col] = mtzRespu.matriz[fil, col] + matriz[fil, diCol] * mtz2.matriz[diCol, col];
                    }
                }
            }
            mtzRespu.fila = this.fila;
            mtzRespu.colum = mtz2.colum;
        }

        // Funcion auxiliar para la multiplicacion de matrices
        public void ReturnDimension(ref int numFila, ref int numCol)
        {
            numFila = this.fila;
            numCol = this.colum;
        }

        // Busqueda de un elemento de una matriz
        public bool busquedaElem(int number)
        {
            int col, fil;
            bool answer = false;
            col = 1;

            while((col <= this.colum) && (answer == false))
            {
                fil = this.fila;
                while((fil >= 1) && (answer == false))
                {
                    if(matriz[fil, col] == number)
                    {
                        answer = true;
                    }
                    fil--;
                }
                col++;
            }
            return answer;
        }

        // Busqueda de una matriz por las posiciones que tiene la matriz
        // osea donde esta la fila y la columna
        public void busquedaElem2(int number, ref int numFila, ref int numColum)
        {
            int col, fil;
            bool answer = false;
            col = 1; numFila = 0; numColum = 0;

            while((col <= this.colum) && (answer == false))
            {
                fil = this.fila;
                while((fil >= 1) && (answer == false))
                {
                    if(matriz[fil, col] == number)
                    {
                        answer = true;
                        numFila = fil;
                        numColum = col;
                    }
                    fil--;
                }
                col++;
            }
        }

        // Verificar una matriz de los aprobados
        public bool verifAprobado()
        {
            int col, fil;
            bool answer = true;
            col = 1;
            while((col <= this.colum) && (answer == true))
            {
                fil = this.fila;
                while((fil >= 1) && (answer == true))
                {
                    if(!(matriz[fil, col] > 50))
                    {
                        answer = false;
                    }
                    fil--;
                }
                col++;
            }
            return answer;
        }
    }
}
