﻿using System;
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
        private int _ticks;
        private string presion;
        private string _temperatura;
        //DateTime Horalectura = DateTime.Now;
        private string _estado;
        public static bool[] readcoils;
        public static int[] readHoldingRegisters;
        public static bool forms_abiero = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            btnDesconectar.Enabled = true;
            try
            {
                timer1.Start();
                timer2.Start();
                ////lo desabilite para trabajr offline
                modbusClient = new ModbusClient("10.10.255.168", 502);
                modbusClient.Connect();
                MessageBox.Show("Conexion establecida :-) ");
                //button1.Text = "Desconectar";

                //bool[] readcoils = modbusClient.ReadCoils(0, 10);
                //int[] readHoldingRegisters = modbusClient.ReadHoldingRegisters(0, 10);



                //for (int i = 0; i < readcoils.Length; i++)
                //    LM0.Text = readcoils[0].ToString();

                //for (int i = 0; i < readHoldingRegisters.Length; i++)
                //    label9.Text = readHoldingRegisters[0].ToString();
                //    label8.Text = readHoldingRegisters[8].ToString();
                

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            //timer1.Start();
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
            try
            {

                if(readcoils[8] == true)
                {
                    _estado = "Inicio proceso";
                }
                else { 
                    if (readcoils[50] == true && readcoils [8] == false )
                    {
                         _estado = "Precalentamiento";
                    }
                    else 
                    {
                        if (readcoils [51] == true && readcoils [50] == false)
                        {
                           _estado = "completado";
                        }
                        else { _estado = "apagado"; }
                    }
                        }


                DateTime Horalectura = DateTime.Now;
                _ticks++;
                label13.Text = _ticks.ToString();
                string tiempoactual = Horalectura.Hour.ToString() + ":" + Horalectura.Minute.ToString() + ":" + Horalectura.Second.ToString();
                presion = readHoldingRegisters[20].ToString();
                _temperatura = readHoldingRegisters[40].ToString();
                //timer2.Start();
                if (_ticks > 0) //guarda datos cada 5 seg, osea 1seg+ que lo que se marca
                {
                    dataGridView1.Rows.Add(_ticks ,tiempoactual , presion, _temperatura, _estado);
                    //_ticks = 0;
                }

            }
            catch { }
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            btnDesconectar.Enabled = false;
            button1.Enabled = true;
            
            modbusClient.Disconnect();
            MessageBox.Show("Conexion cerrada :-( ");
            timer1.Stop();
            timer2.Stop();
        }
    }
}
