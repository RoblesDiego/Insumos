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
        //ModbusClient modbusClient;
        public Capturar()
        {
            InitializeComponent();
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
            //comment
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            try
            {
                label3.Text = Form1.readHoldingRegisters[14].ToString();
                label4.Text = Form1.readHoldingRegisters[15].ToString();
                label10.Text = Form1.readHoldingRegisters[10].ToString();
                

                if (Form1.readcoils[8] == true)
                {
                    DateTime FechaLectura = DateTime.Now;
                    string FechaActual = FechaLectura.Hour.ToString() + ":" + FechaLectura.Minute.ToString() + ":" + FechaLectura.Second.ToString();
                    label8.Text = FechaActual.ToString();
                    lblProceso.Text = Form1.readcoils[8].ToString();
                    pictureBox1.Image = Image.FromFile(@"D:\Imagenes\Bmp\green2.bmp");
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

                this.Close();
                MessageBox.Show("No se a realizado la conexion", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                

            }
        }
    }
}
