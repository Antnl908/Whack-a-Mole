using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whack_a_Mole
{
    public class Scoreboard
    {
        public List<int> scoreboard = new List<int>();

        public void AddScore(int score)
        {
            scoreboard.Add(score);
        }
    }
}
