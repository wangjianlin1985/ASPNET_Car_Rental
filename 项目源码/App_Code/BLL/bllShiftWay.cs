using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*������ʽҵ���߼���*/
    public class bllShiftWay{
        /*���������ʽ*/
        public static bool AddShiftWay(ENTITY.ShiftWay shiftWay)
        {
            return DAL.dalShiftWay.AddShiftWay(shiftWay);
        }

        /*����shitWayId��ȡĳ��������ʽ��¼*/
        public static ENTITY.ShiftWay getSomeShiftWay(int shitWayId)
        {
            return DAL.dalShiftWay.getSomeShiftWay(shitWayId);
        }

        /*����������ʽ*/
        public static bool EditShiftWay(ENTITY.ShiftWay shiftWay)
        {
            return DAL.dalShiftWay.EditShiftWay(shiftWay);
        }

        /*ɾ��������ʽ*/
        public static bool DelShiftWay(string p)
        {
            return DAL.dalShiftWay.DelShiftWay(p);
        }

        /*��ѯ������ʽ*/
        public static System.Data.DataSet GetShiftWay(string strWhere)
        {
            return DAL.dalShiftWay.GetShiftWay(strWhere);
        }

        /*����������ҳ��ѯ������ʽ*/
        public static System.Data.DataTable GetShiftWay(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalShiftWay.GetShiftWay(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�������ʽ*/
        public static System.Data.DataSet getAllShiftWay()
        {
            return DAL.dalShiftWay.getAllShiftWay();
        }
    }
}
