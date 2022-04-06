using MVCYoutube.Models.App;
using MVCYoutube.Models.Table;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCYoutube.Models.DbHelper
{
    public class EmployeeDbHelper
    {
        public int Add(TbEmployee emp)
        {
            int i;
            using (SqlConnection dbconn= GlobalApp.Connection)
            {
                dbconn.Open();
                SqlCommand cmm = new SqlCommand("INSERT INTO TbEmployee (Name,Age,State,County) VALUES (@Name,@Age,@State,@County)", dbconn);
                cmm.Parameters.AddWithValue("@Name",emp.Name);
                cmm.Parameters.AddWithValue("@Age", emp.Age);
                cmm.Parameters.AddWithValue("@State", emp.State);
                cmm.Parameters.AddWithValue("@County", emp.County);
                i = cmm.ExecuteNonQuery();
                dbconn.Close();
            }
            return i;

        }
        public int Update(TbEmployee emp)
        {
            int i;
            using (SqlConnection dbconn = GlobalApp.Connection)
            {
                dbconn.Open();
                SqlCommand cmm = new SqlCommand("UPDATE TbEmployee SET Name=@Name,Age=@Age,State=@State,County=@County WHERE EmployeeID=@EmployeeID", dbconn);
        
                cmm.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
                cmm.Parameters.AddWithValue("@Name", emp.Name);
                cmm.Parameters.AddWithValue("@Age", emp.Age);
                cmm.Parameters.AddWithValue("@State", emp.State);
                cmm.Parameters.AddWithValue("@County", emp.County);
                i = cmm.ExecuteNonQuery();
                dbconn.Close();
            }
            return i;

        }
        public int Delete(TbEmployee emp)
        {
            int i;
            using (SqlConnection dbconn = GlobalApp.Connection)
            {
                dbconn.Open();
                SqlCommand cmm = new SqlCommand("DELETE FROM TbEmployee WHERE EmployeeID=@EmployeeID", dbconn);
                cmm.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);
                i = cmm.ExecuteNonQuery();
                dbconn.Close();
            }
            return i;

        }

        public List<TbEmployee> ListAll()
        {
            List<TbEmployee> lst = new List<TbEmployee>();
            using (SqlConnection dbconn = GlobalApp.Connection)
            {
                dbconn.Open();
                SqlCommand cmm = new SqlCommand("SELECT * FROM TbEmployee ", dbconn);
                SqlDataReader rdr = cmm.ExecuteReader();
                while (rdr.Read())
                {
                    //tek tablo
                    lst.Add(new TbEmployee
                    {
                        EmployeeID = Convert.ToInt32(rdr["EmployeeID"] == DBNull.Value ? 0 : rdr["EmployeeID"]),
                        Name = rdr[""].ToString(),
                        Age = Convert.ToByte(rdr["Age"] == DBNull.Value ? 0 : rdr["Age"]),
                        State = rdr["State"].ToString(),
                        County = rdr["County"].ToString(),
                    });
                    //çift tablo
                    //TbEmployee tb = new TbEmployee
                    //{
                    //    EmployeeID = Convert.ToInt32(rdr["EmployeeID"] == DBNull.Value ? 0 : rdr["EmployeeID"]),
                    //    Name = rdr[""].ToString(),
                    //    Age = Convert.ToByte(rdr["Age"] == DBNull.Value ? 0 : rdr["Age"]),
                    //    State = rdr["State"].ToString(),
                    //    County = rdr["County"].ToString(),
                    //    //}
                    //};
                    //tb._county.CountryID = Convert.ToInt32(rdr["CountryID"] == DBNull.Value ? 0 : rdr["CountryID"]);
                    //lst.Add(tb);
                }

                dbconn.Close();
                return lst;
             
            }

        }
    }
}