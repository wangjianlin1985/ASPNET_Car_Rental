using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace chengxusheji.Admin
{
    public partial class ShiftWayEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                if (Request["shitWayId"] != null)
                {
                    LoadData();
                }
            }
        }
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "shitWayId")))
            {
                ENTITY.ShiftWay shiftWay = BLL.bllShiftWay.getSomeShiftWay(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "shitWayId")));
                shiftName.Value = shiftWay.shiftName;
            }
        }

        protected void BtnShiftWaySave_Click(object sender, EventArgs e)
        {
            ENTITY.ShiftWay shiftWay = new ENTITY.ShiftWay();
            shiftWay.shiftName = shiftName.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "shitWayId")))
            {
                shiftWay.shitWayId = int.Parse(Request["shitWayId"]);
                if (BLL.bllShiftWay.EditShiftWay(shiftWay))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"ShiftWayEdit.aspx?shitWayId=" + Request["shitWayId"] + "\"} else  {location.href=\"ShiftWayList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllShiftWay.AddShiftWay(shiftWay))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"ShiftWayEdit.aspx\"} else  {location.href=\"ShiftWayList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShiftWayList.aspx");
        }
    }
}

