﻿Public Class FormAddItem
    Private conn As New MySqlConnection
    Dim connString = "Database=laundryapp;Data source=localhost;user id=root;password=;"
    Public totHrgSingle As Double = 0

    Private Sub FormAddItem_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        showItem()
        showItemSingle()
        'If (cekNotaSingleExis(formUpdateOrder.txtNota.Text)) Then
        '    getItemSingleNotaHrg(formUpdateOrder.txtNota.Text)
        '    Console.WriteLine("active : " & totHrgSingle)
        'Else
        '    totHrgSingle = 0
        'End If
        cmbNmSingle.Items.Clear()
        fillDropDownNamaSingle()
    End Sub

    Private Sub FormAddItem_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        formUpdateOrder.bayarItem = totHrgSingle
    End Sub

    Private Sub FormAddItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        showItem()
        showItemSingle()
        If (cekNotaSingleExis(formUpdateOrder.txtNota.Text)) Then
            getItemSingleNotaHrg(formUpdateOrder.txtNota.Text)
            Console.WriteLine("active : " & totHrgSingle)
        Else
            totHrgSingle = 0
        End If
    End Sub

    Function cekNotaSingleExis(ByVal nota As String) As Boolean
        Dim conn As MySqlConnection = New MySqlConnection(connString)
        Dim cmd As MySqlCommand = New MySqlCommand("SELECT IF(EXISTS (SELECT nota " & _
            "FROM t_order_single_item WHERE nota = @nota), 'Y','N')", conn)
        cmd.Parameters.AddWithValue("@nota", nota)
        conn.Open()
        Dim exists As String = cmd.ExecuteScalar().ToString()
        'Console.WriteLine(exists)
        conn.Close()
        Return If(exists = "Y", True, False)
    End Function

    Sub getItemSingleNotaHrg(ByVal nota As String)
        conn = New MySqlConnection(connString)
        conn.Open()

        Dim dr As MySqlDataReader = Nothing
        Dim cmdAmbil As MySqlCommand = conn.CreateCommand

        Try
            Dim sqlString As String = "select nama_item from vw_single_item where nota=@nota;"
            cmdAmbil.CommandText = sqlString
            cmdAmbil.Parameters.AddWithValue("@nota", nota)
            dr = cmdAmbil.ExecuteReader
            While dr.Read
                totHrgSingle = getSingleHarga(dr.Item("nama_item").ToString) + totHrgSingle
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message, "terjadi Kegagalan!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cmdAmbil.Dispose()
            'conn.Close()
            'conn = Nothing
        End Try
    End Sub

    Sub showItem()
        Dim da As New MySqlDataAdapter()
        Dim ds As New DataSet()

        conn = New MySqlConnection(connString)
        conn.Open()

        Dim cmdSelect As MySqlCommand = conn.CreateCommand()
        Dim sqlString As String

        Try
            sqlString = "Select id,nama_item,jumlah from t_detailorder where nota=@nota;"
            cmdSelect.Parameters.Add("@nota", MySqlDbType.Int16).Value = formUpdateOrder.nota
            'cmdSelect.Parameters.Add("@nota", MySqlDbType.Int16).Value = 9

            cmdSelect.CommandText = sqlString
            da.SelectCommand = cmdSelect
            da.Fill(ds, "t_detailorder")
            gridItem.DataSource = ds
            gridItem.DataMember = "t_detailorder"
            gridItem.ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Terjadi Kegagalan!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cmdSelect.Dispose()
            conn.Close()
        End Try
    End Sub

    Sub showItemSingle()
        Dim da As New MySqlDataAdapter()
        Dim ds As New DataSet()

        conn = New MySqlConnection(connString)
        conn.Open()

        Dim cmdSelect As MySqlCommand = conn.CreateCommand()
        Dim sqlString As String

        Try
            sqlString = "Select id,nama_item,jumlah from vw_single_item where nota=@nota;"
            cmdSelect.Parameters.Add("@nota", MySqlDbType.VarChar, 50).Value = formUpdateOrder.nota
            'cmdSelect.Parameters.Add("@nota", MySqlDbType.Int16).Value = 9

            cmdSelect.CommandText = sqlString
            da.SelectCommand = cmdSelect
            da.Fill(ds, "vw_single_item")
            DGVSingleItem.DataSource = ds
            DGVSingleItem.DataMember = "vw_single_item"
            DGVSingleItem.ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Terjadi Kegagalan!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cmdSelect.Dispose()
            conn.Close()
        End Try
    End Sub
    Sub fillDropDownNamaSingle()
        conn = New MySqlConnection(connString)
        conn.Open()

        Dim dr As MySqlDataReader = Nothing
        Dim cmdAmbil As MySqlCommand = conn.CreateCommand

        Try
            Dim sqlString As String = "select nama_item from t_singleitem;"
            cmdAmbil.CommandText = sqlString
            dr = cmdAmbil.ExecuteReader
            While dr.Read
                cmbNmSingle.Items.Add(dr.Item("nama_item").ToString)
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message, "terjadi Kegagalan!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cmdAmbil.Dispose()
            'conn.Close()
            'conn = Nothing
        End Try
    End Sub
    Function getSingleItemID(ByVal nama_item As String) As Integer
        conn = New MySqlConnection(connString)
        conn.Open()

        Dim dr As MySqlDataReader = Nothing
        Dim cmdAmbil As MySqlCommand = conn.CreateCommand
        Dim singleItemID As String
        Try
            Dim sqlString As String = "select id from t_singleitem where nama_item=@nama_item;"
            cmdAmbil.Parameters.Add("@nama_item", MySqlDbType.String, 100).Value = nama_item
            cmdAmbil.CommandText = sqlString
            dr = cmdAmbil.ExecuteReader
            If dr.Read Then
                singleItemID = dr("id").ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "terjadi Kegagalan!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cmdAmbil.Dispose()
            'conn.Close()
            'conn = Nothing
        End Try
        Return singleItemID
    End Function

    Function getSingleHarga(ByVal nama_item As String) As Double
        conn = New MySqlConnection(connString)
        conn.Open()

        Dim dr As MySqlDataReader = Nothing
        Dim cmdAmbil As MySqlCommand = conn.CreateCommand
        Dim singleHarga As String
        Try
            Dim sqlString As String = "select harga from t_singleitem where nama_item=@nama_item;"
            cmdAmbil.Parameters.Add("@nama_item", MySqlDbType.String, 100).Value = nama_item
            cmdAmbil.CommandText = sqlString
            dr = cmdAmbil.ExecuteReader
            If dr.Read Then
                singleHarga = dr("harga").ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "terjadi Kegagalan!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cmdAmbil.Dispose()
            'conn.Close()
            'conn = Nothing
        End Try
        Return singleHarga
    End Function

    Private Sub btnTambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTambah.Click
        conn = New MySqlConnection(connString)
        conn.Open()

        Dim cmdInsert As MySqlCommand = conn.CreateCommand
        If (editItem.Text <> "" And editJumlah.Text <> "") Then
            Try
                Dim sqlString As String = "insert into t_detailorder(nota,nama_item,jumlah)" & _
                    " values " & _
                    "(@nota,@item,@jumlah);"
                cmdInsert.CommandText = sqlString
                cmdInsert.Connection = conn
                cmdInsert.Parameters.Add("@nota", MySqlDbType.VarChar, 100).Value = formUpdateOrder.txtNota.Text
                'cmdInsert.Parameters.Add("@nota", MySqlDbType.VarChar, 100).Value = 9
                cmdInsert.Parameters.Add("@item", MySqlDbType.VarChar, 100).Value = editItem.Text
                cmdInsert.Parameters.Add("@jumlah", MySqlDbType.Int16).Value = editJumlah.Text
                cmdInsert.ExecuteNonQuery()
                'MessageBox.Show("Data berhasil ditambahkan", "Create Order", MessageBoxButtons.OK, MessageBoxIcon.Information)
                editItem.Clear()
                editJumlah.Clear()
                showItem()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Terjadi kegagalan!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub


    Private Sub btnAddSingleItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddSingleItem.Click
        conn = New MySqlConnection(connString)
        conn.Open()
        Dim jum As Double = CDbl(editJumSingle.Text)
        Dim cmdInsert As MySqlCommand = conn.CreateCommand
        If (cmbNmSingle.Text <> "" And editJumSingle.Text <> "") Then
            Try
                Dim sqlString As String = "insert into t_order_single_item(nota,singleitem_id,jumlah)" & _
                    " values " & _
                    "(@nota,@singelitemID,@jumlah);"
                cmdInsert.CommandText = sqlString
                cmdInsert.Connection = conn
                cmdInsert.Parameters.Add("@nota", MySqlDbType.VarChar, 100).Value = formUpdateOrder.txtNota.Text
                'cmdInsert.Parameters.Add("@nota", MySqlDbType.VarChar, 100).Value = 9
                cmdInsert.Parameters.Add("@singelitemID", MySqlDbType.Int16).Value = getSingleItemID(cmbNmSingle.Text)
                cmdInsert.Parameters.Add("@jumlah", MySqlDbType.Int16).Value = editJumSingle.Text
                cmdInsert.ExecuteNonQuery()
                'MessageBox.Show("Data berhasil ditambahkan", "Create Order", MessageBoxButtons.OK, MessageBoxIcon.Information)
                editJumSingle.Clear()
                showItemSingle()
                totHrgSingle = (getSingleHarga(cmbNmSingle.Text) * jum) + totHrgSingle
                Console.WriteLine("after add item : " & totHrgSingle)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Terjadi kegagalan!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub gridItem_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridItem.CellContentClick
        If (e.ColumnIndex = 3) Then
            Dim id As Integer = gridItem.Rows(e.RowIndex).Cells(0).Value
            'MsgBox(gridItem.Rows(e.RowIndex).Cells(0).Value)

            conn = New MySqlConnection(connString)
            conn.Open()

            Dim cmdDel As MySqlCommand = conn.CreateCommand
            Try
                Dim sqlString As String = "delete from t_detailorder where id=@id;"
                cmdDel.CommandText = sqlString
                cmdDel.Connection = conn
                cmdDel.Parameters.Add("@id", MySqlDbType.Int16).Value = id
                cmdDel.ExecuteNonQuery()
                'MessageBox.Show("Data berhasil ditambahkan", "Create Order", MessageBoxButtons.OK, MessageBoxIcon.Information)
                showItem()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Terjadi kegagalan!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub DGVSingleItem_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVSingleItem.CellContentClick
        If (e.ColumnIndex = 0) Then
            Dim id As Integer = DGVSingleItem.Rows(e.RowIndex).Cells(1).Value
            'MsgBox(DGVSingleItem.Rows(e.RowIndex).Cells(2).Value)

            conn = New MySqlConnection(connString)
            conn.Open()

            Dim jum As Double = CDbl(DGVSingleItem.Rows(e.RowIndex).Cells(3).Value)
            Dim namaitem As String = CStr(DGVSingleItem.Rows(e.RowIndex).Cells(2).Value)

            Dim cmdDel As MySqlCommand = conn.CreateCommand
            Try
                Dim sqlString As String = "delete from t_order_single_item where id=@id;"
                cmdDel.CommandText = sqlString
                cmdDel.Connection = conn
                cmdDel.Parameters.Add("@id", MySqlDbType.Int16).Value = id
                cmdDel.ExecuteNonQuery()
                'MessageBox.Show("Data berhasil ditambahkan", "Create Order", MessageBoxButtons.OK, MessageBoxIcon.Information)
                showItemSingle()
                totHrgSingle = totHrgSingle - (getSingleHarga(namaitem) * jum)
                Console.WriteLine("after del item : " & totHrgSingle)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Terjadi kegagalan!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        formUpdateOrder.bayarItem = totHrgSingle
        Me.Close()
        formUpdateOrder.Show()
    End Sub
End Class