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
//using Microsoft.Office.Interop.Excel;

namespace Envio_de_datos_Net
{
    public partial class Form1 : Form
    {
        ModbusClient modbusClient;
        public Form1()
        {
            InitializeComponent();
        }


        public int ENPROCESO = 8;
        public int ESTERELIZACION = 50;
        public bool _enProceso;
        public bool _precalentamieno;
        public bool _esterelizacion;
        public bool _completado;
        public bool _IniProceso;
        private void button1_Click(object sender, EventArgs e)
        {
            //button1.Enabled = false;
            //btnDesconectar.Enabled = true;
            //btnIniProceso.Enabled = true;
            
            try
            {
                timer1.Start();
                //timer2.Start();

                ////lo desabilite para trabajr offline
                modbusClient = new ModbusClient("10.10.255.168", 502);
                modbusClient.Connect();
                MessageBox.Show("Conexion establecida :-) ");
                button1.Enabled = false;
                btnDesconectar.Enabled = true;
                btnIniProceso.Enabled = true;
                btnCapturar.Enabled = true;
                button2.Enabled = false;
                //bool[] writecoils = modbusClient.WriteSingleCoil[1];

                //button1.Text = "Desconectar";

                //bool[] readcoils = modbusClient.ReadCoils(0, 10);
                //int[] readHoldingRegisters = modbusClient.ReadHoldingRegisters(0, 10);



                //for (int i = 0; i < readcoils.Length; i++)
                //    LM0.Text = readcoils[0].ToString();

                //for (int i = 0; i < readHoldingRegisters.Length; i++)
                //    label9.Text = readHoldingRegisters[0].ToString();
                //    label8.Text = readHoldingRegisters[8].ToString();
                //otra prueba github

            }
            catch
            {
                //MessageBox.Show("Se a producido un error . . . :'(");
                MessageBox.Show("No se pudo conectar", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("Revise que el PLC este conectado correctamente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static bool [] readcoils;
        public static int[] readHoldingRegisters;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            try
            {
                //lo desabilite para trabajr offline
                //modbusClient = new ModbusClient("10.10.255.168", 502);
                //modbusClient.Connect();
                //MessageBox.Show("Conexion establecida . . . ");
                //button1.Text = "Desconectar";

                //bool[] 
                    readcoils = modbusClient.ReadCoils(0, 100);
                //int[] 
                    readHoldingRegisters = modbusClient.ReadHoldingRegisters(0, 100);


                for (int i = 0; i < readcoils.Length; i++)
                    LM0.Text = readcoils[0].ToString();

                for (int i = 0; i < readHoldingRegisters.Length; i++)
                    label9.Text = readHoldingRegisters[0].ToString();
                label8.Text = readHoldingRegisters[8].ToString();


                if (_IniProceso  == false)
                {
                   
                    //pictureBox1.Image = Image.FromFile(@"D:\Imagenes\Bmp\verde2.bmp");
                    pictureBox1.Image = Image.FromFile(@"D:\Imagenes\Bmp\grisText.bmp");
                }
                else
                {
                    //pictureBox1.Image = Image.FromFile(@"D:\Imagenes\Bmp\gris.bmp");
                }


            }
            catch
            {

            }
        }
        public static bool forms_abiero = false;
        private void btnCapturar_Click(object sender, EventArgs e)
        {
           
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType () == typeof (Capturar))
                {
                    forms_abiero = true;
                }
            } //preguntar si el form2 (capturar) est abierto
            if (forms_abiero == false)
            { 
            Capturar frm1 = new Capturar();
            frm1.Show();
            }
            
        }
        private int _ticks;
        private string _presion;
        private string _temperatura;
        private string _estado;
        //DateTime Horalectura = DateTime.Now;
       
        private void timer2_Tick(object sender, EventArgs e)
        {

           
            //seleccion de la etapa de trabajo
            try{

                if (readcoils[ENPROCESO] == true && readcoils [ESTERELIZACION] == false )
                {
                    _estado = "Precalentamiento";
                    _enProceso = true;
                    _precalentamieno = true;
                    pictureBox1.Image = Image.FromFile(@"D:\Imagenes\Bmp\verdeText.bmp");
                    //lblEstado.Text = "Precalentamiento".ToString();
                }
                else
                {
                    if (readcoils[ESTERELIZACION ] == true)
                    {
                        _estado = "Esterelizacion";
                        _precalentamieno = false;
                        _esterelizacion = true;
                        pictureBox1.Image = Image.FromFile(@"D:\Imagenes\Bmp\amarilloText.bmp");
                        //lblEstado.Text = "Esterelizacion".ToString();
                    }
                    else
                    {
                        if (_esterelizacion  == true && readcoils[ESTERELIZACION ] == false)
                        {
                            _estado = "completado";
                            _enProceso = false;
                            _completado = true;
                            _esterelizacion = false;
                            //lblEstado.Text = "completado".ToString();
                          

                            //tratando de deteenr y capturar la hora
                            try
                            {
                                if (_completado == true)
                                {
                                    DateTime LecturaActualFin = DateTime.Now;

                                    string _lecturaActualFin = LecturaActualFin.Hour.ToString() + ":" + LecturaActualFin.Minute.ToString() + ":" + LecturaActualFin.Second.ToString();

                                    lblHoraFin.Text = _lecturaActualFin.ToString();

                                    btnIniProceso.Enabled = false;
                                    btnIniProceso.Enabled = true;
                                    btnDesconectar.Enabled = true;
                                    btnFinProceso.Enabled = false;
                                    btnGuardar.Enabled = true;
                                    pictureBox1.Image = Image.FromFile(@"D:\Imagenes\Bmp\azulText.bmp");

                                    timer2.Stop();
                                }
                            }
                            catch
                            {
                            }


                        }
                        else 
                        {
                        _estado = "apagado";
                        //lblEstado.Text = "apagado".ToString();
                        //pictureBox1.Image = Image.FromFile(@"D:\Imagenes\Bmp\grisText.bmp");
                        }

                    }
                }

             DateTime Horalectura = DateTime.Now;
                _ticks++;
                label13.Text = _ticks.ToString();
                string tiempoactual = Horalectura.Hour.ToString() + ":" + Horalectura.Minute.ToString() + ":" + Horalectura.Second.ToString();
                _presion = readHoldingRegisters[6].ToString();
                _temperatura = readHoldingRegisters[40].ToString();
                //dataGridView1.Rows.Add("Nro Lectura", "Tiempo actual", "Presión", "Temperatura", "Estado");
                //timer2.Start();
                if (_ticks > 0) //guarda datos cada 5 seg, osea 1seg+ que lo que se marca
                {
                    dataGridView1.Rows.Add(_ticks ,tiempoactual , _presion, _temperatura, _estado);
                    //_ticks = 0;
                }

            }
            catch { }

        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            
                btnDesconectar.Enabled = false;
                button1.Enabled = true;
                btnIniProceso.Enabled = false;
                btnCapturar.Enabled = false;
                button2.Enabled = true;
                btnGuardar.Enabled = false;

                modbusClient.Disconnect();
                MessageBox.Show("Conexion cerrada :-( ");
                timer1.Stop();
                //timer2.Stop();

            

        }

        //DateTime LecturaActualInicio = DateTime.Now;
        
        private void btnIniProceso_Click(object sender, EventArgs e)
        {
            
            DateTime LecturaActualInicio = DateTime.Now;
            button1.Enabled = false;
            btnDesconectar.Enabled = false;
            btnFinProceso.Enabled = true;
            btnIniProceso.Enabled = false;
            btnGuardar.Enabled = false;
            //inicia proceso
            _IniProceso = true;
            timer2.Start();

            string _lecturaActual = LecturaActualInicio.Hour.ToString() + ":" + LecturaActualInicio.Minute.ToString() + ":" + LecturaActualInicio.Second.ToString();
            lblHoraInicio.Text = _lecturaActual.ToString();
            dataGridView1.Rows.Add("Nro Lectura", "Tiempo actual", "Presión", "Temperatura", "Etapa");//Agrega titulo para el excel
            
        }

        private void btnFinProceso_Click(object sender, EventArgs e)
        {
            btnIniProceso.Enabled = false;
            btnIniProceso.Enabled = true;
            btnDesconectar.Enabled = true;
            btnFinProceso.Enabled = false;
            btnGuardar.Enabled = true;
            _IniProceso = false;
            DateTime LecturaActualFin = DateTime.Now;

            string _lecturaActualFin = LecturaActualFin.Hour.ToString() + ":" + LecturaActualFin.Minute.ToString() + ":" + LecturaActualFin.Second.ToString();
            lblHoraFin.Text = _lecturaActualFin.ToString();

          

            timer2.Stop();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Conexion_Net exp = new Conexion_Net();
            exp.ExportarDataGridViewExcel(dataGridView1);
            dataGridView1.ClearSelection();
        }

        //public void exportarExcel (DataGridView _tabla)
        //{
        //    Microsoft.Office.Interop.Excel.Application _excel = new Microsoft.Office.Interop.Excel.Application();
        //    _excel.Application.Workbooks.Add(true);
        //    int _IndiceColumna = 0;

        //    foreach (DataGridViewColumn col in _tabla.Columns) //columnas
        //    {
        //        _IndiceColumna++;
        //        _excel.Cells[1, _IndiceColumna] = col.Name;
        //    }
        //    int _IndiceFila = 0;

        //    foreach (DataGridView row in _tabla.Rows) //Fila
        //    {
        //        _IndiceFila++;
        //        _IndiceColumna = 0;

        //        foreach (DataGridView col in _tabla.Columns)
        //        {
        //            _IndiceColumna++;
        //            _excel.Cells[_IndiceFila + 1, _IndiceColumna] =  _excel.Cells[col.Name].value;
        //        }
        //    }
        //    _excel.Visible = true;
        //} 
    }
}
