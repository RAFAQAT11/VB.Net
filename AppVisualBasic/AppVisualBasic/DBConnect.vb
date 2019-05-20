
Imports System.Data.SQLite


Public Class DBConnect
    Shared conStr As String = "URI=file:database.db;"
    Shared dataTable As New DataTable("users")

    Shared Sub New()
    End Sub

    Public Shared Sub InsertEmailAndPassword(email As String, password As String)
        Try
            Dim con As New SQLiteConnection("Data Source=database.db;Version=3;")
            con.Open()
            Dim cmd As New SQLiteCommand("insert into users(email,pass,name,age,qualification) values(@email,@pass,@name,@age,@qualification)", con)
            cmd.Parameters.AddWithValue("@email", email)
            cmd.Parameters.AddWithValue("@pass", password)
            cmd.Parameters.AddWithValue("@name", "Null")
            cmd.Parameters.AddWithValue("@age", 0)
            cmd.Parameters.AddWithValue("@qualification", "Null")
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MessageBox.Show("Already exist user.")
        End Try
        MessageBox.Show("Account created successfully")
        'dataTable.Rows.Add(email, password, "Null", 0, "Null")
    End Sub

    Public Shared Sub InsertCredentials(email As String, name As String, age As Integer, qualification As String)
        Dim con As New SQLiteConnection(conStr)
        con.Open()
        Dim cmd As New SQLiteCommand("update users set name=@name,age=@age,qualification=@qualification where email=@email", con)
        cmd.Parameters.AddWithValue("@email", email)
        cmd.Parameters.AddWithValue("@name", name)
        cmd.Parameters.AddWithValue("@age", age)
        cmd.Parameters.AddWithValue("@qualification", qualification)
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Shared Function Auth(email As String, password As String) As Boolean
        Dim con As New SQLiteConnection(conStr)
        Dim DA As New SQLiteDataAdapter("select * from users where email='" + email + "' and pass='" + password + "'", con)
        Dim CB As New SQLiteCommandBuilder(DA)
        DA.Fill(dataTable)
        If dataTable.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function

    Public Shared Sub IsConnected()
        Dim con As New SQLiteConnection(conStr)
        con.Open()
        Dim cmd As New SQLiteCommand("PRAGMA schema_version", con)
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Shared Function GetTable() As DataTable
        Dim con As New SQLiteConnection(conStr)
        Dim DA As New SQLiteDataAdapter("select * from users", con)
        Dim CB As New SQLiteCommandBuilder(DA)
        DA.Fill(dataTable)
        Return dataTable
    End Function

    Public Shared Sub Delete(sno As String)
        Dim con As New SQLiteConnection(conStr)
        con.Open()
        Dim cmd As New SQLiteCommand("delete from users where sno=" + sno, con)
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Shared Sub Update(sno As String, email As String, pass As String, name As String, age As Integer, qualification As String)
        Dim con As New SQLiteConnection(conStr)
        con.Open()
        Dim cmd As New SQLiteCommand("update users set email=@email,pass=@pass,name=@name,age=@age,qualification=@qualification where sno=@sno", con)
        cmd.Parameters.AddWithValue("@sno", sno)
        cmd.Parameters.AddWithValue("@email", email)
        cmd.Parameters.AddWithValue("@pass", pass)
        cmd.Parameters.AddWithValue("@name", name)
        cmd.Parameters.AddWithValue("@age", age)
        cmd.Parameters.AddWithValue("@qualification", qualification)
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

    Public Shared Sub Clear()
        dataTable.Rows.Clear()
    End Sub


End Class
