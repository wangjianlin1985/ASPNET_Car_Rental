using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ENTITY
{
    /// <summary>
    ///CarRent ��ժҪ˵�����⳵ʵ��
    /// </summary>

    public class CarRent
    {
        /*������*/
        private int _rentId;
        public int rentId
        {
            get { return _rentId; }
            set { _rentId = value; }
        }

        /*��������*/
        private string _carObj;
        public string carObj
        {
            get { return _carObj; }
            set { _carObj = value; }
        }

        /*�⳵�û�*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*�⳵��ʼʱ��*/
        private DateTime _rentTime;
        public DateTime rentTime
        {
            get { return _rentTime; }
            set { _rentTime = value; }
        }

        /*����ʱ��*/
        private string _returnTime;
        public string returnTime
        {
            get { return _returnTime; }
            set { _returnTime = value; }
        }

        /*���*/
        private float _rentMoney;
        public float rentMoney
        {
            get { return _rentMoney; }
            set { _rentMoney = value; }
        }

        /*��ע��Ϣ*/
        private string _rentMemo;
        public string rentMemo
        {
            get { return _rentMemo; }
            set { _rentMemo = value; }
        }

    }
}
