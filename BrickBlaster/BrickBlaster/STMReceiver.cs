using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
    public class STMReceiver : IDisposable
    {


        public bool Break;
        public Int16 axisX;
        public Int16 axisY;
        public Int16 axisZ;
        private bool _keepListenieng = true;
        private Thread t;
        public SerialPort Port;
        public void Dispose()
        {
            _keepListenieng = false;
        }
        public STMReceiver()
        {
            Port = new SerialPort("COM9", 112500, Parity.None, 8, StopBits.One);
            if (Port == null)
            {
                Debug.WriteLine("Error , Port = Null");
            }
            
            foreach (string port2 in SerialPort.GetPortNames())
            {
                Debug.WriteLine(port2);
            }

            try
            {
                Port.Open();
                Debug.WriteLine("Port open OK");
            }

            catch
            {
                Debug.WriteLine("Error, cannot open port");
            }
        }
        private void InternalStartListening()
        {
            // command = Port.ReadByte();
            while (_keepListenieng)
            {
                Port.BaseStream.Flush();
                //Data = Port.ReadByte();
                int command = Port.ReadByte();
                byte[] buffer = new byte[2];
                if (command == 0xAA)
                {
                    Debug.WriteLine("Accelerometer command nr: " + command + "\n");

                    buffer[0] = (byte)Port.ReadByte();
                    buffer[1] = (byte)Port.ReadByte();
                    axisX = BitConverter.ToInt16(buffer, 0);                 
                    buffer[0] = (byte)Port.ReadByte();
                    buffer[1] = (byte)Port.ReadByte();
                    axisY = BitConverter.ToInt16(buffer, 0);                  
                    buffer[0] = (byte)Port.ReadByte();
                    buffer[1] = (byte)Port.ReadByte();
                    axisZ = BitConverter.ToInt16(buffer, 0);     
                    buffer[0] = (byte)Port.ReadByte();
                    buffer[1] = (byte)Port.ReadByte();
                    Int16 max = BitConverter.ToInt16(buffer, 0);
                    byte crc = (byte)Port.ReadByte();
                    #region DEBUG Messages
                    Debug.WriteLine("X axis: " + axisX + "\n");
                    Debug.WriteLine("Y axis: " + axisY + "\n");
                    Debug.WriteLine("Z axis: " + axisZ + "\n");
                    Debug.WriteLine("Accelerometer max: " + max + "\n");
                    Debug.WriteLine("CRC: " + crc + "\n\n");
                    #endregion
                }
                else if (command == 0x38)
                {
                    Debug.WriteLine("Button command nr: " + command + "\n");
                    byte button1state = (byte)Port.ReadByte();
                    Debug.WriteLine("Button 1 state: " + button1state + "\n");
                    #region Additional Buttons
                    byte button2state = (byte)Port.ReadByte();
                    //Debug.WriteLine("Button 2 state: " + button2state + "\n");

                    byte button3state = (byte)Port.ReadByte();
                    //Debug.WriteLine("Button 3 state: " + button3state + "\n");

                    byte button4state = (byte)Port.ReadByte();
                    //Debug.WriteLine("Button 4 state: " + button4state + "\n");

                    byte crc = (byte)Port.ReadByte();
                    //Debug.WriteLine("CRC: " + crc + "\n\n");
                    #endregion
                    if (button1state == 0)
                        Break = false;
                    else
                        Break = true;
                }
            }
        }
        public void StartListening()
        {
            if (!Port.IsOpen)
            {
                Debug.WriteLine("Port is not open, cannot start listening");
                return;
            }
            t = new Thread(InternalStartListening);
            _keepListenieng = true;
            t.Start();
        }

    
}
