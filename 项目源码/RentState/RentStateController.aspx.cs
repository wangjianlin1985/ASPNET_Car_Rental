using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using com.force.json;

public partial class RentState_RentStateController : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        if (action == "add") addRentState();
        if (action == "delete") deleteRentState();
        if (action == "update") updateRentState();
        if (action == "getRentState") getRentState();
        if (action == "listAll") listAll();
    }
    //处理添加出租状态控制层方法
    protected void addRentState()
    {
        int success = 0;
        string message = "";
        ENTITY.RentState rentState = new ENTITY.RentState();
        rentState.stateName = Request["rentState.stateName"];
        if (!BLL.bllRentState.AddRentState(rentState))
        {
            message = "添加出租状态发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //处理删除出租状态控制层方法
    protected void deleteRentState()
    {
        int success = 0;
        string message = "";
        string stateId = Request["stateId"];
        try {
            BLL.bllRentState.DelRentState(stateId);
            success = 1;
        } catch {
            message = "出租状态删除失败";
        }
        writeResult(success, message);
    }

    //处理更新出租状态控制层方法
    protected void updateRentState()
    {
        int success = 0;
        string message = "";
        ENTITY.RentState rentState = new ENTITY.RentState();
        rentState.stateId = int.Parse(Request["RentState.stateId"]);
        rentState.stateName = Request["rentState.stateName"];
        if (!BLL.bllRentState.EditRentState(rentState))
        {
            message = "更新出租状态发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //获取单个出租状态对象，返回json格式
    protected void getRentState()
    {
        int stateId = int.Parse(Request.QueryString["stateId"]);
        ENTITY.RentState rentState = BLL.bllRentState.getSomeRentState(stateId);
        JSONObject jsonRentState = new JSONObject();
        jsonRentState.Put("stateId", rentState.stateId);
        jsonRentState.Put("stateName", rentState.stateName);
        Response.Write(jsonRentState.ToString());
    }

    protected void listAll()
    {
        DataSet rentStateDs = BLL.bllRentState.getAllRentState();
        JSONArray rentStateArray = new JSONArray();
        for (int i = 0; i < rentStateDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = rentStateDs.Tables[0].Rows[i];
            JSONObject jsonRentState = new JSONObject();
            jsonRentState.Put("stateId", Convert.ToInt32(dr["stateId"]));
            jsonRentState.Put("stateName", dr["stateName"].ToString());
            rentStateArray.Put(jsonRentState);
        }
        Response.Write(rentStateArray.ToString());
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
