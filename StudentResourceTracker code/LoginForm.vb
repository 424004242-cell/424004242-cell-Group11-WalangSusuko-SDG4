Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class LoginForm
    Inherits Form

    Dim txtUsername As New TextBox()
    Dim txtPassword As New TextBox()

    Dim btnLogin As New Button()

    Dim lblUser As New Label()
    Dim lblPass As New Label()

    Public Sub New()

        Me.Text = "LoginForm"
        Me.Size = New Drawing.Size(400, 250)

        lblUser.Text = "Username"
        lblUser.Location = New Drawing.Point(30, 40)

        txtUsername.Location = New Drawing.Point(130, 40)
        txtUsername.Width = 180

        lblPass.Text = "Password"
        lblPass.Location = New Drawing.Point(30, 90)

        txtPassword.Location = New Drawing.Point(130, 90)
        txtPassword.Width = 180
        txtPassword.UseSystemPasswordChar = True

        btnLogin.Text = "Login"
        btnLogin.Location = New Drawing.Point(130, 140)

        AddHandler btnLogin.Click, AddressOf LoginClick

        Me.Controls.Add(lblUser)
        Me.Controls.Add(txtUsername)

        Me.Controls.Add(lblPass)
        Me.Controls.Add(txtPassword)

        Me.Controls.Add(btnLogin)

    End Sub

    Private Sub LoginClick(sender As Object, e As EventArgs)

        Try

            DBConnection.con.Open()

            Dim cmd As New SqlCommand(
                "SELECT * FROM Users WHERE Username=@u AND Password=@p",
                DBConnection.con
            )

            cmd.Parameters.AddWithValue("@u", txtUsername.Text)
            cmd.Parameters.AddWithValue("@p", txtPassword.Text)

            Dim reader As SqlDataReader = cmd.ExecuteReader()

            If reader.HasRows Then

                MessageBox.Show("Login Successful!")

                Dim f As New Form1()
                f.Show()

                Me.Hide()

            Else

                MessageBox.Show("Invalid Username or Password")

            End If

            reader.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally

            DBConnection.con.Close()

        End Try

    End Sub

End Class