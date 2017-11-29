﻿Public Class frmMonMain


#Region "Declare"

    Public Enum ActStatus
        Activate = 0
        DeActivate = 1
    End Enum
 

    Private _GrpList As List(Of GroupInfo)
    ''' <summary>
    ''' Group List Items 안에 서버 리스트가 있음. 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property GrpList As List(Of GroupInfo)
        Get
            Return _GrpList
        End Get
    End Property

    Private _AgentCn As eXperDB.ODBC.DXODBC = Nothing
    ''' <summary>
    ''' 정책 서버 Connection 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property AgentCn As eXperDB.ODBC.DXODBC
        Get
            Return _AgentCn
        End Get
    End Property

    Private _ShowHchkNormal As Boolean = True
    Private _ShowHchkWarning As Boolean = True
    Private _ShowHchkCritical As Boolean = True

    Private _ElapseInterval As Integer = 3000
    Private _GroupRotateinterval As Integer = 30000



    Private _GrpListServerinfo As List(Of GroupInfo.ServerInfo)
    ''' <summary>
    ''' Group List Items 안에 서버 리스트가 있음. 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property GrpListServerinfo As List(Of GroupInfo.ServerInfo)
        Get
            Return _GrpListServerinfo
        End Get
    End Property


    Private _AgentInfo As structAgent
    ReadOnly Property AgentInfo As structAgent
        Get
            Return _AgentInfo
        End Get
    End Property


    'Private _ShowCritical As Boolean = True
    'Property ShowCritical As Boolean
    '    Get
    '        Return _ShowCritical
    '    End Get
    '    Set(value As Boolean)
    '        If Not _ShowCritical.Equals(value) Then
    '            _ShowCritical = value
    '            If _ShowCritical = False Then
    '                sb_CriticalClose()
    '            End If

    '        End If
    '    End Set
    'End Property

#End Region


#Region "Form"

#Region "Initialize & Finalize"
    ''' <summary>
    ''' 초기화 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(ByVal AgentCn As eXperDB.ODBC.DXODBC, ByVal GrpLst As List(Of GroupInfo), ByVal Elapseinterval As Integer, ByVal GroupRotateinterval As Integer, ByVal clsAgentInfo As structAgent)

        ' 이 호출은 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

        _AgentCn = AgentCn
        _GrpList = GrpLst

        _ElapseInterval = Elapseinterval
        _GroupRotateinterval = GroupRotateinterval
        tmCollect.Interval = _ElapseInterval
        tmRotateGroup.Interval = _GroupRotateinterval
        _AgentInfo = clsAgentInfo

        ReadConfig()


        'Me.ShowCritical = False
        Me.ShowCritical = True



    End Sub

    Private Sub ReadConfig()
        Dim clsIni As New Common.IniFile(p_AppConfigIni)
        _ShowHchkNormal = clsIni.ReadValue("General", "NORMAL_SHOW", True)
        _ShowHchkWarning = clsIni.ReadValue("General", "WARNING_SHOW", True)
        _ShowHchkCritical = clsIni.ReadValue("General", "CRITICAL_SHOW", True)


        nudBackendcnt.Value = clsIni.ReadValue("FORM", "SESSIONMAIN", 30)

        chkIDLE.Checked = clsIni.ReadValue("FORM", "IDLEMAIN", "False")



    End Sub
    Private Sub frmMonMain_FormControlRotation(e As Boolean) Handles Me.FormControlRotation
        Try
            If e = True Then
                tmRotateGroup.Start()
            Else
                tmRotateGroup.Stop()
            End If
        Catch ex As Exception
            p_Log.AddMessage(clsLog4Net.enmType.Error, ex.ToString)
        End Try
    End Sub
    Private Sub frmMonMain_FormControlPower(e As Boolean) Handles Me.FormControlPower
        Try

       
            If e = True Then

                p_clsAgentCollect.Start(_AgentCn, _ElapseInterval, p_ShowName)
                tmCollect.Start()
            Else
                tmCollect.Stop()
                p_clsAgentCollect.Stop()
            End If
        Catch ex As Exception
            p_Log.AddMessage(clsLog4Net.enmType.Error, ex.ToString)
        End Try
    End Sub



    ''' <summary>
    ''' Form Load 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmMonMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' 폼 초기화 
        InitForm()
        ' Set Radio Button Group = 처음 시작시 모니터링 서버 목록을 가져와서 존재하는 그룹만 화면에 출력한다. 
        sb_SetRbGrp(_GrpList)
        tmCollect.Start()
        ' Timer Thread를 생성하고 돌려줌
        ' Timer Thread 는 



    End Sub

    ''' <summary>
    ''' 화면 언어 및 컨트롤 초기화 실행 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InitForm()
        'modCommon.FontChange(Me, p_Font)
        Dim iniConfig As New Common.IniFile(p_AppConfigIni)



        ' 상태 이상 정보 
        grpStausSuminfo.Text = p_clsMsgData.fn_GetData("F028")
        lblNormal.Text = p_clsMsgData.fn_GetData("F029")
        lblWarning.Text = p_clsMsgData.fn_GetData("F030")
        lblCritical.Text = p_clsMsgData.fn_GetData("F031")

        ' 인스턴스 요약정보 
        grpInstSumInfo.Text = p_clsMsgData.fn_GetData("F032")

        ' CPU 정보 
        grpCPU.Text = p_clsMsgData.fn_GetData("F035")
        colGrpCpuSvrNm.HeaderText = p_clsMsgData.fn_GetData("F033")
        colGrpCpuSvrUsage.HeaderText = p_clsMsgData.fn_GetData("F034")

        radCpu.Style = iniConfig.ReadValue("STYLE", "CPU", 2)
        radCpu.ItemReverse = iniConfig.ReadValue("STYLE", "CPUREVERSE", False)

        ' Memory 정보 
        grpMem.Text = p_clsMsgData.fn_GetData("F036")
        colGrpMemSvrNm.HeaderText = p_clsMsgData.fn_GetData("F033")
        colGrpMemSvrUsage.HeaderText = p_clsMsgData.fn_GetData("F034")
        radMem.Style = iniConfig.ReadValue("STYLE", "MEM", 2)
        radMem.ItemReverse = iniConfig.ReadValue("STYLE", "MEMREVERSE", False)

        ' Request Information
        grpReqInfo.Text = p_clsMsgData.fn_GetData("F040")
        colDgvReqInfoSvrNm.HeaderText = p_clsMsgData.fn_GetData("F033")
        colDgvReqInfoInsert.HeaderText = p_clsMsgData.fn_GetData("F053")
        colDgvReqInfoInsert.HeaderCell.Style.ForeColor = chrReqInfo.Series("INSERT").Color
        colDgvReqInfoInsert.DefaultCellStyle.ForeColor = chrReqInfo.Series("INSERT").Color
        colDgvReqInfoInsert.DefaultCellStyle.SelectionForeColor = chrReqInfo.Series("INSERT").Color

        colDgvReqInfoRead.HeaderText = p_clsMsgData.fn_GetData("F054")
        colDgvReqInfoRead.HeaderCell.Style.ForeColor = chrReqInfo.Series("READ").Color
        colDgvReqInfoRead.DefaultCellStyle.ForeColor = chrReqInfo.Series("READ").Color
        colDgvReqInfoRead.DefaultCellStyle.SelectionForeColor = chrReqInfo.Series("READ").Color

        colDgvReqInfoUpdate.HeaderText = p_clsMsgData.fn_GetData("F055")
        colDgvReqInfoUpdate.HeaderCell.Style.ForeColor = chrReqInfo.Series("UPDATE").Color
        colDgvReqInfoUpdate.DefaultCellStyle.ForeColor = chrReqInfo.Series("UPDATE").Color
        colDgvReqInfoUpdate.DefaultCellStyle.SelectionForeColor = chrReqInfo.Series("UPDATE").Color

        colDgvReqInfoDelete.HeaderText = p_clsMsgData.fn_GetData("F056")
        colDgvReqInfoDelete.HeaderCell.Style.ForeColor = chrReqInfo.Series("DELETE").Color
        colDgvReqInfoDelete.DefaultCellStyle.ForeColor = chrReqInfo.Series("DELETE").Color
        colDgvReqInfoDelete.DefaultCellStyle.SelectionForeColor = chrReqInfo.Series("DELETE").Color

        colDgvReqInfoCommit.HeaderText = p_clsMsgData.fn_GetData("F057")
        colDgvReqInfoRollback.HeaderText = p_clsMsgData.fn_GetData("F058")




        ' Disk Access
        grpDiskAccess.Text = p_clsMsgData.fn_GetData("F041")
        colDgvDiskAccessSvrNm.HeaderText = p_clsMsgData.fn_GetData("F033")
        colDgvDiskAccessDiskNm.HeaderText = p_clsMsgData.fn_GetData("F085")
        colDgvDiskAccessRate.HeaderText = p_clsMsgData.fn_GetData("F043")

        ' Disk Usage
        grpDiskUsage.Text = p_clsMsgData.fn_GetData("F044")
        colDgvDiskUsageSvrNm.HeaderText = p_clsMsgData.fn_GetData("F033")
        colDgvDiskUsageDiskNm.HeaderText = p_clsMsgData.fn_GetData("F193")
        colDgvDiskUsageTot.HeaderText = p_clsMsgData.fn_GetData("F045")
        colDgvDiskUsageRate.HeaderText = p_clsMsgData.fn_GetData("F046")



        ' Session Information

        grpSessionInfo.Text = p_clsMsgData.fn_GetData("F089")
        dgvSessionInfo.AutoGenerateColumns = False
        colDgvSessionInfoSvrNm.HeaderText = p_clsMsgData.fn_GetData("F033")
        colDgvSessionInfoRead.HeaderText = p_clsMsgData.fn_GetData("F048")
        colDgvSessioninfoWrite.HeaderText = p_clsMsgData.fn_GetData("F136")
        colDgvSessionInfoCpuUsage.HeaderText = p_clsMsgData.fn_GetData("F049")
        colDgvSessionInfoTmStart.HeaderText = p_clsMsgData.fn_GetData("F050")
        colDgvSessionInfoTmElapse.HeaderText = p_clsMsgData.fn_GetData("F051")
        colDgvSessionInfoSQL.HeaderText = p_clsMsgData.fn_GetData("F052")

        chkIDLE.Text = p_clsMsgData.fn_GetData("F227")
        chkIDLE.Tag = p_clsMsgData.fn_GetSpecificData("F227", "COMMENTS")

        'Health 
        colDgvHealthSvrNm.HeaderText = p_clsMsgData.fn_GetData("F146")
        colDgvHealthSvrIP.HeaderText = p_clsMsgData.fn_GetData("F034")
        colDgvHealthSvrPort.HeaderText = p_clsMsgData.fn_GetData("F007")
        colDgvHealthSvrStatus.HeaderText = p_clsMsgData.fn_GetData("F063")





        Me.EspRight.Expand = False

        modCommon.FontChange(Me, p_Font)

    End Sub


    ''' <summary>
    ''' Group Radio Button 초기화 
    ''' </summary>
    ''' <param name="grpLst"></param>
    ''' <remarks></remarks>
    Private Sub sb_SetRbGrp(ByVal grpLst As List(Of GroupInfo))

        If grpLst Is Nothing Then Return

        ' 그룹 버튼을 Visible을 끈다. 
        For Each tmpCtl As Control In tlpGroup.Controls
            tmpCtl.Visible = False
        Next


        ' 컨트롤의 이름을 변경하고 Tag에 서버 목록을 저장한다. 
        ' 인스턴스 정보나 기타 정보는 CheckED
        For i As Integer = 0 To grpLst.Count - 1
            Dim tmpCtl As BaseControls.RadioButton = tlpGroup.Controls.Find("rbGrp" & i + 1, True)(0)
            tmpCtl.Text = grpLst.Item(i).GroupName
            tmpCtl.ForeColor = System.Drawing.Color.Gray
            tmpCtl.Visible = True
            ' tag 에 그룹에 속한 서버 리스트를 저장한다. 
            ' 버튼 선택시 자신의 Tag 에서 해당 리스트 목록을 가져오기 위함. 
            tmpCtl.Tag = GrpList.Item(i)
            If i = 0 Then
                tmpCtl.Checked = True
                tmpCtl.ForeColor = System.Drawing.Color.Yellow
            End If
        Next

    End Sub
    ''' <summary>
    ''' 그룹 박스 체크시 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbGrp_CheckedChanged(sender As Object, e As EventArgs) Handles rbGrp1.CheckedChanged, rbGrp2.CheckedChanged, rbGrp3.CheckedChanged, rbGrp4.CheckedChanged

        For i As Integer = 0 To _GrpList.Count - 1
            Dim tmpCtl As BaseControls.RadioButton = tlpGroup.Controls.Find("rbGrp" & i + 1, True)(0)
            tmpCtl.ForeColor = System.Drawing.Color.Gray
            tmpCtl.BackColor = System.Drawing.Color.Black
        Next

        Dim selCtl As BaseControls.RadioButton = TryCast(sender, BaseControls.RadioButton)
        If selCtl IsNot Nothing AndAlso selCtl.Checked = True Then
            selCtl.ForeColor = System.Drawing.Color.Yellow
            ' 컨트롤의 Tag에서 인스턴스 정보를 가져온다 
            Dim grpInfo As GroupInfo = selCtl.Tag
            ' 인스턴스에 따른 인스턴스 컨트롤 변경 시작 
            ' 인스턴스 상태 정보를 변경한다. 
            sb_SetInstanceStatus(grpInfo.Items)
            ' CPU 관련 목록을 변경한다. 
            sb_SetGrpCPU(grpInfo.Items)
            ' 메모리 관련 목록을 변경한다. 
            sb_SetGrpMem(grpInfo.Items)
            ' Disk Access , Disk Usage
            sb_setGrpDiskInfos()
            ' Request Info 
            sb_SetGrpReqinfo(grpInfo.Items)

            '서버 Alert ServerInfo
            _GrpListServerinfo = grpInfo.Items

            ' 인스턴스에 따른 인스턴스 컨트롤 변경 종료 
        End If
    End Sub





    Private Sub sb_SetGrpReqinfo(ByVal svrLst As List(Of GroupInfo.ServerInfo))
        For Each tmpSeries As DataVisualization.Charting.Series In Me.chrReqInfo.Series
            tmpSeries.Points.Clear()
        Next
        Dim srtLSt As New SortedList

        For i As Integer = 0 To svrLst.Count - 1
            srtLSt.Add(svrLst.Item(i).InstanceID, i)
            For Each tmpSeries As DataVisualization.Charting.Series In Me.chrReqInfo.Series
                Dim tmpInt As Integer = tmpSeries.Points.AddY(0)
                tmpSeries.Points(tmpInt).AxisLabel = svrLst.Item(i).ShowNm
            Next
        Next




        Me.chrReqInfo.Tag = srtLSt


        chrReqInfo.Invalidate()

        dgvReqInfo.Rows.Clear()



    End Sub

    ''' <summary>
    ''' GrpDiskAccess , grpDiskUsage 초기화 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub sb_setGrpDiskInfos()
        dgvGrpDiskAccess.Rows.Clear()
        dgvGrpDiskUsage.Rows.Clear()
    End Sub






    ''' <summary>
    ''' GrpCPU 컨트롤 초기화 
    ''' </summary>
    ''' <param name="svrLst"></param>
    ''' <remarks></remarks>
    Private Sub sb_SetGrpCPU(ByVal svrLst As List(Of GroupInfo.ServerInfo))
        ' 레이더 보이는 아이템을 모두 삭제한다. 
        radCpu.items.Clear()
        ' 레이더 컨트롤 옆의 Grid도 모두 삭제한다. 
        dgvGrpCpuSvrLst.Rows.Clear()

        ' Raider 및 DataGridview의 목록을 초기화로 넣는다. 
        For Each tmpSvr As GroupInfo.ServerInfo In svrLst
            radCpu.items.Add(tmpSvr.InstanceID, tmpSvr.ShowNm)
            Dim idxRow As Integer = dgvGrpCpuSvrLst.Rows.Add()
            dgvGrpCpuSvrLst.Rows(idxRow).Cells(colGrpCpuSvrID.Index).Value = tmpSvr.InstanceID
            dgvGrpCpuSvrLst.Rows(idxRow).Cells(colGrpCpuSvrNm.Index).Value = tmpSvr.ShowNm
            dgvGrpCpuSvrLst.Rows(idxRow).Cells(colGrpCpuSvrUsage.Index).Value = 0.0
            dgvGrpCpuSvrLst.Rows(idxRow).Cells(colGrpCpuSvrProg.Index).Value = 0.0
        Next


        DgvRowHeightFill(dgvGrpCpuSvrLst)
        AddHandler dgvGrpCpuSvrLst.SizeChanged, AddressOf DataGridView_SizeChanged
    End Sub
    ''' <summary>
    ''' GrpMem 컨트롤 초기화 
    ''' </summary>
    ''' <param name="svrLst"></param>
    ''' <remarks></remarks>
    Private Sub sb_SetGrpMem(ByVal svrLst As List(Of GroupInfo.ServerInfo))
        ' 레이더 보이는 아이템을 모두 삭제한다. 
        radMem.items.Clear()
        ' 레이더 컨트롤 옆의 Grid도 모두 삭제한다. 
        dgvGrpMemSvrLst.Rows.Clear()
        ' Raider 및 DataGridview의 목록을 초기화로 넣는다. 
        For Each tmpSvr As GroupInfo.ServerInfo In svrLst
            radMem.items.Add(tmpSvr.InstanceID, tmpSvr.ShowNm)
            Dim idxRow As Integer = dgvGrpMemSvrLst.Rows.Add()
            dgvGrpMemSvrLst.Rows(idxRow).Cells(colGrpMemSvrID.Index).Value = tmpSvr.InstanceID
            dgvGrpMemSvrLst.Rows(idxRow).Cells(colGrpMemSvrNm.Index).Value = tmpSvr.ShowNm
            dgvGrpMemSvrLst.Rows(idxRow).Cells(colGrpMemSvrUsage.Index).Value = 0.0
            dgvGrpMemSvrLst.Rows(idxRow).Cells(colGrpMemSvrprog.Index).Value = 0
        Next
        DgvRowHeightFill(dgvGrpMemSvrLst)
        AddHandler dgvGrpMemSvrLst.SizeChanged, AddressOf DataGridView_SizeChanged
    End Sub



    ''' <summary>
    ''' 인스턴스 상태 표시 컨트롤을 변경 
    ''' </summary>
    ''' <param name="svrLst"></param>
    ''' <remarks></remarks>
    Private Sub sb_SetInstanceStatus(ByVal svrLst As List(Of GroupInfo.ServerInfo))
        ' 모든 컨트롤을 Visible을 끈다. 
        'For Each tmpCtl As Control In tlpInstance.Controls
        '    Dim tmpProg3D As Controls.Progress3D = TryCast(tmpCtl, Controls.Progress3D)
        '    If tmpProg3D IsNot Nothing Then
        '        tmpProg3D.Visible = False
        '        tmpProg3D.Tag = Nothing
        '        If tmpProg3D.isSelected Then
        '            tmpProg3D.isSelected = False
        '        End If
        '        tmpProg3D.Value = 0
        '    End If
        'Next
        While (flpInstance.Controls.Count > 0)
            Dim tmpCtl As Progress3D = flpInstance.Controls.Item(0)
            tmpCtl.Items.Clear()
            RemoveHandler tmpCtl.SelectedChanged, AddressOf prog3Dinst1_SelectedChanged
            tmpCtl.Dispose()
        End While
        'For Each tmpCtl As Progress3D In flpInstance.Controls
        'RemoveHandler tmpCtl.SelectedChanged, AddressOf prog3Dinst1_SelectedChanged
        'Next

        flpInstance.Controls.Clear()



        ' 인스턴스 수 만큼 화면에 보여준다. 
        For i As Integer = 0 To svrLst.Count - 1
            Dim tmpCtl As Progress3D = CreateProgress3D("prog3Dinst" & i + 1)

            tmpCtl.Text = svrLst.Item(i).ShowNm
            tmpCtl.Tag = svrLst.Item(i)
            flpInstance.Controls.Add(tmpCtl)
            AddHandler tmpCtl.SelectedChanged, AddressOf prog3Dinst1_SelectedChanged

            'Dim tmpProg As Controls.Progress3D = tlpInstance.Controls("prog3Dinst" & i + 1)
            'tmpProg.Text = svrLst.Item(i).HostNm
            'tmpProg.Tag = svrLst.Item(i)
            'tmpProg.Visible = True
        Next

        flpInstance_SizeChanged(flpInstance, Nothing)

    End Sub



    Private Function CreateProgress3D(ByVal CtlNm As String) As Progress3D
        Dim tmpCtl As New Progress3D
        tmpCtl.Name = CtlNm


        Dim Progress3DItem1 As New Progress3D.Progress3DItem
        Dim Progress3DItem2 As New Progress3D.Progress3DItem
        Dim Progress3DItem3 As New Progress3D.Progress3DItem
        Progress3DItem1.Checked = False
        Progress3DItem1.FillColor = System.Drawing.Color.Lime
        Progress3DItem1.FillOpacity = 180
        Progress3DItem1.LineColor = System.Drawing.Color.Lime
        Progress3DItem1.LineOpacity = 220
        Progress3DItem1.Name = Nothing
        Progress3DItem2.Checked = False
        Progress3DItem2.FillColor = System.Drawing.Color.Orange
        Progress3DItem2.FillOpacity = 180
        Progress3DItem2.LineColor = System.Drawing.Color.Orange
        Progress3DItem2.LineOpacity = 220
        Progress3DItem2.Name = Nothing
        Progress3DItem3.Checked = False
        Progress3DItem3.FillColor = System.Drawing.Color.Red
        Progress3DItem3.FillOpacity = 180
        Progress3DItem3.LineColor = System.Drawing.Color.Red
        Progress3DItem3.LineOpacity = 220
        Progress3DItem3.Name = Nothing
        tmpCtl.Items.AddRange(New eXperDB.Controls.Progress3D.Progress3DItem() {Progress3DItem1, Progress3DItem2, Progress3DItem3})

        tmpCtl.Width = 78 ' Size = New System.Drawing.Size(78, 123)
        tmpCtl.Height = 123
        tmpCtl.Radius = 10
        tmpCtl.BackColor = System.Drawing.Color.Black
        tmpCtl.BorderColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        'tmpCtl.Dock = System.Windows.Forms.DockStyle.Fill
        tmpCtl.FillColor = System.Drawing.Color.Black
        tmpCtl.Font = New System.Drawing.Font("바탕", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        tmpCtl.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        tmpCtl.isSelected = False
        tmpCtl.Text = "Server #8"
        tmpCtl.UseAnimation = True
        tmpCtl.UseSelected = True
        tmpCtl.UseTitle = True
        tmpCtl.Value = 0
        tmpCtl.Margin = New Padding(0)



        Return tmpCtl
    End Function





    ''' <summary>
    ''' 프로그램 종료시 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmMonMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        tmRotateGroup.Stop()
        tmCollect.Stop()

        p_clsAgentCollect.Stop()
        ' 열려있는 창을 닫는다. 
        Dim ArrFrm As New ArrayList
        For Each tmpFrm As Form In Application.OpenForms
            ArrFrm.Add(tmpFrm)
        Next

        For Each tmpFrm As Form In ArrFrm
            tmpFrm.Show()
        Next
    End Sub

#End Region


    ''' <summary>
    ''' Controls Configuration 버튼 클릭시 메뉴 아이템을 보여준다. 
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmMonMain_FormControlConfig(e As Rectangle) Handles Me.FormControlConfig
        mnuPopup.Show(New Point(e.X, e.Y + e.Height), ToolStripDropDownDirection.Default)




    End Sub



    ''' <summary>
    ''' 환경 설정 메뉴 클릭시 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuConfig_Click(sender As Object, e As EventArgs) Handles mnuConfig.Click
        Dim frmConfig As New frmConfig
        frmConfig.ShowDialog()
        ReadConfig()


    End Sub



#End Region







    ''' <summary>
    ''' Detail 창 활성 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub prog3Dinst1_SelectedChanged(sender As Object, e As Progress3D.SelectEventArgs)

        If modCommon.fn_FormisLock(Me, _AgentCn) = True Then
            Dim strMsg As String = p_clsMsgData.fn_GetData("M005")
            MsgBox(strMsg)
            e.Cancel = True
            Return
        End If


        ' Tag에 값을 넝ㅎ어 두었음. 
        ' Dim intInstanceID As Integer = DirectCast(DirectCast(sender, Progress3D).Tag, GroupInfo.ServerInfo).InstanceID
        Dim svrInfo As GroupInfo.ServerInfo = TryCast(TryCast(sender, Progress3D).Tag, GroupInfo.ServerInfo)


        If e.Selected = True Then
            Dim FrmSub As New frmMonDetail(svrInfo, _ElapseInterval, AgentInfo, AgentCn)
            FrmSub.Owner = Me
            FrmSub.Show()
        Else


            For Each tmpFrm As Form In My.Application.OpenForms
                Dim frmDtl As frmMonDetail = TryCast(tmpFrm, frmMonDetail)
                If frmDtl IsNot Nothing AndAlso frmDtl.InstanceID = svrInfo.InstanceID Then
                    tmpFrm.Activate()
                    Exit For
                End If
            Next

            e.Cancel = True
            'End If


        End If

    End Sub


    Public Sub InstanceSelectedChange(ByVal intInstanceID As Integer, ByVal Bret As Boolean)
        For Each tmpCtl As Controls.Progress3D In Me.flpInstance.Controls
            If tmpCtl.Visible = True AndAlso DirectCast(tmpCtl.Tag, GroupInfo.ServerInfo).InstanceID.Equals(intInstanceID) Then
                tmpCtl.isSelected = Bret
                Exit For
            End If
        Next
        'For Each tmpCtl As Controls.Progress3D In Me.tlpInstance.Controls
        '    If tmpCtl.Visible = True AndAlso DirectCast(tmpCtl.Tag, GroupInfo.ServerInfo).InstanceID.Equals(intInstanceID) Then
        '        tmpCtl.isSelected = Bret
        '        Exit For
        '    End If
        'Next

    End Sub







    Private Sub grpDiskAccess_Enter(sender As Object, e As EventArgs) Handles grpDiskAccess.Enter

    End Sub


    ''' <summary>
    ''' alert 환경 설정 메뉴 클릭시 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub mnuAlertConfig_Click(sender As Object, e As EventArgs) Handles mnuAlertConfig.Click
        Dim AlertConfig As New frmAlertConfig(GrpListServerinfo)
        AlertConfig.Show()
    End Sub



#Region "Timer Thread "

    Private WithEvents tmCollect As New Timer
    Private Sub tmCollect_Tick(sender As Object, e As EventArgs) Handles tmCollect.Tick

        Try



            tmCollect.Stop()




            initControls(p_clsAgentCollect.AgentState)

            If p_clsAgentCollect.AgentState = clsCollect.AgntState.Activate Then

                clsAgentCollect_GetDataBackendinfo(p_clsAgentCollect.infoDataBackend)
                clsAgentCollect_GetDataCpuMem(p_clsAgentCollect.infoDataCpuMem)
                clsAgentCollect_GetDataDiskInfo(p_clsAgentCollect.infoDataDisk)
                clsAgentCollect_GetDataLockinfo(p_clsAgentCollect.infoDatalock)
                'clsAgentCollect_GetDataSQLRespTmInfo(p_clsAgentCollect.infoDataSQLRespTm)
                clsAgentCollect_GetDataObjectInfo(p_clsAgentCollect.infoDataObject, p_clsAgentCollect.infoDataSessioninfo)
                'clsAgentCollect_GetDataPhysicaliOinfo(p_clsAgentCollect.infoDataPhysicaliO)
                clsAgentCollect_GetDataHealthCheck(p_clsAgentCollect.infoDataHealth)
            Else
                'SerialCheck()

            End If

            'clsAgentCollect_GetDataRequestInfo(p_clsAgentCollect.infoDataRequest)
            'clsAgentCollect_GetDataCurrentActinfo(p_clsAgentCollect.infoDataCurrentAct)
            'clsAgentCollect_GetDataDBinfo(p_clsAgentCollect.infoDataDBinfo)
            'clsAgentCollect_GetDataTBspaceinfo(p_clsAgentCollect.infoDataTBspaceinfo)
            'clsAgentCollect_GetDataTBinfo(p_clsAgentCollect.infoDataTBinfo)
            'clsAgentCollect_GetDataIndexinfo(p_clsAgentCollect.infoDataIndexinfo)

            'logEvents.AppendTextNewLine(String.Format("[{0}] 데이터 정상 로드 완료", Now.ToString("yyyy-MM-dd HH:mm:ss")))

            Dim msgQueue As Queue(Of String) = p_clsAgentCollect.ThreadMsgQueue
            Do Until msgQueue.Count = 0
                Dim strMSg As String = msgQueue.Dequeue()
                logEvents.AppendTextNewLine(strMSg, Color.DarkGray)
            Loop
        Catch ex As Exception
            GC.Collect()
        Finally

            tmCollect.Start()
        End Try

    End Sub
    Private WithEvents tmRotateGroup As New Timer
    Private Sub tmRotateGroup_Tick(sender As Object, e As EventArgs) Handles tmRotateGroup.Tick

        Try
            tmRotateGroup.Stop()
            tmRotateGroup.Dispose()
            
            If _GrpList Is Nothing Then Return

            ' 컨트롤의 이름을 변경하고 Tag에 서버 목록을 저장한다. 
            ' 인스턴스 정보나 기타 정보는 CheckED
            Dim tmpCtl As BaseControls.RadioButton
            Dim CurrentCheckedIndex As Integer = 0
            For i As Integer = 0 To _GrpList.Count - 1
                tmpCtl = tlpGroup.Controls.Find("rbGrp" & i + 1, True)(0)
                If tmpCtl.Checked Then
                    CurrentCheckedIndex = i
                End If
            Next
            tmpCtl = tlpGroup.Controls.Find("rbGrp" & CurrentCheckedIndex + 1, True)(0)
            CurrentCheckedIndex = CurrentCheckedIndex + 1
            If CurrentCheckedIndex > _GrpList.Count - 1 Then
                CurrentCheckedIndex = 0
            End If
            tmpCtl = tlpGroup.Controls.Find("rbGrp" & CurrentCheckedIndex + 1, True)(0)
            tmpCtl.Tag = GrpList.Item(CurrentCheckedIndex)
            tmpCtl.Checked = True

        Catch ex As Exception
            GC.Collect()
        Finally
            tmRotateGroup.Start()
        End Try

    End Sub

    Private Sub SerialCheck()
        Dim clsQu As New clsQuerys(_AgentCn)
        Dim dtTable As DataTable = clsQu.SelectLicense()
        If dtTable IsNot Nothing Then
            If dtTable.Rows.Count = 0 Then
                p_clsAgentCollect.Stop()
                tmCollect.Stop()
                If MsgBox(p_clsMsgData.fn_GetData("M018")) = frmMsgbox.MsgBoxResult.OK Then
                    Me.Close()
                End If
            Else
                If dtTable.Rows(0).Item(0) <> "2" Then
                    p_clsAgentCollect.Stop()
                    tmCollect.Stop()
                    'tm_Serial.Stop()
                    If MsgBox(p_clsMsgData.fn_GetData("M018")) = frmMsgbox.MsgBoxResult.OK Then
                        Me.Close()
                    End If
                End If
            End If



        End If

    End Sub

    Private Sub clsAgentCollect_GetDataBackendinfo(ByVal dtTable As DataTable)
        If dtTable Is Nothing OrElse dtTable.Rows.Count = 0 Then Return

        Dim strSvrIDInQuery As String = ""

        For Each tmpCtl As Control In tlpGroup.Controls
            If TryCast(tmpCtl, BaseControls.RadioButton) IsNot Nothing _
                AndAlso tmpCtl.Visible = True _
                AndAlso tmpCtl.Tag IsNot Nothing _
                AndAlso DirectCast(tmpCtl, BaseControls.RadioButton).Checked = True Then

                Dim tmpGrp As GroupInfo = DirectCast(tmpCtl.Tag, GroupInfo)
                strSvrIDInQuery = String.Join(",", tmpGrp.Items.Select(Function(e) e.InstanceID))
            End If
        Next
        Dim subQuery As String = ""
        If chkIDLE.Checked = False Then
            Dim tmpStr As String = chkIDLE.Tag
            subQuery = String.Format(" AND SQL <> '{0}'", tmpStr)
        End If

        Dim dtView As DataView = New DataView(dtTable, String.Format("INSTANCE_ID IN ({0}) {1}", strSvrIDInQuery, subQuery), "CPU_USAGE DESC, ELAPSED_TIME DESC", DataViewRowState.CurrentRows)
        Dim showDt As DataTable = Nothing
        If dtView.Count > 0 Then
            showDt = dtView.ToTable.AsEnumerable.Take(nudBackendcnt.Value).CopyToDataTable
        End If

        dgvSessionInfo.DataSource = showDt
        dgvSessionInfo.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

        ' 하위폼이 있을 경우 하위폼에 던진다. 

        'For Each tmpFrm As Form In My.Application.OpenForms
        '    Dim subFrm As frmMonDetail = TryCast(tmpFrm, frmMonDetail)

        '    If subFrm IsNot Nothing Then
        '        subFrm.SetDataBackEnd(dtTable)
        '    End If
        'Next

    End Sub

    ''' <summary>
    ''' CPU / MEM 관련 정보가 변경되었을 경우 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clsAgentCollect_GetDataCpuMem(ByVal dtTable As DataTable)
        If dtTable Is Nothing Then Return

        For Each dtRow As DataRow In dtTable.DefaultView.ToTable(True, "INSTANCE_ID", "CPU_MAIN", "MEM_USED_RATE", "HOST_NAME").Rows
            ' GRP CPU
            Dim intInstID As Integer = dtRow.Item("INSTANCE_ID")
            Dim cpuidx As Integer = radCpu.items.IndexOf(intInstID)
            Dim strInstNm As String = dtRow.Item("HOST_NAME")
            If cpuidx >= 0 Then
                Dim dblCpu As Double = ConvDBL(dtRow.Item("CPU_MAIN"))
                radCpu.items(cpuidx).Value = dblCpu '  datainfo.C02_CPU_MAIN
                radCpu.items(cpuidx).Text = strInstNm

                Using tmpRow As DataGridViewRow = dgvGrpCpuSvrLst.FindFirstRow(intInstID, colGrpCpuSvrID.Index)
                    tmpRow.Cells(colGrpCpuSvrNm.Index).Value = strInstNm   'datainfo.C07_SWP_USED_RATE
                    tmpRow.Cells(colGrpCpuSvrUsage.Index).Value = dblCpu / 100  '  datainfo.C02_CPU_MAIN
                    tmpRow.Cells(colGrpCpuSvrProg.Index).Value = dblCpu ' datainfo.C02_CPU_MAIN
                End Using



                ' GRP MEM
                Dim memidx As Integer = radMem.items.IndexOf(intInstID)
                Dim dblMem As Double = ConvDBL(dtRow.Item("MEM_USED_RATE"))
                radMem.items(memidx).Value = dblMem
                radMem.items(memidx).Text = strInstNm

                Using tmpRow As DataGridViewRow = dgvGrpMemSvrLst.FindFirstRow(intInstID, colGrpMemSvrID.Index)
                    tmpRow.Cells(colGrpMemSvrNm.Index).Value = strInstNm   'datainfo.C07_SWP_USED_RATE
                    tmpRow.Cells(colGrpMemSvrUsage.Index).Value = dblMem / 100   'datainfo.C07_SWP_USED_RATE
                    tmpRow.Cells(colGrpMemSvrprog.Index).Value = dblMem  'datainfo.C07_SWP_USED_RATE
                End Using
            End If

        Next



        ' 컨트롤 색상 변경 
        modCommon.sb_GridProgClrChg(dgvGrpCpuSvrLst)
        sb_GridSortChg(dgvGrpCpuSvrLst, colGrpCpuSvrUsage.Index)
        modCommon.sb_GridProgClrChg(dgvGrpMemSvrLst)
        sb_GridSortChg(dgvGrpMemSvrLst, colGrpMemSvrUsage.Index)

        ' 하위폼이 있을 경우 하위폼에 던진다. 

        'For Each tmpFrm As Form In My.Application.OpenForms
        '    Dim subFrm As frmMonDetail = TryCast(tmpFrm, frmMonDetail)
        '    If subFrm IsNot Nothing Then
        '        subFrm.SetDataCpuMem(dtTable)
        '    End If
        'Next

    End Sub


    ''' <summary>
    '''  Disk Information 업데이트 되었을 경우 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clsAgentCollect_GetDataDiskInfo(ByVal dtTable As DataTable)
        If dtTable Is Nothing Then Return





        Dim UpdTime As Double = Now.ToOADate



        For Each dtRow As DataRow In dtTable.Rows
            ' GRP ACCESS
            Dim intInstID As Integer = dtRow.Item("INSTANCE_ID") ' datainfo.C00_INSTANCE_ID
            Dim strInstNm As String = dtRow.Item("HOST_NAME")
            ' 현재 활성화 목록을 CPU RAIDER 에서 검색한다. 있으면 뿌리고 없으면 뿌리지 않음. 
            ' 추후 개선할 것 
            Dim cpuidx As Integer = radCpu.items.IndexOf(intInstID)
            If cpuidx >= 0 Then
                If dtRow.Item("DISK_NAME") <> "-" Then
                    Dim strDiskNm As String = dtRow.Item("DISK_NAME")
                    Dim strKey As String = intInstID & strDiskNm
                    Dim dblRate As Double = ConvDBL(dtRow.Item("BUSY_RATE"))

                    ' 키로 찾기 위하여 Instance  + Disk Name 으로 키를 넣어둠. 
                    Using tmpRow As DataGridViewRow = dgvGrpDiskAccess.FindFirstRow(strKey, colDgvDiskAccessKey.Index)
                        If tmpRow Is Nothing Then
                            Dim intIdx As Integer = dgvGrpDiskAccess.Rows.Add() ' dgvGrpDiskAccess.InvokeRowsAdd
                            ' 디스크KEY
                            dgvGrpDiskAccess.Rows(intIdx).Cells(colDgvDiskAccessKey.Index).Value = strKey
                            ' 서버명칭 
                            dgvGrpDiskAccess.Rows(intIdx).Cells(colDgvDiskAccessSvrNm.Index).Value = strInstNm
                            ' 디스크명칭
                            dgvGrpDiskAccess.Rows(intIdx).Cells(colDgvDiskAccessDiskNm.Index).Value = strDiskNm
                            ' 사용률
                            dgvGrpDiskAccess.Rows(intIdx).Cells(colDgvDiskAccessProg.Index).Value = dblRate
                            dgvGrpDiskAccess.Rows(intIdx).Cells(colDgvDiskAccessRate.Index).Value = dblRate / 100
                            ' 마지막 갱신 시간 다 돌고 시간이 다른넘은 삭제한다. -- 기존 데이터를 계속 갱신하게 때문에 삭제에 대한 로직도 필요함. 
                            dgvGrpDiskAccess.Rows(intIdx).Cells(colDgvDiskAccessUpdTime.Index).Value = UpdTime
                        Else
                            ' 사용률
                            tmpRow.Cells(colDgvDiskAccessProg.Index).Value = dblRate
                            tmpRow.Cells(colDgvDiskAccessRate.Index).Value = dblRate / 100
                            ' 마지막 갱신 시간 다 돌고 시간이 다른넘은 삭제한다. -- 기존 데이터를 계속 갱신하게 때문에 삭제에 대한 로직도 필요함. 
                            tmpRow.Cells(colDgvDiskAccessUpdTime.Index).Value = UpdTime
                        End If
                    End Using
                End If

                If dtRow.Item("DEVICE_NAME") <> "-" Then
                    Dim strDeviceNm As String = dtRow.Item("DEVICE_NAME")
                    Dim strKey As String = intInstID & strDeviceNm
                    Dim dblTotKb As Double = ConvDBL(dtRow.Item("TOTAL_KB"))
                    Dim dblRate As Double = ConvDBL(dtRow.Item("DISK_USAGE_PER"))

                    ' GRP USAGE
                    Using tmpRow As DataGridViewRow = dgvGrpDiskUsage.FindFirstRow(strKey, colDgvDiskUsageKey.Index)
                        If tmpRow Is Nothing Then
                            'Dim intIdx As Integer = dgvGrpDiskUsage.InvokeRowsAdd
                            Dim intIDx As Integer = dgvGrpDiskUsage.Rows.Add()
                            ' Key 
                            dgvGrpDiskUsage.Rows(intIDx).Cells(colDgvDiskUsageKey.Index).Value = strKey
                            dgvGrpDiskUsage.Rows(intIDx).Cells(colDgvDiskUsageSvrNm.Index).Value = strInstNm
                            dgvGrpDiskUsage.Rows(intIDx).Cells(colDgvDiskUsageDiskNm.Index).Value = strDeviceNm
                            dgvGrpDiskUsage.Rows(intIDx).Cells(colDgvDiskUsageTot.Index).Value = dblTotKb
                            dgvGrpDiskUsage.Rows(intIDx).Cells(colDgvDiskUsageProg.Index).Value = dblRate
                            dgvGrpDiskUsage.Rows(intIDx).Cells(colDgvDiskUsageRate.Index).Value = dblRate / 100
                            dgvGrpDiskUsage.Rows(intIDx).Cells(colDgvDiskUsageUpdTime.Index).Value = UpdTime
                        Else
                            tmpRow.Cells(colDgvDiskUsageTot.Index).Value = dblTotKb
                            tmpRow.Cells(colDgvDiskUsageProg.Index).Value = dblRate
                            tmpRow.Cells(colDgvDiskUsageRate.Index).Value = dblRate / 100
                            tmpRow.Cells(colDgvDiskUsageUpdTime.Index).Value = UpdTime
                        End If

                    End Using
                End If
            End If
        Next

        ' 목록에 사라진것 삭제하기 
        dgvGrpDiskAccess.invokeRowsRemoves(UpdTime, colDgvDiskAccessUpdTime.Index, False)
        dgvGrpDiskUsage.invokeRowsRemoves(UpdTime, colDgvDiskUsageUpdTime.Index, False)

        dgvGrpDiskAccess.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
        dgvGrpDiskUsage.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)

        ' 컨트롤 색상 변경 
        modCommon.sb_GridProgClrChg(dgvGrpDiskAccess)
        sb_GridSortChg(dgvGrpDiskAccess, colDgvDiskAccessRate.Index)
        modCommon.sb_GridProgClrChg(dgvGrpDiskUsage)
        sb_GridSortChg(dgvGrpDiskUsage, colDgvDiskUsageRate.Index)

        'For Each tmpFrm As Form In My.Application.OpenForms
        '    Dim subFrm As frmMonDetail = TryCast(tmpFrm, frmMonDetail)
        '    If subFrm IsNot Nothing Then
        '        subFrm.SetDataDisk(dtTable)
        '    End If
        'Next


    End Sub

    'Private Delegate Sub delegateChartClear(ByVal Chart As DataVisualization.Charting.Chart)
    ' ''' <summary>
    ' ''' Thread 접근 불가로 인하여 대리자 선언 
    ' ''' </summary>
    ' ''' <param name="Chart"></param>
    ' ''' <remarks></remarks>
    'Private Sub sb_ChartClear(ByVal Chart As DataVisualization.Charting.Chart)
    '    If Chart.InvokeRequired Then
    '        Chart.Invoke(New delegateChartClear(AddressOf sb_ChartClear), Chart)
    '    Else
    '        For Each tmpSeries As DataVisualization.Charting.Series In Chart.Series
    '            tmpSeries.Points.Clear()
    '        Next
    '    End If

    'End Sub

    'Private Delegate Sub delegateChartPointSetY(ByVal Chart As DataVisualization.Charting.Chart, ByVal strSeries As String, ByVal intY As Double, ByVal strLabel As String)
    Private Sub sb_ChartPointSetY(ByVal Chart As DataVisualization.Charting.Chart, ByVal strSeries As String, ByVal intY As Double, ByVal strLabel As String)

        'If Chart.InvokeRequired Then
        '    Chart.Invoke(New delegateChartPointSetY(AddressOf sb_ChartPointSetY), Chart, strSeries, intY, strLabel)
        'Else
        Chart.Series(strSeries).Points.Add(intY)
        Chart.Series(strSeries).Label = strLabel
        'End If

    End Sub




    ''' <summary>
    ''' Lock 관련 정보가 업데이트 되었을 경우 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clsAgentCollect_GetDataLockinfo(ByVal dtTable As DataTable)
        If dtTable Is Nothing Then Return


        ' 하위폼이 있을 경우 하위폼에 던진다. 

        For Each tmpFrm As Form In My.Application.OpenForms
            Dim subFrm As frmMonActInfo = TryCast(tmpFrm, frmMonActInfo)
            If subFrm IsNot Nothing Then
                subFrm.SetDataLockinfo(dtTable)
            End If
        Next

    End Sub

    ' ''' <summary>
    ' ''' SQL Response Time 값이 변경 되었을 경우 
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub clsAgentCollect_GetDataSQLRespTmInfo(ByVal dtTable As DataTable)
    '    If dtTable Is Nothing Then Return




    '    ' 하위폼에 값을 던진다. 
    '    For Each tmpFrm As Form In My.Application.OpenForms
    '        Dim subFrm As frmMonDetail = TryCast(tmpFrm, frmMonDetail)
    '        If subFrm IsNot Nothing Then
    '            subFrm.SetDataSQLRespTm(dtTable)
    '        End If
    '    Next

    'End Sub





    ' ''' <summary>
    ' ''' Database information 값이 변경되었을 경우  
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub clsAgentCollect_GetDataDBinfo(ByVal dtTable As DataTable)
    '    If dtTable Is Nothing Then Return



    '        For Each tmpFrm As Form In My.Application.OpenForms
    '            Dim subFrm As frmMonActInfo = TryCast(tmpFrm, frmMonActInfo)
    '            If subFrm IsNot Nothing Then
    '                subFrm.SetDataDBinfo(dtTable)
    '            End If
    '        Next

    'End Sub

    ' ''' <summary>
    ' ''' tablespace Information 값이 변경되었을 경우  
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub clsAgentCollect_GetDataTBspaceinfo(ByVal dtTable As DataTable)
    '    If dtTable Is Nothing Then Return


    '    ' 하위폼에 값을 던진다. 
    '    For Each tmpFrm As Form In My.Application.OpenForms
    '        Dim subFrm As frmMonActInfo = TryCast(tmpFrm, frmMonActInfo)
    '        If subFrm IsNot Nothing Then
    '            subFrm.SetDataTBspaceinfo(dtTable)
    '        End If
    '    Next


    'End Sub



    ' ''' <summary>
    ' ''' table Information 값이 변경되었을 경우  
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub clsAgentCollect_GetDataTBinfo(ByVal dtTable As DataTable)
    '    If dtTable Is Nothing Then Return



    '    ' 하위폼에 값을 던진다. 
    '    For Each tmpFrm As Form In My.Application.OpenForms
    '        Dim subFrm As frmMonActInfo = TryCast(tmpFrm, frmMonActInfo)
    '        If subFrm IsNot Nothing Then
    '            subFrm.SetDataTBinfo(dtTable)
    '        End If
    '    Next

    'End Sub



    ' ''' <summary>
    ' ''' index Information 값이 변경되었을 경우  
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub clsAgentCollect_GetDataIndexinfo(ByVal dtTable As DataTable)
    '    If dtTable Is Nothing Then Return



    '    ' 하위폼에 값을 던진다. 
    '    For Each tmpFrm As Form In My.Application.OpenForms
    '        Dim subFrm As frmMonActInfo = TryCast(tmpFrm, frmMonActInfo)
    '        If subFrm IsNot Nothing Then
    '            subFrm.SetDataIndexinfo(dtTable)
    '        End If
    '    Next

    'End Sub



    Private Sub clsAgentCollect_GetDataObjectInfo(ByVal dtTableObject As DataTable, ByVal dtTableSession As DataTable)


        If dtTableObject Is Nothing Then Return
        Dim tmpSrtLst As SortedList = TryCast(Me.chrReqInfo.Tag, SortedList)

        Dim MaxPri As Double = 0 ' lngInsertTuples + lngDeleteTuples + lngUpdatetTuples
        Dim MaxSec As Double = 0 ' lngReadtTuples
        For Each dtRow As DataRow In dtTableObject.Rows
            ' GRP Reqinfo
            ' DgvreqInfo 
            Dim intInstID As Integer = dtRow.Item("INSTANCE_ID")
            ' 현재 활성화 목록을 CPU RAIDER 에서 검색한다. 있으면 뿌리고 없으면 뿌리지 않음. 
            ' 추후 개선할 것 
            Dim cpuidx As Integer = radCpu.items.IndexOf(intInstID)
            If cpuidx >= 0 Then
                Dim strInstNm As String = dtRow.Item("HOST_NAME")
                Dim lngInsertTuples As Long = ConvULong(dtRow.Item("INSERT_TUPLES_PER_SEC"))
                Dim lngReadtTuples As Long = ConvULong(dtRow.Item("SELECT_TUPLES_PER_SEC"))
                Dim lngUpdatetTuples As Long = ConvULong(dtRow.Item("UPDATE_TUPLES_PER_SEC"))
                Dim lngDeleteTuples As Long = ConvULong(dtRow.Item("DELETE_TUPLES_PER_SEC"))
                Dim lngCommitTuples As Long = ConvULong(dtRow.Item("COMMIT_TUPLES_PER_SEC"))
                Dim lngRollabckTuples As Long = ConvULong(dtRow.Item("ROLLBACK_TUPLES_PER_SEC"))



                ' 키로 찾기 위하여 Instance  + Disk Name 으로 키를 넣어둠. 
                Using tmpRow As DataGridViewRow = dgvReqInfo.FindFirstRow(intInstID, colDgvReqinfoID.Index)
                    If tmpRow Is Nothing Then
                        Dim intIdx As Integer = dgvReqInfo.Rows.Add
                        ' 디스크KEY
                        dgvReqInfo.Rows(intIdx).Cells(colDgvReqinfoID.Index).Value = intInstID
                        ' 서버명칭 
                        dgvReqInfo.Rows(intIdx).Cells(colDgvReqInfoSvrNm.Index).Value = strInstNm
                        dgvReqInfo.Rows(intIdx).Cells(colDgvReqInfoInsert.Index).Value = lngInsertTuples
                        dgvReqInfo.Rows(intIdx).Cells(colDgvReqInfoRead.Index).Value = lngReadtTuples
                        dgvReqInfo.Rows(intIdx).Cells(colDgvReqInfoUpdate.Index).Value = lngUpdatetTuples
                        dgvReqInfo.Rows(intIdx).Cells(colDgvReqInfoDelete.Index).Value = lngDeleteTuples
                        dgvReqInfo.Rows(intIdx).Cells(colDgvReqInfoCommit.Index).Value = lngCommitTuples
                        dgvReqInfo.Rows(intIdx).Cells(colDgvReqInfoRollback.Index).Value = lngRollabckTuples
                    Else
                        tmpRow.Cells(colDgvReqInfoInsert.Index).Value = lngInsertTuples
                        tmpRow.Cells(colDgvReqInfoRead.Index).Value = lngReadtTuples
                        tmpRow.Cells(colDgvReqInfoUpdate.Index).Value = lngUpdatetTuples
                        tmpRow.Cells(colDgvReqInfoDelete.Index).Value = lngDeleteTuples
                        tmpRow.Cells(colDgvReqInfoCommit.Index).Value = lngCommitTuples
                        tmpRow.Cells(colDgvReqInfoRollback.Index).Value = lngRollabckTuples

                    End If
                End Using
                If tmpSrtLst IsNot Nothing Then
                    Dim idx As Integer = tmpSrtLst.Item(intInstID)
                    Me.chrReqInfo.Series("INSERT").Points(idx).SetValueY(lngInsertTuples)
                    Me.chrReqInfo.Series("DELETE").Points(idx).SetValueY(lngDeleteTuples)
                    Me.chrReqInfo.Series("UPDATE").Points(idx).SetValueY(lngUpdatetTuples)
                    Me.chrReqInfo.Series("READ").Points(idx).SetValueY(lngReadtTuples)

                    MaxPri = Math.Max(lngInsertTuples + lngDeleteTuples + lngUpdatetTuples, MaxPri)
                    MaxSec = Math.Max(lngReadtTuples, MaxSec)


                    ' Invoke 로 처리함 귀찮 ㅎㅎ
                    'Me.chrReqInfo.Invoke(New MethodInvoker(Sub() Me.chrReqInfo.ChartAreas(0).RecalculateAxesScale()))


                End If

            End If

        Next


        If MaxPri > 0 Then

            Dim intPri As Integer = MaxPri \ 5
            intPri += 1
            Me.chrReqInfo.ChartAreas(0).AxisY.Maximum = intPri * 5
            Me.chrReqInfo.ChartAreas(0).AxisY.IntervalAutoMode = DataVisualization.Charting.IntervalAutoMode.FixedCount
            Me.chrReqInfo.ChartAreas(0).AxisY.Interval = Me.chrReqInfo.ChartAreas(0).AxisY.Maximum / 5
        End If
        If MaxSec > 0 Then
            Dim intSec As Integer = MaxSec \ 5
            intSec += 1
            Me.chrReqInfo.ChartAreas(0).AxisY2.Maximum = intSec * 5
            Me.chrReqInfo.ChartAreas(0).AxisY2.IntervalAutoMode = DataVisualization.Charting.IntervalAutoMode.FixedCount
            Me.chrReqInfo.ChartAreas(0).AxisY2.Interval = Me.chrReqInfo.ChartAreas(0).AxisY2.Maximum / 5
        End If


        Me.chrReqInfo.ChartAreas(0).RecalculateAxesScale()


        '' 하위폼에 값을 던진다. 
        'For Each tmpFrm As Form In My.Application.OpenForms
        '    Dim subFrm As frmMonDetail = TryCast(tmpFrm, frmMonDetail)
        '    If subFrm IsNot Nothing Then
        '        subFrm.SetDataRequest(dtTableObject, dtTableSession)
        '    End If
        'Next





        'For Each tmpFrm As Form In My.Application.OpenForms
        '    Dim subFrm As frmMonDetail = TryCast(tmpFrm, frmMonDetail)
        '    If subFrm IsNot Nothing Then
        '        subFrm.SetDataObject(dtTableObject)
        '    End If
        'Next



    End Sub

    'Private Sub clsAgentCollect_GetDataPhysicaliOinfo(ByVal dtTable As DataTable)
    '    If dtTable Is Nothing Then Return




    '    For Each tmpFrm As Form In My.Application.OpenForms
    '        Dim subFrm As frmMonDetail = TryCast(tmpFrm, frmMonDetail)
    '        If subFrm IsNot Nothing Then
    '            subFrm.SetDataPhysicaliO(dtTable)
    '        End If
    '    Next

    'End Sub


    Private Sub clsAgentCollect_GetDataHealthCheck(ByVal dtTable As DataTable)
        If dtTable Is Nothing Then Return
        ''Dim tmpDtTable As DataTable = dtTable.DefaultView.ToTable(True, "INSTANCE_ID , MAX(HCHK_VALUE)")

        ' Linq  Group Instance ID , Max 
        Dim InstanceMaxVals = _
            dtTable.AsEnumerable().GroupBy( _
                Function(r) New With {Key .InstanceID = r.Field(Of Integer)("INSTANCE_ID"), _
                              Key .IP = r.Field(Of String)("SERVER_IP"), _
                              Key .Port = r.Field(Of String)("SERVICE_PORT"), _
                              Key .Name = r.Field(Of String)("HOST_NAME")} _
                         ).[Select]( _
                         Function(grp) _
                             New With {Key .InstanceID = grp.Key.InstanceID, _
                                       Key .IP = grp.Key.IP, _
                                       Key .Port = grp.Key.Port, _
                                       Key .Name = grp.Key.Name, _
                                       Key .MaxVal = grp.Max(Function(e) e.Field(Of Integer)("HCHK_VALUE"))} _
                                   )



        ' Linq Group Instance ID A
        'Dim intNormalVal As Integer = CInt(Me.dgtNumN.Value)
        'Dim intWarningVal As Integer = CInt(Me.dgtNumW.Value)
        'Dim intCriticalVal As Integer = CInt(Me.dgtNumC.Value)

        Dim CntNormal As Integer = 0  'InstanceMaxVals.Count(Function(r) r.MaxVal = intNormalVal)
        Dim CntWarning As Integer = 0  'InstanceMaxVals.Count(Function(r) r.MaxVal = intWarningVal)
        Dim CntCritical As Integer = 0  'InstanceMaxVals.Count(Function(r) r.MaxVal = intCriticalVal)

        Dim arrSvrIds As New SortedList

        If InstanceMaxVals.Count > 0 Then
            For Each tmpCtl As Control In tlpGroup.Controls
                If TryCast(tmpCtl, BaseControls.RadioButton) IsNot Nothing AndAlso tmpCtl.Visible = True AndAlso tmpCtl.Tag IsNot Nothing Then
                    Dim tmpGrp As GroupInfo = DirectCast(tmpCtl.Tag, GroupInfo)
                    For Each tmpSvrInfo As GroupInfo.ServerInfo In tmpGrp.Items
                        Dim tmpInstance = InstanceMaxVals.AsEnumerable.Where(Function(e) e.InstanceID = tmpSvrInfo.InstanceID)
                        If tmpInstance.Count > 0 Then
                            Select Case tmpInstance(0).MaxVal / 100
                                Case 1 : CntNormal += 1
                                Case 2 : CntWarning += 1
                                Case 3 : CntCritical += 1 : arrSvrIds.Add(tmpInstance(0).InstanceID, tmpInstance(0).Name)
                            End Select
                        End If
                    Next
                End If
            Next



            ' Instance 컨트롤에 Tag에 InstanceID 를 넣어 둫었음.]
            For Each tmpCtl As Control In flpInstance.Controls
                If tmpCtl.Visible = True AndAlso tmpCtl.GetType.Equals(GetType(Progress3D)) Then
                    Dim intInstID As Integer = DirectCast(tmpCtl.Tag, GroupInfo.ServerInfo).InstanceID
                    If InstanceMaxVals.Where(Function(e) e.InstanceID = intInstID).Count > 0 Then
                        DirectCast(tmpCtl, Progress3D).Value = InstanceMaxVals.Where(Function(e) e.InstanceID = intInstID)(0).MaxVal / 100
                        tmpCtl.Text = InstanceMaxVals.Where(Function(e) e.InstanceID = intInstID)(0).Name
                    End If
                End If

            Next
            'For Each tmpCtl As Control In tlpInstance.Controls
            '    If tmpCtl.Visible = True AndAlso tmpCtl.GetType.Equals(GetType(Progress3D)) Then
            '        Dim intInstID As Integer = DirectCast(tmpCtl.Tag, GroupInfo.ServerInfo).InstanceID
            '        If InstanceMaxVals.Where(Function(e) e.InstanceID = intInstID).Count > 0 Then
            '            DirectCast(tmpCtl, Progress3D).Value = InstanceMaxVals.Where(Function(e) e.InstanceID = intInstID)(0).MaxVal / 100

            '        End If
            '    End If

            'Next
        End If



        dgtNumN.Value = CntNormal.ToString().PadLeft(InstanceMaxVals.Count.ToString.Length, "0")
        dgtNumW.Value = CntWarning.ToString.PadLeft(InstanceMaxVals.Count.ToString.Length, "0")
        dgtNumC.Value = CntCritical.ToString.PadLeft(InstanceMaxVals.Count.ToString.Length, "0")




        For Each InstanceMaxVal In InstanceMaxVals
            ' GRP CPU
            Dim intInstID As Integer = InstanceMaxVal.InstanceID
            Dim strStatus As String = fn_GetHealthName(InstanceMaxVal.MaxVal)


            Using dgvHealthRow As DataGridViewRow = dgvHealth.FindFirstRow(intInstID, colDgvHealthSvrID.Index)
                If dgvHealthRow Is Nothing Then
                    Dim intIDx As Integer = dgvHealth.Rows.Add

                    dgvHealth.Rows(intIDx).Cells(colDgvHealthSvrID.Index).Value = InstanceMaxVal.InstanceID
                    dgvHealth.Rows(intIDx).Cells(colDgvHealthSvrNm.Index).Value = InstanceMaxVal.Name
                    dgvHealth.Rows(intIDx).Cells(colDgvHealthSvrIP.Index).Value = InstanceMaxVal.IP
                    dgvHealth.Rows(intIDx).Cells(colDgvHealthSvrPort.Index).Value = InstanceMaxVal.Port
                    dgvHealth.Rows(intIDx).Cells(colDgvHealthSvrStatus.Index).Value = strStatus
                    dgvHealth.Rows(intIDx).Cells(colDgvHealthStatusVal.Index).Value = InstanceMaxVal.MaxVal


                Else
                    dgvHealthRow.Cells(colDgvHealthSvrStatus.Index).Value = strStatus
                    dgvHealthRow.Cells(colDgvHealthStatusVal.Index).Value = InstanceMaxVal.MaxVal
                End If

            End Using



        Next






        ' 컨트롤 색상 변경 
        modCommon.sb_GridProgClrChg(dgvHealth, colDgvHealthStatusVal.Index, p_RageHealthClr)
        sb_GridSortChg(dgvHealth, colDgvHealthStatusVal.Index)


        If CntCritical > 0 Then

            'Dim arrSvrLst As New ArrayList

            'For Each tmpLst In InstanceMaxVals.Where(Function(r) r.MaxVal = 300)
            'arrSvrLst.Add(tmpLst.Name)
            'arrSvrIds.Add(tmpLst.InstanceID, tmpLst.InstanceID)
            'Next

            SetGrpWarning(arrSvrIds)


            Me.radCpu.AniColorin = Color.Red
            Me.radMem.AniColorin = Color.Red


            If Me.ShowCritical = True Then




                sb_CriticalShow(arrSvrIds)
            End If
        Else
            Me.radCpu.AniColorin = Color.Lime
            Me.radMem.AniColorin = Color.Lime
            For Each tmpCtl As Control In tlpGroup.Controls
                If TryCast(tmpCtl, BaseControls.RadioButton) IsNot Nothing Then
                    DirectCast(tmpCtl, BaseControls.RadioButton).Warning = False
                End If
            Next
            sb_CriticalClose()
        End If


        Try


            For Each tmpRow As DataRow In dtTable.Rows

                Dim intHchkVal As Integer = tmpRow.Item("HCHK_VALUE")
                Dim strRegDt As DateTime = IIf(IsDBNull(tmpRow.Item("COLLECT_TIME")), Now, tmpRow.Item("COLLECT_TIME"))
                Dim strHost As String = tmpRow.Item("HOST_NAME")
                Dim strHchkNm As String = p_clsMsgData.fn_GetData(tmpRow.Item("HCHK_NAME"))
                Dim strValue As String = fn_GetValueCast(tmpRow.Item("HCHK_NAME"), tmpRow.Item("VALUE"))
                Dim strValueUnit As String = tmpRow.Item("UNIT")
                Dim strComment As String = IIf(IsDBNull(tmpRow.Item("COMMENTS")), "", tmpRow.Item("COMMENTS"))
                Dim strShowValue As String = "[{0}]{1}-{2} {3}{4} {5}"
                strShowValue = String.Format(strShowValue, strRegDt.ToString("HH:mm:ss"), strHost, strHchkNm, strValue, strValueUnit, strComment)



                If intHchkVal = 100 AndAlso _ShowHchkNormal Then
                    Me.logEvents.AppendTextNewLine(strShowValue, Color.Lime)
                ElseIf intHchkVal = 200 AndAlso _ShowHchkWarning Then
                    Me.logEvents.AppendTextNewLine(strShowValue, Color.Orange)
                ElseIf intHchkVal = 300 AndAlso _ShowHchkCritical Then
                    Me.logEvents.AppendTextNewLine(strShowValue, Color.Red)
                End If
            Next

        Catch ex As Exception
            Debug.Print(ex.ToString)
        End Try
        '' 하위폼이 있을 경우 하위폼에 던진다. 

        'For Each tmpFrm As Form In My.Application.OpenForms
        '    Dim subFrm As frmMonDetail = TryCast(tmpFrm, frmMonDetail)
        '    If subFrm IsNot Nothing Then
        '        subFrm.SetDataHealth(dtTable)
        '    End If
        'Next

    End Sub



    Private Sub SetGrpWarning(ByVal arrLst As SortedList)

        For Each tmpOpt As Control In tlpGroup.Controls
            If tmpOpt.GetType.Equals(GetType(BaseControls.RadioButton)) AndAlso tmpOpt.Visible = True Then
                Dim rdBtn As BaseControls.RadioButton = tmpOpt
                Dim grpInfos As GroupInfo = rdBtn.Tag
                Dim BretWarning As Boolean = False
                For Each tmpGrpinfo As GroupInfo.ServerInfo In grpInfos.Items
                    If arrLst.Item(tmpGrpinfo.InstanceID) IsNot Nothing Then
                        BretWarning = True
                        rdBtn.Warning = True
                        Exit For
                    End If
                Next
                If BretWarning = False Then
                    rdBtn.Warning = False
                End If

            End If
        Next

    End Sub







    Private Sub initControls(ByVal AgentStat As clsCollect.AgntState)
        Try

            lblAgentSvrState.Text = TryCast(p_clsAgentCollect.AgentState.GetType().GetMember(p_clsAgentCollect.AgentState.ToString)(0).GetCustomAttributes(GetType(System.ComponentModel.DescriptionAttribute), False)(0), System.ComponentModel.DescriptionAttribute).Description

            If AgentStat = clsCollect.AgntState.Activate Then
                lblAgentSvrState.ForeColor = Color.Lime
                radCpu.UseAnimation = True
                radMem.UseAnimation = True
            Else
                lblAgentSvrState.ForeColor = Color.Red
                ' Group Stop 
                For Each tmpCtl As eXperDB.BaseControls.RadioButton In tlpGroup.Controls
                    tmpCtl.Warning = False
                Next
                ' CPU STOP 
                radCpu.UseAnimation = False
                For Each tmpItm As RaiderItem In radCpu.items
                    tmpItm.Value = 0

                Next

                For Each tmpRow As DataGridViewRow In dgvGrpCpuSvrLst.Rows
                    tmpRow.Cells(colGrpCpuSvrProg.Index).Value = 0
                    tmpRow.Cells(colGrpCpuSvrUsage.Index).Value = 0
                    tmpRow.DefaultCellStyle.ForeColor = Color.DarkGray
                    tmpRow.DefaultCellStyle.SelectionForeColor = Color.DarkGray
                Next
                ' MEM STOP 
                radMem.UseAnimation = False

                For Each tmpitm As RaiderItem In radMem.items
                    tmpitm.Value = 0
                Next

                For Each tmpRow As DataGridViewRow In dgvGrpMemSvrLst.Rows
                    tmpRow.Cells(colGrpMemSvrprog.Index).Value = 0
                    tmpRow.Cells(colGrpMemSvrUsage.Index).Value = 0
                    tmpRow.DefaultCellStyle.ForeColor = Color.DarkGray
                    tmpRow.DefaultCellStyle.SelectionForeColor = Color.DarkGray
                Next

                ' HEAL COUNT STOP 
                dgtNumN.Value = 0
                dgtNumW.Value = 0
                dgtNumC.Value = 0


                For Each tmpCtl As Progress3D In flpInstance.Controls
                    tmpCtl.Value = 0
                Next
                ' GRID CLEAR 
                dgvGrpDiskAccess.Rows.Clear()
                dgvGrpDiskUsage.Rows.Clear()
                dgvSessionInfo.DataSource = Nothing
                dgvReqInfo.Rows.Clear()
                dgvHealth.Rows.Clear()

                ' CHART CLEAR 

                For Each tmpSeries As DataVisualization.Charting.Series In Me.chrReqInfo.Series
                    For Each tmpPt As DataVisualization.Charting.DataPoint In tmpSeries.Points
                        tmpPt.SetValueY(0)
                    Next
                Next


                Me.chrReqInfo.ChartAreas(0).RecalculateAxesScale()





            End If
        Catch ex As Exception
            p_Log.AddMessage(clsLog4Net.enmType.Error, ex.ToString)
        End Try

    End Sub


#End Region


    Private Sub dgvSessionInfo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSessionInfo.CellContentClick
        'SQL
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = colDgvSessionInfoSQL.Index Then
                Dim frmQuery As New frmQueryView(dgvSessionInfo.Rows(e.RowIndex).Cells(colDgvSessionInfoSQL.Index).Value, dgvSessionInfo.Rows(e.RowIndex).Cells(colDgvSessionInfoDBNm.Index).Value, dgvSessionInfo.Rows(e.RowIndex).Cells(colDgvSessionInfoInstID.Index).Value, _AgentInfo, dgvSessionInfo.Rows(e.RowIndex).Cells(colDgvSessionInfoUser.Index).Value)

                frmQuery.Show()
            End If
        End If
    End Sub

    Private Sub dgvSessionInfo_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSessionInfo.CellContentDoubleClick
    End Sub

    Private Sub mnuReports_Click(sender As Object, e As EventArgs) Handles mnuReports.Click
        Dim frmReport As New frmReports(_AgentCn, _GrpList, _AgentInfo)

        frmReport.Show(Me)


    End Sub

    Public Sub DgvRowHeightFill(ByVal ctlDgv As BaseControls.DataGridView)

        Dim height As Integer = Math.Ceiling((ctlDgv.Height - ctlDgv.ColumnHeadersHeight - 2) / ctlDgv.Rows.Count) - 1


        For Each tmpRow As DataGridViewRow In ctlDgv.Rows
            tmpRow.Height = height
        Next
    End Sub

    Private Sub DataGridView_SizeChanged(sender As Object, e As EventArgs)
        Dim ctlDgv As BaseControls.DataGridView = DirectCast(sender, BaseControls.DataGridView)
        If ctlDgv.IsHandleCreated Then
            DgvRowHeightFill(sender)
        End If


    End Sub

    Private Sub flpInstance_SizeChanged(sender As Object, e As EventArgs) Handles flpInstance.SizeChanged
        Dim BaseCTl As BaseControls.FlowLayoutPanel = sender
        Dim ctlWidth As Integer = (BaseCTl.Width - (2 * 2) - IIf(BaseCTl.VerticalScroll.Visible, 20, 0)) / 2
        Dim ctlHeight As Integer = (BaseCTl.Height - (2 * 4)) / 4

        For Each tmpCtl As Progress3D In BaseCTl.Controls
            tmpCtl.Width = ctlWidth
            tmpCtl.Height = ctlHeight
        Next


    End Sub


    Private Sub nudBackendcnt_ValueChanged(sender As Object, e As EventArgs) Handles nudBackendcnt.ValueChanged
        Dim clsIni As New Common.IniFile(p_AppConfigIni)
        clsIni.WriteValue("FORM", "SESSIONMAIN", DirectCast(sender, BaseControls.NumericUpDown).Value)


    End Sub

    Private Sub chkIDLE_CheckedChanged(sender As Object, e As EventArgs) Handles chkIDLE.CheckedChanged
        Dim clsIni As New Common.IniFile(p_AppConfigIni)
        clsIni.WriteValue("FORM", "IDLEMAIN", chkIDLE.Checked)
    End Sub

    Private Sub chrReqInfo_GetToolTipText(sender As Object, e As DataVisualization.Charting.ToolTipEventArgs) Handles chrReqInfo.GetToolTipText


        Select Case e.HitTestResult.ChartElementType
            Case DataVisualization.Charting.ChartElementType.Axis, DataVisualization.Charting.ChartElementType.TickMarks
                'Dim result As DataVisualization.Charting.HitTestResult = chrReqInfo.HitTest(e.X, e.Y, DataVisualization.Charting.ChartElementType.DataPoint)
                'If result.ChartElementType = DataVisualization.Charting.ChartElementType.DataPoint Then
                '    e.Text = result.Series.Points(result.PointIndex).AxisLabel & vbCrLf & result.Series.Name & vbCrLf & result.Series.Points(result.PointIndex).XValue.ToString & " : " & result.Series.Points(result.PointIndex).YValues(0).ToString
                'End If

                'Exit Select

            Case DataVisualization.Charting.ChartElementType.AxisLabels

                If e.HitTestResult.Object.GetType.Equals(GetType(DataVisualization.Charting.CustomLabel)) Then
                    e.Text = DirectCast(e.HitTestResult.Object, DataVisualization.Charting.CustomLabel).Text
                End If


            Case DataVisualization.Charting.ChartElementType.DataPoint
                If e.HitTestResult.Object.GetType.Equals(GetType(DataVisualization.Charting.DataPoint)) Then
                    Dim tmpDtp As DataVisualization.Charting.DataPoint = DirectCast(e.HitTestResult.Object, DataVisualization.Charting.DataPoint)
                    ' 메모리 공유 문제 인듯 디버그 시 보이나 ToString 사용하지 않으면 값이 나오지 않음 
                    Dim strServer As String = tmpDtp.AxisLabel.ToString

                    e.Text = String.Format("[{0}]{1}{2} : {3}", strServer, vbCrLf, e.HitTestResult.Series.Name, tmpDtp.YValues(0).ToString("N0"))
                End If


        End Select

    End Sub



    Private Sub chrReqInfo_Click(sender As Object, e As EventArgs) Handles chrReqInfo.Click

    End Sub

    'Private Sub tm_Serial_Tick(sender As Object, e As EventArgs)
    '    tm_Serial.Stop()
    '    Try


    '        Dim clsQry As New clsQuerys(_AgentCn)
    '        Dim dtTable As DataTable = clsQry.SelectSerialKey()
    '        If dtTable IsNot Nothing Then
    '            Dim dtRow As DataRow = dtTable.Rows(0)
    '            Dim strLicData As String = dtRow.Item("LICDATA")
    '            Dim CurDate As Date = dtRow.Item("CURDATETIME")
    '            Dim tmpStruct As New License(strLicData, "WebCash9")
    '            If tmpStruct.ExpireDate.Equals(DateTime.MinValue) Then
    '                MsgBox(p_clsMsgData.fn_GetData("M020"))
    '            Else
    '                Dim intDay As Integer = DateDiff(DateInterval.Day, CurDate, tmpStruct.ExpireDate)
    '                If intDay < 30 Then
    '                    MsgBox(p_clsMsgData.fn_GetData("M019", intDay))

    '                End If
    '            End If

    '        End If
    '    Catch ex As Exception
    '    Finally
    '        tm_Serial.Start()

    '    End Try



    'End Sub
#If 1 Then
    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
                 (ByVal hWnd As IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As IntPtr

    Private Const WM_LBUTTONDOWN As Long = &H201

    Private Sub dgvGrpCpuSvrLst_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGrpCpuSvrLst.CellContentClick
        If e.RowIndex >= 0 And e.RowIndex < 6 Then
            For Each tmpCtl As Progress3D In flpInstance.Controls
                If dgvGrpCpuSvrLst.Rows(e.RowIndex).Cells(0).Value = tmpCtl.Tag.InstanceID Then
                    SendMessage(tmpCtl.Handle.ToInt32, WM_LBUTTONDOWN, 1&, 0)
                    Exit For
                End If
            Next
        End If

    End Sub
#End If

    Private Sub dgvGrpCpuSvrLst_CellMouseMove(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvGrpCpuSvrLst.CellMouseMove
        If e.RowIndex >= 0 Then
            dgvGrpCpuSvrLst.Cursor = Cursors.Hand
            If dgvGrpCpuSvrLst.Rows(e.RowIndex).Selected = False Then
                dgvGrpCpuSvrLst.ClearSelection()
                dgvGrpCpuSvrLst.Rows(e.RowIndex).Selected = True
            End If
            For i As Integer = 0 To dgvGrpCpuSvrLst.ColumnCount - 1
                dgvGrpCpuSvrLst.Rows(e.RowIndex).Cells(i).Style.SelectionBackColor = Color.FromArgb(0, 20, 30)
                dgvGrpCpuSvrLst.Rows(e.RowIndex).Cells(i).Style.Font = New Font("Gulim", 10, FontStyle.Bold)

            Next
        End If
    End Sub

    Private Sub dgvGrpCpuSvrLst_CellMouseLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGrpCpuSvrLst.CellMouseLeave
        If e.RowIndex >= 0 Then
            dgvGrpCpuSvrLst.Cursor = Cursors.Arrow
            If dgvGrpCpuSvrLst.Rows(e.RowIndex).Selected = True Then
                dgvGrpCpuSvrLst.ClearSelection()
                dgvGrpCpuSvrLst.Rows(e.RowIndex).Selected = False
            End If
            For i As Integer = 0 To dgvGrpCpuSvrLst.ColumnCount - 1
                dgvGrpCpuSvrLst.Rows(e.RowIndex).Cells(i).Style.SelectionBackColor = dgvGrpCpuSvrLst.DefaultCellStyle.SelectionBackColor
                dgvGrpCpuSvrLst.Rows(e.RowIndex).Cells(i).Style.Font = dgvGrpCpuSvrLst.DefaultCellStyle.Font
            Next
        End If
    End Sub

    Private Sub dgvGrpMemSvrLst_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvGrpMemSvrLst.CellContentClick
        If e.RowIndex >= 0 And e.RowIndex < 6 Then
            For Each tmpCtl As Progress3D In flpInstance.Controls
                If dgvGrpMemSvrLst.Rows(e.RowIndex).Cells(0).Value = tmpCtl.Tag.InstanceID Then
                    SendMessage(tmpCtl.Handle.ToInt32, WM_LBUTTONDOWN, 1&, 0)
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub dgvGrpMemSvrLst_CellMouseMove(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvGrpMemSvrLst.CellMouseMove
        If e.RowIndex >= 0 Then
            dgvGrpMemSvrLst.Cursor = Cursors.Hand
            If dgvGrpMemSvrLst.Rows(e.RowIndex).Selected = False Then
                dgvGrpMemSvrLst.ClearSelection()
                dgvGrpMemSvrLst.Rows(e.RowIndex).Selected = True
            End If
            For i As Integer = 0 To dgvGrpMemSvrLst.ColumnCount - 1
                dgvGrpMemSvrLst.Rows(e.RowIndex).Cells(i).Style.SelectionBackColor = Color.FromArgb(0, 20, 30)
                dgvGrpMemSvrLst.Rows(e.RowIndex).Cells(i).Style.Font = New Font("Gulim", 10, FontStyle.Bold)

            Next
        End If
    End Sub

    Private Sub dgvGrpMemSvrLst_CellMouseLeave(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGrpMemSvrLst.CellMouseLeave
        If e.RowIndex >= 0 Then
            dgvGrpMemSvrLst.Cursor = Cursors.Arrow
            If dgvGrpMemSvrLst.Rows(e.RowIndex).Selected = True Then
                dgvGrpMemSvrLst.ClearSelection()
                dgvGrpMemSvrLst.Rows(e.RowIndex).Selected = False
            End If
            For i As Integer = 0 To dgvGrpMemSvrLst.ColumnCount - 1
                dgvGrpMemSvrLst.Rows(e.RowIndex).Cells(i).Style.SelectionBackColor = dgvGrpMemSvrLst.DefaultCellStyle.SelectionBackColor
                dgvGrpMemSvrLst.Rows(e.RowIndex).Cells(i).Style.Font = dgvGrpMemSvrLst.DefaultCellStyle.Font
            Next
        End If
    End Sub

    Private Sub dgvSessionInfo_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvSessionInfo.CellMouseMove
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = colDgvSessionInfoSQL.Index Then
                dgvSessionInfo.Cursor = Cursors.Hand
                If dgvSessionInfo.Rows(e.RowIndex).Selected = False Then
                    dgvSessionInfo.ClearSelection()
                    dgvSessionInfo.Rows(e.RowIndex).Selected = True
                End If
                For i As Integer = 0 To dgvSessionInfo.ColumnCount - 1
                    dgvSessionInfo.Rows(e.RowIndex).Cells(i).Style.SelectionBackColor = Color.FromArgb(0, 20, 30)
                Next
            End If
        End If
    End Sub

    Private Sub dgvSessionInfo_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSessionInfo.CellMouseLeave
        If e.RowIndex >= 0 Then
            If e.ColumnIndex = colDgvSessionInfoSQL.Index Then
                dgvSessionInfo.Cursor = Cursors.Arrow
                If dgvSessionInfo.Rows(e.RowIndex).Selected = True Then
                    dgvSessionInfo.ClearSelection()
                    dgvSessionInfo.Rows(e.RowIndex).Selected = False
                End If
                For i As Integer = 0 To dgvSessionInfo.ColumnCount - 1
                    dgvSessionInfo.Rows(e.RowIndex).Cells(i).Style.SelectionBackColor = dgvSessionInfo.DefaultCellStyle.SelectionBackColor
                Next
            End If
        End If
    End Sub

End Class