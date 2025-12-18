using System.Collections.Generic;

namespace GeometryEngine3D
{
    public class Cube : Shape
    {
        double s;

        public Cube(double size)
        {
            s = size / 2;
        }

        protected override List<Point_3D> GetLocalVertices()
        {
            return new List<Point_3D>
            {
                new Point_3D(-s,-s,-s), new Point_3D(s,-s,-s),
                new Point_3D(s, s,-s), new Point_3D(-s, s,-s),
                new Point_3D(-s,-s, s), new Point_3D(s,-s, s),
                new Point_3D(s, s, s), new Point_3D(-s, s, s)
            };
        }
    }
}
