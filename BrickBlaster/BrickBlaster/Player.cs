using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BrickBlaster
{
   public  class Player
   {
       #region -------------------Variables
       public int licznik_kary;
       public bool kara=false;
       public  string nazwa = "player";
       public short moc = 3;
       public float szybkość = 2.75F;
       public int maxBomb = 3;
       public int postawionychBomb = 0;
       public int timerBomby;
       public bool zyje = true;
       public Vector2 Position;
       public int idBomb=1300;
       #endregion
       public Player(int Id_bomby)
       {
           nazwa = "player";
           moc = 3;
           szybkość = 2;
           maxBomb = 2;
           postawionychBomb = 0;
           idBomb = Id_bomby;
           timerBomby = 8;
           zyje = true;
       }
       public void Player_Poruszanie(bool[] tab, GraphicsDeviceManager graphics)
        {
            if (kara == false)
            {
                if (tab[(int)Kontroler.klawisz.Up]==true)
                {
                    Position.Y -= szybkość;
                }
                if (tab[(int)Kontroler.klawisz.Down]==true)
                {
                    Position.Y += szybkość;
                }
                if (tab[(int)Kontroler.klawisz.Left]==true)
                {
                    Position.X -= szybkość;
                }
                if (tab[(int)Kontroler.klawisz.Right]==true)
                {
                    Position.X += szybkość;
                }
                if (Position.Y < 25)
                {
                    Position.Y = 25;
                }
            }
            else
            {
                if (tab[(int)Kontroler.klawisz.Up] == true)
                {
                    Position.Y += szybkość;
                }
                if (tab[(int)Kontroler.klawisz.Down] == true)
                {
                    Position.Y -= szybkość;
                }
                if (tab[(int)Kontroler.klawisz.Left] == true)
                {
                    Position.X += szybkość;
                }
                if (tab[(int)Kontroler.klawisz.Right] == true)
                {
                    Position.X -= szybkość;
                }
                if (Position.Y < 25)
                {
                    Position.Y = 25;
                }
            }
            if (Position.Y > graphics.PreferredBackBufferHeight - (145))
            {
                Position.Y = graphics.PreferredBackBufferHeight - (145);
            }
            if (Position.X < 275)
            {
               Position.X = 275;
            }
            if (Position.X > graphics.PreferredBackBufferWidth - (125))
            {
                Position.X = graphics.PreferredBackBufferWidth - (125);
            }
        }
        public int[] Logika_Bomba_stawianie(bool[] tab)
        {
            int[] tab_przekaz = new int[2];
            tab_przekaz[0] = 14;
            tab_przekaz[1] = 14;
            if (tab[4]== true)      
            {
                if (postawionychBomb < maxBomb)
                {
                 int u = (int)((Position.Y - 20) / 50);
                 int j = (int)((Position.X - 250) / 50);        
                  tab_przekaz[0] = u;
                  tab_przekaz[1] = j;           
                }         
            }
            return tab_przekaz; 
        }
        public void Zwieksz_liczbe_bomb_postawionych(int a)
        {
            if (a == 1)
            {
                postawionychBomb++;
            }
        }
        public void Zmniejsz_liczbe_bomb_postawionych(int a)
        {       
                postawionychBomb = postawionychBomb - a;  
        }
        public void Aktualizuj_Pozycje(Vector2 Pozycja)
        {
            Position = Pozycja;
        }     
    }
}
