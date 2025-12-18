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

        private void DrawShape(GeometryEngine3D.Shape shape)
        {
            SetupScene();

            MeshGeometry3D mesh = new MeshGeometry3D();

            foreach (var p in shape.GetVertices())
            {
                mesh.Positions.Add(new Point3D(p.X, p.Y, p.Z));
            }

            for (int i = 0; i < mesh.Positions.Count - 2; i += 3)
            {
                mesh.TriangleIndices.Add(i);
                mesh.TriangleIndices.Add(i + 1);
                mesh.TriangleIndices.Add(i + 2);
            }

            GeometryModel3D model = new GeometryModel3D
            {
                Geometry = mesh,
                Material = new DiffuseMaterial(new SolidColorBrush(Colors.LightBlue))
            };

            viewport.Children.Add(new ModelVisual3D { Content = model });
        }

        private void Cube_Click(object sender, RoutedEventArgs e)
        {
            DrawShape(new Cube(2));
        }

        private void Cuboid_Click(object sender, RoutedEventArgs e)
        {
            DrawShape(new Cuboid(3, 2, 1));
        }

        private void Sphere_Click(object sender, RoutedEventArgs e)
        {
            DrawShape(new Sphere(1.5));
        }

        private void Cylinder_Click(object sender, RoutedEventArgs e)
        {
            DrawShape(new Cylinder(1, 3));
        }

        private void Cone_Click(object sender, RoutedEventArgs e)
        {
            DrawShape(new Cone(1.5, 3));
        }

        private void Pyramid_Click(object sender, RoutedEventArgs e)
        {
            DrawShape(new Pyramid(2, 3));
        }
    }
}
