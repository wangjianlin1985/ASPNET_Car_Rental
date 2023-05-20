using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�⳵ҵ���߼���*/
    public class bllCarRent{
        /*����⳵*/
        public static bool AddCarRent(ENTITY.CarRent carRent)
        {
            return DAL.dalCarRent.AddCarRent(carRent);
        }

        /*����rentId��ȡĳ���⳵��¼*/
        public static ENTITY.CarRent getSomeCarRent(int rentId)
        {
            return DAL.dalCarRent.getSomeCarRent(rentId);
        }

        /*�����⳵*/
        public static bool EditCarRent(ENTITY.CarRent carRent)
        {
            return DAL.dalCarRent.EditCarRent(carRent);
        }

        /*ɾ���⳵*/
        public static bool DelCarRent(string p)
        {
            return DAL.dalCarRent.DelCarRent(p);
        }

        /*��ѯ�⳵*/
        public static System.Data.DataSet GetCarRent(string strWhere)
        {
            return DAL.dalCarRent.GetCarRent(strWhere);
        }

        /*����������ҳ��ѯ�⳵*/
        public static System.Data.DataTable GetCarRent(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCarRent.GetCarRent(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е��⳵*/
        public static System.Data.DataSet getAllCarRent()
        {
            return DAL.dalCarRent.getAllCarRent();
        }
    }
}
