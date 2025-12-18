using System;
using System.Collections.Generic;

namespace GeometryEngine3D
{
    public class Sphere : Shape
    {
        double radius;
        int slices = 16;

        public Sphere(double radius)
        {
            Name = "Sphere";
            this.radius = radius;
        }

        public override List<Point_3D> GetVertices()
        {
            List<Point_3D> points = new List<Point_3D>();

            for (int i = 0; i <= slices; i++)
            {
                double lat = Math.PI * i / slices;
                for (int j = 0; j <= slices; j++)
                {
                    double lon = 2 * Math.PI * j / slices;

                    double x = radius * Math.Sin(lat) * Math.Cos(lon);
                    double y = radius * Math.Cos(lat);
                    double z = radius * Math.Sin(lat) * Math.Sin(lon);

                    points.Add(new Point_3D(x, y, z));
                }
            }
            return points;
        }
    }
}
