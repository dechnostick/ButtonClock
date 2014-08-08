Imports System.Windows.Media.Animation
Imports System.Windows.Threading

Class Window1

    Dim dispatcherTimer As New DispatcherTimer()

    Private Sub Window1_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded

        Button1.Content = DateTime.Now.ToLongTimeString()

        dispatcherTimer = New DispatcherTimer(DispatcherPriority.Normal)
        dispatcherTimer.Interval = New TimeSpan(0, 0, 1)
        AddHandler dispatcherTimer.Tick, AddressOf dispatcherTimer_Tick
        dispatcherTimer.Start()

        Dim n As DateTime = DateTime.Now
        Dim da As New DoubleAnimation(0 + (n.Second * 6) - 90, 360 + (n.Second * 6) - 90, New Duration(TimeSpan.FromSeconds(60)))
        da.RepeatBehavior = RepeatBehavior.Forever

        Dim rt As New RotateTransform()
        rt.BeginAnimation(RotateTransform.AngleProperty, da)
        Button1.RenderTransform = rt
    End Sub

    Public Sub dispatcherTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        Button1.Content = DateTime.Now.ToLongTimeString()
    End Sub
End Class
