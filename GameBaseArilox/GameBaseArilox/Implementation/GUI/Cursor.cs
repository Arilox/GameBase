﻿using GameBaseArilox.API.Detection;
using GameBaseArilox.API.Environment;
using GameBaseArilox.API.Graphic;
using GameBaseArilox.Implementation.Graphic;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.Implementation.GUI
{
    public class Cursor : IDisplayed, IGameElement, IScreenPositioned
    {
        private int _x;
        private int _y;

        public ISprite Sprite { get; set; }
        public IDetectionArea Hitbox { get; set; }

        public Point ScreenPosition
        {
            get
            {
                return new Point(_x, _y);
            }
            set
            {
                Sprite.ScreenPosition = value;
                _x = value.X;
                _y = value.Y;
            }
        }

        public Vector2 Position
        {
            get
            {
                return new Vector2(_x,_y);
            }
            set
            {
                Sprite.Position = value;
                _x = (int)value.X;
                _y = (int)value.Y;
            }
        }

        public Cursor(GameModel game)
        {
            Sprite = new Sprite(0, 0, 32, 32, "Cursor2", Vector2.Zero, null ,0.5f);
            game.AddDrawable(Sprite);
        }
    }
}
