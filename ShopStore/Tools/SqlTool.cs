using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShopStore.Tools
{
    public class SqlTool
    {
        string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        public object ProcScalar(string proc, List<SqlParameter> lParam = null)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(proc, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (lParam != null)
                    {
                        cmd.Parameters.AddRange(lParam.ToArray());
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        internal void Proc(string proc, List<SqlParameter> lParam)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(proc, con))
                {
                    cmd.CommandType= CommandType.StoredProcedure;
                    if (lParam != null)
                    {
                        cmd.Parameters.AddRange(lParam.ToArray());
                    }
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}