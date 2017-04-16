using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DictWebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var words = new NorthwindEntities().WordTables;
            Dictionary<char, int> alphabet = new Dictionary<char, int>();
            Dictionary<char, int> alphabetLast = new Dictionary<char, int>();
            //The total chars of words where the char is the first char
            Dictionary<char, int> alphabetTotalChars = new Dictionary<char, int>();
            Dictionary<char, string> smallestWord = new Dictionary<char, string>();
            Dictionary<char, string> largestWord = new Dictionary<char, string>();

            foreach ( var word in words)
            {

                char firstLetter = word.Word.First();
                if (alphabet.ContainsKey(firstLetter))
                {
                    //add to count of words that match
                    int count = ++alphabet[firstLetter];
                    alphabet.Remove(firstLetter);
                    alphabet.Add(firstLetter, count);
                    //add length of word to Total Length of Words that Match
                    count = alphabetTotalChars[firstLetter]+word.Word.Count();
                    alphabetTotalChars.Remove(firstLetter);
                    alphabetTotalChars.Add(firstLetter, count);
                    //if word is smallest word, replace the current smallest word
                    if (smallestWord[firstLetter].Count() > word.Word.Count())
                    {
                        smallestWord.Remove(firstLetter);
                        smallestWord.Add(firstLetter, word.Word);
                    }
                    if (largestWord[firstLetter].Count() < word.Word.Count())
                    {
                        largestWord.Remove(firstLetter);
                        largestWord.Add(firstLetter, word.Word);
                    }

                }
                else
                {
                    alphabetTotalChars.Add(firstLetter, word.Word.Count());
                    smallestWord.Add(firstLetter, word.Word);
                    largestWord.Add(firstLetter, word.Word);

                    alphabet.Add(firstLetter, 1);
                }
                char lastLetter = word.Word.Last();
                if (alphabetLast.ContainsKey(lastLetter))
                {
                    int count = ++alphabetLast[lastLetter];
                    alphabetLast.Remove(lastLetter);
                    alphabetLast.Add(lastLetter, count);
                }
                else
                    alphabetLast.Add(lastLetter, 1);

            }
            //dbTest.Text = "# Words with First char A : "+alphabet['a'].ToString()+ " X: " + alphabet['x'].ToString();
            //endStrings.Text = "# Words with Last char A : " + alphabetLast['a'].ToString() + " X: " + alphabetLast['x'].ToString();
            //averageLength.Text = " Length: " + "A : "+ (alphabetTotalChars['a']/ alphabet['a']).ToString()+ " X: " + (alphabetTotalChars['x'] / alphabet['x']).ToString();
            //smallestWordLiteral.Text = "Smallest Word: "+smallestWord['a'].ToString() + " X: " + smallestWord['x'].ToString();
            //largestWordLiteral.Text = "Largest Word: "+largestWord['a'].ToString() + " X: " + largestWord['x'].ToString();

            DataTable dt = new DataTable("DictionaryTable");
            dt.Columns.Add("Letter");
            dt.Columns.Add("# Words with first char matching");
            dt.Columns.Add("# Words with last char matching");
            dt.Columns.Add("Average Length");
            dt.Columns.Add("Smallest Word");
            dt.Columns.Add("Longest Word");
            DataRow workRow;
            char[] alphabetArray = alphabet.Keys.ToArray();
            for (int i = 0; i < 26; i++)
            {
                workRow = dt.NewRow();
                char letter = alphabetArray[i];
                workRow[0] = letter;
                workRow[1] = alphabet[letter].ToString();
                workRow[2] = alphabetLast[letter].ToString();
                workRow[3] = (alphabetTotalChars[letter] / alphabet[letter]).ToString();
                workRow[4] = smallestWord[letter].ToString();
                workRow[5] = largestWord[letter].ToString();
                dt.Rows.Add(workRow);
            }
            gv.DataSource = dt;
            gv.DataBind();
        }
    }
}