using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whack_a_Mole
{
    public interface IStateInterface
    {
        public void Update();

        public void Draw();
    }
}
