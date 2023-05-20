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
    public partial class RentStateEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                if (Request["stateId"] != null)
                {
                    LoadData();
                }
            }
        }
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "stateId")))
            {
                ENTITY.RentState rentState = BLL.bllRentState.getSomeRentState(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "stateId")));
                stateName.Value = rentState.stateName;
            }
        }

        protected void BtnRentStateSave_Click(object sender, EventArgs e)
        {
            ENTITY.RentState rentState = new ENTITY.RentState();
            rentState.stateName = stateName.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "stateId")))
            {
                rentState.stateId = int.Parse(Request["stateId"]);
                if (BLL.bllRentState.EditRentState(rentState))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"RentStateEdit.aspx?stateId=" + Request["stateId"] + "\"} else  {location.href=\"RentStateList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllRentState.AddRentState(rentState))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"RentStateEdit.aspx\"} else  {location.href=\"RentStateList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("RentStateList.aspx");
        }
    }
}

