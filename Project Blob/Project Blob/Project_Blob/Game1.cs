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

namespace Project_Blob
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Microsoft.Xna.Framework.Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		Texture2D TileSpriteSheet;
		public List<Tiles> TileList = new List<Tiles>();
		Random rng = new Random();

		KeyboardState keyboardState, previousKeyboardState;

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

			TileSpriteSheet = Content.Load<Texture2D>(@"images\tiles");

			GenerateSquares();

			// TODO: use this.Content to load your game content here
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
			keyboardState = Keyboard.GetState();

			// Allows the game to exit
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
				this.Exit();

			if (keyboardState.IsKeyUp(Keys.F5) && previousKeyboardState.IsKeyDown(Keys.F5))
			{
				TileList.RemoveRange(0, TileList.Count);

				GenerateSquares();
			}

			// TODO: Add your update logic here

			base.Update(gameTime);

			previousKeyboardState = keyboardState;
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here

			spriteBatch.Begin();
				foreach (Tiles t in TileList)
				{
					t.Draw(gameTime, spriteBatch);
				}
			spriteBatch.End();

			base.Draw(gameTime);
		}

		protected void GenerateSquares()
		{
			for (int x = 0; x < 8; x++)
			{
				for (int y = 0; y < 8; y++)
				{
					TileList.Add(new Tiles(TileSpriteSheet, new Vector2(30 * x, 30 * y), Color.White, rng.Next(5)));
				}
			}
		}
	}
}
