using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScores
{
    public class TestScoresClass
    {
        private int testScore1;
        private int testScore2;
        private int testScore3;

        public TestScoresClass(int score1, int score2, int score3)
        {
            testScore1 = score1;
            testScore2 = score2;
            testScore3 = score3;
        }

        public int GetTestScore1()
        {
            return testScore1;
        }

        public void SetTestScore1(int score)
        {
            testScore1 = score;
        }

        public int GetTestScore2()
        {
            return testScore2;
        }

        public void SetTestScore2(int score)
        {
            testScore2 = score;
        }

        public int GetTestScore3()
        {
            return testScore3;
        }

        public void SetTestScore3(int score)
        {
            testScore3 = score;
        }

        public double GetAverageScore()
        {
            return (double)(testScore1 + testScore2 + testScore3) / 3;
        }

        public char GetLetterGrade()
        {
            double averageScore = GetAverageScore();

            if (averageScore >= 90)
            {
                return 'A';
            }
            else if (averageScore >= 80)
            {
                return 'B';
            }
            else if (averageScore >= 70)
            {
                return 'C';
            }
            else if (averageScore >= 60)
            {
                return 'D';
            }
            else
            {
                return 'F';
            }
        }
    }
}
