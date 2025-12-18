using System.Collections.Generic;

namespace GeometryEngine3D
{
    public abstract class Shape
    {
        public Transform3D Transform = new Transform3D();

        protected abstract List<Point_3D> GetLocalVertices();

        public List<Point_3D> GetVertices()
        {
            var result = new List<Point_3D>();
            var world = Transform.GetWorldMatrix();

            foreach (var p in GetLocalVertices())
            {
                var v = world.MultiplyPoint(p.ToVector());
                result.Add(Point_3D.FromVector(v));
            }
            return result;
        }
    }
}
