using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _2018._11._20_LinqStuff
{
    [TestClass]
    public class LinqStuffTests
    {
        static string[] Keywords = {
            "abstract", "add*", "alias*", "as", "ascending*",
            "async*", "await*", "base","bool", "break",
            "by*", "byte", "case", "catch", "char", "checked",
            "class", "const", "continue", "decimal", "default",
            "delegate", "descending*", "do", "double",
            "dynamic*", "else", "enum", "event", "equals*",
            "explicit", "extern", "false", "finally", "fixed",
            "from*", "float", "for", "foreach", "get*", "global*",
            "group*", "goto", "if", "implicit", "in", "int",
            "into*", "interface", "internal", "is", "lock", "long",
            "join*", "let*", "nameof*", "namespace", "new", "null",
            "object", "on*", "operator", "orderby*", "out", "override",
            "params", "partial*", "private", "protected",
            "public", "readonly", "ref", "remove*", "return", "sbyte",
            "sealed", "select*", "set*", "short", "sizeof",
            "stackalloc", "static", "string", "struct", "switch",
            "this", "throw", "true", "try", "typeof", "uint", "ulong",
            "unchecked", "unsafe", "ushort", "using", "value*", "var*",
            "virtual", "void", "volatile", "where*", "while", "yield*"
        };



        [TestMethod]
        public void Where_KeywordsEndInE_Success()
        {
            int predicateCounter = 0;
            bool PredicateForThingsEndingInE(string word)
            {
                predicateCounter++;
                return word.ToLower().EndsWith('e');
            }

            IEnumerable<string> query = Keywords.Where(
                PredicateForThingsEndingInE);

            // What does predicateCounterEqual?
            Assert.AreEqual<int>(0, predicateCounter);

            List<string> keywordsEndingInE = query.ToList();
            Assert.AreEqual<int>(Keywords.Length, predicateCounter);
            Assert.IsTrue(keywordsEndingInE.Count<string>() > 0);

            // What does predicateCounterEqual?
            Assert.AreEqual<int>(Keywords.Length, predicateCounter);
            foreach (string item in keywordsEndingInE)
            {
                Assert.AreEqual<char>('e', item[item.Length - 1]);
            }

            // What does predicateCounterEqual?
            Assert.AreEqual<int>(Keywords.Length, predicateCounter);

        }

        [TestMethod]
        public void Where_KeywordsEndInSpecifiedCharacter_Success()
        {
            bool PredicateForThingsEndingIn(string word, char endingCharacter)
            {
                return word.ToLower().EndsWith(char.ToLower(endingCharacter));
            }

            IEnumerable<string> query = Keywords.Where(
                (string item) => PredicateForThingsEndingIn(item, 'e'));

            int counter = 0;
            foreach (string item in query)
            {
                Assert.AreEqual<char>('e', item[item.Length - 1]);
                counter++;
            }
            Assert.AreEqual<int>(17, counter);
        }


        [TestMethod]
        public void Select_FirstAndLastLetter_VerifySuccessWithEnumerator()
        {

            IEnumerable<(char First, char Last)> query = Keywords.Select<string, (char First, char Last)>(
                (string item) => (item[0], item[item.Length - 1]));



            IEnumerator< (char First, char Last)> queryEnumerator = query.GetEnumerator();
            
            foreach(string keyword in Keywords)
            {
                Assert.IsTrue(queryEnumerator.MoveNext());
                // Could also be done comparing the tuples directly.
                Assert.AreEqual<char>(keyword[0], queryEnumerator.Current.First);
                Assert.AreEqual<char>(keyword[keyword.Length-1], queryEnumerator.Current.Last);
            }
            Assert.IsFalse(queryEnumerator.MoveNext(),
                "Unexpectedly, the are more first,last tuples to enumerate over.");
        }

        [TestMethod]
        public void Select_FirstAndLastLetter_VerifySuccessWithZip()
        {

            IEnumerable<(char First, char Last)> query = Keywords.Select<string, (char First, char Last)>(
                (string item) => (item[0], item[item.Length - 1]));

            Keywords.Zip(query, (item, firstLastLetters) => {
                Assert.AreEqual<char>(item[0], firstLastLetters.First);
                Assert.AreEqual<char>(item[item.Length], firstLastLetters.Last);
                return true;
            });  
        }
    }
}
