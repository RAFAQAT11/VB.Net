Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            DBConnect.IsConnected()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim signup As New SignUp()
        signup.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not String.IsNullOrEmpty(TextBox1.Text) And Not String.IsNullOrEmpty(TextBox2.Text) Then
            If DBConnect.Auth(TextBox1.Text, TextBox2.Text) Then
                Dim detail As New Detail(TextBox1.Text, TextBox2.Text)
                detail.Show()
                Me.Hide()
            Else
                MessageBox.Show("user does't exist")
            End If
        Else
            MessageBox.Show("Field can't be empty")
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim cp As New ControlPanal()
        cp.Show()
        Me.Hide()
    End Sub
End Class
