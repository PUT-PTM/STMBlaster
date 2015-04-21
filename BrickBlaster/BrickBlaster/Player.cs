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
       public int licznik_kary;
       public bool kara=false;
       public  string Nazwa = "player";
       public short Moc = 3;
       public short Szybkość = 2;
       public int Max_Bomb = 3;
       public int Postawionych_Bomb = 0;
       public bool zyje = true;
       public Vector2 Position;
       public int Id_bomb=1300;
       public Player(int Id_bomby)
       {
           Nazwa = "player";
           Moc = 3;
           Szybkość = 2;
           Max_Bomb = 2;
           Postawionych_Bomb = 0;
           Id_bomb = Id_bomby;
           zyje = true;
       }      
        public void Player_Poruszanie(bool[] tab)
        {
            if (kara == false)
            {
                if (tab[0] == true)
                {
                    Position.Y -= Szybkość;
                }
                if (tab[1] == true)
                {
                    Position.Y += Szybkość;
                }
                if (tab[2] == true)
                {
                    Position.X -= Szybkość;
                }
                if (tab[3] == true)
                {
                    Position.X += Szybkość;
                }
                if (Position.Y < 25)
                {
                    Position.Y = 25;
                }
            }
            else
            {
                if (tab[0] == true)
                {
                    Position.Y += Szybkość;
                }
                if (tab[1] == true)
                {
                    Position.Y -= Szybkość;
                }
                if (tab[2] == true)
                {
                    Position.X += Szybkość;
                }
                if (tab[3] == true)
                {
                    Position.X -= Szybkość;
                }
                if (Position.Y < 25)
                {
                    Position.Y = 25;
                }
            }
        }
        public int[] Logika_Bomba_stawianie(bool[] tab)
        {
            int[] tab_przekaz = new int[2];
            tab_przekaz[0] = 14;
            tab_przekaz[1] = 14;
            if (tab[4]== true)      
            {
                if (Postawionych_Bomb < Max_Bomb)
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
                Postawionych_Bomb++;
            }
        }
        public void Zmniejsz_liczbe_bomb_postawionych(int a)
        {       
                Postawionych_Bomb = Postawionych_Bomb - a;  
        }
        public void Aktualizuj_Pozycje(Vector2 Pozycja)
        {
            Position = Pozycja;
        }     
    }
}
