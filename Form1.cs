
using System;
using System.Windows.Forms;
using System.Numerics;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Drawing.Design;

namespace Уравнения
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox12.Text = "0";
            textBox11.Text = "10";
            textBox10.Text = "0";
            textBox9.Text = "10";
        }

        public class Point
        {
            public double X { get; set; }
            public double Y { get; set; }

            public Point(double x, double y)
            {
                X = x;
                Y = y;
            }

            public override string ToString()
            {
                return $"({X}, {Y})";
            }
        }
        private List<Point> pointsList = new List<Point>();

        private void button2_Click(object sender, EventArgs e)
        {
        
            for(int i = 0; i < pointsList.Count-1; i++)
            {
                if (pointsList[i].Y> pointsList[i+1].Y )
                {
                    textBox4.Text = pointsList[i].Y.ToString("N3")+ Environment.NewLine;
                    break;
                }

            }
            textBox4.Text += pointsList[pointsList.Count-1].X.ToString("N3") + Environment.NewLine;

        }
    
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45 && textBox3.SelectionStart == 0) {; }
            else
            {
                if (e.KeyChar == '.') e.KeyChar = ',';
                if (e.KeyChar != 13 && e.KeyChar != 44 && e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                {
                    e.Handled = true;
                }
            }
        }
       
        

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == 45 && textBox9.SelectionStart == 0) {; }
                else
                {
                    if (e.KeyChar == '.') e.KeyChar = ',';
                    if (e.KeyChar != 13 && e.KeyChar != 44 && e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                    {
                        e.Handled = true;
                    }
                }
            }
            private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == 45 && textBox10.SelectionStart == 0) {; }
                else
                {
                    if (e.KeyChar == '.') e.KeyChar = ',';
                    if (e.KeyChar != 13 && e.KeyChar != 44 && e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                    {
                        e.Handled = true;
                    }
                }
            }
        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45 && textBox11.SelectionStart == 0) {; }
            else
            {
                if (e.KeyChar == '.') e.KeyChar = ',';
                if (e.KeyChar != 13 && e.KeyChar != 44 && e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                {
                    e.Handled = true;
                }
            }
        }
        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 45 && textBox12.SelectionStart == 0) {; }
            else
            {
                if (e.KeyChar == '.') e.KeyChar = ',';
                if (e.KeyChar != 13 && e.KeyChar != 44 && e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                {
                    e.Handled = true;
                }
            }
        }
           

        private void button3_Click(object sender, EventArgs e)
        {
            double max = 0;
            int maxu = 0;

            textBox9.Visible = true;
            textBox10.Visible = true;
            textBox11.Visible = true;
            textBox12.Visible = true;
            chart1.Visible = true;
            chart1.Series.Clear(); chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add(new ChartArea());
            double xmin = 0;
            double xmax = Convert.ToDouble(textBox11.Text);
            double ymin = Convert.ToDouble(textBox10.Text);
            double ymax = Convert.ToDouble(textBox9.Text);
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.Crossing = 0;
            chart1.ChartAreas[0].AxisY.Crossing = 0;
            chart1.MouseWheel += Chart1_MouseWheel;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart1.ChartAreas[0].AxisX.Minimum = xmin;
            chart1.ChartAreas[0].AxisX.Maximum = xmax; ;
            chart1.ChartAreas[0].AxisY.Minimum = ymin; ;
            chart1.ChartAreas[0].AxisY.Maximum = ymax; ;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.LabelStyle.Interval = 5;
            chart1.ChartAreas[0].AxisY.Interval = 1;
            chart1.ChartAreas[0].AxisY.LabelStyle.Interval = 5;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;
            chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset();
             double step = Convert.ToDouble(textBox3.Text);
             //   double t0 = Convert.ToDouble(textBox1.Text);
            double maxx=0,d=0.2,a=Math.PI*Math.Pow(d,2)/4, R=0,angle=45, Vx = 1, Vy = 1, x = 0, y = 0, vx1 = 0, vy1 = 0, k = 0.5 * 1.2 * 0.2 * a, g = 9.81, m = 104;
            for (int i = 20; i < 50; i++)
            {
                x = 0;
                y = 0;
                Series series = new Series();
                series.Points.Clear();
                series.ChartType = SeriesChartType.Spline;
                series.BorderWidth = 2;
                angle = i * Math.PI / 180;
                Vx = 1800 * Math.Cos(angle);
                Vy = 1800 * Math.Sin(angle);
                while (y >= 0)
                {
                    series.Points.AddXY(x / 1000, y / 50);
                    vx1 = Vx;
                    vy1 = Vy;
                    Vx += -k * Math.Sqrt(Math.Pow(vx1, 2) + Math.Pow(vy1, 2)) * vx1 / m * step;
                    Vy += (-g - (k * Math.Sqrt(Math.Pow(vx1, 2) + Math.Pow(vy1, 2)) * vy1) / m) * step;
                    x += Vx * step;
                    y += Vy * step;
                }
                if (maxx <= x)
                {
                    maxx = x;
                    max = i;
                }
                else
                {
                    chart1.Series.Add(series);
                    break;

                }
              
            }
            textBox4.Text += "без "+ Math.Round (max,3).ToString() +" "+ Math.Round (maxx/1000,3).ToString();
            maxx = 0;
            max = 0;
            for (int i = 20; i < 50; i++)
            {       
                Series series1 = new Series();
                series1.ChartType = SeriesChartType.Spline;
                series1.Points.Clear();
                x = 0; y = 0; k = 0;
                angle = i * Math.PI / 180;
                Vx = 1800 * Math.Cos(angle);
                Vy = 1800 * Math.Sin(angle);
                while (y >= 0)
                {
                   
                    R = 1.2 * Math.Exp(-y / 80000);
                    k = 0.5 * R * 0.2 * a;
                    series1.Points.AddXY(x / 1000, y / 50);
                    vx1 = Vx;
                    vy1 = Vy;
                    Vx += -k * Math.Sqrt(Math.Pow(vx1, 2) + Math.Pow(vy1, 2)) * vx1 / m * step;
                    Vy += (-g - (k * Math.Sqrt(Math.Pow(vx1, 2) + Math.Pow(vy1, 2)) * vy1) / m) * step;
                    x += Vx * step;
                    y += Vy * step;
                }
                if (maxx <= x)
                {
                    maxx = x;
                    max = i;
                }
                else
                { 
                    chart1.Series.Add(series1);
                    break;
                  
                }
            }
            textBox4.Text +=Environment.NewLine+ "c " + Math.Round (max,3).ToString() + " " + Math.Round (maxx/1000,3).ToString();

        }  
        private void Chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            int delta = e.Delta;

            double currentMinX = chart1.ChartAreas[0].AxisX.Minimum;
            double currentMaxX = chart1.ChartAreas[0].AxisX.Maximum;
            double currentMinY = chart1.ChartAreas[0].AxisY.Minimum;
            double currentMaxY = chart1.ChartAreas[0].AxisY.Maximum;

            double newMinX = currentMinX - delta * 0.01; 
            double newMaxX = currentMaxX + delta * 0.01; 
            double newMinY = currentMinY - delta * 0.01; 
            double newMaxY = currentMaxY + delta * 0.01;

            if (newMinX < newMaxX)
            {
                chart1.ChartAreas[0].AxisX.Minimum = newMinX;
                chart1.ChartAreas[0].AxisX.Maximum = newMaxX;
            }
            if (newMinY < newMaxY)
            {
                chart1.ChartAreas[0].AxisY.Minimum = newMinY;
                chart1.ChartAreas[0].AxisY.Maximum = newMaxY;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
