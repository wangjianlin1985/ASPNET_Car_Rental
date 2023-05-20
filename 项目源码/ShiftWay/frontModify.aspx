<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontModify.aspx.cs" Inherits="ShiftWay_frontModify" %>
<%@ Register Src="../header.ascx" TagName="header" TagPrefix="uc" %>
<%@ Register Src="../footer.ascx" TagName="footer" TagPrefix="uc" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/";
%>
<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1 , user-scalable=no">
  <TITLE>修改启动方式信息</TITLE>
  <link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/animate.css" rel="stylesheet"> 
</head>
<body style="margin-top:70px;"> 
<div class="container">
<uc:header ID="header" runat="server" />
	<div class="col-md-9 wow fadeInLeft">
	<ul class="breadcrumb">
  		<li><a href="<%=basePath %>index.aspx">首页</a></li>
  		<li class="active">启动方式信息修改</li>
	</ul>
		<div class="row"> 
      	<form class="form-horizontal" name="shiftWayEditForm" id="shiftWayEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="shiftWay_shitWayId_edit" class="col-md-3 text-right">记录id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="shiftWay_shitWayId_edit" name="shiftWay.shitWayId" class="form-control" placeholder="请输入记录id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="shiftWay_shiftName_edit" class="col-md-3 text-right">启动方式名称:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="shiftWay_shiftName_edit" name="shiftWay.shiftName" class="form-control" placeholder="请输入启动方式名称">
			 </div>
		  </div>
			  <div class="form-group">
			  	<span class="col-md-3""></span>
			  	<span onclick="ajaxShiftWayModify();" class="btn btn-primary bottom5 top5">修改</span>
			  </div>
		</form> 
	    <style>#shiftWayEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
   </div>
</div>


<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap-datetimepicker.min.js"></script>
<script src="<%=basePath %>plugins/locales/bootstrap-datetimepicker.zh-CN.js"></script>
<script type="text/javascript" src="<%=basePath %>js/jsdate.js"></script>
<script>
var basePath = "<%=basePath%>";
/*弹出修改启动方式界面并初始化数据*/
function shiftWayEdit(shitWayId) {
	$.ajax({
		url :  basePath + "ShiftWay/ShiftWayController.aspx?action=getShiftWay&shitWayId=" + shitWayId,
		type : "get",
		dataType: "json",
		success : function (shiftWay, response, status) {
			if (shiftWay) {
				$("#shiftWay_shitWayId_edit").val(shiftWay.shitWayId);
				$("#shiftWay_shiftName_edit").val(shiftWay.shiftName);
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*ajax方式提交启动方式信息表单给服务器端修改*/
function ajaxShiftWayModify() {
	$.ajax({
		url :  basePath + "ShiftWay/ShiftWayController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#shiftWayEditForm")[0]),
		success : function (obj, response, status) {
            if(obj.success){
                alert("信息修改成功！");
                location.reload(true);
            }else{
                alert(obj.message);
            } 
		},
		processData: false,
		contentType: false,
	});
}

$(function(){
        /*小屏幕导航点击关闭菜单*/
        $('.navbar-collapse a').click(function(){
            $('.navbar-collapse').collapse('hide');
        });
        new WOW().init();
    shiftWayEdit('<%=Request["shitWayId"] %>');
 })
 </script> 
</body>
</html>

