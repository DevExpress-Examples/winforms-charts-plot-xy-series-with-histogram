using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace WindowsFormsApplication1 {
    public partial class Form1 : Form {
        const int HistogramPointsCount = 1000;
        const int DistributionPointsCount = 100;
        const double Mean = 0.5;
        const double StdDev = 0.15;
        const double Max = 10;
        const double MinValue = 0;
        const double MaxValue = Max;
        const int BinCount = 20;
        Random random = new Random();

        public List<DataPoint> NormalDistribution { get; private set; }
        public List<DataPoint> Histogram { get; private set; }
       

        public Form1()
        {
            InitializeComponent();
            CreateDataSource();

            Series histogram = new Series("Histogram", ViewType.Bar);
            histogram.ArgumentDataMember = "XValue";
            chartControl1.Series.Add(histogram);
            ((BarSeriesView)histogram.View).AggregateFunction = SeriesAggregateFunction.Histogram;

            Series line = new Series("Line", ViewType.Spline);
            line.ArgumentDataMember = "XValue";
            line.ValueDataMembers[0] = "YValue";
            chartControl1.Series.Add(line);
            LineSeriesView lineView = (LineSeriesView)line.View;
            lineView.AggregateFunction = SeriesAggregateFunction.None;
            XYDiagram diagram = (XYDiagram)chartControl1.Diagram;
            diagram.AxisX.NumericScaleOptions.ScaleMode = ScaleMode.Interval;
            diagram.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True;
            diagram.AxisX.WholeRange.MinValue = MinValue;
            diagram.AxisX.WholeRange.MaxValue = MaxValue;
            diagram.AxisX.WholeRange.SideMarginsValue = 0;
            diagram.AxisX.NumericScaleOptions.IntervalOptions.GridLayoutMode = GridLayoutMode.GridShiftedLabelCentered;
            diagram.AxisX.NumericScaleOptions.IntervalOptions.Count = BinCount;
            diagram.AxisX.NumericScaleOptions.IntervalOptions.DivisionMode = IntervalDivisionMode.Count;
            diagram.AxisX.Label.TextPattern = "{}{OB}{A1:F1}, {A2:F1}{CB}";
            SecondaryAxisY secondaryAxisY = new SecondaryAxisY();
            diagram.SecondaryAxesY.Add(secondaryAxisY);
            lineView.AxisY = secondaryAxisY;
            SecondaryAxisX secondaryAxisX = new SecondaryAxisX();
            diagram.SecondaryAxesX.Add(secondaryAxisX);
            secondaryAxisX.WholeRange.SideMarginsValue = 0;
            lineView.AxisX = secondaryAxisX;

            line.DataSource = NormalDistribution;
            histogram.DataSource = Histogram;

        }

        void CreateDataSource() {
            NormalDistribution = new List<DataPoint>();
            for (int i = 0; i < DistributionPointsCount; i++) {
                double x = i * Max / DistributionPointsCount;
                NormalDistribution.Add(new DataPoint(x, GetNormalDistribution(x, Mean * Max, StdDev * Max)));
            }
            Histogram = new List<DataPoint>();
            for (int x = 0; x < HistogramPointsCount; x++)
                Histogram.Add(new DataPoint(GenerateHistogramPoint(Mean * Max, StdDev * Max)));
        }
        double GetNormalDistribution(double x, double mean, double stdDev) {
            double tmp = 1 / (Math.Sqrt(2 * Math.PI) * stdDev);
            return Math.Exp(-Math.Pow(x - mean, 2) / (2 * Math.Pow(stdDev, 2))) * tmp;
        }
        double GenerateHistogramPoint(double mean, double stdDev) {
            
            return Math.Sqrt(-2 * Math.Log(random.NextDouble())) * Math.Cos(2 * Math.PI * random.NextDouble()) * stdDev + mean;
        }
    }
    public class DataPoint {
        public double XValue { get; set; }
        public double YValue { get; set; }

        public DataPoint(double x, double y) {
            XValue = x;
            YValue = y;
        }
        public DataPoint(double value) : this(value, value) {
        }
    }
}
