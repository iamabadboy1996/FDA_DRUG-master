﻿Imports Telerik.Web.UI
Public Class FRM_EXPERT_ASSIGN_V4
    Inherits System.Web.UI.Page
    Private _CLS As New CLS_SESSION
    Sub RunSession()
        Try
            If Session("CLS") Is Nothing Then
                Response.Redirect("http://privus.fda.moph.go.th/")
            Else
                _CLS = Session("CLS")
            End If
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            Dim bao As New BAO.ClsDBSqlcommand
            Dim dt As New DataTable

            Try
                If Request.QueryString("id_r") = "" Then
                    dt = bao.SP_GET_EXPERT_SELECTED_V4(Request.QueryString("rcvno"), Request.QueryString("ntype"), Request.QueryString("b_type"), Request.QueryString("s_type"), Request.QueryString("drgtpcd"))
                Else
                    dt = bao.SP_GET_EXPERT_SELECTED_BY_FK_IDA(Request.QueryString("ida"))
                End If
            Catch ex As Exception

            End Try
            set_labelV2(2)
            'If dt.Rows.Count > 0 Then
            '    btn_add.Style.Add("display", "none")
            'End If
        End If
    End Sub

    Protected Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Dim amount As Integer = 0
        Try
            amount = rm_amount.Value
        Catch ex As Exception

        End Try
        If amount > 0 Then
            For i As Integer = 1 To amount
                Try
                    'Dim dao_chk As New DAO_DRUG.TB_E_TRACKING_EXPERT_SELECTED
                    'dao_chk.GetDataby_FK_IDA()
                    Dim dao As New DAO_DRUG.TB_E_TRACKING_EXPERT_SELECTED
                    dao.fields.FK_EXPERT = 0
                    dao.fields.FK_EXPERT_SKILL = 0
                    dao.fields.FK_COMMENT = 0
                    Try
                        dao.fields.ctzid = Request.QueryString("ctzid")
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.rcvno = Request.QueryString("rcvno")
                    Catch ex As Exception

                    End Try
                    dao.fields.PRODUCT_TYPE = Request.QueryString("b_type")
                    dao.fields.SUB_PRODUCT_TYPE = Request.QueryString("s_type")
                    Try
                        dao.fields.rgttpcd = Request.QueryString("ntype")
                    Catch ex As Exception

                    End Try
                    Try
                        dao.fields.drgtpcd = Request.QueryString("drgtpcd")
                    Catch ex As Exception

                    End Try
                    dao.fields.FK_IDA = Request.QueryString("ida")
                    Try
                        dao.fields.COUNT_P = rnt_count.Value
                    Catch ex As Exception

                    End Try

                    dao.insert()

                    AddLogStatusEtracking(status_id:=0, STATUS_TYPE:=1, iden:=_CLS.CITIZEN_ID, description:="เพิ่มผู้เชี่ยวชาญจำนวน " & amount & " คน", PROCESS_NAME:="เพิ่มผู้เชี่ยวชาญ", FK_IDA:=Request.QueryString("id_r"), SUB_IDA:=dao.fields.IDA, SUB_STATUS:=0, url:=HttpContext.Current.Request.Url.AbsoluteUri)
                Catch ex As Exception

                End Try
            Next

            RadGrid1.Rebind()
        End If

    End Sub

    Private Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item
            Dim IDA As String = item("IDA").Text
            'Dim HEAD_STATUS_ID As String = item("HEAD_STATUS_ID").Text
            If e.CommandName = "_date" Then

                'Dim rgttpcd As String = item("rgttpcd").Text
                'Dim lcnsid As String = item("lcnsid").Text
                Dim url2 As String = "NEW/FRM_EXPERT_DATE_POPUP.aspx?rcvno=" & Request.QueryString("rcvno") & "&ntype=" & Request.QueryString("ntype") & "&new=1&b_type=" & Request.QueryString("b_type") & "&s_type=" & Request.QueryString("s_type") & "&IDA=" & IDA & "&drgtpcd=" & Request.QueryString("drgtpcd") & "&id_h=" & Request.QueryString("ida")
                If Request.QueryString("id_r") <> "" Then
                    url2 &= "&id_r=" & Request.QueryString("id_r")
                End If
                Response.Redirect(url2)

            End If

        End If
    End Sub

    Private Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType = GridItemType.Item Then
            Dim item As GridDataItem
            item = e.Item
            Dim ida As String = item("IDA").Text
            Dim P_ID As String = ""
            Dim S_ID As String = ""
            Dim C_ID As String = ""
            Try
                P_ID = item("FK_EXPERT").Text
            Catch ex As Exception
                P_ID = ""
            End Try
            Try
                S_ID = item("FK_EXPERT_SKILL").Text
            Catch ex As Exception
                S_ID = ""
            End Try
            Try
                C_ID = item("FK_COMMENT").Text
            Catch ex As Exception
                C_ID = ""
            End Try
            Dim rad_name As RadComboBox = DirectCast(item("name").FindControl("rcb_name"), RadComboBox)
            Dim rad_skill As RadComboBox = DirectCast(item("skill").FindControl("rcb_skill"), RadComboBox)
            Dim rad_comment As RadComboBox = DirectCast(item("comment").FindControl("rcb_comment"), RadComboBox)
            Dim lbl_name As Label = DirectCast(item("name").FindControl("lbl_name"), Label)
            Dim lbl_skill As Label = DirectCast(item("skill").FindControl("lbl_skill"), Label)
            Dim btn_date As LinkButton = DirectCast(item("btn_date").Controls(0), LinkButton)
            Dim lbl_comment As Label = DirectCast(item("comment").FindControl("lbl_comment"), Label)
            Dim rd_startdate As RadDatePicker = DirectCast(item("TIME_START_DATE").FindControl("rd_startdate"), RadDatePicker)
            Dim lbl_statdate As Label = DirectCast(item("TIME_START_DATE").FindControl("lbl_statdate"), Label)

            Dim dao As New DAO_DRUG.TB_MAS_EXPERT_NAME
            dao.GetDataALL()

            Dim dao_comment As New DAO_DRUG.TB_MAS_EXPERT_COMMENT
            dao_comment.GetDataAll()


            rad_name.DataSource = dao.datas
            rad_name.DataTextField = "FULLNAME"
            rad_name.DataValueField = "IDA"
            rad_name.DataBind()
            Dim r As New RadComboBoxItem
            r.Text = "กรุณาเลือก"
            r.Value = 0
            rad_name.Items.Insert(0, r)

            rad_comment.DataSource = dao_comment.datas
            rad_comment.DataTextField = "EXPERT_COMMENT"
            rad_comment.DataValueField = "IDA"
            rad_comment.DataBind()

            Dim r2 As New RadComboBoxItem
            r2.Text = "กรุณาเลือก"
            r2.Value = 0
            rad_comment.Items.Insert(0, r2)

            If P_ID <> "" And P_ID <> "0" Then
                rad_name.SelectedValue = P_ID
                lbl_name.Text = rad_name.SelectedItem.Text
                lbl_name.Style.Add("display", "block")
                rad_name.Style.Add("display", "none")
            Else
                btn_date.Style.Add("display", "none")
            End If
            If C_ID <> "" And C_ID <> "0" Then
                rad_comment.SelectedValue = P_ID
                lbl_comment.Text = rad_comment.SelectedItem.Text
                lbl_comment.Style.Add("display", "block")
                rad_comment.Style.Add("display", "none")
            Else
                btn_date.Style.Add("display", "none")
            End If



            Dim dao2 As New DAO_DRUG.TB_MAS_EXPERT_SKILL
            dao2.GetDataALL()
            rad_skill.DataSource = dao2.datas
            rad_skill.DataTextField = "EXPERT_SKILL"
            rad_skill.DataValueField = "IDA"
            rad_skill.DataBind()
            Dim r3 As New RadComboBoxItem
            r3.Text = "กรุณาเลือก"
            r3.Value = 0
            rad_skill.Items.Insert(0, r3)

            If S_ID <> "" And S_ID <> "0" Then
                rad_skill.SelectedValue = S_ID
                lbl_skill.Text = rad_skill.SelectedItem.Text
                lbl_skill.Style.Add("display", "block")
                rad_skill.Style.Add("display", "none")
            End If
            If C_ID <> "" And C_ID <> "0" Then
                rad_comment.SelectedValue = C_ID
                lbl_comment.Text = rad_comment.SelectedItem.Text
                lbl_comment.Style.Add("display", "block")
                rad_comment.Style.Add("display", "none")
            End If
            Try
                Dim dao_ex As New DAO_DRUG.TB_E_TRACKING_EXPERT_SELECTED
                dao_ex.GetDataby_IDA(item("IDA").Text)
                If dao_ex.fields.TIME_START_DATE IsNot Nothing Then
                    lbl_statdate.Text = CDate(dao_ex.fields.TIME_START_DATE).ToShortDateString()
                    lbl_statdate.Style.Add("display", "block")
                    rd_startdate.Style.Add("display", "none")
                End If

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable
        Try
            If Request.QueryString("id_r") = "" Then
                dt = bao.SP_GET_EXPERT_SELECTED_V4(Request.QueryString("rcvno"), Request.QueryString("ntype"), Request.QueryString("b_type"), Request.QueryString("s_type"), Request.QueryString("drgtpcd"))
            Else
                dt = bao.SP_GET_EXPERT_SELECTED_BY_FK_IDA(Request.QueryString("ida"))
            End If
        Catch ex As Exception

        End Try
        'Try
        '    dt = bao.SP_GET_EXPERT_SELECTED_V4(Request.QueryString("rcvno"), Request.QueryString("ntype"), Request.QueryString("b_type"), Request.QueryString("s_type"), Request.QueryString("drgtpcd"))
        'Catch ex As Exception

        'End Try

        RadGrid1.DataSource = dt
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If Len(rnt_count.Value) = 0 Then
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, GetType(Page), "ใส่ไรก็ได้", "alert('กรุณาเลือกครั้งที่');", True)
        Else

            For Each item As GridDataItem In RadGrid1.Items
                Dim dao As New DAO_DRUG.TB_E_TRACKING_EXPERT_SELECTED
                Dim rad_name As RadComboBox = DirectCast(item("name").FindControl("rcb_name"), RadComboBox)
                Dim rad_skill As RadComboBox = DirectCast(item("skill").FindControl("rcb_skill"), RadComboBox)
                Dim rad_comment As RadComboBox = DirectCast(item("comment").FindControl("rcb_comment"), RadComboBox)

                Dim rd_startdate As RadDatePicker = DirectCast(item("TIME_START_DATE").FindControl("rd_startdate"), RadDatePicker)

                Dim dao_chk As New DAO_DRUG.TB_E_TRACKING_EXPERT_SELECTED
                dao_chk.GetDataby_FK_IDA(Request.QueryString("ida"), rnt_count.Value, rad_skill.SelectedValue, rad_name.SelectedValue)

                If dao_chk.fields.IDA = 0 Then
                    dao.GetDataby_IDA(item("IDA").Text)
                    If dao.fields.FK_EXPERT = 0 Then
                        dao.fields.FK_EXPERT = rad_name.SelectedValue
                        dao.fields.FK_EXPERT_SKILL = rad_skill.SelectedValue

                    End If

                    Try
                        If dao.fields.TIME_START_DATE Is Nothing Then
                            dao.fields.TIME_START_DATE = rd_startdate.SelectedDate
                        End If
                    Catch ex As Exception

                    End Try
                    dao.update()
                End If

                Try
                    Dim dao_chk2 As New DAO_DRUG.TB_E_TRACKING_EXPERT_SELECTED
                    dao_chk2.GetDataby_OTHER_ID(Request.QueryString("ida"), rnt_count.Value, rad_skill.SelectedValue, rad_name.SelectedValue)
                    If dao_chk2.fields.IDA = 0 Then
                        Dim dao2 As New DAO_DRUG.TB_E_TRACKING_EXPERT_SELECTED
                        dao2.GetDataby_IDA(item("IDA").Text)
                        If dao2.fields.FK_COMMENT = 0 Then
                            dao2.fields.FK_COMMENT = rad_comment.SelectedValue
                            dao2.update()
                        End If
                    End If
                Catch ex As Exception

                End Try
                Dim str As String = ""
                str = "บันทึก " & rad_name.SelectedItem.Text & ", ด้าน - " & rad_skill.SelectedItem.Text & ", ผลประเมิน - " & rad_comment.SelectedItem.Text
                AddLogStatusEtracking(status_id:=0, STATUS_TYPE:=1, iden:=_CLS.CITIZEN_ID, description:=str, PROCESS_NAME:="บันทึกข้อมูลผู้เชี่ยวชาญ", FK_IDA:=Request.QueryString("id_r"), SUB_IDA:=dao.fields.IDA, SUB_STATUS:=0, url:=HttpContext.Current.Request.Url.AbsoluteUri)
            Next
            RadGrid1.Rebind()
        End If

    End Sub

    Private Sub btn_back_Click(sender As Object, e As EventArgs) Handles btn_back.Click
        Dim url As String = ""
        Dim url2 As String = ""
        'If Request.QueryString("extra") = "" Then

        If Request.QueryString("id_r") = "" Then
            url2 = "NEW/FRM_ETRACKING_STATUS_HEAD_MAIN.aspx?rcvno=" & Request.QueryString("rcvno") & "&ntype=" & Request.QueryString("ntype") & "&new=1&b_type=" & Request.QueryString("b_type") & "&s_type=" & Request.QueryString("s_type") & "&head=" & Request.QueryString("head") & "&drgtpcd=" & Request.QueryString("drgtpcd")
        Else
            url2 = "NEW/FRM_ETRACKING_STATUS_HEAD_MAIN_RQ_CENTER.aspx?id_r=" & Request.QueryString("id_r") & "&ida=" & Request.QueryString("ida") ' & "&FK_IDA=" & Request.QueryString("FK_IDA")
        End If


        'Else
        '    url2 = "../FRM_DRRGT_STATUS_POPUPV2.aspx?rcvno=" & Request.QueryString("rcvno") & "&ntype=" & Request.QueryString("ntype") & "&new=1&b_type=" & Request.QueryString("b_type") & "&s_type=" & Request.QueryString("s_type") & "&extra=1" & "&head=" & Request.QueryString("head")
        'End If

        Response.Redirect(url2)
    End Sub
    Sub set_labelV2(ByVal _type As Integer)
        Dim bao As New BAO.ClsDBSqlcommand
        Dim dt As New DataTable

        If _type = 1 Then 'ปกติ
            dt = bao.SP_E_TRACKING_PERSON_WORK_BY_RCVNO_AND_CTZID_NEW_V3(Request.QueryString("rcvno"), Request.QueryString("ntype"), Request.QueryString("drgtpcd"))

            For Each dr As DataRow In dt.Rows
                lbl_product_name.Text = dr("drgnm")
                lbl_lcnno_display.Text = dr("rcvno_display")
                'lbl_lcnsnm.Text = dr("thanm")
            Next

            Dim dao_max As New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
            dao_max.GetDataby_GEN3(Request.QueryString("rcvno"), Request.QueryString("ntype"), Request.QueryString("b_type"), Request.QueryString("s_type"))
            Dim max_num As Integer = 0
            Try
                max_num = dao_max.fields.STATUS_INDEX
            Catch ex As Exception

            End Try

            Dim dao_cur As New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
            dao_cur.GetDataCurrent(Request.QueryString("rcvno"), Request.QueryString("ntype"), Request.QueryString("b_type"), Request.QueryString("s_type"), max_num)

            Dim stat_id As Integer = 0
            Try
                stat_id = dao_cur.fields.STATUS_ID
            Catch ex As Exception

            End Try
            Dim dao_stat As New DAO_DRUG.TB_MAS_E_TRACKING_STATUS_NAME
            dao_stat.GetDataby_IDA(stat_id)
            Try
                lbl_stat.Text = dao_stat.fields.STAFF_STATUS & " (" & dao_stat.fields.STAGE_NAME & ")"
            Catch ex As Exception
                lbl_stat.Text = "-"
            End Try
            If stat_id = 0 Then
                lbl_stat.Text = "รอบันทึกสถานะเข้าระบบ"
            End If
            Try
                lbl_date.Text = CDate(dao_cur.fields.STATUS_DATE).ToShortDateString()
            Catch ex As Exception

            End Try
        ElseIf _type = 2 Then 'เลขR
            Dim dao As New DAO_DRUG.TB_DRUG_CONSIDER_REQUESTS
            dao.GetDataby_IDA(Request.QueryString("id_r"))
            lbl_lcnno_display.Text = dao.fields.RCVNO_DISPLAY
            lbl_lcnsnm.Text = dao.fields.ALLOW_NAME


            Dim dao_max As New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
            dao_max.GetDataby_GEN5(Request.QueryString("id_r"))
            Dim max_num As Integer = 0
            Try
                max_num = dao_max.fields.STATUS_INDEX
            Catch ex As Exception

            End Try

            Dim dao_cur As New DAO_DRUG.TB_E_TRACKING_CURRENT_STATUS
            dao_cur.GetDataCurrentv2(Request.QueryString("id_r"), max_num)

            Dim stat_id As Integer = 0
            Try
                stat_id = dao_cur.fields.STATUS_ID
            Catch ex As Exception

            End Try
            Dim dao_stat As New DAO_DRUG.TB_MAS_E_TRACKING_STATUS_NAME
            dao_stat.GetDataby_IDA(stat_id)
            Try
                lbl_stat.Text = dao_stat.fields.STAFF_STATUS & " (" & dao_stat.fields.STAGE_NAME & ")"
            Catch ex As Exception
                lbl_stat.Text = "-"
            End Try
            If stat_id = 0 Then
                lbl_stat.Text = "รอบันทึกสถานะเข้าระบบ"
            End If
            Try
                lbl_date.Text = CDate(dao_cur.fields.STATUS_DATE).ToShortDateString()
            Catch ex As Exception

            End Try
        End If


    End Sub
End Class