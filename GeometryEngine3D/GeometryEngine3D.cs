using System.Collections.Generic;

namespace GeometryEngine3D
{
    public class GeometryEngines
    {
        private List<Shape> shapes = new List<Shape>();

        public void AddShape(Shape shape)
        {
            shapes.Add(shape);
        }

        public List<Shape> GetAllShapes()
        {
            return shapes;
        }
    }
}
