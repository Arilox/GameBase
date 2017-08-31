﻿using GameBaseArilox.API.Core;
using GameBaseArilox.API.Graphic;
using GameBaseArilox.Graphic;
using GameBaseArilox.zDrawers;
using GameBaseArilox.zLoaders;
using GameBaseArilox.zUpdaters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameBaseArilox.UnitTest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class TestSpriteEffects : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _spriteFont;

        private SpriteDrawer _spriteDrawer;
        private SpriteUpdater _spriteUpdater;
        private SpriteLoader _spriteLoader;

        private readonly ISprite _sprite;
        private readonly ISprite _sprite2;
        private readonly ISprite _sprite3;
        private readonly ISprite _sprite4;

        public TestSpriteEffects()
        {
            _graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
            _sprite = new Sprite(100,100,64,64,"SpriteTest");
            _sprite2 = new Sprite(400, 100, 64, 64, "SpriteTest");
            _sprite3 = new Sprite(100, 400, 64, 64, "SpriteTest");
            _sprite4 = new Sprite(400, 400, 64, 64, "SpriteTest");

            _spriteDrawer = new SpriteDrawer();
            _spriteUpdater = new SpriteUpdater();
            _spriteLoader = new SpriteLoader(Content,_spriteDrawer);
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

            IsMouseVisible = true;
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _spriteFont = Content.Load<SpriteFont>("FONTS/Arial12");
            _spriteLoader.LoadSpriteTest();

            IDrawableEffectOverTime d1 = new DrawableFlashingEffectOverTime(5, 50);
            IDrawableEffectOverTime d4 = new DrawableFlashingEffectOverTime(5, 7);
           
            d1.SetDrawable(_sprite);
            var d2 = new DrawableFlashingEffectOverTime(2, _sprite2, 3);
            var d3 = new DrawableFlashingEffectOverTime(3, _sprite3, 10);
            d4.SetDrawable(_sprite4);

            d2.Speed = 9;
            d3.Duration = 20;
            //NOT WORKING_sprite.AddEffect(drawableFlashingEffectOverTime);
            //NOT WORKING_sprite4.AddEffect( d2);

            _spriteDrawer.AddSprite(_sprite);
            _spriteUpdater.AddToUpdate(_sprite);

            _spriteDrawer.AddSprite(_sprite2);
            _spriteUpdater.AddToUpdate(_sprite2);

            _spriteDrawer.AddSprite(_sprite3);
            _spriteUpdater.AddToUpdate(_sprite3);

            _spriteDrawer.AddSprite(_sprite4);
            _spriteUpdater.AddToUpdate(_sprite4);
            // TODO: use this.Content to load your game content here
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            
           _spriteUpdater.Update(gameTime);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Immediate);
            _spriteDrawer.DrawAll(_spriteBatch);
            _spriteBatch.End();
            // TODO: Add your drawing code here
            
            base.Draw(gameTime);
        }
    }
}