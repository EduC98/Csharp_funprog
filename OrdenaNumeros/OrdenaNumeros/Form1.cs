using System;
using System.Drawing;
using System.Windows.Forms;

namespace OrdenaNumeros
{
    public partial class Form1 : Form
    {
        //Atributos propios del juego
        private Button[,] matrizBotones;
        private LogicaJuego miLogica;

        /// <summary>
        /// Constructor de la clase Form1
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            miLogica = new LogicaJuego();
            miLogica.InicializaMatrizValores();

            matrizBotones = new Button[4, 4];
            //Aqui se invocan los metodos que inicializan las matrices
            InicializaMatrizBotones();
        }

        /// <summary>
        /// Evento que se usa cuando se carga la forma por primera vez
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            //Se invoca la inicializaci�n de botones
            InicializaEtiquetaBotones();
        }

        /// <summary>
        /// Inicializa la matriz de botones, con los botones del interfaz
        /// </summary>
        private void InicializaMatrizBotones()
        {
            matrizBotones[0, 0] = boton1;
            matrizBotones[0, 1] = boton2;
            matrizBotones[0, 2] = boton3;
            matrizBotones[0, 3] = boton4;

            matrizBotones[1, 0] = boton5;
            matrizBotones[1, 1] = boton6;
            matrizBotones[1, 2] = boton7;
            matrizBotones[1, 3] = boton8;

            matrizBotones[2, 0] = boton9;
            matrizBotones[2, 1] = boton10;
            matrizBotones[2, 2] = boton11;
            matrizBotones[2, 3] = boton12;

            matrizBotones[3, 0] = boton13;
            matrizBotones[3, 1] = boton14;
            matrizBotones[3, 2] = boton15;
            matrizBotones[3, 3] = boton16;
        }



        /// <summary>
        /// Asigna los valores de la matrizValores como etiquetas de los
        /// botones en la matrizBotones
        /// </summary>
        private void InicializaEtiquetaBotones()
        {
            //Recalculamos la matriz de valores
            miLogica.InicializaMatrizValores();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //El bot�n que tenga el valor 0, se ver� como vac�o
                    //para que el usuario pueda "desplazar" el valor all�
                    if (miLogica.MatrizValores[i, j] == 0)
                        matrizBotones[i, j].Text = "";
                    else
                        matrizBotones[i, j].Text = miLogica.MatrizValores[i, j].ToString();
                }
            }
        }

        /// <summary>
        /// Evento para reiniciar el juego desde la barra de Menus - ItemReiniciaJuego
        /// </summary>
        private void menuItemReiniciaJuego_Click(object sender, EventArgs e)
        {
            //Se invoca la inicializaci�n de botones
            InicializaEtiquetaBotones();

            //Se activan los botones para que puedan ser usados 
            ActivaBotones();

            //Se le coloca el color de fondo predeterminado
            InicializaFondoBotones();

            //Se da la notificaci�n si el valor se encuentra en la posici�n correcta
            NotificaPosicionCorrectaValor();
        }

        private void boton1_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(1, 0, 0);
        }

        private void boton2_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(2, 0, 1);
        }

        private void boton3_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(3, 0, 2);
        }

        private void boton4_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(4, 0, 3);
        }

        private void boton5_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(5, 1, 0);
        }

        private void boton6_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(6, 1, 1);
        }

        private void boton7_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(7, 1, 2);
        }

        private void boton8_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(8, 1, 3);
        }

        private void boton9_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(9, 2, 0);
        }

        private void boton10_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(10, 2, 1);
        }

        private void boton11_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(11, 2, 2);
        }

        private void boton12_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(12, 2, 3);
        }

        private void boton13_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(13, 3, 0);
        }

        private void boton14_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(14, 3, 1);
        }

        private void boton15_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(15, 3, 2);
        }

        private void boton16_Click(object sender, EventArgs e)
        {
            EvaluaBotonPresionado(16, 3, 3);
        }

        /// <summary>
        /// Evento para item salir que cierra la aplicaci�n
        /// </summary>
        private void menuItemSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Evalua informaci�n asociada al bot�n presionado
        /// </summary>
        /// <param name="numeroBoton">Consecutivo del bot�n presionado</param>
        /// <param name="datoFila">Fila en la matriz a la que pertenece el bot�n</param>
        /// <param name="datoColumna">Columna en la matriz a la que pertenece el bot�n</param>
        private void EvaluaBotonPresionado(int numeroBoton, int datoFila, int datoColumna)
        {
            miLogica.PosicionFila = datoFila;
            miLogica.PosicionColumna = datoColumna;

            //Aqui evaluamos en la matrizValores, la posici�n correspondiente al bot�n presionado
            EvaluaPosicion();

            //Finalmente, se da la notificaci�n si el valor se encuentra en la posici�n correcta
            NotificaPosicionCorrectaValor();
        }

        /// <summary>
        /// Evalua si la posici�n presionada est� adjacente al espacio disponible para usar
        /// </summary>
        private void EvaluaPosicion()
        {
            int valorTemporal = 0;

            //Validamos el valor superior a donde presionamos si est� el cero
            if (miLogica.PosicionFila > 0)
            {
                if (miLogica.MatrizValores[miLogica.PosicionFila - 1, miLogica.PosicionColumna] == 0)
                {
                    valorTemporal = miLogica.MatrizValores[miLogica.PosicionFila, miLogica.PosicionColumna];
                    miLogica.MatrizValores[miLogica.PosicionFila, miLogica.PosicionColumna] = 0;
                    miLogica.MatrizValores[miLogica.PosicionFila - 1, miLogica.PosicionColumna] = valorTemporal;
                }
            }

            //Validamos el valor inferior a donde presionamos si est� el cero
            if (miLogica.PosicionFila < 3)
            {
                if (miLogica.MatrizValores[miLogica.PosicionFila + 1, miLogica.PosicionColumna] == 0)
                {
                    valorTemporal = miLogica.MatrizValores[miLogica.PosicionFila, miLogica.PosicionColumna];
                    miLogica.MatrizValores[miLogica.PosicionFila, miLogica.PosicionColumna] = 0;
                    miLogica.MatrizValores[miLogica.PosicionFila + 1, miLogica.PosicionColumna] = valorTemporal;
                }
            }

            //Validamos el valor izquierdo a donde presionamos si est� el cero
            if (miLogica.PosicionColumna > 0)
            {
                if (miLogica.MatrizValores[miLogica.PosicionFila, miLogica.PosicionColumna - 1] == 0)
                {
                    valorTemporal = miLogica.MatrizValores[miLogica.PosicionFila, miLogica.PosicionColumna];
                    miLogica.MatrizValores[miLogica.PosicionFila, miLogica.PosicionColumna] = 0;
                    miLogica.MatrizValores[miLogica.PosicionFila, miLogica.PosicionColumna - 1] = valorTemporal;
                }
            }

            //Validamos el valor derecho a donde presionamos si est� el cero
            if (miLogica.PosicionColumna < 3)
            {
                if (miLogica.MatrizValores[miLogica.PosicionFila, miLogica.PosicionColumna + 1] == 0)
                {
                    valorTemporal = miLogica.MatrizValores[miLogica.PosicionFila, miLogica.PosicionColumna];
                    miLogica.MatrizValores[miLogica.PosicionFila, miLogica.PosicionColumna] = 0;
                    miLogica.MatrizValores[miLogica.PosicionFila, miLogica.PosicionColumna + 1] = valorTemporal;
                }
            }

            //Finalmente actualizamos etiquetas de los botones
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (miLogica.MatrizValores[i, j] == 0)
                        matrizBotones[i, j].Text = "";
                    else
                        matrizBotones[i, j].Text = miLogica.MatrizValores[i, j].ToString();
                }
            }

            //Y valoramos la condici�n de victoria
            EvaluaCondicionVictoria();
        }

        /// <summary>
        /// Esta funci�n valida si todos los n�meros est�n organizados
        /// </summary>
        private void EvaluaCondicionVictoria()
        {
            //Partimos del supuesto que ya logramos la condici�n de victoria
            bool condicionVictoria = true;

            int valorBuscado = 0;

            //Aqui recorremos la matriz de valores buscando para cada posici�n si el valor est� en orden
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //incrementamos el valor buscado
                    valorBuscado++;

                    //Si los valores son diferentes, entonces todav�a necesitamos seguir jugando!!!
                    if (miLogica.MatrizValores[i, j] != valorBuscado)
                    {
                        // Validamos si estamos en la �ltima casilla, el valor existente es 0,
                        // el valor buscado ya lleg� a 16 y la condici�n de victoria sigue siendo true
                        if (miLogica.MatrizValores[i, j] == 0 && valorBuscado == 16 && condicionVictoria == true)
                            condicionVictoria = true;

                        // De lo contrario, es porque estamos en cualquier otra casilla y los valores
                        // Todav�a no son iguales
                        else
                            condicionVictoria = false;
                    }
                }
            }


            //Si la condici�n de victoria se logr�, mostramos el mensaje de Victoria y desactivamos los botones
            if (condicionVictoria == true)
            {
                MessageBox.Show("Todos los n�meros organizados, Felicitaciones!", "Victoria Alcanzada!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                InactivaBotones();
            }
        }

        /// <summary>
        /// Esta funci�n inactiva los botones para ser utilizados en el juego
        /// </summary>
        private void InactivaBotones()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    matrizBotones[i, j].Enabled = false;
        }

        /// <summary>
        /// Esta funci�n activa los botones para ser utilizados en el juego
        /// </summary>
        private void ActivaBotones()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    matrizBotones[i, j].Enabled = true;
        }

        /// <summary>
        /// Notifica que el n�mero se encuentra en la posici�n correcta, cambiando el color de fondo del bot�n
        /// </summary>
        private void NotificaPosicionCorrectaValor()
        {

            int[,] valoresEsperados = new int[4, 4];
            int valor = 1;

            int totalFilas = valoresEsperados.GetLength(0);
            int totalColumnas = valoresEsperados.GetLength(1);

            //Aqui llenamos la matriz de los valores esperados
            for (int i = 0; i < totalFilas; i++)
                for (int j = 0; j < totalColumnas; j++)
                {
                    valoresEsperados[i, j] = valor;
                    valor++;
                }

            //Al finalizar el juego, en la posici�n 4,4 se encuentra el 0
            valoresEsperados[3, 3] = 0;

            //Ahora comparamos con los valores actuales para saber si est�n en la posici�n correcta
            for (int i = 0; i < totalFilas; i++)
                for (int j = 0; j < totalColumnas; j++)
                {
                    if (miLogica.MatrizValores[i, j] == valoresEsperados[i, j])
                        matrizBotones[i, j].BackColor = Color.LightGreen;
                    else
                        matrizBotones[i, j].BackColor = Color.LightGray;

                    //El bot�n que tiene el 0 no deber� cambiar de color
                    if (miLogica.MatrizValores[i, j] == 0)
                        matrizBotones[i, j].BackColor = Color.LightGray;
                }
        }

        /// <summary>
        /// M�todo que inicializa el fondo de los botones con un color gris claro
        /// </summary>
        private void InicializaFondoBotones()
        {
            int totalFilas = matrizBotones.GetLength(0);
            int totalColumnas = matrizBotones.GetLength(1);

            //Asignamos a todos los botones gris claro como color de fondo
            for (int i = 0; i < totalFilas; i++)
                for (int j = 0; j < totalColumnas; j++)
                    matrizBotones[i, j].BackColor = Color.LightGray;
        }
    }
}
