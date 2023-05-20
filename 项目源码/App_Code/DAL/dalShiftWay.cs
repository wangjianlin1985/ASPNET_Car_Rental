using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*������ʽҵ���߼���ʵ��*/
    public class dalShiftWay
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���������ʽʵ��*/
        public static bool AddShiftWay(ENTITY.ShiftWay shiftWay)
        {
            string sql = "insert into ShiftWay(shiftName) values(@shiftName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@shiftName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = shiftWay.shiftName; //������ʽ����

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����shitWayId��ȡĳ��������ʽ��¼*/
        public static ENTITY.ShiftWay getSomeShiftWay(int shitWayId)
        {
            /*������ѯsql*/
            string sql = "select * from ShiftWay where shitWayId=" + shitWayId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ShiftWay shiftWay = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                shiftWay = new ENTITY.ShiftWay();
                shiftWay.shitWayId = Convert.ToInt32(DataRead["shitWayId"]);
                shiftWay.shiftName = DataRead["shiftName"].ToString();
            }
            return shiftWay;
        }

        /*����������ʽʵ��*/
        public static bool EditShiftWay(ENTITY.ShiftWay shiftWay)
        {
            string sql = "update ShiftWay set shiftName=@shiftName where shitWayId=@shitWayId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@shiftName",SqlDbType.VarChar),
             new SqlParameter("@shitWayId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = shiftWay.shiftName;
            parm[1].Value = shiftWay.shitWayId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��������ʽ*/
        public static bool DelShiftWay(string p)
        {
            string sql = "delete from ShiftWay where shitWayId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ������ʽ*/
        public static DataSet GetShiftWay(string strWhere)
        {
            try
            {
                string strSql = "select * from ShiftWay" + strWhere + " order by shitWayId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ������ʽ*/
        public static System.Data.DataTable GetShiftWay(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from ShiftWay";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "shitWayId", strShow, strSql, strWhere, " shitWayId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllShiftWay()
        {
            try
            {
                string strSql = "select * from ShiftWay";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
