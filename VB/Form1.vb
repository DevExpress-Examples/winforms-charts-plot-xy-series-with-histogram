Imports DevExpress.XtraCharts
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms

Namespace WindowsFormsApplication1
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()

			Dim histogramData As New List(Of Double)()
			Dim lineData As New List(Of TestPoint)()
			Dim random As New Random()
			For i As Integer = 0 To 99
				Dim value As Integer = random.Next(1, 20)
				histogramData.Add(value)
				lineData.Add(New TestPoint(value, random.Next(1, 10)))
			Next i

			Dim histogram As New Series("Histogram", ViewType.Bar)
			histogram.DataSource = histogramData
			chartControl1.Series.Add(histogram)
			CType(histogram.View, BarSeriesView).AggregateFunction = SeriesAggregateFunction.Histogram

			Dim line As New Series("Line", ViewType.Line)
			line.DataSource = lineData
			line.ArgumentDataMember = "Argument"
			line.ValueDataMembers(0) = "Value"
			chartControl1.Series.Add(line)
			Dim lineView As LineSeriesView = CType(line.View, LineSeriesView)
			lineView.AggregateFunction = SeriesAggregateFunction.Average

			Dim diagram As XYDiagram = CType(chartControl1.Diagram, XYDiagram)
			diagram.AxisX.NumericScaleOptions.ScaleMode = ScaleMode.Interval
			Dim secondaryAxisY As New SecondaryAxisY()
			diagram.SecondaryAxesY.Add(secondaryAxisY)
			lineView.AxisY = secondaryAxisY
		End Sub
	End Class
	Public Class TestPoint
		Public ReadOnly Property Argument() As Double
		Public ReadOnly Property Value() As Double
		Public Sub New(ByVal argument As Double, ByVal value As Double)
			Me.Argument = argument
			Me.Value = value
		End Sub
	End Class
End Namespace