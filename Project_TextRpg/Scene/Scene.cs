using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRpg
{
    // Scene 을 하나의 단위로써 각 단위 별로 구현을 달리하기 위한 최소한의 해당 프로젝트의 객체단위 
    // 따라서 모든 Scene 의 개념이 되는 추상 클래스를 생성한다. ~ Type_Scene, 으로 구체적인 Scene 에 대해서 정의 하게 된다. 
    public abstract class Scene
    {
        // Because in a game, there can be different type of game, 
        // Scene must belong to a certain_type of a game 
        protected Game game; 

        public Scene(Game game)
        {
            this.game = game;
        }
        // 1. For all the scene, it must be able to express itself, -> Render 
        // 2. and based on the input, be updated for the next render 
        public abstract void Render();

        public abstract void Update(); 
    }
}
