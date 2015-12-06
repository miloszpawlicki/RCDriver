using Newtonsoft.Json;
using RCDriver.Common;
using System;
using System.IO.Ports;
using System.Text.RegularExpressions;

namespace RCDriver.MainApp
{
    public delegate void MessageReceivedEventHandler(CommunicationProtocol sender, RCMessageEventArgs e);
    public class CommunicationProtocol
    {
        SerialPort serialPort;
        string portName;
        public event MessageReceivedEventHandler MessageReceived;

        public CommunicationProtocol(string portName)
        {
            this.portName = portName;
            this.serialPort = new SerialPort(this.portName);
            this.serialPort.DataReceived += serialPort_DataReceived;
            

        }

        public RCMessage Receive()
        {
            if (!this.serialPort.IsOpen) this.serialPort.Open();

            string sMessage = this.serialPort.ReadLine();

            return JsonConvert.DeserializeObject<RCMessage>(sMessage);
        }

        public void Send(RCMessage message)
        {
            if (!this.serialPort.IsOpen) this.serialPort.Open();

            this.serialPort.WriteLine(JsonConvert.SerializeObject(message));
        }

        void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            RCMessageEventArgs rcE = new RCMessageEventArgs();
            SerialPort sp = (SerialPort)sender;
            string messages = sp.ReadExisting();

            if(!string.IsNullOrEmpty(messages))
            {
                string[] messageTable = Regex.Split(messages, Environment.NewLine);

                foreach (string stringMessage in messageTable)
                {
                    rcE.Message = JsonConvert.DeserializeObject<RCMessage>(stringMessage);

                    this.onMessageReceived(rcE);

                }
            }


            
        }

        void onMessageReceived(RCMessageEventArgs e)
        {
            if(this.MessageReceived != null)
            {
                this.MessageReceived(this, e);  
            }
        }
    }
}
