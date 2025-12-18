using System.Collections.Generic;

namespace GeometryEngine3D
{
    public abstract class Shape
    {
        public string Name { get; protected set; }

        public abstract List<Point_3D> GetVertices();
    }
}
