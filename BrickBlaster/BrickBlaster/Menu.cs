using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BrickBlaster
{
    class Menu
    {
        int x = 190;
        int y = 745;
        public SoundEffect menu_play_sound;
        public SoundEffect menu_przeskok_sound;
        public int CurrentMenuState = 1;
        public int CurrentOptionsState = 1;
        public  int CurrentControllerState = 1;
        public enum menu { Play = 1, Options = 2, Credits = 3, Exit = 4 };
        public enum oMenu { Controller=1, Sound = 2 };
        public enum oController { Keyboard = 1, STM = 2 };
        public  void Menu_Logika( KeyboardState keyboardState,SpriteBatch spriteBatch, GraphicsDevice GraphicsDevice,Graphic graphic,GameTime gameTime)
        {
            Thread.Sleep(150);
            keyboardState = Keyboard.GetState();
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    if (CurrentMenuState > (int)menu.Play)
                        CurrentMenuState--;
 
                    if(Game1.Sound==true)
                    menu_przeskok_sound.Play();
                }
                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    if (CurrentMenuState < (int)menu.Exit)
                        CurrentMenuState++;

                    if (Game1.Sound == true)
                    menu_przeskok_sound.Play();
                }
                graphic.Grafika_Menu(spriteBatch,CurrentMenuState,gameTime);
                if (keyboardState.IsKeyDown(Keys.Enter))
                {
                    if ((int)CurrentMenuState == (int)menu.Play)
                    {
                        Game1.GameState = Game1.Stan.Gra;

                        if (Game1.Sound == true)
                        menu_play_sound.Play();
                        Thread.Sleep(500);
                    }
                    if ((int)CurrentMenuState == (int)menu.Options)
                        Game1.GameState = Game1.Stan.Options;
                    if ((int)CurrentMenuState == (int)menu.Credits)
                        Game1.GameState = Game1.Stan.Credits;
                    if ((int)CurrentMenuState == (int)menu.Exit)
                        Game1.GameState = Game1.Stan.Exit;
                }
        }
        public void Menu_Opcje(KeyboardState keyboardState, SpriteBatch spriteBatch, GraphicsDevice GraphicsDevice, Graphic graphic, GameTime gameTime)
        {
            Thread.Sleep(150);
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                if (CurrentOptionsState > (int)oMenu.Controller)
                    CurrentOptionsState--;

                 if (Game1.Sound == true)
                menu_przeskok_sound.Play();
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                if (CurrentOptionsState < (int)oMenu.Sound)
                    CurrentOptionsState++;

                if (Game1.Sound == true)
                menu_przeskok_sound.Play();
            }
            if (keyboardState.IsKeyDown(Keys.Right)&&CurrentOptionsState==(int)oMenu.Controller)
            {
                Thread.Sleep(100);
                if (CurrentControllerState < (int)oController.STM)
                {
                    CurrentControllerState++;
                }
                else
                {
                    CurrentControllerState--;
                }

                if (Game1.Sound == true)
                menu_przeskok_sound.Play();
            }
            if (keyboardState.IsKeyDown(Keys.Left) && CurrentOptionsState == (int)oMenu.Controller)
            {
                Thread.Sleep(100);
                if (CurrentControllerState > (int)oController.Keyboard)
                {
                    CurrentControllerState--;
                }
                else
                {
                    CurrentControllerState++;
                }

                if (Game1.Sound == true)
                menu_przeskok_sound.Play();
            }


            if ((keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.Left))&& CurrentOptionsState == (int)oMenu.Sound)
            {
                Thread.Sleep(100);
                if (Game1.Sound==true)
                {
                    Game1.Sound = false;
                }
                else
                {
                    Game1.Sound = true;
                }

                if (Game1.Sound == true)
                menu_przeskok_sound.Play();
            }
           
            graphic.Grafika_Menu2(spriteBatch, CurrentOptionsState,CurrentControllerState, gameTime, Game1.Sound);
            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                Thread.Sleep(50);
                    Game1.GameState = Game1.Stan.Menu;
            }
        }
        public void Menu_Credits(KeyboardState keyboardState, SpriteBatch spriteBatch, GraphicsDevice GraphicsDevice, Graphic graphic, GameTime gameTime)
        {
                 if (keyboardState.IsKeyDown(Keys.Escape))
                 {
                     Game1.GameState = Game1.Stan.Menu;
                      x = 190;
                      y = 745;
                      
                      if (menu_Credits.State == SoundState.Playing)
                     menu_Credits.Stop();
                 }
                 else
                 {
                     if (y > -330)
                     {
                         y--;
                     }
                     else
                     {
                         y = 745;
                     }
                     keyboardState = Keyboard.GetState();
                     graphic.Grafika_Credits(spriteBatch, gameTime, x, y);
                 }                
        }
    }
}
