using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_DataStructure
{
    // Adapter 패턴을 응용한 이미 존재하는 객체( 아답터를 활용하기 위한 객체 구현 이후 (_Adaptee)) 
    // Array 를 응용한 
    #region 
    // TODO: test this region 
    #endregion
    // 개발자는 생각보다 문제에 대해서 파악 -> 심플화 -> 해결을 위한 접근할수 있도록 simple 화 작업이 필수가 되는 직종인것 같다 
    // 해당 행동패턴은 수학할때 꽤나 강조되었던 내용으로, 
    // 수포자 였던 나는 그러므로 수학을 배우지 않는다고 고집한다면 
    // 개발자를 하겠다는 나의 선택과 모순된다. ㄷ; 
    public class Queue<T> // 일반화 
    {
        protected int DefaultCapacity = 4;

        public T[] array;
        private int head; // 값을 반환할 키 (포인터)
        public int Head { get { return head; } }
        private int tail; // 값을 추가할 키 (포인터) 
        public int Tail { get { return tail; } }
        public int Count
        {
            get
            {
                if (head <= tail) // 테일이 헤드 대비 배열의 앞쪽에 위치한 경우 
                    return tail - head;
                else // 그게 아니라면 
                    return tail - head + array.Length; // 카운트, 즉 추가된 (행동할수 있는 값은) 
            }
        }

        public Queue(int cap)
        {
            //this.DefaultCapacity = cap; // 요세푸스문제를 위해 고정된 선형구조의 큐 생성 
            array = new T[DefaultCapacity + 1];  // +1 to seperate head and tail 
            head = 0;
            tail = 0;
        }

        public void Enqueue(T item)
        {
            if (IsFull())
            {
                Grow();
                Console.WriteLine("Grow!");
            }// 고전 스타일 큐는 배열이 가득찼다면 더이상 사용이 안되었었다
            // 놀랍게도 요세푸스 문제를 풀면서 알게된 사실은, 
            // Grow 를 했을때의 장점을 이전에는 그저 배열을 리스트같이 사용하는것처럼 느껴졌으나, 
            // 반은 맞고 반은 틀렸다. Enqueue 와 Dequeue 의 호출비율에 따라서 나선형의 소용돌이 처럼 늘어나는것도 (마치 무한대의 리스트처럼) 도 가능하나, 
            // 동시에 끝점이 이어져 돌림판처럼 돌수있게 해주는 부분이었다. 
            // 나선형을 만들어야된다면 이처럼 구현할수 있지않을까 생각도 드는 부분이다. 
            //throw new InvalidOperationException();
            array[tail] = item;
            MoveNext(ref tail);

        }
        /// <summary>
        /// 값 접근 및 방출 하기 위한 기능 
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            T result = array[head];
            MoveNext(ref head);
            return result;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();
            return array[head];
        }
        /// <summary>
        /// head 또는 tail이 움직여야하는 기능, 기본적으로 움직여야할곳에 대해서 알고리즘 구현 
        /// </summary>
        /// <param name="index"></param>
        private void MoveNext(ref int index) // 참조형식으로 원본값을 void 로 수정이 가능하다 
        {
            if (index == array.Length - 1)
            {
                index = 0;
            }
            else
            {
                Console.WriteLine($"H:{head} T:{tail}");
                index = index + 1;
            }

        }
        private bool IsEmpty()
        {
            return head == tail;
        }

        private bool IsFull()
        {
            if (head > tail)
                return head == tail + 1; // 만약 해드가 테일보다 앞에 있다면, (기본적인 전제가 head 와 tail 은 한칸 간격으로 분리되어있는데, (가득찬 상태를 만들어주기 위한 밑작업), 
                                            // 해드가 만약 앞에 있다면 이는 이미 둘중하나는 순환을 돌았다는 반증이기에, 이후에 tail +1 값과 head 값이 같다면 Enqueue가 DeQeue 대비 너무 많은 상황일것이다. 
            else
                return (Count == array.Length - 1) && (tail == array.Length - 1); // 증식가능한 큐에서는, 더이상 head 가 0인 상황을 고려하지 않아도 된다, 다만, 그대신 count 자체가 가득찼다면으로 대체함으로써
            //   T                              T 
            //else
            //    return head == 0 && tail == array.Length - 1; //  [ ][h][2][4][5][t]
            //                                                      [ ][1][2][4][h][ ]
        }

        private void Grow()
        {
            T[] growArray = new T[array.Length * 2];
            if (head < tail) // 그냥 복사하는것이 크게 문제가 되지는 않는다 
                Array.Copy(array, 0, growArray, 0, Count);
            else // tail < head [][t][][h][2][3]  // 만일 tail 이 head 뒤에 있는 상황에서 단순복사는 null값에 대해서 무방비하게 되는데, 
                 // newArray = [][t][][][h][2][3][][] // 일때 h가 1,2,3 처리후 그 뒤의 남은 값을 처리할때 문제가 발생하게 된다 
            {
                Array.Copy(array, head, growArray, 0, array.Length - head); // 이때 원본의 해드부터 끝까지를 처음으로 복사해주고 
                Array.Copy(array, 0, growArray, array.Length - head, tail); // 원본의 0번부터 해드까지 (7-3 = index = 4) 처음 복사된 값의 다음값부터
                                                                            // 테일의 가장 이전값까지 복사하여준다
                                                                            // 이후 마지막으로 tail을 복사가 끝난 그 이후 시점으로 지정하여 준다. 

                // [h][2][3][][t][][][][] 이런식으로 생성이 된다 
                head = 0;
                tail = Count;  // 1- 3 + 6 = 4 
            }
            array = growArray; // 큐는 여기서 끝이 나지 않는 이유는 만약 테일이 해드보다 배열의 스타트보다 앞에 있다면 문제가 발생한다. 
        }

    }
}
