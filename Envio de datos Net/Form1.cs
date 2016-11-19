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
using SaveToMySQL;


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

        public int ENPROCESO = 9;
        public int CALENTAMIENTO = 26;
        public int ESTERELIZACION = 29;
        public int COMPLETADO = 3;
        public int PRESION = 15;
        public int TEMPERATURA = 14;
        public int PARADAEMERGENCIA = 16;

        
        public bool _enProceso;
        public bool _precalentamieno;
        public bool _esterelizacion;
        public bool _completado;
        public bool _IniProceso;
        public bool _LecturaAutomatica = false;
        public int _IniEsterilizacion = 0;

        //para datagridview2
        public int _procesosCompletados;
        public string _HoraInicio;
        public string _HoraFin;
        public int CONSIGNATEMPERATURA = 8;
        public int CONSIGNAPRESION = 6;
        public int CONSIGNATIEMPO = 70;
        private int listo;
        public static bool forms_abiero = false;

        private int _ticks;
        private string _presion;
        private int _temperatura;
        
        private string _estado;
        //DateTime Horalectura = DateTime.Now;

        private bool _errorPresion;
        private bool _errorTemperatura;

        private void conectarModbus()
        {
            modbusClient = new ModbusClient("192.168.0.101", 502); //dirección estática del plc
            modbusClient.Connect();
            MessageBox.Show("Conexión establecida.");
            button1.Enabled = false;
            btnDesconectar.Enabled = true;
            btnIniProceso.Enabled = true;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {        
            try
            {
                this.conectarModbus();
                timer1.Start();
                if (_LecturaAutomatica == true)
                {
                    DateTime LecturaActualInicio = DateTime.Now;
                    button1.Enabled = false;
                    btnDesconectar.Enabled = false;
                    btnFinProceso.Enabled = true;
                    btnIniProceso.Enabled = false;
                    btnGuardar.Enabled = false;
                    //Iinicia Proceso
                    string _lecturaActual = LecturaActualInicio.Hour.ToString() + ":" + LecturaActualInicio.Minute.ToString() + ":" + LecturaActualInicio.Second.ToString();
                    lblHoraInicio.Text = _lecturaActual.ToString();
                    this.limpiarTabla();
                    _ticks = 0;
                }
            }
            catch
            {
                //En caso de no conectar saltan los siguientes mensajes
                MessageBox.Show("No se pudo conectar", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show("Revise que el PLC este conectado correctamente", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
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

                if (readcoils [ENPROCESO] == false && readcoils [CALENTAMIENTO] == false && readcoils [ESTERELIZACION] == false && readcoils[COMPLETADO] == false)
                {
                    pictureBox1.Image = Image.FromFile(@"grisText.bmp");
                    _estado = "apagado";
                }
                if (readcoils[ENPROCESO] == true && listo < 1)
                {
                    this.iniciarCaptura();
                    listo++;
                }
                if (readcoils[PARADAEMERGENCIA] == true)
                {
                    this.detenerLectura();
                }
            }
            catch
            {

            }
        }

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
        
        private void timer2_Tick(object sender, EventArgs e)
        {  
            //seleccion de la etapa de trabajo
            int presionestablecida = readHoldingRegisters[CONSIGNAPRESION] / 183;
                lblPresionEstablecida.Text = presionestablecida.ToString();
                int temperaturainicial = readHoldingRegisters[12] / 100;
                lblTemperaturaEstablecida.Text = temperaturainicial.ToString();
                if (readHoldingRegisters[PRESION] > 5000)
                {
                    _errorPresion = true;
                    pictureBox1.Image = Image.FromFile(@"rojoError.bmp");
                    _estado = "Presión elevada";
                }
                else { _errorPresion = false; }
                if (readHoldingRegisters[TEMPERATURA] > 11866)
                {
                    _errorTemperatura = true;
                    pictureBox1.Image = Image.FromFile(@"rojoError.bmp");
                    _estado = "Temperatura elevada";
                }

                else { _errorTemperatura = false; }

            //Agregando condicion
            if (_temperatura > 11400) //valor normal de trabajo es 11400
            {
                _IniEsterilizacion++;
            }
            int Timecomplet = conteoESeg;

            if (readcoils [ENPROCESO] == true && readcoils [CALENTAMIENTO] == true &&  _errorPresion == false && _errorTemperatura == false ) 
            //if (readcoils[ENPROCESO] && !_esterelizacion && !_errorPresion && !_errorTemperatura)
                {
                    _estado = "Calentamiento";
                    _enProceso = true;
                    _precalentamieno = true;
                    pictureBox1.Image = Image.FromFile(@"verdeText.bmp");
                }
                else
                {
                    //if (readcoils[ESTERELIZACION] && _enProceso && !_errorPresion && !_errorTemperatura)
                    if (readcoils[ESTERELIZACION] == true && _errorPresion == false && _errorTemperatura == false)
                    {
                        _estado = "Esterilizacion";
                        _precalentamieno = false;
                        _esterelizacion = true;
                        pictureBox1.Image = Image.FromFile(@"amarilloText.bmp");
                    }
                    else
                    {
                        if (readcoils [COMPLETADO] == true)
                            //if (lblTEsterilizacion.Text  = "1:0".ToString )
                        //if ( _IniEsterilizacion  && !readcoils[ESTERELIZACION] && !_precalentamieno && !_errorPresion && !_errorTemperatura)
                        {
                            
                            _estado = "Completado";
                            _enProceso = false;
                            _completado = true;
                            _esterelizacion = false;
                            _IniEsterilizacion = 0;
                           
                                if (_completado == true && _esterelizacion == false)
                                {
                                    _LecturaActualFin = DateTime.Now;

                                    string _lecturaActualFin = _LecturaActualFin.Hour.ToString() + ":" + _LecturaActualFin.Minute.ToString() + ":" + _LecturaActualFin.Second.ToString();
                                    lblHoraFin.Text = _lecturaActualFin.ToString();
                                    btnIniProceso.Enabled = false;
                                    btnIniProceso.Enabled = true;
                                    btnDesconectar.Enabled = true;
                                    btnFinProceso.Enabled = false;
                                    btnGuardar.Enabled = true;
                                    //Una vez completado el proceso se procede a guardar y detener el proceso de monitoreo

                                    _HoraInicio = lblHoraInicio.Text.ToString();
                                    _HoraFin = lblHoraFin.Text.ToString();
                                    pictureBox1.Image = Image.FromFile(@"azulText.bmp");
                                    
                                    //Se activará si se precisa que los datos se guarden de manera directa cada que finalice un proceso.
                                    //_ExportaraExcel.ExportarDataGridViewExcel(dataGridView1);
                                    listo = 0;
                                    this.guardarDB();
                                    try
                                    {
                                        timer2.Stop();
                                    }
                                    catch { }
                                    
                                }
                        }

                    }
                }

                DateTime Horalectura = DateTime.Now;
                _ticks++;
                this.incConteo(_precalentamieno);
                label13.Text = _ticks.ToString();
                string _tiempoActual = Horalectura.Hour.ToString() + ":" + Horalectura.Minute.ToString() + ":" + Horalectura.Second.ToString();
                int _presionRes = readHoldingRegisters[PRESION] / 183;
                _presion = readHoldingRegisters[PRESION].ToString();
                _temperatura = int.Parse( readHoldingRegisters[TEMPERATURA].ToString());

                int _temperatura10 = _temperatura / 100;
                
                if (_ticks > 0 ) //guarda datos cada 1 seg, osea 1seg+ que lo que se marca
                {
                    dataGridView1.Rows.Add(_ticks ,_tiempoActual , _presionRes, _temperatura10, _estado);
                }
        }

        private bool guardarDB()
        {
            Esterilizacion esterilizacion = new Esterilizacion();
            esterilizacion.horaFinal =  TimeSpan.Parse(this._LecturaActualFin.ToLongTimeString());
            esterilizacion.horaInicio = TimeSpan.Parse(this.LecturaActualInicio.ToLongTimeString());
            esterilizacion.presion = int.Parse(this.lblPresionEstablecida.Text);
            esterilizacion.temperatura = int.Parse(this.lblTemperaturaEstablecida.Text);
            esterilizacion.tiempoCalentamiento = this.conteoMin;
            esterilizacion.tiempoEsterilizado = this.conteoEMin;
            esterilizacion.noEsterilizacion = 0;
            if (esterilizacion.guardar())
            {
                esterilizacion.obtenerId();
                return esterilizacion.guardarRegistros(this.dataGridView1, esterilizacion);
            }
            return false;
        }

        private void incConteo(bool calentamiento)
        {
            if (calentamiento)
            {
                this.conteoSeg++;
                if (this.conteoSeg >= 60)
                {
                    this.conteoMin++;
                    this.conteoSeg = 0;
                }
                this.lblTCalentamiento.Text = this.conteoMin.ToString() + ":" + this.conteoSeg.ToString();
            }
            if(_esterelizacion)
            {
                this.conteoESeg++;
                if (this.conteoESeg >= 60)
                {
                    this.conteoEMin++;
                    this.conteoESeg = 0;
                }
                this.lblTEsterilizacion.Text = this.conteoEMin.ToString() + ":" + this.conteoESeg.ToString();
            }
            
        }
        private void btnDesconectar_Click(object sender, EventArgs e)
        {        
                btnDesconectar.Enabled = false;
                button1.Enabled = true;
                btnIniProceso.Enabled = false;
                button2.Enabled = true;
                btnGuardar.Enabled = false;
                modbusClient.Disconnect();
                MessageBox.Show("Conexion cerrada");
                timer1.Stop();           
        }


        public void limpiarTabla()
        {
            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Refresh();
        }
        private void btnIniProceso_Click(object sender, EventArgs e)
        {
            this.iniciarCaptura();
          //this.horaInicio = LecturaActualInicio;
        }

        private void iniciarCaptura()
        {
            this.limpiarTabla();
            _ticks = 0;
            LecturaActualInicio = DateTime.Now;
            button1.Enabled = false;
            btnDesconectar.Enabled = false;
            btnFinProceso.Enabled = true;
            btnIniProceso.Enabled = false;
            btnGuardar.Enabled = false;

            _LecturaAutomatica = true;
            _IniProceso = true;

            string _lecturaActual = LecturaActualInicio.Hour.ToString() + ":" + LecturaActualInicio.Minute.ToString() + ":" + LecturaActualInicio.Second.ToString();
            lblHoraInicio.Text = _lecturaActual.ToString();

            this.conteoEMin = 0;
            this.conteoESeg = 0;
            this.conteoMin = 0;
            this.conteoSeg = 0;
            timer2.Start();
            //this.horaInicio = LecturaActualInicio;
        }
        private void detenerLectura()
        {
            btnIniProceso.Enabled = false;
            btnIniProceso.Enabled = true;
            btnDesconectar.Enabled = true;
            btnFinProceso.Enabled = false;
            btnGuardar.Enabled = true;
            _IniProceso = false;
            _esterelizacion = false;
            _enProceso = false;
            DateTime _LecturaActualFin = DateTime.Now;

            string _lecturaActualFin = _LecturaActualFin.Hour.ToString() + ":" + _LecturaActualFin.Minute.ToString() + ":" + _LecturaActualFin.Second.ToString();
            lblHoraFin.Text = _lecturaActualFin.ToString();
            _IniEsterilizacion = 0;
            timer2.Stop();
            listo = 0;
        }
        private void btnFinProceso_Click(object sender, EventArgs e)
        {
            this.detenerLectura();
            //btnIniProceso.Enabled = false;
            //btnIniProceso.Enabled = true;
            //btnDesconectar.Enabled = true;
            //btnFinProceso.Enabled = false;
            //btnGuardar.Enabled = true;
            //_IniProceso = false;
            //DateTime _LecturaActualFin = DateTime.Now;

            //string _lecturaActualFin = _LecturaActualFin.Hour.ToString() + ":" + _LecturaActualFin.Minute.ToString() + ":" + _LecturaActualFin.Second.ToString();
            //lblHoraFin.Text = _lecturaActualFin.ToString();

            //timer2.Stop();
           // listo = 0;

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

        public int conteoSeg { get; set; }

        public int conteoMin { get; set; }

        public int conteoESeg { get; set; }

        public int conteoEMin { get; set; }

        public DateTime _LecturaActualFin { get; set; }

        public DateTime LecturaActualInicio { get; set; }

        private void bInformes_Click(object sender, EventArgs e)
        {
            FormGeneradordeInforme f = new FormGeneradordeInforme();
            f.Show();
        }
    }
}
