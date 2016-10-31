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
        public Form1()
        {
            InitializeComponent();
        }

        public int M0;
        public int M1;
        public int M2;
        public int M3;
        public int M4;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ////lo desabilite para trabajr offline
                modbusClient = new ModbusClient("10.10.255.168", 502);
                modbusClient.Connect();
                MessageBox.Show("Conexion establecida . . . ");
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
    }
}
