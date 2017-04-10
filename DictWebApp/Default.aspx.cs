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
            foreach( var word in words)
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

                
            }
            dbTest.Text = "A : "+alphabet['a'].ToString()+ " X: " + alphabet['x'].ToString();

        }
    }
}