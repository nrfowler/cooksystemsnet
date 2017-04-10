using System;
using System.Collections.Generic;
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

            foreach ( var word in words)
            {
                char firstLetter = word.Word.First();
                if (alphabet.ContainsKey(firstLetter))
                {
                    int count = ++alphabet[firstLetter];
                    alphabet.Remove(firstLetter);
                    alphabet.Add(firstLetter, count);
                }
                else
                    alphabet.Add(firstLetter, 1);
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
            dbTest.Text = "A : "+alphabet['a'].ToString()+ " X: " + alphabet['x'].ToString();
            endStrings.Text = "A : " + alphabetLast['a'].ToString() + " X: " + alphabetLast['x'].ToString();

        }
    }
}