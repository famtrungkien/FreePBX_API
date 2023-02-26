using SuperSimpleTcp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FreePBX_API;

namespace TestAPI
{
    public partial class Form1 : Form
    {

        private FreePBX_API api;
        public Form1()
        {
            InitializeComponent();
            Thread.Sleep(1000);

        }

        private void connectedEvent(object s, ConnectedArgs e)
        {
            label2.Invoke((MethodInvoker)(() => label2.Text = "Connected" ));

            
        }
        private void disconnectedEvent(object s, DisconnectedArgs e)
        {
            label2.Invoke((MethodInvoker)(() => label2.Text = "Disconnected"));
            
        }
        private void receivedData(object s,  ReceivedDataArgs e)
        {
            textBox13.Invoke((MethodInvoker)(() => textBox13.Text = e.ReceivedData));

            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string poPhone = textBox1.Text;
            string phonenum = textBox3.Text;
            api.Dial_To_A_SIPPhone(poPhone, phonenum);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string poPhone = textBox1.Text;
            string phonenum = textBox4.Text;
            api.Dial_To_A_AnalogPhone(poPhone, phonenum);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string volume = comboBox1.Text;
           
            api.set_Volume(textBox1.Text, Int16.Parse(volume));

        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            api = new FreePBX_API();
            api.ConnectedEvent += new ConnectedHandler(connectedEvent);
            api.DisconnectedEvent += new DisconnectedHandler(disconnectedEvent);
            api.ReceivedDataEvent += new ReceivedDataHandler(receivedData);
            api.FreePBX_API_Init();


            String tongdai = textBox12.Text;
            String poPhone = textBox1.Text;
    

            api.Init_PBXHelper(tongdai, poPhone);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string channel = textBox5.Text;
            api.Get_Exten_Status(channel);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string POPhone = textBox1.Text;
            List<string> lst_phoneNumber = new List<string>();
            lst_phoneNumber.Add(textBox2.Text);
            lst_phoneNumber.Add(textBox6.Text);


            api.Dial_To_Conference(POPhone, lst_phoneNumber, 0);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            api.set_Video_Single_For_Channel(textBox7.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string channel1 = "";
            string channel2 = "";
            string timeout = "30000";

            api.Hold_Number(channel1, channel2, timeout);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string channel1 = "";
            string Phone = "";
            api.Cancel_Hold_Number(channel1, Phone);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            api.Remove_A_Phonenumber_From_Conference(textBox10.Text);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            api.Add_Number_To_Conference(textBox11.Text, false);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            api.Finish_Conference();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            api.Finish_Call(textBox1.Text);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if(button15.Text == "Ghi âm")
            {
                button15.Text = "Dừng";
                string channel = "";
                string filename = "";
                bool mix = true;
                api.Start_Record_Channel(channel, filename, mix);
            }
            else
            {
                button15.Text = "Ghi âm";
                string channel = "";
                api.Stop_Record_Channel(channel);
            }
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (button16.Text == "Ghi âm hội nghị")
            {
                button16.Text = "Dừng";
                string filename = "";
                
                api.Start_Record_Conference(filename);
            }
            else
            {
                button16.Text = "Ghi âm hội nghị";
                api.Stop_Record_Conference();
            }
        }
    }
}
