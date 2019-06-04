using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LINQ;
using System.Collections.Generic;
using System.Linq;

namespace LinqTests
{
    [TestClass]
    public class PracticeTests
    {
        private static readonly string _lowers = "abcdefghijklmnopqrstuvwxyz";
        private static readonly string _uppers = _lowers.ToUpper();
        private static Random _random = new Random(Environment.TickCount);

        [TestMethod]
        public void DisemvowelTest()
        {
            Assert.AreEqual("Ths xrcs s fr lsrs LL!", Practice.Disemvowel("This exercise is for losers LOL!"));
            Assert.AreEqual("N ffns bt,\nr wrtng s mng th wrst 'v vr rd", Practice.Disemvowel("No offense but,\nYour writing is among the worst I've ever read"));
            Assert.AreEqual("Wht r ,  cmmnst?", Practice.Disemvowel("What are you, a communist?"));
        }

        [TestMethod]
        public void TwoToOneTest()
        {
            Assert.AreEqual("aehrsty", Practice.TwoToOne("aretheyhere", "yestheyarehere"));
            Assert.AreEqual("abcdefghilnoprstu", Practice.TwoToOne("loopingisfunbutdangerous", "lessdangerousthancoding"));
            Assert.AreEqual("acefghilmnoprstuy", Practice.TwoToOne("inmanylanguages", "theresapairoffunctions"));
            Assert.AreEqual("adefhklnorst", Practice.TwoToOne("lordsofthefallen", "kros"));
            Assert.AreEqual("aefmnorst", Practice.TwoToOne("transformers", "transformers"));
            Assert.AreEqual("acefghilmnorstu", Practice.TwoToOne("agenerationmustconfrontthelooming", "transformerrs"));
        }

        [TestMethod]
        public void TwoToOneTestRandom()
        {
            for (int i = 0; i < 200; i++)
            {
                string s1 = GenerateRandomString(_random.Next(1, 10));
                string s2 = GenerateRandomString(_random.Next(1, 8));
                Assert.AreEqual(LongestUgly(s1, s2), Practice.TwoToOne(s1, s2));
            }
        }

        [TestMethod]
        public void RemoveMinimumTest()
        {
            CollectionAssert.AreEqual(new List<int> { 2, 3, 4, 5 }, Practice.RemoveMinimum(new List<int> { 1, 2, 3, 4, 5 }));
            CollectionAssert.AreEqual(new List<int> { 5, 3, 2, 4 }, Practice.RemoveMinimum(new List<int> { 5, 3, 2, 1, 4 }));
            CollectionAssert.AreEqual(new List<int> { 2, 3, 1, 1 }, Practice.RemoveMinimum(new List<int> { 1, 2, 3, 1, 1 }));
            CollectionAssert.AreEqual(new List<int>(), Practice.RemoveMinimum(new List<int>()));
        }

        [TestMethod]
        public void RemoveMinimumTestRandom()
        {
            for (int i = 0; i < 100; i++)
            {
                List<int> l = GenerateRandomList();
                CollectionAssert.AreEqual(MinimumUgly(l), Practice.RemoveMinimum(l));
            }
        }

        [TestMethod]
        public void CharacterErrorTest()
        {
            Assert.AreEqual("3/56", Practice.CharacterError("aaaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbmmmmmmmmmmmmmmmmmmmxyz"));
            Assert.AreEqual("6/60", Practice.CharacterError("kkkwwwaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbmmmmmmmmmmmmmmmmmmmxyz"));
            Assert.AreEqual("11/65", Practice.CharacterError("kkkwwwaaaaaaaaaaaaaabbbbbbbbbbbbbbbbbbmmmmmmmmmmmmmmmmmmmxyzuuuuu"));
        }

        [TestMethod]
        public void CharacterErrorTestRandom()
        {
            for (int i = 0; i < 200; i++)
            {
                string s = GenerateRandomString(_random.Next(1, 20));
                Assert.AreEqual(CharErrorUgly(s), Practice.CharacterError(s));
            }
        }

        [TestMethod]
        public void ArrayDiffTest()
        {
            CollectionAssert.AreEqual(new int[] { 2 }, Practice.ArrayDiff(new int[] { 1, 2 }, new int[] { 1 }));
            CollectionAssert.AreEqual(new int[] { 2, 2 }, Practice.ArrayDiff(new int[] { 1, 2, 2 }, new int[] { 1 }));
            CollectionAssert.AreEqual(new int[] { 1 }, Practice.ArrayDiff(new int[] { 1, 2, 2 }, new int[] { 2 }));
            CollectionAssert.AreEqual(new int[] { 1, 2, 2 }, Practice.ArrayDiff(new int[] { 1, 2, 2 }, new int[] { }));
            CollectionAssert.AreEqual(new int[] { }, Practice.ArrayDiff(new int[] { }, new int[] { 1, 2 }));
        }

        [TestMethod]
        public void ArrayDiffTestRandom()
        {
            for (int i = 0; i < 200; i++)
            {
                int[] a = new int[_random.Next(0, 10000)].Select(_ => _random.Next(0, 1001)).ToArray();
                int[] b = new int[_random.Next(0, 1000)].Select(_ => _random.Next(0, 1001)).ToArray();
                CollectionAssert.AreEqual(ArrayDiffUgly(a, b), Practice.ArrayDiff(a, b));
            }
        }

        [TestMethod]
        public void IsIsogramTest()
        {
            Assert.IsTrue(Practice.IsIsogram("Dermatoglyphics"));
            Assert.IsTrue(Practice.IsIsogram("isogram"));
            Assert.IsFalse(Practice.IsIsogram("moose"));
            Assert.IsFalse(Practice.IsIsogram("isIsogram"));
            Assert.IsFalse(Practice.IsIsogram("aba"));
            Assert.IsFalse(Practice.IsIsogram("moOse"));
            Assert.IsTrue(Practice.IsIsogram("thumbscrewjapingly"));
            Assert.IsTrue(Practice.IsIsogram(""));
            Assert.IsFalse(Practice.IsIsogram($"{_lowers}{_lowers[_random.Next(0, _lowers.Length)]}"));
            Assert.IsFalse(Practice.IsIsogram($"{_uppers}{_uppers[_random.Next(0, _uppers.Length)]}"));
        }

        [TestMethod]
        public void IsIsogramTestRandom()
        {
            for (int i = 0; i < 200; i++)
            {
                string s = GenerateRandomString(_random.Next(1, 20));
                Assert.AreEqual(IsogramUgly(s), Practice.IsIsogram(s));
            }
        }

        [TestMethod]
        public void CreatePhoneNumberTest()
        {
            Assert.AreEqual("(123) 456-7890", Practice.CreatePhoneNumber(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }));
            Assert.AreEqual("(111) 111-1111", Practice.CreatePhoneNumber(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }));
        }

        [TestMethod]
        public void CreatePhoneNumberTestRandom()
        {
            for (int i = 0; i < 200; i++)
            {
                int[] numbers = new int[10];
                for (int j = 0; j < numbers.Length; j++)
                    numbers[j] = _random.Next(10);

                Assert.AreEqual(PhoneNumberUgly(numbers), Practice.CreatePhoneNumber(numbers));
            }
        }

        [TestMethod]
        public void GetParityOutlierTest()
        {
            Assert.AreEqual(3, Practice.FindParityOutlier(new int[] { 2, 6, 8, -10, 3 }));
            Assert.AreEqual(206847684, Practice.FindParityOutlier(new int[] { 206847684, 1056521, 7, 17, 1901, 21104421, 7, 1, 35521, 1, 7781 }));
            Assert.AreEqual(0, Practice.FindParityOutlier(new int[] { int.MaxValue, 0, 1 }));
        }

        [TestMethod]
        public void PigLatinTest()
        {
            Assert.AreEqual("igPay atinlay siay oolcay", Practice.PigLatin("Pig latin is cool"));
            Assert.AreEqual("hisTay siay ymay tringsay", Practice.PigLatin("This is my string"));
        }

        [TestMethod]
        public void ChangeWeightTest()
        {
            Assert.AreEqual("2000 103 123 4444 99", Practice.ChangeWeight("103 123 4444 99 2000"));
            Assert.AreEqual("11 11 2000 10003 22 123 1234000 44444444 9999", Practice.ChangeWeight("2000 10003 1234000 44444444 9999 11 11 22 123"));
            Assert.AreEqual("", Practice.ChangeWeight(""));
            Assert.AreEqual("2000 10003 1234000 44444444 9999 123456789", Practice.ChangeWeight("10003 1234000 44444444 9999 2000 123456789"));
            string a = "3 16 9 38 95 1131268 49455 347464 59544965313 496636983114762 85246814996697";
            string r = "3 16 9 38 95 1131268 49455 347464 59544965313 496636983114762 85246814996697";
            Assert.AreEqual(r, Practice.ChangeWeight(a));
            a = "71899703 200 6 91 425 4 67407 7 96488 6 4 2 7 31064 9 7920 1 34608557 27 72 18 81";
            r = "1 2 200 4 4 6 6 7 7 18 27 72 81 9 91 425 31064 7920 67407 96488 34608557 71899703";
            Assert.AreEqual(r, Practice.ChangeWeight(a));
            a = "387087 176 351832 100 430372 8 58052 54 175432 120 269974 147 309754 91 404858 67 271476 164 295747 111 40";
            r = "100 111 120 40 8 54 91 164 147 67 176 430372 58052 175432 351832 271476 309754 404858 387087 295747 269974";
            Assert.AreEqual(r, Practice.ChangeWeight(a));
        }

        [TestMethod]
        public void ChangeWeightTestRandom()
        {
            for (int i = 0; i < 200; i++)
            {
                string weights = GenerateWeights();
                Assert.AreEqual(WeightUgly(weights), Practice.ChangeWeight(weights));
            }
        }

        [TestMethod]
        public void DontGiveMeFiveTest()
        {
            Assert.AreEqual(8, Practice.DontGiveMeFive(1, 9));
            Assert.AreEqual(12, Practice.DontGiveMeFive(4, 17));
            Assert.AreEqual(72, Practice.DontGiveMeFive(1, 90));
            Assert.AreEqual(20, Practice.DontGiveMeFive(-4, 17));
            Assert.AreEqual(38, Practice.DontGiveMeFive(-4, 37));
            Assert.AreEqual(13, Practice.DontGiveMeFive(-14, -1));
            Assert.AreEqual(1, Practice.DontGiveMeFive(149, 151));
            Assert.AreEqual(9, Practice.DontGiveMeFive(-14, -6));
        }

        [TestMethod]
        public void DontGiveMeFiveTestRandom()
        {
            Func<int, int, int> myDontGiveMeFive = delegate (int start, int end)
            {
                var count = 0;
                for (int i = start; i <= end; i++)
                {
                    if (!i.ToString().Contains("5"))
                    {
                        count++;
                    }
                }
                return count;
            };

            for (var i = 0; i < 100; i++)
            {
                var start = _random.Next(-50, 60);
                var end = _random.Next(start + 1, 80);

                Assert.AreEqual(myDontGiveMeFive(start, end), Practice.DontGiveMeFive(start, end));
            }
        }

        [TestMethod]
        public void DuplicateEncoderTest()
        {
            Assert.AreEqual("(((", Practice.DuplicateEncode("din"));
            Assert.AreEqual("()()()", Practice.DuplicateEncode("recede"));
            Assert.AreEqual(")())())", Practice.DuplicateEncode("Success"), "should ignore case");
            Assert.AreEqual("))((", Practice.DuplicateEncode("(( @"));
            Assert.AreEqual("()(((())())", Practice.DuplicateEncode("CodeWarrior"));
            Assert.AreEqual(")()))()))))()(", Practice.DuplicateEncode("Supralapsarian"), "should ignore case");
            Assert.AreEqual("))))))", Practice.DuplicateEncode("iiiiii"), "duplicate-only-string");
            Assert.AreEqual("))((", Practice.DuplicateEncode("(( @"));
            Assert.AreEqual(")))))(", Practice.DuplicateEncode(" ( ( )"));
        }

        [TestMethod]
        public void DuplicateEncoderTestRandom()
        {
            Func<string, string> myDuplicateEncode = delegate (string word)
            {
                Dictionary<char, int> dict = new Dictionary<char, int>();
                for (int i = 0; i < word.Length; i++)
                {
                    if (!dict.ContainsKey(char.ToLower(word[i])))
                    {
                        dict.Add(char.ToLower(word[i]), 0);
                    }
                    dict[char.ToLower(word[i])]++;
                }
                string result = "";

                for (var i = 0; i < word.Length; i++)
                {
                    if (dict[char.ToLower(word[i])] == 1)
                    {
                        result += "(";
                    }
                    else
                    {
                        result += ")";
                    }
                }

                return result;
            };

            for (int r = 0; r < 100; r++)
            {
                var length = _random.Next(10, 21);
                var chars = "abcdeFGHIJklmnOPQRSTuvwxyz() @!";
                var word = string.Concat(Enumerable.Range(0, length).Select(a => chars[_random.Next(0, chars.Length)]));

                Assert.AreEqual(myDuplicateEncode(word), Practice.DuplicateEncode(word));
            }
        }

        [TestMethod]
        public void OnesAndZerosTest()
        {
            Assert.AreEqual(0, Practice.OnesAndZeros(new int[] { 0, 0, 0, 0 }));
            Assert.AreEqual(15, Practice.OnesAndZeros(new int[] { 1, 1, 1, 1 }));
            Assert.AreEqual(6, Practice.OnesAndZeros(new int[] { 0, 1, 1, 0 }));
            Assert.AreEqual(5, Practice.OnesAndZeros(new int[] { 0, 1, 0, 1 }));
            Assert.AreEqual(11, Practice.OnesAndZeros(new int[] { 1, 0, 1, 1 }));
            Assert.AreEqual(9, Practice.OnesAndZeros(new int[] { 1, 0, 0, 1 }));
            Assert.AreEqual(1, Practice.OnesAndZeros(new int[] { 0, 0, 0, 1 }));
            Assert.AreEqual(10, Practice.OnesAndZeros(new int[] { 1, 0, 1, 0 }));
            Assert.AreEqual(8, Practice.OnesAndZeros(new int[] { 1, 0, 0, 0 }));
            Assert.AreEqual(4, Practice.OnesAndZeros(new int[] { 0, 1, 0, 0 }));
        }

        [TestMethod]
        public void OnesAndZerosTestRandom()
        {
            for (int r = 0; r < 100; r++)
            {
                int[] arr = new int[_random.Next(0, 5) + 4];
                for (int i = 0; i < arr.Length; i++)
                    arr[i] = _random.Next(0, 2);
                Assert.AreEqual(BinaryUgly(arr), Practice.OnesAndZeros(arr));
            }
        }

        [TestMethod]
        public void CountPositivesSumNegativesTest()
        {
            CollectionAssert.AreEqual(new int[] { 10, -65 }, Practice.CountPositivesSumNegatives(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, -11, -12, -13, -14, -15 }));
            CollectionAssert.AreEqual(new int[] { 8, -50 }, Practice.CountPositivesSumNegatives(new[] { 0, 2, 3, 0, 5, 6, 7, 8, 9, 10, -11, -12, -13, -14 }));
            CollectionAssert.AreEqual(new int[] { }, Practice.CountPositivesSumNegatives(null));
            CollectionAssert.AreEqual(new int[] { }, Practice.CountPositivesSumNegatives(new int[] { }));
        }

        [TestMethod]
        public void CountPositivesSumNegativesTestRandom()
        {
            for (int r = 0; r < 100; r++)
            {
                int[] arr = GenerateRandomList().ToArray();
                CollectionAssert.AreEqual(SumCountUgly(arr), Practice.CountPositivesSumNegatives(arr), $"test {r}");
            }
        }

        #region Misc

        private static string GenerateRandomString(int k)
        {
            string res = "";
            int n = -1;
            for (int i = 0; i < 15; i++)
            {
                n = _random.Next(97 + k, 122);
                for (int j = 0; j < _random.Next(1, 5); j++)
                    res += (char)n;
            }
            return res;
        }

        private static List<int> GenerateRandomList(bool alsoNegatives = false)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < _random.Next(15); i++)
            {
                list.Add(alsoNegatives ? _random.Next(-400, 400) : _random.Next(400));
            }
            return list;
        }

        private static string LongestUgly(string s1, string s2)
        {
            int[] alpha1 = new int[26];
            for (int i = 0; i < alpha1.Length; i++) alpha1[i] = 0;
            int[] alpha2 = new int[26];
            for (int i = 0; i < alpha2.Length; i++) alpha2[i] = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                int c = (int)s1[i];
                if (c >= 97 && c <= 122)
                    alpha1[c - 97]++;
            }
            for (int i = 0; i < s2.Length; i++)
            {
                int c = (int)s2[i];
                if (c >= 97 && c <= 122)
                    alpha2[c - 97]++;
            }
            string res = "";
            for (int i = 0; i < 26; i++)
            {
                if (alpha1[i] != 0)
                {
                    res += (char)(i + 97);
                    alpha2[i] = 0;
                }
            }
            for (int i = 0; i < 26; i++)
            {
                if (alpha2[i] != 0)
                    res += (char)(i + 97);
            }
            char[] lstr = res.ToCharArray();
            Array.Sort(lstr);
            res = string.Join("", lstr);
            return res;
        }

        private static List<int> MinimumUgly(List<int> numbers)
        {
            List<int> answer = numbers.ToList();
            if (answer.Count > 0)
            {
                answer.Remove(answer.Min());
            }
            return answer;
        }

        private static string CharErrorUgly(string s)
        {
            int cnt = 0; int l = s.Length;
            for (int i = 0; i < l; i++)
            {
                int c = (int)s[i];
                if (c > 109 && c <= 122)
                    cnt++;
            }
            return cnt.ToString() + "/" + l.ToString();
        }

        private static int[] ArrayDiffUgly(int[] a, int[] b)
        {
            List<int> ret = new List<int>(a);

            foreach (int x in b)
            {
                ret.RemoveAll(n => n == x);
            }

            return ret.ToArray();
        }

        private static bool IsogramUgly(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (dic.ContainsKey(char.ToLower(c)))
                    dic[char.ToLower(c)] = dic[char.ToLower(c)] + 1;
                else
                    dic.Add(char.ToLower(c), 1);
            }

            return dic.Values.All(cnt => cnt == 1);
        }

        private static string PhoneNumberUgly(int[] numbers)
        {
            string result = "";
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == 0) result += "(";
                result += numbers[i];
                if (i == 2) result += ") ";
                if (i == 5) result += "-";
            }
            return result;
        }

        private static int weightStrNbSol(string strng)
        {
            char[] digits = strng.ToCharArray();
            int dsum = 0;
            foreach (char d in digits)
            {
                int dgt = int.Parse(d.ToString());
                dsum += dgt;
            }
            return dsum;
        }

        private static int cmpSol(string x, string y)
        {
            int cp = weightStrNbSol(x) - weightStrNbSol(y);
            if (cp == 0)
                return string.Compare(x, y);
            if (cp < 0) return -1; else return 1;
        }

        private static string WeightUgly(string strng)
        {
            string[] lstr = strng.Split(' ');
            Array.Sort(lstr, cmpSol);
            string res = string.Join(" ", lstr);
            return res;
        }

        private static string GenerateWeights()
        {
            string res = "";
            for (int i = 0; i < 20; i++)
            {
                int n = _random.Next(1, 500000);
                res += n + " ";
            }
            return res + _random.Next(1, 100);
        }

        public static int BinaryUgly(int[] binaryArray)
        {
            binaryArray = binaryArray.Reverse().ToArray();
            for (int i = 1; i < binaryArray.Length; i++) binaryArray[0] += (binaryArray[i] == 1) ? (int)Math.Pow(2, i) : 0;
            return binaryArray[0];
        }

        public static int[] SumCountUgly(int[] numbers)
        {
            int count = 0, sum = 0;

            foreach (int n in numbers)
            {
                if (n > 0)
                    count++;
                else if (n < 0)
                    sum += n;
            }

            return (numbers.Length == 0 ? new int[] { } : new int[] { count, sum });
        }

        #endregion
    }
}