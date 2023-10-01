using System.Collections;

namespace KR_OOP_02
{
    public class NormalStack<T> : Stack
    { 
        Stack<T> stack = new Stack<T>();


        public void Add(T obj)
        {
            stack.Push(obj);
        }

        public void Pop()
        {
            try
            {
                throw new InsufficientExecutionStackException("Зачем ты меня удаляешь, что я тебе сделал?");
            }
            catch (InsufficientExecutionStackException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch
            {
                Console.WriteLine("Тип ошибки я не поняв((");
            }
        }
    }

    public delegate void NumberGoalInfo(int x);

    public class Match
    {
        public event NumberGoalInfo Goal;

        public int counterGoal = 0;

        public void GetGoal()
        {
            counterGoal++;

            if (Goal != null)
            {
                Goal(counterGoal);
            }
        }
    }

    public class Bolelschik
    {
        private int number;

        public Bolelschik(int number)
        {
            this.number = number;
        }

        public void OnGoal(int numberGoal)
        {
            Console.WriteLine($"{number} болельщик : {numberGoal} ГГГОООООЛЛЛЛ!!!");
        }
    }

    class Programm
    {
        static void Main()
        {

            // - - - - Task_01 - - - -
            Console.WriteLine("- - - - Task_01 - - - -");

            NormalStack<int> ints= new NormalStack<int>();

            ints.Add(1);
            ints.Add(2);
            ints.Add(3);

            ints.Pop();


            // - - - - Task_02 - - - -

            int[] numbers = { 1, 2, -2, 3, 4, 5, 0, -1, -2, -3 };

            var counterNumbers = numbers.Count(p => p <= 0);
            Console.WriteLine("- - - - Task_02 - - - -");
            Console.WriteLine(counterNumbers);

            // - - - - Task_03 - - - -
            Console.WriteLine("- - - - Task_03 - - - -");

            Match match = new Match();

            Bolelschik bolelschik_01 = new Bolelschik(1);
            Bolelschik bolelschik_02 = new Bolelschik(2);
            Bolelschik bolelschik_03 = new Bolelschik(3);
            Bolelschik bolelschik_04 = new Bolelschik(4);
            Bolelschik bolelschik_05 = new Bolelschik(5);

            match.Goal += bolelschik_01.OnGoal;
            match.Goal += bolelschik_02.OnGoal;
            match.Goal += bolelschik_03.OnGoal;
            match.Goal += bolelschik_04.OnGoal;
            match.Goal += bolelschik_05.OnGoal;

            Console.WriteLine("Динамо Минск забитвает первый гол");
            match.GetGoal();
            Console.WriteLine("Динамо Минск забитвает второй гол");
            match.GetGoal();



        }
    }
}