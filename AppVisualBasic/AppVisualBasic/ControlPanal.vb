Public Class ControlPanal
    Dim sno As String
    Private Sub ControlPanal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = DBConnect.GetTable()
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridView1.MultiSelect = False
    End Sub

    Private Sub ControlPanal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            sno = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            TextBox1.Text = DataGridView1.SelectedRows(0).Cells(1).Value.ToString()
            TextBox2.Text = DataGridView1.SelectedRows(0).Cells(2).Value.ToString()
            TextBox3.Text = DataGridView1.SelectedRows(0).Cells(3).Value.ToString()
            TextBox4.Text = DataGridView1.SelectedRows(0).Cells(4).Value.ToString()
            TextBox5.Text = DataGridView1.SelectedRows(0).Cells(5).Value.ToString()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        DBConnect.Clear()
        DataGridView1.DataSource = DBConnect.GetTable()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If Integer.Parse(sno) >= 0 Then
                DBConnect.Update(sno, TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text)
            Else
                MessageBox.Show("Select the row first.")
            End If
        Catch ex As Exception
            MessageBox.Show("Select the Row, and press select button.")
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            If Integer.Parse(sno) >= 0 Then
                DBConnect.Delete(sno)
            Else
                MessageBox.Show("Select the row first.")
            End If
        Catch ex As Exception
            MessageBox.Show("Select using, Select button first.")
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        
    End Sub

    Private Sub DataGridView1_RowHeaderCellChanged(sender As Object, e As DataGridViewRowEventArgs) Handles DataGridView1.RowHeaderCellChanged
        
    End Sub
End Class