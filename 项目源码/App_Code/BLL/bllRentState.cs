using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*����״̬ҵ���߼���*/
    public class bllRentState{
        /*��ӳ���״̬*/
        public static bool AddRentState(ENTITY.RentState rentState)
        {
            return DAL.dalRentState.AddRentState(rentState);
        }

        /*����stateId��ȡĳ������״̬��¼*/
        public static ENTITY.RentState getSomeRentState(int stateId)
        {
            return DAL.dalRentState.getSomeRentState(stateId);
        }

        /*���³���״̬*/
        public static bool EditRentState(ENTITY.RentState rentState)
        {
            return DAL.dalRentState.EditRentState(rentState);
        }

        /*ɾ������״̬*/
        public static bool DelRentState(string p)
        {
            return DAL.dalRentState.DelRentState(p);
        }

        /*��ѯ����״̬*/
        public static System.Data.DataSet GetRentState(string strWhere)
        {
            return DAL.dalRentState.GetRentState(strWhere);
        }

        /*����������ҳ��ѯ����״̬*/
        public static System.Data.DataTable GetRentState(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalRentState.GetRentState(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĳ���״̬*/
        public static System.Data.DataSet getAllRentState()
        {
            return DAL.dalRentState.getAllRentState();
        }
    }
}
