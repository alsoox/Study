using System.Diagnostics;

namespace Yeild
{
    internal class Program
    {
        static void Main(string[] args)
        {
            foreach (var score in GetScores())
            {
                Console.WriteLine(score);
            }
        }

        static IEnumerable<int> GetScores()
        {
           int[] scores = new int[] { 10, 20, 30, 40, 50 };

            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] == 30)
                {
                    yield break;
                }
                yield return scores[i];
                Debug.WriteLine(i + " : Done");
            }
        }

    }
}
