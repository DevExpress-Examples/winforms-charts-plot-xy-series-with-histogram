Imports DevExpress.XtraCharts
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Namespace WindowsFormsApplication1

    Public Partial Class Form1
        Inherits Form

        Private _NormalDistribution As List(Of WindowsFormsApplication1.DataPoint), _Histogram As List(Of WindowsFormsApplication1.DataPoint)

        Const HistogramPointsCount As Integer = 1000

        Const DistributionPointsCount As Integer = 100

        Const Mean As Double = 0.5

        Const StdDev As Double = 0.15

        Const Max As Double = 10

        Const MinValue As Double = 0

        Const MaxValue As Double = Max

        Const BinCount As Integer = 20

        Private random As Random = New Random()

        Public Property NormalDistribution As List(Of DataPoint)
            Get
                Return _NormalDistribution
            End Get

            Private Set(ByVal value As List(Of DataPoint))
                _NormalDistribution = value
            End Set
        End Property

        Public Property Histogram As List(Of DataPoint)
            Get
                Return _Histogram
            End Get

            Private Set(ByVal value As List(Of DataPoint))
                _Histogram = value
            End Set
        End Property

        Public Sub New()
            InitializeComponent()
            CreateDataSource()
            Dim histogram As Series = New Series("Histogram", ViewType.Bar)
            histogram.ArgumentDataMember = "XValue"
            chartControl1.Series.Add(histogram)
            CType(histogram.View, BarSeriesView).AggregateFunction = SeriesAggregateFunction.Histogram
            Dim line As Series = New Series("Line", ViewType.Spline)
            line.ArgumentDataMember = "XValue"
            line.ValueDataMembers(0) = "YValue"
            chartControl1.Series.Add(line)
            Dim lineView As LineSeriesView = CType(line.View, LineSeriesView)
            lineView.AggregateFunction = SeriesAggregateFunction.None
            Dim diagram As XYDiagram = CType(chartControl1.Diagram, XYDiagram)
            diagram.AxisX.NumericScaleOptions.ScaleMode = ScaleMode.Interval
            diagram.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True
            diagram.AxisX.WholeRange.MinValue = MinValue
            diagram.AxisX.WholeRange.MaxValue = MaxValue
            diagram.AxisX.WholeRange.SideMarginsValue = 0
            diagram.AxisX.NumericScaleOptions.IntervalOptions.GridLayoutMode = GridLayoutMode.GridShiftedLabelCentered
            diagram.AxisX.NumericScaleOptions.IntervalOptions.Count = BinCount
            diagram.AxisX.NumericScaleOptions.IntervalOptions.DivisionMode = IntervalDivisionMode.Count
            diagram.AxisX.NumericScaleOptions.IntervalOptions.Pattern = "{OB}{A1:F1}, {A2:F1}{CB}"
            Dim secondaryAxisY As SecondaryAxisY = New SecondaryAxisY()
            diagram.SecondaryAxesY.Add(secondaryAxisY)
            lineView.AxisY = secondaryAxisY
            Dim secondaryAxisX As SecondaryAxisX = New SecondaryAxisX()
            diagram.SecondaryAxesX.Add(secondaryAxisX)
            secondaryAxisX.WholeRange.SideMarginsValue = 0
            lineView.AxisX = secondaryAxisX
            line.DataSource = NormalDistribution
            histogram.DataSource = Me.Histogram
        End Sub

        Private Sub CreateDataSource()
            NormalDistribution = New List(Of DataPoint)()
            For i As Integer = 0 To DistributionPointsCount - 1
                Dim x As Double = i * Max / DistributionPointsCount
                NormalDistribution.Add(New DataPoint(x, GetNormalDistribution(x, Mean * Max, StdDev * Max)))
            Next

            Histogram = New List(Of DataPoint)()
            For x As Integer = 0 To HistogramPointsCount - 1
                Histogram.Add(New DataPoint(GenerateHistogramPoint(Mean * Max, StdDev * Max)))
            Next
        End Sub

        Private Function GetNormalDistribution(ByVal x As Double, ByVal mean As Double, ByVal stdDev As Double) As Double
            Dim tmp As Double = 1 / (Math.Sqrt(2 * Math.PI) * stdDev)
            Return Math.Exp(-Math.Pow(x - mean, 2) / (2 * Math.Pow(stdDev, 2))) * tmp
        End Function

        Private Function GenerateHistogramPoint(ByVal mean As Double, ByVal stdDev As Double) As Double
            Return Math.Sqrt(-2 * Math.Log(random.NextDouble())) * Math.Cos(2 * Math.PI * random.NextDouble()) * stdDev + mean
        End Function
    End Class

    Public Class DataPoint

        Public Property XValue As Double

        Public Property YValue As Double

        Public Sub New(ByVal x As Double, ByVal y As Double)
            XValue = x
            YValue = y
        End Sub

        Public Sub New(ByVal value As Double)
            Me.New(value, value)
        End Sub
    End Class
End Namespace
