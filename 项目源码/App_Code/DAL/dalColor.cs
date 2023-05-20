using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*������ɫҵ���߼���ʵ��*/
    public class dalColor
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���������ɫʵ��*/
        public static bool AddColor(ENTITY.Color color)
        {
            string sql = "insert into Color(colorName) values(@colorName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@colorName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = color.colorName; //��ɫ����

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����colorId��ȡĳ��������ɫ��¼*/
        public static ENTITY.Color getSomeColor(int colorId)
        {
            /*������ѯsql*/
            string sql = "select * from Color where colorId=" + colorId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Color color = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                color = new ENTITY.Color();
                color.colorId = Convert.ToInt32(DataRead["colorId"]);
                color.colorName = DataRead["colorName"].ToString();
            }
            return color;
        }

        /*����������ɫʵ��*/
        public static bool EditColor(ENTITY.Color color)
        {
            string sql = "update Color set colorName=@colorName where colorId=@colorId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@colorName",SqlDbType.VarChar),
             new SqlParameter("@colorId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = color.colorName;
            parm[1].Value = color.colorId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��������ɫ*/
        public static bool DelColor(string p)
        {
            string sql = "delete from Color where colorId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ������ɫ*/
        public static DataSet GetColor(string strWhere)
        {
            try
            {
                string strSql = "select * from Color" + strWhere + " order by colorId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ������ɫ*/
        public static System.Data.DataTable GetColor(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Color";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "colorId", strShow, strSql, strWhere, " colorId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllColor()
        {
            try
            {
                string strSql = "select * from Color";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
