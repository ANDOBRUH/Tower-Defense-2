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

        Map map;
        Spawner spawner;


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
           
            Data.Content = Content;
            _gameManager = new();
            map = new Map();   
            spawner= new Spawner();   

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Data.SpriteBatch = _spriteBatch;

            Data.hitboxTexture = new Texture2D(GraphicsDevice, 1, 1);
            Data.hitboxTexture.SetData<Color>(new Color[] { Color.Gray * 0.5f });

            Data.towerTexture = Content.Load<Texture2D>("Tower");
            Data.enemyTexture = Content.Load<Texture2D>("RedEnemy");

            //1 hitbox
            Data.gameObjects.Add(new EnemyMovementHitbox(new Vector2(312, 127), new Rectangle(100, 100, 2, 64)));
            //2 hitbox
            Data.gameObjects.Add(new EnemyMovementHitbox(new Vector2(256, 573), new Rectangle(100, 100, 64, 2)));
            //3 hitbox
            Data.gameObjects.Add(new EnemyMovementHitbox(new Vector2(703, 512), new Rectangle(100, 100, 2, 64)));
            //4 hitbox
            Data.gameObjects.Add(new EnemyMovementHitbox(new Vector2(640, 957), new Rectangle(100, 100, 64, 2)));
            //5 hitbox
            Data.gameObjects.Add(new EnemyMovementHitbox(new Vector2(958, 897), new Rectangle(100, 100, 2, 64)));
            //6 hitbox
            Data.gameObjects.Add(new EnemyMovementHitbox(new Vector2(900, 129), new Rectangle(100, 100, 64, 2)));
            //7 hitbox
            Data.gameObjects.Add(new EnemyMovementHitbox(new Vector2(1472, 127), new Rectangle(100, 100, 2, 64)));
            //8 hitbox
            Data.gameObjects.Add(new EnemyMovementHitbox(new Vector2(1402, 830), new Rectangle(100, 100, 64, 2)));
            //9 hitbox
            Data.gameObjects.Add(new EnemyMovementHitbox(new Vector2(2002, 830), new Rectangle(100, 100, 64, 2)));

            Tile.Content = Content;

            map.Generate(new int[,]
            {
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1, 1, 1 },
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1, 1, 1 },
                {0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,0 ,1 ,1 ,1 ,1 ,1, 1, 1 },
                {1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,0 ,1 ,1 ,1 ,1 ,1, 1, 1 },
                {1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,0 ,1 ,1 ,1 ,1 ,1, 1, 1 },
                {1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,0 ,1 ,1 ,1 ,1 ,1, 1, 1 },
                {1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,0 ,1 ,1 ,1 ,1 ,1, 1, 1 },
                {1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,0 ,1 ,1 ,1 ,1 ,1, 1, 1 },
                {1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,0 ,1 ,1 ,1 ,1 ,1, 1, 1 },
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,0 ,1 ,1 ,1 ,1 ,1, 1, 1 },
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,0 ,1 ,1 ,1 ,1 ,1, 1, 1 },
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,0 ,1 ,1 ,1 ,1 ,1, 1, 1 },
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,0 ,0 ,0 ,0 ,0 ,0, 0, 0 },
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 0 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1, 1, 1 },
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1, 1, 1 },
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1, 1, 1 },
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1, 1, 1 },

            }, 64);
        }

        protected override void Update(GameTime gt)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            CollisionManager.Update();
    
            for (int i = 0; i < Data.gameObjects.Count; i++)
            {
                Data.gameObjects[i].Update(gt);
            }

            for (int i = Data.gameObjects.Count - 1; i >= 0; i--)
            {
                if (Data.gameObjects[i].isRemoved)
                    Data.gameObjects.RemoveAt(i);
            }

            spawner.Update();
            _gameManager.Update();
            Data.Update(gt);

            base.Update(gt);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SaddleBrown);

            GraphicsDevice.Clear(Color.SaddleBrown);

            _gameManager.Draw();

            _spriteBatch.Begin();
            map.Draw(_spriteBatch);

            for (int i = 0; i < Data.gameObjects.Count; i++)
            {
                Data.gameObjects[i].Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}