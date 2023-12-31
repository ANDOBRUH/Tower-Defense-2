﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower_Defence_2
{
    public static class InputManager
    {
        public static MouseState _lastMouseState;
        public static Vector2 lastMousePosition;
        public static bool MouseClicked { get; private set; }
        public static bool MouseRightClicked { get; private set; }
        public static Rectangle MouseRectangle { get; private set; }

        public static void Update()
        {
            var mouseState = Mouse.GetState();

            MouseClicked = mouseState.LeftButton == ButtonState.Pressed && _lastMouseState.LeftButton == ButtonState.Released;
            MouseRightClicked = mouseState.RightButton == ButtonState.Pressed && _lastMouseState.RightButton == ButtonState.Released;
            MouseRectangle = new(mouseState.Position.X, mouseState.Position.Y, 1, 1);

            _lastMouseState = mouseState;
            lastMousePosition.X = mouseState.Position.X;
            lastMousePosition.Y = mouseState.Position.Y;
        }
    }
}
