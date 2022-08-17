Option Strict On
Option Explicit On
Imports System.Drawing
Imports System.Runtime.CompilerServices
Module ExtendedGraphics

    ''' <summary>
    ''' Draws a rectangle with it's corners rounded using GDI+
    ''' </summary>
    ''' <param name="g">The graphics that does the drawing</param>
    ''' <param name="pen">System.Drawing.Pen that determines the color, width, and style of the rectangle.</param>
    ''' <param name="area">System.Drawing.Rectangle that represents the rectangle to draw.</param>
    ''' <param name="radius">System.Int32 that determines the roundness of the corners.</param>
    <Extension()>
    Public Sub DrawRectangle(ByVal g As Graphics, ByVal pen As Pen, ByVal area As Rectangle, ByVal radius As Int32)
        'Clip out the corners
        g.SetClip(New Rectangle(area.Location, New Size(radius, radius)), Drawing2D.CombineMode.Exclude) 'upper-left
        g.SetClip(New Rectangle(New Point(area.Right - radius, area.Top), New Size(radius * 2, radius)), Drawing2D.CombineMode.Exclude) 'upper-right
        g.SetClip(New Rectangle(New Point(area.Left, area.Bottom - radius), New Size(radius, radius * 2)), Drawing2D.CombineMode.Exclude) 'lower-left
        g.SetClip(New Rectangle(New Point(area.Right - radius, area.Bottom - radius), New Size(radius * 2, radius * 2)), Drawing2D.CombineMode.Exclude) 'lower-right

        'Draw the initial rectangle
        g.DrawRectangle(pen, area)
        g.ResetClip()

        'Draw the corners
        g.DrawArc(pen, area.Left, area.Top, radius * 2, radius * 2, 180, 90) 'Upper-Left
        g.DrawArc(pen, area.Right - (radius * 2), area.Top, radius * 2, radius * 2, 270, 90) 'Upper-Right
        g.DrawArc(pen, area.Left, area.Bottom - (radius * 2), radius * 2, radius * 2, 90, 90) 'Lower-Left
        g.DrawArc(pen, area.Right - (radius * 2), area.Bottom - (radius * 2), radius * 2, radius * 2, 0, 90) 'Lower-Right
    End Sub

    ''' <summary>
    ''' Draws a rectangle with it's corners rounded using GDI+
    ''' </summary>
    ''' <param name="g">The graphics that does the drawing</param>
    ''' <param name="pen">System.Drawing.Pen that determines the color, width, and style of the rectangle.</param>
    ''' <param name="location">The x and y coordinates that determine the upper-left corner of the rectangle.</param>
    ''' <param name="size">The width and height that determine the size of the rectangle.</param>
    ''' <param name="radius">System.Int32 that determines the roundness of the corners.</param>
    <Extension()>
    Public Sub DrawRectangle(ByVal g As Graphics, ByVal pen As Pen, ByVal location As Point, ByVal size As Size, ByVal radius As Int32)
        'Create a rectangle
        Dim area As Rectangle = New Rectangle(location, size)

        'Clip out the corners
        g.SetClip(New Rectangle(area.Location, New Size(radius, radius)), Drawing2D.CombineMode.Exclude) 'upper-left
        g.SetClip(New Rectangle(New Point(area.Right - radius, area.Top), New Size(radius * 2, radius)), Drawing2D.CombineMode.Exclude) 'upper-right
        g.SetClip(New Rectangle(New Point(area.Left, area.Bottom - radius), New Size(radius, radius * 2)), Drawing2D.CombineMode.Exclude) 'lower-left
        g.SetClip(New Rectangle(New Point(area.Right - radius, area.Bottom - radius), New Size(radius * 2, radius * 2)), Drawing2D.CombineMode.Exclude) 'lower-right

        'Draw the initial rectangle
        g.DrawRectangle(pen, area)
        g.ResetClip()

        'Draw the corners
        g.DrawArc(pen, area.Left, area.Top, radius * 2, radius * 2, 180, 90) 'Upper-Left
        g.DrawArc(pen, area.Right - (radius * 2), area.Top, radius * 2, radius * 2, 270, 90) 'Upper-Right
        g.DrawArc(pen, area.Left, area.Bottom - (radius * 2), radius * 2, radius * 2, 90, 90) 'Lower-Left
        g.DrawArc(pen, area.Right - (radius * 2), area.Bottom - (radius * 2), radius * 2, radius * 2, 0, 90) 'Lower-Right
    End Sub

    ''' <summary>
    ''' Draws a rectangle with it's corners rounded using GDI+
    ''' </summary>
    ''' <param name="g">The graphics that does the drawing</param>
    ''' <param name="pen">System.Drawing.Pen that determines the color, width, and style of the rectangle.</param>
    ''' <param name="x">The x coordinate that determines the upper-left corner of the rectangle.</param>
    ''' <param name="y">The y coordinate that determines the upper-left corner of the rectangle.</param>
    ''' <param name="width">Width of the rectangle to draw.</param>
    ''' <param name="height">Height of the rectangle to draw.</param>
    ''' <param name="radius">System.Int32 that determines the roundness of the corners.</param>
    <Extension()>
    Public Sub DrawRectangle(ByVal g As Graphics, ByVal pen As Pen, ByVal x As Int32, ByVal y As Int32, ByVal width As Int32, ByVal height As Int32, ByVal radius As Int32)
        'Create a rectangle
        Dim area As Rectangle = New Rectangle(x, y, width, height)

        'Clip out the corners
        g.SetClip(New Rectangle(area.Location, New Size(radius, radius)), Drawing2D.CombineMode.Exclude) 'upper-left
        g.SetClip(New Rectangle(New Point(area.Right - radius, area.Top), New Size(radius * 2, radius)), Drawing2D.CombineMode.Exclude) 'upper-right
        g.SetClip(New Rectangle(New Point(area.Left, area.Bottom - radius), New Size(radius, radius * 2)), Drawing2D.CombineMode.Exclude) 'lower-left
        g.SetClip(New Rectangle(New Point(area.Right - radius, area.Bottom - radius), New Size(radius * 2, radius * 2)), Drawing2D.CombineMode.Exclude) 'lower-right

        'Draw the initial rectangle
        g.DrawRectangle(pen, area)
        g.ResetClip()

        'Draw the corners
        g.DrawArc(pen, area.Left, area.Top, radius * 2, radius * 2, 180, 90) 'Upper-Left
        g.DrawArc(pen, area.Right - (radius * 2), area.Top, radius * 2, radius * 2, 270, 90) 'Upper-Right
        g.DrawArc(pen, area.Left, area.Bottom - (radius * 2), radius * 2, radius * 2, 90, 90) 'Lower-Left
        g.DrawArc(pen, area.Right - (radius * 2), area.Bottom - (radius * 2), radius * 2, radius * 2, 0, 90) 'Lower-Right
    End Sub

    ''' <summary>
    ''' Fills a rectangle with it's corners rounded using GDI+
    ''' </summary>
    ''' <param name="g">The graphics that does the drawing</param>
    ''' <param name="brush">System.Drawing.Brush that determines the color and style of the line.</param>
    ''' <param name="area">System.Drawing.Rectangle that represents the rectangle to fill.</param>
    ''' <param name="radius">System.Int32 that determines the roundness of the corners.</param>
    <Extension()>
    Public Sub FillRectangle(ByVal g As Graphics, ByVal brush As Brush, ByVal area As Rectangle, ByVal radius As Int32)
        Dim path As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath

        'Add the corners
        path.AddArc(area.Left, area.Top, radius * 2, radius * 2, 180, 90) 'Upper-Left
        path.AddArc(area.Right - (radius * 2), area.Top, radius * 2, radius * 2, 270, 90) 'Upper-Right
        path.AddArc(area.Right - (radius * 2), area.Bottom - (radius * 2), radius * 2, radius * 2, 0, 90) 'Lower-Right
        path.AddArc(area.Left, area.Bottom - (radius * 2), radius * 2, radius * 2, 90, 90) 'Lower-Left

        'Fill the rounded rectangle
        g.FillPath(brush, path)
    End Sub

    ''' <summary>
    ''' Fills a rectangle with it's corners rounded using GDI+
    ''' </summary>
    ''' <param name="g">The graphics that does the drawing</param>
    ''' <param name="brush">System.Drawing.Pen that determines the color and style of the rectangle.</param>
    ''' <param name="location">The x and y coordinates that determine the upper-left corner of the rectangle.</param>
    ''' <param name="size">The width and height that determine the size of the rectangle.</param>
    ''' <param name="radius">System.Int32 that determines the roundness of the corners.</param>
    <Extension()>
    Public Sub FillRectangle(ByVal g As Graphics, ByVal brush As Brush, ByVal location As Point, ByVal size As Size, ByVal radius As Int32)
        Dim area As Rectangle = New Rectangle(location, size)
        Dim path As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath

        'Add the corners
        path.AddArc(area.Left, area.Top, radius * 2, radius * 2, 180, 90) 'Upper-Left
        path.AddArc(area.Right - (radius * 2), area.Top, radius * 2, radius * 2, 270, 90) 'Upper-Right
        path.AddArc(area.Right - (radius * 2), area.Bottom - (radius * 2), radius * 2, radius * 2, 0, 90) 'Lower-Right
        path.AddArc(area.Left, area.Bottom - (radius * 2), radius * 2, radius * 2, 90, 90) 'Lower-Left

        'Fill the rounded rectangle
        g.FillPath(brush, path)
    End Sub

    ''' <summary>
    ''' Fills a rectangle with it's corners rounded using GDI+
    ''' </summary>
    ''' <param name="g">The graphics that does the drawing</param>
    ''' <param name="brush">System.Drawing.Pen that determines the color and style of the rectangle.</param>
    ''' <param name="x">The x coordinate that determines the upper-left corner of the rectangle.</param>
    ''' <param name="y">The y coordinate that determines the upper-left corner of the rectangle.</param>
    ''' <param name="width">Width of the rectangle to draw.</param>
    ''' <param name="height">Height of the rectangle to draw.</param>
    ''' <param name="radius">System.Int32 that determines the roundness of the corners.</param>
    <Extension()>
    Public Sub FillRectangle(ByVal g As Graphics, ByVal brush As Brush, ByVal x As Int32, ByVal y As Int32, ByVal width As Int32, ByVal height As Int32, ByVal radius As Int32)
        Dim area As Rectangle = New Rectangle(x, y, width, height)
        Dim path As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath

        'Add the corners
        path.AddArc(area.Left, area.Top, radius * 2, radius * 2, 180, 90) 'Upper-Left
        path.AddArc(area.Right - (radius * 2), area.Top, radius * 2, radius * 2, 270, 90) 'Upper-Right
        path.AddArc(area.Right - (radius * 2), area.Bottom - (radius * 2), radius * 2, radius * 2, 0, 90) 'Lower-Right
        path.AddArc(area.Left, area.Bottom - (radius * 2), radius * 2, radius * 2, 90, 90) 'Lower-Left

        'Fill the rounded rectangle
        g.FillPath(brush, path)
    End Sub

End Module