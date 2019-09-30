﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using RandomchaosMGBase.BaseClasses;
using RandomchaosMGBase.InputManagers;

namespace RandomchaosMGFire
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;

        KeyboardStateManager kbm;
        Base3DCamera camera;

        RCLayeredFire Fire3D;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.GraphicsProfile = GraphicsProfile.HiDef;

            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;

            IsMouseVisible = true;

            kbm = new KeyboardStateManager(this);

            camera = new Base3DCamera(this, .5f, 20000);
            camera.Position = new Vector3(0, 0, 10);
            Components.Add(camera);
            Services.AddService(typeof(Base3DCamera), camera);

            Fire3D = new RCLayeredFire(this, 8);
            Fire3D.Scale = new Vector3(2, 6, 8);
            Fire3D.AnimationSpeed = .01f;
            Fire3D.FlameOffSet = .2f;

            Components.Add(Fire3D);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

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

            font = Content.Load<SpriteFont>("Fonts/hudFont");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            kbm.PreUpdate(gameTime);

            base.Update(gameTime);

            if (kbm.KeyPress(Keys.Space))
            { }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || kbm.KeyDown(Keys.Escape))
                Exit();

            // Camera controls..
            float speedTran = .1f;
            float speedRot = .01f;

            if (kbm.KeyDown(Keys.W) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0)
                camera.Translate(Vector3.Forward * speedTran);
            if (kbm.KeyDown(Keys.S) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < 0)
                camera.Translate(Vector3.Backward * speedTran);
            if (kbm.KeyDown(Keys.A) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < 0)
                camera.Translate(Vector3.Left * speedTran);
            if (kbm.KeyDown(Keys.D) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0)
                camera.Translate(Vector3.Right * speedTran);

            if (kbm.KeyDown(Keys.Left) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X < 0)
                camera.Rotate(Vector3.Up, speedRot);
            if (kbm.KeyDown(Keys.Right) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X > 0)
                camera.Rotate(Vector3.Up, -speedRot);
            if (kbm.KeyDown(Keys.Up) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y > 0)
                camera.Rotate(Vector3.Right, speedRot);
            if (kbm.KeyDown(Keys.Down) || GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y < 0)
                camera.Rotate(Vector3.Right, -speedRot);

            if (kbm.KeyDown(Keys.R))
                Fire3D.NoiseFrequency += .001f;
            if (kbm.KeyDown(Keys.F))
                Fire3D.NoiseFrequency -= .001f;

            if (kbm.KeyDown(Keys.T))
                Fire3D.NoiseStrength += .001f;
            if (kbm.KeyDown(Keys.G))
                Fire3D.NoiseStrength -= .001f;

            if (kbm.KeyDown(Keys.Y))
                Fire3D.TimeScale += .01f;
            if (kbm.KeyDown(Keys.H))
                Fire3D.TimeScale -= .01f;

            if(kbm.KeyDown(Keys.U))
                Fire3D.AnimationSpeed += .0001f;
            if (kbm.KeyDown(Keys.J))
                Fire3D.AnimationSpeed -= .0001f;

            if (kbm.KeyDown(Keys.I))
                Fire3D.Color = SetColor(Fire3D.Color.ToVector4() + new Vector4(0.01f,0,0,1));
            if (kbm.KeyDown(Keys.K))
                Fire3D.Color = SetColor(Fire3D.Color.ToVector4() - new Vector4(0.01f, 0, 0, 1));

            if (kbm.KeyDown(Keys.O))
                Fire3D.Color = SetColor(Fire3D.Color.ToVector4() + new Vector4(0, 0.01f, 0, 1));
            if (kbm.KeyDown(Keys.L))
                Fire3D.Color = SetColor(Fire3D.Color.ToVector4() - new Vector4(0, 0.01f, 0, 1));

            if (kbm.KeyDown(Keys.P))
                Fire3D.Color = SetColor(Fire3D.Color.ToVector4() + new Vector4(0, 0, 0.01f, 1));
            if (kbm.KeyDown(Keys.OemSemicolon))
                Fire3D.Color = SetColor(Fire3D.Color.ToVector4() - new Vector4(0, 0, 0.01f, 1));

            Fire3D.NoiseFrequency = MathHelper.Clamp(Fire3D.NoiseFrequency, 0, 1);
            Fire3D.NoiseStrength = MathHelper.Clamp(Fire3D.NoiseStrength, 0, 1);
            Fire3D.TimeScale = MathHelper.Clamp(Fire3D.TimeScale, 0, 2);
            Fire3D.AnimationSpeed = MathHelper.Clamp(Fire3D.AnimationSpeed, 0, 1);
        }

        protected Color SetColor(Vector4 newC)
        {
            return new Color(Vector4.Clamp(newC, Vector4.Zero, Vector4.One));
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);

            line = 0;

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearWrap, DepthStencilState.Default, RasterizerState.CullCounterClockwise);
            WriteLine("Camera Controls: [WASD - Translate] [Arrow Keys - Rotate]", Color.Gold);
            WriteLine($"[R/F] - Flame Noise Frequency +- {Fire3D.NoiseFrequency}", Color.Gold);
            WriteLine($"[T/G] - Flame Noise Strength +- {Fire3D.NoiseStrength}", Color.Gold);
            WriteLine($"[Y/H] - Flame Time Scale +- {Fire3D.TimeScale}", Color.Gold);
            WriteLine($"[U/J] - Flame Animation Speed +- {Fire3D.AnimationSpeed}", Color.Gold);
            WriteLine($"[I/K] - Flame Color (R) +- : {Fire3D.Color.ToVector4().X}", Color.LimeGreen);
            WriteLine($"[O/L] - Flame Color (G) +- : {Fire3D.Color.ToVector4().Y}", Color.LimeGreen);
            WriteLine($"[P/;] - Flame Color (B) +- : {Fire3D.Color.ToVector4().Z}", Color.LimeGreen);
            spriteBatch.End();
        }

        int line = 0;
        protected void WriteLine(string msg, Color color)
        {
            spriteBatch.DrawString(font, msg, new Vector2(8, 8 + (font.LineSpacing * line)), Color.Gold);
            line++;
        }
    }
}
