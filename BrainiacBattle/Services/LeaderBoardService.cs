using System;
using System.Text;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using BrainiacBattle.Services;
using BrainiacBattle.Data;

namespace BrainiacBattle.Models
{
    public class LeaderBoardService
    {

        private DataTable fullLeaderBoard;
        public Accounts account = new Accounts();

        public LeaderBoardService()
        {
            fullLeaderBoard = new DataTable();
            fullLeaderBoard.Columns.Add("Rank", typeof(int));
            fullLeaderBoard.Columns.Add("UserName", typeof(string));
            fullLeaderBoard.Columns.Add("BrainRating", typeof(string));
            //Add an arraylist to store the usernames and BrainRatings in the LeaderBoard

            ArrayList boardUsernames = new ArrayList();
            ArrayList boardBrainRatings = new ArrayList();
            String currentUserName = account.Username.ToString();
            String currentUserRating = account.BrainRating.ToString();
            DatabaseConnection db = new DatabaseConnection();
            db.OpenDatabase();
            String queryString = "SELECT UserName, BrainRating FROM Accounts ORDER BY BrainRating DESC";
            db.SetSqlCommand(queryString);
            int count = 1;
            using (db.GetDataReader())
            {
                while (db.GetDataReader().Read())
                {
                    DataRow row = fullLeaderBoard.NewRow();
                    row["Rank"] = count;
                    row["UserName"] = db.GetDataReader()["UserName"].ToString();
                    row["BrainRating"] = db.GetDataReader()["BrainRating"].ToString();
                    fullLeaderBoard.Rows.Add(row);
                    count++;
                }
            }
            db.CloseDatabase();
        }
        public DataTable getFullLeaderBoard()
        {
            return fullLeaderBoard;
        }
        public string getUserRank(string userName)
        {

            DataRow[] uRow = fullLeaderBoard.Select("UserName = " + userName);
            string userRank = uRow[0].ToString();
            return userRank;
        }
        public DataTable getTop10()
        {
            DataTable top10 = new DataTable();
            top10.Columns.Add("Rank", typeof(int));
            top10.Columns.Add("UserName", typeof(string));
            top10.Columns.Add("BrainRating", typeof(int));

            return top10;
        }
    }
}
