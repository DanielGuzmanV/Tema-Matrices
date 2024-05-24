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
                for(int fil = 1; fil <= this.fila; fil++)
                {
                    mtzRes.matriz[fil, col] = matriz[fil, col] + mtz2.matriz[fil, col];
                }
            }
            mtzRes.fila = this.fila;
            mtzRes.colum = this.colum;
        }

        // Resta de matrices
        public void restaMatrices(classMatriz mtz2, ref classMatriz mtzRes)
        {
            for(int fil = 1; fil <= this.fila; fil++)
            {
                for(int col = 1; col <= this.colum; col++)
                {
                    mtzRes.matriz[fil, col] = matriz[fil, col] - mtz2.matriz[fil, col];
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
            int col = 1, fil;
            bool answer = false;

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

        // Verificar si los elementos de la matriz son iguales
        public bool verifIguales()
        {
            int col, fil, refEle;
            bool answer = true;
            col = 1; refEle = matriz[this.fila, 1];

            while((col <= this.colum) && (answer == true))
            {
                fil = this.fila;
                while((fil >= 1) && (answer == true))
                {
                    if(!(matriz[fil, col] == refEle))
                    {
                        answer = false;
                    }
                    fil--;
                }
                col++;
            }
            return answer;
        }

        // verificar si la matriz esta ordenada
        public bool verifOrden()
        {
            int col, fil, eleAnte; bool answer = true;
            col = 1; eleAnte = matriz[this.fila, 1];

            while((col <= this.colum) && (answer == true))
            {
                fil = this.fila;
                while((fil >= 1) && (answer == true))
                {
                    if(matriz[fil, col] <= eleAnte)
                    {
                        eleAnte = matriz[fil, col];
                    }
                    else
                    {
                        answer = false;
                    }
                    fil--;
                }
                col++;
            }
            return answer;
        }
        // Verificar cuantos numeros primos hay en una matriz
        public int numElemPrimos()
        {
            int numPrim = 0;
            numerosEnteros num1 = new numerosEnteros();
            for(int col = 1; col <= this.colum; col++)
            {
                for(int fil = 1; fil <= this.fila; fil++)
                {
                    num1.cargarDatos(matriz[fil, col]);
                    if (num1.verifPrimo() == true)
                    {
                        numPrim++;
                    }
                }   
            }
            return numPrim;
        }

        // verificar cuantos primos hay en las filas de una matriz
        // Funcion auxiliar para operacion "numParPorFilas()"
        public int auxNumParFilas(int numFil)
        {
            int numPar = 0;
            numerosEnteros number = new numerosEnteros();
            for(int col = 1; col <= this.colum; col++)
            {
                number.cargarDatos(matriz[numFil, col]);
                if(number.verifPrimo() == true)
                {
                    numPar++;
                }
            }
            return numPar;
        }
        // Funcion 
        public void numParPorFilas()
        {
            for(int fil = 1; fil <= this.colum; fil++)
            {
                matriz[fil, this.colum + 1] = this.auxNumParFilas(fil);
            }
            this.colum++;
        }

        // Funcion auxiliar para de intercambio
        public void interCambio(int fil1, int col1, int fil2, int col2)
        {
            int auxi = matriz[fil1, col1];
            matriz[fil1, col1] = matriz[fil2, col2];
            matriz[fil2, col2] = auxi;
        }

        // Ordenamiento por columnas de una matriz por parametros
        public void ordenPorColum(int numCol)
        {
            for(int posici = 1; posici < this.fila; posici++)
            {
                for(int despla = this.fila; despla >= posici + 1; despla--)
                {
                    if(matriz[despla, numCol] > matriz[despla - 1, numCol])
                    {
                        this.interCambio(despla, numCol, despla - 1, numCol);
                    }
                }
            }
        }

        // Ordenamiento por columnas sin parametros usando las anteriores funciones
        public void ordenColums()
        {
            for(int col = 1; col <= this.colum; col++)
            {
                this.ordenPorColum(col);
            }
        }
    }
}
