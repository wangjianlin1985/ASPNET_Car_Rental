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
    ///CarInfo ��ժҪ˵����������Ϣʵ��
    /// </summary>

    public class CarInfo
    {
        /*���ƺ���*/
        private string _chepaiNo;
        public string chepaiNo
        {
            get { return _chepaiNo; }
            set { _chepaiNo = value; }
        }

        /*�ͺ�*/
        private string _serialNo;
        public string serialNo
        {
            get { return _serialNo; }
            set { _serialNo = value; }
        }

        /*��������*/
        private string _carName;
        public string carName
        {
            get { return _carName; }
            set { _carName = value; }
        }

        /*��ɫ*/
        private int _colorObj;
        public int colorObj
        {
            get { return _colorObj; }
            set { _colorObj = value; }
        }

        /*������ʽ*/
        private int _shiftWayObj;
        public int shiftWayObj
        {
            get { return _shiftWayObj; }
            set { _shiftWayObj = value; }
        }

        /*ÿСʱ����*/
        private float _price;
        public float price
        {
            get { return _price; }
            set { _price = value; }
        }

        /*��������*/
        private DateTime _outDate;
        public DateTime outDate
        {
            get { return _outDate; }
            set { _outDate = value; }
        }

        /*���ҵ�ַ*/
        private string _makeAddress;
        public string makeAddress
        {
            get { return _makeAddress; }
            set { _makeAddress = value; }
        }

        /*����ͼƬ*/
        private string _carPhoto;
        public string carPhoto
        {
            get { return _carPhoto; }
            set { _carPhoto = value; }
        }

        /*��������*/
        private string _cofigParam;
        public string cofigParam
        {
            get { return _cofigParam; }
            set { _cofigParam = value; }
        }

        /*����״̬*/
        private int _rentStateObj;
        public int rentStateObj
        {
            get { return _rentStateObj; }
            set { _rentStateObj = value; }
        }

    }
}
