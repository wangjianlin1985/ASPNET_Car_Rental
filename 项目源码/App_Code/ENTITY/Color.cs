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
    ///Color ��ժҪ˵����������ɫʵ��
    /// </summary>

    public class Color
    {
        /*��ɫ���*/
        private int _colorId;
        public int colorId
        {
            get { return _colorId; }
            set { _colorId = value; }
        }

        /*��ɫ����*/
        private string _colorName;
        public string colorName
        {
            get { return _colorName; }
            set { _colorName = value; }
        }

    }
}
