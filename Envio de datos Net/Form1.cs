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

        public int M0;
        public int M1;
        public int M2;
        public int M3;
        public int M4;
        public int ENPROCESO = 8;
        public int ESTERELIZACION = 50;
        public bool _enProceso;
        public bool _precalentamieno;
        public bool _esterelizacion;
        public bool _completado;
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            btnDesconectar.Enabled = true;
            btnIniProceso.Enabled = true;
            
            try
            {
                timer1.Start();
                //timer2.Start();

                ////lo desabilite para trabajr offline
                modbusClient = new ModbusClient("10.10.255.168", 502);
                modbusClient.Connect();
                MessageBox.Show("Conexion establecida :-) ");
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
            try{

                if (readcoils[ENPROCESO] == true && readcoils [ESTERELIZACION] == false )
                {
                    _estado = "Precalentamiento";
                    _enProceso = true;
                    _precalentamieno = true;
                }
                else
                {
                    if (readcoils[ESTERELIZACION ] == true)
                    {
                        _estado = "Esterelizacion";
                        _precalentamieno = false;
                        _esterelizacion = true;
                    }
                    else
                    {
                        if (_esterelizacion  == true && readcoils[ESTERELIZACION ] == false)
                        {
                            _estado = "completado";
                            _enProceso = false;
                            _completado = true;
                            _esterelizacion = false;
                        }
                        else { _estado = "apagado"; }
                    }
                }

             DateTime Horalectura = DateTime.Now;
                _ticks++;
                label13.Text = _ticks.ToString();
                string tiempoactual = Horalectura.Hour.ToString() + ":" + Horalectura.Minute.ToString() + ":" + Horalectura.Second.ToString();
                _presion = readHoldingRegisters[6].ToString();
                _temperatura = readHoldingRegisters[40].ToString();
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

                modbusClient.Disconnect();
                MessageBox.Show("Conexion cerrada :-( ");
                timer1.Stop();
                //timer2.Stop();

            

        }

        private void btnIniProceso_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            btnDesconectar.Enabled = false;
            btnFinProceso.Enabled = true;
            btnIniProceso.Enabled = false;
            timer2.Start();
        }

        private void btnFinProceso_Click(object sender, EventArgs e)
        {
            btnIniProceso.Enabled = false;
            btnIniProceso.Enabled = true;
            btnDesconectar.Enabled = true;
            btnFinProceso.Enabled = false;
            timer2.Stop();
        }
    }
}
