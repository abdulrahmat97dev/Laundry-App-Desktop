﻿Imports System.Drawing.Printing
Imports System.Globalization

Public Class formDetail

    Private conn As New MySqlConnection
    Dim connString = "Database=laundryapp;Data source=localhost;user id=root;password=;"

    Private Sub formDetail_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        tampil()
        'showItem()
        showItemAll()
        Application.CurrentCulture = New CultureInfo("EN-US")
    End Sub

    Private Sub formDetail_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Application.Exit()
        Me.Hide()
        formListOrder.tampil()
    End Sub

    Private Sub formDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tampil()
        'showItem()
        showItemAll()
    End Sub

    Sub tampil()

        conn = New MySqlConnection(connString)
        conn.Open()

        Dim dr As MySqlDataReader = Nothing
        Dim cmdAmbil As MySqlCommand = conn.CreateCommand
        Try
            Dim sqlString As String = "select * from t_order where nota = @nota;"
            cmdAmbil.Parameters.Add("@nota", MySqlDbType.Int16).Value = formUpdateOrder.nota
            'cmdAmbil.Parameters.Add("@nota", MySqlDbType.Int16).Value = "8"
            cmdAmbil.CommandText = sqlString
            dr = cmdAmbil.ExecuteReader
            If dr.Read Then
                Dim forDate As String = "dd-MMMM-yyyy"
                txtNota.Text = dr("nota").ToString
                txtNama.Text = dr("nama_customer").ToString
                txtStatusMember.Text = dr("status_member").ToString
                txtTerima.Text = CType(dr("tgl_terima").ToString, DateTime).ToString(forDate, New CultureInfo("id"))
                txtBerat.Text = dr("berat").ToString & " Kg"
                txtJenisLayanan.Text = dr("jenis_layanan").ToString
                txtHarga.Text = Format(dr("harga"), "#,##0.00")
                txtDiskon.Text = Format(dr("diskon"), "#,##0.00")
                txtBayar.Text = Format(dr("bayar"), "#,##0.00")
                txtProgress.Text = dr("progress").ToString
                txtStatus.Text = dr("status").ToString
                txtAmbil.Text = CType(dr("tgl_diambil").ToString, DateTime).ToString(forDate, New CultureInfo("id"))
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "terjadi Kegagalan!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cmdAmbil.Dispose()
            'dr = Nothing
            conn.Close()
        End Try

    End Sub

    'Sub showItem()
    '    Dim da As New MySqlDataAdapter()
    '    Dim ds As New DataSet()

    '    conn = New MySqlConnection(connString)
    '    conn.Open()

    '    Dim cmdSelect As MySqlCommand = conn.CreateCommand()
    '    Dim sqlString As String

    '    Try
    '        sqlString = "Select id,nama_item,jumlah from t_detailorder where nota=@nota;"
    '        cmdSelect.Parameters.Add("@nota", MySqlDbType.Int16).Value = formUpdateOrder.nota
    '        'cmdSelect.Parameters.Add("@nota", MySqlDbType.Int16).Value = 9

    '        cmdSelect.CommandText = sqlString

    '        'data gridview
    '        da.SelectCommand = cmdSelect
    '        da.Fill(ds, "t_detailorder")
    '        gridDetail.DataSource = ds
    '        gridDetail.DataMember = "t_detailorder"
    '        gridDetail.ReadOnly = True
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "Terjadi Kegagalan!", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Finally
    '        cmdSelect.Dispose()
    '        'conn.Close()
    '    End Try
    'End Sub

    Sub showItemAll()
        Dim da As New MySqlDataAdapter()
        Dim ds As New DataSet()

        conn = New MySqlConnection(connString)
        conn.Open()

        Dim cmdSelect As MySqlCommand = conn.CreateCommand()
        Dim sqlString As String

        Try
            sqlString = "SELECT nama_item,jumlah FROM " & _
            "(SELECT t_detailorder.nota, t_detailorder.nama_item,t_detailorder.jumlah FROM " & _
            "t_detailorder UNION " & _
             "SELECT vw_single_item.nota, vw_single_item.nama_item,vw_single_item.jumlah FROM " & _
             "vw_single_item) as itemsdata WHERE nota=@nota;"
            cmdSelect.Parameters.Add("@nota", MySqlDbType.Int16).Value = formUpdateOrder.nota
                'cmdSelect.Parameters.Add("@nota", MySqlDbType.Int16).Value = 9

            cmdSelect.CommandText = sqlString

                'data gridview
            da.SelectCommand = cmdSelect
            da.Fill(ds, "itemsdata")
            gridDetail.DataSource = ds
            gridDetail.DataMember = "itemsdata"
            gridDetail.ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Terjadi Kegagalan!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cmdSelect.Dispose()
            'conn.Close()
        End Try
    End Sub

    Private Sub Update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Update.Click
        formUpdateOrder.nota = txtNota.Text
        formUpdateOrder.Show()
        Me.Hide()
    End Sub

    Private Sub Hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Hapus.Click
        conn = New MySqlConnection(connString)
        conn.Open()

        Dim cmdDelete As MySqlCommand = conn.CreateCommand
        Dim cmdDelete2 As MySqlCommand = conn.CreateCommand
        If MessageBox.Show("Anda yakin akan menghapus Data dengan Nota :  " & txtNota.Text & " akan dihapus ? ", "Peringatan!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim sqlString As String = "delete from t_order where nota=@nota;"
                Dim sqlString2 As String = "delete from t_detailorder where nota=@nota;"

                cmdDelete.CommandText = sqlString
                cmdDelete2.CommandText = sqlString2

                cmdDelete.Connection = conn
                cmdDelete2.Connection = conn

                cmdDelete.Parameters.Add("@nota", MySqlDbType.Int16).Value = txtNota.Text
                cmdDelete2.Parameters.Add("@nota", MySqlDbType.Int16).Value = txtNota.Text

                'cmdDelete.Parameters.Add("@nota", MySqlDbType.Int16).Value = 9
                'cmdDelete2.Parameters.Add("@nota", MySqlDbType.Int16).Value = 9

                cmdDelete2.ExecuteNonQuery()
                cmdDelete.ExecuteNonQuery()

                MessageBox.Show("Data Berhasil dihapus", "Delete Order", MessageBoxButtons.OK, MessageBoxIcon.Information)

                formListOrder.Show()
                Me.Hide()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Terjadi Kegagalan!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                cmdDelete.Dispose()
                'conn.Close()
            End Try
        End If

    End Sub

    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        Me.Hide()
        formUpdateOrder.nota = ""
        formListOrder.Show()
        formListOrder.tampil()
    End Sub

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

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        PrintingOut()
    End Sub

    Public sess_ESC As String = ChrW(27) + "!"
    Public sess_EPSON_BOLD_ON As String = sess_ESC + Chr(16) + sess_ESC + Chr(32)
    Public sess_EPSON_BOLD_OFF As String = sess_ESC + Chr(0) + sess_ESC + Chr(0)
    Public sess_STAR_BOLD_ON As String = sess_ESC + Chr(14) + sess_ESC + Chr(15)
    Public sess_STAR_BOLD_OFF As String = sess_ESC + Chr(4) + sess_ESC + Chr(5)

    Public sess_PRINT_BOLD_ON As String = sess_ESC + Chr(17)
    Public sess_PRINT_BOLD_OFF As String = sess_ESC + Chr(0)

    Public Sub PrintingOut()
        conn = New MySqlConnection(connString)
        conn.Open()

        Dim cmdSelect2 As MySqlCommand = conn.CreateCommand()
        Dim sqlString2 As String

        Dim drset As MySqlDataReader = Nothing

        Dim nama_laundry$, alamat$, notelp$, footer$
        Try
            sqlString2 = "Select * from t_settings where id=1;"
            cmdSelect2.CommandText = sqlString2
            drset = cmdSelect2.ExecuteReader
            If drset.Read() Then
                nama_laundry = drset("nama_laundry").ToString
                alamat = drset("alamat").ToString
                notelp = drset("notelp").ToString
                footer = drset("footer_print").ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Terjadi Kegagalan!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cmdSelect2.Dispose()
            conn.Close()
        End Try

        Dim s As String

        Dim pd As New PrintDialog()

        ' You need a string to send.
        s = sess_PRINT_BOLD_ON
        s &= vbTab & "   .: " & nama_laundry & " :." & vbCrLf
        s &= vbTab & alamat & vbCrLf
        s &= vbTab & notelp & vbCrLf
        s &= sess_PRINT_BOLD_OFF
        s &= vbCrLf
        s &= sess_PRINT_BOLD_ON
        s &= "NOTA : " & txtNota.Text & vbCrLf
        s &= txtStatusMember.Text & vbCrLf
        s &= sess_PRINT_BOLD_OFF
        s &= "Nama : " & txtNama.Text & vbCrLf
        s &= "Tgl Terima : " & txtTerima.Text & vbCrLf
        s &= "Tgl Ambil : " & txtAmbil.Text & vbCrLf
        s &= "================================" & vbCrLf
        s &= vbTab & "   Detail Nota" & vbCrLf & vbCrLf
        s &= "Berat : " & txtBerat.Text & vbCrLf
        s &= "Jenis Layanan : " & txtJenisLayanan.Text & vbCrLf

        's &= FontStyle.Bold
        s &= sess_PRINT_BOLD_ON
        s &= "HARGA    Rp. " & Format(CDbl(txtHarga.Text), "#,##0.00") & vbCrLf
        s &= "Diskon   Rp. " & Format(CDbl(txtDiskon.Text), "#,##0.00") & vbCrLf
        s &= "Total Bayar   Rp. " & Format(CDbl(txtBayar.Text), "#,##0.00") & vbCrLf
        s &= sess_PRINT_BOLD_OFF

        s &= "Item Single: " & vbCrLf

        Dim cmdSelect3 As MySqlCommand = conn.CreateCommand()
        Dim sqlString3 As String

        Dim dr3 As MySqlDataReader = Nothing

        Dim namaitem$, jum$
        conn.Open()
        Try
            sqlString3 = "Select nama_item,jumlah from vw_single_item where nota=@nota;"
            cmdSelect3.Parameters.Add("@nota", MySqlDbType.Int16).Value = txtNota.Text
            'cmdSelect.Parameters.Add("@nota", MySqlDbType.Int16).Value = 9
            cmdSelect3.CommandText = sqlString3
            dr3 = cmdSelect3.ExecuteReader
            While dr3.Read()
                namaitem = dr3.Item("nama_item")
                jum = dr3.Item("jumlah")
                s &= namaitem & " : "
                s &= jum & " = "
                s &= getSingleHarga(namaitem) * CDbl(jum)
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Terjadi Kegagalan!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cmdSelect3.Dispose()
            conn.Close()
        End Try

        s &= vbCrLf

        'item section
        s &= "Item: " & vbCrLf
        's &= "Item - Jumlah" & vbCrLf

        Dim cmdSelect As MySqlCommand = conn.CreateCommand()
        Dim sqlString As String

        Dim dr2 As MySqlDataReader = Nothing
        conn.Open()
        Try
            sqlString = "Select id,nama_item,jumlah from t_detailorder where nota=@nota;"
            cmdSelect.Parameters.Add("@nota", MySqlDbType.Int16).Value = txtNota.Text
            'cmdSelect.Parameters.Add("@nota", MySqlDbType.Int16).Value = 9
            cmdSelect.CommandText = sqlString
            dr2 = cmdSelect.ExecuteReader
            While dr2.Read()
                s &= dr2.Item("nama_item") & " : "
                s &= dr2.Item("jumlah") & vbCrLf
            End While
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Terjadi Kegagalan!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            cmdSelect.Dispose()
            conn.Close()
        End Try

        'end item section

        s &= "================================" & vbCrLf
        s &= footer & vbCrLf
        s &= "" & vbCrLf
        s &= "" & vbCrLf
        s &= "" & vbCrLf
        s &= "" & vbCrLf
        s &= "" & vbCrLf
        s &= "" & vbCrLf
        s &= "" & vbCrLf
        s &= "" & vbCrLf
        s &= "_" & vbCrLf

        ' Open the printer dialog box, and then allow the user to select a printer.
        pd.PrinterSettings = New PrinterSettings()
        '        If (pd.ShowDialog() = DialogResult.OK) Then
        RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, s)
        'End If
    End Sub
End Class