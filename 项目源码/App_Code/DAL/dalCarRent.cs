using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�⳵ҵ���߼���ʵ��*/
    public class dalCarRent
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*����⳵ʵ��*/
        public static bool AddCarRent(ENTITY.CarRent carRent)
        {
            string sql = "insert into CarRent(carObj,userObj,rentTime,returnTime,rentMoney,rentMemo) values(@carObj,@userObj,@rentTime,@returnTime,@rentMoney,@rentMemo)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@carObj",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@rentTime",SqlDbType.DateTime),
             new SqlParameter("@returnTime",SqlDbType.VarChar),
             new SqlParameter("@rentMoney",SqlDbType.Float),
             new SqlParameter("@rentMemo",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = carRent.carObj; //��������
            parm[1].Value = carRent.userObj; //�⳵�û�
            parm[2].Value = carRent.rentTime; //�⳵��ʼʱ��
            parm[3].Value = carRent.returnTime; //����ʱ��
            parm[4].Value = carRent.rentMoney; //���
            parm[5].Value = carRent.rentMemo; //��ע��Ϣ

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����rentId��ȡĳ���⳵��¼*/
        public static ENTITY.CarRent getSomeCarRent(int rentId)
        {
            /*������ѯsql*/
            string sql = "select * from CarRent where rentId=" + rentId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.CarRent carRent = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                carRent = new ENTITY.CarRent();
                carRent.rentId = Convert.ToInt32(DataRead["rentId"]);
                carRent.carObj = DataRead["carObj"].ToString();
                carRent.userObj = DataRead["userObj"].ToString();
                carRent.rentTime = Convert.ToDateTime(DataRead["rentTime"].ToString());
                carRent.returnTime = DataRead["returnTime"].ToString();
                carRent.rentMoney = float.Parse(DataRead["rentMoney"].ToString());
                carRent.rentMemo = DataRead["rentMemo"].ToString();
            }
            return carRent;
        }

        /*�����⳵ʵ��*/
        public static bool EditCarRent(ENTITY.CarRent carRent)
        {
            string sql = "update CarRent set carObj=@carObj,userObj=@userObj,rentTime=@rentTime,returnTime=@returnTime,rentMoney=@rentMoney,rentMemo=@rentMemo where rentId=@rentId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@carObj",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@rentTime",SqlDbType.DateTime),
             new SqlParameter("@returnTime",SqlDbType.VarChar),
             new SqlParameter("@rentMoney",SqlDbType.Float),
             new SqlParameter("@rentMemo",SqlDbType.VarChar),
             new SqlParameter("@rentId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = carRent.carObj;
            parm[1].Value = carRent.userObj;
            parm[2].Value = carRent.rentTime;
            parm[3].Value = carRent.returnTime;
            parm[4].Value = carRent.rentMoney;
            parm[5].Value = carRent.rentMemo;
            parm[6].Value = carRent.rentId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���⳵*/
        public static bool DelCarRent(string p)
        {
            string sql = "delete from CarRent where rentId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�⳵*/
        public static DataSet GetCarRent(string strWhere)
        {
            try
            {
                string strSql = "select * from CarRent" + strWhere + " order by rentId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ�⳵*/
        public static System.Data.DataTable GetCarRent(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from CarRent";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "rentId", strShow, strSql, strWhere, " rentId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllCarRent()
        {
            try
            {
                string strSql = "select * from CarRent";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
