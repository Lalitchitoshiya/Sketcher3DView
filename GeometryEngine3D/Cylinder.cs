using System;
using System.Collections.Generic;

namespace GeometryEngine3D
{
    public class Cylinder : Shape
    {
        double radius, height;
        int segments = 20;

        public Cylinder(double radius, double height)
        {
            Name = "Cylinder";
            this.radius = radius;
            this.height = height;
        }

        public override List<Point_3D> GetVertices()
        {
            List<Point_3D> pts = new List<Point_3D>();
            double h = height / 2;

            for (int i = 0; i <= segments; i++)
            {
                double angle = 2 * Math.PI * i / segments;
                double x = radius * Math.Cos(angle);
                double z = radius * Math.Sin(angle);

                pts.Add(new Point_3D(x, -h, z));
                pts.Add(new Point_3D(x, h, z));
            }
            return pts;
        }
    }
}
