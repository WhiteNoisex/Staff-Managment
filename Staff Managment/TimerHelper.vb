Imports System.Diagnostics

Public Class TimerHelper
    Private stopwatch As New Stopwatch()

    ' Start the stopwatch
    Public Sub StartTimer()
        If Not stopwatch.IsRunning Then
            stopwatch.Start()
        End If
    End Sub

    ' Stop the stopwatch
    Public Sub StopTimer()
        If stopwatch.IsRunning Then
            stopwatch.Stop()
        End If
    End Sub

    ' Reset the stopwatch
    Public Sub ResetTimer()
        stopwatch.Reset()
    End Sub

    ' Get elapsed time in seconds (double precision)
    Public Function GetElapsedSeconds() As Double
        Return stopwatch.Elapsed.TotalSeconds
    End Function

    ' Get elapsed time in milliseconds (higher precision)
    Public Function GetElapsedMilliseconds() As Double
        Return stopwatch.Elapsed.TotalMilliseconds
    End Function

    ' Get elapsed time in microseconds (1,000,000 per second)
    Public Function GetElapsedMicroseconds() As Double
        Return stopwatch.ElapsedTicks / (Stopwatch.Frequency / 1_000_000.0)
    End Function

    ' Get elapsed time in nanoseconds (1,000,000,000 per second)
    Public Function GetElapsedNanoseconds() As Double
        Return stopwatch.ElapsedTicks / (Stopwatch.Frequency / 1_000_000_000.0)
    End Function

    ' Get formatted time (HH:MM:SS.MS.US.NS)
    Public Function GetFormattedTime() As String
        Dim ts As TimeSpan = stopwatch.Elapsed
        Dim parts As New List(Of String)

        ' If duration is 1 second or more, show hours/minutes/seconds (and milliseconds if available)
        If ts.TotalSeconds >= 1 Then
            If ts.Hours > 0 Then parts.Add(ts.Hours.ToString() & "h")
            If ts.Minutes > 0 OrElse parts.Count > 0 Then parts.Add(ts.Minutes.ToString() & "m")
            parts.Add(ts.Seconds.ToString() & "s")
            ' Optionally add milliseconds if there’s room for a third detail and they exist
            If parts.Count < 3 AndAlso ts.Milliseconds > 0 Then parts.Add(ts.Milliseconds.ToString() & "ms")
        ElseIf ts.TotalMilliseconds >= 1 Then
            ' For durations under 1 second but at least 1 millisecond, show ms + extra detail
            parts.Add(ts.Milliseconds.ToString() & "ms")
            Dim micro As Double = GetElapsedMicroseconds() Mod 1000  ' microseconds remaining after ms
            Dim nano As Double = GetElapsedNanoseconds() Mod 1000     ' nanoseconds remaining after µs
            If micro > 0 Then parts.Add(micro.ToString("F0") & "µs")
            If nano > 0 Then parts.Add(nano.ToString("F0") & "ns")
        Else
            ' For durations under 1 millisecond, show µs and ns if available
            Dim micro As Double = GetElapsedMicroseconds()
            Dim nano As Double = GetElapsedNanoseconds()
            If micro >= 1 Then parts.Add(micro.ToString("F0") & "µs")
            If nano >= 1 Then parts.Add(nano.ToString("F0") & "ns")
        End If

        ' Limit to a maximum of 3 components
        If parts.Count > 3 Then
            parts = parts.Take(3).ToList()
        End If

        ' Fallback if nothing was added
        If parts.Count = 0 Then parts.Add("0s")

        Return String.Join(" ", parts)
    End Function



End Class
