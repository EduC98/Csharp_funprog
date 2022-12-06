/*
Programa:       SimRadio
Contacto:       Juan Dario Rodas - jdrodas@hotmail.com

Enunciado al problema:
----------------------

Realice un programa en C# con interfaz gr�fica en Windows Forms que simule 
el comportamiento de un radio FM.

El programa permitir� cambiar la frecuencia de la emisora a trav�s de dos botones
(F+,F-) que realizar�n incrementos de la frecuencia de a 1 MHz. Las frecuencias est�n
en el rango comprendido entre 88.9 y 107.9 MHz. El valor predeterminado para la frecuencia
actual cuando comienza el programa ser� de 88.9 MHz. Si se incrementa el valor 
por encima del l�mite superior, el valor siguiente ser� el de la frecuencia del l�mite 
inferior. De manera equivalente, si se decrementa por debajo del l�mite inferior, el valor
siguiente ser� el del l�mite superior. Con F+ y F- se podr� dar ciclos completos dentro
del rango de frecuencias especificado.

El programa permitir� cambiar el valor del volumen a trav�s de dos botones (V+,V-), los cuales
realizar�n incrementos de 1 unidad en un rango de valores entre 0 y 10. Si se llega a los
l�mites inferiores o superiores, los valores no podr�n superar o decrementar dichos l�mites.
El valor predeterminado del volumen ser� 0.

El programa tendr� un bot�n de encendido y apagado, el cual no permitir� que las funciones
se ejecuten en caso de que el radio est� apagado. Cuando el radio est� apagado, los valores
para la frecuencia y el volumen no se ven y los botones no funcionan 

Nota Importante:
----------------

Esta versi�n del proyecto tiene mezclada la funcionalidad de presentaci�n y l�gica en una
sola clase, Form1. En una versi�n mejorada, deber�a existir una clase "Logica" con el 
comportamiento del radio y la forma solo quede con los elementos de visualizaci�n.

*/


using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimRadio
{
    public partial class Form1 : Form
    {
        //Atributo de la clase
        private float frecuencia;
        private int volumen;
        private bool encendido;

        public Form1()
        {
            InitializeComponent();

            volumen = 0;
            frecuencia = 88.9f;
            encendido = false;
        }
        private void botonEncendido_Click(object sender, EventArgs e)
        {
            //Cambiamos el estado de encendido del radio
            CambiaEncendido();

            //Aqui cambiamos el fondo del bot�n dependiendo del estado
            ValidaEstadoRadio();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ValidaEstadoRadio();
        }

        private void ValidaEstadoRadio()
        {
            //Aqui cambiamos el fondo del bot�n dependiendo del estado
            if (encendido == true)
            {
                botonEncendido.BackColor = Color.Green;
                etiquetaValorFrecuencia.Text = frecuencia.ToString();
                etiquetaValorVolumen.Text = volumen.ToString();

                botonSubeVolumen.Enabled = true;
                botonBajaVolumen.Enabled = true;

                botonSubeFrecuencia.Enabled = true;
                botonBajaFrecuencia.Enabled = true;
            }
            else
            {
                botonEncendido.BackColor = Color.Red;
                etiquetaValorFrecuencia.Text = "";
                etiquetaValorVolumen.Text = "";

                botonSubeVolumen.Enabled = false;
                botonBajaVolumen.Enabled = false;

                botonSubeFrecuencia.Enabled = false;
                botonBajaFrecuencia.Enabled = false;
            }
        }

        private void botonSubeVolumen_Click(object sender, EventArgs e)
        {
            SubirVolumen();
            etiquetaValorVolumen.Text = volumen.ToString();
        }

        private void botonBajaVolumen_Click(object sender, EventArgs e)
        {
            BajarVolumen();
            etiquetaValorVolumen.Text = volumen.ToString();

        }

        private void botonSubeFrecuencia_Click(object sender, EventArgs e)
        {
            SubirFrecuencia();
            etiquetaValorFrecuencia.Text = frecuencia.ToString();
        }

        private void botonBajaFrecuencia_Click(object sender, EventArgs e)
        {
            BajarFrecuencia();
            etiquetaValorFrecuencia.Text = frecuencia.ToString();
        }

        //Metodos
        public void SubirVolumen()
        {
            if (volumen != 10)
                volumen++;
        }

        public void BajarVolumen()
        {
            if (volumen != 0)
                volumen--;
        }

        public void SubirFrecuencia()
        {
            if (frecuencia != 107.9f)
                frecuencia++;
            else
                frecuencia = 88.9f;
        }

        public void BajarFrecuencia()
        {
            if (frecuencia != 88.9f)
                frecuencia--;
            else
                frecuencia = 107.9f;
        }

        public void CambiaEncendido()
        {
            if (encendido == true)
                encendido = false;
            else
                encendido = true;
        }
    }
}
