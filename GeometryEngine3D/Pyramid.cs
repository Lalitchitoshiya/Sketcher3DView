using System.Collections.Generic;

namespace GeometryEngine3D
{
    public class Pyramid : Shape
    {
        double size, height;

        public Pyramid(double baseSize, double height)
        {
            size = baseSize / 2;
            this.height = height;
        }

        protected override List<Point_3D> GetLocalVertices()
        {
            return new List<Point_3D>
            {
                new Point_3D(0, height, 0),          // Apex
                new Point_3D(-size, 0, -size),
                new Point_3D( size, 0, -size),
                new Point_3D( size, 0,  size),
                new Point_3D(-size, 0,  size)
            };
        }
    }
}
