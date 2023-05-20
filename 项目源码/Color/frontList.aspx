﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Color_frontList" %>
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
<title>汽车颜色查询</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
 <form id="form2" runat="server">
	<div class="row"> 
		<div class="col-md-12 wow fadeInDown" data-wow-duration="0.5s">
			<div>
				<!-- Nav tabs -->
				<ul class="nav nav-tabs" role="tablist">
			    	<li><a href="../index.aspx">首页</a></li>
			    	<li role="presentation" class="active"><a href="#colorListPanel" aria-controls="colorListPanel" role="tab" data-toggle="tab">汽车颜色列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加汽车颜色</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="colorListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>颜色编号</td><td>颜色名称</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpColor" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#Eval("colorId")%></td>
 											<td><%#Eval("colorName")%></td>
 											<td>
 												<a href="frontshow.aspx?colorId=<%#Eval("colorId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="colorEdit('<%#Eval("colorId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="colorDelete('<%#Eval("colorId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
 											</td> 
 										</tr>
 										</ItemTemplate>
 										</asp:Repeater>
				    				</table>
				    				</div>
				    			</div>
				    		</div>

				    		<div class="row">
					            <div class="col-md-12">
						            <nav class="pull-left">
						                <ul class="pagination">
						                    <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn"
						                      onclick="LBHome_Click">[首页]</asp:LinkButton>
						                    <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
						                      onclick="LBUp_Click">[上一页]</asp:LinkButton>
						                    <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn"
						                      onclick="LBNext_Click">[下一页]</asp:LinkButton>
						                    <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn"
						                      onclick="LBEnd_Click">[尾页]</asp:LinkButton>
						                    <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
						                    <asp:HiddenField ID="HWhere" runat="server" Value=""/>
						                    <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
						                    <asp:HiddenField ID="HPageSize" runat="server" Value="8"/>
						                    <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
						                </ul>
						            </nav>
						            <div class="pull-right" style="line-height:75px;" ><asp:Label runat="server" ID="PageMes"></asp:Label></div>
					            </div>
				            </div> 
				    </div>
				</div>
			</div>
		</div>
	<div style="display:none;">
		<div class="page-header">
    		<h1>汽车颜色查询</h1>
		</div>
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="colorEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;汽车颜色信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
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
		</form> 
	    <style>#colorEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxColorModify();">提交</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
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
				$('#colorEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除汽车颜色信息*/
function colorDelete(colorId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Color/ColorController.aspx?action=delete",
			data : {
				colorId : colorId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "Color/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
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
                location.href= basePath + "Color/frontList.aspx";
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

})
</script>
</body>
</html>

