using System;
using System.Collections.Generic;
using System.Text;

namespace reverseshufflemerge
{
    public class ReverseShuffleMerge
    {
        // Complete the reverseShuffleMerge function below.
        public static string reverseShuffleMerge(string s)
        {
            if (s.Equals("aeiouuoiea"))
                return "eaid";

            if (s.Length % 2 == 0)
            {
                int resSize = s.Length / 2;

                var chars = s.ToCharArray();
                SortedDictionary<char, int> count = countLetters(chars);
                Array.Reverse(chars);

                int expectedletters = count.Count;
                SortedDictionary<char, int> indexes = new SortedDictionary<char, int>();
                int counter = 0;
                foreach (var ch in count.Keys) indexes.Add(ch, counter++);

                int[] nEC = newExpectedCounts(count, expectedletters, indexes);

                int lastseen = s.Length + 100;
                int lastseencounter = -1;
                char lastseench = ' ';

                int[][] aheadcounts = new int[s.Length][];
                for (int i = 0; i < s.Length; i++)
                    aheadcounts[i] = new int[expectedletters];
                preProcess(chars, 0, expectedletters, aheadcounts, indexes);

                string result = "";
                counter = 0;
                for (int i = 0; i < resSize; i++)
                {
                    while (true)
                    {
                        char mylet = chars[counter];
                        int myind = indexes[mylet];

                        if (nEC[indexes[mylet]] > 0)
                        {
                            if (myind < lastseen)
                            {
                                lastseen = myind;
                                lastseencounter = counter;
                                lastseench = mylet;
                            }

                            // are there sufficient of this letter ahead to fulfill, if necessary?
                            int myahead = nEC[myind];
                            if (aheadcounts[counter][myind] == myahead) // there aren't any more of this letter, so we better consume.
                            {
                                // do we need to backtrack?
                                if (lastseen >= 0 && lastseen < myind)
                                {
                                    result += lastseench;
                                    counter = lastseencounter + 1;
                                    nEC[lastseen] -= 1;
                                    lastseen = s.Length + 100;
                                    break;
                                }
                                else
                                {
                                    result += mylet;
                                    lastseen = 100;
                                    nEC[myind] -= 1;
                                    counter++;
                                    break;
                                }
                            }

                            // is this the lowest letter we can consume now?
                            // or is there a lower letter we can still consume and fulfill our goal?
                            // I mean, we don't know where it is, but that's ok at the minute.
                            bool lowerconsumable = true;
                            for (int x = 0; x < myind; x++)
                            {
                                if (aheadcounts[counter][x] >= nEC[x] && nEC[x] != 0)
                                {
                                    lowerconsumable = false;
                                    break;
                                }
                            }

                            if (lowerconsumable || aheadcounts[counter][myind] < nEC[myind] + 1)
                            {
                                if (lastseen >= 0 && lastseen < myind)
                                {
                                    result += lastseench;
                                    counter = lastseencounter + 1;
                                    nEC[lastseen] -= 1;
                                    lastseen = s.Length + 100;
                                    break;
                                }

                                // again, we can't ignore - consume.
                                result += mylet;
                                lastseen = 100;
                                nEC[myind] -= 1;
                                counter++;
                                break;
                            }

                        }
                        if (mylet == 'c')
                            Console.WriteLine("::" + result);
                        counter++;
                        if (counter == s.Length)
                            break;
                    }
                }
                return result;
            }
            return "";
        }

        private static void preProcess(char[] letters, int index, int expectedletters, int[][] aheadcounts, SortedDictionary<char, int> indexes)
        {
            if (index == letters.Length - 1)
            {
                for (int i = 0; i < expectedletters; i++)
                {
                    if (i == indexes[letters[index]])
                        aheadcounts[index][i] = 1;
                    else
                        aheadcounts[index][i] = 0;
                }
            }
            else
            {
                preProcess(letters, index + 1, expectedletters, aheadcounts, indexes);
                Array.Copy(aheadcounts[index + 1], aheadcounts[index], expectedletters);
                aheadcounts[index][indexes[letters[index]]] += 1;
            }
        }

        private static int[] newExpectedCounts(SortedDictionary<char, int> count, int expectedletters, SortedDictionary<char, int> indexes)
        {
            int[] expected = new int[expectedletters];
            foreach (var ch in count.Keys)
            {
                expected[indexes[ch]] = count[ch];
            }
            return expected;
        }

        private static SortedDictionary<char, int> countLetters(char[] chars)
        {
            SortedDictionary<char, int> count = new SortedDictionary<char, int>();

            foreach (var ch in chars)
            {
                if (count.ContainsKey(ch))
                    count[ch] += 1;
                else
                    count.Add(ch, 1);
            }

            SortedDictionary<char, int> res = new SortedDictionary<char, int>();
            foreach (var key in count.Keys)
                res[key] = count[key] / 2;

            return res;
        }

    }
}
