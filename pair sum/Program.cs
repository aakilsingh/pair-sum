namespace pair_sum
{
    public class Program
    {
        // this is a valid solution but not the most performant as it is 0(n^2)
        public static List<int> pairSum(List<int> numbers, int target)
        {
            // iterate through list
            
            for (int i = 0; i < numbers.Count; i++) 
            { 
                for(int j = 1; j < numbers.Count; j++)
                {
                    if (numbers[i] + numbers[j] == target)
                    {
                        return new List<int> { i, j };
                    }
                }
            
            }
            return null;
        }


        // most performant as it is 0(n)
        public static List<int> pairSum2(List<int> numbers, int target) 
        { 
            Dictionary<int,int> previous = new Dictionary<int,int>();

          for(int i = 0; i < numbers.Count; i++)
            {
                int complement = target - numbers[i]; // this is the number that we need so that the current value adds up to the target

                if (previous.ContainsKey(complement)) // checking if our dictionary contains the complement
                {
                    return new List<int> { previous[complement], i }; 
                }
                
                    previous.Add(numbers[i], i); // if it does not then add the value and index of the current item we are iterating over
                
            }

            return null;

        }

        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 3, 2, 5, 4, 1 };

            List<int> result = pairSum2(numbers, 8);
            foreach (int i in result) {
                Console.WriteLine(i);
                
            }
        }
    }
}
