﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSingelItem
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSingelItem))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.DGVSingleItem = New System.Windows.Forms.DataGridView()
        Me.colIDPlgn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kol_layanan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kol_Terima = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kol_Edit = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.kol_Hapus = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.btntambah = New System.Windows.Forms.Button()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVSingleItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.CornflowerBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Location = New System.Drawing.Point(-3, -2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(599, 78)
        Me.Panel3.TabIndex = 100
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Cooper Std Black", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(136, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(213, 38)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Single Item"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(-1, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(133, 77)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'DGVSingleItem
        '
        Me.DGVSingleItem.AllowUserToAddRows = False
        Me.DGVSingleItem.AllowUserToDeleteRows = False
        Me.DGVSingleItem.AllowUserToResizeColumns = False
        Me.DGVSingleItem.AllowUserToResizeRows = False
        Me.DGVSingleItem.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.DGVSingleItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVSingleItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colIDPlgn, Me.kol_layanan, Me.kol_Terima, Me.kol_Edit, Me.kol_Hapus})
        Me.DGVSingleItem.Location = New System.Drawing.Point(30, 142)
        Me.DGVSingleItem.Name = "DGVSingleItem"
        Me.DGVSingleItem.ReadOnly = True
        Me.DGVSingleItem.Size = New System.Drawing.Size(435, 273)
        Me.DGVSingleItem.TabIndex = 102
        '
        'colIDPlgn
        '
        Me.colIDPlgn.DataPropertyName = "id"
        Me.colIDPlgn.HeaderText = "ID"
        Me.colIDPlgn.Name = "colIDPlgn"
        Me.colIDPlgn.ReadOnly = True
        Me.colIDPlgn.Width = 50
        '
        'kol_layanan
        '
        Me.kol_layanan.DataPropertyName = "nama_item"
        Me.kol_layanan.FillWeight = 150.0!
        Me.kol_layanan.HeaderText = "Nama Item"
        Me.kol_layanan.Name = "kol_layanan"
        Me.kol_layanan.ReadOnly = True
        Me.kol_layanan.Width = 150
        '
        'kol_Terima
        '
        Me.kol_Terima.DataPropertyName = "harga"
        Me.kol_Terima.HeaderText = "Harga"
        Me.kol_Terima.Name = "kol_Terima"
        Me.kol_Terima.ReadOnly = True
        '
        'kol_Edit
        '
        Me.kol_Edit.DataPropertyName = "id"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Goldenrod
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.NullValue = "Edit"
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DarkGoldenrod
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White
        Me.kol_Edit.DefaultCellStyle = DataGridViewCellStyle5
        Me.kol_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.kol_Edit.HeaderText = ""
        Me.kol_Edit.Name = "kol_Edit"
        Me.kol_Edit.ReadOnly = True
        Me.kol_Edit.Text = "Edit"
        Me.kol_Edit.UseColumnTextForButtonValue = True
        Me.kol_Edit.Width = 40
        '
        'kol_Hapus
        '
        Me.kol_Hapus.DataPropertyName = "id"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Firebrick
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.NullValue = "Delete"
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Brown
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White
        Me.kol_Hapus.DefaultCellStyle = DataGridViewCellStyle6
        Me.kol_Hapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.kol_Hapus.HeaderText = ""
        Me.kol_Hapus.Name = "kol_Hapus"
        Me.kol_Hapus.ReadOnly = True
        Me.kol_Hapus.Text = "Delete"
        Me.kol_Hapus.UseColumnTextForButtonValue = True
        Me.kol_Hapus.Width = 50
        '
        'btntambah
        '
        Me.btntambah.BackColor = System.Drawing.Color.Transparent
        Me.btntambah.BackgroundImage = CType(resources.GetObject("btntambah.BackgroundImage"), System.Drawing.Image)
        Me.btntambah.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btntambah.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btntambah.FlatAppearance.BorderSize = 0
        Me.btntambah.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btntambah.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btntambah.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btntambah.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntambah.Location = New System.Drawing.Point(30, 82)
        Me.btntambah.Name = "btntambah"
        Me.btntambah.Size = New System.Drawing.Size(104, 42)
        Me.btntambah.TabIndex = 103
        Me.btntambah.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.btntambah.UseVisualStyleBackColor = False
        '
        'FormSingelItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.LaundyProject.My.Resources.Resources.th001X0WEA
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(496, 440)
        Me.Controls.Add(Me.btntambah)
        Me.Controls.Add(Me.DGVSingleItem)
        Me.Controls.Add(Me.Panel3)
        Me.Name = "FormSingelItem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form Singel Item"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVSingleItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btntambah As System.Windows.Forms.Button
    Friend WithEvents DGVSingleItem As System.Windows.Forms.DataGridView
    Friend WithEvents colIDPlgn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kol_layanan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kol_Terima As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kol_Edit As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents kol_Hapus As System.Windows.Forms.DataGridViewButtonColumn
End Class
