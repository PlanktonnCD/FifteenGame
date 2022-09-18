using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class UtilsMath
    {
        public static List<int> GetRandomList(int count)
        {
            var randomList = new List<int>();
            for (int i = 0; i < count; i++)
            {
                var randomNumber = Random.Range(0, count);
                while (randomList.Contains(randomNumber) || randomNumber == i)
                {
                    randomNumber = Random.Range(0, count);
                }
                randomList.Add(randomNumber);
            }
            return randomList;
        }
        
        public static bool IsSolvable(List<int> randomList) 
        {
            int countInversions = 0;
 
            for (int i = 0; i < randomList.Count; i++) {
                for (int j = 0; j < i; j++) {
                    if (randomList[j] > randomList[i])
                        countInversions++;
                }
            }
 
            return countInversions % 2 == 0;
        }
    }
}