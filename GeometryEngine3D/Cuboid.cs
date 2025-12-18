using System.Collections.Generic;

namespace GeometryEngine3D
{
    public class Cuboid : Shape
    {
        double w, h, d;

        public Cuboid(double width, double height, double depth)
        {
            Name = "Cuboid";
            w = width / 2;
            h = height / 2;
            d = depth / 2;
        }

        public override List<Point_3D> GetVertices()
        {
            return new List<Point_3D>
            {
                new Point_3D(-w, -h, -d),
                new Point_3D( w, -h, -d),
                new Point_3D( w,  h, -d),
                new Point_3D(-w,  h, -d),

                new Point_3D(-w, -h,  d),
                new Point_3D( w, -h,  d),
                new Point_3D( w,  h,  d),
                new Point_3D(-w,  h,  d),
            };
        }
    }
}
