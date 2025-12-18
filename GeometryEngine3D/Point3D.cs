namespace GeometryEngine3D
{
    public class Point_3D
    {
        public double X, Y, Z;

        public Point_3D(double x, double y, double z)
        {
            X = x; Y = y; Z = z;
        }

        public Vector3 ToVector() => new Vector3(X, Y, Z);

        public static Point_3D FromVector(Vector3 v)
            => new Point_3D(v.X, v.Y, v.Z);
    }
}
