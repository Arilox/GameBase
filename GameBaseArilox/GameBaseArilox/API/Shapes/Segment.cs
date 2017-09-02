﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using GameBaseArilox.Core;
using Microsoft.Xna.Framework;
using static System.Single;

namespace GameBaseArilox.API.Shapes
{
    public struct Segment : ISegment
    {
        private Vector2D _point1;
        private Vector2D _point2;
        private List<ICoordinates> _points;

        public ICoordinates Point1
        {
            get
            {
                return _point1;
            }
            set
            {
                if (value.X > _point2.X)
                {
                    _point1 = _point2;
                    _point2 = new Vector2D(value.X,value.Y);
                }
                _point1 = new Vector2D(value.X, value.Y);

            }
        }

        public ICoordinates Point2
        {
            get
            {
                return _point2;
            }
            set
            {
                if (value.X < _point1.X)
                {
                    _point2 = _point1;
                    _point1 = new Vector2D(value.X, value.Y);
                }
                _point1 = new Vector2D(value.X, value.Y);
            }
        }

        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator")]
        public float Slope
        {
            get
            {
                if (Point1.X == Point2.X) return 0;
                if(Point2.Y != Point1.Y)
                    return (Point2.Y - Point1.Y) / (Point2.X - Point1.X);
                return PositiveInfinity;
            }
            set { }
        }

        public float YAt0
        {
            get { return Slope*Point1.X - Point1.Y; }
            set { }
        }

        public float Root => -YAt0 / Slope;


        public float Top => MathHelper.Max(Point1.Y, Point2.Y);
        public float Bot => MathHelper.Min(Point1.Y, Point2.Y);
        public float Right => MathHelper.Max(Point1.X, Point2.X);
        public float Left => MathHelper.Min(Point1.X, Point2.X);

        public List<ICoordinates> Points
        {
            get { return _points; }
            set
            {
                if (value.Count != 2) return;
                if (value[0].X > value[1].X)
                {
                    Point1 = value[1];
                    Point2 = value[0];
                }
                Point1 = value[0];
                Point2 = value[1];
                _points = new List<ICoordinates>
                {
                    Point1,Point2
                };
            }
        }

        public ICoordinates Center => new Vector2D((Point1.X+Point2.X)/2f,(Point1.Y+Point2.Y)/2f);

        public double Lenght => ShapesHelper.DistanceBetween(Point1,Point2);

        public Segment(Point point1, Point point2)
        {
            if (point1.X > point2.X)
            {

                _point1 = (Vector2D) point2;
                _point2 = (Vector2D) point1;
            }
            else
            {
                _point1 = (Vector2D)point1;
                _point2 = (Vector2D)point2;
            }
            _points = new List<ICoordinates>
            {
                _point1,_point2
            };
        }

        public Segment(Vector2 point1, Vector2 point2)
        {
            _point1 = (Vector2D)point1;
            _point2 = (Vector2D)point2;
            _points = new List<ICoordinates>
            {
                _point1,_point2
            };
        }
    }
}
