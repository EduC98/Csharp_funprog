/*
Programa:       EncuentraParejasNumeros
Contacto:       Juan Dario Rodas - jdrodas @hotmail.com

Especificacionesde funcionamiento
=================================

Se ha implementado un juego de �Encuentre las parejas� que consiste en identificar 
la ubicaci�n de 8 parejas de n�meros distribuidas en 16 botones que el usuario debe 
presionar para revelar su ubicaci�n.

Cada vez que el usuario presiona un bot�n, en el cuadro de texto �Estado�, se 
visualiza cual fue el bot�n presionado y que valor est� all�. Cada vez que se presione 
dos botones de manera consecutivos, se visualiza una ventana emergente con informaci�n 
de la pareja revelada. Si los valores son iguales, se ha encontrado una pareja y se 
incrementar� el contador respectivo. Sea que se encuentre o no, el contador de intentos 
tambi�n se incrementar�.

En caso de que el jugador desee reiniciar el juego, el bot�n �Reiniciar el juego� 
distribuir� nuevamente los valores en ubicaciones diferentes y reiniciar� los respectivos 
contadores.

Cuando se encuentren las 8 parejas, el programa indicar� que se alcanz� la victoria.


*/



using System;
using System.Windows.Forms;

namespace EncuentraParejasNumeros
{
    public partial class Form1 : Form
    {
        //Aqui declaramos los atributos del juego
        private LogicaJuego miLogica;

        private Button[] arregloBotones;

        public Form1()
        {
            InitializeComponent();
            miLogica = new LogicaJuego();

            arregloBotones = new Button[16];

            //Aqui inicializamos los atributos del juego
            InicializaAtributos();

            //Llevamos los valores de los atributos a los cuadros de texto
            textoTotalIntentos.Text = miLogica.TotalIntentos.ToString();
            textoParejasEncontradas.Text = miLogica.TotalParejas.ToString();

        }

        private void InicializaAtributos()
        {
            //Aqui inicializamos la l�gica
            miLogica.InicializaLogica();

            //Aqui invocamos las funciones de inicializaci�n de arreglo
            InicializaArregloBotones();
        }

        // Este m�todo inicializa los Botones
        private void InicializaArregloBotones()
        {
            arregloBotones[0] = button1;
            arregloBotones[1] = button2;
            arregloBotones[2] = button3;
            arregloBotones[3] = button4;
            arregloBotones[4] = button5;
            arregloBotones[5] = button6;
            arregloBotones[6] = button7;
            arregloBotones[7] = button8;
            arregloBotones[8] = button9;
            arregloBotones[9] = button10;
            arregloBotones[10] = button11;
            arregloBotones[11] = button12;
            arregloBotones[12] = button13;
            arregloBotones[13] = button14;
            arregloBotones[14] = button15;
            arregloBotones[15] = button16;

            //Finalmente, aqui ocultamos todas las etiquetas de los botones
            for (int i = 0; i < arregloBotones.Length; i++)
            {
                arregloBotones[i].Text = "X";
                arregloBotones[i].Enabled = true; //Los habilitamos
            }
        }

        private void botonReiniciar_Click(object sender, EventArgs e)
        {
            InicializaAtributos();

            //Llevamos los valores de los atributos a los cuadros de texto
            textoTotalIntentos.Text = miLogica.TotalIntentos.ToString();
            textoParejasEncontradas.Text = miLogica.TotalParejas.ToString();

            textoEstado.Text = "Juego reinicializado.";

        }

        private void AnalizaBotonPresionado(int numeroBoton)
        {
            //Aqui leemos el valor del dato correspondiente al boton presionado
            int datoValor = miLogica.ArregloValores[numeroBoton - 1];

            //Luego visualizamos el valor en el bot�n presionado
            arregloBotones[numeroBoton - 1].Text = datoValor.ToString();

            //preparamos el texto para el texto de estado
            textoEstado.Text = "Presionaste el bot�n " +
                numeroBoton.ToString() + ", el valor aqui es: " +
                 datoValor.ToString();

            //Y tambi�n desactivamos el bot�n para que no se vuelva a usar mientras se
            //define la busqueda de la pareja
            arregloBotones[numeroBoton - 1].Enabled = false;

            string resultadoAnalisis = miLogica.AnalizaPosicionSeleccionada(numeroBoton);

            if (miLogica.ParejaParteA != 0 && miLogica.ParejaParteB != 0)
                ValidaEtiquetasBotones();

            if (miLogica.ParejaParteB != 0)
            {
                //Se visualiza en un cuadro de dialogo que se ha encontrado una pareja
                MessageBox.Show(resultadoAnalisis, "Resultado del An�lisis", MessageBoxButtons.OK, MessageBoxIcon.Information);

                miLogica.ActualizaIntentos();
            }

            //Aqui actualizamos la informaci�n de los usuarios
            textoTotalIntentos.Text = miLogica.TotalIntentos.ToString();
            textoParejasEncontradas.Text = miLogica.TotalParejas.ToString();

            //Evaluamos condicion de victoria
            bool victoriaAlcanzada = miLogica.EvaluarCondicionVictoria();

            if (victoriaAlcanzada)
            {
                MessageBox.Show("Se ha identificado todas las parejas",
                                "Victoria Alcanzada!",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                textoEstado.Text = "Juego finalizado. Reinicia para jugar de nuevo.";
            }
        }

        //Este m�todo se encarga de volver a esconder aquellos valores que no han sido
        //relacionados en parejas, colocando en el bot�n una X
        private void ValidaEtiquetasBotones()
        {
            int datoValor;

            //Se valida si el valor fue encontrado. Si no, se vuelve a colocar la X
            for (int i = 0; i < miLogica.ArregloValores.Length; i++)
            {
                datoValor = miLogica.ArregloValores[i];

                //Se identifica en el arreglo de valoresEncontrados si ya se identific� la pareja
                if (miLogica.ValoresEncontrados[datoValor - 1] == false)
                {
                    //Si el valor no fue encontrado, el bot�n se coloca con X
                    arregloBotones[i].Text = "X";
                    arregloBotones[i].Enabled = true; //se habilita nuevamente el bot�n
                }
            }

            textoEstado.Text = "";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(11);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(12);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(13);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(14);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(15);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            AnalizaBotonPresionado(16);
        }

    }
}
