using NPOI.SS.Formula.Functions;
using NPOI.XSSF.Streaming.Values;
using NPOI.XSSF.UserModel;
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
        //Naipe, index na posição da lista passada
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

        internal int[] ReadStepValues(Dictionary<string, int[]> dataCards,List<Card> lista, string naipe)
        {
            List<int> result = new List<int>();
            List<int> outers = new List<int>();
            List<int> lastOption = new List<int>();
            
            foreach (var item in dataCards.Keys)
            {
                if (item == naipe)
                {
                    var x = dataCards[item];
                    foreach (var value in x)
                    {
                        result.Add(lista[value].Value);
                    }

                }
                else if (item == "Heart")
                {
                    var x = dataCards[item];
                    foreach (var value in x)
                    {
                        lastOption.Add(lista[value].Value);
                    }
                }
                else
                {
                    var x = dataCards[item];
                    foreach (var value in x)
                    {
                        outers.Add(lista[value].Value);
                    }
                }
            }

            if(result.Count() < 1)
            {
                if (lastOption.Count() > 0)
                {
                    return lastOption.ToArray();
                }
                else
                {
                    return outers.ToArray();
                }
            }

            return result.ToArray();
        }

        public string MaxOfSep(Dictionary<string, int[]> sepCards)
        {
            Dictionary<string, int> order = new Dictionary<string, int>();
            string max = null;

            foreach (var key in sepCards.Keys)
            {
                max = key;
                var x = sepCards[key];
                order.Add(key, x.Count());
            }

            foreach (var key in sepCards.Keys)
            {
                if (order[key] > order[max])
                {
                    max = key;
                }
            }

            return max;

        }

        

        public int AfterThem(List<Card> playeds, List<Card> myCards)
        {
            Dictionary<string, int[]> sepCardsPlayed = FirstStep(playeds);
            Dictionary<string, int[]> sepMyCards = FirstStep(myCards);

            //primeira naipe carta playeds.First().Suit

            //verifica se mais de um naipe e busca saber qual é
            if (sepCardsPlayed.Keys.Count() > 0)
            {
                if (!sepMyCards.Keys.Contains(sepCardsPlayed.Keys.First()))
                {
                    return ReadStepValues(sepMyCards, myCards, "Heart").First();
                }
            }
            else
            {
                if (sepMyCards.Any(some => some.Key == sepCardsPlayed.Keys.ToList().First()))
                {
                    int[] equalCards = ReadStepValues(sepMyCards, myCards, sepCardsPlayed.Keys.ToList()[0]); // Retorna os index's de suas cartas com esse naipe
                    int[] playedValues = ReadStepValues(sepCardsPlayed, playeds, sepCardsPlayed.Keys.ToList()[0]);

                    if (playedValues.Max(x => x > equalCards.Last() && sepCardsPlayed.Keys.ToList()[0] != "Heart"))
                    {
                        return equalCards.First();
                    }
                    else
                    {
                        return equalCards.Last();
                    }
                }


               
            }


            string key = MaxOfSep(sepMyCards);
            return sepMyCards[key].First();

        }


        public int FistPlay(List<Card> myCards)
        {
            Dictionary<string, int[]> sepMyCards = FirstStep(myCards);

            var key = MaxOfSep(sepMyCards);

            return sepMyCards[key].Last();
        }


    }
}
