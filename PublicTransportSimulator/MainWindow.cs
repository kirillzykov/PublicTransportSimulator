using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace PublicTransportSimulator
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.Zoom = 5;
            gMapControl1.MaxZoom = 15;
            gMapControl1.MinZoom = 3;
            gMapControl1.MarkersEnabled = true;
            label4.Text = gMapControl1.Zoom.ToString();
        }

        private void AddPoint(double latitude, double longtitude)
        {
            gMapControl1.Position = new PointLatLng(latitude, longtitude);
            GMapOverlay markersOverlay = new GMapOverlay("markers");
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(latitude, longtitude), GMarkerGoogleType.green);
            markersOverlay.Markers.Add(marker);
            gMapControl1.Overlays.Add(markersOverlay);
        }

        private void AddRoute(double latitude1, double longtitude1, double latitude2, double longtitude2)
        {
            GMapOverlay routes = new GMapOverlay("routes");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(latitude1, longtitude1));
            points.Add(new PointLatLng(latitude2, longtitude2));
            gMapControl1.Position = new PointLatLng(latitude2, longtitude2);
            GMapRoute route = new GMapRoute(points, "route");
            route.Stroke = new Pen(Color.Red, 3);
            routes.Routes.Add(route);
            gMapControl1.Overlays.Add(routes);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            AddPoint(52.0975500, 23.6877500);
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            AddRoute(52.0975500, 23.6877500, 52.1975500, 23.6877500);
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            gMapControl1.Zoom = trackBar2.Value;
            label4.Text = gMapControl1.Zoom.ToString();
        }
    }
}