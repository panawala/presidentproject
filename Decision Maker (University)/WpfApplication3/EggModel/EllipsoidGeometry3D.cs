using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace WpfApplication3.EggModel
{
    public class EllipsoidGeometry3D
    {
        public int N { get; set; }
        public double Radius { get; set; }
        public Point3DCollection Points { get; set; }
        public Int32Collection TriangleIndices { get; set; }
        public double YAxis { get; set; }
        public double XAxis { get; set; }
        public double ZAxis { get; set; }

        public double YRelative { get; set; }
        public double XRelative { get; set; }
        public double ZRelative { get; set; }

        public void CalculateGeometry()
        {
            int e;
            double segmentRad = Math.PI / 2 / (N + 1);

            Points = new Point3DCollection();
            TriangleIndices = new Int32Collection();

            for (e = -N; e <= N; e++)
            {
                double rE = Radius * Math.Cos(segmentRad * e);
                double yE = Radius * Math.Sin(segmentRad * e);

                for (int s = 0; s <= (4 * N + 4 - 1); s++)
                {
                    double zS = rE * Math.Sin(segmentRad * s) * (-1);
                    double xS = rE * Math.Cos(segmentRad * s);
                    Points.Add(new Point3D(XRelative + XAxis * xS, YRelative + YAxis * yE, ZRelative + ZAxis * zS));
                }
            }
            Points.Add(new Point3D(XRelative, YRelative + YAxis * Radius, ZRelative));
            Points.Add(new Point3D(XRelative, -1 * YAxis * Radius + YRelative, ZRelative));

            for (e = 0; e < 2 * N; e++)
            {
                for (int i = 0; i < (4 * N + 4); i++)
                {
                    TriangleIndices.Add(e * (4 * N + 4) + i);
                    TriangleIndices.Add(e * (4 * N + 4) + i + (4 * N + 4));
                    TriangleIndices.Add(e * (4 * N + 4) + (i + 1) % (4 * N + 4) + (4 * N + 4));

                    TriangleIndices.Add(e * (4 * N + 4) + (i + 1) % (4 * N + 4) + (4 * N + 4));
                    TriangleIndices.Add(e * (4 * N + 4) + (i + 1) % (4 * N + 4));
                    TriangleIndices.Add(e * (4 * N + 4) + i);
                }
            }

            for (int i = 0; i < (4 * N + 4); i++)
            {
                TriangleIndices.Add(e * (4 * N + 4) + i);
                TriangleIndices.Add(e * (4 * N + 4) + (i + 1) % (4 * N + 4));
                TriangleIndices.Add((4 * N + 4) * (2 * N + 1));
            }

            for (int i = 0; i < (4 * N + 4); i++)
            {
                TriangleIndices.Add(i);
                TriangleIndices.Add((i + 1) % (4 * N + 4));
                TriangleIndices.Add((4 * N + 4) * (2 * N + 1) + 1);
            }
        }
        public void SetRelativeCoordinate(double x, double y, double z)
        {
            XRelative = x;
            YRelative = y;
            ZRelative = z;
        }
        public EllipsoidGeometry3D(double x, double y, double z, double r, int n)
        {
            SetRelativeCoordinate(0, 0, 0);
            XAxis = x;
            YAxis = y;
            ZAxis = z;
            Radius = r;
            N = n;
        }
        public EllipsoidGeometry3D(double x, double y, double z, double r)
        {
            SetRelativeCoordinate(0, 0, 0);
            XAxis = x;
            YAxis = y;
            ZAxis = z;
            Radius = r;
            N = 40;
        }
        public EllipsoidGeometry3D(double x, double y, double z)
        {
            SetRelativeCoordinate(0, 0, 0);
            XAxis = x;
            YAxis = y;
            ZAxis = z;
            Radius = 1;
            N = 40;
        }
    }
}
