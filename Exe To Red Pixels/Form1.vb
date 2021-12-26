Imports System.Drawing.Imaging
Imports System.IO
Imports Microsoft.VisualBasic.CompilerServices

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
            openFileDialog.Filter = "(*.exe)|*.exe"
            openFileDialog.ShowDialog()
            Dim flag As Boolean = Operators.CompareString(openFileDialog.FileName, "", False) <> 0
            If flag Then
                TextBox1.Text = openFileDialog.FileName
                Me.img = File.ReadAllBytes(openFileDialog.FileName)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public img As Byte()

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim saveFileDialog As SaveFileDialog = New SaveFileDialog()
            saveFileDialog.Filter = "(*.png)|*.png"
            saveFileDialog.FileName = "Image"
            saveFileDialog.ShowDialog()
            Dim flag As Boolean = Operators.CompareString(saveFileDialog.FileName, "", False) <> 0
            If flag Then
                Dim array As Byte() = Me.img
                Dim bitmap As Bitmap = New Bitmap(array.Length, 1)
                Dim arg_50_0 As Integer = 0
                Dim num As Integer = array.Length - 1
                Dim num2 As Integer = arg_50_0
                While True
                    Dim arg_72_0 As Integer = num2
                    Dim num3 As Integer = num
                    If arg_72_0 > num3 Then
                        Exit While
                    End If
                    bitmap.SetPixel(num2, 0, Color.FromArgb(CInt(array(num2)), 0, 0))
                    num2 += 1
                End While

                bitmap.Save(saveFileDialog.FileName, ImageFormat.Png)
                MsgBox(saveFileDialog.FileName, , "DONE!")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class
