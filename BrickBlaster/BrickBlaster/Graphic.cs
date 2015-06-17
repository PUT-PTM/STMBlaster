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
    class Graphic
    {
        #region -------------------------------------Objects---------------------------------------------------------
        GraphicsDeviceManager graphics;
        ContentManager Content;
        Mapa Mapa1;
        Menu Menu1;
        Player Gracz1;
        Player Gracz2;
        Kontroler Klawiatura1;
        KeyboardState keyboardState;
        #endregion
        #region  -------------------------------------Textures2D--------------------------------------------------------
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
        Texture2D Bomba;
        Texture2D Bonus_Max;
        Texture2D Bonus_Moc;
        Texture2D Bomba2;
        Texture2D Man_Dead;
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
        Texture2D menuPlay;
        Texture2D menuOptions;
        Texture2D menuExit;
        Texture2D menuCredits;
        Texture2D menuKeyboard;
        Texture2D menuKeyboard2;
        Texture2D menuSTM;
        Texture2D menuSTM2;
        Texture2D menuMusicON;
        Texture2D menuMusicON2;
        Texture2D menuMusicOFF;
        Texture2D menuMusicOFF2;
        Texture2D credits;
        Texture2D pause;
        Texture2D music_on;
        Texture2D music_off;
        Texture2D press_p;
        Texture2D press_o_resume;
        Texture2D press_esc;
        #endregion
        #region-------------------------------------Variables-------------------------------------------------------
        int zamiana = 0;
        int Zamiana;
        Game1.Stan GameState;
        #endregion
        #region -------------------------------------SoundEffects-declaration---------------------------------
        public SoundEffect muzyka;
        public SoundEffect muzyka_credits;
        public SoundEffect remis_sound;
        public  SoundEffect p1w_sound;
        public SoundEffect p2w_sound;
        public SoundEffectInstance muzykainstancja;
        #endregion
        public Graphic()
            {
            
        }
        public void PrzypiszReferencje(GraphicsDeviceManager graphics, ContentManager Content, Mapa Mapa1,Menu Menu1,Player Gracz1,Player Gracz2,Kontroler Klawiatura1,Game1.Stan GameState, KeyboardState keyboardState)
        {
            this.graphics = graphics;
            this.Content = Content;
            this.Mapa1 = Mapa1;
            this.Menu1 = Menu1;
            this.Gracz1 = Gracz1;
            this.Gracz2 = Gracz2;
            this.Klawiatura1 = Klawiatura1;
            this.GameState = GameState;
            this.keyboardState = keyboardState;
        }
        public void Load_Player_Graphic()
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
           // Man2_Dead = Content.Load<Texture2D>("Dead2");
            Man2_Almost_Died1 = Content.Load<Texture2D>("Dead2_swiatlo1");
            Man2_Almost_Died2 = Content.Load<Texture2D>("Dead2_swiatlo2");
        }
        public void Load_Map_Objects_Graphic()
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
            Ogien_koniec_S = Content.Load<Texture2D>("ogien_koniec_S");
            Ogien_koniec_E = Content.Load<Texture2D>("ogien_koniec_E");
            Ogien_koniec_W = Content.Load<Texture2D>("ogien_koniec_W");
            Ogien_srodek = Content.Load<Texture2D>("ogien_srodek");
            Ogien_pion = Content.Load<Texture2D>("ogien_pion");
            Ogien_poziom = Content.Load<Texture2D>("ogien_poziom");
        }
        public void Load_Interface_Graphic()
        {
            Power_Bar = Content.Load<Texture2D>("Power_Bar");
            Power_Bar_Icon = Content.Load<Texture2D>("Power_bar_icon");
            Power_Bar_Icon2 = Content.Load<Texture2D>("Power_bar_icon2");
            Bar_blue = Content.Load<Texture2D>("Bar_blue");
            Bar_yellow = Content.Load<Texture2D>("Bar_yellow");
            Bar_red = Content.Load<Texture2D>("Bar_red");
            Player1 = Content.Load<Texture2D>("Player1");
            Player2 = Content.Load<Texture2D>("Player2");
        }
        public void Load_Sounds()
        {
            Mapa1.wybuch = Content.Load<SoundEffect>("wybuch");
            Mapa1.lost = Content.Load<SoundEffect>("lost");
            Mapa1.Bonus = Content.Load<SoundEffect>("bonus");
            muzyka = Content.Load<SoundEffect>("muzyka");
            muzyka_credits = Content.Load<SoundEffect>("dyna_credits2");
            remis_sound = Content.Load<SoundEffect>("remis_sound");
            p1w_sound = Content.Load<SoundEffect>("player1wins");
            p2w_sound = Content.Load<SoundEffect>("player2wins");
            Mapa1.Czacha = Content.Load<SoundEffect>("czaszka");
            muzykainstancja = muzyka.CreateInstance();
            Menu1.menu_play_sound = Content.Load<SoundEffect>("menu_play_sound");
            Menu1.menu_Credits = muzyka_credits.CreateInstance();
            Menu1.menu_przeskok_sound = Content.Load<SoundEffect>("menu_przeskok_sound");
        }
        public void Load_Menu_Graphic()
        {
            menuPlay = Content.Load<Texture2D>("menu_play");
            menuOptions = Content.Load<Texture2D>("menu_options");
            menuCredits = Content.Load<Texture2D>("menu_credits");
            menuExit = Content.Load<Texture2D>("menu_exit");
            menuKeyboard = Content.Load<Texture2D>("menu_options_keyboard");
            menuKeyboard2 = Content.Load<Texture2D>("menu_options_keyboard2");
            menuSTM = Content.Load<Texture2D>("menu_options_stm");
            menuSTM2 = Content.Load<Texture2D>("menu_options_stm2");
            menuMusicON = Content.Load<Texture2D>("menu_options_musicON");
            menuMusicON2 = Content.Load<Texture2D>("menu_options_musicON2");
            menuMusicOFF = Content.Load<Texture2D>("menu_options_musicOFF");
            menuMusicOFF2 = Content.Load<Texture2D>("menu_options_musicOFF2");
            music_on = Content.Load<Texture2D>("music_on");
            music_off= Content.Load<Texture2D>("music_off");
            pause = Content.Load<Texture2D>("pause");
            credits = Content.Load<Texture2D>("credits");
            press_p = Content.Load<Texture2D>("press_p");
            press_o_resume = Content.Load<Texture2D>("press_o_resume");
            press_esc = Content.Load<Texture2D>("press_esc_restart");
        }
        public int ZamianaUstaw()
        {
            if (Game1.licznik_klatek % 10 == 0)
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
        public void Grafika_Poruszanie2(Player Gracz1, bool[] tab, int zamiana,SpriteBatch spriteBatch)
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
        public void Grafika_Poruszanie2_Player2(Player Gracz2, bool[] tab, int zamiana, SpriteBatch spriteBatch)
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
        public void Grafika_Cała(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Mapa, new Vector2(0, 0), Color.White);
            for (int l = 0; l < 11; l++)
            {
                //------------------------------------------------------------------------------------------Sprawdzanie zawartosci tabeli i rysowanie Obiektów -- ------------------------------------------------------------
                for (int i = 0; i < 13; i++)
                {
                    Sprawdzanie_pol_tabeli(i, l, Mapa1,spriteBatch);
                }
                Zamiana = ZamianaUstaw();
                //------------------------------------------------------------------------------------------Grafika poruszania się cd. : ----------------------------------------------------------------------------------------------
                //--------------------------------------------------------------------------------------------------------------------Grafika poruszania się : Gracz1 ------------------------------------------------------------
                if (Gracz1.Position.Y > 62 + (l - 1) * 50)
                {
                    if ((int)Menu1.CurrentControllerState == 2)
                    Grafika_Poruszanie2(Gracz1, Klawiatura1.STMZwracanie1(), Zamiana, spriteBatch);
                    if((int)Menu1.CurrentControllerState==1)
                    Grafika_Poruszanie2(Gracz1, Klawiatura1.Zwracanie(), Zamiana,spriteBatch);
                }
                //--------------------------------------------------------------------------------------------------------------------Grafika poruszania się : Gracz2 ------------------------------------------------------------                                   
                if (Gracz2.Position.Y > 62 + (l - 1) * 50)
                {
                    if((int)Menu1.CurrentControllerState==2)
                    Grafika_Poruszanie2_Player2(Gracz2, Klawiatura1.STMZwracanie2(), Zamiana, spriteBatch);
                    if((int)Menu1.CurrentControllerState==1)
                    Grafika_Poruszanie2_Player2(Gracz2, Klawiatura1.Zwracanie2(), Zamiana, spriteBatch);
                }

            }
            Grafika_Interface(spriteBatch);
            Grafika_Smierc(spriteBatch);
            if (Game1.GameState == Game1.Stan.Pause)
            {
                spriteBatch.Draw(pause, new Vector2(175, 150), Color.White);
                spriteBatch.Draw(press_o_resume, new Vector2(20, 600), Color.White);
                spriteBatch.Draw(press_esc, new Vector2(20, 580), Color.White);
            }
            if (Game1.GameState == Game1.Stan.Gra)
            {
                spriteBatch.Draw(press_p, new Vector2(20, 600), Color.White);
            }

            Reset_Gry(spriteBatch);
        }
        public void Grafika_Interface(SpriteBatch spriteBatch)
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
        public void Grafika_Smierc(SpriteBatch spriteBatch)
        {
            if ((Gracz1.zyje == false && GameState == Game1.Stan.Gra) && (Gracz2.zyje == true && GameState == Game1.Stan.Gra))
            {
                if (Game1.licznik_klatek % 13 == 0)
                {
                    Man_stoi = Content.Load<Texture2D>("Dead_swiatlo1");
                }
                if (Game1.licznik_klatek % 17 == 0)
                {
                    Man_stoi = Content.Load<Texture2D>("Dead_swiatlo2");
                }
                if (Game1.licznik_klatek % 23 == 0)
                {
                    GameState = Game1.Stan.Przegrana1;
                }
            }
            if (GameState == Game1.Stan.Przegrana1)
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
                if(Game1.Sound==true)
                p2w_sound.Play();
                GameState = Game1.Stan.Reset1;
            }
            if ((Gracz1.zyje == true && GameState == Game1.Stan.Gra) && (Gracz2.zyje == false && GameState == Game1.Stan.Gra))
            {
                if (Game1.licznik_klatek % 13 == 0)
                {
                    Man2_stoi = Content.Load<Texture2D>("Dead2_swiatlo1");
                }
                if (Game1.licznik_klatek % 17 == 0)
                {
                    Man2_stoi = Content.Load<Texture2D>("Dead2_swiatlo2");
                }
                if (Game1.licznik_klatek % 23 == 0)
                {
                    GameState = Game1.Stan.Przegrana2;
                }
            }
            if (GameState == Game1.Stan.Przegrana2)
            {
                Man2_prawo = Content.Load<Texture2D>("Dead2");
                Man2_lewo = Content.Load<Texture2D>("Dead2");
                Man2_krok_prawo = Content.Load<Texture2D>("Dead2");
                Man2_krok_lewo = Content.Load<Texture2D>("Dead2");
                Man2_gora = Content.Load<Texture2D>("Dead2");
                Man2_stoi = Content.Load<Texture2D>("Dead2");
                Man2_gora_krok = Content.Load<Texture2D>("Dead2");
                Man2_gora_krok2 = Content.Load<Texture2D>("Dead2");
                if(Game1.Sound==true)
                p1w_sound.Play();
                GameState = Game1.Stan.Reset2;
            }

            if ((Gracz1.zyje == false && GameState == Game1.Stan.Gra) && (Gracz2.zyje == false && GameState == Game1.Stan.Gra))
            {
                if (Game1.licznik_klatek % 13 == 0)
                {
                    Man_stoi = Content.Load<Texture2D>("Dead_swiatlo1");
                    Man2_stoi = Content.Load<Texture2D>("Dead2_swiatlo1");
                }
                if (Game1.licznik_klatek % 17 == 0)
                {
                    Man_stoi = Content.Load<Texture2D>("Dead_swiatlo2");
                    Man2_stoi = Content.Load<Texture2D>("Dead2_swiatlo2");
                }
                if (Game1.licznik_klatek % 23 == 0)
                {
                    GameState = Game1.Stan.Remis;
                }
            }
            if (GameState == Game1.Stan.Remis)
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
                if(Game1.Sound==true)
                remis_sound.Play();
                GameState = Game1.Stan.Reset3;
            }
        }
        public  void Reset_Gry(SpriteBatch spriteBatch)
        {
            bool reset = false;
            if (GameState == Game1.Stan.Reset1)
            {
                spriteBatch.Draw(Player2win, new Vector2(400, 100), Color.White);
                reset = true;
            }
            if (GameState == Game1.Stan.Reset2)
            {
                spriteBatch.Draw(Player1win, new Vector2(400, 100), Color.White);
                reset = true;
            }
            if (GameState == Game1.Stan.Reset3)
            {
                spriteBatch.Draw(remis, new Vector2(400, 100), Color.White);
                reset = true;
            }
            if (reset == true)
            {
                keyboardState = Keyboard.GetState();
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
                    Gracz1.szybkość = 2;
                    Gracz1.moc = 3;
                    Gracz1.kara = false;
                    Gracz1.Position = new Vector2(275, 55);
                    Gracz1.zyje = true;
                    Gracz2.postawionychBomb = 0;
                    Gracz2.Position = new Vector2(900, 630);
                    Gracz2.zyje = true;
                    Gracz2.kara = false;
                    Gracz2.maxBomb = 2;
                    Gracz2.szybkość = 2;
                    Gracz2.moc = 3;
                    GameState = Game1.Stan.Gra;
                }
            }
        }
        public  void Grafika_Menu(SpriteBatch spriteBatch, int opcja,GameTime gameTime)
        {
                if (opcja == 1)
                    spriteBatch.Draw(menuPlay, new Vector2(0, -128), Color.White);
                if (opcja == 2)
                    spriteBatch.Draw(menuOptions, new Vector2(0, -128), Color.White);
                if (opcja == 3)
                    spriteBatch.Draw(menuCredits, new Vector2(0, -128), Color.White);
                if (opcja == 4)
                    spriteBatch.Draw(menuExit, new Vector2(0, -128), Color.White);
        }
        public void Grafika_Menu2(SpriteBatch spriteBatch, int opcja,int opcjaController, GameTime gameTime, bool Sound)
        {
                if (opcjaController == 1 && opcja ==1 && Sound == true )
                spriteBatch.Draw(menuKeyboard, new Vector2(0, -128), Color.White);
                if (opcjaController == 2 && opcja==1 && Sound == true)
                spriteBatch.Draw(menuSTM, new Vector2(0, -128), Color.White);
                if (opcjaController == 1 && opcja==1 && Sound == false)
                spriteBatch.Draw(menuKeyboard2, new Vector2(0, -128), Color.White);
                if (opcjaController == 2 && opcja==1 && Sound == false)
                spriteBatch.Draw(menuSTM2, new Vector2(0, -128), Color.White);
                if (opcjaController == 1 && opcja==2 && Sound == true)
                spriteBatch.Draw(menuMusicON, new Vector2(0, -128), Color.White);
                if (opcjaController == 2 && opcja==2 && Sound == true)
                spriteBatch.Draw(menuMusicON2, new Vector2(0, -128), Color.White);
                if (opcjaController == 1 && opcja==2 && Sound == false)
                spriteBatch.Draw(menuMusicOFF, new Vector2(0, -128), Color.White);
                if (opcjaController == 2 && opcja==2 && Sound == false)
                spriteBatch.Draw(menuMusicOFF2, new Vector2(0, -128), Color.White);
        }
        public void Grafika_Credits(SpriteBatch spriteBatch, GameTime gameTime, int x , int y)
        {
            spriteBatch.Draw(credits, new Vector2(x, y), Color.White);
        }
        public   void Sprawdzanie_pol_tabeli(int i, int l, Mapa Mapa,SpriteBatch spriteBatch)
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
                if (Game1.licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Right;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.Left)
            {
                spriteBatch.Draw(Ogien_koniec_W, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (Game1.licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Left;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.Down)
            {
                spriteBatch.Draw(Ogien_koniec_S, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (Game1.licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Down;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.Up)
            {
                spriteBatch.Draw(Ogien_koniec_N, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (Game1.licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Up;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.RightBonusBomb)
            {
                spriteBatch.Draw(Ogien_koniec_E, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (Game1.licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Right;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.RightBonusPower)
            {
                spriteBatch.Draw(Ogien_koniec_E, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (Game1.licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Right;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.RightPunishPB)
            {
                spriteBatch.Draw(Ogien_koniec_E, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (Game1.licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Right;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.RightPunishSides)
            {
                spriteBatch.Draw(Ogien_koniec_E, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (Game1.licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Right;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.LeftBonusBomb)
            {
                spriteBatch.Draw(Ogien_koniec_W, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (Game1.licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Left;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.LeftBonusPower)
            {
                spriteBatch.Draw(Ogien_koniec_W, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (Game1.licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Left;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.LeftPunishPB)
            {
                spriteBatch.Draw(Ogien_koniec_W, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (Game1.licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Left;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.LeftPunishSides)
            {
                spriteBatch.Draw(Ogien_koniec_W, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (Game1.licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Left;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.DownBonusBomb)
            {
                spriteBatch.Draw(Ogien_koniec_S, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (Game1.licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Down;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.DownBonusPower)
            {
                spriteBatch.Draw(Ogien_koniec_S, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (Game1.licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Down;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.DownPunishPB)
            {
                spriteBatch.Draw(Ogien_koniec_S, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (Game1.licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Down;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.DownPunishSides)
            {
                spriteBatch.Draw(Ogien_koniec_S, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (Game1.licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Down;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.UpBonusBomb)
            {
                spriteBatch.Draw(Ogien_koniec_N, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (Game1.licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Up;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.UpBonusPower)
            {
                spriteBatch.Draw(Ogien_koniec_N, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (Game1.licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Up;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.UpPunishPB)
            {
                spriteBatch.Draw(Ogien_koniec_N, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (Game1.licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Up;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.UpPunishSides)
            {
                spriteBatch.Draw(Ogien_koniec_N, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (Game1.licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Up;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.Middle)
            {
                spriteBatch.Draw(Ogien_srodek, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (Game1.licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Middle;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.Poziom)
            {

                spriteBatch.Draw(Ogien_poziom, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (Game1.licznik_klatek % 55 == 0)
                    Mapa1.tab_mapa[i, l] = Mapa1.tab_mapa[i, l] - (int)Mapa.fire.Poziom;
            }
            if (Mapa1.tab_mapa[i, l] == (int)Mapa.fire.Pion)
            {

                spriteBatch.Draw(Ogien_pion, new Vector2(275 + (i * 50), 66 + (l * 50)), Color.White);
                if (Game1.licznik_klatek % 55 == 0)
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
    }
}
