﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AlertConfiguration
    Inherits System.Windows.Forms.UserControl

    'UserControl은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AlertConfiguration))
        Me.TableLayoutPanel10 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.dtbCPUwaitratio = New eXperDB.Controls.DoubleTrackBarDraw()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtbConnections = New eXperDB.Controls.DoubleTrackBarDraw()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.dtbCommitratio = New eXperDB.Controls.DoubleTrackBarDraw()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtbBufferhitratio = New eXperDB.Controls.DoubleTrackBarDraw()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblTxAlert = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Button1 = New eXperDB.BaseControls.Button()
        Me.nudLockedtranccnt = New System.Windows.Forms.NumericUpDown()
        Me.nudLongrunsqlsec = New System.Windows.Forms.NumericUpDown()
        Me.nudLastvacuumDay = New System.Windows.Forms.NumericUpDown()
        Me.nudConfailedcnt = New System.Windows.Forms.NumericUpDown()
        Me.nudIdletranscnt = New System.Windows.Forms.NumericUpDown()
        Me.nudUnusedindexcnt = New System.Windows.Forms.NumericUpDown()
        Me.nudLastAnalyzeday = New System.Windows.Forms.NumericUpDown()
        Me.cbxLockedtranccnt = New eXperDB.BaseControls.CheckBox()
        Me.cbxLongrunsqlsec = New eXperDB.BaseControls.CheckBox()
        Me.cbxLastvacuumDay = New eXperDB.BaseControls.CheckBox()
        Me.cbxConfailedcnt = New eXperDB.BaseControls.CheckBox()
        Me.cbxIdletranscnt = New eXperDB.BaseControls.CheckBox()
        Me.cbxLastAnalyzeday = New eXperDB.BaseControls.CheckBox()
        Me.cbxUnusedindexcnt = New eXperDB.BaseControls.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel11 = New System.Windows.Forms.TableLayoutPanel()
        Me.dtbSWAPusedratio = New eXperDB.Controls.DoubleTrackBarDraw()
        Me.dtbDiskusedratio = New eXperDB.Controls.DoubleTrackBarDraw()
        Me.TableLayoutPanel10.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.nudLockedtranccnt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudLongrunsqlsec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudLastvacuumDay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudConfailedcnt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudIdletranscnt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudUnusedindexcnt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudLastAnalyzeday, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel11.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel10
        '
        Me.TableLayoutPanel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TableLayoutPanel10.ColumnCount = 2
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel10.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel10.Controls.Add(Me.dtbDiskusedratio, 0, 1)
        Me.TableLayoutPanel10.Controls.Add(Me.Label12, 1, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.Label13, 0, 0)
        Me.TableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel10.Location = New System.Drawing.Point(3, 285)
        Me.TableLayoutPanel10.Name = "TableLayoutPanel10"
        Me.TableLayoutPanel10.RowCount = 3
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel10.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel10.Size = New System.Drawing.Size(412, 88)
        Me.TableLayoutPanel10.TabIndex = 49
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label12.Location = New System.Drawing.Point(43, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(366, 30)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Disk used ratio"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label13.Image = CType(resources.GetObject("Label13.Image"), System.Drawing.Image)
        Me.Label13.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label13.Location = New System.Drawing.Point(3, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(34, 30)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "      "
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TableLayoutPanel9.ColumnCount = 2
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.Controls.Add(Me.dtbSWAPusedratio, 0, 1)
        Me.TableLayoutPanel9.Controls.Add(Me.Label10, 1, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.Label11, 0, 0)
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(3, 191)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 2
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(412, 88)
        Me.TableLayoutPanel9.TabIndex = 48
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label10.Location = New System.Drawing.Point(43, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(366, 30)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "SWAP used ratio"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Image = CType(resources.GetObject("Label11.Image"), System.Drawing.Image)
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label11.Location = New System.Drawing.Point(3, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 30)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "      "
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TableLayoutPanel8.ColumnCount = 2
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel8.Controls.Add(Me.dtbCPUwaitratio, 0, 1)
        Me.TableLayoutPanel8.Controls.Add(Me.Label8, 1, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.Label9, 0, 0)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(3, 473)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 2
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(412, 89)
        Me.TableLayoutPanel8.TabIndex = 47
        '
        'dtbCPUwaitratio
        '
        Me.dtbCPUwaitratio.BackColor = System.Drawing.Color.Gray
        Me.dtbCPUwaitratio.BarBorderColor = System.Drawing.Color.DimGray
        Me.dtbCPUwaitratio.BarColor = System.Drawing.Color.WhiteSmoke
        Me.dtbCPUwaitratio.BarHighLight = System.Drawing.SystemColors.Highlight
        Me.dtbCPUwaitratio.BarMaxValue = 70
        Me.dtbCPUwaitratio.BarMinValue = 50
        Me.dtbCPUwaitratio.BarSize = New System.Drawing.Size(14, 18)
        Me.dtbCPUwaitratio.CaptionSpacing = 10
        Me.TableLayoutPanel8.SetColumnSpan(Me.dtbCPUwaitratio, 2)
        Me.dtbCPUwaitratio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtbCPUwaitratio.ForeColor = System.Drawing.Color.White
        Me.dtbCPUwaitratio.Location = New System.Drawing.Point(3, 33)
        Me.dtbCPUwaitratio.Name = "dtbCPUwaitratio"
        Me.dtbCPUwaitratio.Size = New System.Drawing.Size(406, 53)
        Me.dtbCPUwaitratio.TabIndex = 40
        Me.dtbCPUwaitratio.Text = "DoubleTrackBarDraw1"
        Me.dtbCPUwaitratio.TickColor = System.Drawing.Color.Silver
        Me.dtbCPUwaitratio.TickSpacing = 20
        Me.dtbCPUwaitratio.TrackBorderColor = System.Drawing.Color.DimGray
        Me.dtbCPUwaitratio.TrackHeight = 6
        Me.dtbCPUwaitratio.YPosition = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label8.Location = New System.Drawing.Point(43, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(366, 30)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "CPU wait ratio"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Image = CType(resources.GetObject("Label9.Image"), System.Drawing.Image)
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label9.Location = New System.Drawing.Point(3, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(34, 30)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "      "
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TableLayoutPanel7.ColumnCount = 2
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel7.Controls.Add(Me.Label6, 1, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Label7, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.dtbConnections, 0, 1)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(3, 379)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 2
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(412, 88)
        Me.TableLayoutPanel7.TabIndex = 46
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label6.Location = New System.Drawing.Point(43, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(366, 30)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Connections"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Image = CType(resources.GetObject("Label7.Image"), System.Drawing.Image)
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.Location = New System.Drawing.Point(3, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 30)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "      "
        '
        'dtbConnections
        '
        Me.dtbConnections.BackColor = System.Drawing.Color.Gray
        Me.dtbConnections.BarBorderColor = System.Drawing.Color.DimGray
        Me.dtbConnections.BarColor = System.Drawing.Color.WhiteSmoke
        Me.dtbConnections.BarHighLight = System.Drawing.SystemColors.Highlight
        Me.dtbConnections.BarMaxValue = 70
        Me.dtbConnections.BarMinValue = 50
        Me.dtbConnections.BarSize = New System.Drawing.Size(14, 18)
        Me.dtbConnections.CaptionSpacing = 10
        Me.TableLayoutPanel7.SetColumnSpan(Me.dtbConnections, 2)
        Me.dtbConnections.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtbConnections.ForeColor = System.Drawing.Color.White
        Me.dtbConnections.Location = New System.Drawing.Point(3, 33)
        Me.dtbConnections.Name = "dtbConnections"
        Me.dtbConnections.Size = New System.Drawing.Size(406, 52)
        Me.dtbConnections.TabIndex = 39
        Me.dtbConnections.Text = "DoubleTrackBarDraw1"
        Me.dtbConnections.TickColor = System.Drawing.Color.Silver
        Me.dtbConnections.TickSpacing = 20
        Me.dtbConnections.TrackBorderColor = System.Drawing.Color.DimGray
        Me.dtbConnections.TrackHeight = 6
        Me.dtbConnections.YPosition = 10
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TableLayoutPanel6.ColumnCount = 2
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel6.Controls.Add(Me.dtbCommitratio, 0, 1)
        Me.TableLayoutPanel6.Controls.Add(Me.Label4, 1, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.Label5, 0, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(3, 97)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 2
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(412, 88)
        Me.TableLayoutPanel6.TabIndex = 45
        '
        'dtbCommitratio
        '
        Me.dtbCommitratio.BackColor = System.Drawing.Color.Gray
        Me.dtbCommitratio.BarBorderColor = System.Drawing.Color.DimGray
        Me.dtbCommitratio.BarColor = System.Drawing.Color.WhiteSmoke
        Me.dtbCommitratio.BarHighLight = System.Drawing.SystemColors.Highlight
        Me.dtbCommitratio.BarMaxValue = 70
        Me.dtbCommitratio.BarMinValue = 50
        Me.dtbCommitratio.BarSize = New System.Drawing.Size(14, 18)
        Me.dtbCommitratio.CaptionSpacing = 10
        Me.TableLayoutPanel6.SetColumnSpan(Me.dtbCommitratio, 2)
        Me.dtbCommitratio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtbCommitratio.ForeColor = System.Drawing.Color.White
        Me.dtbCommitratio.Location = New System.Drawing.Point(3, 33)
        Me.dtbCommitratio.Name = "dtbCommitratio"
        Me.dtbCommitratio.Size = New System.Drawing.Size(406, 52)
        Me.dtbCommitratio.TabIndex = 38
        Me.dtbCommitratio.Text = "DoubleTrackBarDraw1"
        Me.dtbCommitratio.TickColor = System.Drawing.Color.Silver
        Me.dtbCommitratio.TickSpacing = 20
        Me.dtbCommitratio.TrackBorderColor = System.Drawing.Color.DimGray
        Me.dtbCommitratio.TrackColor1 = System.Drawing.Color.Red
        Me.dtbCommitratio.TrackColor3 = System.Drawing.Color.Lime
        Me.dtbCommitratio.TrackHeight = 6
        Me.dtbCommitratio.YPosition = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Location = New System.Drawing.Point(43, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(366, 30)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Commit ratio"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Image = CType(resources.GetObject("Label5.Image"), System.Drawing.Image)
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.Location = New System.Drawing.Point(3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 30)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "      "
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TableLayoutPanel5.ColumnCount = 2
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel5.Controls.Add(Me.Label2, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.dtbBufferhitratio, 0, 1)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(412, 88)
        Me.TableLayoutPanel5.TabIndex = 44
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label2.Location = New System.Drawing.Point(43, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(366, 30)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Buffer hit ratio"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Image = CType(resources.GetObject("Label3.Image"), System.Drawing.Image)
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 30)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "      "
        '
        'dtbBufferhitratio
        '
        Me.dtbBufferhitratio.BackColor = System.Drawing.Color.Gray
        Me.dtbBufferhitratio.BarBorderColor = System.Drawing.Color.DimGray
        Me.dtbBufferhitratio.BarColor = System.Drawing.Color.WhiteSmoke
        Me.dtbBufferhitratio.BarHighLight = System.Drawing.SystemColors.Highlight
        Me.dtbBufferhitratio.BarMaxValue = 70
        Me.dtbBufferhitratio.BarMinValue = 50
        Me.dtbBufferhitratio.BarSize = New System.Drawing.Size(14, 18)
        Me.dtbBufferhitratio.CaptionSpacing = 10
        Me.TableLayoutPanel5.SetColumnSpan(Me.dtbBufferhitratio, 2)
        Me.dtbBufferhitratio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtbBufferhitratio.ForeColor = System.Drawing.Color.White
        Me.dtbBufferhitratio.Location = New System.Drawing.Point(3, 33)
        Me.dtbBufferhitratio.Name = "dtbBufferhitratio"
        Me.dtbBufferhitratio.Size = New System.Drawing.Size(406, 52)
        Me.dtbBufferhitratio.TabIndex = 26
        Me.dtbBufferhitratio.Text = "DoubleTrackBarDraw1"
        Me.dtbBufferhitratio.TickColor = System.Drawing.Color.Silver
        Me.dtbBufferhitratio.TickSpacing = 20
        Me.dtbBufferhitratio.TrackBorderColor = System.Drawing.Color.DimGray
        Me.dtbBufferhitratio.TrackColor1 = System.Drawing.Color.Red
        Me.dtbBufferhitratio.TrackColor3 = System.Drawing.Color.Lime
        Me.dtbBufferhitratio.TrackHeight = 6
        Me.dtbBufferhitratio.YPosition = 10
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.Controls.Add(Me.lblTxAlert, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.TableLayoutPanel3, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(421, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel11.SetRowSpan(Me.TableLayoutPanel4, 6)
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(329, 559)
        Me.TableLayoutPanel4.TabIndex = 26
        '
        'lblTxAlert
        '
        Me.lblTxAlert.AutoSize = True
        Me.lblTxAlert.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTxAlert.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTxAlert.ForeColor = System.Drawing.Color.White
        Me.lblTxAlert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTxAlert.Location = New System.Drawing.Point(43, 0)
        Me.lblTxAlert.Name = "lblTxAlert"
        Me.lblTxAlert.Size = New System.Drawing.Size(331, 30)
        Me.lblTxAlert.TabIndex = 0
        Me.lblTxAlert.Text = "Transaction alert"
        Me.lblTxAlert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.Color.Gray
        Me.TableLayoutPanel3.ColumnCount = 4
        Me.TableLayoutPanel4.SetColumnSpan(Me.TableLayoutPanel3, 2)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.15356!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.84644!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Button1, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.nudLockedtranccnt, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.nudLongrunsqlsec, 2, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.nudLastvacuumDay, 2, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.nudConfailedcnt, 2, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.nudIdletranscnt, 2, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.nudUnusedindexcnt, 2, 6)
        Me.TableLayoutPanel3.Controls.Add(Me.nudLastAnalyzeday, 2, 7)
        Me.TableLayoutPanel3.Controls.Add(Me.cbxLockedtranccnt, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.cbxLongrunsqlsec, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.cbxLastvacuumDay, 1, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.cbxConfailedcnt, 1, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.cbxIdletranscnt, 1, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.cbxLastAnalyzeday, 1, 6)
        Me.TableLayoutPanel3.Controls.Add(Me.cbxUnusedindexcnt, 1, 7)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 33)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 9
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(371, 523)
        Me.TableLayoutPanel3.TabIndex = 24
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1.CheckFillColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.Button1.FixedHeight = False
        Me.Button1.FixedWidth = False
        Me.Button1.Font = New System.Drawing.Font("Gulim", 9.0!)
        Me.Button1.GraColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Button1.LineColor = System.Drawing.Color.Gray
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Radius = 10
        Me.Button1.Size = New System.Drawing.Size(24, 13)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Button1"
        Me.Button1.UnCheckFillColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1.UseRound = True
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'nudLockedtranccnt
        '
        Me.nudLockedtranccnt.BackColor = System.Drawing.Color.White
        Me.nudLockedtranccnt.Dock = System.Windows.Forms.DockStyle.Top
        Me.nudLockedtranccnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.nudLockedtranccnt.Location = New System.Drawing.Point(244, 23)
        Me.nudLockedtranccnt.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudLockedtranccnt.Name = "nudLockedtranccnt"
        Me.nudLockedtranccnt.Size = New System.Drawing.Size(54, 21)
        Me.nudLockedtranccnt.TabIndex = 7
        Me.nudLockedtranccnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'nudLongrunsqlsec
        '
        Me.nudLongrunsqlsec.BackColor = System.Drawing.Color.White
        Me.nudLongrunsqlsec.ForeColor = System.Drawing.SystemColors.WindowText
        Me.nudLongrunsqlsec.Location = New System.Drawing.Point(244, 66)
        Me.nudLongrunsqlsec.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudLongrunsqlsec.Name = "nudLongrunsqlsec"
        Me.nudLongrunsqlsec.Size = New System.Drawing.Size(54, 21)
        Me.nudLongrunsqlsec.TabIndex = 9
        Me.nudLongrunsqlsec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'nudLastvacuumDay
        '
        Me.nudLastvacuumDay.BackColor = System.Drawing.Color.White
        Me.nudLastvacuumDay.ForeColor = System.Drawing.SystemColors.WindowText
        Me.nudLastvacuumDay.Location = New System.Drawing.Point(244, 109)
        Me.nudLastvacuumDay.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudLastvacuumDay.Name = "nudLastvacuumDay"
        Me.nudLastvacuumDay.Size = New System.Drawing.Size(54, 21)
        Me.nudLastvacuumDay.TabIndex = 11
        Me.nudLastvacuumDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'nudConfailedcnt
        '
        Me.nudConfailedcnt.BackColor = System.Drawing.Color.White
        Me.nudConfailedcnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.nudConfailedcnt.Location = New System.Drawing.Point(244, 152)
        Me.nudConfailedcnt.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudConfailedcnt.Name = "nudConfailedcnt"
        Me.nudConfailedcnt.Size = New System.Drawing.Size(54, 21)
        Me.nudConfailedcnt.TabIndex = 15
        Me.nudConfailedcnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'nudIdletranscnt
        '
        Me.nudIdletranscnt.BackColor = System.Drawing.Color.White
        Me.nudIdletranscnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.nudIdletranscnt.Location = New System.Drawing.Point(244, 195)
        Me.nudIdletranscnt.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudIdletranscnt.Name = "nudIdletranscnt"
        Me.nudIdletranscnt.Size = New System.Drawing.Size(54, 21)
        Me.nudIdletranscnt.TabIndex = 8
        Me.nudIdletranscnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'nudUnusedindexcnt
        '
        Me.nudUnusedindexcnt.BackColor = System.Drawing.Color.White
        Me.nudUnusedindexcnt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.nudUnusedindexcnt.Location = New System.Drawing.Point(244, 238)
        Me.nudUnusedindexcnt.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudUnusedindexcnt.Name = "nudUnusedindexcnt"
        Me.nudUnusedindexcnt.Size = New System.Drawing.Size(54, 21)
        Me.nudUnusedindexcnt.TabIndex = 10
        Me.nudUnusedindexcnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'nudLastAnalyzeday
        '
        Me.nudLastAnalyzeday.BackColor = System.Drawing.Color.White
        Me.nudLastAnalyzeday.ForeColor = System.Drawing.SystemColors.WindowText
        Me.nudLastAnalyzeday.Location = New System.Drawing.Point(244, 281)
        Me.nudLastAnalyzeday.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.nudLastAnalyzeday.Name = "nudLastAnalyzeday"
        Me.nudLastAnalyzeday.Size = New System.Drawing.Size(54, 21)
        Me.nudLastAnalyzeday.TabIndex = 13
        Me.nudLastAnalyzeday.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbxLockedtranccnt
        '
        Me.cbxLockedtranccnt.AutoSize = True
        Me.cbxLockedtranccnt.CheckFillColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.cbxLockedtranccnt.Dock = System.Windows.Forms.DockStyle.Top
        Me.cbxLockedtranccnt.ForeColor = System.Drawing.Color.White
        Me.cbxLockedtranccnt.LineColor = System.Drawing.Color.Gray
        Me.cbxLockedtranccnt.Location = New System.Drawing.Point(39, 23)
        Me.cbxLockedtranccnt.Name = "cbxLockedtranccnt"
        Me.cbxLockedtranccnt.Radius = 10
        Me.cbxLockedtranccnt.Size = New System.Drawing.Size(199, 16)
        Me.cbxLockedtranccnt.TabIndex = 16
        Me.cbxLockedtranccnt.Text = "Locked transaction count"
        Me.cbxLockedtranccnt.UnCheckFillColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbxLockedtranccnt.UseVisualStyleBackColor = True
        '
        'cbxLongrunsqlsec
        '
        Me.cbxLongrunsqlsec.AutoSize = True
        Me.cbxLongrunsqlsec.CheckFillColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.cbxLongrunsqlsec.ForeColor = System.Drawing.Color.White
        Me.cbxLongrunsqlsec.LineColor = System.Drawing.Color.Gray
        Me.cbxLongrunsqlsec.Location = New System.Drawing.Point(39, 66)
        Me.cbxLongrunsqlsec.Name = "cbxLongrunsqlsec"
        Me.cbxLongrunsqlsec.Radius = 10
        Me.cbxLongrunsqlsec.Size = New System.Drawing.Size(165, 16)
        Me.cbxLongrunsqlsec.TabIndex = 17
        Me.cbxLongrunsqlsec.Text = "Long running sql second"
        Me.cbxLongrunsqlsec.UnCheckFillColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbxLongrunsqlsec.UseVisualStyleBackColor = True
        '
        'cbxLastvacuumDay
        '
        Me.cbxLastvacuumDay.AutoSize = True
        Me.cbxLastvacuumDay.CheckFillColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.cbxLastvacuumDay.ForeColor = System.Drawing.Color.White
        Me.cbxLastvacuumDay.LineColor = System.Drawing.Color.Gray
        Me.cbxLastvacuumDay.Location = New System.Drawing.Point(39, 109)
        Me.cbxLastvacuumDay.Name = "cbxLastvacuumDay"
        Me.cbxLastvacuumDay.Radius = 10
        Me.cbxLastvacuumDay.Size = New System.Drawing.Size(118, 16)
        Me.cbxLastvacuumDay.TabIndex = 18
        Me.cbxLastvacuumDay.Text = "last vacuum day"
        Me.cbxLastvacuumDay.UnCheckFillColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbxLastvacuumDay.UseVisualStyleBackColor = True
        '
        'cbxConfailedcnt
        '
        Me.cbxConfailedcnt.AutoSize = True
        Me.cbxConfailedcnt.CheckFillColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.cbxConfailedcnt.ForeColor = System.Drawing.Color.White
        Me.cbxConfailedcnt.LineColor = System.Drawing.Color.Gray
        Me.cbxConfailedcnt.Location = New System.Drawing.Point(39, 152)
        Me.cbxConfailedcnt.Name = "cbxConfailedcnt"
        Me.cbxConfailedcnt.Radius = 10
        Me.cbxConfailedcnt.Size = New System.Drawing.Size(157, 16)
        Me.cbxConfailedcnt.TabIndex = 19
        Me.cbxConfailedcnt.Text = "Connection failed count"
        Me.cbxConfailedcnt.UnCheckFillColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbxConfailedcnt.UseVisualStyleBackColor = True
        '
        'cbxIdletranscnt
        '
        Me.cbxIdletranscnt.AutoSize = True
        Me.cbxIdletranscnt.CheckFillColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.cbxIdletranscnt.ForeColor = System.Drawing.Color.White
        Me.cbxIdletranscnt.LineColor = System.Drawing.Color.Gray
        Me.cbxIdletranscnt.Location = New System.Drawing.Point(39, 195)
        Me.cbxIdletranscnt.Name = "cbxIdletranscnt"
        Me.cbxIdletranscnt.Radius = 10
        Me.cbxIdletranscnt.Size = New System.Drawing.Size(159, 16)
        Me.cbxIdletranscnt.TabIndex = 20
        Me.cbxIdletranscnt.Text = "Idle in transaction count"
        Me.cbxIdletranscnt.UnCheckFillColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbxIdletranscnt.UseVisualStyleBackColor = True
        '
        'cbxLastAnalyzeday
        '
        Me.cbxLastAnalyzeday.AutoSize = True
        Me.cbxLastAnalyzeday.CheckFillColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.cbxLastAnalyzeday.ForeColor = System.Drawing.Color.White
        Me.cbxLastAnalyzeday.LineColor = System.Drawing.Color.Gray
        Me.cbxLastAnalyzeday.Location = New System.Drawing.Point(39, 238)
        Me.cbxLastAnalyzeday.Name = "cbxLastAnalyzeday"
        Me.cbxLastAnalyzeday.Radius = 10
        Me.cbxLastAnalyzeday.Size = New System.Drawing.Size(118, 16)
        Me.cbxLastAnalyzeday.TabIndex = 22
        Me.cbxLastAnalyzeday.Text = "last analyze day"
        Me.cbxLastAnalyzeday.UnCheckFillColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbxLastAnalyzeday.UseVisualStyleBackColor = True
        '
        'cbxUnusedindexcnt
        '
        Me.cbxUnusedindexcnt.AutoSize = True
        Me.cbxUnusedindexcnt.CheckFillColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.cbxUnusedindexcnt.ForeColor = System.Drawing.Color.White
        Me.cbxUnusedindexcnt.LineColor = System.Drawing.Color.Gray
        Me.cbxUnusedindexcnt.Location = New System.Drawing.Point(39, 281)
        Me.cbxUnusedindexcnt.Name = "cbxUnusedindexcnt"
        Me.cbxUnusedindexcnt.Radius = 10
        Me.cbxUnusedindexcnt.Size = New System.Drawing.Size(137, 16)
        Me.cbxUnusedindexcnt.TabIndex = 21
        Me.cbxUnusedindexcnt.Text = "Unused index count"
        Me.cbxUnusedindexcnt.UnCheckFillColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cbxUnusedindexcnt.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 30)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "      "
        '
        'TableLayoutPanel11
        '
        Me.TableLayoutPanel11.BackColor = System.Drawing.Color.Gray
        Me.TableLayoutPanel11.ColumnCount = 2
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.51129!))
        Me.TableLayoutPanel11.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.48871!))
        Me.TableLayoutPanel11.Controls.Add(Me.TableLayoutPanel4, 1, 0)
        Me.TableLayoutPanel11.Controls.Add(Me.TableLayoutPanel8, 0, 5)
        Me.TableLayoutPanel11.Controls.Add(Me.TableLayoutPanel10, 0, 3)
        Me.TableLayoutPanel11.Controls.Add(Me.TableLayoutPanel5, 0, 0)
        Me.TableLayoutPanel11.Controls.Add(Me.TableLayoutPanel9, 0, 2)
        Me.TableLayoutPanel11.Controls.Add(Me.TableLayoutPanel7, 0, 4)
        Me.TableLayoutPanel11.Controls.Add(Me.TableLayoutPanel6, 0, 1)
        Me.TableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel11.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel11.Name = "TableLayoutPanel11"
        Me.TableLayoutPanel11.RowCount = 6
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel11.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel11.Size = New System.Drawing.Size(753, 565)
        Me.TableLayoutPanel11.TabIndex = 3
        '
        'dtbSWAPusedratio
        '
        Me.dtbSWAPusedratio.BackColor = System.Drawing.Color.Gray
        Me.dtbSWAPusedratio.BarBorderColor = System.Drawing.Color.DimGray
        Me.dtbSWAPusedratio.BarColor = System.Drawing.Color.WhiteSmoke
        Me.dtbSWAPusedratio.BarHighLight = System.Drawing.SystemColors.Highlight
        Me.dtbSWAPusedratio.BarMaxValue = 70
        Me.dtbSWAPusedratio.BarMinValue = 50
        Me.dtbSWAPusedratio.BarSize = New System.Drawing.Size(14, 18)
        Me.dtbSWAPusedratio.CaptionSpacing = 10
        Me.TableLayoutPanel9.SetColumnSpan(Me.dtbSWAPusedratio, 2)
        Me.dtbSWAPusedratio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtbSWAPusedratio.ForeColor = System.Drawing.Color.White
        Me.dtbSWAPusedratio.Location = New System.Drawing.Point(3, 33)
        Me.dtbSWAPusedratio.Name = "dtbSWAPusedratio"
        Me.dtbSWAPusedratio.Size = New System.Drawing.Size(406, 52)
        Me.dtbSWAPusedratio.TabIndex = 44
        Me.dtbSWAPusedratio.Text = "DoubleTrackBarDraw1"
        Me.dtbSWAPusedratio.TickColor = System.Drawing.Color.Silver
        Me.dtbSWAPusedratio.TickSpacing = 20
        Me.dtbSWAPusedratio.TrackBorderColor = System.Drawing.Color.DimGray
        Me.dtbSWAPusedratio.TrackHeight = 6
        Me.dtbSWAPusedratio.YPosition = 10
        '
        'dtbDiskusedratio
        '
        Me.dtbDiskusedratio.BackColor = System.Drawing.Color.Gray
        Me.dtbDiskusedratio.BarBorderColor = System.Drawing.Color.DimGray
        Me.dtbDiskusedratio.BarColor = System.Drawing.Color.WhiteSmoke
        Me.dtbDiskusedratio.BarHighLight = System.Drawing.SystemColors.Highlight
        Me.dtbDiskusedratio.BarMaxValue = 70
        Me.dtbDiskusedratio.BarMinValue = 50
        Me.dtbDiskusedratio.BarSize = New System.Drawing.Size(14, 18)
        Me.dtbDiskusedratio.CaptionSpacing = 10
        Me.TableLayoutPanel10.SetColumnSpan(Me.dtbDiskusedratio, 2)
        Me.dtbDiskusedratio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtbDiskusedratio.ForeColor = System.Drawing.Color.White
        Me.dtbDiskusedratio.Location = New System.Drawing.Point(3, 33)
        Me.dtbDiskusedratio.Name = "dtbDiskusedratio"
        Me.TableLayoutPanel10.SetRowSpan(Me.dtbDiskusedratio, 2)
        Me.dtbDiskusedratio.Size = New System.Drawing.Size(406, 52)
        Me.dtbDiskusedratio.TabIndex = 53
        Me.dtbDiskusedratio.Text = "DoubleTrackBarDraw1"
        Me.dtbDiskusedratio.TickColor = System.Drawing.Color.Silver
        Me.dtbDiskusedratio.TickSpacing = 20
        Me.dtbDiskusedratio.TrackBorderColor = System.Drawing.Color.DimGray
        Me.dtbDiskusedratio.TrackHeight = 6
        Me.dtbDiskusedratio.YPosition = 10
        '
        'AlertConfiguration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Controls.Add(Me.TableLayoutPanel11)
        Me.Name = "AlertConfiguration"
        Me.Size = New System.Drawing.Size(753, 565)
        Me.TableLayoutPanel10.ResumeLayout(False)
        Me.TableLayoutPanel10.PerformLayout()
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.TableLayoutPanel9.PerformLayout()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel8.PerformLayout()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.TableLayoutPanel7.PerformLayout()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.TableLayoutPanel6.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.nudLockedtranccnt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudLongrunsqlsec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudLastvacuumDay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudConfailedcnt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudIdletranscnt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudUnusedindexcnt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudLastAnalyzeday, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel11.ResumeLayout(False)
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtbCPUwaitratio As eXperDB.Controls.DoubleTrackBarDraw
    Friend WithEvents dtbConnections As eXperDB.Controls.DoubleTrackBarDraw
    Friend WithEvents dtbCommitratio As eXperDB.Controls.DoubleTrackBarDraw
    Friend WithEvents dtbBufferhitratio As eXperDB.Controls.DoubleTrackBarDraw
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblTxAlert As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cbxConfailedcnt As eXperDB.BaseControls.CheckBox
    Friend WithEvents cbxLastvacuumDay As eXperDB.BaseControls.CheckBox
    Friend WithEvents cbxLongrunsqlsec As eXperDB.BaseControls.CheckBox
    Friend WithEvents cbxLockedtranccnt As eXperDB.BaseControls.CheckBox
    Friend WithEvents nudConfailedcnt As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudLastvacuumDay As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudLongrunsqlsec As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudLockedtranccnt As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button1 As eXperDB.BaseControls.Button
    Friend WithEvents cbxLastAnalyzeday As eXperDB.BaseControls.CheckBox
    Friend WithEvents cbxUnusedindexcnt As eXperDB.BaseControls.CheckBox
    Friend WithEvents cbxIdletranscnt As eXperDB.BaseControls.CheckBox
    Friend WithEvents nudLastAnalyzeday As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudUnusedindexcnt As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudIdletranscnt As System.Windows.Forms.NumericUpDown
    Friend WithEvents TableLayoutPanel10 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel9 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel11 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents dtbDiskusedratio As eXperDB.Controls.DoubleTrackBarDraw
    Friend WithEvents dtbSWAPusedratio As eXperDB.Controls.DoubleTrackBarDraw

End Class
