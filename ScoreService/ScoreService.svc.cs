using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ScoreService
{    
    public class ScoreService : IScoreService
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\Projects\GitHub\Find-the-Number\ScoreService\App_Data\ScoreDB.mdf;Integrated Security=True");

        public List<ScoreEntry> GetLeaderboard()
        {
            List<ScoreEntry> scores = new List<ScoreEntry>();
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 10 Name,Score FROM Scoreboard ORDER BY Score DESC", connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ScoreEntry entry = new ScoreEntry();
                entry.Name = reader.GetSqlString(0).ToString();
                entry.Score = (int)reader.GetSqlInt32(1);
                scores.Add(entry);
            }
            connection.Close();
            return scores;
        }

        public bool AddScore(string name, int score)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO Scoreboard (Name,Score) VALUES ('{0}','{1}')", name, score), connection);
            bool success = cmd.ExecuteNonQuery() > 0;
            connection.Close();
            return success;
        }

        //For debugging purposes only, do not include in demo
        public bool ResetScores()
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Scoreboard", connection);
            bool success = cmd.ExecuteNonQuery() > 0;
            cmd = new SqlCommand("DBCC CHECKIDENT (Scoreboard, RESEED, 0)", connection);
            success &= cmd.ExecuteNonQuery() > 0;
            connection.Close();
            return success;
        }
    }
}
