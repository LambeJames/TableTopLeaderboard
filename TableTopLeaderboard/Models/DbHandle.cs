using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TableTopLeaderboard.Models
{
    public class DbHandle
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["TableTopLeaderboardDBConn"].ToString();
            con = new SqlConnection(constring);
        }

        // **************** ADD NEW STUDENT *********************
        public bool AddPlayer(PlayerModel model)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewPlayer", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
            cmd.Parameters.AddWithValue("@LastName", model.LastName);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW STUDENT DETAILS ********************
        public List<PlayerModel> GetPlayers()
        {
            connection();
            List<PlayerModel> players = new List<PlayerModel>();

            SqlCommand cmd = new SqlCommand("GetPlayers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                players.Add(
                    new PlayerModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        FirstName = Convert.ToString(dr["FirstName"]),
                        LastName = Convert.ToString(dr["LastName"])
                    });
            }
            return players ;
        }

        // ***************** UPDATE STUDENT DETAILS *********************
        public bool UpdatePlayer(PlayerModel model)
        {
            connection();
            SqlCommand cmd = new SqlCommand("UpdateStudentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", model.Id);
            cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
            cmd.Parameters.AddWithValue("@LastName", model.LastName);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********************** DELETE STUDENT DETAILS *******************
        public bool DeletePlayer(int id)
        {
            connection();
            SqlCommand cmd = new SqlCommand("DeletePlayer", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", id);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}
