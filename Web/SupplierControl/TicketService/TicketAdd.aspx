﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketAdd.aspx.cs" Inherits="Web.SupplierControl.TicketService.TicketAdd" %>
<%@ Register  Src="~/UserControl/ProvinceList.ascx" TagName="ucProvince" TagPrefix="uc1" %>
<%@ Register  Src="~/UserControl/CityList.ascx" TagName="ucCity" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link href="/css/sytle.css" rel="stylesheet" type="text/css" />
    <script src="/js/jquery.js" type="text/javascript"></script>
    <script src="/js/ValiDatorForm.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
        <table width="800" border="0" align="center" cellpadding="0" cellspacing="1" style="margin-top:10px;">
          <tr class="odd">
            <th width="80" height="30" align="center"><SPAN style="COLOR: red">*</SPAN>省份：</th>
            <td width="330" align="left"> 
              <uc1:ucProvince id="ucProvince1" runat="server"/>
              <input type="hidden" name="proname" id="proname" />
              
            </td>
            <th width="80" align="center"><SPAN style="COLOR: red">*</SPAN>城市：</th>
            
            <td width="330" align="left">
              <uc2:ucCity id="ucCity1" runat="server"  />
              <input type="hidden" name="cityname" id="cityname" />
            </td>
          </tr>
          <tr class="even">
            <th height="30" align="center"><SPAN style="COLOR: red">*</SPAN>单位名称： </th>
            <td align="left">
                <input type="text" id="unionname" name="unionname" value="<% =csModel.UnitName %>" class="searchinput searchinput02" valid="required" errmsg="单位不能为空" />
			    <span id="errMsg_unionname" class="errmsg"></span>
            </td>
            <th align="center">地址： </th>
            <td align="left">
                <input type="text" id="txtAddress" name="txtAddress" value="<% =csModel.UnitAddress %>" class="searchinput searchinput02" />
            </td>
          </tr>
          <tr class="odd">
            <th height="30" align="center">合作协议： </th>
            <td colspan="3" align="left" class="updom">
            <%if ( !string.IsNullOrEmpty(csModel.AgreementFile))
              { %>
              <a href="<%=csModel.AgreementFile %>" target="_blank">查看合作协议</a><img src="/images/fujian_x.gif" style="cursor:pointer" width="14" height="13" class="close" alt="" />
            <%}
              else
              { %>
            <input type="file" name="workAgree"/>
            <%} %>
            </td>
          </tr>
          <tr class="even">
            <th align="center">联系人：</th>
            <td colspan="3" align="left">
            <table id="userlist" width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#FFFFFF">
              <tr class="odd">
                <th width="12%" height="30" align="center"><SPAN style="COLOR: red">*</SPAN>姓名</th>
                <th width="12%" align="center">职务</th>
                <th width="12%" align="center">电话</th>
                <th width="12%" align="center"><SPAN style="COLOR: red">*</SPAN>手机</th>
                <th width="12%" align="center">QQ</th>
                <th width="12%" align="center">E-mail</th>
                <th width="12%" align="center">传真</th>
                <th width="15%" align="center">操作</th> 
              </tr>
              <%if (csModel.SupplierContact!=null && csModel.SupplierContact.Count > 0)
                {
                    int temp = 0;
                    foreach (EyouSoft.Model.CompanyStructure.SupplierContact sc in csModel.SupplierContact)
                    {
                         %>
              <tr class="<% =temp%2==0?"even":"odd" %>">
                <th height="30" align="center"><input  type="text" name="inname" class="searchinput inname" value="<%=sc.ContactName %>" /></th>
                <th align="center"><input  type="text" name="indate" class="searchinput indate" value="<%=sc.JobTitle %>" /></th>
                <th align="center"><input  type="text" name="inphone" class="searchinput inphone" value="<%=sc.ContactTel %>" /></th>
                <th align="center"><input  type="text" name="inmobile" class="searchinput inmobile" value="<%=sc.ContactMobile %>" /></th>
                <th align="center"><input  type="text" name="inqq" class="searchinput inqq" value="<%=sc.QQ %>" /></th>
                <th align="center"><input  type="text" name="inemail" class="searchinput inemail" value="<%=sc.Email %>" /></th>
                <th align="center"><input  type="text" name="infax" class="searchinput infax" value="<%=sc.ContactFax %>" /></th>
                <td align="center"> <%if (!show)
                                      { %><a href="javascript:;" class="add"><img height="16" width="15" alt="" src="/images/tianjiaicon01.gif" /> 添加</a> <a href="javascript:;" class="del"><img src="/images/delicon01.gif" width="14" height="14"  /> 删除</a><%} %></td>
              </tr>
              <% temp++;}
                }
                else
                { %>
                <tr class="even">
                    <th height="30" align="center"><input  type="text" name="inname" class="searchinput inname" /></th>
                    <th align="center"><input  type="text" name="indate" class="searchinput indate" /></th>
                    <th align="center"><input  type="text" name="inphone" class="searchinput inphone" /></th>
                    <th align="center"><input  type="text" name="inmobile" class="searchinput inmobile" /></th>
                    <th align="center"><input  type="text" name="inqq" class="searchinput inqq" /></th>
                    <th align="center"><input  type="text" name="inemail" class="searchinput inemail" /></th>
                    <th align="center"><input  type="text" name="infax" class="searchinput infax" /></th>
                    <td align="center"> <%if (!show)
                                 { %><a href="javascript:;" class="add"><img height="16" width="15" alt="" src="/images/tianjiaicon01.gif" /> 添加</a> <a href="javascript:;" class="del"><img src="/images/delicon01.gif" width="14" height="14"  /> 删除</a><%} %></td>
                  </tr>
              <%} %>
            </table></td>
          </tr>
          <tr class="odd">
            <th height="60" align="center">政策：</th>
            <td colspan="3"><textarea name="police" id="police" cols="45" rows="5" class="textareastyle"><% = csModel.UnitPolicy %></textarea></td>
          </tr>
          <tr class="even">
            <th height="60" align="center">备注：</th>
            <td colspan="3"><textarea name="remark" id="remark" cols="45" rows="5" class="textareastyle"><%= csModel.Remark %></textarea></td>
          </tr>
        </table>
        <table width="320" border="0" align="center" cellpadding="0" cellspacing="0">
          <tr>
            <td height="40" align="center"></td>
            <td height="40" align="center" class="tjbtn02"><%if (!show)
                                                             { %><a href="javascript:;" class="save">保存</a><%} %></td>
            <td height="40" align="center" class="tjbtn02"><a href="javascript:;" id="linkCancel" onclick="parent.Boxy.getIframeDialog('<%=Request.QueryString["iframeId"] %>').hide()">关闭</a></td>
            <input type="hidden" name="tid" value="<%=tid %>" />
          </tr>
        </table>
        
        
       <script type="text/javascript">
       $(function(){
            $("img.close").click(function(){
                var that = $(this);
                $("td.updom").html("<input type=\"file\" name=\"workAgree\" />");
            });
            
            $("a.save").click(function(){
                
                var proid = provinceAndCity_province["<%=ucProvince1.ClientID %>"].provinceId;
                var cityid = provinceAndCity_city["<%=ucCity1.ClientID %>"].cityId;
                if($("#"+proid).val()=='0'){
                    alert("请选择省份");
                    return false;
                }
                if($("#"+cityid).val()=='0'){
                    alert("请选择城市");
                    return false;
                }
                $("#proname").val($("#"+proid+">option:selected").eq(0).text());
                $("#cityname").val($("#"+cityid+">option:selected").eq(0).text());
            
	            var form = $(this).closest("form").get(0);
	            //点击按纽触发执行的验证函数
	            if(ValiDatorForm.validator(form,"span")&&checkname()&&checkmobile()){ 
                    form.submit(); 
	            }else{
	                return false;
	            } 
	            
	            return false;
            });
            
            function checkname(){
                var res = true;
                $("#userlist").find("input.inname").each(function() {
                    if (!$.trim($(this).val())) {
                        alert("请填写联系人姓名");
                        $(this).focus();
                        res = false;
                        return false;
                    }
                });
                return res;
            }
            
            function checkmobile(){
                var res = true;
                $("#userlist").find("input.inmobile").each(function() {
                    if (!$.trim($(this).val())) {
                        alert("请填写联系人手机号码");
                        $(this).focus();
                        res = false;
                        return false;
                    }
                });
                return res;
            }
            //初始化表单元素失去焦点时的行为，当需验证的表单元素失去焦点时，验证其有效性。
            FV_onBlur.initValid($("a.save").closest("form").get(0));
            
            
            function getuserinput(){
                var cls = $("#userlist").find("tr").length%2?"even":"odd";
                var html =  "<tr class=\""+cls+"\">"+
                                "<th height=\"30\" align=\"center\"><input  type=\"text\" name=\"inname\"  class=\"searchinput inname\" /></th>"+
                                "<th align=\"center\"><input  type=\"text\" name=\"indate\" class=\"searchinput indate\" /></th>"+
                                "<th align=\"center\"><input  type=\"text\" name=\"inphone\" class=\"searchinput inphone\" /></th>"+
                                "<th align=\"center\"><input  type=\"text\" name=\"inmobile\" class=\"searchinput inmobile\" /></th>"+
                                "<th align=\"center\"><input  type=\"text\" name=\"inqq\" class=\"searchinput inqq\" /></th>"+
                                "<th align=\"center\"><input  type=\"text\" name=\"inemail\" class=\"searchinput inemail\" /></th>"+
                                "<th align=\"center\"><input  type=\"text\" name=\"infax\" class=\"searchinput infax\" /></th>"+
                                "<td align=\"center\"><a href=\"javascript:;\" class=\"add\" ><img height=\"16\" width=\"15\" alt=\"\" src=\"/images/tianjiaicon01.gif\" /> 添加</a> <a href=\"javascript:;\" class=\"del\" ><img src=\"/images/delicon01.gif\" width=\"14\" height=\"14\" /> 删除</a></td>"+
                                "</tr>";
                 return html;
            }
            function add(){
                var html = getuserinput();
                $("#userlist").append(html);
                $("a.add").unbind().bind("click",function(){
                    add();
                    return false;
                });
                $("a.del").unbind().bind("click",function(){
                    var that = $(this);
                    del(that);
                    return false;
                });
            }
            
            
            function del(that){
                var trlist = $("#userlist").find("tr");
                if(trlist.length>2)
                {
                    that.parent().parent().remove();
                }
            }
            $("a.add").bind("click",function(){
                add();
                return false;
            });
            $("a.del").bind("click",function(){
                var that=$(this);
                del(that);
                return false;
            });
            
        });
    </script>
    </form>
</body>
</html>
