Imports System.IO.Ports
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class Form1
    Dim WithEvents arduinoPort As New SerialPort("COM6", 9600) ' Cambia "COM" al puerto correcto

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        arduinoPort.Open()
    End Sub

    Private Sub arduinoPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles arduinoPort.DataReceived
        Dim data As String = arduinoPort.ReadLine()
        Me.Invoke(Sub() HandleProductSelection(data))
    End Sub

    Private Sub HandleProductSelection(data As String)
        ' Mostrar la selección de productos en un TextBox o Label
        ProdSeleccionado.Text = data
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If arduinoPort.IsOpen Then
            arduinoPort.Close()
        End If
    End Sub
End Class




