using System;
namespace CanvasParticle
{
    public struct Point2D
    {
        public double X;
        public double Y;


        public Point2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point2D(Point2D pt)
        {
            X = pt.X;
            Y = pt.Y;
        }

        // Computes the length of this point as if it were a vector with XY components relative to the
        // origin. This is computed each time this property is accessed, so cache the value that is
        // returned.
        public double Length
        {
            get { return Math.Sqrt(X * X + Y * Y); }
        }


        public static double Distance(Point2D v1, Point2D v2)
        {
            return (v1 - v2).Length;
        }

        public static double Distance(Point2D v1, double x, double y)
        {
            Point2D v2;
            v2.X = x;
            v2.Y = y;
            return (v1 - v2).Length;
        }

        #region Operator Overloads

        public static Point2D operator -(Point2D p1, Point2D p2)
        {
            Point2D pt;
            pt.X = p1.X - p2.X;
            pt.Y = p1.Y - p2.Y;
            return pt;
        }

        #endregion

    }

}
