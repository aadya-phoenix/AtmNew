using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Linq;

namespace AtmNew
{
    public class Account 
    {

        public string Name { get; set; }

        public int CardNumber { get; set; }
        public int Pin { get; set; }
        public double Balance { get; set; }

        public bool ValidateCard(string cardNumber)
        {
            
            DataTable dt;
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from dbo.tblAccount", con);

                dt = new DataTable();
                da.Fill(dt);
            }

            if (dt != null && dt.Rows.Count > 0)
            {
                var nu = Convert.ToInt64(cardNumber);

                bool contains = dt.AsEnumerable().Any(row => nu == row.Field<Int64>("cardNumber"));

                if (contains)
                {
                    return true;
                }
            }
            return false;
        
        }
        public bool ValidatePin(string cardNumber, int pin)
        {
            DataTable dt;
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from dbo.CardDetails", con);

                dt = new DataTable();
                da.Fill(dt);
            }

            if (dt != null && dt.Rows.Count > 0)
            {
                var nu = Convert.ToInt64(cardNumber);

                bool contains = dt.AsEnumerable().Any(row => nu == row.Field<Int64>("CardNumber") && pin == row.Field<int>("Pin"));

                if (contains)
                {
                    return true;
                }
            }
            return false;
        }

        public long BalanceCh(string cardNumber, int pin)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                DataTable dt;

                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from dbo.CardDetails where CardNumber=" + "'" + cardNumber + "'", con);

                    dt = new DataTable();
                    da.Fill(dt);
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    return Convert.ToInt64(dt.Rows[0]["CurrentBalance"]);
                }
                else
                {
                    return 0;
                }
            }
        }


        public long Withdraw(string cardNumber, int pin)
        {
            DataTable dt;
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from dbo.CardDetails where CurrentBalance=" + "'" + cardNumber + "'", con);

                dt = new DataTable();
                da.Fill(dt);
            }

            if (dt != null && dt.Rows.Count > 0)

            {
                return Convert.ToInt64(dt.Rows[0]["CurrentBalance"]);

            }


            else
            {
                return 0;
            }
        }

    }
}
