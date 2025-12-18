using System.Collections.Generic;

namespace GeometryEngine3D
{
    public class Cuboid : Shape
    {
        double w, h, d;

        public Cuboid(double width, double height, double depth)
        {
            w = width / 2;
            h = height / 2;
            d = depth / 2;
        }

        protected override List<Point_3D> GetLocalVertices()
        {
            return new List<Point_3D>
            {
                new Point_3D(-w,-h,-d),
                new Point_3D( w,-h,-d),
                new Point_3D( w, h,-d),
                new Point_3D(-w, h,-d),

                new Point_3D(-w,-h, d),
                new Point_3D( w,-h, d),
                new Point_3D( w, h, d),
                new Point_3D(-w, h, d),
            };
        }
    }
}
