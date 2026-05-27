Imports System.Data.SqlClient

Public Class DBConnection

    Public Shared con As New SqlConnection(
        "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentResourceTracker;Integrated Security=True"
    )

End Class