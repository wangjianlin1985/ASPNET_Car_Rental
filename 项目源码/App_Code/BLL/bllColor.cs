using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*������ɫҵ���߼���*/
    public class bllColor{
        /*���������ɫ*/
        public static bool AddColor(ENTITY.Color color)
        {
            return DAL.dalColor.AddColor(color);
        }

        /*����colorId��ȡĳ��������ɫ��¼*/
        public static ENTITY.Color getSomeColor(int colorId)
        {
            return DAL.dalColor.getSomeColor(colorId);
        }

        /*����������ɫ*/
        public static bool EditColor(ENTITY.Color color)
        {
            return DAL.dalColor.EditColor(color);
        }

        /*ɾ��������ɫ*/
        public static bool DelColor(string p)
        {
            return DAL.dalColor.DelColor(p);
        }

        /*��ѯ������ɫ*/
        public static System.Data.DataSet GetColor(string strWhere)
        {
            return DAL.dalColor.GetColor(strWhere);
        }

        /*����������ҳ��ѯ������ɫ*/
        public static System.Data.DataTable GetColor(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalColor.GetColor(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�������ɫ*/
        public static System.Data.DataSet getAllColor()
        {
            return DAL.dalColor.getAllColor();
        }
    }
}
