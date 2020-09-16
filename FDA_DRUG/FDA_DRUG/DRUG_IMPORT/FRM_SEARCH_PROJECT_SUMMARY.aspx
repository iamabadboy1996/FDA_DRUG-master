﻿<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_SEARCH_PROJECT_SUMMARY.aspx.vb" Inherits="FDA_DRUG.FRM_SEARCH_PROJECT_SUMMARY" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
      <script type="text/javascript" >

          $(document).ready(function () {
              //$(window).load(function () {
              //    $.ajax({
              //        type: 'POST',
              //        data: { submit: true },
              //        success: function (result) {
              //            $('#spinner').fadeOut(1);

              //        }
              //    });
              //});

              function CloseSpin() {
                  $('#spinner').toggle('slow');
              }

              $('#ContentPlaceHolder1_btn_upload').click(function () {
                  Popups('POPUP_LCN_UPLOAD_ATTACH_SELECT.aspx');
                  return false;
              });

              $('#ContentPlaceHolder1_btn_download').click(function () {
                  Popups('POPUP_LCN_DOWNLOAD_DRUG.aspx');
                  return false;
              });

              function Popups(url) { // สำหรับทำ Div Popup

                  $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                  var i = $('#f1'); // ID ของ iframe   
                  i.attr("src", url); //  url ของ form ที่จะเปิด
              }

          });

          function Popups2(url) { // สำหรับทำ Div Popup
              $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
              var i = $('#f1'); // ID ของ iframe   
              i.attr("src", url); //  url ของ form ที่จะเปิด
          }
          function Popups3(url) { // สำหรับทำ Div Popup

              $('#myModal2').modal('toggle'); // เป็นคำสั่งเปิดปิด
              var i = $('#f2'); // ID ของ iframe   
              i.attr("src", url); //  url ของ form ที่จะเปิด
          }
          function spin_space() { // คำสั่งสั่งปิด PopUp
              //    alert('123456');
              $('#spinner').toggle('slow');
              //$('#myModal').modal('hide');
              //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

          }
          function close_modal() { // คำสั่งสั่งปิด PopUp
              $('#myModal').modal('hide');
              $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
          }

          function close_modal2() { // คำสั่งสั่งปิด PopUp
              $('#myModal2').modal('hide');
              $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
          }
        </script> 

      <div id="spinner" style=" background-color:transparent; display:none; " >
  <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
</div>

    
    <div class="h3" style="padding-left:5%;">  <asp:Label ID="lbl_name" runat="server" Visible="false" Text=""></asp:Label> </div>
    
     <div class="panel" style="text-align:left ;width:100%">
         <div class="panel-heading panel-title" style="height:70px" > 
            
             <div  class="col-lg-4 col-md-4"><h2> รายละเอียดโครงการวิจัย</h2> </div>

         </div>
    
    </div>

               

       <div class="panel panel-body"  style="width:100%;padding-left:5%;">
           <table style="width:100%;">
               <tr>
                   <td align="right">
                       <asp:Label ID="lbl_remark" runat="server" Text="*หมายเหตุ เมื่ออัพโหลดคำขออนุญาตผลิตยาแผนปัจจุบันแล้ว ให้ทำการเพิ่มหมวดยาจึงจะสามารถส่งคำขอได้" style="display:none;"></asp:Label>                
                   </td>
               </tr>
           </table>
           <center>
           <asp:TextBox ID="TextBox1" runat="server" Height="45px" Width="500px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" CssClass="btn-lg" runat="server" Text="ค้นหา" />
               <br />
               <br />
               </center>
           <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="15" Visible="false">
               <MasterTableView AutoGenerateColumns="False">
                   <Columns>
                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                           SortExpression="IDA" UniqueName="IDA" Display="false">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="CREATE_DATE" DataType="System.Int32" FilterControlAltText="Filter CREATE_DATE column" HeaderText="CREATE_DATE"  DataFormatString="{0:dd/MM/yyyy}"
                           SortExpression="CREATE_DATE" UniqueName="CREATE_DATE">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="TR_ID" DataType="System.Int32" FilterControlAltText="Filter TR_ID column" HeaderText="TR_ID"
                           SortExpression="TR_ID" UniqueName="TR_ID">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="TFDA_CT_no" FilterControlAltText="Filter TFDA_CT_no column"
                           HeaderText="TFDA_CT_no" SortExpression="TFDA_CT_no" UniqueName="TFDA_CT_no">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="pj_code" FilterControlAltText="Filter pj_code column"
                           HeaderText="pj_code" SortExpression="pj_code" UniqueName="pj_code">
                       </telerik:GridBoundColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                           CommandName="sel" Text="ดูข้อมูล">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                   </Columns>
               </MasterTableView>
           </telerik:RadGrid>

           <asp:ScriptManager ID="ScriptManager1" runat="server">
           </asp:ScriptManager>

    </div>

    <div class="modal fade " id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    รายละเอียดโครงการวิจัย<button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f1" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
