using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            List<double> histogramData = new List<double>();
            List<TestPoint> lineData = new List<TestPoint>();
            Random random = new Random();
            for(int i = 0; i < 100; i++) {
                int value = random.Next(1, 20);
                histogramData.Add(value);
                lineData.Add(new TestPoint(value, random.Next(1, 10)));
            }

            Series histogram = new Series("Histogram", ViewType.Bar);
            histogram.DataSource = histogramData;
            chartControl1.Series.Add(histogram);
            ((BarSeriesView)histogram.View).AggregateFunction = SeriesAggregateFunction.Histogram;

            Series line = new Series("Line", ViewType.Line);
            line.DataSource = lineData;
            line.ArgumentDataMember = "Argument";
            line.ValueDataMembers[0] = "Value";
            chartControl1.Series.Add(line);
            LineSeriesView lineView = (LineSeriesView)line.View;
            lineView.AggregateFunction = SeriesAggregateFunction.Average;

            XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
            diagram.AxisX.NumericScaleOptions.ScaleMode = ScaleMode.Interval;
            SecondaryAxisY secondaryAxisY = new SecondaryAxisY();
            diagram.SecondaryAxesY.Add(secondaryAxisY);
            lineView.AxisY = secondaryAxisY;
        }
    }
    public class TestPoint {
        public double Argument { get; }
        public double Value { get; }
        public TestPoint(double argument, double value) {
            Argument = argument;
            Value = value;
        }
    }
}