Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Form1
    Inherits Form

    Dim dgv As New DataGridView()

    Dim txtTitle As New TextBox()
    Dim txtCategory As New TextBox()
    Dim txtAuthor As New TextBox()
    Dim txtQuantity As New TextBox()

    Dim btnAdd As New Button()
    Dim btnDelete As New Button()
    Dim btnLoad As New Button()
    Dim btnUpdate As New Button()
    Dim btnSearch As New Button()

    Public Sub New()

        Me.Text = "Student Resource Tracker"
        Me.Size = New Drawing.Size(800, 500)

        dgv.Location = New Drawing.Point(20, 20)
        dgv.Size = New Drawing.Size(740, 200)

        txtTitle.Location = New Drawing.Point(20, 250)
        txtTitle.Width = 150

        txtCategory.Location = New Drawing.Point(200, 250)
        txtCategory.Width = 150

        txtAuthor.Location = New Drawing.Point(380, 250)
        txtAuthor.Width = 150

        txtQuantity.Location = New Drawing.Point(560, 250)
        txtQuantity.Width = 100

        btnAdd.Text = "Add"
        btnAdd.Location = New Drawing.Point(20, 300)

        btnDelete.Text = "Delete"
        btnDelete.Location = New Drawing.Point(120, 300)

        btnLoad.Text = "Load"
        btnLoad.Location = New Drawing.Point(220, 300)

        btnUpdate.Text = "Update"
        btnUpdate.Location = New Drawing.Point(320, 300)

        btnSearch.Text = "Search"
        btnSearch.Location = New Drawing.Point(420, 300)

        AddHandler btnAdd.Click, AddressOf AddData
        AddHandler btnDelete.Click, AddressOf DeleteData
        AddHandler btnLoad.Click, AddressOf LoadData
        AddHandler btnUpdate.Click, AddressOf UpdateData
        AddHandler btnSearch.Click, AddressOf SearchData

        Me.Controls.Add(dgv)

        Me.Controls.Add(txtTitle)
        Me.Controls.Add(txtCategory)
        Me.Controls.Add(txtAuthor)
        Me.Controls.Add(txtQuantity)

        Me.Controls.Add(btnAdd)
        Me.Controls.Add(btnDelete)
        Me.Controls.Add(btnLoad)
        Me.Controls.Add(btnUpdate)
        Me.Controls.Add(btnSearch)

        AddHandler Me.Load, AddressOf FormLoad

    End Sub

    Private Sub FormLoad(sender As Object, e As EventArgs)

        LoadData(Nothing, Nothing)

    End Sub

    Private Sub LoadData(sender As Object, e As EventArgs)

        Try

            DBConnection.con.Open()

            Dim da As New SqlDataAdapter(
                "SELECT * FROM Resources",
                DBConnection.con
            )

            Dim dt As New DataTable()

            da.Fill(dt)

            dgv.DataSource = dt

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally

            DBConnection.con.Close()

        End Try

    End Sub

    Private Sub AddData(sender As Object, e As EventArgs)

        Try

            DBConnection.con.Open()

            Dim cmd As New SqlCommand(
                "INSERT INTO Resources(Title,Category,Author,Quantity)
                 VALUES(@t,@c,@a,@q)",
                DBConnection.con
            )

            cmd.Parameters.AddWithValue("@t", txtTitle.Text)
            cmd.Parameters.AddWithValue("@c", txtCategory.Text)
            cmd.Parameters.AddWithValue("@a", txtAuthor.Text)
            cmd.Parameters.AddWithValue("@q", txtQuantity.Text)

            cmd.ExecuteNonQuery()

            MessageBox.Show("Added Successfully")

            LoadData(Nothing, Nothing)

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally

            DBConnection.con.Close()

        End Try

    End Sub

    Private Sub DeleteData(sender As Object, e As EventArgs)

        Try

            If dgv.CurrentRow Is Nothing Then
                Exit Sub
            End If

            DBConnection.con.Open()

            Dim id As Integer =
                dgv.CurrentRow.Cells("ResourceID").Value

            Dim cmd As New SqlCommand(
                "DELETE FROM Resources WHERE ResourceID=@id",
                DBConnection.con
            )

            cmd.Parameters.AddWithValue("@id", id)

            cmd.ExecuteNonQuery()

            MessageBox.Show("Deleted Successfully")

            LoadData(Nothing, Nothing)

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally

            DBConnection.con.Close()

        End Try

    End Sub

    Private Sub UpdateData(sender As Object, e As EventArgs)

        Try

            If dgv.CurrentRow Is Nothing Then
                Exit Sub
            End If

            DBConnection.con.Open()

            Dim id As Integer =
                dgv.CurrentRow.Cells("ResourceID").Value

            Dim cmd As New SqlCommand(
                "UPDATE Resources
                 SET Title=@t,
                     Category=@c,
                     Author=@a,
                     Quantity=@q
                 WHERE ResourceID=@id",
                DBConnection.con
            )

            cmd.Parameters.AddWithValue("@t", txtTitle.Text)
            cmd.Parameters.AddWithValue("@c", txtCategory.Text)
            cmd.Parameters.AddWithValue("@a", txtAuthor.Text)
            cmd.Parameters.AddWithValue("@q", txtQuantity.Text)
            cmd.Parameters.AddWithValue("@id", id)

            cmd.ExecuteNonQuery()

            MessageBox.Show("Updated Successfully")

            LoadData(Nothing, Nothing)

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally

            DBConnection.con.Close()

        End Try

    End Sub

    Private Sub SearchData(sender As Object, e As EventArgs)

        Try

            DBConnection.con.Open()

            Dim da As New SqlDataAdapter(
                "SELECT * FROM Resources WHERE Title LIKE @search",
                DBConnection.con
            )

            da.SelectCommand.Parameters.AddWithValue(
                "@search",
                "%" & txtTitle.Text & "%"
            )

            Dim dt As New DataTable()

            da.Fill(dt)

            dgv.DataSource = dt

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        Finally

            DBConnection.con.Close()

        End Try

    End Sub

End Class