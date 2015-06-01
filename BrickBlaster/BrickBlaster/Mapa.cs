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
        #region --------------------SoundEffectsDeclaration
        public SoundEffect wybuch;
        public SoundEffect lost;
        public SoundEffect Bonus;
        public SoundEffect Czacha;
        #endregion
        #region --------------------Variables/Enums
        bool[,] zniszczone= new bool [13,11];
        public int Licznik=0;
        public int[,] tab_mapa = new int[13, 11];
        public enum brick { 
            Unbreakable=1, Breakable=2 };
        public enum fire {
            Right = 20000, RightBonusBomb = 20400, RightBonusPower = 20401, RightPunishPB = 20402, RightPunishSides=20403,
            Left = 21000, LeftBonusBomb = 21400, LeftBonusPower = 21401, LeftPunishPB = 21402, LeftPunishSides=21403,
            Down = 22000, DownBonusBomb = 22400, DownBonusPower = 22401, DownPunishPB = 22402, DownPunishSides = 22403,
            Up=23000, UpBonusBomb=23400, UpBonusPower=23401, UpPunishPB=23402, UpPunishSides=23403,            
            Middle=30000,
            Poziom=40000,
            Pion=41000}
        public enum bonus { 
            Bomb = 400, Power = 401, PunishBP = 402, PunishSides = 403 };
        #endregion
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
                    tab_mapa[i, l] = (int)brick.Unbreakable;
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
                            tab_mapa[i, l] = (int)brick.Breakable;
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
                if ((tab_mapa[j, u] < Gracz1.idBomb || tab_mapa[j, u] > (Gracz1.idBomb + Gracz1.timerBomby)))
                {
                    if ((tab_mapa[j, u] < Gracz2.idBomb || tab_mapa[j, u] > (Gracz2.idBomb + Gracz2.timerBomby)))
                    {
                        if (tab_mapa[j, u] != (int)brick.Unbreakable && tab_mapa[j, u] !=(int)brick.Breakable )
                        {
                            tab_mapa[j, u] = Gracz1.idBomb;
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
                        if (tab_mapa[i, l] == (int)brick.Unbreakable || tab_mapa[i, l] == (int)brick.Breakable)
                        {
                            if ((Position.X > 230 + (i * 50)) && (Position.X < 315 + (i * 50)) && (Position.Y > (3) + (l * 50)) && (Position.Y < 80 + (l * 50)))
                            {
                                if (tab[(int)Kontroler.klawisz.Right] == true && tab[(int)Kontroler.klawisz.Up] == false && tab[(int)Kontroler.klawisz.Down] == false && tab[(int)Kontroler.klawisz.Left]==false)
                                {
                                    Position.X = 230 + (i * 50);
                                }
                                else
                                {
                                    if (tab[(int)Kontroler.klawisz.Left] == true && tab[(int)Kontroler.klawisz.Up] == false && tab[(int)Kontroler.klawisz.Down] == false && tab[(int)Kontroler.klawisz.Right]==false)
                                    {
                                        Position.X = 315 + (i * 50);
                                    }

                                    if (tab[(int)Kontroler.klawisz.Up] == true && tab[(int)Kontroler.klawisz.Right] == false && tab[(int)Kontroler.klawisz.Left] == false)
                                    {
                                        Position.Y = 80 + (l * 50);
                                    }
                                    else
                                    {
                                        if (tab[(int)Kontroler.klawisz.Down] == true && tab[(int)Kontroler.klawisz.Right] == false && tab[(int)Kontroler.klawisz.Left] == false)
                                        {
                                            Position.Y = (3) + (l * 50);
                                        }
                                        else
                                        {
                                            if (tab[(int)Kontroler.klawisz.Down] == true && tab[(int)Kontroler.klawisz.Right] == true)
                                            {
                                                Position.Y -= 2;
                                                Position.X -= 2;
                                            }
                                            if (tab[(int)Kontroler.klawisz.Down] == true && tab[(int)Kontroler.klawisz.Left] == true)
                                            {
                                                Position.Y -= 2;
                                                Position.X += 2;
                                            }
                                            if (tab[(int)Kontroler.klawisz.Up] == true && tab[(int)Kontroler.klawisz.Right] == true)
                                            {
                                                Position.Y += 2;
                                                Position.X -= 2;
                                            }
                                            if (tab[(int)Kontroler.klawisz.Up] == true && tab[(int)Kontroler.klawisz.Left] == true)
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
                        if (tab_mapa[i, l] == (int)brick.Unbreakable || tab_mapa[i, l] == (int)brick.Breakable)
                        {
                            if ((Position.X > 230 + (i * 50)) && (Position.X < 315 + (i * 50)) && (Position.Y > (-5) + (l * 50)) && (Position.Y < 80 + (l * 50)))
                            {
                                if (tab[(int)Kontroler.klawisz.Left] == true && tab[(int)Kontroler.klawisz.Up] == false && tab[(int)Kontroler.klawisz.Down] == false)
                                {
                                    Position.X = 230 + (i * 50);
                                }
                                else
                                {
                                    if (tab[(int)Kontroler.klawisz.Right] == true && tab[(int)Kontroler.klawisz.Up] == false && tab[(int)Kontroler.klawisz.Down] == false)
                                    {
                                        Position.X = 315 + (i * 50);
                                    }

                                    if (tab[(int)Kontroler.klawisz.Down] == true && tab[(int)Kontroler.klawisz.Right] == false && tab[(int)Kontroler.klawisz.Left] == false)
                                    {
                                        Position.Y = 80 + (l * 50);
                                    }
                                    else
                                    {
                                        if (tab[(int)Kontroler.klawisz.Up] == true && tab[(int)Kontroler.klawisz.Right] == false && tab[(int)Kontroler.klawisz.Left] == false)
                                        {
                                            Position.Y = (-5) + (l * 50);
                                        }
                                        else
                                        {
                                            if (tab[(int)Kontroler.klawisz.Up] == true && tab[(int)Kontroler.klawisz.Left] == true && tab[(int)Kontroler.klawisz.Right] == false && tab[(int)Kontroler.klawisz.Down]==false)
                                            {
                                                Position.Y -= 2;
                                                Position.X -= 2;
                                            }
                                            if (tab[(int)Kontroler.klawisz.Up] == true && tab[(int)Kontroler.klawisz.Right] == true&&tab[(int)Kontroler.klawisz.Left] == false && tab[(int)Kontroler.klawisz.Down]==false)
                                            {
                                                Position.Y -= 2;
                                                Position.X += 2;
                                            }
                                            if (tab[(int)Kontroler.klawisz.Down] == true && tab[(int)Kontroler.klawisz.Left] == true&&tab[(int)Kontroler.klawisz.Right] == false && tab[(int)Kontroler.klawisz.Up]==false)
                                            {
                                                Position.Y += 2;
                                                Position.X -= 2;
                                            }
                                            if (tab[(int)Kontroler.klawisz.Down] == true && tab[(int)Kontroler.klawisz.Right] == true&&tab[(int)Kontroler.klawisz.Left] == false && tab[(int)Kontroler.klawisz.Up]==false)
                                            {
                                                Position.Y += 2;
                                                Position.X += 2;
                                            }
                                            if(tab[(int)Kontroler.klawisz.Right] == true && tab[(int)Kontroler.klawisz.Left]==true&&tab[(int)Kontroler.klawisz.Up] ==true&&tab[(int)Kontroler.klawisz.Down] ==false )
                                            {
                                              Position.Y = (-5) + (l * 50);
                                            }
                                             if(tab[(int)Kontroler.klawisz.Right] == true && tab[(int)Kontroler.klawisz.Left]==true&&tab[(int)Kontroler.klawisz.Down] ==true&&tab[(int)Kontroler.klawisz.Up] ==false ) 
                                            {
                                                Position.Y = 80 + (l * 50);
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
                        if (tab_mapa[i, l] >= Gracz1.idBomb && tab_mapa[i, l] < (Gracz1.idBomb+Gracz1.timerBomby))
                        {
                            tab_mapa[i, l] += 1;
                        }

                        if (tab_mapa[i, l] == (Gracz1.idBomb + Gracz1.timerBomby))
                        {

                            tab_mapa[i, l] = (int)fire.Middle;
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
            Logika_Smierc(i, l, Gracz2);
            for (int k = 1; k <= Gracz1.moc; k++)
            {
                if (i + k <= 12)
                {
                    Logika_Smierc(i + k, l, Gracz1);
                    Logika_Smierc(i + k, l, Gracz2);
                   /* if (Gracz1.zyje == false)
                    {
                        break;
                    }*/
                    if (tab_mapa[i + k, l] == (int)brick.Breakable)
                    {

                        Losowanie = rnd.Next(1, 20);
                        if (Losowanie == 3 || Losowanie == 9)
                        {
                            tab_mapa[i + k, l] = (int)fire.RightBonusBomb;
                        }
                        if (Losowanie == 4 || Losowanie == 10)
                        {
                            tab_mapa[i + k, l] = (int)fire.RightBonusPower;
                        }
                        if (Losowanie == 5)
                        {
                            tab_mapa[i + k, l] = (int)fire.RightPunishPB;
                        }
                        if (Losowanie == 6)
                        {
                            tab_mapa[i + k, l] = (int)fire.RightPunishSides;
                        }
                        if (Losowanie != 3 && Losowanie != 4 && Losowanie != 5 && Losowanie != 6 && Losowanie != 9 && Losowanie != 10)
                        {
                            tab_mapa[i + k, l] = (int)fire.Right;
                        }
                        // postawionych_bomb--;
                        break;
                    }
                    if (tab_mapa[i + k, l] == (int)brick.Unbreakable)
                    {
                        // postawionych_bomb--;
                        break;
                    }
                    if (tab_mapa[i + k, l] >= Gracz1.idBomb && tab_mapa[i + k, l] <= (Gracz1.idBomb + Gracz1.timerBomby))
                    {
                        tab_mapa[i + k, l] = (int)fire.Middle;
                        //postawionych_bomb--;
                        Logika_Bomba_Wybuchv2(i + k, l, Gracz1, Gracz2);
                        break;
                    }
                    if (tab_mapa[i + k, l] >= Gracz2.idBomb && tab_mapa[i + k, l] <= (Gracz2.idBomb + Gracz2.timerBomby))
                    {
                        tab_mapa[i + k, l] = (int)fire.Middle;
                        //postawionych_bomb--;
                        Logika_Bomba_Wybuchv2(i + k, l, Gracz2, Gracz1);
                        break;
                    }
                    if (tab_mapa[i + k, l] != (int)fire.Middle)
                    {
                        tab_mapa[i + k, l] = (int)fire.Poziom;
                    }

                }
            }
            for (int k = 1; k <= Gracz1.moc; k++)
            {
                if (i - k >= 0)
                {
                    Logika_Smierc(i - k, l, Gracz1);
                    Logika_Smierc(i -k, l, Gracz2);
                   /* if (Gracz1.zyje == false)
                    {
                        break;
                    }*/
                    if (tab_mapa[i - k, l] == (int)brick.Breakable)
                    {
                        Losowanie = rnd.Next(1, 20);
                        if (Losowanie == 3 || Losowanie == 9)
                        {
                            tab_mapa[i - k, l] = (int)fire.LeftBonusBomb;
                        }
                        if (Losowanie == 4 || Losowanie == 10)
                        {
                            tab_mapa[i - k, l] = (int)fire.LeftBonusPower;
                        }
                        if (Losowanie == 5)
                        {
                            tab_mapa[i - k, l] = (int)fire.LeftPunishPB;
                        }
                        if (Losowanie == 6)
                        {
                            tab_mapa[i - k, l] = (int)fire.LeftBonusBomb;
                        }
                        if (Losowanie != 3 && Losowanie != 4 && Losowanie != 5 && Losowanie != 6 && Losowanie != 9 && Losowanie != 10)
                        {
                            tab_mapa[i - k, l] = (int)fire.Left;
                        }
                        break;
                    }
                    if (tab_mapa[i - k, l] == (int)brick.Unbreakable)
                    {
                        break;
                    }
                    if (tab_mapa[i - k, l] >= Gracz1.idBomb && tab_mapa[i - k, l] <= (Gracz1.idBomb + Gracz1.timerBomby))
                    {
                        tab_mapa[i - k, l] = (int)fire.Middle;
                        Logika_Bomba_Wybuchv2(i - k, l, Gracz1, Gracz2);
                        break;
                    }
                    if (tab_mapa[i - k, l] >= Gracz2.idBomb && tab_mapa[i - k, l] <= (Gracz2.idBomb + Gracz2.timerBomby))
                    {
                        tab_mapa[i - k, l] = (int)fire.Middle;
                        Logika_Bomba_Wybuchv2(i - k, l, Gracz2, Gracz1);
                        break;
                    }
                    if (tab_mapa[i - k, l] != (int)fire.Middle)
                    {
                        tab_mapa[i - k, l] = (int)fire.Poziom;
                    }
                }
            }
            for (int k = 1; k <= Gracz1.moc; k++)
            {
                if (l + k <= 10)
                {
                    Logika_Smierc(i, l + k, Gracz1);
                    Logika_Smierc(i, l+k, Gracz2);
                  /*  if (Gracz1.zyje == false)
                    {
                        break;
                    }*/
                    if (tab_mapa[i, l + k] == (int)brick.Breakable)
                    {
                        Losowanie = rnd.Next(1, 10);
                        if (Losowanie == 3 || Losowanie == 9)
                        {
                            tab_mapa[i, l + k] = (int)fire.DownBonusBomb;
                        }
                        if (Losowanie == 4 || Losowanie == 10)
                        {
                            tab_mapa[i, l + k] = (int)fire.DownBonusPower;
                        }
                        if (Losowanie == 5)
                        {
                            tab_mapa[i, l + k] = (int)fire.DownPunishPB;
                        }
                        if (Losowanie == 6)
                        {
                            tab_mapa[i, l + k] = (int)fire.DownPunishSides;
                        }
                        if (Losowanie != 3 && Losowanie != 4 && Losowanie != 5 && Losowanie != 6 && Losowanie != 9 && Losowanie != 10)
                        {
                            tab_mapa[i, l + k] = (int)fire.Down;
                        }
                        break;
                    }
                    if (tab_mapa[i, l + k] == (int)brick.Unbreakable)
                    {
                        break;
                    }
                    if (tab_mapa[i, l + k] >= Gracz1.idBomb && tab_mapa[i, l + k] <= (Gracz1.idBomb + Gracz1.timerBomby))
                    {
                        tab_mapa[i, l + k] = (int)fire.Middle;
                        Logika_Bomba_Wybuchv2(i, l + k, Gracz1, Gracz2);
                        break;
                    }
                    if (tab_mapa[i, l + k] >= Gracz2.idBomb && tab_mapa[i, l + k] <= (Gracz2.idBomb + Gracz2.timerBomby))
                    {
                        tab_mapa[i, l + k] = (int)fire.Middle;
                        Logika_Bomba_Wybuchv2(i, l + k, Gracz2, Gracz1);
                        break;
                    }
                    if (tab_mapa[i, l + k] != (int)fire.Middle)
                    {
                        tab_mapa[i, l + k] = (int)fire.Pion;
                    }
                }
            }
            for (int k = 1; k <= Gracz1.moc; k++)
            {
                if (l - k >= 0)
                {
                    Logika_Smierc(i, l - k, Gracz1);
                    Logika_Smierc(i, l-k, Gracz2);
                   /* if (Gracz1.zyje == false)
                    {
                        break;
                    }*/
                    if (tab_mapa[i, l - k] == (int)brick.Breakable)
                    {                                       //BONUSY POJAWIANIE SIE ------------------------------------------------------
                        Losowanie = rnd.Next(1, 10);
                        if (Losowanie == 3 || Losowanie == 9)
                        {
                            tab_mapa[i, l - k] = (int)fire.UpBonusBomb;
                        }
                        if (Losowanie == 4 || Losowanie == 10)
                        {
                            tab_mapa[i, l - k] = (int)fire.UpBonusPower;
                        }
                        if (Losowanie == 5)
                        {
                            tab_mapa[i, l - k] = (int)fire.DownPunishPB;
                        }
                        if (Losowanie == 6)
                        {
                            tab_mapa[i, l - k] = (int)fire.DownPunishSides;
                        }
                        if (Losowanie != 3 && Losowanie != 4 && Losowanie != 5 && Losowanie != 6 && Losowanie != 9 && Losowanie != 10)
                        {
                            tab_mapa[i, l - k] = (int)fire.Down;
                        }
                        break;
                    }
                    if (tab_mapa[i, l - k] == (int)brick.Unbreakable)
                    {
                        break;
                    }
                    if (tab_mapa[i, l - k] >= Gracz1.idBomb && tab_mapa[i, l - k] <= (Gracz1.idBomb + Gracz1.timerBomby))
                    {
                        tab_mapa[i, l - k] = (int)fire.Middle;
                        Logika_Bomba_Wybuchv2(i, l - k, Gracz1, Gracz2);
                        break;
                    }
                    if (tab_mapa[i, l - k] >= Gracz2.idBomb && tab_mapa[i, l - k] <= (Gracz2.idBomb + Gracz2.timerBomby))
                    {
                        tab_mapa[i, l - k] = (int)fire.Middle;
                        Logika_Bomba_Wybuchv2(i, l - k, Gracz2, Gracz1);
                        break;
                    }
                    if (tab_mapa[i, l - k] != (int)fire.Middle)
                    {
                        tab_mapa[i, l - k] = (int)fire.Pion;
                    }
                }
            }
            Gracz1.postawionychBomb--;
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
                         if (tab_mapa[i, l] == (int)fire.Right || tab_mapa[i, l] == (int)fire.Left || tab_mapa[i, l] == (int)fire.Down || tab_mapa[i, l] == (int)fire.Up || tab_mapa[i, l] == (int)fire.RightBonusBomb || tab_mapa[i, l] == (int)fire.RightBonusPower || tab_mapa[i, l] == (int)fire.LeftBonusBomb || tab_mapa[i, l] == (int)fire.LeftBonusPower || tab_mapa[i, l] == (int)fire.DownBonusBomb || tab_mapa[i, l] == (int)fire.DownBonusPower || tab_mapa[i, l] == (int)fire.UpBonusBomb || tab_mapa[i, l] == (int)fire.UpBonusPower || tab_mapa[i, l] == (int)fire.Middle || tab_mapa[i, l] == (int)fire.Poziom || tab_mapa[i, l] == (int)fire.Pion || tab_mapa[i, l] == (int)fire.LeftPunishPB || tab_mapa[i, l] == (int)fire.LeftPunishSides || tab_mapa[i, l] == (int)fire.RightPunishPB || tab_mapa[i, l] == (int)fire.RightPunishSides || tab_mapa[i, l] == (int)fire.UpPunishPB || tab_mapa[i, l] == (int)fire.UpPunishSides || tab_mapa[i, l] == (int)fire.DownPunishPB || tab_mapa[i, l] == (int)fire.DownPunishSides)
                         {
                               Gracz1.zyje = false;
                               lost.Play();
                         }
                }
            }
        }
        public void Sprawdz_Bonus(Player Gracz1,Player Gracz2,int Licznik_Bonusu)
        {          
            int u = (int)((Gracz1.Position.Y - 20) / 50);
            int j = (int)((Gracz1.Position.X - 250) / 50);   
            if (tab_mapa[j,u] == (int)bonus.Bomb)
            {
                if (Gracz1.maxBomb + 1 <= 13)
                {
                    Gracz1.maxBomb++;
                }
                tab_mapa[j, u] = 0;
               Bonus.Play();
            }
            if (tab_mapa[j, u] == (int)bonus.Power)
            {
                if (Gracz1.moc + 1 <= 13)
                {
                    Gracz1.moc++;
                }
                tab_mapa[j, u] = 0;
               Bonus.Play();
            }
            if (tab_mapa[j, u] == (int)bonus.PunishBP)
            {
                if (Gracz1.maxBomb - 1 > 0)
                {
                    Gracz1.maxBomb--;
                }
                if (Gracz1.moc - 1 > 0)
                {
                    Gracz1.moc--;
                }
                 tab_mapa[j, u] = 0;
                 Czacha.Play();
            }
            if (tab_mapa[j, u] == (int)bonus.PunishSides)
            {
               tab_mapa[j, u] = 0;
               Gracz1.licznik_kary = 0;
               Gracz2.kara = true;
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
