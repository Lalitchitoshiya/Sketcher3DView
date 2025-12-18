namespace GeometryEngine3D
{
    public class Transform3D
    {
        public Vector3 Position = new Vector3();
        public Vector3 Rotation = new Vector3(); // degrees
        public Vector3 Scale = new Vector3(1, 1, 1);

        public Matrix4x4 GetWorldMatrix()
        {
            var t = Matrix4x4.Translation(Position.X, Position.Y, Position.Z);
            var r = Matrix4x4.RotationY(Rotation.Y);
            var s = Matrix4x4.Scale(Scale.X, Scale.Y, Scale.Z);

            return t * r * s;   // Scale → Rotate → Translate
        }
    }
}
