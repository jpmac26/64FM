﻿Imports Transitions 'Helps me a lot.
Imports Filmmaker.AddonModule
Public Class SplashScreen1
    'This will be checked lotsa times.
    Dim Percentage As Integer = 0
    Private Sub SplashScreen1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If the program is compiled in DEBUG mode, then enable the "Debug" flag in Globals.vb
#If DEBUG Then
        Debug = True
#End If
        'Start the timer and make every tick be less than a second.
        PercentagedTime.Interval = 50

        'Declare the transition for the TitleLabel
        Dim t1 As New Transition(New TransitionType_EaseInEaseOut(1000))
        Dim t2 As New Transition(New TransitionType_Linear(800))
        t2.add(TitleLabel, "ForeColor", Color.White)
        t1.add(TitleLabel, "Left", Me.Width - TitleLabel.Width - 5)
        'Run transitions
        t1.run()
        t2.run()
        STATUS_RTB.AppendText("Initializing..." + vbCrLf)
        STATUS_RTB.AppendText("Loading Addons..." + vbCrLf)
        AddonData.RepopulateFromDefault()
        STATUS_RTB.AppendText("You have " + AddonData.Addonlist.Count.ToString + " addons installed.")
        STATUS_RTB.ScrollToCaret()
        PercentagedTime.Start()
    End Sub

    Private Sub PercentagedTime_Tick(sender As Object, e As EventArgs) Handles PercentagedTime.Tick
        If Percentage < 100 Then
            Percentage = Percentage + 1
        ElseIf Percentage = 100 Then
            If My.Settings.Name = "" And My.Settings.Image = "" Then
                SetUpForm.Show()
                Me.Close()
            Else
                MainMenu.Show()
                Me.Close()
            End If
        End If
    End Sub

    Private Sub TitleLabel_Click(sender As Object, e As EventArgs) Handles TitleLabel.Click
        'DEBUG FEATURE: Reset "Custom Greeting" data.
        If Debug Then
            My.Settings.Reset()
            STATUS_RTB.AppendText("DEBUG: User data reinitialized!" + vbCrLf)
        End If
    End Sub

    Private Sub progressbar1_Click(sender As Object, e As EventArgs) Handles progressbar1.Click
        Percentage = 99
    End Sub
End Class
