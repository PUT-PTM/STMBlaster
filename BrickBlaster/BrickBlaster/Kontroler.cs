using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;
using System.IO;
namespace BrickBlaster
{
    public class Kontroler
    { 
        public enum klawisz {Up=0,Down=1,Left=2,Right=3,Action=4};
        public bool[] tab = new bool[5];
        KeyboardState keyboardState;
        private STMReceiver _receiver;
        private STMReceiver _receiver2;
        private TextReader czyt;                 
        public Kontroler()
        {
            czyt = new StreamReader("porty.txt");  
            String tekst;   
            tekst = czyt.ReadLine();
            Debug.WriteLine("pierwszy port : " + tekst);
            _receiver = new STMReceiver(tekst);
            tekst = czyt.ReadLine();
            Debug.WriteLine("drugi port : " + tekst);
            _receiver2 = new STMReceiver(tekst);
            czyt.Close();
            _receiver.StartListening();
            _receiver2.StartListening();
        }
        public bool[] Zwracanie()
        {
            for (int i = 0; i < 5; i++)
            {
                tab[i] = false;
            }
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                tab[(int)klawisz.Up] = true;                
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                tab[(int)klawisz.Down] = true;         
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                tab[(int)klawisz.Left] = true;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                tab[(int)klawisz.Right] = true;
            }
            if (keyboardState.IsKeyDown(Keys.Space))
            {
                tab[(int)klawisz.Action] = true;
            }
         
            return tab;
        }
        public bool[] Zwracanie2()
        {
            for (int i = 0; i < 5; i++)
            {
                tab[i] = false;               
            }
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.W))
            {
                tab[(int)klawisz.Up] = true;               
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                tab[(int)klawisz.Down] = true;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                tab[(int)klawisz.Left] = true;
            }

            if (keyboardState.IsKeyDown(Keys.D))
            {
                tab[(int)klawisz.Right] = true;
            }
            if (keyboardState.IsKeyDown(Keys.LeftControl))
            {
                tab[(int)klawisz.Action] = true;
            }
            return tab;
        }
        public bool[] STMZwracanie1()
        {
            Int16 axisX;
            Int16 axisY;
            Int16 axisZ;
            byte button1state;
            axisX = _receiver.axisX;
            axisZ = _receiver.axisZ;
            axisY = _receiver.axisY;
            button1state = _receiver.button1state;
            #region DEBUG axis Messages
           /* Debug.WriteLine("axisX = " + axisX);
            Debug.WriteLine("axisY = " + axisY);
            Debug.WriteLine("axisZ = " + axisZ);*/
            #endregion
            
            for (int i = 0; i < 5; i++)
            {
                tab[i] = false;
            }
            
            if (axisY>111&& axisY<132&&axisX<3&& axisZ>0&&axisZ<58)
            {
                tab[(int)klawisz.Left] = true;                
            }
            if (axisY>115&& axisY<132&&axisX>10&& axisZ>0&&axisZ<62)
            {
                tab[(int)klawisz.Right] = true;         
            }
            if (axisY>130&&axisX>-10&&axisX<5&& axisZ>40&&axisZ<65)
            {
                tab[(int)klawisz.Up] = true;
            }
            if (axisY<120&&axisX>-10&&axisX<5&& axisZ>40&&axisZ<65)
            {
                tab[(int)klawisz.Down] = true;
            }
            if (button1state==0xFF)
            {
                tab[(int)klawisz.Action] = true;
            }
         
            return tab;
         
        }
        public bool[] STMZwracanie2()
        {
            Int16 axisX;
            Int16 axisY;
            Int16 axisZ;
            byte button1state;
            axisX = _receiver2.axisX;
            axisZ = _receiver2.axisZ;
            axisY = _receiver2.axisY;
            button1state = _receiver2.button1state;
            #region DEBUG axis Messages
             Debug.WriteLine("axisX = " + axisX);
            Debug.WriteLine("axisY = " + axisY);
            Debug.WriteLine("axisZ = " + axisZ);
            #endregion

            for (int i = 0; i < 5; i++)
            {
                tab[i] = false;
            }



            if (axisY > 111 && axisY < 131 && axisX < 3 && axisZ > 0 && axisZ < 55)
            {
                tab[(int)klawisz.Left] = true;
            }
            if (axisY > 115 && axisY < 132 && axisX > 10 && axisZ > 0 && axisZ < 62)
            {
                tab[(int)klawisz.Right] = true;
            }
            if (axisY > 130 && axisX > -10 && axisX < 5 && axisZ > 40 && axisZ < 65)
            {
                tab[(int)klawisz.Up] = true;
            }
            if (axisY < 118 && axisX > -10 && axisX < 5 && axisZ > 40 && axisZ < 65)
            {
                tab[(int)klawisz.Down] = true;
            }
            if (button1state == 0xFF)
            {
                tab[(int)klawisz.Action] = true;
            }

            return tab;

        }
    }
}
