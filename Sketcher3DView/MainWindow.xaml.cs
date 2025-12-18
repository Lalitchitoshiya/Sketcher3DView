using GeometryEngine3D;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Sketcher3DView
{
    public partial class MainWindow : Window
    {
        // Currently selected shape
        private Shape currentShape;

        public MainWindow()
        {
            InitializeComponent();
            SetupScene();
        }

        // ================= SCENE SETUP =================
        private void SetupScene()
        {
            viewport.Children.Clear();

            viewport.Camera = new PerspectiveCamera
            {
                Position = new Point3D(6, 6, 6),
                LookDirection = new Vector3D(-6, -6, -6),
                UpDirection = new Vector3D(0, 1, 0),
                FieldOfView = 60
            };

            Model3DGroup lights = new Model3DGroup();
            lights.Children.Add(new AmbientLight(Colors.White));

            viewport.Children.Add(new ModelVisual3D
            {
                Content = lights
            });
        }

        // ================= DRAW SHAPE =================
        private void DrawShape(Shape shape)
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
                Material = new DiffuseMaterial(Brushes.LightBlue),
                BackMaterial = new DiffuseMaterial(Brushes.LightBlue)
            };

            viewport.Children.Add(new ModelVisual3D
            {
                Content = model
            });
        }

        // ================= TRIANGLES =================

        private void AddCubeTriangles(MeshGeometry3D mesh)
        {
            int[] idx =
            {
                0,1,2, 0,2,3,
                4,6,5, 4,7,6,
                0,3,7, 0,7,4,
                1,5,6, 1,6,2,
                3,2,6, 3,6,7,
                0,4,5, 0,5,1
            };

            foreach (int i in idx)
                mesh.TriangleIndices.Add(i);
        }

        private void AddPyramidTriangles(MeshGeometry3D mesh)
        {
            int[] idx =
            {
                0,1,2,
                0,2,3,
                0,3,4,
                0,4,1,
                1,4,3,
                1,3,2
            };

            foreach (int i in idx)
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

            for (int i = 1; i < mesh.Positions.Count - 2; i++)
            {
                mesh.TriangleIndices.Add(apex);
                mesh.TriangleIndices.Add(i);
                mesh.TriangleIndices.Add(i + 1);
            }
        }

        private void AddSphereTriangles(MeshGeometry3D mesh)
        {
            int slices = 16;
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

        // ================= SHAPE MENU =================

        private void Cube_Click(object sender, RoutedEventArgs e)
        {
            currentShape = new Cube(2);
            DrawShape(currentShape);
        }

        private void Cuboid_Click(object sender, RoutedEventArgs e)
        {
            currentShape = new Cuboid(3, 2, 1);
            DrawShape(currentShape);
        }

        private void Sphere_Click(object sender, RoutedEventArgs e)
        {
            currentShape = new Sphere(1.5);
            DrawShape(currentShape);
        }

        private void Pyramid_Click(object sender, RoutedEventArgs e)
        {
            currentShape = new Pyramid(2, 3);
            DrawShape(currentShape);
        }

        private void Cylinder_Click(object sender, RoutedEventArgs e)
        {
            currentShape = new Cylinder(1, 3);
            DrawShape(currentShape);
        }

        private void Cone_Click(object sender, RoutedEventArgs e)
        {
            currentShape = new Cone(1.5, 3);
            DrawShape(currentShape);
        }

        // ================= TRANSFORM MENU =================

        // Rotation handlers for X axes
        private void RotateX_Click(object sender, RoutedEventArgs e)
        {
            if (currentShape == null) return;

            currentShape.Transform.Rotation.X += 10;
            DrawShape(currentShape);
        }

        private void RotateNegX_Click(object sender, RoutedEventArgs e)
        {
            if (currentShape == null) return;

            currentShape.Transform.Rotation.X -= 10;
            DrawShape(currentShape);
        }
        
        
        // Rotation handlers for Y axes
        private void RotateY_Click(object sender, RoutedEventArgs e)
        {
            if (currentShape == null) return;

            currentShape.Transform.Rotation.Y += 10;
            DrawShape(currentShape);
        }

        private void RotateNegY_Click(object sender, RoutedEventArgs e)
        {
            if (currentShape == null) return;

            currentShape.Transform.Rotation.Y -= 10;
            DrawShape(currentShape);
        }

        // Rotation handlers for z axes
        private void RotateZ_Click(object sender, RoutedEventArgs e)
        {
            if (currentShape == null) return;

            currentShape.Transform.Rotation.Z += 10;
            DrawShape(currentShape);
        }

        private void RotateNegZ_Click(object sender, RoutedEventArgs e)
        {
            if (currentShape == null) return;

            currentShape.Transform.Rotation.Z -= 10;
            DrawShape(currentShape);
        }

        // Scale handlers
        private void ScaleUp_Click(object sender, RoutedEventArgs e)
        {
            if (currentShape == null) return;

            currentShape.Transform.Scale.X += 0.1;
            currentShape.Transform.Scale.Y += 0.1;
            currentShape.Transform.Scale.Z += 0.1;

            DrawShape(currentShape);
        }

        private void ScaleDown_Click(object sender, RoutedEventArgs e)
        {
            if (currentShape == null) return;

            currentShape.Transform.Scale.X -= 0.1;
            currentShape.Transform.Scale.Y -= 0.1;
            currentShape.Transform.Scale.Z -= 0.1;

            DrawShape(currentShape);
        }
        // Translation handlers for X axes
        private void MoveX_Click(object sender, RoutedEventArgs e)
        {
            if (currentShape == null) return;

            currentShape.Transform.Position.X += 0.2;
            DrawShape(currentShape);
        }

        private void MoveNegX_Click(object sender, RoutedEventArgs e)
        {
            if (currentShape == null) return;

            currentShape.Transform.Position.X -= 0.2;
            DrawShape(currentShape);
            
        }
        // Translation handlers for Y axes
        private void MoveY_Click(object sender, RoutedEventArgs e)
        {
            if (currentShape == null) return;

            currentShape.Transform.Position.Y += 0.2;
            DrawShape(currentShape);
        }

        private void MoveNegY_Click(object sender, RoutedEventArgs e)
        {
            if (currentShape == null) return;

            currentShape.Transform.Position.Y -= 0.2;
            DrawShape(currentShape);
        }

        // Translation handlers for z axes
        private void MoveZ_Click(object sender, RoutedEventArgs e)
        {
            if (currentShape == null) return;

            currentShape.Transform.Position.Z += 0.2;
            DrawShape(currentShape);
        }

        private void MoveNegZ_Click(object sender, RoutedEventArgs e)
        {
            if (currentShape == null) return;

            currentShape.Transform.Position.Z -= 0.2;
            DrawShape(currentShape);
        }

    }
}
