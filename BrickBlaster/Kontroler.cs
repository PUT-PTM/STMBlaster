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
    public class Kontroler
    { 
        public enum klawisz {Up=0,Down=1,Left=2,Right=3,Action=4};
        public bool[] tab = new bool[5];
        KeyboardState keyboardState;
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
    }
}
