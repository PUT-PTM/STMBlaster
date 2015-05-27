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
using System.Threading;
namespace BrickBlaster
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region --------------------Variables/Objects/etc.
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        Vector2 Pozycja_g1 = new Vector2(275, 55);
        Vector2 Pozycja_g2 = new Vector2(875, 555);
        Player Gracz1 = new Player(1300);
        Player Gracz2 = new Player(2300);
        Menu Menu1 = new Menu();
        Vector2 Position = new Vector2(275, 55);
        public enum Stan {Gra=1,Reset1=2,Reset2=3,Reset3=4,Remis=5,Przegrana1=6,Przegrana2=7,Credits=8,Options=9,Exit=10,Menu=11};  
        Mapa Mapa1 = new Mapa();
        KeyboardState keyboardState;
        public static Stan GameState = Stan.Gra;
        Kontroler Klawiatura1 = new Kontroler();
        Graphic Graphic= new Graphic();
        public static int licznik_klatek = 0;
        #endregion
        void Logika_Gry()
        {
            #region KEYBOARD STEROWANIE
            if ((int)Menu1.CurrentControllerState == 1)
            {
                Gracz1.Player_Poruszanie(Klawiatura1.Zwracanie(), graphics);
                Mapa1.Sprawdz_Bonus(Gracz1, Gracz2, licznik_klatek);
                Gracz2.Player_Poruszanie(Klawiatura1.Zwracanie2(), graphics);
                Mapa1.Sprawdz_Bonus(Gracz2, Gracz1, licznik_klatek);
                Gracz1.Zwieksz_liczbe_bomb_postawionych(Mapa1.stawianie_bomby(Gracz1.Logika_Bomba_stawianie(Klawiatura1.Zwracanie()), Gracz1, Gracz2));
                Mapa1.Logika_bomba(licznik_klatek, Gracz1, Gracz2);
                Gracz2.Zwieksz_liczbe_bomb_postawionych(Mapa1.stawianie_bomby(Gracz2.Logika_Bomba_stawianie(Klawiatura1.Zwracanie2()), Gracz2, Gracz1));
                Mapa1.Logika_bomba(licznik_klatek, Gracz2, Gracz1);
                Gracz1.Aktualizuj_Pozycje(Mapa1.kolizje(Gracz1.Position, Klawiatura1.Zwracanie(),Gracz1.kara));
                Gracz2.Aktualizuj_Pozycje(Mapa1.kolizje(Gracz2.Position, Klawiatura1.Zwracanie2(), Gracz2.kara));
            }
            #endregion
            #region STM STEROWANIE
           if ((int)Menu1.CurrentControllerState==2)
            {
                Gracz1.Player_Poruszanie(Klawiatura1.STMZwracanie1(), graphics);
                Mapa1.Sprawdz_Bonus(Gracz1, Gracz2, licznik_klatek);
                Gracz2.Player_Poruszanie(Klawiatura1.STMZwracanie2(), graphics);
                Mapa1.Sprawdz_Bonus(Gracz2, Gracz1, licznik_klatek);
                Gracz1.Zwieksz_liczbe_bomb_postawionych(Mapa1.stawianie_bomby(Gracz1.Logika_Bomba_stawianie(Klawiatura1.STMZwracanie1()), Gracz1, Gracz2));
                Mapa1.Logika_bomba(licznik_klatek, Gracz1, Gracz2);
                Gracz2.Zwieksz_liczbe_bomb_postawionych(Mapa1.stawianie_bomby(Gracz2.Logika_Bomba_stawianie(Klawiatura1.STMZwracanie2()), Gracz2, Gracz1));
                Mapa1.Logika_bomba(licznik_klatek, Gracz2, Gracz1);
                Gracz1.Aktualizuj_Pozycje(Mapa1.kolizje(Gracz1.Position, Klawiatura1.STMZwracanie1(), Gracz1.kara));
                Gracz2.Aktualizuj_Pozycje(Mapa1.kolizje(Gracz2.Position, Klawiatura1.STMZwracanie2(), Gracz2.kara));
            }
            #endregion
            /*
            #region --------------------Player1 Movement
            Gracz1.Player_Poruszanie(Klawiatura1.STMZwracanie1(), graphics); 
           // Gracz1.Player_Poruszanie(Klawiatura1.Zwracanie(), graphics);
            Mapa1.Sprawdz_Bonus(Gracz1,Gracz2,licznik_klatek);
            #endregion
            #region --------------------Player2 Movement           
            Gracz2.Player_Poruszanie(Klawiatura1.STMZwracanie2(), graphics);    
          //  Gracz2.Player_Poruszanie(Klawiatura1.Zwracanie2(),graphics);             
            Mapa1.Sprawdz_Bonus(Gracz2,Gracz1,licznik_klatek);
            #endregion
            #region --------------------Player1 Bomb Logic
            Gracz1.Zwieksz_liczbe_bomb_postawionych(Mapa1.stawianie_bomby(Gracz1.Logika_Bomba_stawianie(Klawiatura1.STMZwracanie1()), Gracz1, Gracz2));
           // Gracz1.Zwieksz_liczbe_bomb_postawionych(Mapa1.stawianie_bomby(Gracz1.Logika_Bomba_stawianie(Klawiatura1.Zwracanie()), Gracz1,Gracz2));
            Mapa1.Logika_bomba(licznik_klatek, Gracz1,Gracz2);
            #endregion
            #region --------------------Player2 Bomb Logic
            Gracz2.Zwieksz_liczbe_bomb_postawionych(Mapa1.stawianie_bomby(Gracz2.Logika_Bomba_stawianie(Klawiatura1.STMZwracanie2()), Gracz2, Gracz1));   
          //  Gracz2.Zwieksz_liczbe_bomb_postawionych(Mapa1.stawianie_bomby(Gracz2.Logika_Bomba_stawianie(Klawiatura1.Zwracanie2()),Gracz2, Gracz1));   
            Mapa1.Logika_bomba(licznik_klatek, Gracz2,Gracz1);
            #endregion
            #region --------------------Collisions
            //-----------------------------------------------------------------------------------------------------------------Kolizje :  Gracz1 -----------------------------------------------------------------------------
            Gracz1.Aktualizuj_Pozycje(Mapa1.kolizje(Gracz1.Position, Klawiatura1.STMZwracanie1(), Gracz1.kara));
          //  Gracz1.Aktualizuj_Pozycje(Mapa1.kolizje(Gracz1.Position, Klawiatura1.Zwracanie(),Gracz1.kara));
            //-----------------------------------------------------------------------------------------------------------------Kolizje :  Gracz2 -----------------------------------------------------------------------------
            Gracz2.Aktualizuj_Pozycje(Mapa1.kolizje(Gracz2.Position, Klawiatura1.STMZwracanie2(), Gracz2.kara)); 
           // Gracz2.Aktualizuj_Pozycje(Mapa1.kolizje(Gracz2.Position, Klawiatura1.Zwracanie2(),Gracz2.kara));
            #endregion
            */
            #region --------------------Death - Delay
            Mapa1.Smierc_delay(Gracz1);
            Mapa1.Smierc_delay(Gracz2);
            #endregion
        }
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 700;
            graphics.PreferredBackBufferWidth = 1000;
            Graphic.PrzypiszReferencje(graphics, Content, Mapa1, Menu1, Gracz1, Gracz2, Klawiatura1, GameState, keyboardState);
        }    
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here         
            Gracz1.Position = new Vector2(275, 55);
            Gracz2.Position = new Vector2(900, 630);
            Mapa1.Stawianie_klockow();
            GameState = Stan.Menu;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Graphic.Load_Interface_Graphic();
            Graphic.Load_Player_Graphic();
            Graphic.Load_Menu_Graphic();
            Graphic.Load_Map_Objects_Graphic();
            Graphic.Load_Sounds();
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
            if (GameState == Stan.Gra)
            {
                if (Gracz1.zyje == true && Gracz2.zyje == true)
                {
                    if (Graphic.muzykainstancja.State != SoundState.Playing)
                    {
                        Graphic.muzykainstancja.Play();
                    }
                    Logika_Gry();
                }
                else
                {
                    Graphic.muzykainstancja.Stop();
                }
           }
            if (Game1.GameState == Stan.Exit)
            {
                this.Exit(); 
            }
             licznik_klatek++;          
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            #region -------------------Graphic methods
            //------------------------------------------------------------------------------------------------Mapa Grafika-------------------------------------------------------------------------------------------------------
           if(GameState == Stan.Gra)
            Graphic.Grafika_Ca³a(spriteBatch);
           if (GameState == Stan.Options)
           {
               keyboardState = Keyboard.GetState();
               Menu1.Menu_Opcje(keyboardState, spriteBatch, GraphicsDevice, Graphic, gameTime);
           }
           if (GameState == Stan.Menu)
           {
              /* KeyboardState temp=keyboardState;
               keyboardState = Keyboard.GetState();
               if (keyboardState != temp)
               {*/
                   keyboardState = Keyboard.GetState();
                   Menu1.Menu_Logika(keyboardState, spriteBatch, GraphicsDevice, Graphic, gameTime);
              // }
           }
           
#endregion
           #region--------------------------Fps counter for animation 
           if (licznik_klatek >= 60)
            {
                licznik_klatek = 0;
            }
           #endregion
           spriteBatch.End();         
            base.Draw(gameTime);
        }
    }
}
