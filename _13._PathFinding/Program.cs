namespace _13._PathFinding
{
    internal class Program
    {
        // 게임 개발자들의 친구 : A* Algorithm 
        // Dijkstra 알고리즘을 옆그레이드 였던 A1 과 업그레이드 베타버전 A2
        // (later proved its capability through optimization using heuristic approach)
        // which 나중에 A*로 일컬게 되었다. 

        // 그래프 순회에서, 그리고 일반적인 길찾기 기법중에서 인기있는 녀석이다. 
        // 특히 맵에서 많이 사용할 녀석이며, trpg제작을 생각하며 구상을 해보는것도 좋을것 같다. 

        // 이진탐색트리x sortedDict 완전이진트리 Heap/ PriorityQueue, yes 을 이용하여 구현하는데, 
        // 노드값이 살짝 괴상하게 생겼다. 
        // 이제 보니 다익스트라가 선녀였다. 이건 하나도 안닮았다. 
        
        /* <노드> 
         * A*에서는 정점과 Edge 에 대해서 노드로 구사하는데, 
         * 기존 그래프와는 다르게 각 정점별로 이미 갔던 값과, 이후 탐색할 값의 추정치를 지니고 있다
         * 
         * 추정치 계산법 
         * Where f(x) = g(x) + h(x), 
         * 맨하탄 = CostStraight * (x+y)
         * 유클리드 = Sqrt(x^2 + y^2) 이다. 
         * 
         */

       


        static void Main(string[] args)
        {
            int[] ints = { 1, 2, 3 };
            int[] ints2 = { 1,2, 3 };
            ints.CopyTo(ints2,0);
            Console.WriteLine("Hello, World!");
        }
    }
}