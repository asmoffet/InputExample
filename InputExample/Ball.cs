using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace InputExample
{
    class Ball
    {
        /// <summary>
        /// random number generator
        /// </summary>
        Random random;

        /// <summary>
        /// the game the ball is associated with
        /// </summary>
        Game game;

        /// <summary>
        /// color of the ball
        /// </summary>
        Color color;

        /// <summary>
        /// the ball's texture
        /// </summary>
        Texture2D texture;

        /// <summary>
        /// the balls position
        /// </summary>
        public Vector2 Position { get; set; }

        public Ball(Game game, Color color)
        {
            this.game = game;
            this.color = color;
            this.random = new Random();
        }

        public void LoadContent()
        {
            texture = game.Content.Load<Texture2D>("circle");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (texture is null) throw new InvalidOperationException("Texture Missing");
            spriteBatch.Draw(texture, Position, color);
        }

        /// <summary>
        /// moves the ball to a random position
        /// </summary>
        public void Warp()
        {
            Position = new Vector2((float)random.NextDouble() * game.GraphicsDevice.Viewport.Width, 
                (float)random.NextDouble() * game.GraphicsDevice.Viewport.Height);
        }
    }
}
