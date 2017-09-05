﻿using System;
using System.Collections.Generic;
using GameBaseArilox.API.Graphic;
using GameBaseArilox.API.Shapes;
using GameBaseArilox.Implementation.Shapes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameBaseArilox.Implementation.zDrawers
{
    public class ShapeDrawer : IDrawer
    {
        private Dictionary<string,Texture2D> _textures = new Dictionary<string, Texture2D>();
        private List<IShape> _shapesToDraw = new List<IShape>();


        /*-------------*/
        /* CONSTRUCTOR */
        /*-------------*/
        public ShapeDrawer(GameModel game)
        {
            game.AddToDrawers(this);
        }


        public void AddShape(IShape toAdd)
        {
            _shapesToDraw.Add(toAdd);
        }

        public void AddContent(string contentId, object content)
        {
            Texture2D texture = content as Texture2D;
            if (texture != null)
                _textures.Add(contentId, texture);
        }

        public void DrawAll(SpriteBatch spriteBatch)
        {
            foreach (IShape shape in _shapesToDraw)
            {
                DrawShape(spriteBatch, shape);
            }
        }

        public void DrawShape(SpriteBatch spriteBatch, IShape shape)
        {
            if (shape.Points.Count > 1)
            {
                for (int i = 0; i < shape.Points.Count; i++)
                {
                    for (int j = i; j < shape.Points.Count; j++)
                    {
                        ISegment segment = new Segment(shape.Points[i],shape.Points[j]);
                        DrawSegment(spriteBatch, segment);
                    }
                }
            }

            foreach (ICoordinates point in shape.Points)
            {
                DrawPoint(spriteBatch, point);
            }
        }

        public void DrawPoint(SpriteBatch spriteBatch, ICoordinates point)
        {
            Texture2D pointTexture2D;
            _textures.TryGetValue("PointTexture", out pointTexture2D);
            if(pointTexture2D == null) throw new Exception("ERROR : Texture not found in the Dictionary.");
            spriteBatch.Draw(pointTexture2D, new Vector2(point.X-1, point.Y-1), Color.White);
        }

        public void DrawSegment(SpriteBatch spriteBatch, ISegment segment)
        {
            Texture2D segmentTexture2D;
            _textures.TryGetValue("SegmentTexture", out segmentTexture2D);
            if (segmentTexture2D == null) throw new Exception("ERROR : Texture not found in the dictionary");
            spriteBatch.Draw(segmentTexture2D, new Rectangle((int)segment.Point1.X,(int)segment.Point1.Y,(int)segment.Lenght+1,1), null, Color.Black, AngleHelper.SlopeToRadian(segment.Slope),new Vector2(0,0),SpriteEffects.None, 0f );
        }
    }
}