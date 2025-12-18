using System;
using System.Collections.Generic;

namespace GeometryEngine3D
{
    public class Sphere : Shape
    {
        double radius;
        int slices = 16;
        int stacks = 16;

        public Sphere(double radius)
        {
            this.radius = radius;
        }

        protected override List<Point_3D> GetLocalVertices()
        {
            List<Point_3D> pts = new List<Point_3D>();

            for (int stack = 0; stack <= stacks; stack++)
            {
                double phi = Math.PI * stack / stacks;

                for (int slice = 0; slice <= slices; slice++)
                {
                    double theta = 2 * Math.PI * slice / slices;

                    double x = radius * Math.Sin(phi) * Math.Cos(theta);
                    double y = radius * Math.Cos(phi);
                    double z = radius * Math.Sin(phi) * Math.Sin(theta);

                    pts.Add(new Point_3D(x, y, z));
                }
            }

            return pts;
        }
    }
}
