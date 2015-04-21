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

namespace BrickBlaster
{
    class Kontroler
    {
        public enum klawisz {Up, Down, Left, Right, Brak };  
        public bool[] Wduszony = new bool[5];
        KeyboardState keyboardState;
        public bool[] Zwracanie()
        {
            for (int i = 0; i < 5; i++)
            {
                Wduszony[i] = false;
            }
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                Wduszony[0] = true;                
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                Wduszony[1] = true;         
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                Wduszony[2] = true;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                Wduszony[3] = true;
            }
            if (keyboardState.IsKeyDown(Keys.Space))
            {
                Wduszony[4] = true;
            }
         
            return Wduszony;
        }
        public bool[] Zwracanie2()
        {
            for (int i = 0; i < 5; i++)
            {
                Wduszony[i] = false;
            }
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.W))
            {
                Wduszony[0] = true;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                Wduszony[1] = true;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                Wduszony[2] = true;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                Wduszony[3] = true;
            }
            if (keyboardState.IsKeyDown(Keys.G))
            {
                Wduszony[4] = true;
            }
            return Wduszony;
        }     
    }
}
