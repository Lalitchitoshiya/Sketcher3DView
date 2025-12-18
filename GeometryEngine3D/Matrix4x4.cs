using System;

namespace GeometryEngine3D
{
    public class Matrix4x4
    {
        public double[,] M = new double[4, 4];

        public static Matrix4x4 Identity()
        {
            Matrix4x4 m = new Matrix4x4();
            for (int i = 0; i < 4; i++)
                m.M[i, i] = 1;
            return m;
        }

        public static Matrix4x4 Translation(double x, double y, double z)
        {
            var m = Identity();
            m.M[0, 3] = x;
            m.M[1, 3] = y;
            m.M[2, 3] = z;
            return m;
        }

        public static Matrix4x4 Scale(double x, double y, double z)
        {
            var m = Identity();
            m.M[0, 0] = x;
            m.M[1, 1] = y;
            m.M[2, 2] = z;
            return m;
        }

        public static Matrix4x4 RotationY(double angleDeg)
        {
            double rad = angleDeg * Math.PI / 180;
            var m = Identity();
            m.M[0, 0] = Math.Cos(rad);
            m.M[0, 2] = Math.Sin(rad);
            m.M[2, 0] = -Math.Sin(rad);
            m.M[2, 2] = Math.Cos(rad);
            return m;
        }
        public static Matrix4x4 RotationX(double angleDeg)
        {
            double rad = angleDeg * Math.PI / 180;
            var m = Identity();

            m.M[1, 1] = Math.Cos(rad);
            m.M[1, 2] = -Math.Sin(rad);
            m.M[2, 1] = Math.Sin(rad);
            m.M[2, 2] = Math.Cos(rad);

            return m;
        }

        public static Matrix4x4 RotationZ(double angleDeg)
        {
            double rad = angleDeg * Math.PI / 180;
            var m = Identity();

            m.M[0, 0] = Math.Cos(rad);
            m.M[0, 1] = -Math.Sin(rad);
            m.M[1, 0] = Math.Sin(rad);
            m.M[1, 1] = Math.Cos(rad);

            return m;
        }

        public static Matrix4x4 operator *(Matrix4x4 a, Matrix4x4 b)
        {
            Matrix4x4 r = new Matrix4x4();
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    for (int k = 0; k < 4; k++)
                        r.M[i, j] += a.M[i, k] * b.M[k, j];
            return r;
        }

        public Vector3 MultiplyPoint(Vector3 p)
        {
            double x = p.X * M[0, 0] + p.Y * M[0, 1] + p.Z * M[0, 2] + M[0, 3];
            double y = p.X * M[1, 0] + p.Y * M[1, 1] + p.Z * M[1, 2] + M[1, 3];
            double z = p.X * M[2, 0] + p.Y * M[2, 1] + p.Z * M[2, 2] + M[2, 3];
            return new Vector3(x, y, z);
        }
    }
}
