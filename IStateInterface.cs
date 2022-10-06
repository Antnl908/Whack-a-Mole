using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Whack_a_Mole
{
    public interface IStateInterface
    {
        public void Update(GameTime gameTime);

        public void Draw(GameTime gameTime);

        public bool mouseVisibility();

        public void Reset();
    }
}
