﻿using NPOI.SS.Formula.Functions;
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

        internal int[] readStepValues(Dictionary<string, int[]> dataCards,List<Card> lista, string naipe)
        {
            List<int> result = new List<int>();
            
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
            }
            return result.ToArray();
        }

        public int afterThem(List<Card> playeds, List<Card> myCards)
        {
            Dictionary<string, int[]> sepCardsPlayed = FirstStep(playeds);
            Dictionary<string, int[]> sepMyCards = FirstStep(myCards);

            //primeira naipe carta playeds.First().Suit

            //verifica se mais de um naipe e busca saber qual é
            if (sepCardsPlayed.Keys.Count() > 1)
            {
                foreach (var naipe in sepMyCards.Keys)
                {
                    if(naipe == "Heart")
                    {
                        int value = readStepValues(sepCardsPlayed, playeds, "Heart")[0]; 
                        //...
                    }
                }
            }
            else
            {
                if (sepMyCards.Any(some => some.Key == playeds.First().Suit.ToString()))
                {
                    int[] equalCards = readStepValues(sepMyCards, myCards, playeds.First().Suit.ToString()); // Retorna os index's de suas cartas com esse naipe
                    int[] playedValues = readStepValues(sepCardsPlayed, playeds, playeds.First().Suit.ToString());

                    if (playedValues.Max(x => x > equalCards.Last()))
                    {

                    }
                    
                }
                else
                {

                }
            }



            return 0;
        }

    }
}
