Imports DevExpress.XtraCharts
Imports System

Namespace WindowsFormsApplication1

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

        Private Sub InitializeComponent()
            Me.chartControl1 = New DevExpress.XtraCharts.ChartControl()
            CType((Me.chartControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' chartControl1
            ' 
            Me.chartControl1.AutoLayout = False
            Me.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.chartControl1.Legend.Name = "Default Legend"
            Me.chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.[False]
            Me.chartControl1.Location = New System.Drawing.Point(0, 0)
            Me.chartControl1.Name = "chartControl1"
            Me.chartControl1.SeriesSerializable = New DevExpress.XtraCharts.Series(-1) {}
            Me.chartControl1.Size = New System.Drawing.Size(844, 390)
            Me.chartControl1.TabIndex = 3
            ' 
            ' Form1
            ' 
            Me.ClientSize = New System.Drawing.Size(844, 390)
            Me.Controls.Add(Me.chartControl1)
            Me.Name = "Form1"
            CType((Me.chartControl1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

        Private chartControl1 As DevExpress.XtraCharts.ChartControl
    End Class
End Namespace
