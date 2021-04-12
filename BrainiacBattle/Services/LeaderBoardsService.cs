using BrainiacBattle.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BrainiacBattle.Services
{
    public class LeaderBoardsService
    {
        private readonly BrainiacBattleContext db;

        public LeaderBoardsService(BrainiacBattleContext context)
        {
            db = context;
        }
        public List<string> GetAllUserNames()
        {
            using (db)
            {
                List<string> userNames = new List<String>();
                var query = from Username in db.Accounts orderby Username.BrainRating descending select Username;
                var userName = query.ToArray();
                int count = 0;
                while (count < userName.Length)
                {
                    userNames.Add(userName[count].ToString());
                    count++;
                }
                return userNames;
            }
        }
        public List<string> GetAllBrainRatings()
        {
            using (db)
            {
                List<string> bRatings = new List<String>();
                var query = from BrainRating in db.Accounts orderby BrainRating descending select BrainRating;
                var rating = query.ToArray();
                int count = 0;
                while (count < rating.Length)
                {
                    bRatings.Add(rating[count].ToString());
                    count++;
                }
                return bRatings;
            }
        }
        public DataTable GetLeaderBoard()
        {
            int count = 1;
            int iterator = 0;
            List<string> userNames = GetAllUserNames();
            List<string> brainRatings = GetAllBrainRatings();

            DataTable lBoard = new DataTable();
            lBoard.Columns.Add("Rank", typeof(int));
            lBoard.Columns.Add("Name", typeof(string));
            lBoard.Columns.Add("Score", typeof(string));
            
            while (iterator < userNames.Count())
            {
                DataRow row = lBoard.NewRow();
                row["Rank"] = count;
                row["Name"] = userNames[iterator].ToString();
                row["Score"] = brainRatings[iterator].ToString();
                lBoard.Rows.Add(row);
                count++;
                iterator++;
            }
            return lBoard;
        }    
        public string GetUserRank(string userName)
        {
            DataRow[] uRow = GetLeaderBoard().Select("Name = " + userName);
            string userRank = uRow[0].ToString();
            return userRank;
        }
        /*public DataTable getTop10()
        {
            DataTable lBoard = GetLeaderBoard();
            DataTable top10 = new DataTable();
            top10.Columns.Add("Rank", typeof(int));
            top10.Columns.Add("Name", typeof(int));
            top10.Columns.Add("Score", typeof(int));
            int iterator = 0;
            int count = 1;
            while(iterator < 10)
            {
                DataRow row = top10.NewRow();
                row["Rank"] = count;
                row["Name"] = 
            }

            
        }
        */
    }
}
