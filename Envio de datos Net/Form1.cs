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
    public partial class Form1 : Form
    {
        ModbusClient modbusClient;
        public Form1()
        {
            InitializeComponent();
        }
        

        //Direcciones de lectura PLC
        public static bool[] readcoils;
        public static int[] readHoldingRegisters;

        public int ENPROCESO = 8;
        public int ESTERELIZACION = 50;
        public int PRESION = 15;
        public int TEMPERATURA = 14;

        public bool _enProceso;
        public bool _precalentamieno;
        public bool _esterelizacion;
        public bool _completado;
        public bool _IniProceso;
        public bool _LecturaAutomatica = false;

        //para datagridview2
        public int _procesosCompletados;
        public string _HoraInicio;
        public string _HoraFin;
        public int CONSIGNATEMPERATURA = 40;
        public int CONSIGNAPRESION = 64;
        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                //Prueba de conectar el PLC
                timer1.Start();
                modbusClient = new ModbusClient("10.10.255.168", 502); //dirección estática del plc
                modbusClient.Connect();
                MessageBox.Show("Conexion establecida :-) ");
                button1.Enabled = false;
                btnDesconectar.Enabled = true;
                btnIniProceso.Enabled = true;
                //btnCapturar.Enabled = true;
                button2.Enabled = false;

                //if (readcoils [ENPROCESO] == true)
                //{
                //    _LecturaAutomatica = true;
                //}
                //else 
                //{}
                if (_LecturaAutomatica == true)
                {

                    DateTime LecturaActualInicio = DateTime.Now;
                    button1.Enabled = false;
                    btnDesconectar.Enabled = false;
                    btnFinProceso.Enabled = true;
                    btnIniProceso.Enabled = false;
                    btnGuardar.Enabled = false;

                    //_IniProceso = true;
                    //timer2.Start();

                    ////inicia proceso


                    string _lecturaActual = LecturaActualInicio.Hour.ToString() + ":" + LecturaActualInicio.Minute.ToString() + ":" + LecturaActualInicio.Second.ToString();
                    lblHoraInicio.Text = _lecturaActual.ToString();
                    dataGridView1.Rows.Add("Nro Lectura", "Tiempo actual", "Presión", "Temperatura", "Etapa");//Agrega titulo para el excel
                }
                else
                {
                }

            }
            catch
            {
                //En caso de no conectar saltan los siguientes mensajes
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            try
            {


                //bool[] 
                    readcoils = modbusClient.ReadCoils(0, 100);
                //int[] 
                    readHoldingRegisters = modbusClient.ReadHoldingRegisters(0, 100);

                if (_IniProceso  == false)
                {
                   
                    //pictureBox1.Image = Image.FromFile(@"D:\Imagenes\Bmp\grisText.bmp");
                    pictureBox1.Image = Image.FromFile(@"grisText.bmp");
                    _estado = "apagado";
                }
                else
                {
                    
                }
                if (readcoils[ENPROCESO] == true && listo < 1)
                {
                    DateTime LecturaActualInicio = DateTime.Now;
                    button1.Enabled = false;
                    btnDesconectar.Enabled = false;
                    btnFinProceso.Enabled = true;
                    btnIniProceso.Enabled = false;
                    btnGuardar.Enabled = false;

                    _IniProceso = true;
                    timer2.Start();
                    _LecturaAutomatica = true;
                    //inicia proceso;


                    string _lecturaActual = LecturaActualInicio.Hour.ToString() + ":" + LecturaActualInicio.Minute.ToString() + ":" + LecturaActualInicio.Second.ToString();
                    lblHoraInicio.Text = _lecturaActual.ToString();
                    dataGridView1.Rows.Add("Nro Lectura", "Tiempo actual", "Presión", "Temperatura", "Etapa");//Agrega titulo para el excel

                    listo++;
                }
                else
                { }


            }
            catch
            {

            }
        }
        private int listo;
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

        private bool _errorPresion;
        private bool _errorTemperatura;
        private void timer2_Tick(object sender, EventArgs e)
        {

           
            //seleccion de la etapa de trabajo
            try{
                if (readHoldingRegisters[PRESION] > 12)
                {
                    _errorPresion = true;
                    //pictureBox1.Image = Image.FromFile(@"D:\Imagenes\Bmp\rojoError.bmp");
                    pictureBox1.Image = Image.FromFile(@"rojoError.bmp");
                    _estado = "Presión elevada";
                }
                else { _errorPresion = false; }
                if (readHoldingRegisters[TEMPERATURA] > 118)
                {
                    _errorTemperatura = true;
                    //pictureBox1.Image = Image.FromFile(@"D:\Imagenes\Bmp\rojoError.bmp");
                    pictureBox1.Image = Image.FromFile(@"rojoError.bmp");
                    _estado = "Temperatura elevada";
                }

                else { _errorTemperatura = false; }
                if (readcoils[ENPROCESO] == true && _esterelizacion == false && _errorPresion == false && _errorTemperatura == false)
                {
                    _estado = "Precalentamiento";
                    _enProceso = true;
                    _precalentamieno = true;

                    //pictureBox1.Image = Image.FromFile(@"D:\Imagenes\Bmp\verdeText.bmp");
                    pictureBox1.Image = Image.FromFile(@"verdeText.bmp");
                    
                }
                else
                {
                    if (readcoils[ESTERELIZACION] == true && _enProceso == true && _errorPresion == false && _errorTemperatura == false)
                    {
                        _estado = "Esterelizacion";
                        _precalentamieno = false;
                        _esterelizacion = true;
                        //pictureBox1.Image = Image.FromFile(@"D:\Imagenes\Bmp\amarilloText.bmp");
                        pictureBox1.Image = Image.FromFile(@"amarilloText.bmp");
                    }
                    else
                    {
                        if (_esterelizacion == true && readcoils[ESTERELIZACION] == false && _errorPresion == false && _errorTemperatura == false)
                        {
                            _estado = "completado";
                            _enProceso = false;
                            _completado = true;
                            _esterelizacion = false;
                                                   

                            try
                            {
                                if (_completado == true)
                                {
                                    DateTime _LecturaActualFin = DateTime.Now;

                                    string _lecturaActualFin = _LecturaActualFin.Hour.ToString() + ":" + _LecturaActualFin.Minute.ToString() + ":" + _LecturaActualFin.Second.ToString();

                                    lblHoraFin.Text = _lecturaActualFin.ToString();

                                    btnIniProceso.Enabled = false;
                                    btnIniProceso.Enabled = true;
                                    btnDesconectar.Enabled = true;
                                    btnFinProceso.Enabled = false;
                                    btnGuardar.Enabled = true;
                                    //Una vez completado el proceso se procede a guardar y detener el proceso de monitoreo
                                    //pictureBox1.Image = Image.FromFile(@"D:\Imagenes\Bmp\azulText.bmp");
                                    _procesosCompletados++;
                                    _HoraInicio = lblHoraInicio.Text.ToString();
                                    _HoraFin = lblHoraFin.Text.ToString();
                                    dataGridView2.Rows.Add(_procesosCompletados, "", readHoldingRegisters[CONSIGNAPRESION], readHoldingRegisters[CONSIGNATEMPERATURA], _HoraInicio,_HoraFin, _estado);
                                    pictureBox1.Image = Image.FromFile(@"azulText.bmp");
                                    
                                    //Se activará si se precisa que los datos se guarden de manera directa cada que finalice un proceso.
                                    //Conexion_Net _ExportaraExcel = new Conexion_Net();
                                    //_ExportaraExcel.ExportarDataGridViewExcel(dataGridView1);
                                    //this.dataGridView1.Rows.Clear(); //Por fin!!! Borra datos luego de guardarlo a excel
                               
                                    timer2.Stop();
                                    listo = 0;
                                }
                            }
                            catch
                            {
                            }


                        }
                        else 
                        {
                        
                        }

                    }
                }

             DateTime Horalectura = DateTime.Now;
                _ticks++;
                label13.Text = _ticks.ToString();
                string _tiempoActual = Horalectura.Hour.ToString() + ":" + Horalectura.Minute.ToString() + ":" + Horalectura.Second.ToString();
                _presion = readHoldingRegisters[PRESION].ToString();
                _temperatura = readHoldingRegisters[TEMPERATURA].ToString();             
                if (_ticks > 0) //guarda datos cada 1 seg, osea 1seg+ que lo que se marca
                {
                    dataGridView1.Rows.Add(_ticks ,_tiempoActual , _presion, _temperatura, _estado);
                    
                }

            }
            catch { }

        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            
                btnDesconectar.Enabled = false;
                button1.Enabled = true;
                btnIniProceso.Enabled = false;
                button2.Enabled = true;
                btnGuardar.Enabled = false;

                modbusClient.Disconnect();
                MessageBox.Show("Conexion cerrada :-( ");
                timer1.Stop();
                //timer2.Stop();

            

        }
                
        private void btnIniProceso_Click(object sender, EventArgs e)
        {
            //this.dataGridView1.Rows.Clear();//limpia antes de leer nuevos datos
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
            DateTime _LecturaActualFin = DateTime.Now;

            string _lecturaActualFin = _LecturaActualFin.Hour.ToString() + ":" + _LecturaActualFin.Minute.ToString() + ":" + _LecturaActualFin.Second.ToString();
            lblHoraFin.Text = _lecturaActualFin.ToString();

          
            
            timer2.Stop();
            listo = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Conexion_Net _ExportaraExcel = new Conexion_Net();
            _ExportaraExcel.ExportarDataGridViewExcel(dataGridView1);
            this.dataGridView1.Rows.Clear(); //Por fin!!! Borra datos luego de guardarlo a excel.
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
