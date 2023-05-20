<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontModify.aspx.cs" Inherits="Color_frontModify" %>
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
  <TITLE>修改汽车颜色信息</TITLE>
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
  		<li class="active">汽车颜色信息修改</li>
	</ul>
		<div class="row"> 
      	<form class="form-horizontal" name="colorEditForm" id="colorEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="color_colorId_edit" class="col-md-3 text-right">颜色编号:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="color_colorId_edit" name="color.colorId" class="form-control" placeholder="请输入颜色编号" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="color_colorName_edit" class="col-md-3 text-right">颜色名称:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="color_colorName_edit" name="color.colorName" class="form-control" placeholder="请输入颜色名称">
			 </div>
		  </div>
			  <div class="form-group">
			  	<span class="col-md-3""></span>
			  	<span onclick="ajaxColorModify();" class="btn btn-primary bottom5 top5">修改</span>
			  </div>
		</form> 
	    <style>#colorEditForm .form-group {margin-bottom:5px;}  </style>
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
/*弹出修改汽车颜色界面并初始化数据*/
function colorEdit(colorId) {
	$.ajax({
		url :  basePath + "Color/ColorController.aspx?action=getColor&colorId=" + colorId,
		type : "get",
		dataType: "json",
		success : function (color, response, status) {
			if (color) {
				$("#color_colorId_edit").val(color.colorId);
				$("#color_colorName_edit").val(color.colorName);
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*ajax方式提交汽车颜色信息表单给服务器端修改*/
function ajaxColorModify() {
	$.ajax({
		url :  basePath + "Color/ColorController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#colorEditForm")[0]),
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
    colorEdit('<%=Request["colorId"] %>');
 })
 </script> 
</body>
</html>

