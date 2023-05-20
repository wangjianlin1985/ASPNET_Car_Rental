using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using com.force.json;

public partial class ShiftWay_ShiftWayController : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        if (action == "add") addShiftWay();
        if (action == "delete") deleteShiftWay();
        if (action == "update") updateShiftWay();
        if (action == "getShiftWay") getShiftWay();
        if (action == "listAll") listAll();
    }
    //处理添加启动方式控制层方法
    protected void addShiftWay()
    {
        int success = 0;
        string message = "";
        ENTITY.ShiftWay shiftWay = new ENTITY.ShiftWay();
        shiftWay.shiftName = Request["shiftWay.shiftName"];
        if (!BLL.bllShiftWay.AddShiftWay(shiftWay))
        {
            message = "添加启动方式发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //处理删除启动方式控制层方法
    protected void deleteShiftWay()
    {
        int success = 0;
        string message = "";
        string shitWayId = Request["shitWayId"];
        try {
            BLL.bllShiftWay.DelShiftWay(shitWayId);
            success = 1;
        } catch {
            message = "启动方式删除失败";
        }
        writeResult(success, message);
    }

    //处理更新启动方式控制层方法
    protected void updateShiftWay()
    {
        int success = 0;
        string message = "";
        ENTITY.ShiftWay shiftWay = new ENTITY.ShiftWay();
        shiftWay.shitWayId = int.Parse(Request["ShiftWay.shitWayId"]);
        shiftWay.shiftName = Request["shiftWay.shiftName"];
        if (!BLL.bllShiftWay.EditShiftWay(shiftWay))
        {
            message = "更新启动方式发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //获取单个启动方式对象，返回json格式
    protected void getShiftWay()
    {
        int shitWayId = int.Parse(Request.QueryString["shitWayId"]);
        ENTITY.ShiftWay shiftWay = BLL.bllShiftWay.getSomeShiftWay(shitWayId);
        JSONObject jsonShiftWay = new JSONObject();
        jsonShiftWay.Put("shitWayId", shiftWay.shitWayId);
        jsonShiftWay.Put("shiftName", shiftWay.shiftName);
        Response.Write(jsonShiftWay.ToString());
    }

    protected void listAll()
    {
        DataSet shiftWayDs = BLL.bllShiftWay.getAllShiftWay();
        JSONArray shiftWayArray = new JSONArray();
        for (int i = 0; i < shiftWayDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = shiftWayDs.Tables[0].Rows[i];
            JSONObject jsonShiftWay = new JSONObject();
            jsonShiftWay.Put("shitWayId", Convert.ToInt32(dr["shitWayId"]));
            jsonShiftWay.Put("shiftName", dr["shiftName"].ToString());
            shiftWayArray.Put(jsonShiftWay);
        }
        Response.Write(shiftWayArray.ToString());
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
