using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BrickBlaster
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D Mapa;
        Texture2D Man_prawo;
        Texture2D Man_lewo;
        Texture2D Man_krok_prawo;
        Texture2D Man_krok_lewo;
        Texture2D Man_stoi;
        Texture2D Man_stoi_krok;
        Texture2D Man_stoi_krok2;
        Texture2D Man_gora;
        Texture2D Man_gora_krok;
        Texture2D Man_gora_krok2;
        Texture2D Man2_prawo;
        Texture2D Man2_lewo;
        Texture2D Man2_krok_prawo;
        Texture2D Man2_krok_lewo;
        Texture2D Man2_stoi;
        Texture2D Man2_stoi_krok;
        Texture2D Man2_stoi_krok2;
        Texture2D Man2_gora;
        Texture2D Man2_gora_krok;
        Texture2D Man2_gora_krok2;
        Texture2D Unbreakable;
        Texture2D Breakable;
        Texture2D Ogien;
        Texture2D Bomba;
        Texture2D Bonus_Max;
        Texture2D Bonus_Moc;
        Texture2D Bomba2;
        Texture2D Man_Dead;
        Texture2D Man2_Dead;
        Texture2D Przegrana;
        Texture2D Man_Almost_Died1;
        Texture2D Man_Almost_Died2;
        Texture2D Man2_Almost_Died1;
        Texture2D Man2_Almost_Died2;
        Texture2D Bonus_Speed;
        Texture2D Ogien_koniec_N;
        Texture2D Ogien_koniec_S;
        Texture2D Ogien_koniec_E;
        Texture2D Ogien_koniec_W;
        Texture2D Ogien_srodek;
        Texture2D Ogien_pion;
        Texture2D Ogien_poziom;
        Texture2D Kara;
        Texture2D Power_Bar;
        Texture2D Power_Bar_Icon;
        Texture2D Power_Bar_Icon2;
        Texture2D Bar_blue;
        Texture2D Bar_yellow;
        Texture2D Bar_red;
        Texture2D Player1;
        Texture2D Player2;
        Texture2D Player1win;
        Texture2D Player2win;
        Texture2D remis;
        Vector2 Pozycja_g1 = new Vector2(275, 55);
        Vector2 Pozycja_g2 = new Vector2(875, 555);
        Player Gracz1 = new Player(1300);
        Player Gracz2 = new Player(2300);
        Vector2 Position = new Vector2(275, 55);
        Mapa Mapa1 = new Mapa();
        Kontroler Klawiatura1 = new Kontroler();
        enum Stan {Gra,Reset1,Reset2,Reset3,Remis,Przegrana1,Przegrana2};
        KeyboardState keyboardState;
        public int licznik_klatek = 0;
        int zamiana = 0;
        Stan GameState = Stan.Gra;
        SoundEffect muzyka;
        SoundEffect remis_sound;
        SoundEffect p1w_sound;
        SoundEffect p2w_sound;
        SoundEffectInstance muzykainstancja;
        int Zamiana;
        void Load_Player_Graphic()
        {
            Man_prawo = Content.Load<Texture2D>("bomber_prawo_stoi");
            Man_lewo = Content.Load<Texture2D>("bomber_lewo_stoi");
            Man_krok_prawo = Content.Load<Texture2D>("krok_prawo");
            Man_krok_lewo = Content.Load<Texture2D>("krok_lewo");
            Man_stoi = Content.Load<Texture2D>("man_stoi");
            Man_stoi_krok = Content.Load<Texture2D>("man_stoi_krok");
            Man_stoi_krok2 = Content.Load<Texture2D>("man_stoi_krok2");
            Man_gora = Content.Load<Texture2D>("man_gora");
            Man_gora_krok = Content.Load<Texture2D>("Man_gora_krok");
            Man_gora_krok2 = Content.Load<Texture2D>("Man_gora_krok2");
            Man2_prawo = Content.Load<Texture2D>("bomber2_prawo_stoi");
            Man2_lewo = Content.Load<Texture2D>("bomber2_lewo_stoi");
            Man2_krok_prawo = Content.Load<Texture2D>("krok2_prawo");
            Man2_krok_lewo = Content.Load<Texture2D>("krok2_lewo");
            Man2_stoi = Content.Load<Texture2D>("man2_stoi");
            Man2_stoi_krok = Content.Load<Texture2D>("man2_stoi_krok");
            Man2_stoi_krok2 = Content.Load<Texture2D>("man2_stoi_krok2");
            Man2_gora = Content.Load<Texture2D>("man2_gora");
            Man2_gora_krok = Content.Load<Texture2D>("Man2_gora_krok");
            Man2_gora_krok2 = Content.Load<Texture2D>("Man2_gora_krok2");
            Man_Dead = Content.Load<Texture2D>("Dead");
            Man_Almost_Died1 = Content.Load<Texture2D>("Dead_swiatlo1");
            Man_Almost_Died2 = Content.Load<Texture2D>("Dead_swiatlo2");
            Man2_Dead = Content.Load<Texture2D>("Dead2");
            Man2_Almost_Died1 = Content.Load<Texture2D>("Dead2_swiatlo1");
            Man2_Almost_Died2 = Content.Load<Texture2D>("Dead2_swiatlo2");
        }
        void Load_Map_Objects_Graphic()
        {
            Mapa = Content.Load<Texture2D>("Wzor_mapy_trawa_mur_otoczenie_gotowa");
            Unbreakable = Content.Load<Texture2D>("unbreak");
            Breakable = Content.Load<Texture2D>("kocek_do_niszczenia");
            Bomba = Content.Load<Texture2D>("Bomba_new");
            Bomba2 = Content.Load<Texture2D>("Bomba_new_2");
            Bonus_Moc = Content.Load<Texture2D>("Bonus_Moc");
            Bonus_Speed = Content.Load<Texture2D>("Bonus_Speed");
            Kara = Content.Load<Texture2D>("Bonus_Czaszka");
            Bonus_Max = Content.Load<Texture2D>("Bonus_Max");
            Player1win = Content.Load<Texture2D>("p1w");
            Player2win = Content.Load<Texture2D>("p2w");
            remis = Content.Load<Texture2D>("remis");
            Ogien_koniec_N = Content.Load<Texture2D>("ogien_koniec_N");
            Ogien_koniec_S =Content.Load<Texture2D>("ogien_koniec_S");
            Ogien_koniec_E =Content.Load<Texture2D>("ogien_koniec_E");
            Ogien_koniec_W =Content.Load<Texture2D>("ogien_koniec_W");
            Ogien_srodek = Content.Load<Texture2D>("ogien_srodek");
            Ogien_pion =Content.Load<Texture2D>("ogien_pion");
            Ogien_poziom = Content.Load<Texture2D>("ogien_poziom");            
        }
        void Load_Interface_Graphic()
        {
            Power_Bar = Content.Load<Texture2D>("Power_Bar");
            Power_Bar_Icon = Content.Load<Texture2D>("Power_bar_icon");
            Power_Bar_Icon2= Content.Load<Texture2D>("Power_bar_icon2");
            Bar_blue = Content.Load<Texture2D>("Bar_blue");
            Bar_yellow = Content.Load<Texture2D>("Bar_yellow");
            Bar_red = Content.Load<Texture2D>("Bar_red");
            Player1 = Content.Load<Texture2D>("Player1");
            Player2 = Content.Load<Texture2D>("Player2");
        }
        void Load_Sounds()
        {
            Mapa1.wybuch = Content.Load<SoundEffect>("wybuch");
            Mapa1.lost = Content.Load<SoundEffect>("lost");
            Mapa1.Bonus = Content.Load<SoundEffect>("bonus");
            muzyka = Content.Load<SoundEffect>("muzyka");
            remis_sound = Content.Load<SoundEffect>("remis_sound");
            p1w_sound = Content.Load<SoundEffect>("player1wins");
            p2w_sound = Content.Load<SoundEffect>("player2wins");
            Mapa1.Czacha = Content.Load<SoundEffect>("czaszka");
            muzykainstancja = muzyka.CreateInstance();
        }
        public int ZamianaUstaw()
        {
            if (licznik_klatek % 10 == 0)
            {
                if (zamiana == 0)
                {
                    zamiana = 1;
                }
                else
                {
                    if (zamiana == 1)
                    {
                        zamiana = 2;
                    }
                    else
                    {
                        if (zamiana == 2)
                        {
                            zamiana = 3;
                        }
                        else
                        {
                            if (zamiana == 3)
                            {
                                zamiana = 0;
                            }
                        }
                    }
                }
            }
            return zamiana;
        }
        public void Grafika_Poruszanie2(Player Gracz1, bool[] tab,int zamiana)
        {
            
            if ((tab[3] == false && tab[2] == false && tab[0] == false) && tab[1] == false || (tab[1] == true && tab[2] == true) || (tab[0] == true && tab[1] == true))
            {
                spriteBatch.Draw(Man_stoi, Gracz1.Position, Color.White);
            }
            else
            {
                if (tab[3] == true)
                {
                    if (zamiana == 0 || zamiana == 2)
                    {
                        spriteBatch.Draw(Man_krok_prawo, Gracz1.Position, Color.White);
                    }
                    if (zamiana == 1 || zamiana == 3)
                    {
                        spriteBatch.Draw(Man_prawo, Gracz1.Position, Color.White);
                    }
                }
                else
                {
                    if (tab[2] == true)
                    {
                        if (zamiana == 0 || zamiana == 2)
                        {
                            spriteBatch.Draw(Man_lewo, Gracz1.Position, Color.White);
                        }

                        if (zamiana == 1 || zamiana == 3)
                        {
                            spriteBatch.Draw(Man_krok_lewo, Gracz1.Position, Color.White);
                        }
                        if (zamiana == 3)
                        {
                        }
                    }
                    if (tab[0] == true)
                    {
                        if (zamiana == 0 || zamiana == 2)
                        {
                            spriteBatch.Draw(Man_gora, Gracz1.Position, Color.White);
                        }
                        if (zamiana == 1)
                        {
                            spriteBatch.Draw(Man_gora_krok, Gracz1.Position, Color.White);
                        }
                        if (zamiana == 3)
                        {
                            spriteBatch.Draw(Man_gora_krok2, Gracz1.Position, Color.White);
                        }
                    }
                    if (tab[0] == true && Gracz1.Position.X == 275)
                    {
                        if (zamiana == 0 || zamiana == 2)
                        {
                            spriteBatch.Draw(Man_gora, Gracz1.Position, Color.White);
                        }
                        if (zamiana == 1)
                        {
                            spriteBatch.Draw(Man_gora_krok, Gracz1.Position, Color.White);
                        }
                        if (zamiana == 3)
                        {
                            spriteBatch.Draw(Man_gora_krok2, Gracz1.Position, Color.White);
                        }
                    }
                    else
                    {
                        if (tab[1] == true /*&& Gracz1.Position.Y == 50 + 75*/)
                        {
                            if (Gracz1.zyje == true)
                            {
                                if (zamiana == 0 || zamiana == 2)
                                {
                                    spriteBatch.Draw(Man_stoi, Gracz1.Position, Color.White);
                                }
                                if (zamiana == 1)
                                {
                                    spriteBatch.Draw(Man_stoi_krok, Gracz1.Position, Color.White);
                                }
                                if (zamiana == 3)
                                {
                                    spriteBatch.Draw(Man_stoi_krok2, Gracz1.Position, Color.White);
                                }
                            }
                            else
                            {
                                spriteBatch.Draw(Man_Dead, Gracz1.Position, Color.White);
                            }
                        }
                    }
                }

            }
        }
        public void Grafika_Poruszanie2_Player2(Player Gracz2, bool[] tab,int zamiana)
        {        
            if ((tab[3] == false && tab[2] == false && tab[0] == false) && tab[1] == false || (tab[1] == true && tab[2] == true) || (tab[0] == true && tab[1] == true))
            {
                spriteBatch.Draw(Man2_stoi, Gracz2.Position, Color.White);
            }
            else
            {
                if (tab[3] == true)
                {
                    if (zamiana == 0 || zamiana == 2)
                    {
                        spriteBatch.Draw(Man2_krok_prawo, Gracz2.Position, Color.White);
                    }
                    if (zamiana == 1 || zamiana == 3)
                    {
                        spriteBatch.Draw(Man2_prawo, Gracz2.Position, Color.White);
                    }
                }
                else
                {
                    if (tab[2] == true)
                    {
                        if (zamiana == 0 || zamiana == 2)
                        {
                            spriteBatch.Draw(Man2_lewo, Gracz2.Position, Color.White);
                        }

                        if (zamiana == 1 || zamiana == 3)
                        {
                            spriteBatch.Draw(Man2_krok_lewo, Gracz2.Position, Color.White);
                        }
                        if (zamiana == 3)
                        {
                        }
                    }
                    if (tab[0] == true)
                    {
                        if (zamiana == 0 || zamiana == 2)
                        {
                            spriteBatch.Draw(Man2_gora, Gracz2.Position, Color.White);
                        }
                        if (zamiana == 1)
                        {
                            spriteBatch.Draw(Man2_gora_krok, Gracz2.Position, Color.White);
                        }
                        if (zamiana == 3)
                        {
                            spriteBatch.Draw(Man2_gora_krok2, Gracz2.Position, Color.White);
                        }
                    }
                    if (tab[0] == true && Gracz1.Position.X == 275)
                    {
                        if (zamiana == 0 || zamiana == 2)
                        {
                            spriteBatch.Draw(Man2_gora, Gracz2.Position, Color.White);
                        }
                        if (zamiana == 1)
                        {
                            spriteBatch.Draw(Man2_gora_krok, Gracz2.Position, Color.White);
                        }
                        if (zamiana == 3)
                        {
                            spriteBatch.Draw(Man2_gora_krok2, Gracz2.Position, Color.White);
                        }
                    }
                    else
                    {
                        if (tab[1] == true /*&& Gracz1.Position.Y == 50 + 75*/)
                        {
                            if (Gracz1.zyje == true)
                            {
                                if (zamiana == 0 || zamiana == 2)
                                {
                                    spriteBatch.Draw(Man2_stoi, Gracz2.Position, Color.White);
                                }
                                if (zamiana == 1)
                                {
                                    spriteBatch.Draw(Man2_stoi_krok, Gracz2.Position, Color.White);
                                }
                                if (zamiana == 3)
                                {
                                    spriteBatch.Draw(Man2_stoi_krok2, Gracz2.Position, Color.White);
                                }
                            }
                            else
                            {
                                spriteBatch.Draw(Man_Dead, Gracz2.Position, Color.White);
                            }
                        }
                    }
                }

            }
        }
        void Grafika_Ca�a()
        {
            spriteBatch.Draw(Mapa, new Vector2(0, 0), Color.White);
            for (int l = 0; l < 11; l++)
            {         
                //------------------------------------------------------------------------------------------Sprawdzanie zawartosci tabeli i rysowanie Obiekt�w -- ------------------------------------------------------------
                for (int i = 0; i < 13; i++)
                {
                    Sprawdzanie_pol_tabeli(i, l,Mapa1);
                }
                Zamiana = ZamianaUstaw();
                //------------------------------------------------------------------------------------------Grafika poruszania si� cd. : ----------------------------------------------------------------------------------------------
                //--------------------------------------------------------------------------------------------------------------------Grafika poruszania si� : Gracz1 ------------------------------------------------------------
                if (Gracz1.Position.Y > 62 + (l - 1) * 50)
                {
                    Grafika_Poruszanie2(Gracz1, Klawiatura1.Zwracanie(), Zamiana);
                }
                //--------------------------------------------------------------------------------------------------------------------Grafika poruszania si� : Gracz2 ------------------------------------------------------------                                   
                if (Gracz2.Position.Y > 62 + (l - 1) * 50)
                {
                    Grafika_Poruszanie2_Player2(Gracz2, Klawiatura1.Zwracanie2(), Zamiana);
                }
                    
            }
            Grafika_Interface();
            Grafika_Smierc();
            Reset_Gry();
        }
        void Grafika_Interface()
        {
            spriteBatch.Draw(Player1, new Vector2(75, 0), Color.White);
            spriteBatch.Draw(Power_Bar_Icon, new Vector2(4, 70), Color.White);
            spriteBatch.Draw(Power_Bar, new Vector2(35, 70), Color.White);
            for (int i = 1; i < Gracz1.moc; i++)
            {
                if (i < 4)
                    spriteBatch.Draw(Bar_blue, new Vector2(36 + (i * 12), 71), Color.White);
                if (i < 8 && i >= 4)
                    spriteBatch.Draw(Bar_yellow, new Vector2(36 + (i * 12), 71), Color.White);
                if (i >= 8)
                    spriteBatch.Draw(Bar_red, new Vector2(36 + (i * 12), 71), Color.White);

            }
            spriteBatch.Draw(Power_Bar_Icon2, new Vector2(4, 103), Color.White);
            spriteBatch.Draw(Power_Bar, new Vector2(35, 103), Color.White);
            for (int i = 1; i < Gracz1.maxBomb; i++)
            {
                if (i < 4)
                    spriteBatch.Draw(Bar_blue, new Vector2(36 + (i * 12), 104), Color.White);
                if (i < 8 && i >= 4)
                    spriteBatch.Draw(Bar_yellow, new Vector2(36 + (i * 12), 104), Color.White);
                if (i >= 8)
                    spriteBatch.Draw(Bar_red, new Vector2(36 + (i * 12), 104), Color.White);
            }

            spriteBatch.Draw(Player2, new Vector2(75, 200), Color.White);
            spriteBatch.Draw(Power_Bar_Icon, new Vector2(4, 270), Color.White);
            spriteBatch.Draw(Power_Bar, new Vector2(35, 270), Color.White);
            for (int i = 1; i < Gracz2.moc; i++)
            {
                if (i < 4)
                    spriteBatch.Draw(Bar_blue, new Vector2(36 + (i * 12), 271), Color.White);
                if (i < 8 && i >= 4)
                    spriteBatch.Draw(Bar_yellow, new Vector2(36 + (i * 12), 271), Color.White);
                if (i >= 8)
                    spriteBatch.Draw(Bar_red, new Vector2(36 + (i * 12), 271), Color.White);

            }
            spriteBatch.Draw(Power_Bar_Icon2, new Vector2(4, 303), Color.White);
            spriteBatch.Draw(Power_Bar, new Vector2(35, 303), Color.White);
            for (int i = 1; i < Gracz2.maxBomb; i++)
            {
                if (i < 4)
                    spriteBatch.Draw(Bar_blue, new Vector2(36 + (i * 12), 304), Color.White);
                if (i < 8 && i >= 4)
                    spriteBatch.Draw(Bar_yellow, new Vector2(36 + (i * 12), 304), Color.White);
                if (i >= 8)
                    spriteBatch.Draw(Bar_red, new Vector2(36 + (i * 12), 304), Color.White);
            }
        }
        void Grafika_Smierc()
        {
            if ((Gracz1.zyje == false && GameState == Stan.Gra) && (Gracz2.zyje == true && GameState == Stan.Gra))
            {
                if (licznik_klatek % 13 == 0)
                {
                    Man_stoi = Content.Load<Texture2D>("Dead_swiatlo1");
                }
                if (licznik_klatek % 17 == 0)
                {
                    Man_stoi = Content.Load<Texture2D>("Dead_swiatlo2");
                }
                if (licznik_klatek % 23 == 0)
                {
                    GameState = Stan.Przegrana1;
                }
            }
            if (GameState == Stan.Przegrana1)
            {
                Man_prawo = Content.Load<Texture2D>("Dead");
                Man_lewo = Content.Load<Texture2D>("Dead");
                Man_krok_prawo = Content.Load<Texture2D>("Dead");
                Man_krok_lewo = Content.Load<Texture2D>("Dead");
                Man_gora = Content.Load<Texture2D>("Dead");
                Man_stoi = Content.Load<Texture2D>("Dead");
                Man_gora_krok = Content.Load<Texture2D>("Dead");
                Man_gora_krok2 = Content.Load<Texture2D>("Dead");
                spriteBatch.Draw(Player2win, new Vector2(200, 100), Color.White);
                p2w_sound.Play();
                GameState = Stan.Reset1;
            }
            if ((Gracz1.zyje == true && GameState == Stan.Gra) && (Gracz2.zyje == false && GameState == Stan.Gra))
            {
                if (licznik_klatek % 13 == 0)
                {                    
                    Man2_stoi = Content.Load<Texture2D>("Dead2_swiatlo1");
                }
                if (licznik_klatek % 17 == 0)
                {
                    Man2_stoi = Content.Load<Texture2D>("Dead2_swiatlo2");
                }
                if (licznik_klatek % 23 == 0)
                {
                    GameState = Stan.Przegrana2;
                }
            }
            if (GameState == Stan.Przegrana2)
            {
                Man2_prawo = Content.Load<Texture2D>("Dead2");
                Man2_lewo = Content.Load<Texture2D>("Dead2");
                Man2_krok_prawo = Content.Load<Texture2D>("Dead2");
                Man2_krok_lewo = Content.Load<Texture2D>("Dead2");
                Man2_gora = Content.Load<Texture2D>("Dead2");
                Man2_stoi = Content.Load<Texture2D>("Dead2");
                Man2_gora_krok = Content.Load<Texture2D>("Dead2");
                Man2_gora_krok2 = Content.Load<Texture2D>("Dead2");
                p1w_sound.Play();
                GameState = Stan.Reset2;         
            }

            if ((Gracz1.zyje == false && GameState == Stan.Gra) && (Gracz2.zyje == false && GameState == Stan.Gra))
            {
                if (licznik_klatek % 13 == 0)
                {
                    Man_stoi = Content.Load<Texture2D>("Dead_swiatlo1");
                    Man2_stoi = Content.Load<Texture2D>("Dead2_swiatlo1");
                }
                if (licznik_klatek % 17 == 0)
                {
                    Man_stoi = Content.Load<Texture2D>("Dead_swiatlo2");
                    Man2_stoi = Content.Load<Texture2D>("Dead2_swiatlo2");
                }
                if (licznik_klatek % 23 == 0)
                {
                    GameState = Stan.Remis;
                }
            }
            if (GameState == Stan.Remis)
            {
                Man_prawo = Content.Load<Texture2D>("Dead");
                Man_lewo = Content.Load<Texture2D>("Dead");
                Man_krok_prawo = Content.Load<Texture2D>("Dead");
                Man_krok_lewo = Content.Load<Texture2D>("Dead");
                Man_gora = Content.Load<Texture2D>("Dead");
                Man_stoi = Content.Load<Texture2D>("Dead");
                Man_gora_krok = Content.Load<Texture2D>("Dead");
                Man_gora_krok2 = Content.Load<Texture2D>("Dead");
                Man2_prawo = Content.Load<Texture2D>("Dead2");
                Man2_lewo = Content.Load<Texture2D>("Dead2");
                Man2_krok_prawo = Content.Load<Texture2D>("Dead2");
                Man2_krok_lewo = Content.Load<Texture2D>("Dead2");
                Man2_gora = Content.Load<Texture2D>("Dead2");
                Man2_stoi = Content.Load<Texture2D>("Dead2");
                Man2_gora_krok = Content.Load<Texture2D>("Dead2");
                Man2_gora_krok2 = Content.Load<Texture2D>("Dead2");
                remis_sound.Play();
                GameState = Stan.Reset3;
            }
        }
        void Reset_Gry()
        {
            bool reset = false;
            if (GameState == Stan.Reset1)
            {
                spriteBatch.Draw(Player2win, new Vector2(400, 100), Color.White);
                reset = true;
            }
            if (GameState == Stan.Reset2)
            {
                spriteBatch.Draw(Player1win, new Vector2(400, 100), Color.White);
                reset = true;
            }
            if (GameState == Stan.Reset3)
            {
                spriteBatch.Draw(remis, new Vector2(400, 100), Color.White);
                reset = true;
            }
            if (reset == true)
            {
                if (keyboardState.IsKeyDown(Keys.R))
                {
                    Man_prawo = Content.Load<Texture2D>("bomber_prawo_stoi");
                    Man_lewo = Content.Load<Texture2D>("bomber_lewo_stoi");
                    Man_krok_prawo = Content.Load<Texture2D>("krok_prawo");
                    Man_krok_lewo = Content.Load<Texture2D>("krok_lewo");
                    Man_stoi = Content.Load<Texture2D>("man_stoi");
                    Man_stoi_krok = Content.Load<Texture2D>("man_stoi_krok");
                    Man_gora = Content.Load<Texture2D>("man_gora");
                    Man_gora_krok = Content.Load<Texture2D>("Man_gora_krok");
                    Man_gora_krok2 = Content.Load<Texture2D>("Man_gora_krok2");
                    Man2_prawo = Content.Load<Texture2D>("bomber2_prawo_stoi");
                    Man2_lewo = Content.Load<Texture2D>("bomber2_lewo_stoi");
                    Man2_krok_prawo = Content.Load<Texture2D>("krok2_prawo");
                    Man2_krok_lewo = Content.Load<Texture2D>("krok2_lewo");
                    Man2_stoi = Content.Load<Texture2D>("man2_stoi");
                    Man2_stoi_krok = Content.Load<Texture2D>("man2_stoi_krok");
                    Man2_gora = Content.Load<Texture2D>("man2_gora");
                    Man2_gora_krok = Content.Load<Texture2D>("Man2_gora_krok");
                    Man2_gora_krok2 = Content.Load<Texture2D>("Man2_gora_krok2");
                    Mapa1.Stawianie_klockow();
                    Gracz1.postawionychBomb = 0;
                    Gracz1.maxBomb = 2;
                    Gracz1.szybko�� = 2;
                    Gracz1.moc = 3;
                    Gracz1.kara = false;
                    Gracz1.Position = new Vector2(275, 55);
                    Gracz1.zyje = true;
                    Gracz2.postawionychBomb = 0;
                    Gracz2.Position = new Vector2(900, 630);
                    Gracz2.zyje = true;
                    Gracz2.kara = false;
                    GameState = Stan.Gra;
                }
            }
        }   
        void Sprawdzanie_pol_tabeli(int i, int l,Mapa Mapa)
        {
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.brick.Unbreakable)
            {
                spriteBatch.Draw(Unbreakable, new Vector2(275 + (i * 50), 62 + (l * 50)), Color.White);
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.brick.Breakable)
            {
                spriteBatch.Draw(Breakable, new Vector2(275 + (i * 50), 62 + (l * 50)), Color.White);
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.Right)
            {
                spriteBatch.Draw(Ogien_koniec_E, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Right;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.Left)
            {
                spriteBatch.Draw(Ogien_koniec_W, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Left;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.Down)
            {
                spriteBatch.Draw(Ogien_koniec_S, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Down;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.Up)
            {
                spriteBatch.Draw(Ogien_koniec_N, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Up;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.RightBonusBomb)
            {
                spriteBatch.Draw(Ogien_koniec_E, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Right;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.RightBonusPower)
            {
                spriteBatch.Draw(Ogien_koniec_E, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Right;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.RightPunishPB)
            {
                spriteBatch.Draw(Ogien_koniec_E, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Right;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.RightPunishSides)
            {
                spriteBatch.Draw(Ogien_koniec_E, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Right;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.LeftBonusBomb)
            {
                spriteBatch.Draw(Ogien_koniec_W, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Left;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.LeftBonusPower)
            {
                spriteBatch.Draw(Ogien_koniec_W, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Left;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.LeftPunishPB)
            {
                spriteBatch.Draw(Ogien_koniec_W, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Left;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.LeftPunishSides)
            {
                spriteBatch.Draw(Ogien_koniec_W, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Left;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.DownBonusBomb)
            {
                spriteBatch.Draw(Ogien_koniec_S, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Down;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.DownBonusPower)
            {
                spriteBatch.Draw(Ogien_koniec_S, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Down;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.DownPunishPB)
            {
                spriteBatch.Draw(Ogien_koniec_S, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Down;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.DownPunishSides)
            {
                spriteBatch.Draw(Ogien_koniec_S, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Down;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.UpBonusBomb)
            {
                spriteBatch.Draw(Ogien_koniec_N, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Up;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.UpBonusPower)
            {
                spriteBatch.Draw(Ogien_koniec_N, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Up;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.UpPunishPB) 
            {
                spriteBatch.Draw(Ogien_koniec_N, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Up;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.UpPunishSides)
            {
                spriteBatch.Draw(Ogien_koniec_N, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Up;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.Middle)
            {
                spriteBatch.Draw(Ogien_srodek, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Middle;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.Poziom)
            {

                spriteBatch.Draw(Ogien_poziom, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Poziom;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.Pion)
            {

                spriteBatch.Draw(Ogien_pion, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Pion;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.bonus.Bomb)
            {
                spriteBatch.Draw(Bonus_Max, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.bonus.Power)
            {
                spriteBatch.Draw(Bonus_Moc, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.bonus.PunishBP)
            {
                spriteBatch.Draw(Kara, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.bonus.PunishSides)
            {
                spriteBatch.Draw(Kara, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
            }
            if (Mapa1.tab_mapa[i, l] >= Gracz1.idBomb && Mapa1.tab_mapa[i, l] < (Gracz1.idBomb + Gracz1.timerBomby))
            {
                if (zamiana == 0 || zamiana == 2)
                {
                    spriteBatch.Draw(Bomba, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                }
                if (zamiana == 1 || zamiana == 3)
                {
                    spriteBatch.Draw(Bomba2, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                }
            }
            if (Mapa1.tab_mapa[i, l] >= Gracz2.idBomb && Mapa1.tab_mapa[i, l] < (Gracz2.idBomb + Gracz2.timerBomby))
            {
                if (zamiana == 0 || zamiana == 2)
                {
                    spriteBatch.Draw(Bomba, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                }
                if (zamiana == 1 || zamiana == 3)
                {
                    spriteBatch.Draw(Bomba2, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                }
            }
        }
        void Logika_Gry()
        {
            //-------------------------------------------------------------------------------------------------------  Poruszanie sie :------------------------------------------------------------------------------------------------
            //------------------------------------------------------------------------------------------------------------------------poruszanie sie: Gracz1 -------------------------------------------------------------------------
            Gracz1.Player_Poruszanie(Klawiatura1.Zwracanie());
            if (Gracz1.Position.Y > graphics.PreferredBackBufferHeight - (Man_prawo.Height + 65))
            {
                Gracz1.Position.Y = graphics.PreferredBackBufferHeight - (Man_prawo.Height + 65);
            }
            if (Gracz1.Position.X < 275)
            {
                Gracz1.Position.X = 275;
            }
            if (Gracz1.Position.X > graphics.PreferredBackBufferWidth - (Man_prawo.Width + 75))
            {
                Gracz1.Position.X = graphics.PreferredBackBufferWidth - (Man_prawo.Width + 75);
            }
            Mapa1.Sprawdz_Bonus(Gracz1,licznik_klatek);
            //------------------------------------------------------------------------------------------------------------------------poruszanie sie: Gracz1 ------------------------------------------------------------------------
           Gracz2.Player_Poruszanie(Klawiatura1.Zwracanie2());
             if (Gracz2.Position.Y > graphics.PreferredBackBufferHeight - (Man_prawo.Height + 65))
             {
                 Gracz2.Position.Y = graphics.PreferredBackBufferHeight - (Man_prawo.Height + 65);
             }
             if (Gracz2.Position.X < 275)
             {
                 Gracz2.Position.X = 275;
             }
             if (Gracz2.Position.X > graphics.PreferredBackBufferWidth - (Man_prawo.Width + 75))
             {
                 Gracz2.Position.X = graphics.PreferredBackBufferWidth - (Man_prawo.Width + 75);
             }
            Mapa1.Sprawdz_Bonus(Gracz2,licznik_klatek); 
            //----------------------------------------------------------------------------------------------------------------Mechanika Bomby: ----------------------------------------------------------------------------------
            //----------------------------------------------------------------------------------------------------------------------------------Mechanika Bomby: Gracz1 ---------------------------------------------------------
            Gracz1.Zwieksz_liczbe_bomb_postawionych(Mapa1.stawianie_bomby(Gracz1.Logika_Bomba_stawianie(Klawiatura1.Zwracanie()), Gracz1,Gracz2));
            Mapa1.Logika_bomba(licznik_klatek, Gracz1,Gracz2);
            //----------------------------------------------------------------------------------------------------------------------------------Mechanika Bomby: Gracz2 ---------------------------------------------------------
            Gracz2.Zwieksz_liczbe_bomb_postawionych(Mapa1.stawianie_bomby(Gracz2.Logika_Bomba_stawianie(Klawiatura1.Zwracanie2()),Gracz2, Gracz1));   
            Mapa1.Logika_bomba(licznik_klatek, Gracz2,Gracz1);
            //----------------------------------------------------------------------------------------------------------------Kolizje : -----------------------------------------------------------------------------------------------
            //-------------------------------------------------------------------------------------------------------------------------Kolizje :  Gracz1 -----------------------------------------------------------------------------
            Gracz1.Aktualizuj_Pozycje(Mapa1.kolizje(Gracz1.Position, Klawiatura1.Zwracanie(),Gracz1.kara));
            //-------------------------------------------------------------------------------------------------------------------------Kolizje :  Gracz2 -----------------------------------------------------------------------------
            Gracz2.Aktualizuj_Pozycje(Mapa1.kolizje(Gracz2.Position, Klawiatura1.Zwracanie2(),Gracz2.kara));     
            Mapa1.Smierc_delay(Gracz1);
            Mapa1.Smierc_delay(Gracz2);
        }
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 700;
            graphics.PreferredBackBufferWidth = 1000;
        }    
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here 
            Gracz1.Position = new Vector2(275, 55);
            Gracz2.Position = new Vector2(900, 630);
            Mapa1.Stawianie_klockow();
            base.Initialize();
        }
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Load_Interface_Graphic();
            Load_Player_Graphic();
            Load_Map_Objects_Graphic();
            Load_Sounds();
        }
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit(); 
            keyboardState = Keyboard.GetState();
            //-----------------------------------------------------------------------------------------------------Logika Gry-----------------------------------------------------------------------------------------------------
            if (Gracz1.zyje == true&& Gracz2.zyje==true)
            {
                if (muzykainstancja.State != SoundState.Playing)
                {
                    muzykainstancja.Play();
                }
                    Logika_Gry();
                }
            else { 
                    muzykainstancja.Stop(); 
                 }
             licznik_klatek++;          
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {      
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
                    //------------------------------------------------------------------------------------------------Mapa Grafika-------------------------------------------------------------------------------------------------------
            Grafika_Ca�a();
                    //---------------------------------------------------------------------------------------Licznik klatek uzywany do animacji ------------------------------------------------------------------------------
            if (licznik_klatek >= 60)
            {
                licznik_klatek = 0;
            }
            spriteBatch.End();         
            base.Draw(gameTime);
        }
    }
}
