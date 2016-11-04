using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyModbus;
using System.IO;

namespace Envio_de_datos_Net
{
    public partial class Capturar : Form
    {

        public Bitmap MiGrafico;
        public Graphics ControlDeImagen;
        public int NumeroLectura;
        public int PosicionGrafica;
        //ModbusClient modbusClient;
        public Capturar()
        {
            InitializeComponent();
            timer2.Start();
            try
            {
                NumeroLectura = 1;
                PosicionGrafica = 1;
                MiGrafico = new Bitmap(Grafica.Width, Grafica.Height);
                ControlDeImagen = Graphics.FromImage(MiGrafico);
            }
            catch
            {

            }
        }

        
        private void btnInicio_Click(object sender, EventArgs e)
        {
            //Form1 frm = new Form1();
            //frm.Show();
            Form1.forms_abiero = false;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            try
            {
                label3.Text = Form1.readHoldingRegisters[40].ToString();
                label4.Text = Form1.readHoldingRegisters[6].ToString();
                label10.Text = Form1.readHoldingRegisters[10].ToString();

                int _temperaturaAnterior = Form1.readHoldingRegisters[40];
                int _presionAnterior = Form1.readHoldingRegisters[6];
                

                if (Form1.readcoils[8] == true)
                {
                    DateTime FechaLectura = DateTime.Now;
                    string FechaActual = FechaLectura.Hour.ToString() + ":" + FechaLectura.Minute.ToString() + ":" + FechaLectura.Second.ToString();
                    label8.Text = FechaActual.ToString();
                    lblProceso.Text = Form1.readcoils[8].ToString();
                    pictureBox1.Image = Image.FromFile(@"D:\Imagenes\Bmp\green2.bmp");

                    //GraficoAnimacion
                    float PosicionX1 = ((PosicionGrafica - 1) * 15);
                    float PosicionX2 = ((PosicionGrafica) * 15);

                    float PosicionY1 = (Grafica.Height - (_temperaturaAnterior * 40));
                    float PosicionY2 = (Grafica.Height - (Form1.readHoldingRegisters[40] * 40));
                    ControlDeImagen.DrawLine(new Pen(Color.Black), PosicionX1, PosicionY1, PosicionX2, PosicionY2);

                    PosicionY1 = (Grafica.Height - (_presionAnterior / 10));
                    PosicionY2 = (Grafica.Height - (Form1.readHoldingRegisters[6] / 10));
                    ControlDeImagen.DrawLine(new Pen(Color.Blue), PosicionX1, PosicionY1, PosicionX2, PosicionY2);
                    if (PosicionGrafica  >20 )//|| PosicionX2 > 5 || PosicionY1 > 5 || PosicionY2 > 2)
                    {
                        PosicionGrafica = 0;
                        PosicionX1 = 0;
                        PosicionX2 = 0;
                        PosicionY1 = 0;
                        PosicionY2 = 0;
                    }
                    //PosicionY1 = (Grafica.Height - (Form1.readHoldingRegisters[40] * 40));
                    //PosicionY2 = (Grafica.Height - (BateriaVoltaje * 40));
                    //ControlDeImagen.DrawLine(new Pen(Color.Yellow), PosicionX1, PosicionY1, PosicionX2, PosicionY2);

                    //PosicionY1 = (Grafica.Height - (Form1.readHoldingRegisters[40] * 10));
                    //PosicionY2 = (Grafica.Height - (BateriaCarga * 10));
                    //ControlDeImagen.DrawLine(new Pen(Color.Green), PosicionX1, PosicionY1, PosicionX2, PosicionY2);

                    Grafica.Image = MiGrafico;
                    PosicionGrafica = PosicionGrafica + 1;



                }
                else
                {
                    //this.Close();
                    lblProceso.Text = Form1.readcoils[8].ToString();
                    pictureBox1.Image = Image.FromFile(@"D:\Imagenes\Bmp\red.bmp");
                }
            }
            catch
            {
                timer2.Stop();
                this.Close();
                MessageBox.Show("No se a realizado la conexion", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                

            }
        }
    }
}
