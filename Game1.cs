using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameBoard__2_
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _whiteSquare, _blackSquare;
        int row = 1, collum = 1;
        bool draw = true;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 800;
            _graphics.ApplyChanges();
            base.Initialize();
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _whiteSquare = Content.Load<Texture2D>("Square White");
            _blackSquare = Content.Load<Texture2D>("Square Black");
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {           
            GraphicsDevice.Clear(Color.Blue);
            _spriteBatch.Begin();
            for (collum = 1; collum < 9;)
            {
                if (row%2 != 0)
                {
                    if (collum%2 != 0)
                        _spriteBatch.Draw(_whiteSquare, new Vector2(row * 100 - 100, collum * 100 - 100), Color.White);
                    else
                        _spriteBatch.Draw(_blackSquare, new Vector2(row * 100 - 100, collum * 100 - 100), Color.White);
                }
                else
                {
                    if (collum % 2 != 0)
                        _spriteBatch.Draw(_blackSquare, new Vector2(row * 100 - 100, collum * 100 - 100), Color.White);
                    else
                        _spriteBatch.Draw(_whiteSquare, new Vector2(row * 100 - 100, collum * 100 - 100), Color.White);
                }
                row++;
                if (row >= 9)
                {
                    row = 1;
                    collum++;
                }  
            }            
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}