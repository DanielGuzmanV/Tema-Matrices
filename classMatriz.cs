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

        // Ordenamiento de una matriz 
        public void ordenEsquema1()
        {
            int filpos, colPos, filDesp, colDesp, idx;

            for (colPos = 1; colPos <= this.colum; colPos++)
            {
                for (filpos = 1; filpos <= this.fila; filpos++)
                {
                    for (colDesp = colPos; colDesp <= this.colum; colDesp++)
                    {
                        if (colDesp == colPos)
                        {
                            idx = filpos;
                        }
                        else
                        {
                            idx = 1;
                        }
                        for (filDesp = idx; filDesp <= this.fila; filDesp++)
                        {
                            if (matriz[filpos, colPos] > matriz[filDesp, colDesp])
                            {
                                this.interCambio(filDesp, colDesp, filpos, colPos);
                            }
                        }
                    }
                }
            }
        }

        // segmentar en pares e impares la matriz
        public void segmentParImpar()
        {
            numerosEnteros numberPos = new numerosEnteros();
            numerosEnteros numberDesp = new numerosEnteros();

            int filpos, colpos, fildesp, coldesp, idx;
            for(colpos = 1; colpos <= this.colum; colpos++)
            {
                for(filpos = 1; filpos <= this.fila; filpos++)
                {
                    for(coldesp = colpos; coldesp <= this.colum; coldesp++)
                    {
                        if(coldesp == colpos)
                        {
                            idx = filpos;
                        }
                        else
                        {
                            idx = 1;
                        }
                        for(fildesp = idx; fildesp <= this.fila; fildesp++)
                        {
                            numberPos.cargarDatos(matriz[filpos, colpos]);
                            numberDesp.cargarDatos(matriz[fildesp, coldesp]);
                            if(numberDesp.verifcarPar() && !numberPos.verifcarPar())
                            {
                                this.interCambio(fildesp, coldesp, filpos, colpos);
                            }
                        }
                    }
                }
            }
        }

        // Segmentar par e impar ordenados
        public void segmentarParImparOrden()
        {
            numerosEnteros numberPos = new numerosEnteros();
            numerosEnteros numberDesp = new numerosEnteros();

            int filPos, colPos, filDesp, colDesp, idx;
            for(colPos = 1; colPos <= this.colum; colPos++)
            {
                for(filPos = 1; filPos <= this.fila; filPos++)
                {
                    for(colDesp = colPos; colDesp <= this.colum; colDesp++)
                    {
                        if(colDesp == colPos)
                        {
                            idx = filPos;
                        }
                        else
                        {
                            idx = 1;
                        }
                        for(filDesp = idx; filDesp <= this.fila; filDesp++)
                        {
                            numberPos.cargarDatos(matriz[filPos, colPos]);
                            numberDesp.cargarDatos(matriz[filDesp, colDesp]);
                            if(numberDesp.verifcarPar() && !numberPos.verifcarPar() ||
                               numberDesp.verifcarPar() && numberPos.verifcarPar() && (matriz[filDesp, colDesp] < matriz[filPos, colPos]) ||
                               !numberDesp.verifcarPar() && !numberPos.verifcarPar() && (matriz[filDesp, colDesp] < matriz[filPos, colPos]))
                            {
                                this.interCambio(filDesp, colDesp, filPos, colPos);
                            }
                        }
                    }
                }
            }
        }

        // Intercalar para e impar ordenado
        public void intercalarParImpar()
        {
            numerosEnteros numberPos = new numerosEnteros();
            numerosEnteros numberDesp = new numerosEnteros();

            int filPos, colPos, filDesp, colDesp, idx;
            bool cambio = true;
            for(colPos = 1; colPos <= this.colum; colPos++)
            {
                for(filPos = 1; filPos <= this.fila; filPos++)
                {
                    if(cambio == true)
                    {
                        for(colDesp = colPos; colDesp <= this.colum; colDesp++)
                        {
                            if(colDesp == colPos)
                            {
                                idx = filPos;
                            }
                            else
                            {
                                idx = 1;
                            }
                            for(filDesp = idx; filDesp <= this.fila; filDesp++)
                            {
                                numberPos.cargarDatos(matriz[filPos, colPos]);
                                numberDesp.cargarDatos(matriz[filDesp, colDesp]);
                                if(numberDesp.verifcarPar() && !numberPos.verifcarPar() || 
                                   numberDesp.verifcarPar() && numberPos.verifcarPar() && (matriz[filDesp, colDesp] < matriz[filPos, colPos]) || 
                                   !numberDesp.verifcarPar() && !numberPos.verifcarPar() && (matriz[filDesp, colDesp] > matriz[filPos, colPos]))
                                {
                                    this.interCambio(filDesp, colDesp, filPos, colPos);
                                }
                            }
                        }
                    }
                    else
                    {
                        for(colDesp = colPos; colDesp <= this.colum; colDesp++)
                        {
                            if(colDesp == colPos)
                            {
                                idx = filPos;
                            }
                            else
                            {
                                idx = 1;
                            }
                            for(filDesp = idx; filDesp <= this.fila; filDesp++)
                            {
                                numberDesp.cargarDatos(matriz[filDesp, colDesp]);
                                numberPos.cargarDatos(matriz[filPos, colPos]);
                                if(!numberDesp.verifcarPar() && numberPos.verifcarPar() ||
                                    !numberDesp.verifcarPar() && !numberPos.verifcarPar() && (matriz[filDesp, colDesp] < matriz[filPos, colPos]) ||
                                    numberDesp.verifcarPar() && numberPos.verifcarPar() && (matriz[filDesp, colDesp] > matriz[filPos, colPos]))
                                {
                                    this.interCambio(filDesp, colDesp, filPos, colPos);
                                }
                            }
                        }
                    }
                    cambio = !cambio;
                }
            }
        }
        // Tema matrices cuadradas: 27/05/2024: O
        // ** Ordenamiento por triangulares superiores por columnas y filas **
        // Orden triangular inferior por filas: izquierda a derecha
        public void triangularInferiorFil(int numFila, int numCol, int ini, int razon)
        {
            int idx = 0;
            this.fila = numFila; this.colum = numCol;

            for(int fil1 = 2; fil1 <= this.fila; fil1++)
            {
                for(int col1 = 1; col1 < fil1; col1++)
                {
                    idx++;
                    matriz[fil1, col1] = ini + (idx - 1) * razon;
                }
            }
        }

        // Orden triangular inferior por columnas: de arriba hacia abajo
        public void triangularInferiorCol(int numfila, int numcol, int ini, int razon)
        {
            int idx = 0;
            this.fila = numfila; this.colum = numcol;
            for(int col1 = 1; col1 < this.colum; col1++)
            {
                for(int fil1 = col1 + 1; fil1 <= this.fila; fil1++)
                {
                    idx++;
                    matriz[fil1, col1] = ini + (idx - 1) * razon;
                }
            }
        }

        // Ordenamiento de diagonales principal y secundaria
        // orden diagonal principal (No funciona correctamente)
        public void ordenDiagonalPrincipal(int numfil, int numcol, int ini, int razon)
        {
            int ter = 0;
            for (int idx = 1; idx <= this.colum; idx++)
            {
                ter++;
                matriz[idx, idx] = ini + (ter - 1) * razon;
            }
        }

        // Orden diagonal secundaria (No funciona correctamente)
        public void ordenDiagonalSecund(int numfil, int numcol, int ini, int razon)
        {
            int ter = 0;
            for(int idx = 1; idx <= this.colum; idx++)
            {
                ter++;
                matriz[idx, this.fila - idx + 1] = ini + (ter - 1) * razon;
            }
        }

        // Intercambiar elementos por filas en forma diagonal
        public void interElemTranspuesta()
        {
            for(int fil1 = 2; fil1 <= this.fila; fil1++)
            {
                for(int col1 = 1; col1 < fil1; col1++)
                {
                    interCambio(fil1, col1, col1, fil1);
                }
            }
        }

        // Orden por filas en la triangular inferior, del extremo izquierdo de arriba hacia abajo
        public void ordenFilTrng()
        {
            int fil1, col1, fil2, col2, idx;
            for(fil1 = 2; fil1 <= this.fila; fil1++)
            {
                for(col1 = 1; col1 < fil1; col1++)
                {
                    for(fil2 = fil1; fil2 <= this.fila; fil2++)
                    {
                        if (fil2 == fil1)
                            idx = col1;
                        else
                            idx = 1;
                        for(col2 = idx; col2 < fil2; col2++)
                        {
                            if(matriz[fil2, col2] < matriz[fil1, col1])
                            {
                                this.interCambio(fil2, col2, fil1, col1);
                            }
                        }
                    }
                }
            }
        }

        // Orden por filas en la triangular inferior del extremo derecho de abajo hacia arriba
        public void ordenFilTrng2()
        {
            int fil1, col1, fil2, col2, idx;

            for(fil1 = this.fila; fil1 >= 2; fil1--)
            {
                for(col1 = fil1 - 1; col1 >= 1; col1--)
                {
                    for(fil2 = fil1; fil2 >= 2; fil2--)
                    {
                        if (fil2 == fil1)
                            idx = col1;
                        else
                            idx = fil2 - 1;
                        for(col2 = idx; col2 >= 1; col2--)
                        {
                            if(matriz[fil2, col2] < matriz[fil1, col1])
                            {
                                this.interCambio(fil2, col2, fil1, col1);
                            }
                        }
                    }
                }
            }

        }

        // clase del dia 29/05/2024
        // Frecuencia de una triangular por filas
        public int frecuTriang(int elem)
        {
            int frecu = 0;
            for(int fil = this.fila; fil >= 2; fil--)
            {
                for(int col = fil - 1; col >= 1; col--)
                {
                    if(matriz[fil, col] == elem)
                    {
                        frecu++;
                    }
                }
            }

            return frecu;
        }

        // Segmentar elementos con frecuencia y sin frecuencia por filas de abajo hacia arriba

        public void segmentFrecu()
        {
            int fil1, col1, fil2, col2, idx;

            for(fil1 = this.fila; fil1 >= 2; fil1--)
            {
                for(col1 = fil1 - 1; col1 >= 1; col1--)
                {
                    for(fil2 = fil1; fil2 >=2; fil2--)
                    {
                        if (fil2 == fil1)
                            idx = col1;
                        else
                            idx = fil2 - 1;
                        for(col2 = idx; col2 >= 1; col2--)
                        {
                            if((frecuTriang(matriz[fil2, col2]) > 1) && (frecuTriang(matriz[fil1, col1]) == 1))
                            {
                                this.interCambio(fil2, col2, fil1, col1);
                            }
                        }
                    }
                }
            }
        }
        
        // segmentar frecuencia triangular en repetidos y no repetidos (sin orden)
        public void segmenTriangFrecu()
        {
            int fil1, col1, fil2, col2, idx;
            for(fil1 = this.fila; fil1 >= 2; fil1--)
            {
                for(col1 = fil1 - 1; col1 >= 1; col1--)
                {
                    for(fil2 = fil1; fil2 >= 2; fil2--)
                    {
                        if (fil2 == fil1)
                            idx = col1;
                        else
                            idx = fil2 - 1;
                        for(col2 = idx; col2 >= 1; col2--)
                        {
                            if((frecuTriang(matriz[fil2, col2]) > 1) && (frecuTriang(matriz[fil1, col1]) == 1) ||
                               (frecuTriang(matriz[fil2, col2]) > 1) && (frecuTriang(matriz[fil1, col1]) > 1) && (matriz[fil2, col2] < matriz[fil1, col1]))
                            {
                                this.interCambio(fil2, col2, fil1, col1);
                            }
                        }
                    }
                }
            }
        }

        // segmentar la triangular en frecuencia, ordenando de menor a mayor
        public void segmetFrecuTriangOrd3()
        {
            int fil1, col1, col2, fil2, idx;
            for(fil1 = this.fila; fil1 >= 2; fil1--)
            {
                for(col1 = fil1 - 1; col1 >= 1; col1--)
                {
                    for(fil2 = fil1; fil2 >= 2; fil2--)
                    {
                        if(fil2 == fil1)
                        {
                            idx = col1;
                        }
                        else
                        {
                            idx = fil2 - 1;
                        }
                        for(col2 = idx; col2 >= 1; col2--)
                        {
                            if((frecuTriang(matriz[fil2, col2]) > 1) && (frecuTriang(matriz[fil1, col1]) == 1) ||
                                (frecuTriang(matriz[fil2, col2]) > 1) && (frecuTriang(matriz[fil1, col1]) > 1) && (matriz[fil2, col2] < matriz[fil1, col1]) ||
                                (frecuTriang(matriz[fil2, col2]) == 1) && (frecuTriang(matriz[fil1, col1]) == 1) && (matriz[fil2, col2] < matriz[fil1, col1]))
                            {
                                this.interCambio(fil2, col2, fil1, col1);
                            }
                        }
                    }
                }
            }
        }

        // intercalar segmentar en repetidos y no repetidos la triangular
        public void intercalarRepNoRepTriang()
        {
            int fil1, col1, fil2, col2, idx; bool change = true;

            for(fil1 = this.fila; fil1 >= 2; fil1--)
            {
                for(col1 = fil1 - 1; col1 >= 1; col1--)
                {
                    if(change == true)
                    {
                        for(fil2 = fil1; fil2 >= 2; fil2--)
                        {
                            if (fil2 == fil1)
                                idx = col1;
                            else
                                idx = fil2 - 1;
                            for(col2 = idx; col2 >= 1; col2--)
                            {
                                if ((frecuTriang(matriz[fil2, col2]) > 1) && (frecuTriang(matriz[fil1, col1]) == 1) ||
                                (frecuTriang(matriz[fil2, col2]) > 1) && (frecuTriang(matriz[fil1, col1]) > 1) && (matriz[fil2, col2] < matriz[fil1, col1]) ||
                                (frecuTriang(matriz[fil2, col2]) == 1) && (frecuTriang(matriz[fil1, col1]) == 1) && (matriz[fil2, col2] < matriz[fil1, col1]))
                                {
                                    this.interCambio(fil2, col2, fil1, col1);
                                }
                            }
                        }
                    }
                    else
                    {
                        for (fil2 = fil1; fil2 >= 2; fil2--)
                        {
                            if (fil2 == fil1)
                                idx = col1;
                            else
                                idx = fil2 - 1;
                            for (col2 = idx; col2 >= 1; col2--)
                            {
                                if (!(frecuTriang(matriz[fil2, col2]) > 1) && !(frecuTriang(matriz[fil1, col1]) == 1) ||
                                !(frecuTriang(matriz[fil2, col2]) > 1) && !(frecuTriang(matriz[fil1, col1]) > 1) && (matriz[fil2, col2] < matriz[fil1, col1]) ||
                                !(frecuTriang(matriz[fil2, col2]) == 1) && !(frecuTriang(matriz[fil1, col1]) == 1) && (matriz[fil2, col2] < matriz[fil1, col1]))
                                {
                                    this.interCambio(fil2, col2, fil1, col1);
                                }
                            }
                        }
                    }
                    change = !change;
                }
            }
        }



        // *************************************************************************************************************

        // Funciones en proceso (No funcionan bien)
        public void ordenTri1()
        {
            int f1, c1, f2, c2, ic;
            for(f1 = 2; f1 <= this.fila; f1++)
            {
                for(c1 = 1; c1 <= f1 - 1; c1++)
                {
                    for(f2 = f1; f2 <= this.fila; f2++)
                    {
                        if (f2 == f1)
                            ic = c1;
                        else
                            ic = 1;
                        for(c2 = ic; c2 <= f2 - 1; c2++)
                        {
                            if (matriz[f2, c2] < matriz[f1, c1])
                                this.interCambio(f2, c2, f1, c1);
                        }
                    }
                }
            }
        }

        public void desconocido()
        {
            int fil1, col1;
            for(fil1 = 2; fil1 <= this.fila; fil1++)
            {
                for(col1 = 1; col1 <= fil1 - 1; col1++)
                {
                    this.interCambio(fil1, col1, col1, fil1);
                }
            }
        }
    }
}
