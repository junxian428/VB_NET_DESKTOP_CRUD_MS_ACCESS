Imports System.Data.OleDb
Public Class Form1

    Dim dbProvider As String
    Dim dbSource As String
    Dim con As New OleDb.OleDbConnection
    Dim sql As String
    Dim da As OleDb.OleDbDataAdapter
    Dim Reader As OleDb.OleDbDataReader
    Dim Command As OleDb.OleDbCommand


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        dbProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;" ' MDB
        'dbProvider = "PROVIDER=Microsoft.Ace.OLEDB.12.0;" 'ACCDB
        dbSource = "Data Source=C:\Users\USer\source\repos\D210044A_Ho_Weng_Yin\D210044A_Ho_Weng_Yin\DatabaseForVB.mdb;  Persist Security Info= False;"
        con.ConnectionString = dbProvider & dbSource
        'Staff_ID_Box Staff_Name_Box Staff_Age_Box Staff_Salary_Box

        Try
            MessageBox.Show("Database is Opened")
            Using myconnection As New OleDbConnection(con.ConnectionString)
                myconnection.Open()
                'Dim sqlQry As String = "INSERT INTO [tbl_user] ([username], [password]) VALUES (@usernme, @passwrd)"
                con.Open()
                sql = "INSERT INTO Staff_Table (Staff_Name, Staff_Age,Staff_Salary) VALUES ('" + Staff_Name_Box.Text + "','" + Staff_Age_Box.Text + "','" + Staff_Salary_Box.Text + "');"
                da = New OleDb.OleDbDataAdapter(sql, con)
                Using cmd As New OleDbCommand(sql, myconnection)
                    cmd.ExecuteNonQuery()
                End Using
                myconnection.Close()
            End Using



        Catch ex As Exception
            ' Show the exception's message.
            MessageBox.Show(ex.Message)
            ' Show the stack trace, which is a list of methods
            ' that are currently executing.
            MessageBox.Show("Stack Trace: " & vbCrLf & ex.StackTrace)
        Finally
            ' This line executes whether or not the exception occurs.
            MessageBox.Show("Operation is Done")
        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        dbProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;" ' MDB
        'dbProvider = "PROVIDER=Microsoft.Ace.OLEDB.12.0;" 'ACCDB
        dbSource = "Data Source=C:\Users\USer\source\repos\D210044A_Ho_Weng_Yin\D210044A_Ho_Weng_Yin\DatabaseForVB.mdb;  Persist Security Info= False;"
        con.ConnectionString = dbProvider & dbSource
        'Staff_ID_Box Staff_Name_Box Staff_Age_Box Staff_Salary_Box

        Try
            MessageBox.Show("Database is Opened")
            Using myconnection As New OleDbConnection(con.ConnectionString)
                myconnection.Open()
                'Dim sqlQry As String = "INSERT INTO [tbl_user] ([username], [password]) VALUES (@usernme, @passwrd)"
                con.Open()
                sql = "Update Staff_Table set Staff_Name='" + Staff_Name_Box.Text + "',Staff_Age='" + Staff_Age_Box.Text + "',Staff_Salary='" + Staff_Salary_Box.Text + "' WHERE ID=" + Staff_ID_Box.Text + ";"
                da = New OleDb.OleDbDataAdapter(sql, con)
                Using cmd As New OleDbCommand(sql, myconnection)
                    cmd.ExecuteNonQuery()
                End Using
                myconnection.Close()
            End Using



        Catch ex As Exception
            ' Show the exception's message.
            MessageBox.Show(ex.Message)
            ' Show the stack trace, which is a list of methods
            ' that are currently executing.
            MessageBox.Show("Stack Trace: " & vbCrLf & ex.StackTrace)
        Finally
            ' This line executes whether or not the exception occurs.
            MessageBox.Show("Operation is Done")
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        dbProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;" ' MDB
        'dbProvider = "PROVIDER=Microsoft.Ace.OLEDB.12.0;" 'ACCDB
        dbSource = "Data Source=C:\Users\USer\source\repos\D210044A_Ho_Weng_Yin\D210044A_Ho_Weng_Yin\DatabaseForVB.mdb;  Persist Security Info= False;"
        con.ConnectionString = dbProvider & dbSource
        'Staff_ID_Box Staff_Name_Box Staff_Age_Box Staff_Salary_Box

        Try
            MessageBox.Show("Database is Opened")
            Using myconnection As New OleDbConnection(con.ConnectionString)
                myconnection.Open()
                'Dim sqlQry As String = "INSERT INTO [tbl_user] ([username], [password]) VALUES (@usernme, @passwrd)"
                con.Open()
                sql = "Delete from Staff_Table " + " WHERE ID=" + Staff_ID_Box.Text + ";"
                da = New OleDb.OleDbDataAdapter(sql, con)
                Using cmd As New OleDbCommand(sql, myconnection)
                    cmd.ExecuteNonQuery()
                End Using
                myconnection.Close()
            End Using



        Catch ex As Exception
            ' Show the exception's message.
            MessageBox.Show(ex.Message)
            ' Show the stack trace, which is a list of methods
            ' that are currently executing.
            MessageBox.Show("Stack Trace: " & vbCrLf & ex.StackTrace)
        Finally
            ' This line executes whether or not the exception occurs.
            MessageBox.Show("Operation is Done")
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;" ' MDB
        'dbProvider = "PROVIDER=Microsoft.Ace.OLEDB.12.0;" 'ACCDB
        dbSource = "Data Source=C:\Users\USer\source\repos\D210044A_Ho_Weng_Yin\D210044A_Ho_Weng_Yin\DatabaseForVB.mdb;  Persist Security Info= False;"
        con.ConnectionString = dbProvider & dbSource
        'Staff_ID_Box Staff_Name_Box Staff_Age_Box Staff_Salary_Box
        Dim cmdString As String = "Select * from Staff_Table"
        Try

            Using myconnection As New OleDbConnection(con.ConnectionString)
                myconnection.Open()
                Dim TheCommand As OleDbCommand = New OleDbCommand(cmdString, myconnection)
                TheCommand.CommandType = CommandType.Text
                Dim TheDataReader As OleDbDataReader = TheCommand.ExecuteReader()
                While TheDataReader.Read()
                    Console.WriteLine(TheDataReader("Staff_Name").ToString())
                    ComboBox1.Items.Add(TheDataReader("Staff_Name").ToString())
                End While
                myconnection.Close()
            End Using



        Catch ex As Exception
            ' Show the exception's message.
            MessageBox.Show(ex.Message)
            ' Show the stack trace, which is a list of methods
            ' that are currently executing.
            MessageBox.Show("Stack Trace: " & vbCrLf & ex.StackTrace)
        Finally
            ' This line executes whether or not the exception occurs.
            MessageBox.Show("Operation is Done")
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        dbProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;" ' MDB
        'dbProvider = "PROVIDER=Microsoft.Ace.OLEDB.12.0;" 'ACCDB
        dbSource = "Data Source=C:\Users\USer\source\repos\D210044A_Ho_Weng_Yin\D210044A_Ho_Weng_Yin\DatabaseForVB.mdb;  Persist Security Info= False;"
        con.ConnectionString = dbProvider & dbSource
        'Staff_ID_Box Staff_Name_Box Staff_Age_Box Staff_Salary_Box
        Dim cmdString As String = "Select * from Staff_Table '" + ComboBox1.Text + "';"
        Try

            Using myconnection As New OleDbConnection(con.ConnectionString)
                myconnection.Open()
                Dim TheCommand As OleDbCommand = New OleDbCommand(cmdString, myconnection)
                TheCommand.CommandType = CommandType.Text
                Dim TheDataReader As OleDbDataReader = TheCommand.ExecuteReader()
                While TheDataReader.Read()
                    Console.WriteLine(TheDataReader("Staff_Name").ToString())
                    'Staff_ID_Box Staff_Name_Box Staff_Age_Box Staff_Salary_Box
                    Staff_ID_Box.Text = TheDataReader("ID").ToString()
                    Staff_Name_Box.Text = TheDataReader("Staff_Name").ToString()
                    Staff_Age_Box.Text = TheDataReader("Staff_Age").ToString()
                    Staff_Salary_Box.Text = TheDataReader("Staff_Salary").ToString()


                End While
                myconnection.Close()
            End Using



        Catch ex As Exception
            ' Show the exception's message.
            MessageBox.Show(ex.Message)
            ' Show the stack trace, which is a list of methods
            ' that are currently executing.
            MessageBox.Show("Stack Trace: " & vbCrLf & ex.StackTrace)
        Finally
            ' This line executes whether or not the exception occurs.
            MessageBox.Show("Operation is Done")
        End Try
    End Sub
End Class
