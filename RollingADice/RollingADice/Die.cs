using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollingADice
{
    class Die
    {
        private Random r;
        private int[] nums;
        public int SideCount { get; }

        public delegate void DieHandler(string msg);

        public event DieHandler TwoFours;
        public event DieHandler SumOfRoles;

        public Die()
        {
            nums = new int[5];
            SideCount = 6;
            r = new Random();
        }

        /// <summary>
        /// Move the array 1 element back to always get the last digits
        /// </summary>
        /// <param name="arr"></param>
        private void MoveArray(ref int[] arr)
        {
            for(int i = 1; i < arr.Length; i++)
            {
                arr[i - 1] = arr[i];
            }
        }

        public void Roll(int rollcount)
        {
            int n = 0;
            int count = 0;
            int sum;
            while (n < rollcount)
            {
                sum = 0;
                int number = r.Next(1, SideCount + 1);
                nums[nums.Length - 1] = number;
                foreach (var t in nums)
                {
                    Console.Write(t + " ");
                    sum += t;
                }

                if (nums[nums.Length - 2] == 4 && nums[nums.Length - 1] == 4)
                {
                    TwoFours?.Invoke("\t Two Fours in a row!");
                    count++;
                }

                if (sum >= 20)
                    SumOfRoles?.Invoke("\t" + sum + " Equal or Greather than 20");
                else
                    Console.WriteLine("\t" + sum + " Less than 20");

                MoveArray(ref nums);
                n++;
            }
            TwoFours?.Invoke($"Count of Two Fours: {count}");
        }
    }
}
