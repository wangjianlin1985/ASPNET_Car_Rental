using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*����״̬ҵ���߼���ʵ��*/
    public class dalRentState
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӳ���״̬ʵ��*/
        public static bool AddRentState(ENTITY.RentState rentState)
        {
            string sql = "insert into RentState(stateName) values(@stateName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@stateName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = rentState.stateName; //״̬����

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����stateId��ȡĳ������״̬��¼*/
        public static ENTITY.RentState getSomeRentState(int stateId)
        {
            /*������ѯsql*/
            string sql = "select * from RentState where stateId=" + stateId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.RentState rentState = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                rentState = new ENTITY.RentState();
                rentState.stateId = Convert.ToInt32(DataRead["stateId"]);
                rentState.stateName = DataRead["stateName"].ToString();
            }
            return rentState;
        }

        /*���³���״̬ʵ��*/
        public static bool EditRentState(ENTITY.RentState rentState)
        {
            string sql = "update RentState set stateName=@stateName where stateId=@stateId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@stateName",SqlDbType.VarChar),
             new SqlParameter("@stateId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = rentState.stateName;
            parm[1].Value = rentState.stateId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ������״̬*/
        public static bool DelRentState(string p)
        {
            string sql = "delete from RentState where stateId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ����״̬*/
        public static DataSet GetRentState(string strWhere)
        {
            try
            {
                string strSql = "select * from RentState" + strWhere + " order by stateId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ����״̬*/
        public static System.Data.DataTable GetRentState(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from RentState";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "stateId", strShow, strSql, strWhere, " stateId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllRentState()
        {
            try
            {
                string strSql = "select * from RentState";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
