using GeometryEngine3D;
using System.Collections.Generic;
using System.Xml.Linq;

namespace GeometryEngine3D
{
    public class Cube : Shape
    {
        private double size;

        public Cube(double size)
        {
            Name = "Cube";
            this.size = size;
        }

        public override List<Point_3D> GetVertices()
        { 
            double s = size / 2;

            return new List<Point_3D>
            {
                new Point_3D(-s, -s, -s),
                new Point_3D( s, -s, -s),
                new Point_3D( s,  s, -s),
                new Point_3D(-s,  s, -s),

                new Point_3D(-s, -s,  s),
                new Point_3D( s, -s,  s),
                new Point_3D( s,  s,  s),
                new Point_3D(-s,  s,  s),
            };
        }
    }
}
