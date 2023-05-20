using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using com.force.json;

public partial class Color_ColorController : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        if (action == "add") addColor();
        if (action == "delete") deleteColor();
        if (action == "update") updateColor();
        if (action == "getColor") getColor();
        if (action == "listAll") listAll();
    }
    //处理添加汽车颜色控制层方法
    protected void addColor()
    {
        int success = 0;
        string message = "";
        ENTITY.Color color = new ENTITY.Color();
        color.colorName = Request["color.colorName"];
        if (!BLL.bllColor.AddColor(color))
        {
            message = "添加汽车颜色发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //处理删除汽车颜色控制层方法
    protected void deleteColor()
    {
        int success = 0;
        string message = "";
        string colorId = Request["colorId"];
        try {
            BLL.bllColor.DelColor(colorId);
            success = 1;
        } catch {
            message = "汽车颜色删除失败";
        }
        writeResult(success, message);
    }

    //处理更新汽车颜色控制层方法
    protected void updateColor()
    {
        int success = 0;
        string message = "";
        ENTITY.Color color = new ENTITY.Color();
        color.colorId = int.Parse(Request["Color.colorId"]);
        color.colorName = Request["color.colorName"];
        if (!BLL.bllColor.EditColor(color))
        {
            message = "更新汽车颜色发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //获取单个汽车颜色对象，返回json格式
    protected void getColor()
    {
        int colorId = int.Parse(Request.QueryString["colorId"]);
        ENTITY.Color color = BLL.bllColor.getSomeColor(colorId);
        JSONObject jsonColor = new JSONObject();
        jsonColor.Put("colorId", color.colorId);
        jsonColor.Put("colorName", color.colorName);
        Response.Write(jsonColor.ToString());
    }

    protected void listAll()
    {
        DataSet colorDs = BLL.bllColor.getAllColor();
        JSONArray colorArray = new JSONArray();
        for (int i = 0; i < colorDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = colorDs.Tables[0].Rows[i];
            JSONObject jsonColor = new JSONObject();
            jsonColor.Put("colorId", Convert.ToInt32(dr["colorId"]));
            jsonColor.Put("colorName", dr["colorName"].ToString());
            colorArray.Put(jsonColor);
        }
        Response.Write(colorArray.ToString());
    }

    //把处理结果返回给界面层
    protected void writeResult(int success, string message)
    {
        JSONObject resultObj = new JSONObject();
        resultObj.Put("success", success);
        resultObj.Put("message", message);
        Response.Write(resultObj.ToString());
    }

}
