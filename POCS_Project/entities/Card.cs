﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    }
    public enum Suits{
        [Display(Name="Ouro")]
        Diamonds = 'O',
        [Display(Name = "Copa")]
        Heart = 'C',
        [Display(Name = "Espada")]
        Spade = 'E',
    }
}