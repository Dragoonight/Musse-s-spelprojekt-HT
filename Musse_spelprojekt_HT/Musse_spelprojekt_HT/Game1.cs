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

namespace Musse_spelprojekt_HT
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //olika GameStates
        enum GameStates
        {
            TitleScreen, levelselect, Tutorial, complete1, complete2, GameOver, Credits, Victory, Level, level2, level3,
        };
        //Start Gamestate
        GameStates gameState = GameStates.TitleScreen;
        //Titlescreen image 
        Texture2D TitleScreenImage;

        //Level select image
        Texture2D LevelSelectImage;
        
        //Tutorial image 
        Texture2D TutorialImage;
        
        //Credits image 
        Texture2D CreditsImage;
        
        //Complete1 image1
        Texture2D CompleteImage1;
        
        //Complete image2
        Texture2D CompleteImage2;
        
        //Victory image
        Texture2D VictoryImage;
        
        //Game over Image
        Texture2D GameOverImage;
        
        //Background Image for game 1
        Texture2D BackgroundImage1;
        
        //Background Image for game 2
        Texture2D BackgroundImage2;

        //Background Image for game 3
        Texture2D BackgroundImage3;

        //Player Sprite
        Texture2D playerSprite;
        //Player Placering
        Vector2 playerPosition = new Vector2(400, 300);

        //Ball Image
        Texture2D ballSprite;
        //Ball2 Image
        Texture2D ballSprite2;
        //Ball3 Image
        Texture2D ballSprite3;

        //Ball Position
        Vector2 ballPosition = new Vector2(400, 45);
        //Ball2 Position 
        Vector2 ballPosition2 = new Vector2(140, 140);
        //Ball2 Position
        Vector2 ballPosition3 = new Vector2(0, 500);

        //Ball speed
        Vector2 ballSpeed = new Vector2(500);
        //Ball2 speed
        Vector2 ballSpeed2 = new Vector2(500);
        //Ball3 speed
        Vector2 ballSpeed3 = new Vector2(500);

        //Font 
        SpriteFont Pericles21;

        //Life points
        int playerLife = 3;
        //Life Position 
        Vector2 lifePosition = new Vector2(390, 60);

       
        //Score
        int playerScore = 300;
        //Score Position 
        Vector2 playerScorePosition = new Vector2(390, 20);

        const int defaultPlayerLife = 3;
        const int defaultPlayerScore = 300;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            this.graphics.PreferredBackBufferHeight = 600;
            this.graphics.PreferredBackBufferWidth = 800;
            this.graphics.ApplyChanges();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //Loading upp TitleScreenImage
            TitleScreenImage = Content.Load<Texture2D>(@"Images /TitleImage");

            //Loading upp LevelselectImage
            LevelSelectImage = Content.Load<Texture2D>(@"Images /LevelSelect");

            //Loading upp Tutorial
            TutorialImage = Content.Load<Texture2D>(@"Images /Tutorial");

            //Loading upp Complete1
            CompleteImage1 = Content.Load<Texture2D>(@"Images /Completion 1");

            //Loading upp Complete2
            CompleteImage2 = Content.Load<Texture2D>(@"Images /Completion 2");

            //Loading upp Credits
            CreditsImage = Content.Load<Texture2D>(@"Images /Credits");

            //Loading upp Game over
            GameOverImage = Content.Load<Texture2D>(@"Images /Game Over");

            //Loading upp Victory
            VictoryImage = Content.Load<Texture2D>(@"Images /Victory");

            //Loading upp Level1
            BackgroundImage1 = Content.Load<Texture2D>(@"Images /LevelImage");

            //Loading upp Level2
            BackgroundImage2 = Content.Load<Texture2D>(@"Images /Level2Image");

            //Loading upp Level3
            BackgroundImage3 = Content.Load<Texture2D>(@"Images /Level3Image");

            //Load Font for life and Score
            Pericles21 = Content.Load<SpriteFont>(@"Fonts/Pericles21");

            //Loading upp Ball Image
            ballSprite = Content.Load<Texture2D>(@"Images/Ball1");

            //Loading upp Ball Image
            ballSprite2 = Content.Load<Texture2D>(@"Images/Ball2");

            //Loading upp Ball Image
            ballSprite3 = Content.Load<Texture2D>(@"Images/Ball3");

            //Load player sprite image
            playerSprite = Content.Load<Texture2D>(@"Images/Player");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //Allows game to exit 
            GamePadState gamePad = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyboard = Keyboard.GetState();
            //Back or Escape exits the game
            if (gamePad.Buttons.Back == ButtonState.Pressed ||
                keyboard.IsKeyDown(Keys.Escape)) this.Exit();
            // TODO: Add your update logic here
            // Press F to toggle full-screen mode
            if (keyboard.IsKeyDown(Keys.F))
            {
                graphics.IsFullScreen = !graphics.IsFullScreen;
                graphics.ApplyChanges();
            }

            //Controlling the ball collision
            Rectangle ballRect = new Rectangle((int)ballPosition.X, (int)ballPosition.Y, ballSprite.Width, ballSprite.Height);
            //Controlling the ball2 collision
            Rectangle ballRect2 = new Rectangle((int)ballPosition2.X, (int)ballPosition2.Y, ballSprite2.Width, ballSprite2.Height);
            //Controlling the ball3 collision
            Rectangle ballRect3 = new Rectangle((int)ballPosition3.X, (int)ballPosition3.Y, ballSprite3.Width, ballSprite3.Height);
            //Controlling the height and widht the player
            Rectangle playerRect = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, playerSprite.Width, playerSprite.Height);

            playerScore -= gameTime.ElapsedGameTime.Seconds;

            //This is the code för the player when it loses life to the ball
            if (playerRect.Intersects(ballRect) && playerLife > 0)
            {
                playerLife--;
                ballPosition.X = 200;
                ballPosition.Y = 0;
            }

            //This is the code from Titlescreen to Game over
            if (playerRect.Intersects(ballRect2) && playerLife > 0)
            {

                playerLife--;
                ballPosition2.X = 200;
                ballPosition2.Y = 0;

            }
            //This is the code from Titlescreen to Game over
            if (playerRect.Intersects(ballRect3) && playerLife > 0)
            {
                playerLife--;
                ballPosition3.X = 200;
                ballPosition3.Y = 0;
            }
           

            //if the balls tries to escape the boundaries
            int maxX = graphics.GraphicsDevice.Viewport.Width - playerSprite.Width;
            int maxY = graphics.GraphicsDevice.Viewport.Height - playerSprite.Height;

            //Controlls that if the player hit any of the sides of the window it bounces
            if (playerPosition.X > maxX)
                playerPosition.X = maxX;

            if (playerPosition.Y > maxY)
                playerPosition.Y = maxY;

            if (playerPosition.X < 0)
                playerPosition.X = 0;

            if (playerPosition.Y < 0)
                playerPosition.Y = 0;

            //move ball position and speed depending on the time
            ballPosition += ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //move ball2 position and speed depending on the time
            ballPosition2 += ballSpeed2 * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //move ball3 position and speed depending on the time
            ballPosition3 += ballSpeed3 * (float)gameTime.ElapsedGameTime.TotalSeconds;


            //Uppdatera Players Position/förflyttning
            if (keyboard.IsKeyDown(Keys.Right))
            {
                playerPosition.X += 7;
            }
            else if (keyboard.IsKeyDown(Keys.Left))
            {
                playerPosition.X -= 7;
            }
            if (keyboard.IsKeyDown(Keys.Down))
            {
                playerPosition.Y += 7;
            }
            else if (keyboard.IsKeyDown(Keys.Up))
            {
                playerPosition.Y -= 7;
            }


            //Controlls that if the ball hit any of the sides of the window it bounces
            if (ballPosition.X > maxX || ballPosition.X < 0)
                ballSpeed.X *= -1;
            if (ballPosition.Y > maxY || ballPosition.Y < 0)
                ballSpeed.Y *= -1;

            //Controlls that if the ball2 hit any of the sides of the window it bounces
            if (ballPosition2.X > maxX || ballPosition2.X < 0)
                ballSpeed2.X *= -1;
            if (ballPosition2.Y > maxY || ballPosition2.Y < 0)
                ballSpeed2.Y *= -1;

            //Controlls that if the ball hit any of the sides of the window it bounces
            if (ballPosition3.X > maxX || ballPosition3.X < 0)
                ballSpeed3.X *= -1;
            if (ballPosition3.Y > maxY || ballPosition3.Y < 0)
                ballSpeed3.Y *= -1;

            Console.WriteLine("runnet");

            //This is the code for the different gamestates that the has 
            switch (gameState)
            {
                //This is the TitleScreen
                case GameStates.TitleScreen:
                    //This is the code from Titlescreen to levelselect
                    if (keyboard.IsKeyDown(Keys.Space))
                    {
                        gameState = GameStates.levelselect;

                        //This are codes that reset everything
                        playerScore = defaultPlayerScore;
                        playerLife = defaultPlayerLife;
                       
                    }

                    //This is the code from Titlescreen to Credits
                    if (keyboard.IsKeyDown(Keys.C))
                    {
                        gameState = GameStates.Credits;

                        //This are codes that reset everything
                        playerScore = defaultPlayerScore;
                        playerLife = defaultPlayerLife;
                    }

                    //This is the code from Titlescreen to Tutorial
                    if (keyboard.IsKeyDown(Keys.T))
                    {
                        gameState = GameStates.Tutorial;

                        //This are codes that reset everything
                        playerScore = defaultPlayerScore;
                        playerLife = defaultPlayerLife;
                    }
                    break;

                //This is the Levelselect
                case GameStates.levelselect:

                    //This is the code from LevelSelect to level
                    if (keyboard.IsKeyDown(Keys.NumPad1))
                    {
                        gameState = GameStates.Level;

                        //This are codes that reset everything
                        playerScore = defaultPlayerScore;
                        playerLife = defaultPlayerLife;
                    }

                    //This is the code from levelSelect to level2
                    if (keyboard.IsKeyDown(Keys.NumPad2))
                    {
                        gameState = GameStates.level2;

                        //This are codes that reset everything
                        playerScore = defaultPlayerScore;
                        playerLife = defaultPlayerLife;
                    }


                    //This is the code from levelSelect to level3
                    if (keyboard.IsKeyDown(Keys.NumPad3))
                    {
                        gameState = GameStates.level3;

                        //This are codes that reset everything
                        playerScore = defaultPlayerScore;
                        playerLife = defaultPlayerLife;
                    }

                    //This is the code from levelSelect to Titlescreen
                    if (keyboard.IsKeyDown(Keys.Enter))
                    {
                        gameState = GameStates.TitleScreen;

                        //This are codes that reset everything
                        playerScore = defaultPlayerScore;
                        playerLife = defaultPlayerLife;
                    }

                    break;

                //This is the code for Tutorial
                case GameStates.Tutorial:
                    //This is the code from Tutorial to levelselect
                    if (keyboard.IsKeyDown(Keys.Space))
                    {
                        gameState = GameStates.levelselect;

                        //This are codes that reset everything
                        playerScore = defaultPlayerScore;
                        playerLife = defaultPlayerLife;
                    }

                    break;
                //This is the code for Credits
                case GameStates.Credits:

                    //This is the code from Credits to TitleScreen
                    if (keyboard.IsKeyDown(Keys.Enter))
                    {
                        gameState = GameStates.TitleScreen;

                        //This are codes that reset everything
                        playerScore = defaultPlayerScore;
                        playerLife = defaultPlayerLife;
                    }

                    break;
                //This is the code for complete1 
                case GameStates.complete1:
                    //This is the code from Complete1 to level 1
                    if (keyboard.IsKeyDown(Keys.R))
                    {
                        gameState = GameStates.Level;

                        //This are codes that reset everything
                        playerScore = defaultPlayerScore;
                        playerLife = defaultPlayerLife;
                    }

                    //This is the code from Complete1 to level2;
                    if (keyboard.IsKeyDown(Keys.NumPad2))
                    {
                        gameState = GameStates.level2;

                        //This are codes that reset everything
                        playerScore = defaultPlayerScore;
                        playerLife = defaultPlayerLife;
                    }
                    break;
                //This is the code for Complete2
                case GameStates.complete2:
                    if (keyboard.IsKeyDown(Keys.Space))
                    {
                        gameState = GameStates.levelselect;

                        //This are codes that reset everything
                        playerScore = defaultPlayerScore;
                        playerLife = defaultPlayerLife;
                    }
                    //This is the code from complete2 to level3;
                    if (keyboard.IsKeyDown(Keys.NumPad3))
                    {
                        gameState = GameStates.level3;

                        //This are codes that reset everything
                        playerScore = defaultPlayerScore;
                        playerLife = defaultPlayerLife;
                    }

                    break;

                //This is the code for GameOver
                case GameStates.GameOver:

                    //This is the code from GameOver to TitleScreen
                    if (keyboard.IsKeyDown(Keys.Space))
                    {
                        gameState = GameStates.levelselect;

                        //This are codes that reset everything
                        playerScore = defaultPlayerScore;
                        playerLife = defaultPlayerLife;


                    }
                    //Thís is code from Game over to TitleScreen
                    if (keyboard.IsKeyDown(Keys.Enter))
                    {
                        gameState = GameStates.TitleScreen;

                        //This are codes that reset everything
                        playerScore = defaultPlayerScore;
                        playerLife = defaultPlayerLife;
                    }
                    break;

                //This is gamestate for Victory
                case GameStates.Victory:
                    if (keyboard.IsKeyDown(Keys.Space))
                    {
                        gameState = GameStates.Credits;

                        //This are codes that reset everything
                        playerScore = defaultPlayerScore;
                        playerLife = defaultPlayerLife;
                    }
                    break;

                //This is gamestate from level1
                case GameStates.Level:

                    if (playerScore <= 0)
                    {
                        gameState = GameStates.complete1;

                        //This are codes that reset everything
                        playerScore = defaultPlayerScore;
                        playerLife = defaultPlayerLife;
                    }
                    //This code if the player looses all of his life and is going to game over
                    if (playerLife <= 0)
                    {
                        gameState = GameStates.GameOver;

                        //This are codes that reset everything
                        playerScore = defaultPlayerScore;
                        playerLife = defaultPlayerLife;
                    }

                    break;
                    //This is gamestate level2
                case GameStates.level2:
                    //This is the code for when the player loses all his life and goes to gameover
                    if (playerScore <= 0)
                    {
                        gameState = GameStates.complete2;

                        //This are codes that reset everything
                        playerScore = defaultPlayerScore;
                        playerLife = defaultPlayerLife;
                    }

                    //This code if the player looses all of his life and is going to game over
                    if (playerLife <= 0)
                    {
                        gameState = GameStates.GameOver;

                        //This are codes that reset everything
                        playerScore = defaultPlayerScore;
                        playerLife = defaultPlayerLife;
                    }

                        break;
                    //This is gamestate level3
                case GameStates.level3:

                    //This is form gamestate level3 to ultimate victory
                    if (playerScore <= 0)
                    {
                        gameState = GameStates.Victory;

                        //This are codes that reset everything
                        playerScore = defaultPlayerScore;
                        playerLife = defaultPlayerLife;
                    }

                    //This code if the player looses all of his life and is going to game over
                    if (playerLife <= 0)
                    {
                        gameState = GameStates.GameOver;
                    }

                    break;
            }

           

            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);
            //Draw TitleScreen
            if (gameState == GameStates.TitleScreen)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(TitleScreenImage, new Vector2(0, 0), Color.White);
                spriteBatch.End();
            }

            // Draw LevelSelectImage
            if (gameState == GameStates.levelselect)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(LevelSelectImage, new Vector2(0, 0), Color.White);
                spriteBatch.End();
            }

            //Draw Tutorial
            if (gameState == GameStates.Tutorial)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(TutorialImage, new Vector2(0, 0), Color.White);
                spriteBatch.End();
            }
            //Draw Complete 1
            if (gameState == GameStates.complete1)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(CompleteImage1, new Vector2(0, 0), Color.White);
                spriteBatch.End();
            }
            //Draw Complete 2
            if (gameState == GameStates.complete2)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(CompleteImage2, new Vector2(0, 0), Color.White);
                spriteBatch.End();
            }
            //Draw Credits 
            if (gameState == GameStates.Credits)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(CreditsImage, new Vector2(0, 0), Color.White);
                spriteBatch.End();
            }
            // Draw Victory
            if (gameState == GameStates.Victory)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(VictoryImage, new Vector2 (0,0), Color.White);
                spriteBatch.End();
            }
            //Draw GameOver
            if (gameState == GameStates.GameOver)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(GameOverImage, new Vector2(0,0), Color.White);
                spriteBatch.End();
            }

            //Draw Level
            if (gameState == GameStates.Level)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(BackgroundImage1, new Vector2(0, 0), Color.AntiqueWhite);
                
                
                spriteBatch.Draw(playerSprite, playerPosition, Color.White);

                spriteBatch.Draw(ballSprite, ballPosition, Color.White);
                spriteBatch.Draw(ballSprite2, ballPosition2, Color.White);
                spriteBatch.Draw(ballSprite3, ballPosition3, Color.White);

                spriteBatch.DrawString(Pericles21, playerLife.ToString(), lifePosition, Color.Pink);
                spriteBatch.DrawString(Pericles21, playerScore.ToString(), playerScorePosition, Color.Red);
                
                spriteBatch.End();
            }
            //Draw Level2
            if (gameState == GameStates.level2)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(BackgroundImage2, new Vector2(0, 0), Color.White);
                
                spriteBatch.Draw(playerSprite, playerPosition, Color.White);

                spriteBatch.Draw(ballSprite, ballPosition, Color.White);
                spriteBatch.Draw(ballSprite2, ballPosition2, Color.White);
                spriteBatch.Draw(ballSprite3, ballPosition3, Color.White);

                spriteBatch.DrawString(Pericles21, playerLife.ToString(), lifePosition, Color.Pink);
                spriteBatch.DrawString(Pericles21, playerScore.ToString(), playerScorePosition, Color.Red);

                spriteBatch.End();
               
            } 
            //Draw Level3
            if (gameState == GameStates.level3)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(BackgroundImage3, new Vector2(0, 0), Color.White);
               
               
                spriteBatch.Draw(playerSprite, playerPosition, Color.White);

                spriteBatch.Draw(ballSprite, ballPosition, Color.White);
                spriteBatch.Draw(ballSprite2, ballPosition2, Color.White);
                spriteBatch.Draw(ballSprite3, ballPosition3, Color.White);

                spriteBatch.DrawString(Pericles21, playerLife.ToString(), lifePosition, Color.Pink);
                spriteBatch.DrawString(Pericles21, playerScore.ToString(), playerScorePosition, Color.Red);
                
                spriteBatch.End();
            }
            base.Draw(gameTime);
            }
        }
    }

