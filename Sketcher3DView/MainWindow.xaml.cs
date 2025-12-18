using GeometryEngine3D;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Sketcher3DView
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetupScene();
        }
        private void Sphere_Click(object sender, RoutedEventArgs e)
        {
            DrawShape(new Sphere(1.5));
        }

        // ================= SCENE =================
        private void SetupScene()
        {
            viewport.Children.Clear();

            viewport.Camera = new PerspectiveCamera
            {
                Position = new Point3D(5, 5, 5),
                LookDirection = new Vector3D(-5, -5, -5),
                UpDirection = new Vector3D(0, 1, 0),
                FieldOfView = 60
            };

            Model3DGroup lights = new Model3DGroup();
            lights.Children.Add(new AmbientLight(Colors.White));

            viewport.Children.Add(new ModelVisual3D { Content = lights });
        }

        // ================= DRAW SHAPE =================
        private void DrawShape(GeometryEngine3D.Shape shape)
        {
            SetupScene();

            MeshGeometry3D mesh = new MeshGeometry3D();

            foreach (var p in shape.GetVertices())
            {
                mesh.Positions.Add(new Point3D(p.X, p.Y, p.Z));
            }

            if (shape is Cube || shape is Cuboid)
                AddCubeTriangles(mesh);
            else if (shape is Pyramid)
                AddPyramidTriangles(mesh);
            else if (shape is Cylinder)
                AddCylinderTriangles(mesh);
            else if (shape is Cone)
                AddConeTriangles(mesh);
            else if (shape is Sphere)
                AddSphereTriangles(mesh);

            GeometryModel3D model = new GeometryModel3D
            {
                Geometry = mesh,
                Material = new DiffuseMaterial(new SolidColorBrush(Colors.LightBlue)),
                BackMaterial = new DiffuseMaterial(new SolidColorBrush(Colors.LightBlue))
            };

            viewport.Children.Add(new ModelVisual3D { Content = model });
        }

        // ================= TRIANGLES =================

        private void AddCubeTriangles(MeshGeometry3D mesh)
        {
            int[] indices =
            {
                0,1,2, 0,2,3,       // Front
                4,6,5, 4,7,6,       // Back
                0,3,7, 0,7,4,       // Left
                1,5,6, 1,6,2,       // Right
                3,2,6, 3,6,7,       // Top
                0,4,5, 0,5,1        // Bottom
            };

            foreach (int i in indices)
                mesh.TriangleIndices.Add(i);
        }

        private void AddPyramidTriangles(MeshGeometry3D mesh)
        {
            int[] indices =
            {
                0,1,2,
                0,2,3,
                0,3,4,
                0,4,1,
                1,4,3,
                1,3,2
            };

            foreach (int i in indices)
                mesh.TriangleIndices.Add(i);
        }

        private void AddCylinderTriangles(MeshGeometry3D mesh)
        {
            int segments = mesh.Positions.Count / 2;

            for (int i = 0; i < segments - 1; i++)
            {
                int b1 = i * 2;
                int t1 = b1 + 1;
                int b2 = b1 + 2;
                int t2 = b1 + 3;

                mesh.TriangleIndices.Add(b1);
                mesh.TriangleIndices.Add(t1);
                mesh.TriangleIndices.Add(t2);

                mesh.TriangleIndices.Add(b1);
                mesh.TriangleIndices.Add(t2);
                mesh.TriangleIndices.Add(b2);
            }
        }

        private void AddConeTriangles(MeshGeometry3D mesh)
        {
            int apex = 0;

            for (int i = 1; i < mesh.Positions.Count - 2; i += 2)
            {
                mesh.TriangleIndices.Add(apex);
                mesh.TriangleIndices.Add(i);
                mesh.TriangleIndices.Add(i + 2);
            }
        }


        private void AddSphereTriangles(MeshGeometry3D mesh)
        {
            int slices = 16; // MUST match Sphere.cs
            int stacks = 16;

            for (int stack = 0; stack < stacks; stack++)
            {
                for (int slice = 0; slice < slices; slice++)
                {
                    int first = (stack * (slices + 1)) + slice;
                    int second = first + slices + 1;

                    mesh.TriangleIndices.Add(first);
                    mesh.TriangleIndices.Add(second);
                    mesh.TriangleIndices.Add(first + 1);

                    mesh.TriangleIndices.Add(second);
                    mesh.TriangleIndices.Add(second + 1);
                    mesh.TriangleIndices.Add(first + 1);
                }
            }
        }

        // ================= BUTTON EVENTS =================

        private void Cube_Click(object sender, RoutedEventArgs e)
        {
            DrawShape(new Cube(2));
        }

        private void Cuboid_Click(object sender, RoutedEventArgs e)
        {
            DrawShape(new Cuboid(3, 2, 1));
        }

        private void Pyramid_Click(object sender, RoutedEventArgs e)
        {
            DrawShape(new Pyramid(2, 3));
        }

        private void Cylinder_Click(object sender, RoutedEventArgs e)
        {
            DrawShape(new Cylinder(1, 3));
        }

        private void Cone_Click(object sender, RoutedEventArgs e)
        {
            DrawShape(new Cone(1.5, 3));
        }
    }
}



