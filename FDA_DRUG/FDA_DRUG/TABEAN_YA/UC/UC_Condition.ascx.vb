﻿Imports System.IO
Imports System.Xml.Serialization

Public Class UC_Condition
    Inherits System.Web.UI.UserControl
    Private _IDA As Integer = 0
    Private _DTL_IDA As Integer
    Dim STATUS_ID As Integer = 0
    Private _CLS As New CLS_SESSION
    Sub RunQuery()
        Try
            _IDA = Request.QueryString("IDA")
        Catch ex As Exception
            _IDA = 0
        End Try
        Try
            _DTL_IDA = Request.QueryString("dtl")
        Catch ex As Exception

        End Try
        Try
            If Request.QueryString("STATUS_ID") <> "" Then
                STATUS_ID = Request.QueryString("STATUS_ID")
            Else
                STATUS_ID = Get_drrqt_Status_by_trid(Request.QueryString("tr_id"))
            End If
        Catch ex As Exception

        End Try
        Try
            _CLS = Session("CLS")
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()

        If Not IsPostBack Then
            If STATUS_ID = 8 Then
                Dim dao_dtl As New DAO_DRUG.TB_DRRGT_CONDITION
                dao_dtl.GetDataby_FK_IDA(_IDA)
                Try
                    txt_con1.Text = dao_dtl.fields.CONDITION1
                    txt_con2.Text = dao_dtl.fields.CONDITION2
                Catch ex As Exception

                End Try

            Else

                Dim dao_dtl As New DAO_DRUG.TB_DRRQT_CONDITION
                dao_dtl.GetDataby_FK_IDA(_IDA)
                Try
                    txt_con1.Text = dao_dtl.fields.CONDITION1
                    txt_con2.Text = dao_dtl.fields.CONDITION2
                Catch ex As Exception

                End Try
            End If
            If Request.QueryString("tt") <> "" Then
                btn_insert.Enabled = False
            End If
            'If STATUS_ID = "8" Then
            '    btn_insert.Enabled = False
            'End If
        End If
    End Sub

    Private Sub btn_insert_Click(sender As Object, e As EventArgs) Handles btn_insert.Click
        RunQuery()
        Dim old_data As String = ""
        Dim new_data As String = ""

        If STATUS_ID = 8 Then
            Dim dao As New DAO_DRUG.TB_DRRGT_CONDITION
            Dim dao_re As New DAO_DRUG.ClsDBdrrgt
            dao_re.GetDataby_IDA(_IDA)
            dao_re.fields.lmdfdate = Date.Now

            Dim IDA_C As Integer = 0
            Try
                Dim c As Integer = 0
                c = dao.count_id(_IDA)
                If c = 0 Then
                    Dim dao_c As New DAO_DRUG.TB_DRRGT_CONDITION
                    dao_c.fields.CONDITION1 = txt_con1.Text
                    dao_c.fields.CONDITION2 = txt_con2.Text
                    dao_c.fields.FK_IDA = _IDA
                    new_data = "บันทึก เงื่อนไขทั่วไป : " & txt_con1.Text & " , เงื่อนไขสำหรับพนักงานเจ้าหน้าที่ : " & txt_con2.Text
                    dao_c.insert()
                    IDA_C = dao_c.fields.IDA
                Else
                    Dim dao_dtl As New DAO_DRUG.TB_DRRGT_CONDITION
                    dao_dtl.GetDataby_FK_IDA(_IDA)
                    old_data = "แก้ไข เงื่อนไขทั่วไป : " & dao_dtl.fields.CONDITION1 & " , เงื่อนไขสำหรับพนักงานเจ้าหน้าที่ : " & dao_dtl.fields.CONDITION2
                    new_data = "แก้ไข เงื่อนไขทั่วไป : " & txt_con1.Text & " , เงื่อนไขสำหรับพนักงานเจ้าหน้าที่ : " & txt_con2.Text

                    dao_dtl.fields.CONDITION1 = txt_con1.Text
                    dao_dtl.fields.CONDITION2 = txt_con2.Text
                    dao_dtl.update()
                    IDA_C = dao.fields.IDA
                End If


                dao = New DAO_DRUG.TB_DRRGT_CONDITION
                dao.GetDataby_FK_IDA(Request.QueryString("IDA"))
                Dim max_no As Integer = 0
                Dim dao_edt As New DAO_DRUG.TB_DRRGT_EDIT_INDEX
                dao_edt.GET_MAX_NO("DRRGT_CONDITION", IDA_C)
                Try
                    max_no = dao_edt.fields.COUNT_EDIT
                Catch ex As Exception

                End Try
                Dim filename As String = ""
                filename = "DRRGT_CONDITION_" & max_no + 1 & ".xml"
                Dim bao_app As New BAO.AppSettings                                          'บอกที่อยู่ของไฟล์
                bao_app.RunAppSettings()
                Dim path As String = bao_app._PATH_EDIT & filename
                Dim objStreamWriter As New StreamWriter(path)                                                   'ประกาศตัวแปร
                Dim x As New XmlSerializer(dao.fields.GetType)                                                     'ประกาศ
                x.Serialize(objStreamWriter, dao.fields)
                objStreamWriter.Close()

                Dim dao_index As New DAO_DRUG.TB_DRRGT_EDIT_INDEX
                With dao_index.fields
                    .COUNT_EDIT = max_no + 1
                    .CREATE_DATE = Date.Now
                    .FILE_NAME = filename
                    .FK_DRRGT_IDA = _IDA
                    .FK_IDA = IDA_C
                    .TABLE_NAME = "DRRGT_CONDITION"
                End With
                dao_index.insert()

                alert("บันทึกเรียบร้อยแล้ว")
            Catch ex As Exception

            End Try

            If STATUS_ID = 8 Then
                Dim dao_rg As New DAO_DRUG.ClsDBdrrgt
                dao_rg.GetDataby_IDA(Request.QueryString("IDA"))

                Dim result As String = ""
                Dim ws_drug As New WS_DRUG_LOG_DR.WS_DRUG
                result = ""
                If Request.QueryString("e") <> "" Then
                    result = "EDIT RQT"
                End If
                Try
                    If Request.QueryString("e") = "" Then
                        ws_drug.Timeout = 8000
                        'result = ws_drug.XML_DRUG_MERGE_UPDATE(dao_rg.fields.pvncd, dao_rg.fields.rgttpcd, dao_rg.fields.drgtpcd, dao_rg.fields.rgtno, _CLS.CITIZEN_ID)
                        Dim dao_esub_xml As New DAO_XML_SEARCH_DRUG_LCN_ESUB.TB_XML_SEARCH_PRODUCT_GROUP_ESUB
                        dao_esub_xml.GetDataby_IDA_drrgt(Request.QueryString("IDA"))

                        Dim gen_xml_to_bc As New GEN_XML_TO_BC.GEN_XML_TO_BC.GEN_XML_XML_DRUG_PRO
                        Dim cls_xml_DR As New LGT_IOW_E
                        cls_xml_DR = gen_xml_to_bc.gen_xml_XML_DR_FORMULA_E_SUB_TXT(dao_esub_xml.fields.Newcode_U)
                        Dim str_xml As String = ""
                        Try
                            SEND_XML_DR(cls_xml_DR, dao_esub_xml.fields.Newcode_U, dao_rg.fields.IDENTIFY)
                            ws_drug.XML_DRUG_BC_UPDATE_TB(dao_esub_xml.fields.Newcode_U, _CLS.CITIZEN_ID)
                        Catch ex As Exception

                        End Try
                    End If

                Catch ex As Exception

                End Try
                Dim url As String = HttpContext.Current.Request.Url.AbsoluteUri

                KEEP_LOGS_TABEAN_BC(dao_rg.fields.pvncd, dao_rg.fields.rgttpcd, dao_rg.fields.drgtpcd, dao_rg.fields.rgtno, dao_rg.fields.IDA, _
                                    dao_rg.fields.IDENTIFY, new_data, "", old_data, result, url, _CLS.CITIZEN_ID)

            End If



            dao_re.update()

            'Dim ws_drug As New WS_DRUG.WS_DRUG
            'ws_drug.DRUG_UPDATE_DR(dao_re.fields.pvncd, dao_re.fields.rgttpcd, dao_re.fields.drgtpcd, dao_re.fields.rgtno)
        Else
            Dim dao As New DAO_DRUG.TB_DRRQT_CONDITION
            Dim dao_re As New DAO_DRUG.ClsDBdrrqt
            dao_re.GetDataby_IDA(_IDA)
            dao_re.fields.lmdfdate = Date.Now
            Try
                Dim c As Integer = 0
                c = dao.count_id(_IDA)
                If c = 0 Then
                    Dim dao_c As New DAO_DRUG.TB_DRRQT_CONDITION
                    dao_c.fields.CONDITION1 = txt_con1.Text
                    dao_c.fields.CONDITION2 = txt_con2.Text
                    dao_c.fields.FK_IDA = _IDA
                    dao_c.insert()
                Else
                    Dim dao_dtl As New DAO_DRUG.TB_DRRQT_CONDITION
                    dao_dtl.GetDataby_FK_IDA(_IDA)
                    dao_dtl.fields.CONDITION1 = txt_con1.Text
                    dao_dtl.fields.CONDITION2 = txt_con2.Text
                    dao_dtl.update()
                End If
                alert("บันทึกเรียบร้อยแล้ว")
            Catch ex As Exception

            End Try
            dao_re.update()
        End If
        KEEP_LOGS_TABEAN_EDIT(_IDA, "แก้ไขเงื่อนไข", _CLS.CITIZEN_ID)

        


    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
End Class