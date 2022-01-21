using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace InputExample
{
    public class InputManager
    {

        KeyboardState currentKeyboadState;
        KeyboardState priorKeyboadState;

        MouseState currentMouseState;
        MouseState priorMouseState;

        GamePadState currentGamePadState;
        GamePadState priorGamePadState;
        /// <summary>
        /// The current direction
        /// </summary>
        public Vector2 Direction { get; private set; }
        /// <summary>
        /// warp functionality has been requested
        /// </summary>
        public bool Warp { get; private set; }
        /// <summary>
        /// user can end the game
        /// </summary>
        public bool Exit { get; private set; } = false;

        public void Update(GameTime gameTime)
        {
            #region Set States
            priorKeyboadState = currentKeyboadState;
            currentKeyboadState = Keyboard.GetState();

            priorMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            priorGamePadState = currentGamePadState;
            currentGamePadState = GamePad.GetState(0);
            #endregion

            #region Mouse Input
            //get position from Mouse
            //Direction = new Vector2(currentMouseState.X, currentMouseState.Y) * - 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            #endregion

            #region Keyboard input
            //get position from keyboard
            if (currentKeyboadState.IsKeyDown(Keys.Left) || currentKeyboadState.IsKeyDown(Keys.A))
            {
                Direction += new Vector2(-100 * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
            }
                
            if (currentKeyboadState.IsKeyDown(Keys.Right) || currentKeyboadState.IsKeyDown(Keys.D))
            {
                Direction += new Vector2(100 * (float)gameTime.ElapsedGameTime.TotalSeconds, 0);
            }
                
            if (currentKeyboadState.IsKeyDown(Keys.Up) || currentKeyboadState.IsKeyDown(Keys.W))
            {
                Direction += new Vector2(0, -100 * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }
                
            if (currentKeyboadState.IsKeyDown(Keys.Down) || currentKeyboadState.IsKeyDown(Keys.S))
            {
                Direction += new Vector2(0, 100 * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }
                
            #endregion

            #region GamePad input
            //get position from gamepad
            Direction += currentGamePadState.ThumbSticks.Left * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            #endregion

            #region Warp Input
            //warping
            Warp = false;
            if (currentMouseState.LeftButton == ButtonState.Pressed && priorMouseState.LeftButton == ButtonState.Released)
                Warp = true;
            if (currentGamePadState.IsButtonDown(Buttons.A) && priorGamePadState.IsButtonUp(Buttons.A))
                Warp = true;
            if (priorKeyboadState.IsKeyUp(Keys.Space) && currentKeyboadState.IsKeyDown(Keys.Space))
                Warp = true;
            #endregion

            #region Exit Input
            if (currentGamePadState.Buttons.Back == ButtonState.Pressed || currentKeyboadState.IsKeyDown(Keys.Escape))
                Exit = true;
            #endregion
        }


    }
}
