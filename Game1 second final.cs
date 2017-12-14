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
        //This is the variable for all the GameStates that i will use
        enum GameStates
        {
            TitleScreen, levelselect, Tutorial, complete1, complete2, GameOver, Credits, Victory, Level, level2, level3,
        };
        //This is the variable for Start Gamestate
        GameStates gameState = GameStates.TitleScreen;
        //This is the variable for Titlescreen image 
        Texture2D TitleScreenImage;

        //This is the variable for Level select image
        Texture2D LevelSelectImage;

        //This is the variable for Tutorial image 
        Texture2D TutorialImage;
        
        //Credits image 
        Texture2D CreditsImage;

        //This is the variable for Complete1 image1
        Texture2D CompleteImage1;

        //This is the variable for Complete image2
        Texture2D CompleteImage2;

        //This is the variable for Victory image
        Texture2D VictoryImage;

        //This is the variable for Game over Image
        Texture2D GameOverImage;

        //This is the variable for Background Image for game 1
        Texture2D BackgroundImage1;

        //This is the variable for Background Image for game 2
        Texture2D BackgroundImage2;

        //This is the variable for Background Image for game 3
        Texture2D BackgroundImage3;

        //This is the variable for player Sprite
        Texture2D playerSprite;
        //This is the variable for player Position
        Vector2 playerPosition = new Vector2(400, 300);
        //This is the variable for uppdating the player position everytime you choose a level
        protected Vector2 defaultPlayerPos = new Vector2(375, 275);

        //This is the variable for ball Image
        Texture2D ballSprite;
        //This is the variable for ball Position
        Vector2 ballPosition = new Vector2(400, 0);
        //This is the variable for ball speed
        Vector2 ballSpeed = new Vector2(500);
        //This variable is for uppdating the ball position everytime you choose a level
        protected Vector2 defaultballPos = new Vector2(400,0);

        //This is the variable for ball2 Image
        Texture2D ballSprite2;
        //This is the variable for ball2 Position 
        Vector2 ballPosition2 = new Vector2(140, 0);
        //This is the variable for ball2 speed
        Vector2 ballSpeed2 = new Vector2(500);
        //This is the variable for uppdating the ball2 position everytime you choose a level
        protected Vector2 defaultballPos2 = new Vector2(140, 0);


        //This is the variable for ball3 Image
        Texture2D ballSprite3;
        //This is the variable for ball3 Position
        Vector2 ballPosition3 = new Vector2(175, 0);
        //This is the variable for ball3 speed
        Vector2 ballSpeed3 = new Vector2(500);
        //This is the variable for uppdating the ball3 position everytime you choose a level
        protected Vector2 defaultballPos3 = new Vector2(175, 0);


        //This is the variable for ball4 Image
        Texture2D ballSprite4;
        //This is the variable for ball4 Position
        Vector2 ballPosition4 = new Vector2(200, 0);
        //This is the variable for ball4 speed
        Vector2 ballSpeed4 = new Vector2(600);
        //This is the variable for uppdating the ball4 position everytime you choose a level
        protected Vector2 defaultballPos4 = new Vector2(200, 0);


        //This is the variable for ball5 Image
        Texture2D ballSprite5;
        //This is the variable for ball5 Position
        Vector2 ballPosition5 = new Vector2(370, 0);
        //This is the variable for ball5 speed
        Vector2 ballSpeed5 = new Vector2(600);
        //This is the variable for uppdating the ball5 position everytime you choose a level
        protected Vector2 defaultballPos5 = new Vector2(370, 0);

        //This is the variable for ball6 Image
        Texture2D ballSprite6;
        //This is the variable for ball6 Position
        Vector2 ballPosition6 = new Vector2(320,0);
        //This is the variable for ball6 speed
        Vector2 ballSpeed6 = new Vector2(700);
        //This is the variable for uppdating the ball6 position everytime you choose a level
        protected Vector2 defaultballPos6 = new Vector2(320, 0);

        //This is the variable for life points
        int playerLife = 5;
        //This is the variable for life Position 
        Vector2 lifePosition = new Vector2(390, 60);
        //This is the variable for uppdating the life so that you will always have 5 in every gamestate
        const int defaultPlayerLife = 5;

        //This is the variable for score
        int playerScore = 30000;
        //This is the variable for score Position 
        Vector2 playerScorePosition = new Vector2(390, 20);
        //This is the variable for the points so that you will always have 30000 in every gamestate            
        const int defaultPlayerScore = 30000;

        //This is the variable for for Fonts
        SpriteFont Pericles21;


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
            //This is the line of code that will control that the screen's Height is always 600 pixels
            this.graphics.PreferredBackBufferHeight = 600;
            //This is the line of code that will control that the screen's Width is always 800 pixels
            this.graphics.PreferredBackBufferWidth = 800;
            //This is the line of code that will control that the changes will apply when the game starts
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

            //This is the line of code that will load up Title Screen image
            TitleScreenImage = Content.Load<Texture2D>(@"Images /TitleImage");

            //This is the line of code that will load up Levelselect image
            LevelSelectImage = Content.Load<Texture2D>(@"Images /LevelSelect");

            //This is the line of code that will load up Tutorial image
            TutorialImage = Content.Load<Texture2D>(@"Images /Tutorial");

            //This is the line of code that will load up Complete1 image
            CompleteImage1 = Content.Load<Texture2D>(@"Images /Completion 1");

            //This is the line of code that will load up Complete2 image
            CompleteImage2 = Content.Load<Texture2D>(@"Images /Completion 2");

            //This is the line of code that will load up Credit image
            CreditsImage = Content.Load<Texture2D>(@"Images /Credits");

            //This is the line of code that will load up Game over image
            GameOverImage = Content.Load<Texture2D>(@"Images /Game Over");

            //This is the line of code that will load up Victory
            VictoryImage = Content.Load<Texture2D>(@"Images /Victory");

            //This is the line of code that will load up Level1
            BackgroundImage1 = Content.Load<Texture2D>(@"Images /LevelImage");

            //This is the line of code that will load up Level2
            BackgroundImage2 = Content.Load<Texture2D>(@"Images /Level2Image");

            //This is the line of code that will load up Level3
            BackgroundImage3 = Content.Load<Texture2D>(@"Images /Level3Image");

            //This is the line of code that will load up fonts for life and score
            Pericles21 = Content.Load<SpriteFont>(@"Fonts/Pericles21");

            //This is the line of code that will load up ball image
            ballSprite = Content.Load<Texture2D>(@"Images/Ball1");

            //This is the line of code that will load up ball2 image
            ballSprite2 = Content.Load<Texture2D>(@"Images/Ball2");

            //This is the line of code that will load up ball3 image
            ballSprite3 = Content.Load<Texture2D>(@"Images/Ball3");

            //This is the line of code that will load up ball4 image
            ballSprite4 = Content.Load<Texture2D>(@"Images/Ball4");

            //This is the line of code that will load up ball5 image
            ballSprite5 = Content.Load<Texture2D>(@"Images/Ball5");

            //This is the line of code that will load up ball6 image
            ballSprite6 = Content.Load<Texture2D>(@"Images/Ball6");

            //This is the line of code that will load up sprite image
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
            //This is the line of code that uppdates that the keyboard is in use 
            GamePadState gamePad = GamePad.GetState(PlayerIndex.One);
            KeyboardState keyboard = Keyboard.GetState();

            //This is the line of code that will control that the escape button exits the game
            if (gamePad.Buttons.Back == ButtonState.Pressed ||
                keyboard.IsKeyDown(Keys.Escape)) this.Exit();

            // This is the line of code that will control that pressing F to toggle full-screen mode
            if (keyboard.IsKeyDown(Keys.F))
            {
                graphics.IsFullScreen = !graphics.IsFullScreen;
                graphics.ApplyChanges();
            }


            //This is the line of code that will control the ball collision
            Rectangle ballRect = new Rectangle((int)ballPosition.X, (int)ballPosition.Y, ballSprite.Width, ballSprite.Height);

            //This is the line of code that will control the ball2 collision
            Rectangle ballRect2 = new Rectangle((int)ballPosition2.X, (int)ballPosition2.Y, ballSprite2.Width, ballSprite2.Height);

            //This is the line of code that will control ball3 collision
            Rectangle ballRect3 = new Rectangle((int)ballPosition3.X, (int)ballPosition3.Y, ballSprite3.Width, ballSprite3.Height);

            //This is the line of code that will control ball4 collision
            Rectangle ballRect4 = new Rectangle((int)ballPosition.X, (int)ballPosition.Y, ballSprite.Width, ballSprite.Height);

            //This is the line of code that will control ball5 collision
            Rectangle ballRect5 = new Rectangle((int)ballPosition.X, (int)ballPosition.Y, ballSprite.Width, ballSprite.Height);

            //This is the line of code that will control ball6 collision
            Rectangle ballRect6 = new Rectangle((int)ballPosition.X, (int)ballPosition.Y, ballSprite.Width, ballSprite.Height);


            //This is the line of code that will control the height and widht the player
            Rectangle playerRect = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, playerSprite.Width, playerSprite.Height);

            //This is the line of code that will control the score goes down
            playerScore -= gameTime.ElapsedGameTime.Milliseconds;

            //This is the line of code that controls that when the player intersect with ball the respective things will happen
            if (playerRect.Intersects(ballRect) && playerLife > 0)
            {
                //This is the line of code that will control the player looses a life to ball if it intercepts with it 
                playerLife--;
                //This is the line of code that will control that the ball goes to it's respective position
                ballPosition.X = 400;
                ballPosition.Y = 0;
            }

            //This is the line of code that controls that when the player intersect with ball2 the respective things will happen
            if (playerRect.Intersects(ballRect2) && playerLife > 0)
            {
                //This is the line of code that will control that the player looses a life to ball2
                playerLife--;
                //This is the line of code that will control that the ball2 goes to it's respective position
                ballPosition2.X = 140;
                ballPosition2.Y = 0;
            }

            //This is the line of code that controls that when the player intersect with ball3 the respective things will happen
            if (playerRect.Intersects(ballRect3) && playerLife > 0)
            {
                //This is the line of code that will control that the player looses a life to ball3
                playerLife--;
                //This is the line of code that will control that the ball3 goes to it's respective position
                ballPosition3.X = 175;
                ballPosition3.Y = 0;
            }

            //This is the line of code that controls that when the player intersect with ball4 the respective things will happen
            if (playerRect.Intersects(ballRect4) && playerLife > 0)
            {
                //This is the line of code that will control that the player looses a life to ball4
                playerLife--;
                //This is the line of code that will control that the ball4 goes to it's respective position
                ballPosition4.X = 200;
                ballPosition4.Y = 0;
            }

            //This is the line of code that controls that when the player intersect with ball5 the respective things will happen
            if (playerRect.Intersects(ballRect5) && playerLife > 0)
            {
                //This is the line of code that will control that the player looses a life to ball5
                playerLife--;
                //This is the line of code that will control that the ball5 goes to it's respective position
                ballPosition5.X = 370;
                ballPosition5.Y = 0;
            }

            //This is the line of code that controls that when the player intersect with ball6 the respective things will happen
            if (playerRect.Intersects(ballRect6) && playerLife > 0)
            {
                //This is the line of code that will control that the player looses a life to ball6
                playerLife--;
                //This is the line of code that will control that the ball6 goes to it's respective position
                ballPosition6.X = 320;
                ballPosition6.Y = 0;
            }

            //This is the line of code checks that the player is within the screen 
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

            // move ball4 position and speed depending on the time
            ballPosition4 += ballSpeed4 * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // move ball5 position and speed depending on the time
            ballPosition5 += ballSpeed5 * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // move ball6 position and speed depending on the time
            ballPosition6 += ballSpeed6 * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Uppdatera Players Movement
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

            //Controlls that if the ball3 hit any of the sides of the window it bounces
            if (ballPosition3.X > maxX || ballPosition3.X < 0)
                ballSpeed3.X *= -1;
            if (ballPosition3.Y > maxY || ballPosition3.Y < 0)
                ballSpeed3.Y *= -1;

            //Controlls that if the ball4 hit any of the sides of the window it bounces
            if (ballPosition4.X > maxX || ballPosition4.X < 0)
                ballSpeed4.X *= -1;
            if (ballPosition4.Y > maxY || ballPosition4.Y < 0)
                ballSpeed4.Y *= -1;

            //Controlls that if the ball5 hit any of the sides of the window it bounces
            if (ballPosition5.X > maxX || ballPosition5.X < 0)
                ballSpeed5.X *= -1;
            if (ballPosition5.Y > maxY || ballPosition5.Y < 0)
                ballSpeed5.Y *= -1;

            //Controlls that if the ball6 hit any of the sides of the window it bounces
            if (ballPosition6.X > maxX || ballPosition6.X < 0)
                ballSpeed6.X *= -1;
            if (ballPosition6.Y > maxY || ballPosition6.Y < 0)
                ballSpeed6.Y *= -1;



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
                        playerPosition = defaultPlayerPos;
                    }

                    //This is the code from levelSelect to level2
                    if (keyboard.IsKeyDown(Keys.NumPad2))
                    {
                        gameState = GameStates.level2;

                        //This are codes that reset everything
                        playerScore = defaultPlayerScore;
                        playerLife = defaultPlayerLife;
                        playerPosition = defaultPlayerPos;
                    }


                    //This is the code from levelSelect to level3
                    if (keyboard.IsKeyDown(Keys.NumPad3))
                    {
                        gameState = GameStates.level3;

                        //This are codes that reset everything
                        playerScore = defaultPlayerScore;
                        playerLife = defaultPlayerLife;
                        playerPosition = defaultPlayerPos;
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
                        playerPosition = defaultPlayerPos;
                    }


                    //This is the code from Complete1 to level2;
                    if (keyboard.IsKeyDown(Keys.NumPad2))
                    {
                        gameState = GameStates.level2;

                        //This are codes that reset everything
                        playerScore = defaultPlayerScore;
                        playerLife = defaultPlayerLife;
                        playerPosition = defaultPlayerPos;
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
                        playerPosition = defaultPlayerPos;
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

                spriteBatch.Draw(ballSprite4, ballPosition4, Color.White);

                spriteBatch.Draw(ballSprite5, ballPosition5, Color.White);

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

                spriteBatch.Draw(ballSprite4, ballPosition4, Color.White);

                spriteBatch.Draw(ballSprite5, ballPosition5, Color.White);

                spriteBatch.Draw(ballSprite6, ballPosition6, Color.White);
                
                spriteBatch.DrawString(Pericles21, playerLife.ToString(), lifePosition, Color.Pink);
                spriteBatch.DrawString(Pericles21, playerScore.ToString(), playerScorePosition, Color.Red);
                
                spriteBatch.End();
            }
            base.Draw(gameTime);
            }
        }
    }

