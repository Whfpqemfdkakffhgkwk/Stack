namespace Stack
{
    class Program
    {
        static void Main()
        {
           Stack<int> stack = new Stack<int>(3);

            //아무것도 없는지 확인
            Console.WriteLine("스택의 시작 count : " + stack.Count);
            
            //Push를 사용하여 값 추가
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            //맨 처음 들어온 값 확인
            Console.WriteLine("스택 값을 추가한 뒤\n스택의 첫번째 값 : " + stack.First());

            //맨 마지막 들어온 값 확인
            Console.WriteLine("스택의 마지막 값 : " + stack.Last());

            //다 차 있는지 확인하는 bool값
            if (stack.IsFull())
            Console.WriteLine("꽉꽉");

            //Pop을 사용하여 뺀 값을 출력
            Console.WriteLine("이제부터 Pop");
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            //다 비어있는지 확인하는 bool값 
            if(stack.IsEmpty())
            Console.WriteLine("텅텅");
        }
    }

    class Stack<T>
    {
        //들어온 형식의 배열
        private T[] stack;
        //배열의 크기
        private int size;
        //들어와있는 요소의 개수
        private int count;
        //공개된 읽기 전용의 Count 
        public int Count { get { return count; } }

        //생성자
        public Stack(int size)
        {
            //들어온 size만큼 stack 배열의 사이즈를 정해준다
            stack = new T[size];

            this.size = size;
            count = 0;
        }

        //값을 넣어주는 기능
        public void Push(T Data)
        {
            //만약 다 차 있는데 더 넣을려고 하면
            if (IsFull())
                throw new ApplicationException("StackOverflowException");
            //다 안 차 있다면
            else
                //값을 넣어주고 요소의 개수인 count를 올려준다
                stack[count++] = Data;
        }

        //값을 비워주는 기능
        public T Pop()
        {
            //만약 다 비어있는데 더 비울려고 하면
            if (IsEmpty())
                throw new ApplicationException("StackEmptyException");
            //다 안 비어있다면
            else
                //요소의 개수인 count를 빼주고 그 값을 비워준다
                return stack[--count];
        }

        //다 차 있는지 확인하는 bool 값
        public bool IsFull()
        {
            return count == stack.Length;
        }

        //다 비어있는지 확인하는 bool 값
        public bool IsEmpty()
        {
            return count == 0;
        }

        //맨 아래에 깔려있는 값을 반환해주는 기능
        public T First()
        {
            //만약 다 비어있는데 접근하려 하면?
            if (IsEmpty())
                throw new ApplicationException("StackEmptyException");
            //다 안 비어있다면
            else
                //맨 아래 깔려있는 값을 반환
                return stack[0];
        }

        //맨 위에 있는 값을 반환해주는 기능
        public T Last()
        {
            //맨 위에 깔려있는 값을 반환
            return stack[count - 1];
        }
    }
}