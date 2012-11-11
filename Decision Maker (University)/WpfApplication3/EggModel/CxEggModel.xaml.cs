using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Media3D;
using System.Windows.Threading;
using System.Windows.Forms;
using Primitive3DSurfaces;
using _3DTools;
using System.Threading;
using MessageBox = System.Windows.MessageBox;
using WpfApplication3.Control;


namespace WpfApplication3.EggModel
{
    /// <summary>
    /// CxEggModel.xaml 的交互逻辑
    /// </summary>
    public partial class CxEggModel : System.Windows.Controls.UserControl
    {
        //SphereOnEvent sphere1;
        //SphereOnEvent sphere2;
        //SphereOnEvent sphere3;
        private WpfApplication3.Enum.MapState myState = WpfApplication3.Enum.MapState.None;
        DispatcherTimer tm;
        int direction = 0;
        Window floatWindow = new Window();
        List<Point3D> list = new List<Point3D>();
        List<Point3D> endList = new List<Point3D>();
        List<double> allValue = new List<double>();
        double warnValue;
        /// <summary>
        /// Parent Window
        /// </summary>
        private Window _thisParent = new Window();

        /// <summary>
        /// Parent Window Attribute
        /// </summary>
        public Window ThisParent
        {
            get { return _thisParent; }
        }

        public CxEggModel(string name, string city, int year)
        {
            list.Clear();
            InitializeComponent();
            SetWindowProperty();
            SetFloatWindowProperty();
            //SetOnePlace(name, city,year);
            _currentYear = year;
            _place = name;
            _city = city;
            _currentEgg = 1;
            InitiateViewPort();
            labelCity.Content = _place;
            //InitializeEggModel(name,city);
        }
        public CxEggModel(string name, string city)
        {
            list.Clear();
            InitializeComponent();
            SetWindowProperty();

            SetFloatWindowProperty();
            //SetAllPlaceEx(name, city);
            _place = name;
            _city = city;
            _currentEgg = 2;
            InitiateViewPort();
            labelCity.Content = _place;
            //InitializeEggModel(name,city);
        }

        /// <summary>
        /// Initiallize Egg  Model
        /// </summary>
        /// <author>Shen Yongyuan</author>
        /// <date>20091114</date>
        private void InitializeEggModel(string place, string city)
        {

        }





        /// <summary>
        /// Show Egg Model
        /// </summary>
        /// <author>Shen Yongyuan</author>
        /// <date>20091111</date>
        public void Show()
        {
            this.ThisParent.Show();
        }

        /// <summary>
        /// Show Modal Egg Model
        /// </summary>
        /// <author>Shen Yongyuan</author>
        /// <date>20091111</date>
        public void ShowDialog()
        {
            this.ThisParent.ShowDialog();
        }

        /// <summary>
        /// Set Parent Window Attribute
        /// </summary>
        /// <author>Shen Yongyuan</author>
        /// <date>20091111</date>
        private void SetWindowProperty()
        {
            this.ThisParent.AllowsTransparency = true;
            this.ThisParent.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.ThisParent.WindowStyle = WindowStyle.None;
            this.ThisParent.Topmost = true;
            this.ThisParent.ShowInTaskbar = false;
            this.ThisParent.Background = null;
            this.ThisParent.SizeToContent = SizeToContent.WidthAndHeight;
            this.ThisParent.Content = this;
            titleBarText.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(Title_MouseLeftButtonDown);
            //this.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(Title_MouseLeftButtonDown);
        }

        /// <summary>
        /// Set Float Window Attribute
        /// </summary>
        /// <author>Huang Xiao</author>
        /// <date>20091111</date>
        private void SetFloatWindowProperty()
        {
            this.floatWindow.AllowsTransparency = true;
            //this.floatWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.floatWindow.WindowStyle = WindowStyle.None;
            this.floatWindow.Topmost = true;
            this.floatWindow.ShowInTaskbar = false;
            this.floatWindow.SizeToContent = SizeToContent.WidthAndHeight;
            this.floatWindow.Background = Brushes.White;

        }
        /// <summary>
        /// Mouse Left Button to Drag Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Shen Yongyuan</author>
        /// <date>20091111</date>
        void Title_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            (this.ThisParent as Window).DragMove();
        }

        /// <summary>
        /// Close Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Shen Yongyuan</author>
        /// <date>20091111</date>
        private void closeButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.ThisParent.Hide();
            this.ThisParent.Close();
        }
        /// <summary>
        /// explain egg model
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CxExplain helpcontent = CxExplain.getInstance();
            if (myState == WpfApplication3.Enum.MapState.Egg)
            {
                helpcontent.SetContent("该球的三维坐标分别代表生态、经济、社会的指标或者发展趋势，其中的一个点定位一个综合指标值");
                helpcontent.Show();
            }
            else if (myState == WpfApplication3.Enum.MapState.Egg2)
            {
                helpcontent.SetContent("该球的三维坐标分别代表生态、经济、社会的指标或者发展趋势，其中的一个点定位一个综合指标值变化率");
                helpcontent.Show();
            }
        }

        /// <summary>
        /// Egg Model Mouse Wheel Navigate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Shen Yongyuan</author>
        /// <date>20091111</date>
        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var p = (Point3D)((PerspectiveCamera)MyViewport.Camera).Position;
            if (e.Delta > 0)
            {
                p.X += 0.5;
                p.Y += 0.5;
                p.Z += 0.5;
            }
            else
            {
                p.X -= 0.5;
                p.Y -= 0.5;
                p.Z -= 0.5;
            }
            ((PerspectiveCamera)MyViewport.Camera).Position = p;
            _perspectiveCamera2.Position = p;
        }

        private SphereOnEvent p0;
        public void drawPoint1Ex(Point3D o, int id, bool isRed)
        {
            Color c = Colors.Green;
            if (isRed)
                c = Colors.Red;
            MyViewport.Children.Remove(p0);
            p0 = new SphereOnEvent(o, 0.05, c, 1, id);

            p0.MouseDown += new MouseButtonEventHandler(p0_MouseDown);
            p0.MouseEnter += new System.Windows.Input.MouseEventHandler(p1_MouseCover);
            p0.MouseLeave += new System.Windows.Input.MouseEventHandler(p1_MouseLeave);

            MyViewport.Children.Insert(0, p0);
            //MyViewport.Children.Insert(0, p0);

        }
        /// <summary>
        /// Draw Point
        /// </summary>
        /// <param name="o"></param>
        /// <param name="id"></param>
        /// <author>Shen Yongyuan</author>
        /// <date>20100123</date>
        public void drawPoint1(Point3D o, int id)
        {
            Color c;
            double distance = Math.Sqrt(o.X * o.X + o.Y * o.Y + o.Z * o.Z);
            if (distance < warnValue)
            {
                c = Colors.Green;
                id = 10000 + id;
            }
            else if (distance < 0.95)
            {
                c = Colors.Yellow;
                id = 20000 + id;
            }
            else
            {
                c = Colors.Red;
                id = 30000 + id;
            }
            var p0 = new SphereOnEvent(o, 0.05, c, 1, id);

            p0.MouseDown += new MouseButtonEventHandler(p0_MouseDown);
            p0.MouseEnter += new System.Windows.Input.MouseEventHandler(p1_MouseCover);
            p0.MouseLeave += new System.Windows.Input.MouseEventHandler(p1_MouseLeave);

            //MyViewport.Children.Insert(0, p0);
            //Viewport3D2.Children.Insert(0,p0);

        }
        //潘伟龙 新加
        private void addGm(Model3DGroup model3DGroup, Brush brush, string position, Color color)
        {
            GeometryModel3D geometryModel3D = new GeometryModel3D();
            model3DGroup.Children.Add(geometryModel3D);


            MeshGeometry3D meshGeometry3D = new MeshGeometry3D();
            //meshGeometry3D.Positions = ((Point3DCollection)new Point3DCollectionConverter().ConvertFromString("-1,1,1 -1,-1,1 1,-1,1 1,1,1"));
            meshGeometry3D.Positions = ((Point3DCollection)new Point3DCollectionConverter().ConvertFromString(position));
            meshGeometry3D.TriangleIndices = ((Int32Collection)new Int32CollectionConverter().ConvertFromString("0,1,2 0,2,3"));
            //meshGeometry3D.TextureCoordinates = ((PointCollection)new PointCollectionConverter().ConvertFromString("0,0 0,1 1,1 1,0"));
            geometryModel3D.Geometry = meshGeometry3D;

            DiffuseMaterial diffuseMaterial = new DiffuseMaterial();
            geometryModel3D.Material = diffuseMaterial;
            DiffuseMaterial diffuseMaterialback = new DiffuseMaterial();
            //geometryModel3D.BackMaterial = diffuseMaterialback;

            //VisualBrush VisualBrush1 = new VisualBrush();

            diffuseMaterialback.Brush = brush;
            SolidColorBrush scb = new SolidColorBrush(color);
            scb.Opacity = 0.3;
            diffuseMaterial.Brush = scb;
            //Label Label1 = new Label();
            //Label1.Content = "Razan";
            //Label1.Foreground = new SolidColorBrush(Colors.Orchid);
            //Label1.Background = GetRectangleDrawingBrush();
            //VisualBrush1.Visual = Label1;   
        }
        void p0_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SphereOnEvent p = sender as SphereOnEvent;
            string content = "";
            int year = p.Id;
            //int rend = p.Id / 10000;
            string stryear = year.ToString();
            if (isSocialFlow == true)
            {
                content += "社会指标超标";
            }
            if (isEconomicFlow == true)
            {
                content = "经济指标超标";
            }
            if (isEcologyFlow == true)
            {
                content = "生态指标超标";
            }
            //
            CxExplain.getInstance().SetContent("该城镇" + stryear + "年" + content);
            CxExplain.getInstance().Show();
        }

        /// <summary>
        /// Draw Point
        /// </summary>
        /// <param name="o"></param>
        /// <param name="id"></param>
        /// <author>Shen Yongyuan</author>
        /// <date>20100123</date>
        public void drawPoint2(Point3D o, int id)
        {
            Color c;
            double distance = Math.Sqrt(o.X * o.X + o.Y * o.Y + o.Z * o.Z);


            if (distance < warnValue)
            {
                if (id == 2000)
                    c = Colors.Silver;
                else
                    c = Colors.Green;
                id = id + 30000;
            }
            else if (distance < 0.95)
            {
                if (id == 2000)
                    c = Colors.Silver;
                else
                    c = Colors.Yellow;
                id = id + 20000;
            }
            else
            {
                if (id == 2000)
                    c = Colors.Silver;
                else
                    c = Colors.Red;
                id = id + 10000;
            }

            var p1 = new SphereOnEvent(o, 0.05, c, 1, id);


            p1.MouseDown += new MouseButtonEventHandler(p1_MouseDown);
            p1.MouseEnter += new System.Windows.Input.MouseEventHandler(p2_MouseCover);
            p1.MouseLeave += new System.Windows.Input.MouseEventHandler(p1_MouseLeave);
            //MyViewport.Children.Insert(0, p1);
            Viewport3D3.Children.Insert(0, p1);


        }

        private SphereOnEvent[] sphereDic = new SphereOnEvent[10];
        public void drawPoint2Ex(Point3D o, int id)
        {
            Color c = Colors.HotPink;
            if (id == 2000)
            {
                c = Colors.Silver;
            }
            else if (id == 2001)
                c = Colors.Green;
            else if (id == 2002)
                c = Colors.Goldenrod;
            else if (id == 2003)
                c = Colors.Purple;
            else if (id == 2004)
                c = Colors.Blue;
            else if (id == 2005)
                c = Colors.Olive;
            else if (id == 2006)
                c = Colors.Indigo;
            else if (id == 2007)
                c = Colors.Yellow;
            else if (id == 2008)
                c = Colors.Orange;
            else if (id == 2009)
                c = Colors.Red;
            //if(sphereDic.Length!=0)
            //MyViewport.Children.Remove(sphereDic[id - 2000]);
            var p1 = new SphereOnEvent(o, 0.05, c, 1, id);
            try
            {
                sphereDic[p1.Id - 2000] = p1;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            p1.MouseDown += new MouseButtonEventHandler(p1_MouseDown);
            p1.MouseEnter += new System.Windows.Input.MouseEventHandler(p2_MouseCover);
            p1.MouseLeave += new System.Windows.Input.MouseEventHandler(p1_MouseLeave);
            //MyViewport.Children.Insert(0, sphereDic[id - 2000]);
            Viewport3D3.Children.Insert(0, sphereDic[id - 2000]);
            //Viewport3D2.Children.Insert(0,p1);

        }

        void p1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SphereOnEvent p = sender as SphereOnEvent;
            int rend = p.Id;
            int year = p.Id;
            string content = "";
            string strEcology = (isEcology[year - 2000].Split('|'))[1];
            string strEconomic = (isEconomic[year - 2000].Split('|'))[1];
            string strSocial = (isSocial[year - 2000].Split('|'))[1];

            if ((isEcology[year - 2000].Split('|'))[0] == "NO")
                content += " 生态指标超标：\n" + strEcology + "\n";
            else
                content += " 生态指标正常：\n" + strEcology + "\n";
            if ((isEconomic[year - 2000].Split('|'))[0] == "NO")
                content += " 经济指标超标：\n" + strEconomic + "\n";
            else
                content += " 经济指标正常：\n" + strEconomic + "\n";
            if ((isSocial[year - 2000].Split('|'))[0] == "NO")
                content += " 社会指标超标：\n" + strSocial + "\n";
            else
                content += " 社会指标正常：\n" + strSocial + "\n";
            try
            {
                string stryear = year.ToString() + "年" + content;
                CxExplain.getInstance().SetContent(stryear);
                CxExplain.getInstance().Show();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }


        }
        /// <summary>
        /// Render explain float window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void p1_MouseCover(object sender, System.Windows.Input.MouseEventArgs e)
        {
            SphereOnEvent p = sender as SphereOnEvent;
            System.Windows.Point point = new System.Windows.Point();
            point = e.GetPosition(this.ThisParent);
            Point3D o;
            string content = "";
            int year = p.Id;
            content = year.ToString();
            if (list.Count == 1)
                o = list[0];
            else
                o = list[year - 2000];
            floatWindow.Owner = ThisParent;
            floatWindow.Top = ThisParent.Top + (Convert.ToInt32(point.Y) + 5);
            floatWindow.Left = ThisParent.Left + (Convert.ToInt32(point.X) + 5);
            floatWindow.Content = year + "年" + (o.X).ToString("f2") + " " + (o.Y).ToString("f2") + " " + (o.Z).ToString("f2");
            floatWindow.Show();

        }

        void p2_MouseCover(object sender, System.Windows.Input.MouseEventArgs e)
        {
            SphereOnEvent p = sender as SphereOnEvent;
            System.Windows.Point point = new System.Windows.Point();
            point = e.GetPosition(this.ThisParent);
            Point3D o;
            string content = "";
            int year = p.Id;
            content = year.ToString();
            if (list.Count == 1)
                o = list[0];
            else
                o = list[year - 2000];
            floatWindow.Owner = ThisParent;
            floatWindow.Top = ThisParent.Top + (Convert.ToInt32(point.Y) + 5);
            floatWindow.Left = ThisParent.Left + (Convert.ToInt32(point.X) + 5);
            floatWindow.Content = year + "年" + (o.X).ToString("f2") + " " + (o.Y).ToString("f2") + " " + (o.Z).ToString("f2");
            floatWindow.Show();

        }
        /// <summary>
        /// Render explain float window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void p1_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            floatWindow.Visibility = Visibility.Collapsed;
        }


        /// <summary>
        /// Set Place
        /// </summary>
        /// <param name="place"></param>
        /// <param name="city"></param>
        /// <author>Shen Yongyuan</author>
        /// <date>20100123</date>
        public void SetPlace(string place, string city, int year, List<Point3D> list, List<double> allValue, Boolean single)
        {
            //Temporary Inplement
            double indexEcology = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "生态子系统综合指标" && c.FromDate.Year == year).First().Value;
            double indexEconomic = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "经济子系统综合指标" && c.FromDate.Year == year).First().Value;
            double indexSocial = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "社会子系统综合指标" && c.FromDate.Year == year).First().Value;

            double percentX = (indexEcology - DataLib.DA_Index.QueryIndex("生态子系统综合指标", city).Min(c => c.Value)) /
                (DataLib.DA_Index.QueryIndex("生态子系统综合指标", city).Max(c => c.Value) - DataLib.DA_Index.QueryIndex("生态子系统综合指标", city).Min(c => c.Value));
            double percentY = (indexEcology - DataLib.DA_Index.QueryIndex("经济子系统综合指标", city).Min(c => c.Value)) /
                (DataLib.DA_Index.QueryIndex("经济子系统综合指标", city).Max(c => c.Value) - DataLib.DA_Index.QueryIndex("经济子系统综合指标", city).Min(c => c.Value));
            double percentZ = (indexEcology - DataLib.DA_Index.QueryIndex("社会子系统综合指标", city).Min(c => c.Value)) /
                (DataLib.DA_Index.QueryIndex("社会子系统综合指标", city).Max(c => c.Value) - DataLib.DA_Index.QueryIndex("社会子系统综合指标", city).Min(c => c.Value));

            if (percentX == 0) percentX = 1;
            if (percentY == 0) percentY = 1;
            if (percentZ == 0) percentZ = 1;
            //Use Random to set percetage positive and negative
            if (!single)
            {
                Random r = new Random();
                percentX *= r.NextDouble() > 0.5 ? 1 : -1;
                percentY *= r.NextDouble() > 0.5 ? 1 : -1;
                percentZ *= r.NextDouble() > 0.5 ? 1 : -1;
            }

            list.Add(new Point3D(percentX, percentY, percentZ));
            allValue.Add((Math.Abs(percentX) + Math.Abs(percentY) + Math.Abs(percentZ)) / 3);
            //if (list.Count == 1)
            //    Introduce.Text = "生态子系统综合指标" + percentX.ToString("f2") + ";经济子系统综合指标" + percentY.ToString("f2") + ";社会子系统综合指标" + percentZ.ToString("f2");
            //else Introduce.Text = "本市各年份综合指标走势";
        }

        /// <summary>
        /// Set One Place
        /// </summary>
        /// <param name="place"></param>
        /// <param name="city"></param>
        /// <author>ZhangMiao</author>
        /// <date>20100324</date>
        public void SetOnePlace(string place, string city, int year)
        {
            myState = WpfApplication3.Enum.MapState.Egg;

            double indexEcology = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "生态子系统综合指标" && c.FromDate.Year == year).First().Value;
            double indexEconomic = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "经济子系统综合指标" && c.FromDate.Year == year).First().Value;
            double indexSocial = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "社会子系统综合指标" && c.FromDate.Year == year).First().Value;
            list.Clear();
            list.Add(new Point3D(indexEcology, indexEconomic, indexSocial));

            ecologyHigh = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "生态子系统综合指标" && c.FromDate.Year == year).First().WarnValueHigh.Value;

            economicHigh = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "经济子系统综合指标" && c.FromDate.Year == year).First().WarnValueHigh.Value;

            socialHigh = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "社会子系统综合指标" && c.FromDate.Year == year).First().WarnValueHigh.Value;


            setEgg(indexEcology, indexEconomic, indexSocial, ecologyHigh, economicHigh, socialHigh, year);

            #region 注释
            //Point3D p = new Point3D(indexEcology - ecologyHigh/2, indexEconomic-economicHigh/2, indexSocial -socialHigh/2);  //潘伟龙 新加
            //Introduce.Text = "生态子系统综合指标" + (p.X + ecologyHigh / 2).ToString("f2") + ";经济子系统综合指标" + (p.Y + economicHigh / 2).ToString("f2") + ";社会子系统综合指标" + (p.Z + socialHigh / 2).ToString("f2");

            //BitmapImage bi1 = new BitmapImage();
            //bi1.BeginInit();
            ////bi.UriSource = new Uri("/Images/light"+indexSummary.IsInWarn.ToString()+".png",UriKind.Relative);
            //bi1.UriSource = new Uri("/Images/light1.png", UriKind.Relative);
            //if (indexEcology > ecologyHigh)
            //{
            //    bi1.UriSource = new Uri("/Images/light0.gif", UriKind.Relative);
            //    isEcologyFlow = true;
            //}        
            //bi1.EndInit();
            //lightEcology.Stretch = Stretch.Fill;
            //lightEcology.Source = bi1;

            //BitmapImage bi2 = new BitmapImage();
            //bi2.BeginInit();
            ////bi.UriSource = new Uri("/Images/light"+indexSummary.IsInWarn.ToString()+".png",UriKind.Relative);
            //bi2.UriSource = new Uri("/Images/light1.png", UriKind.Relative);
            //if (indexSocial > socialHigh)
            //{
            //    bi2.UriSource = new Uri("/Images/light0.gif", UriKind.Relative);
            //    isSocialFlow = true;
            //}
            //bi2.EndInit();
            //lightSociety.Stretch = Stretch.Fill;
            //lightSociety.Source = bi2;

            //BitmapImage bi3 = new BitmapImage();
            //bi3.BeginInit();
            ////bi.UriSource = new Uri("/Images/light"+indexSummary.IsInWarn.ToString()+".png",UriKind.Relative);
            //bi3.UriSource = new Uri("/Images/light1.png", UriKind.Relative);
            //if(indexEconomic>economicHigh)
            //{
            //    bi3.UriSource = new Uri("/Images/light0.gif", UriKind.Relative);
            //    isEconomicFlow = true;
            //}
            //bi3.EndInit();
            //lightEconomic.Stretch = Stretch.Fill;
            //lightEconomic.Source = bi3;

            //if(indexEcology>ecologyHigh||indexSocial>socialHigh||indexEconomic>economicHigh)
            //{
            //    drawPoint1Ex(p, year, true);   
            //}
            //else
            //{
            //    drawPoint1Ex(p, year, false);
            //}

            //_perspectiveCamera1 = MakeCamera();
            //_perspectiveCamera2 = MakeCamera();

            //GenerateViewPort(ecologyHigh,0,economicHigh,0,socialHigh,0);
            //GenerateViewPort2((ecologyHigh - 0) / 2, (economicHigh - 0) / 2, (socialHigh - 0) / 2, (ecologyHigh + 0) / 2, (economicHigh + 0) / 2, (socialHigh + 0) / 2);

            ////GenertateView(ecologyHigh, 0, economicHigh, 0, socialHigh, 0, (ecologyHigh - 0) / 2, (economicHigh - 0) / 2, (socialHigh - 0) / 2, (ecologyHigh + 0) / 2, (economicHigh + 0) / 2, (socialHigh + 0) / 2);

            //Show();
            #endregion
        }
        private void setEgg(double indexEcology, double indexEconomic, double indexSocial, double ecologyHigh, double economicHigh, double socialHigh, int year)
        {
            Point3D p = new Point3D(indexEcology - ecologyHigh / 2, indexEconomic - economicHigh / 2, indexSocial - socialHigh / 2);  //潘伟龙 新加
            Introduce.Text = "生态子系统综合指标" + (p.X + ecologyHigh / 2).ToString("f2") + ";经济子系统综合指标" + (p.Y + economicHigh / 2).ToString("f2") + ";社会子系统综合指标" + (p.Z + socialHigh / 2).ToString("f2");

            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            //bi.UriSource = new Uri("/Images/light"+indexSummary.IsInWarn.ToString()+".png",UriKind.Relative);
            bi1.UriSource = new Uri("/Images/light1.png", UriKind.Relative);
            if (indexEcology > ecologyHigh)
            {
                bi1.UriSource = new Uri("/Images/light0.gif", UriKind.Relative);
                isEcologyFlow = true;
            }
            bi1.EndInit();
            lightEcology.Stretch = Stretch.Fill;
            lightEcology.Source = bi1;

            BitmapImage bi2 = new BitmapImage();
            bi2.BeginInit();
            //bi.UriSource = new Uri("/Images/light"+indexSummary.IsInWarn.ToString()+".png",UriKind.Relative);
            bi2.UriSource = new Uri("/Images/light1.png", UriKind.Relative);
            if (indexSocial > socialHigh)
            {
                bi2.UriSource = new Uri("/Images/light0.gif", UriKind.Relative);
                isSocialFlow = true;
            }
            bi2.EndInit();
            lightSociety.Stretch = Stretch.Fill;
            lightSociety.Source = bi2;

            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            //bi.UriSource = new Uri("/Images/light"+indexSummary.IsInWarn.ToString()+".png",UriKind.Relative);
            bi3.UriSource = new Uri("/Images/light1.png", UriKind.Relative);
            if (indexEconomic > economicHigh)
            {
                bi3.UriSource = new Uri("/Images/light0.gif", UriKind.Relative);
                isEconomicFlow = true;
            }
            bi3.EndInit();
            lightEconomic.Stretch = Stretch.Fill;
            lightEconomic.Source = bi3;

            if (indexEcology > ecologyHigh || indexSocial > socialHigh || indexEconomic > economicHigh)
            {
                drawPoint1Ex(p, year, true);
            }
            else
            {
                drawPoint1Ex(p, year, false);
            }

            //_perspectiveCamera1 = MakeCamera();
            //_perspectiveCamera2 = MakeCamera();

            model3DGroup1.Children.Clear();
            model3DGroup2.Children.Clear();
            InitiateGroup();

            GenerateViewPort(ecologyHigh, 0, economicHigh, 0, socialHigh, 0);
            GenerateViewPort2((ecologyHigh - 0) / 2, (economicHigh - 0) / 2, (socialHigh - 0) / 2, (ecologyHigh + 0) / 2, (economicHigh + 0) / 2, (socialHigh + 0) / 2);

            //GenertateView(ecologyHigh, 0, economicHigh, 0, socialHigh, 0, (ecologyHigh - 0) / 2, (economicHigh - 0) / 2, (socialHigh - 0) / 2, (ecologyHigh + 0) / 2, (economicHigh + 0) / 2, (socialHigh + 0) / 2);

            Show();
        }
        // DispatcherTimer _timer = null;
        private bool isEconomicFlow = false;
        private bool isSocialFlow = false;
        private bool isEcologyFlow = false;
        private List<string> isEconomic = new List<string>();
        private List<string> isEcology = new List<string>();
        private List<string> isSocial = new List<string>();
        private int _currentYear = 2000;
        PerspectiveCamera _perspectiveCamera1 = null;
        PerspectiveCamera _perspectiveCamera2 = null;
        PerspectiveCamera _perspectiveCamera3 = null;
        private double _angle = 0;
        private Viewport3D Viewport3D1 = new Viewport3D();
        private Viewport3D Viewport3D2 = new Viewport3D();
        private Viewport3D Viewport3D3 = new Viewport3D();

        private double ecologyHigh;
        private double economicHigh;
        private double socialHigh;

        private string _place;
        private string _city;

        private int _currentEgg;

        private Model3DGroup model3DGroup1;
        private Model3DGroup model3DGroup2;
        private Model3DGroup model3DGroup3;

        private void GenertateView(double a, double b, double c, double rx, double ry, double rz, double x1, double x2, double y1, double y2, double z1, double z2)
        {
            MyViewport.Camera = _perspectiveCamera1;
            //_perspectiveCamera1 = MakeCamera();
            Viewport3D2.Camera = _perspectiveCamera1;
            Eclip.Children.Add(Viewport3D2);

            ModelVisual3D modelVisual3D = new ModelVisual3D();
            Viewport3D2.Children.Add(modelVisual3D);

            Model3DGroup model3DGroup = new Model3DGroup();
            modelVisual3D.Content = model3DGroup;

            AmbientLight ambientLight = new AmbientLight();
            ambientLight.Color = Colors.Gray;
            model3DGroup.Children.Add(ambientLight);

            DirectionalLight directionalLight = new DirectionalLight();
            directionalLight.Color = Colors.Gray;
            directionalLight.Direction = ((Vector3D)new Vector3DConverter().ConvertFromString("-1,-3,-2"));
            model3DGroup.Children.Add(directionalLight);

            directionalLight = new DirectionalLight();
            directionalLight.Color = Colors.Gray;
            directionalLight.Direction = ((Vector3D)new Vector3DConverter().ConvertFromString("1,-2,3"));
            model3DGroup.Children.Add(directionalLight);

            AddEllipsoid(model3DGroup, Colors.Orange, a, b, c, rx, ry, rz);
            ConstructCube(x1, x2, y1, y2, z1, z2, model3DGroup);
        }

        private void InitiateViewPort()
        {
            _perspectiveCamera1 = MakeCamera();
            _perspectiveCamera2 = MakeCamera();
            _perspectiveCamera3 = MakeCamera();

            MyViewport.Camera = _perspectiveCamera1;

            Viewport3D2.Camera = _perspectiveCamera2;
            Eclip.Children.Add(Viewport3D2);
            Viewport3D1.Camera = _perspectiveCamera2;
            Eclip.Children.Add(Viewport3D1);
            Viewport3D3.Camera = _perspectiveCamera3;
            Eclip.Children.Add(Viewport3D3);

            ModelVisual3D modelVisual3D1 = new ModelVisual3D();
            ModelVisual3D modelVisual3D2 = new ModelVisual3D();
            ModelVisual3D modelVisual3D3 = new ModelVisual3D();
            Viewport3D3.Children.Add(modelVisual3D3);
            Viewport3D2.Children.Add(modelVisual3D1);
            Viewport3D1.Children.Add(modelVisual3D2);


            model3DGroup1 = new Model3DGroup();
            model3DGroup2 = new Model3DGroup();
            model3DGroup3 = new Model3DGroup();
            modelVisual3D3.Content = model3DGroup3;
            modelVisual3D1.Content = model3DGroup1;
            modelVisual3D2.Content = model3DGroup2;

            //InitiateGroup(model3DGroup1,model3DGroup2);

        }
        private void InitiateGroup()
        {
            AmbientLight ambientLight = new AmbientLight();
            ambientLight.Color = Colors.Gray;
            model3DGroup1.Children.Add(ambientLight);
            model3DGroup2.Children.Add(ambientLight);
            model3DGroup3.Children.Add(ambientLight);

            DirectionalLight directionalLight = new DirectionalLight();
            directionalLight.Color = Colors.Gray;
            directionalLight.Direction = ((Vector3D)new Vector3DConverter().ConvertFromString("-1,-3,-2"));
            model3DGroup1.Children.Add(directionalLight);
            model3DGroup2.Children.Add(directionalLight);
            model3DGroup3.Children.Add(directionalLight);

            directionalLight = new DirectionalLight();
            directionalLight.Color = Colors.Gray;
            directionalLight.Direction = ((Vector3D)new Vector3DConverter().ConvertFromString("1,-2,3"));
            model3DGroup1.Children.Add(directionalLight);
            model3DGroup2.Children.Add(directionalLight);
            model3DGroup3.Children.Add(directionalLight);
        }

        private void GenerateViewPort2(double a, double b, double c, double rx, double ry, double rz)
        {
            AddEllipsoid(model3DGroup2, Colors.Orange, a, b, c, 0, 0, 0);
        }
        private void GenerateViewPort(double x1, double x2, double y1, double y2, double z1, double z2)
        {
            ConstructCube(x1 - (x1 - x2) / 2, x2 - (x1 - x2) / 2, y1 - (y1 - y2) / 2, y2 - (y1 - y2) / 2, z1 - (z1 - z2) / 2, z2 - (z1 - z2) / 2, model3DGroup1);
        }

        private PerspectiveCamera MakeCamera()
        {
            Transform3DGroup transform3DGroup = new Transform3DGroup();
            RotateTransform3D rotateTransform3D = new RotateTransform3D();
            transform3DGroup.Children.Add(rotateTransform3D);

            PerspectiveCamera perspectiveCamera = new PerspectiveCamera();
            perspectiveCamera.Position = new Point3D(4.0, 4.0, 4.0);
            perspectiveCamera.LookDirection = new Vector3D(-1, -1, -1);
            perspectiveCamera.UpDirection = new Vector3D(0, 1, 0);
            perspectiveCamera.FieldOfView = 45;
            perspectiveCamera.Transform = transform3DGroup;
            return perspectiveCamera;
        }
        private void AddEllipsoid(Model3DGroup model3DGroup, Color color, double x, double y, double z, double rx, double ry, double rz)
        {
            GeometryModel3D geometryModel3D = new GeometryModel3D();
            model3DGroup.Children.Add(geometryModel3D);

            //生成椭球坐标代码
            EllipsoidGeometry3D elliPlanet = new EllipsoidGeometry3D(x, y, z);
            //设置相对坐标
            elliPlanet.SetRelativeCoordinate(rx, ry, rz);
            //计算网格坐标值
            elliPlanet.CalculateGeometry();
            MeshGeometry3D meshGeometry3D = new MeshGeometry3D();
            meshGeometry3D.Positions = elliPlanet.Points;
            meshGeometry3D.TriangleIndices = elliPlanet.TriangleIndices;

            geometryModel3D.Geometry = meshGeometry3D;

            DiffuseMaterial diffuseMaterial = new DiffuseMaterial();
            geometryModel3D.Material = diffuseMaterial;

            SolidColorBrush solidColorBrush = new SolidColorBrush(color);
            solidColorBrush.Opacity = 0.5;
            diffuseMaterial.Brush = solidColorBrush;
        }

        private void ConstructRetangle(Model3DGroup model3DGroup, Point3DCollection point3DCollection, Color color)
        {
            GeometryModel3D geometryModel3D = new GeometryModel3D();
            model3DGroup.Children.Add(geometryModel3D);
            MeshGeometry3D meshGeometry3D = new MeshGeometry3D();
            meshGeometry3D.Positions = point3DCollection;
            meshGeometry3D.TriangleIndices = ((Int32Collection)new Int32CollectionConverter().ConvertFromString("0,1,2 0,2,3"));
            geometryModel3D.Geometry = meshGeometry3D;
            DiffuseMaterial diffuseMaterial = new DiffuseMaterial();
            geometryModel3D.Material = diffuseMaterial;
            SolidColorBrush solidColorBrush = new SolidColorBrush(color);
            solidColorBrush.Opacity = 0.7;
            diffuseMaterial.Brush = solidColorBrush;
            geometryModel3D.Material = diffuseMaterial;
        }

        private void ConstructCube(double x1, double x2, double y1, double y2, double z1, double z2, Model3DGroup model3DGroup)
        {
            #region 产生面
            //面1
            List<Point3D> point3Ds1 = new List<Point3D>();
            point3Ds1.Add(new Point3D(x1, y1, z1));
            point3Ds1.Add(new Point3D(x1, y2, z1));
            point3Ds1.Add(new Point3D(x1, y2, z2));
            point3Ds1.Add(new Point3D(x1, y1, z2));
            Point3DCollection point3DCollection1 = new Point3DCollection(point3Ds1);

            //面2
            List<Point3D> point3Ds2 = new List<Point3D>();
            point3Ds2.Add(new Point3D(x1, y1, z2));
            point3Ds2.Add(new Point3D(x1, y2, z2));
            point3Ds2.Add(new Point3D(x2, y2, z2));
            point3Ds2.Add(new Point3D(x2, y1, z2));
            Point3DCollection point3DCollection2 = new Point3DCollection(point3Ds2);

            //面3
            List<Point3D> point3Ds3 = new List<Point3D>();
            point3Ds3.Add(new Point3D(x2, y1, z2));
            point3Ds3.Add(new Point3D(x2, y2, z2));
            point3Ds3.Add(new Point3D(x2, y2, z1));
            point3Ds3.Add(new Point3D(x2, y1, z1));
            Point3DCollection point3DCollection3 = new Point3DCollection(point3Ds3);

            //面4
            List<Point3D> point3Ds4 = new List<Point3D>();
            point3Ds4.Add(new Point3D(x2, y1, z1));
            point3Ds4.Add(new Point3D(x2, y2, z1));
            point3Ds4.Add(new Point3D(x1, y2, z1));
            point3Ds4.Add(new Point3D(x1, y1, z1));
            Point3DCollection point3DCollection4 = new Point3DCollection(point3Ds4);


            //面5
            List<Point3D> point3Ds5 = new List<Point3D>();
            point3Ds5.Add(new Point3D(x1, y1, z1));
            point3Ds5.Add(new Point3D(x1, y1, z2));
            point3Ds5.Add(new Point3D(x2, y1, z2));
            point3Ds5.Add(new Point3D(x2, y1, z1));
            Point3DCollection point3DCollection5 = new Point3DCollection(point3Ds5);

            //面6
            List<Point3D> point3Ds6 = new List<Point3D>();
            point3Ds6.Add(new Point3D(x1, y2, z1));
            point3Ds6.Add(new Point3D(x2, y2, z1));
            point3Ds6.Add(new Point3D(x2, y2, z2));
            point3Ds6.Add(new Point3D(x1, y2, z2));
            Point3DCollection point3DCollection6 = new Point3DCollection(point3Ds6);
            #endregion

            ConstructRetangle(model3DGroup, point3DCollection1, Colors.Green);
            ConstructRetangle(model3DGroup, point3DCollection2, Colors.Red);
            ConstructRetangle(model3DGroup, point3DCollection3, Colors.Green);
            ConstructRetangle(model3DGroup, point3DCollection4, Colors.Red);
            ConstructRetangle(model3DGroup, point3DCollection5, Colors.Blue);
            ConstructRetangle(model3DGroup, point3DCollection6, Colors.Blue);
        }
        private ScreenSpaceLines3D[] screenSpaceLines3Ds = new ScreenSpaceLines3D[9];


        public void SetAllPlaceEx(string place, string city)
        {
            txtsociety.Visibility = Visibility.Hidden;
            txteconomic.Visibility = Visibility.Hidden;
            txtecology.Visibility = Visibility.Hidden;

            Introduce.Text = "本市各年份综合指标走势";
            myState = WpfApplication3.Enum.MapState.Egg2;

            ecologyHigh = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "生态子系统综合指标" && c.FromDate.Year == _currentYear).First().WarnValueHigh.Value;
            //double ecologyLow = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "生态子系统综合指标" && c.FromDate.Year == _currentYear).First().WarnValueLow.Value;
            economicHigh = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "经济子系统综合指标" && c.FromDate.Year == _currentYear).First().WarnValueHigh.Value;
            //double economicLow = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "经济子系统综合指标" && c.FromDate.Year == _currentYear).First().WarnValueLow.Value;
            socialHigh = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "社会子系统综合指标" && c.FromDate.Year == _currentYear).First().WarnValueHigh.Value;
            //double socialLow = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "社会子系统综合指标" && c.FromDate.Year == _currentYear).First().WarnValueLow.Value;

            //List<Point3D> list = new List<Point3D>();
            list.Clear();
            for (int i = 2000; i < 2010; i++)
            {
                double indexEcology = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "生态子系统综合指标" && c.FromDate.Year == i).First().Value;
                double indexEconomic = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "经济子系统综合指标" && c.FromDate.Year == i).First().Value;
                double indexSocial = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "社会子系统综合指标" && c.FromDate.Year == i).First().Value;

                ///////////////////////////////////////////////////////////////////

                /////////////////////////////////////////////////////////////////////

                //画点///////////////////////////////////////////////////////////////
                drawPoint2Ex(new Point3D(indexEcology - ecologyHigh / 2, indexEconomic - economicHigh / 2, indexSocial - socialHigh / 2), i);
                list.Add(new Point3D(indexEcology, indexEconomic, indexSocial));
                if (indexEcology > ecologyHigh)
                    isEcology.Add("NO|" + indexEcology);
                else
                {
                    isEcology.Add("YES|" + indexEcology);
                }
                if (indexEconomic > economicHigh)
                    isEconomic.Add("NO|" + indexEconomic);
                else
                {
                    isEconomic.Add("YES|" + indexEconomic);
                }
                if (indexSocial > socialHigh)
                    isSocial.Add("NO|" + indexSocial);
                else
                {
                    isSocial.Add("YES|" + indexSocial);
                }
            }
            //画九条线
            for (int i = 0; i < list.Count - 1; i++)
            {
                ScreenSpaceLines3D screenSpaceLines3D = new ScreenSpaceLines3D();
                Point3DCollection point3DCollection = new Point3DCollection();
                Point3D point3D = new Point3D(list[i].X - ecologyHigh / 2, list[i].Y - economicHigh / 2, list[i].Z - socialHigh / 2);
                Point3D point3D1 = new Point3D(list[i + 1].X - ecologyHigh / 2, list[i + 1].Y - economicHigh / 2, list[i + 1].Z - socialHigh / 2);
                point3DCollection.Add(point3D);
                point3DCollection.Add(point3D1);
                screenSpaceLines3D.Points = point3DCollection;
                screenSpaceLines3D.Thickness = 3;
                screenSpaceLines3D.Color = Color.FromRgb(0, 0, 0);
                //if (screenSpaceLines3Ds.Length != 0)
                //MyViewport.Children.Remove(screenSpaceLines3Ds[i]);
                screenSpaceLines3Ds[i] = screenSpaceLines3D;
                MyViewport.Children.Insert(0, screenSpaceLines3Ds[i]);
            }

            //_perspectiveCamera1 = MakeCamera();
            //_perspectiveCamera2 = MakeCamera();
            if (model3DGroup1 != null)
                model3DGroup1.Children.Clear();
            if (model3DGroup2 != null)
                model3DGroup2.Children.Clear();
            InitiateGroup();
            GenerateViewPort(ecologyHigh, 0, economicHigh, 0, socialHigh, 0);
            GenerateViewPort2((ecologyHigh - 0) / 2, (economicHigh - 0) / 2, (socialHigh - 0) / 2, (ecologyHigh + 0) / 2, (economicHigh + 0) / 2, (socialHigh + 0) / 2);

            Show();

        }
        /// <summary>
        /// Set All Place
        /// </summary>
        /// <param name="place"></param>
        /// <param name="city"></param>
        /// <author>ZhangMiao</author>
        /// <date>20100324</date>
        public void SetAllPlace(string place, string city)
        {
            Introduce.Text = "本市各年份综合指标走势";
            myState = WpfApplication3.Enum.MapState.Egg2;
            //List<Point3D> list = new List<Point3D>();
            for (int i = 2000; i < 2008; i++)
            {
                SetPlace(place, city, i, list, allValue, false);
            }
            List<Point3D> newList = new List<Point3D>();

            for (int i = 0; i < list.Count - 1; i++)
            {
                double x = list[i + 1].X - list[i].X / list[i].X;
                double y = list[i + 1].Y - list[i].Y / list[i].Y;
                double z = list[i + 1].Z - list[i].Z / list[i].Z;

                newList.Add(new Point3D(x, y, z));
            }

            double sumx = 0; double sumy = 0; double sumz = 0;
            for (int i = 0; i < newList.Count; i++)
            {
                sumx = sumx + newList[i].X;
                sumy = sumy + newList[i].Y;
                sumz = sumz + newList[i].Z;
            }
            double avex = sumx / newList.Count;
            double avey = sumy / newList.Count;
            double avez = sumz / newList.Count;

            //List<Point3D> endList = new List<Point3D>();
            for (int i = 0; i < newList.Count; i++)
            {
                endList.Add(new Point3D((newList[i].X - avex), (newList[i].Y - avey), (newList[i].Z - avez)));
            }
            double average = allValue.Sum() / allValue.Count;
            double variance = 0.0;
            foreach (double v in allValue)
            {
                variance += Math.Pow((v - average), 2);
            }
            warnValue = average - 2.33 * Math.Pow((variance / allValue.Count), 0.5);
            foreach (Point3D p in endList)
            {

                drawPoint2(p, endList.IndexOf(p) + 2000);
            }

            Point3D pback = new Point3D();
            Point3D pfront = new Point3D();
            pback = endList[0];
            for (int i = 0; i < endList.Count - 1; i++)
            {
                pfront = pback;
                pback = endList[i + 1];
                ScreenSpaceLines3D pt = new ScreenSpaceLines3D();
                pt.Points.Add(pfront);
                pt.Points.Add(pback);
                pt.Thickness = 2;
                pt.Color = Colors.Blue;
                MyViewport.Children.Insert(0, pt);

                double DArrow = Math.PI / 6;
                double MArrow = 0.3;

                #region 代码
                double ZXYLong = Math.Sqrt((pback.Z - pfront.Z) * (pback.Z - pfront.Z) +
                    (pback.X - pfront.X) * (pback.X - pfront.X) +
                    (pback.Y - pfront.Y) * (pback.Y - pfront.Y));
                if (ZXYLong == 0)
                    continue;
                Point3D arrow1 = new Point3D();
                Point3D arrow2 = new Point3D();

                if (pback.Y == pfront.Y && pback.X == pfront.Y)
                {

                    double MArrowY = MArrow * Math.Sin(DArrow);
                    double MArrowZ = MArrow * Math.Cos(DArrow);
                    int SignedZ;
                    if (pback.Z > pfront.Z)
                        SignedZ = -1;
                    else
                        SignedZ = 1;

                    arrow1.X = pback.X;
                    arrow1.Y = pback.Y - MArrow * Math.Sin(DArrow);
                    arrow1.Z = pback.Z + SignedZ * MArrow * Math.Cos(DArrow);


                    arrow2.X = pback.X;
                    arrow2.Y = pback.Y + MArrow * Math.Sin(DArrow);
                    arrow2.Z = pback.Z + SignedZ * MArrow * Math.Cos(DArrow);

                }
                else
                {

                    double DegreeZ = Math.Asin((pback.Z - pfront.Z) / ZXYLong);

                    double De2 = Math.PI / 2 - DegreeZ;
                    double De1 = Math.PI - DArrow - De2;
                    double De3 = Math.PI - De2;
                    double De4 = Math.PI - De3 - DArrow;

                    double LArrow = MArrow * Math.Sin(De1) / Math.Sin(De2);

                    double MiddelZ = LArrow * (pback.Z - pfront.Z) / ZXYLong;// Math.Sin(DegreeZ);
                    double MiddelY = LArrow * (pback.Y - pfront.Y) / ZXYLong;//Math.Sin(DegreeY);
                    double MiddelX = LArrow * (pback.X - pfront.X) / ZXYLong;//Math.Sin(DegreeX);

                    double MiddleZ = pback.Z - MiddelZ;
                    double MiddleY = pback.Y - MiddelY;
                    double MiddleX = pback.X - MiddelX;

                    double ArOP = MArrow * Math.Sin(De1) / Math.Sin(De4);
                    double Middle2 = MArrow * LArrow / ArOP;
                    //double Middle2 = MArrow * Math.Sin(De4);

                    double Z1 = LArrow * Math.Sin(DArrow) / Math.Sin(De1);
                    double Z2 = MArrow * Math.Sin(DArrow) / Math.Sin(De3);

                    arrow1.X = MiddleX;
                    arrow1.Y = MiddleY;
                    arrow1.Z = MiddleZ + Z1;

                    arrow2.X = pback.X - Middle2 * ((pback.X - pfront.X) / ZXYLong);
                    arrow2.Y = pback.Y - Middle2 * ((pback.Y - pfront.Y) / ZXYLong);
                    arrow2.Z = pback.Z - Middle2 * ((pback.Z - pfront.Z) / ZXYLong) - Z2;

                }

                ScreenSpaceLines3D temp1 = new ScreenSpaceLines3D();
                ScreenSpaceLines3D temp2 = new ScreenSpaceLines3D();
                temp1.Points.Add(pback);
                temp2.Points.Add(pback);
                temp1.Points.Add(arrow1);
                temp2.Points.Add(arrow2);
                temp1.Thickness = 1;
                temp2.Thickness = 1;
                temp1.Color = Colors.Red;
                temp2.Color = Colors.Red;
                MyViewport.Children.Insert(0, temp1);
                MyViewport.Children.Insert(0, temp2);


                #endregion
            }

            double ecologyHigh = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "生态子系统综合指标" && c.FromDate.Year == _currentYear).First().WarnValueHigh.Value;
            //double ecologyLow = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "生态子系统综合指标" && c.FromDate.Year == _currentYear).First().WarnValueLow.Value;
            double economicHigh = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "经济子系统综合指标" && c.FromDate.Year == _currentYear).First().WarnValueHigh.Value;
            //double economicLow = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "经济子系统综合指标" && c.FromDate.Year == _currentYear).First().WarnValueLow.Value;
            double socialHigh = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "社会子系统综合指标" && c.FromDate.Year == _currentYear).First().WarnValueHigh.Value;
            //double socialLow = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "社会子系统综合指标" && c.FromDate.Year == _currentYear).First().WarnValueLow.Value;


            _perspectiveCamera1 = MakeCamera();
            _perspectiveCamera2 = MakeCamera();
            GenerateViewPort(ecologyHigh, 0, economicHigh, 0, socialHigh, 0);
            GenerateViewPort2((ecologyHigh - 0) / 2, (economicHigh - 0) / 2, (socialHigh - 0) / 2, (ecologyHigh + 0) / 2, (economicHigh + 0) / 2, (socialHigh + 0) / 2);

            Show();
        }

        /// <summary>
        /// Display Sphere
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Introduce_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //if (!clicked)
            //    DisplaySphere();
            //else
            //{ clicked = false; }
        }


        private void Left_Click(object sender, RoutedEventArgs e)
        {

            direction = -1;
            tm = new DispatcherTimer();
            tm.Tick += new EventHandler(tm_Tick);
            tm.Interval = TimeSpan.FromSeconds(0.35);
            tm.Start();

        }
        private void Left_Up(object sender, RoutedEventArgs e)
        {
            tm.Stop();
        }
        private void Right_Click(object sender, RoutedEventArgs e)
        {

            direction = 1;
            tm = new DispatcherTimer();
            tm.Tick += new EventHandler(tm_Tick);
            tm.Interval = TimeSpan.FromSeconds(0.35);
            tm.Start();


        }
        private void Right_Up(object sender, RoutedEventArgs e)
        {
            tm.Stop();
        }
        void tm_Tick(object sender, EventArgs e)
        {
            //cameraRotation.Angle += direction * 10;

            Transform3DGroup transform3DGroup = new Transform3DGroup();
            RotateTransform3D rotateTransform3D = new RotateTransform3D();
            AxisAngleRotation3D axisAngleRotation3D = new AxisAngleRotation3D(new Vector3D(0, 1, 0), _angle);
            rotateTransform3D.Rotation = axisAngleRotation3D;
            transform3DGroup.Children.Add(rotateTransform3D);
            _perspectiveCamera1.Transform = transform3DGroup;
            _perspectiveCamera2.Transform = transform3DGroup;
            _perspectiveCamera3.Transform = transform3DGroup;
            _angle += direction * (-10);
        }

        private void titleBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_currentEgg == 1)
                SetOnePlace(_place, _city, _currentYear);
            else if (_currentEgg == 2)
                SetAllPlaceEx(_place, _city);
            return;


            //try
            //{
            //    ComboBoxItem cbi = (ComboBoxItem)titleBar.SelectedItem;

            //    if (cbi.Content.ToString() == "义乌市" || cbi.Content.ToString() == "南充市")
            //    {
            //        string place = cbi.Content.ToString();
            //        if (_currentEgg == 1)
            //        {
            //            double indexEcology = DataLib.DA_Index_High_Level.QueryIndexBySZone(place).Where(c => c.Name == "生态子系统综合指标" && c.FromDate.Year == _currentYear).First().Value;
            //            double indexEconomic = DataLib.DA_Index_High_Level.QueryIndexBySZone(place).Where(c => c.Name == "经济子系统综合指标" && c.FromDate.Year == _currentYear).First().Value;
            //            double indexSocial = DataLib.DA_Index_High_Level.QueryIndexBySZone(place).Where(c => c.Name == "社会子系统综合指标" && c.FromDate.Year == _currentYear).First().Value;
            //            list.Clear();
            //            list.Add(new Point3D(indexEcology, indexEconomic, indexSocial));

            //            ecologyHigh = DataLib.DA_Index_High_Level.QueryIndexBySZone(place).Where(c => c.Name == "生态子系统综合指标" && c.FromDate.Year == _currentYear).First().WarnValueHigh.Value;
            //            //double ecologyLow = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "生态子系统综合指标" && c.FromDate.Year == year).First().WarnValueLow.Value;
            //            economicHigh = DataLib.DA_Index_High_Level.QueryIndexBySZone(place).Where(c => c.Name == "经济子系统综合指标" && c.FromDate.Year == _currentYear).First().WarnValueHigh.Value;
            //            //double economicLow = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "经济子系统综合指标" && c.FromDate.Year == year).First().WarnValueLow.Value;
            //            socialHigh = DataLib.DA_Index_High_Level.QueryIndexBySZone(place).Where(c => c.Name == "社会子系统综合指标" && c.FromDate.Year == _currentYear).First().WarnValueHigh.Value;
            //            //double socialLow = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "社会子系统综合指标" && c.FromDate.Year == year).First().WarnValueLow.Value;
            //            setEgg(indexEcology, indexEconomic, indexSocial, ecologyHigh, economicHigh, socialHigh, _currentYear);
            //        }
            //        else if (_currentEgg == 2)
            //        {
            //            /*
            //            try
            //            {
            //                if (model3DGroup1 != null)
            //                    model3DGroup1.Children.Clear();
            //                if (model3DGroup2 != null)
            //                    model3DGroup2.Children.Clear();
            //                if (model3DGroup3 != null)
            //                    model3DGroup3.Children.Clear();
            //                InitiateGroup();
            //                lightSociety.Visibility = Visibility.Hidden;
            //                lightEconomic.Visibility = Visibility.Hidden;
            //                lightEcology.Visibility = Visibility.Hidden;
            //                list.Clear();
            //                for (int i = 2000; i < 2010; i++)
            //                {
            //                    double indexEcology = DataLib.DA_Index_High_Level.QueryIndexBySZone(place).Where(c => c.Name == "生态子系统综合指标" && c.FromDate.Year == _currentYear).First().Value;
            //                    double indexEconomic = DataLib.DA_Index_High_Level.QueryIndexBySZone(place).Where(c => c.Name == "经济子系统综合指标" && c.FromDate.Year == _currentYear).First().Value;
            //                    double indexSocial = DataLib.DA_Index_High_Level.QueryIndexBySZone(place).Where(c => c.Name == "社会子系统综合指标" && c.FromDate.Year == _currentYear).First().Value;

            //                    ecologyHigh = DataLib.DA_Index_High_Level.QueryIndexBySZone(place).Where(c => c.Name == "生态子系统综合指标" && c.FromDate.Year == _currentYear).First().WarnValueHigh.Value;
            //                    economicHigh = DataLib.DA_Index_High_Level.QueryIndexBySZone(place).Where(c => c.Name == "经济子系统综合指标" && c.FromDate.Year == _currentYear).First().WarnValueHigh.Value;
            //                    socialHigh = DataLib.DA_Index_High_Level.QueryIndexBySZone(place).Where(c => c.Name == "社会子系统综合指标" && c.FromDate.Year == _currentYear).First().WarnValueHigh.Value;

            //                    drawPoint2Ex(new Point3D(indexEcology - ecologyHigh / 2, indexEconomic - economicHigh / 2, indexSocial - socialHigh / 2), i);
            //                    list.Add(new Point3D(indexEcology, indexEconomic, indexSocial));

            //                    if (indexEcology > ecologyHigh)
            //                        isEcology.Add("NO");
            //                    else
            //                    {
            //                        isEcology.Add("YES");
            //                    }
            //                    if (indexEconomic > economicHigh)
            //                        isEconomic.Add("NO");
            //                    else
            //                    {
            //                        isEconomic.Add("YES");
            //                    }
            //                    if (indexSocial > socialHigh)
            //                        isSocial.Add("NO");
            //                    else
            //                    {
            //                        isSocial.Add("YES");
            //                    }
            //                }

            //                for (int i = 0; i < list.Count - 1; i++)
            //                {
            //                    ScreenSpaceLines3D screenSpaceLines3D = new ScreenSpaceLines3D();
            //                    Point3DCollection point3DCollection = new Point3DCollection();
            //                    Point3D point3D = new Point3D(list[i].X - ecologyHigh / 2, list[i].Y - economicHigh / 2, list[i].Z - socialHigh / 2);
            //                    Point3D point3D1 = new Point3D(list[i + 1].X - ecologyHigh / 2, list[i + 1].Y - economicHigh / 2, list[i + 1].Z - socialHigh / 2);
            //                    point3DCollection.Add(point3D);
            //                    point3DCollection.Add(point3D1);
            //                    screenSpaceLines3D.Points = point3DCollection;
            //                    screenSpaceLines3D.Thickness = 3;
            //                    screenSpaceLines3D.Color = Color.FromRgb(0, 0, 0);
            //                    // if (screenSpaceLines3Ds.Length != 0)
            //                    //MyViewport.Children.Remove(screenSpaceLines3Ds[i]);
            //                    screenSpaceLines3Ds[i] = screenSpaceLines3D;
            //                    //MyViewport.Children.Insert(0, screenSpaceLines3Ds[i]);
            //                    Viewport3D3.Children.Insert(0, screenSpaceLines3Ds[i]);
            //                }
            //                GenerateViewPort(ecologyHigh, 0, economicHigh, 0, socialHigh, 0);
            //                GenerateViewPort2((ecologyHigh - 0) / 2, (economicHigh - 0) / 2, (socialHigh - 0) / 2, (ecologyHigh + 0) / 2, (economicHigh + 0) / 2, (socialHigh + 0) / 2);
            //            }
            //            catch (Exception ee)
            //            {
            //                MessageBox.Show(ee.Message);
            //            }
            //             */
            //            ecologyHigh = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "生态子系统综合指标" && c.FromDate.Year == _currentYear).First().WarnValueHigh.Value;
            //            //double ecologyLow = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "生态子系统综合指标" && c.FromDate.Year == _currentYear).First().WarnValueLow.Value;
            //            economicHigh = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "经济子系统综合指标" && c.FromDate.Year == _currentYear).First().WarnValueHigh.Value;
            //            //double economicLow = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "经济子系统综合指标" && c.FromDate.Year == _currentYear).First().WarnValueLow.Value;
            //            socialHigh = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "社会子系统综合指标" && c.FromDate.Year == _currentYear).First().WarnValueHigh.Value;
            //            //double socialLow = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "社会子系统综合指标" && c.FromDate.Year == _currentYear).First().WarnValueLow.Value;

            //            //List<Point3D> list = new List<Point3D>();
            //            list.Clear();
            //            for (int i = 2000; i < 2010; i++)
            //            {
            //                double indexEcology = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "生态子系统综合指标" && c.FromDate.Year == i).First().Value;
            //                double indexEconomic = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "经济子系统综合指标" && c.FromDate.Year == i).First().Value;
            //                double indexSocial = DataLib.DA_Index.QueryIndexByZone(place).Where(c => c.Name == "社会子系统综合指标" && c.FromDate.Year == i).First().Value;

            //                ///////////////////////////////////////////////////////////////////


            //                /////////////////////////////////////////////////////////////////////

            //                drawPoint2Ex(new Point3D(indexEcology - ecologyHigh / 2, indexEconomic - economicHigh / 2, indexSocial - socialHigh / 2), i);
            //                list.Add(new Point3D(indexEcology, indexEconomic, indexSocial));
            //                if (indexEcology > ecologyHigh)
            //                    isEcology.Add("NO");
            //                else
            //                {
            //                    isEcology.Add("YES");
            //                }
            //                if (indexEconomic > economicHigh)
            //                    isEconomic.Add("NO");
            //                else
            //                {
            //                    isEconomic.Add("YES");
            //                }
            //                if (indexSocial > socialHigh)
            //                    isSocial.Add("NO");
            //                else
            //                {
            //                    isSocial.Add("YES");
            //                }
            //            }
            //            for (int i = 0; i < list.Count - 1; i++)
            //            {
            //                ScreenSpaceLines3D screenSpaceLines3D = new ScreenSpaceLines3D();
            //                Point3DCollection point3DCollection = new Point3DCollection();
            //                Point3D point3D = new Point3D(list[i].X - ecologyHigh / 2, list[i].Y - economicHigh / 2, list[i].Z - socialHigh / 2);
            //                Point3D point3D1 = new Point3D(list[i + 1].X - ecologyHigh / 2, list[i + 1].Y - economicHigh / 2, list[i + 1].Z - socialHigh / 2);
            //                point3DCollection.Add(point3D);
            //                point3DCollection.Add(point3D1);
            //                screenSpaceLines3D.Points = point3DCollection;
            //                screenSpaceLines3D.Thickness = 3;
            //                screenSpaceLines3D.Color = Color.FromRgb(0, 0, 0);
            //                //if (screenSpaceLines3Ds.Length != 0)
            //                //MyViewport.Children.Remove(screenSpaceLines3Ds[i]);
            //                screenSpaceLines3Ds[i] = screenSpaceLines3D;

            //                MyViewport.Children.Insert(0, screenSpaceLines3Ds[i]);
            //            }

            //            //_perspectiveCamera1 = MakeCamera();
            //            //_perspectiveCamera2 = MakeCamera();
            //            if (model3DGroup1 != null)
            //                model3DGroup1.Children.Clear();
            //            if (model3DGroup2 != null)
            //                model3DGroup2.Children.Clear();
            //            InitiateGroup();
            //            GenerateViewPort(ecologyHigh, 0, economicHigh, 0, socialHigh, 0);
            //            GenerateViewPort2((ecologyHigh - 0) / 2, (economicHigh - 0) / 2, (socialHigh - 0) / 2, (ecologyHigh + 0) / 2, (economicHigh + 0) / 2, (socialHigh + 0) / 2);

            //            Show();
            //        }
            //    }
            //    else
            //    {
            //        if (_currentEgg == 1)
            //            SetOnePlace(_place, _city, _currentYear);
            //        else if (_currentEgg == 2)
            //            SetAllPlaceEx(_place, _city);
            //    }

            //}
            //catch (Exception eee)
            //{
            //    MessageBox.Show(eee.Message);
            //}

        }




    }
}
