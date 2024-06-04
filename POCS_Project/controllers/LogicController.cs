using NPOI.SS.Formula.Functions;
using NPOI.XSSF.Streaming.Values;
using NPOI.XSSF.UserModel;
using POCS_Project.entities;
using POCS_Project.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCS_Project.controllers
{
    public class LogicController
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
                var x = dataCards[item];
                foreach (var value in x)
                {
                    if (item == naipe)
                        result.Add(lista[value].Order);
                    else if (item == "Heart")
                        lastOption.Add(lista[value].Order);
                    else
                        outers.Add(lista[value].Order);
                }
            }

            if(result.Count() < 1)
            {
                if (lastOption.Count() > 0)
                    return lastOption.ToArray();
                else
                    return outers.ToArray();
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
                    max = key;
            }

            return max;

        }

        public int AfterThem(List<Card> playeds, List<Card> myCards, int currentRound)
        {
            Dictionary<string, int[]> sepCardsPlayed = FirstStep(playeds);
            Dictionary<string, int[]> sepMyCards = FirstStep(myCards);
            Card firstCardPlayedInThisRound = playeds.FirstOrDefault(x => x.RoundPlayed == currentRound);
            string firstSuitPlayedInThisRound = firstCardPlayedInThisRound != null? firstCardPlayedInThisRound.Suit.ToString() : playeds.First().Suit.ToString();

            //verifica se mais de um naipe e busca saber qual é
            if (firstSuitPlayedInThisRound != null && sepCardsPlayed.Keys.Count() > 0 && !sepMyCards.Keys.Contains(firstSuitPlayedInThisRound))
                return ReadStepValues(sepMyCards, myCards, "Heart").First();
            else
            {

                if (firstSuitPlayedInThisRound.ToLower() == "heart")
                    Console.WriteLine();

                if (sepMyCards.Any(some => some.Key == firstSuitPlayedInThisRound))
                {
                    int[] equalCards = ReadStepValues(sepMyCards, myCards, firstSuitPlayedInThisRound); // Retorna os index's de suas cartas com esse naipe
                    int[] playedValues = ReadStepValues(sepCardsPlayed, playeds, firstSuitPlayedInThisRound);
                    return playedValues.Max(x => x > equalCards.Last() && firstSuitPlayedInThisRound != "Heart") ? equalCards.First() : equalCards.Last();
                }
            }


            string key = MaxOfSep(sepMyCards);
            return sepMyCards[key].First();

        }

        public int FirstPlay(List<Card> myCards)
        {
            Dictionary<string, int[]> sepMyCards = FirstStep(myCards);

            var key = MaxOfSep(sepMyCards);

            return sepMyCards[key].Last();
        }

    }
}
