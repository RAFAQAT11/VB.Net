Public Class SignUp

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim signin As New Form1()
        signin.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not String.IsNullOrEmpty(TextBox1.Text) And Not String.IsNullOrEmpty(TextBox2.Text) And Not String.IsNullOrEmpty(TextBox3.Text) Then
            If String.Compare(TextBox2.Text, TextBox3.Text) = 0 Then
                DBConnect.InsertEmailAndPassword(TextBox1.Text, TextBox2.Text)
            Else
                MessageBox.Show("Password is not matched")
            End If
        Else
            MessageBox.Show("Field can't be empty")
        End If
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub

    Private Sub SignUp_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub
End Class