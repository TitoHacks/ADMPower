using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Windows.Forms;
using MSTSCLib;
using System.Diagnostics;
using System.Net.NetworkInformation;

namespace pcconclient
{
    public partial class Form1 : Form
    {
        void Main(string[] args) {
            
        }
        static private NetworkStream steam;
        static private StreamWriter streamw;
        static private StreamReader streamr;
        static private TcpClient client = new TcpClient();
        static private string nick = "no";
        private delegate void DAddItem(string s);
       public  int segundos;
        
        public Form1()
        {
            InitializeComponent();
        }
        private void AddItem(string s) {



          
            

          

           

            










        }

        void Listen() {
            while (client.Connected) {
                try
                {


                    this.Invoke(new DAddItem(AddItem), streamr.ReadLine());


                }
                catch {

                    
                
                }
            
            
            
            
            }
        
        
        
        }
 
    

        void Conectar()
        {
            try
            {
                client.Connect(textbox2.Text, 8000);
                if (client.Connected)
                {
                    Thread t = new Thread(Listen);
                    steam = client.GetStream();
                    streamw = new StreamWriter(steam);
                    streamr = new StreamReader(steam);
                    streamw.WriteLine();
                    streamw.Flush();
                    t.Start();
                    
                    bunifuCheckbox1.Enabled = true;
                    bunifuCheckbox2.Enabled = true;
                    bunifuCheckbox3.Enabled = true;
                    bunifuCheckbox4.Enabled = true;
                   

                }
                else
                {
                    MessageBox.Show("Error al conectarse al servidor");



                }

            }
            catch (Exception ex){
                MessageBox.Show("Servidor no disponible");
            
            
            }
        
        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            timer3.Start();
            bunifuCheckbox1.Enabled = false;
            bunifuCheckbox2.Enabled = false;
            bunifuCheckbox3.Enabled = false;
            bunifuCheckbox4.Enabled = false;

            segundos = 0;

        }



  

       

      

     

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCheckbox2_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox2.Checked) {


                streamw.WriteLine("freeze");

                streamw.Flush();

            }
        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox1.Checked)
            {


                streamw.WriteLine("quit");

                streamw.Flush();

            }
        }

        private void bunifuCheckbox3_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox3.Checked)
            {


                streamw.WriteLine("kill");

                streamw.Flush();

            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conectar();
        }

        private void bunifuCheckbox4_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox4.Checked)
            {


                streamw.WriteLine("blockimp");

                streamw.Flush();

            }
            else {

                streamw.WriteLine("unlockimp");

                streamw.Flush();

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            gunaLinePanel1.BackColor = gunaColorTransition1.Value;
            button1.IdleForecolor = gunaColorTransition1.Value;
            button1.IdleLineColor = gunaColorTransition1.Value;
            

            

        }
        int posY = 0;
        int posX = 0;
        private void gunaLinePanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {

                posX = e.X;
                posY = e.Y;

            }
            else {

                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            
            }
        }

        private void gunaTileButton1_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            float fcpu = pCPU.NextValue();
            gunaCircleProgressBar1.Value = (int)fcpu;
           
        }
        
        private void timer3_Tick(object sender, EventArgs e)
        {
           

           
            

            int minutos = segundos / 60;
            segundos = segundos + 1;
            if (segundos >= 60)
            {

                chart1.Series["TIME"].Points.AddY(minutos);

            }
         
            

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCheckbox5_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox5.Checked)
            {
                if (gunaNumeric1.Value == 1) {

                    streamw.WriteLine("60");

                    streamw.Flush();

                }
                else
                {
                    if (gunaNumeric1.Value == 2)
                    {

                        streamw.WriteLine("120");

                        streamw.Flush();

                    }
                    else
                    {
                        if (gunaNumeric1.Value == 3)
                        {

                            streamw.WriteLine("180");

                            streamw.Flush();

                        }
                        else
                        {
                            if (gunaNumeric1.Value == 4)
                            {

                                streamw.WriteLine("240");

                                streamw.Flush();

                            }
                            else
                            {
                                if (gunaNumeric1.Value == 5)
                                {

                                    streamw.WriteLine("300");

                                    streamw.Flush();

                                }
                                else
                                {
                                    if (gunaNumeric1.Value == 6)
                                    {

                                        streamw.WriteLine("360");

                                        streamw.Flush();

                                    }
                                    else
                                    {
                                        if (gunaNumeric1.Value == 7)
                                        {

                                            streamw.WriteLine("400");

                                            streamw.Flush();

                                        }
                                        else
                                        {
                                            if (gunaNumeric1.Value > 7)
                                            {

                                                MessageBox.Show("Not Supported");

                                            }


                                        }


                                    }


                                }


                            }


                        }


                    }


                }

                

            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            streamw.WriteLine(gunaTextBox1.Text);

            streamw.Flush();
        }
    }
}
