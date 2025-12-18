using System.Collections.Generic;

namespace GeometryEngine3D
{
    public class Pyramid : Shape
    {
        double size, height;

        public Pyramid(double size, double height)
        {
            Name = "Pyramid";
            this.size = size / 2;
            this.height = height;
        }

        public override List<Point_3D> GetVertices()
        {
            Point_3D top = new Point_3D(0, height, 0);

            return new List<Point_3D>
            {
                top, new Point_3D(-size, 0, -size),
                top, new Point_3D( size, 0, -size),
                top, new Point_3D( size, 0,  size),
                top, new Point_3D(-size, 0,  size),
            };
        }
    }
}
