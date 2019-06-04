using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LINQ
{
    public static class Practice
    {
        /// <summary>
        /// Disemvowel: Napíšte funkciu, ktorá na vstupe zoberie reťazec a vráti nový reťazec, v ktorom
        /// bude text zo vstupného reťazca očistený od všetkých samohlások.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Disemvowel(string input)
        {
            string consonants = "aeiouyAEIOUY";
            char[] noVowels = input.Where(c => !consonants.Contains(c)).Select(n => n).ToArray();
            return new string (noVowels);
        }

        /// <summary>
        /// TwoToOne: Do funkcie vstúpia 2 reťazce s1 a s2, ktoré budú obsahovať iba písmená od a po
        ///        z.Z funkcie sa vráti nový zotriedený reťazec, najdlhší možný, v ktorom budú písmená z s1 a
        ///s2, pričom každé sa bude v tomto reťazci vyskytovať iba raz.
        ///Napríklad:
        ///a = "xyaabbbccccdefww", b = "xxxxyyyyabklmopq", TwoToOne(a, b) => "abcdefklmopqwxy"
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static string TwoToOne(string s1, string s2)
        {
            string s = s1 + s2;
            return new string (s.Distinct().OrderBy(c=>c).ToArray());
        }

        /// <summary>
        /// RemoveMinimum: Do funkcie vstúpi zoznam čísel, z ktorého je potrebné odstrániť najmenšiu
        ///        hodnotu.Ak sa v poli vyskytuje najnižšia hodnota viac krát, odstráňte tú z nich, ktorá ma najnižší
        ///index.Ak do funkcie vstúpi prázdny zoznam, vráťte prázdny zoznam.Neupravujte pôvodný
        ///zoznam! Nemeňte poradie zvyšných prvkov.
        ///Napríklad: RemoveMinimum(new List<int>{1,2,3,4,5}) => new List<int>{2,3,4,5}
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static List<int> RemoveMinimum(List<int> numbers)
        {
            if (numbers.Count == 0)
                return numbers;
            numbers.Remove(numbers.Min());
            return numbers;
        }

        //        CharacterError: Vytvorte funkciu, ktorá bude kontrolovať chybovosť vstupného reťazca.Za
        //korektný považujte taký reťazec, ktorý obsahuje iba písmená od a po m.Chybovosť reťazca sa bude
        //vracať v tvare “X/Y”, kde X bude počet chybných znakov v reťazci a Y celková dĺžka reťazca.Na
        //vstupe bude vždy reťazec s dĺžkou minimálne 1, pozostávajúci iba z písmen od a po z.
        //Napríklad: s = "aaaxbbbbyyhwawiwjjjwwm", CharacterError(s) => "8/22"
        public static string CharacterError(string s)
        {
            string errorChars = "nopqrstuvwxyz";

            int numOfErrors = s.Where(c => errorChars.Contains(c)).ToList().Count;

            return $"{numOfErrors}/{s.Length}";
        }

        //ArrayDiff: Vytvorte funkciu, ktorá odčíta jedno pole čísel od druhého a vráti výsledok, t.j.z poľa a
        //by mala odstrániť všetky prvky, ktoré sa nachádzajú v poli b.Ak sa nejaká hodnota nachádza v poli
        //b, z poľa a musia byť odstránené všetky jej výskyty.
        //Napríklad: a = new int[] { 1, 2, 2, 2, 3 }, b = new int[] { 2 }, ArrayDiff(a, b) => new int[] {1, 3}
        public static int[] ArrayDiff(int[] a, int[] b)
        {
            return a.Where(n => !b.Contains(n)).ToArray();
        }

        //IsIsogram: Isogram je slovo, v ktorom sa neopakuje žiadne písmeno.Vytvorte funkciu, ktorá bude
        //identifikovať isogramy. Predpokladajte, že prázdny reťazec je isogram.Na veľkosti písmen nezáleží.
        //Napríklad: IsIsogram("moose") => false
        public static bool IsIsogram(string str)
        {
            str = str.ToLower();
            return str == new string (str.Distinct().ToArray());
        }

        //CreatePhoneNumber: Vytvorte funkciu, ktorá zo vstupného poľa 10 čísel vytvorí telefónne číslo v
        //americkom tvare.Skúste využiť(aj) Regex.
        //Napríklad: CreatePhoneNumber(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 0}) => "(123) 456-7890"
        public static string CreatePhoneNumber(int[] numbers)
        {
            Regex phoneRgx = new Regex(@"\(?\d{3}\)? *\d{3}-?\d{4}");
            return string.Empty;
        }

        //FindParityOutlier: Dostanete pole čísel, ktoré bude mať minimálne 3 prvky, ale môže ich tiež mať
        //oveľa viac.V celom poli sú všetky čísla buď párne, alebo nepárne, okrem jediného čísla N.Vytvorte
        //funkciu, ktorá nájde toto číslo N.
        //Napríklad: GetParityOutlier(new int[] {2, 4, 0, 100, 4, 11, 2602, 36}) => 11 (jediné nepárne číslo)
        public static int FindParityOutlier(int[] integers)
        {
            int[] evenInts = integers.Where(x => x % 2 == 0).ToArray();
            if (evenInts.Length == 1)
                return evenInts[0];
            else
                return integers.First(x=>x%2==1);

        }

        //        PigLatin: Vytvorte jednoduchú šifru na princípe tzv. “pig latin”. Vo vete presuňte prvé písmeno
        //každého slova na jeho koniec a pridajte koncovku “ay”. Interpunkciu nemeňte.
        //Napríklad: PigLatin("Hello world !") => “elloHay orldway !”
        public static string PigLatin(string str)
        {
            string[] words = str.Split(' ');
            string[] pigWords = words.Select(x => x + x.First() + "ay").ToArray();
            pigWords = pigWords.Select(x => new string (x.Skip(1).ToArray())).ToArray();
            string finalSentenceInPig = pigWords.Aggregate((result, x) => result + $" {x}");
            return finalSentenceInPig;
        }

        //ChangeWeight: Do funkcie vám príde zoznam váh fitness klubu Fat to Fit(reťazec čísel oddelených
        //medzerami). Vašou úlohou bude zotriediť čísla v tomto zozname a vrátiť ich naspäť(tiež ako
        //reťazec čísel oddelených medzerami). Aby sa členovia tohto klubu necítili až tak zle, funkcia nebude
        //radiť čísla podľa ich hodnoty, ale najskôr podľa ich ciferného súčtu.V prípade rovnakého ciferného
        //súčtu dvoch čísel sa tieto čísla zoradia navzájom abecedne.
        //Napríklad: ChangeWeight("56 65 74 100 99 68 86 180 90") => "100 180 90 56 65 74 68 86 99"
        public static string ChangeWeight(string strng)
        {
            string[] weights = strng.Split(' ');

            return new string (weights.OrderBy(n=>n.Sum(c => c - '0')).ThenBy(n=>n).Aggregate((result,x) => result + $" {x}").ToArray());
        }

        //DontGiveMeFive: Do funkcie prídu hranice intervalu(inkluzívne) a návratovou hodnotou bude
        //počet čísel z tohto intervalu, v ktorých sa nenachádza číslica 5. Ľavá hranica intervalu bude vždy
        //menšia ako pravá, môžu byť aj záporné.
        //Napríklad: DontGiveMeFive(1, 9) => 8 // 1, 2, 3, 4, 6, 7, 8, 9
        public static int DontGiveMeFive(int start, int end)
        {
            //List<int> range = Enumerable.Range(start, end - start +1).ToList();
            //range = range.Where(x => !x.ToString().Contains('5')).ToList();
            //int count = range.Count();

            return Enumerable.Range(start, end-start+1).Where(x => !x.ToString().Contains('5')).Count();
            //return count;
        }

        //DuplicateEncoder: Vytvorte jednoduché kódovanie, ktoré vo vstupnej správe vymení znaky tak, že
        //znaky, ktoré sa v správe nachádzajú iba raz, nahradí ľavou zátvorkou(“(“) a znaky s viacnásobným
        //výskytom nahradí pravou zátvorkou(“)”). Veľkosť písmen ignorujte.
        //Napríklad: DuplicateEncoder("Recede") => "()()()"
        public static string DuplicateEncode(string word)
        {
            word = word.ToLower();

            return new string(word.Select(x => word.GroupBy(p => p).ToDictionary(y => y.Key, y => y.ToArray().Length)[x] == 1 ? '(' : ')').ToArray());
        }

        //OnesAndZeros: Vytvorte konverted binárnych čísel.Do funkcie bude vstupovať pole núl a
        //jednotiek a z funkcie bude vystupovať číslo v desiatkovej sústave. Vstupné polia môžu mať rôzne
        //veľkosti.
        //Pomôcka: prečítajte si dokumentáciu ku funkcii Convert.ToInt32.
        //Napríklad: OnesAndZeros(new int[] {0, 1, 1, 0}) => 6
        public static int OnesAndZeros(int[] binaryArray)
        {
            int i = 1;
            char c = Convert.ToChar(i+48);


            string binary = new string(binaryArray.Select(x=>Convert.ToChar(x+48)).ToArray());
            return Convert.ToInt32(binary, 2);
        }

        //CountPositivesSumNegatives: Vytvorte funkciu, do ktorej ako parameter príde pole čísel a
        //výstupom ktorej bude dvojprvkové pole, kde prvý prvok bude počet kladných čísel a druhý prvok
        //bude súčet záporných čísel.Ak je vstupné pole prázdne, nech je prázdne aj výstupné pole.
        //Nastavenie:
        //Magic(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, -11, -12, -13, -14, -15}) => new int[] {10, -65}
        public static int[] CountPositivesSumNegatives(int[] input)
        {
            if (input == null)
                return new int[0];

            if (input.Length == 0)
                return new int[0];

            int positivesCount = input.Where(x => x > 0).Count();
            int negativesSum = input.Where(x => x < 0).Count()==0? 0 : input.Where(x => x < 0).Aggregate((result,x)=>result + x);
            return new int[] {positivesCount, negativesSum };
        }
    }
}