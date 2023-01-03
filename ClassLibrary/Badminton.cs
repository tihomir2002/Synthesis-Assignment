namespace ClassLibrary
{
    public class Badminton:Sport
    {
        public Badminton()
        {
            name = "Badminton";
        }

        public override string ValidateResult(int sideOnePoints,int sideTwoPoints, bool twoPointsForWin = false)
        {
            string winner = DetermineWinner(sideOnePoints, sideTwoPoints,twoPointsForWin);
            return winner;
        }

        public override string DetermineWinner(int sideOnePoints,int sideTwoPoints, bool twoPointsForWin = false)
        {
            if ((sideOnePoints > 30 || sideTwoPoints > 30) && !twoPointsForWin) return "invalid";
            if (!twoPointsForWin)
            {
                if (sideOnePoints == 21 && sideOnePoints - sideTwoPoints >= 2) return "one";
                if (sideTwoPoints == 21 && sideTwoPoints - sideOnePoints >= 2) return "two";
                if(sideTwoPoints > 21 || sideOnePoints > 21) return "invalid";
                return "none";
            }
            else
            {
                if (sideOnePoints - sideTwoPoints >= 2) return "one";
                if (sideTwoPoints - sideOnePoints >= 2) return "two";
                if (sideOnePoints == 30) return "one";
                if (sideTwoPoints == 30) return "two";
                if (sideTwoPoints > 30 || sideOnePoints > 30) return "invalid";
                return "none";
            }
        }
    }
}
