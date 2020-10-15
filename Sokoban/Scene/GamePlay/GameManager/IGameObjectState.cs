using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public interface IGameObjectState
    {
        void Init();
        void AnimeUpdate();
        void Update();
        void Draw();
        void End();
    }
}
