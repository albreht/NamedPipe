using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;

using System.Text.RegularExpressions;

namespace MyApp // Note: actual namespace depends on the project name.
{
    [SimpleJob(RunStrategy.ColdStart, launchCount: 1, warmupCount: 1, targetCount: 100)]
    public class Program
    {
        const string allowed = "abcdefghijk ";
        readonly HashSet<int> allowedCharNum ;

        readonly HashSet<int> longArrayHashset ;
        readonly SortedSet<int> longArraySortedset;
        readonly int[] longArray;

        readonly HashSet<int> longArrayHashset1;
        readonly SortedSet<int> longArraySortedset1;

        


        readonly int[] longArray1;

        static Regex onlyLettersRegex = new Regex("[^abcdefghijk ]");
        static Regex multipleSpacesRegex = new Regex(@"\s{2,}");
        string testString = "";
        Random rand = new Random();
        public Program()
        {
            
           testString = "Contrary  to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32.\r\n\r\nThe standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32.\r\n\r\nThe standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32.\r\n\r\nThe standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32.\r\n\r\nThe standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32.\r\n\r\nThe standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32.\r\n\r\nThe standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32.\r\n\r\nThe standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock, a Latin professor at Hampden-Sydney College in Virginia, looked up one of the more obscure Latin words, consectetur, from a Lorem Ipsum passage, and going through the cites of the word in classical literature, discovered the undoubtable source. Lorem Ipsum comes from sections 1.10.32 and 1.10.33 of \"de Finibus Bonorum et Malorum\" (The Extremes of Good and Evil) by Cicero, written in 45 BC. This book is a treatise on the theory of ethics, very popular during the Renaissance. The first line of Lorem Ipsum, \"Lorem ipsum dolor sit amet..\", comes from a line in section 1.10.32.\r\n\r\nThe standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested. Sections 1.10.32 and 1.10.33 from \"de Finibus Bonorum et Malorum\" by Cicero are also reproduced in their exact original form, accompanied by English versions from the 1914 translation by H. Rackham.";
           allowedCharNum = allowed.Select(p=>(int)p).ToHashSet();

            longArrayHashset = new HashSet<int>();
            longArraySortedset = new SortedSet<int>();
            longArray = new int[1500];

            longArrayHashset1 = new HashSet<int>();
            longArraySortedset1 = new SortedSet<int>();
            longArray1 = new int[1500];

            var rand = new Random();
            for (int i = 0; i < 1500; i++)
            {
                var rnd = rand.Next();
                longArrayHashset.Add(rnd);
                longArraySortedset.Add(rnd);
                longArray[i] = rnd;

                longArrayHashset1.Add(rnd);
                longArraySortedset1.Add(rnd);
                longArray1[i] = rnd;
            }
        }
       

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var list = new List<int>() { 1, 2, 3, 4,1,1,1,1,1,1,1,1,1,1 };
            var list1 = new List<int>() { 1, 2, 4, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            var list2 = new List<int>() { 1, 4, 2, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

            Console.WriteLine( GetHashCode(list));
            Console.WriteLine(GetHashCode(list1));
            Console.WriteLine(GetHashCode(list2));

            Console.WriteLine(GetHashCodeOld(list));
            Console.WriteLine(GetHashCodeOld(list1));
            Console.WriteLine(GetHashCodeOld(list2));

            Console.WriteLine(GetHashCodeWithOrder(list));
            Console.WriteLine(GetHashCodeWithOrder(list1));
            Console.WriteLine(GetHashCodeWithOrder(list2));

            Console.WriteLine(GetHashCodeWithOrder1(list));
            Console.WriteLine(GetHashCodeWithOrder1(list1));
            Console.WriteLine(GetHashCodeWithOrder1(list2));


            //var p = new Program();
            //var f = p.testWhile();
            //var d = p.testRegex();
            //var ss = p.stripMultipleSpaces();

#if (!DEBUG)
  var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
#endif



        }
        //[Benchmark]
        //public string testWhile() {

        //    StringBuilder outstr = new StringBuilder();
        //    foreach (var item in testString)
        //    {
        //        if (allowedCharNum.Contains(item))
        //        {
        //            outstr.Append(item);
        //        }
        //        else
        //        {
        //            outstr.Append(' ');
        //        }
        //    }

        //    return outstr.ToString();
        //}

        //[Benchmark]
        //public string stripMultipleSpaces()
        //{
        //    char lastCharacter=' ';
        //    StringBuilder outstr = new StringBuilder();
        //    foreach (var item in testString)
        //    {
        //        if(item == ' ' && lastCharacter == ' ')
        //        {
        //            continue;
        //        }
        //        outstr.Append(item);
        //        lastCharacter = item;
        //    }

        //    return outstr.ToString();
        //}

        //[Benchmark]
        //public string testRegex()
        //{

        //    return onlyLettersRegex.Replace(testString," ");
        //}

        //[Benchmark]
        //public void testFindHashset()
        //{
        //    var rnd = rand.Next();
        //    if (longArrayHashset.Contains(rnd))
        //        longArrayHashset.Remove(rnd);
        //}
        //[Benchmark]
        //public void testFindSortedSet()
        //{

        //    var rnd = rand.Next();
        //    if (longArraySortedset.Contains(rnd))
        //        longArraySortedset.Remove(rnd);
        //}
        [Benchmark]
        public int testIntersectHashset()
        {
           return longArrayHashset.Intersect(longArrayHashset1).Count();
        }
        [Benchmark]
        public int testIntersectSortedSet()
        {

            return longArraySortedset.Intersect(longArraySortedset1).Count();
        }

        [Benchmark]
        public int testIntersectArray()
        {
            return longArray.Intersect(longArray1).Count();
        }




        //[Benchmark]
        //public string testStripMultipleSpacesRegex()
        //{

        //    return multipleSpacesRegex.Replace(testString, " ");
        //}

        static int GetHashCode(IEnumerable<int> integers)
        {
            int hash = 0;

            foreach (int integer in integers)
            {
                int x = integer;

                x ^= x >> 17;
                x *= 830770091;   // 0xed5ad4bb
                x ^= x >> 11;
                x *= -1404298415; // 0xac4c1b51
                x ^= x >> 15;
                x *= 830770091;   // 0x31848bab
                x ^= x >> 14;

                hash += x;
            }

            return hash;
        }

        static int GetHashCodeWithOrder1(IEnumerable<int> integers)
        {
            int hash = 0;
            int i = 0;
            foreach (int integer in integers)
            {
                int x = integer + i;

                x ^= x >> 17;
                x *= 830770091;   // 0xed5ad4bb
                x ^= x >> 11;
                x *= -1404298415; // 0xac4c1b51
                x ^= x >> 15;
                x *= 830770091;   // 0x31848bab
                x ^= x >> 14;

                hash += x;
                i++;
            }

            return hash;
        }

        static int GetHashCodeOld(IEnumerable<int> integers)
        {
            
            

            return integers.Sum();
        }


        static int GetHashCodeWithOrder(IEnumerable<int> integers)
        {


            int ret = 0;
            var list = integers.ToList();
            for (int i = 0; i < integers.Count(); i++)
            {
                ret +=  list[i]-i;
            }

            return ret;
        }

    }
}