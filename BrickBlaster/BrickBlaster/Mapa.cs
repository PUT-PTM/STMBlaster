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
    class Mapa
    {

        public SoundEffect wybuch;
        public SoundEffect lost;
        public SoundEffect Bonus;
        public SoundEffect Czacha;
        public int Licznik=0;
        public int[,] tab_mapa = new int[13, 11];
        private void Czyszczenie_mapa()
        {
            for (int i = 0; i < 13; i ++)
            {
                for (int l = 0; l < 11; l ++)
                {
                        tab_mapa[i, l] = 0;
                }
            }
        }
        public void Stawianie_klockow()
        {
            Czyszczenie_mapa();
            // w tablicy : 1 - niezniszczalny klocek;  2- do niszczenia ; 300-306 - bomba , liczba wzrasta im blizej do wybuchu
            Random rnd = new Random();
            for (int i = 1; i < 13; i += 2)
            {
                for (int l = 1; l < 11; l += 2)
                {
                    tab_mapa[i, l] = 1;
                }
            }
            //Stawianie klockow do niszczenie-----------------------------------------------------------------------
            for (int i = 0; i < 13; i++)
            {
                for (int l = 0; l < 11; l++)
                {
                    if (tab_mapa[i, l] != 1)
                    {
                        int Losowanie = rnd.Next(3,5);
                        if (Losowanie != 4)
                            tab_mapa[i, l] = 2;
                    }
                }
            }
            tab_mapa[0, 0] = 0;
            tab_mapa[1, 0] = 0;
            tab_mapa[0, 1] = 0;
            tab_mapa[12, 10] = 0;
            tab_mapa[11, 10] = 0;
            tab_mapa[12, 9] = 0;
        }
        public int stawianie_bomby(int[] tab,Player Gracz1, Player Gracz2)
        {
            int u = tab[0];
            int j = tab[1];
            if (u < 14 && j < 14)
            {
                if ((tab_mapa[j, u] < Gracz1.Id_bomb || tab_mapa[j, u] > (Gracz1.Id_bomb + 10)))
                {
                    if ((tab_mapa[j, u] < Gracz2.Id_bomb || tab_mapa[j, u] > (Gracz2.Id_bomb + 10)))
                    {
                        if (tab_mapa[j, u] != 1 && tab_mapa[j, u] != 2)
                        {
                            tab_mapa[j, u] = Gracz1.Id_bomb;
                            return 1;
                        }
                    }
                }          
            }
            return 0;
        }
        public Vector2 kolizje(Vector2 Position, bool[] tab,bool kara)
        {
            if (kara == false)
            {
                for (int i = 0; i < 13; i++)
                {
                    for (int l = 0; l < 11; l++)
                    {
                        if (tab_mapa[i, l] == 1 || tab_mapa[i, l] == 2)
                        {
                            if ((Position.X > 230 + (i * 50)) && (Position.X < 315 + (i * 50)) && (Position.Y > (-5) + (l * 50)) && (Position.Y < 80 + (l * 50)))
                            {
                                if (tab[3] == true && tab[0] == false && tab[1] == false)
                                {
                                    Position.X = 230 + (i * 50);
                                }
                                else
                                {
                                    if (tab[2] == true && tab[0] == false && tab[1] == false)
                                    {
                                        Position.X = 315 + (i * 50);
                                    }

                                    if (tab[0] == true && tab[3] == false && tab[2] == false)
                                    {
                                        Position.Y = 80 + (l * 50);
                                    }
                                    else
                                    {
                                        if (tab[1] == true && tab[3] == false && tab[2] == false)
                                        {
                                            Position.Y = (-5) + (l * 50);
                                        }
                                        else
                                        {
                                            if (tab[1] == true && tab[3] == true)
                                            {
                                                Position.Y -= 2;
                                                Position.X -= 2;
                                            }
                                            if (tab[1] == true && tab[2] == true)
                                            {
                                                Position.Y -= 2;
                                                Position.X += 2;
                                            }
                                            if (tab[0] == true && tab[3] == true)
                                            {
                                                Position.Y += 2;
                                                Position.X -= 2;
                                            }
                                            if (tab[0] == true && tab[2] == true)
                                            {
                                                Position.Y += 2;
                                                Position.X += 2;
                                            }

                                        }

                                    }

                                }
                            }

                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < 13; i++)
                {
                    for (int l = 0; l < 11; l++)
                    {
                        if (tab_mapa[i, l] == 1 || tab_mapa[i, l] == 2)
                        {
                            if ((Position.X > 230 + (i * 50)) && (Position.X < 315 + (i * 50)) && (Position.Y > (-5) + (l * 50)) && (Position.Y < 80 + (l * 50)))
                            {
                                if (tab[2] == true && tab[0] == false && tab[1] == false)
                                {
                                    Position.X = 230 + (i * 50);
                                }
                                else
                                {
                                    if (tab[3] == true && tab[0] == false && tab[1] == false)
                                    {
                                        Position.X = 315 + (i * 50);
                                    }

                                    if (tab[1] == true && tab[3] == false && tab[2] == false)
                                    {
                                        Position.Y = 80 + (l * 50);
                                    }
                                    else
                                    {
                                        if (tab[0] == true && tab[3] == false && tab[2] == false)
                                        {
                                            Position.Y = (-5) + (l * 50);
                                        }
                                        else
                                        {
                                            if (tab[0] == true && tab[2] == true)
                                            {
                                                Position.Y -= 2;
                                                Position.X -= 2;
                                            }
                                            if (tab[0] == true && tab[3] == true)
                                            {
                                                Position.Y -= 2;
                                                Position.X += 2;
                                            }
                                            if (tab[1] == true && tab[2] == true)
                                            {
                                                Position.Y += 2;
                                                Position.X -= 2;
                                            }
                                            if (tab[1] == true && tab[3] == true)
                                            {
                                                Position.Y += 2;
                                                Position.X += 2;
                                            }

                                        }

                                    }

                                }
                            }

                        }
                    }
                }
            }
            return Position;
        }
        public void Logika_bomba(int licznik_klatek,Player Gracz1,Player Gracz2)
        {        
            for (int i = 0; i < 13; i++)
            {
                for (int l = 0; l < 11; l++)
                {

                    if (licznik_klatek % 30 == 0)
                    {
                        if (tab_mapa[i, l] >= Gracz1.Id_bomb && tab_mapa[i, l] < (Gracz1.Id_bomb+10))
                        {
                            tab_mapa[i, l] += 1;
                        }

                        if (tab_mapa[i, l] == (Gracz1.Id_bomb+10))
                        {

                            tab_mapa[i, l] = 30000;
                            Logika_Bomba_Wybuchv2(i, l,Gracz1,Gracz2);

                        }
                    }
                }
            }
            
        }
        public void Logika_Bomba_Wybuchv2(int i, int l, Player Gracz1, Player Gracz2)
        {
            //-------------------------------------------------------------------------------------Opis : ----------------------------------------------------------------------------------------------------
            // Funkcja sprawdzająca odpowiednie pola podczas wybuchu. Wstawia ona również bonusy w miejsce zniszczonych klocków z danym prawdopodobienstwem.
            int Losowanie;
            Random rnd = new Random();
            Logika_Smierc(i, l, Gracz1);
            for (int k = 1; k <= Gracz1.Moc; k++)
            {
                if (i + k <= 12)
                {
                    Logika_Smierc(i + k, l, Gracz1);
                    if (Gracz1.zyje == false)
                    {
                        break;
                    }
                    if (tab_mapa[i + k, l] == 2)
                    {

                       Losowanie = rnd.Next(1, 20);
                       if (Losowanie == 3||Losowanie == 9)
                       {
                           tab_mapa[i + k, l] = 20400;
                       }
                       if (Losowanie == 4||Losowanie == 10)
                       {
                           tab_mapa[i + k, l] =20401;
                       }
                       if (Losowanie == 5)
                       {
                           tab_mapa[i + k, l] = 20402;
                       }
                       if (Losowanie == 6)
                       {
                           tab_mapa[i+k, l ] = 20403;
                       }
                       if (Losowanie != 3 && Losowanie != 4 && Losowanie != 5 && Losowanie != 6&& Losowanie != 9 && Losowanie !=10 )
                       {
                           tab_mapa[i + k, l] = 20000;
                       }
                        // postawionych_bomb--;
                        break;
                    }
                    if (tab_mapa[i + k, l] == 1)
                    {
                        // postawionych_bomb--;
                        break;
                    }
                    if (tab_mapa[i + k, l] >= Gracz1.Id_bomb && tab_mapa[i + k, l] <= (Gracz1.Id_bomb + 10))
                    {
                        tab_mapa[i + k, l] =30000;
                        //postawionych_bomb--;
                        Logika_Bomba_Wybuchv2(i + k, l, Gracz1, Gracz2);
                        break;
                    }
                    if (tab_mapa[i + k, l] >= Gracz2.Id_bomb && tab_mapa[i + k, l] <= (Gracz2.Id_bomb + 10))
                    {
                        tab_mapa[i + k, l] = 30000;
                        //postawionych_bomb--;
                        Logika_Bomba_Wybuchv2(i + k, l, Gracz2,Gracz1);
                        break;
                    }
                    if (tab_mapa[i + k, l] != 30000)
                    {
                        tab_mapa[i + k, l] = 40000;
                    }

                }
            }
            for (int k = 1; k <= Gracz1.Moc; k++)
            {
                if (i - k >= 0)
                {
                    Logika_Smierc(i - k, l,Gracz1);
                    if (Gracz1.zyje == false)
                    {
                        break;
                    }
                    if (tab_mapa[i - k, l] == 2)
                    {
                        Losowanie = rnd.Next(1, 20);
                        if (Losowanie == 3|| Losowanie==9)
                        {
                            tab_mapa[i - k, l] = 21400;
                        }
                        if (Losowanie == 4|| Losowanie==10)
                        {
                            tab_mapa[i - k, l] = 21401;
                        }
                        if (Losowanie == 5)
                        {
                            tab_mapa[i - k, l] = 21402;
                        }
                        if (Losowanie == 6)
                        {
                            tab_mapa[i-k, l ] = 21403;
                        }
                        if (Losowanie != 3 && Losowanie != 4 && Losowanie != 5 && Losowanie != 6&& Losowanie != 9 && Losowanie !=10 )
                        {
                            tab_mapa[i - k, l] = 21000;
                        }
                        break;
                    }
                    if (tab_mapa[i - k, l] == 1)
                    {
                        break;
                    }
                    if (tab_mapa[i - k, l] >= Gracz1.Id_bomb && tab_mapa[i - k, l] <= (Gracz1.Id_bomb+10))
                    {
                        tab_mapa[i - k, l] = 30000;
                        Logika_Bomba_Wybuchv2(i - k, l,Gracz1,Gracz2);
                        break;
                    }
                    if (tab_mapa[i - k, l] >= Gracz2.Id_bomb && tab_mapa[i - k, l] <= (Gracz2.Id_bomb + 10))
                    {
                        tab_mapa[i - k, l] = 30000;
                        Logika_Bomba_Wybuchv2(i - k, l,Gracz2, Gracz1);
                        break;
                    }
                    if (tab_mapa[i - k, l] != 30000)
                    {
                        tab_mapa[i - k, l] = 40000;
                    }
                }
            }
            for (int k = 1; k <= Gracz1.Moc; k++)
            {
                if (l + k <= 10)
                {
                    Logika_Smierc(i, l + k, Gracz1);
                    if (Gracz1.zyje == false)
                    {
                        break;
                    }
                    if (tab_mapa[i, l + k] == 2)
                    {
                        Losowanie = rnd.Next(1, 10);
                        if (Losowanie == 3||Losowanie==9)
                        {
                            tab_mapa[i , l+k] = 22400;
                        }
                        if (Losowanie == 4||Losowanie==10)
                        {
                            tab_mapa[i , l+k] = 22401;
                        }
                        if (Losowanie == 5)
                        {
                            tab_mapa[i , l+k] = 22402;
                        }
                        if (Losowanie == 6)
                        {
                            tab_mapa[i, l + k] = 22403;
                        }
                        if (Losowanie != 3 && Losowanie != 4 && Losowanie != 5 && Losowanie != 6 && Losowanie != 9 && Losowanie != 10)
                        {
                            tab_mapa[i, l + k] = 22000;
                        }
                        break;
                    }
                    if (tab_mapa[i, l + k] == 1)
                    {
                        break;
                    }
                    if (tab_mapa[i, l + k] >= Gracz1.Id_bomb && tab_mapa[i, l + k] <= (Gracz1.Id_bomb+10))
                    {
                        tab_mapa[i, l + k] = 30000;
                        Logika_Bomba_Wybuchv2(i, l + k, Gracz1, Gracz2);
                        break;
                    }
                    if (tab_mapa[i, l + k] >= Gracz2.Id_bomb && tab_mapa[i, l + k] <= (Gracz2.Id_bomb + 10))
                    {
                        tab_mapa[i, l + k] = 30000;
                        Logika_Bomba_Wybuchv2(i, l + k,Gracz2, Gracz1);
                        break;
                    }
                    if (tab_mapa[i, l + k] != 30000)
                    {
                        tab_mapa[i, l + k] = 41000;
                    }
                }
            }
            for (int k = 1; k <= Gracz1.Moc; k++)
            {
                if (l - k >= 0)
                {
                    Logika_Smierc(i, l - k, Gracz1);
                    if (Gracz1.zyje == false)
                    {
                        break;
                    }
                    if (tab_mapa[i, l - k] == 2)
                    {                                       //BONUSY POJAWIANIE SIE ------------------------------------------------------
                        Losowanie = rnd.Next(1, 10);
                        if (Losowanie == 3||Losowanie==9)
                        {
                            tab_mapa[i , l - k] = 23400;
                        }
                        if (Losowanie == 4|| Losowanie==10)
                        {
                            tab_mapa[i , l - k] = 23401;
                        }
                        if (Losowanie == 5)
                        {
                            tab_mapa[i , l-k] = 23402;
                        }
                        if (Losowanie == 6)
                        {
                            tab_mapa[i, l - k] = 23403;
                        }
                        if (Losowanie != 3 && Losowanie != 4 && Losowanie != 5 && Losowanie != 6 && Losowanie != 9 && Losowanie != 10)
                        {
                            tab_mapa[i, l - k] = 23000;
                        }
                        break;
                    }
                    if (tab_mapa[i, l - k] == 1)
                    {
                        break;
                    }
                    if (tab_mapa[i, l - k] >= Gracz1.Id_bomb && tab_mapa[i, l - k] <= (Gracz1.Id_bomb+10))
                    {
                        tab_mapa[i, l - k] = 30000;
                        Logika_Bomba_Wybuchv2(i, l - k, Gracz1, Gracz2);
                        break;
                    }
                    if (tab_mapa[i, l - k] >= Gracz2.Id_bomb && tab_mapa[i, l - k] <= (Gracz2.Id_bomb + 10))
                    {
                        tab_mapa[i, l - k] = 30000;
                        Logika_Bomba_Wybuchv2(i, l - k,Gracz2, Gracz1);
                        break;
                    }
                    if (tab_mapa[i, l - k] != 30000)
                    {
                        tab_mapa[i, l - k] = 41000;
                    }
                }
            }
            Gracz1.Postawionych_Bomb--;
            wybuch.Play();
        }       
        public void Logika_Smierc(int i, int l, Player Gracz1)
        {
            if ((Gracz1.Position.X > 230 + (i * 50)) && (Gracz1.Position.X < 315 + (i * 50)) && (Gracz1.Position.Y > 12 + (l * 50)) && (Gracz1.Position.Y < 77 + (l * 50)))
            {
                Gracz1.zyje = false;
                lost.Play();
            }
        }
        public void Smierc_delay(Player Gracz1)
        {
            for (int l = 0; l < 11; l++)
            {
                for (int i = 0; i < 13; i++)
                {                    
                     if ((Gracz1.Position.X > 230 + (i * 50)) && (Gracz1.Position.X < 315 + (i * 50)) && (Gracz1.Position.Y > 12 + (l * 50)) && (Gracz1.Position.Y < 77 + (l * 50)))
                         if (tab_mapa[i, l] == 20000||tab_mapa[i, l] == 21000||tab_mapa[i, l] == 22000||tab_mapa[i, l] == 23000||tab_mapa[i, l] == 20400||tab_mapa[i, l] == 20401||tab_mapa[i, l] == 21400||tab_mapa[i, l] == 21401||tab_mapa[i, l] == 22400||tab_mapa[i, l] == 22401||tab_mapa[i, l] == 23400||tab_mapa[i, l] == 23401||tab_mapa[i, l] == 30000||tab_mapa[i, l] == 40000||tab_mapa[i, l] == 41000)
                         {
                               Gracz1.zyje = false;
                               lost.Play();
                         }
                }
            }
        }
        public void Sprawdz_Bonus(Player Gracz1,int Licznik_Bonusu)
        {          
            int u = (int)((Gracz1.Position.Y - 20) / 50);
            int j = (int)((Gracz1.Position.X - 250) / 50);   
            if (tab_mapa[j,u] == 400)
            {
                if (Gracz1.Max_Bomb + 1 <= 13)
                {
                    Gracz1.Max_Bomb++;
                }
                tab_mapa[j, u] = 0;
               Bonus.Play();
            }
            if (tab_mapa[j, u] == 401)
            {
                if (Gracz1.Moc + 1 <= 13)
                {
                    Gracz1.Moc++;
                }
                tab_mapa[j, u] = 0;
               Bonus.Play();
            }
            if (tab_mapa[j, u] == 402)
            {
                if (Gracz1.Max_Bomb - 1 > 0)
                {
                    Gracz1.Max_Bomb--;
                }
                if (Gracz1.Moc - 1 > 0)
                {
                    Gracz1.Moc--;
                }
                 tab_mapa[j, u] = 0;
                 Czacha.Play();
            }
            if (tab_mapa[j, u] == 403)
            {
               tab_mapa[j, u] = 0;
               Gracz1.licznik_kary = 0;
               Gracz1.kara = true;
               Czacha.Play();
            }
            if (Gracz1.licznik_kary >= 10)
            {
                Gracz1.licznik_kary = 0;
                Gracz1.kara = false;   
            }
            if (Licznik_Bonusu % 59 == 0 && Gracz1.kara == true)
            {
                Gracz1.licznik_kary++;
            }
        }
    }
}
