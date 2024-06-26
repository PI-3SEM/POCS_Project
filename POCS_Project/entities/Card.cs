﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCS_Project.entities
{
    public class Card
    {
        public Player Owner { get; set; }
        public int Order { get; set; }
        public Suits Suit { get; set; }
        public int Value { get; set; }
        public int? RoundPlayed { get; set; }

        public bool WasUsed = false;
    }


    public class CardStyle
    {
        public List<string> pathsNotPlayed = Directory.GetFiles("Assets", "*.png")
            .Where(x=>!x.Contains("Virada"))
            .ToList();
        public List<string> pathsPlayed = Directory.GetFiles("Assets", "*.png")
            .Where(x=>x.Contains("Virada"))
            .ToList();
        public int x = 60;
        public int y = 90;
    }

    public enum Suits{
        [Display(Name="Ouro")]
        Diamonds = 'O',
        [Display(Name = "Copa")]
        Heart = 'C',
        [Display(Name = "Espada")]
        Spade = 'E',
        [Display(Name = "Lua")]
        Moon = 'L',
        [Display(Name = "Paus")]
        Clubs = 'P',
        [Display(Name = "Triângulo")]
        Triangle = 'T',
        [Display(Name = "Estrela")]
        Star = 'S'
    }
}
