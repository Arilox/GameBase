﻿using GameBaseArilox.Core;
using Microsoft.Xna.Framework;

namespace GameBaseArilox.API.Shapes
{
    struct Ray2D : ILine
    {
        private ICoordinates _startPoint;
        private Angle _angleFromXAxis;

        public ICoordinates StartPoint
        {
            get
            {
                return _startPoint;
            }
            set
            {
                YAt0 = value.Y - Slope * value.X;
                _startPoint = value;
            }
        }

        public Angle AngleFromXAxis
        {
            get { return _angleFromXAxis; }
            set
            {
                Slope = AngleHelper.AngleToSlope(value);
                _angleFromXAxis = value;
            }
        }

        public bool TowardsPositive
        {
            get
            {
                return AngleFromXAxis > 270 || AngleFromXAxis < 90;
            }
            set
            {
                if (value != TowardsPositive)
                {
                    AngleFromXAxis += 180;
                }
            }
        }

        //ANGLE

        public float Slope { get; set; }
        public float YAt0 { get; set; }
        public float Root => -YAt0/Slope;

        public Ray2D(Point point, Angle angle)
        {
            _startPoint = (Vector2D) point;
            _angleFromXAxis = angle;
            Slope = AngleHelper.AngleToSlope(angle);
            YAt0 = point.Y - Slope * point.X;
        }

        public Ray2D(ICoordinates startPoint, Angle angle)
        {
            _startPoint = (Vector2D)startPoint;
            _angleFromXAxis = angle;
            Slope = AngleHelper.AngleToSlope(angle);
            YAt0 = startPoint.Y - Slope * startPoint.X;
        }
    }
}
