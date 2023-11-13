using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tower_Defence_2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GameManager _gameManager;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferHeight = Data.bufferHeight;
            _graphics.PreferredBackBufferWidth = Data.bufferWidth;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            TileMap.CreateMap(100, 100);
            Data.Content = Content;
            _gameManager = new();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Data.SpriteBatch = _spriteBatch;

            Data.hitboxTexture = new Texture2D(GraphicsDevice, 1, 1);
            Data.hitboxTexture.SetData<Color>(new Color[] { Color.Gray * 1f });

            Data.towerTexture = Content.Load<Texture2D>("Tower");

            Data.gameObjects.Add(new Tile(TileMap.tileSpawnPosition));
        }

        protected override void Update(GameTime gt)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            CollisionManager.Update();


            if (InputManager.MouseClicked)
            {
                Data.gameObjects.Add(new Tile(TileMap.tileSpawnPosition));
                TileMap.tileSpawnPosition.X += 50;
            }

            for (int i = 0; i < Data.gameObjects.Count; i++)
            {
                Data.gameObjects[i].Update(gt);
            }

            for (int i = Data.gameObjects.Count - 1; i >= 0; i--)
            {
                if (Data.gameObjects[i].isRemoved)
                    Data.gameObjects.RemoveAt(i);
            }

            _gameManager.Update();
            Data.Update(gt);

            base.Update(gt);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            GraphicsDevice.Clear(Color.CornflowerBlue);

            _gameManager.Draw();

            _spriteBatch.Begin();
            for (int i = 0; i < Data.gameObjects.Count; i++)
            {
                Data.gameObjects[i].Draw(_spriteBatch);
            }


            for (int x = 0; x < TileMap.map.GetLength(0); x++)
            {
                for (int y = 0; y < TileMap.map.GetLength(1); y++)
                {
                    TileMap.map[x, y].Draw(_spriteBatch);
                }
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}