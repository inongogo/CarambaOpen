using System;
using System.Linq;
using CarambaOpen.DbContexts;

namespace CarambaOpen.Models
{
    public class Ranking
    {
        public decimal Cheapness { get; set; }
        public decimal Weather { get; set; }
        public decimal Golf { get; set; }
        public decimal Living { get; set; }
        public decimal FoodDrinkAndParty { get; set; }
        public decimal Country { get; set; }
        public decimal Social { get; set; }
        public decimal Risk { get; set; }

        public User User { get; set; }

        public Ranking(User user)
        {
            User = user;
        }

        public static Ranking GetRanking(Poll poll)
        {

            var rank = new Ranking(poll.User);

            var q1 = poll.Answers.Single(x => x.Question.Order == 1);
            rank.Golf += Convert.ToInt32(q1.Alt1);
            rank.Country += Convert.ToInt32(q1.Alt1);
            rank.FoodDrinkAndParty -= Convert.ToInt32(q1.Alt1);
            rank.Cheapness -= Convert.ToInt32(q1.Alt1);
            rank.Weather += Convert.ToInt32(q1.Alt1);
            rank.Social += Convert.ToInt32(q1.Alt1);

            rank.Social += Convert.ToInt32(q1.Alt2);
            rank.FoodDrinkAndParty += Convert.ToInt32(q1.Alt2);
            rank.Cheapness += Convert.ToInt32(q1.Alt1);

            rank.FoodDrinkAndParty += Convert.ToInt32(q1.Alt3);
            rank.Social += Convert.ToInt32(q1.Alt3);
            rank.Cheapness -= Convert.ToInt32(q1.Alt3);
            rank.Golf -= Convert.ToInt32(q1.Alt3);
            rank.Country -= Convert.ToInt32(q1.Alt3);

            rank.Cheapness += Convert.ToInt32(q1.Alt4) * 3;
            rank.Living -= Convert.ToInt32(q1.Alt4);
            rank.FoodDrinkAndParty -= Convert.ToInt32(q1.Alt4);
            rank.Golf -= Convert.ToInt32(q1.Alt4);
            rank.Country -= Convert.ToInt32(q1.Alt4);
            rank.Living -= Convert.ToInt32(q1.Alt3);

            rank.Risk -= Convert.ToInt32(q1.Alt1) * 2;
            rank.Risk += Convert.ToInt32(q1.Alt2);
            rank.Risk -= Convert.ToInt32(q1.Alt3);
            rank.Risk += Convert.ToInt32(q1.Alt4) * 2;

            var q2 = poll.Answers.Single(x => x.Question.Order == 2);
            rank.Golf -= Convert.ToInt32(q2.Alt1) * 2;
            rank.Golf -= Convert.ToInt32(q2.Alt2);
            rank.Golf += Convert.ToInt32(q2.Alt3);
            rank.Golf += Convert.ToInt32(q2.Alt4) * 2;

            rank.Social -= Convert.ToInt32(q2.Alt1) * 2;
            rank.Social -= Convert.ToInt32(q2.Alt2);
            rank.Social += Convert.ToInt32(q2.Alt3);
            rank.Social += Convert.ToInt32(q2.Alt4) * 2;

            rank.FoodDrinkAndParty -= Convert.ToInt32(q2.Alt1) * 2;
            rank.FoodDrinkAndParty += Convert.ToInt32(q2.Alt2);
            rank.FoodDrinkAndParty += Convert.ToInt32(q2.Alt3);
            rank.FoodDrinkAndParty += Convert.ToInt32(q2.Alt4) * 2;

            rank.Cheapness += Convert.ToInt32(q2.Alt1) * 4;
            rank.Cheapness += Convert.ToInt32(q2.Alt2) * 2;
            rank.Cheapness -= Convert.ToInt32(q2.Alt3);
            rank.Cheapness -= Convert.ToInt32(q2.Alt4) * 2;

            rank.Risk -= Convert.ToInt32(q1.Alt1) * 4;
            rank.Risk -= Convert.ToInt32(q1.Alt2) * 1;
            rank.Risk += Convert.ToInt32(q1.Alt3) * 2;
            rank.Risk += Convert.ToInt32(q1.Alt4) * 4;

            var q3 = poll.Answers.Single(x => x.Question.Order == 3);
            rank.Social += Convert.ToInt32(q3.Alt1) * 2;
            rank.Weather += Convert.ToInt32(q3.Alt1);
            rank.Golf -= Convert.ToInt32(q3.Alt1);
            rank.Cheapness += Convert.ToInt32(q3.Alt1);

            rank.Social -= Convert.ToInt32(q3.Alt2);
            rank.Golf += Convert.ToInt32(q3.Alt2) * 2;
            rank.Weather += Convert.ToInt32(q3.Alt2);
            rank.Cheapness -= Convert.ToInt32(q3.Alt2);

            rank.Country += Convert.ToInt32(q3.Alt3);
            rank.FoodDrinkAndParty += Convert.ToInt32(q3.Alt3);
            rank.Social += Convert.ToInt32(q3.Alt3);
            rank.Living += Convert.ToInt32(q3.Alt3);

            rank.Weather += Convert.ToInt32(q3.Alt4) * 2;
            rank.Country += Convert.ToInt32(q3.Alt4);
            rank.Golf += Convert.ToInt32(q3.Alt4);
            rank.Cheapness -= Convert.ToInt32(q3.Alt4);

            rank.Risk -= Convert.ToInt32(q3.Alt1);
            rank.Risk += Convert.ToInt32(q3.Alt2);
            rank.Risk += Convert.ToInt32(q3.Alt3) * 2;
            rank.Risk -= Convert.ToInt32(q3.Alt4);

            var q4 = poll.Answers.Single(x => x.Question.Order == 4);
            rank.Golf += Convert.ToInt32(q4.Alt1) * 2;

            rank.Living += Convert.ToInt32(q4.Alt2);

            rank.FoodDrinkAndParty += Convert.ToInt32(q4.Alt3);
            rank.Social += Convert.ToInt32(q4.Alt3);

            rank.Weather += Convert.ToInt32(q4.Alt4) * 2;
            rank.Country += Convert.ToInt32(q4.Alt4) * 2;
            rank.Golf += Convert.ToInt32(q4.Alt4);


            rank.Risk += Convert.ToInt32(q4.Alt1);
            rank.Risk -= Convert.ToInt32(q4.Alt2);
            rank.Risk -= Convert.ToInt32(q4.Alt3);
            rank.Risk += Convert.ToInt32(q4.Alt3);

            var q5 = poll.Answers.Single(x => x.Question.Order == 5);
            rank.Cheapness += Convert.ToInt32(q5.Alt1) * 4;
            rank.Country -= Convert.ToInt32(q5.Alt1);
            rank.Golf -= Convert.ToInt32(q5.Alt1);
            rank.Living -= Convert.ToInt32(q5.Alt1);
            rank.FoodDrinkAndParty -= Convert.ToInt32(q5.Alt1);

            rank.Country += Convert.ToInt32(q5.Alt2);
            rank.Social += Convert.ToInt32(q5.Alt2);
            rank.FoodDrinkAndParty += Convert.ToInt32(q5.Alt2);
            rank.Cheapness -= Convert.ToInt32(q5.Alt2);

            rank.Social += Convert.ToInt32(q5.Alt3);
            rank.Golf += Convert.ToInt32(q5.Alt3) * 2;
            rank.Cheapness -= Convert.ToInt32(q5.Alt3);

            rank.Country += Convert.ToInt32(q5.Alt4);
            rank.Weather += Convert.ToInt32(q5.Alt4) * 2;
            rank.Golf += Convert.ToInt32(q5.Alt4);
            rank.Cheapness -= Convert.ToInt32(q5.Alt4);

            rank.Risk -= Convert.ToInt32(q5.Alt1) * 2;
            rank.Risk += Convert.ToInt32(q5.Alt2) * 2;
            rank.Risk += Convert.ToInt32(q5.Alt3);
            rank.Risk -= Convert.ToInt32(q5.Alt4) * 2;

            var q6 = poll.Answers.Single(x => x.Question.Order == 6);
            rank.Golf += Convert.ToInt32(q6.Alt1) * 2;
            rank.Country += Convert.ToInt32(q6.Alt1);

            rank.Golf += Convert.ToInt32(q6.Alt2);
            rank.Country += Convert.ToInt32(q6.Alt2);

            rank.Social += Convert.ToInt32(q6.Alt3);
            rank.FoodDrinkAndParty += Convert.ToInt32(q6.Alt3) * 2;
            rank.Golf -= Convert.ToInt32(q6.Alt3) * 2;
            rank.Cheapness -= Convert.ToInt32(q6.Alt3);
            rank.Weather -= Convert.ToInt32(q6.Alt3);

            rank.Country -= Convert.ToInt32(q6.Alt4);
            rank.Weather -= Convert.ToInt32(q6.Alt4);
            rank.Golf -= Convert.ToInt32(q6.Alt4);
            rank.Cheapness -= Convert.ToInt32(q6.Alt4);
            rank.Social += Convert.ToInt32(q6.Alt4);
            rank.FoodDrinkAndParty += Convert.ToInt32(q6.Alt4);
            rank.Living += Convert.ToInt32(q6.Alt4) * 2;

            rank.Risk -= Convert.ToInt32(q6.Alt1) * 2;
            rank.Risk -= Convert.ToInt32(q6.Alt2);
            rank.Risk += Convert.ToInt32(q6.Alt3);
            rank.Risk += Convert.ToInt32(q6.Alt4);

            var q7 = poll.Answers.Single(x => x.Question.Order == 7);
            rank.Golf -= Convert.ToInt32(q7.Alt1);
            rank.FoodDrinkAndParty -= Convert.ToInt32(q7.Alt1) * 2;
            rank.Social -= Convert.ToInt32(q7.Alt1);
            rank.Country += Convert.ToInt32(q7.Alt1) * 2;
            rank.Weather += Convert.ToInt32(q7.Alt1);
            rank.Living += Convert.ToInt32(q7.Alt1) * 2;
            rank.Cheapness += Convert.ToInt32(q7.Alt1);

            rank.Golf += Convert.ToInt32(q7.Alt2);
            rank.FoodDrinkAndParty += Convert.ToInt32(q7.Alt2) * 2;
            rank.Social += Convert.ToInt32(q7.Alt2);
            rank.Country -= Convert.ToInt32(q7.Alt2) * 2;
            rank.Weather -= Convert.ToInt32(q7.Alt2) * 2;
            rank.Living -= Convert.ToInt32(q7.Alt2) * 2;
            rank.Cheapness += Convert.ToInt32(q7.Alt2) * 2;

            rank.Golf -= Convert.ToInt32(q7.Alt3);
            rank.FoodDrinkAndParty -= Convert.ToInt32(q7.Alt3) * 2;
            rank.Social -= Convert.ToInt32(q7.Alt3);
            rank.Country += Convert.ToInt32(q7.Alt3) * 3;
            rank.Weather += Convert.ToInt32(q7.Alt3) * 2;
            rank.Living -= Convert.ToInt32(q7.Alt3);
            rank.Cheapness -= Convert.ToInt32(q7.Alt3);

            rank.Golf += Convert.ToInt32(q7.Alt4);
            rank.FoodDrinkAndParty += Convert.ToInt32(q7.Alt4) * 2;
            rank.Social += Convert.ToInt32(q7.Alt4);
            rank.Country -= Convert.ToInt32(q7.Alt4);
            rank.Weather -= Convert.ToInt32(q7.Alt4);
            rank.Living += Convert.ToInt32(q7.Alt4);
            rank.Cheapness -= Convert.ToInt32(q7.Alt4);

            return rank;
        }
    }
}