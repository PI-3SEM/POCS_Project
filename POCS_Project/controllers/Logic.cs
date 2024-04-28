using NPOI.SS.Formula.Functions;
using POCS_Project.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCS_Project.controllers
{
    public class Logic
    {
        //Naipe, index
        public Dictionary<string, int[]> FirstStep(List<Card> cards)
        {
            Dictionary<string, int[]> dataCards = new Dictionary<string, int[]>();
            List<int> index = new List<int>();

            foreach (var sec in cards)
            {
                bool flag = false;
                if (cards.Any(obj => obj.Suit == sec.Suit))
                    index = Enumerable.Range(0, cards.Count)
                            .Where(i => cards[i].Suit == sec.Suit)
                            .ToList();

                if (dataCards.Any(x => x.Key == sec.Suit.ToString()))
                    flag = true;

                if (index.Count() > 0 && flag != true)
                    dataCards.Add(cards[index[0]].Suit.ToString(), index.ToArray());

            }

            return dataCards;


        }
    }
}
