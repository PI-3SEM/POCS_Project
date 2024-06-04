using POCS_Project.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.ExceptionServices;
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
        public Dictionary<string, Bitmap> cardImages = new Dictionary<string, Bitmap>();
        public int x = 60;
        public int y = 90;
        public CardStyle()
        {
            var bitmaps = new List<Bitmap> {
                Properties.Resources.Estrela,
                Properties.Resources.EstrelaVirada,
                Properties.Resources.LuaVirada,
                Properties.Resources.Lua,
                Properties.Resources.PausVirada,
                Properties.Resources.Paus,
                Properties.Resources.Copas,
                Properties.Resources.CopasVirada,
                Properties.Resources.Espadas,
                Properties.Resources.EspadasVirada,
                Properties.Resources.Ouros,
                Properties.Resources.OurosVirada,
                Properties.Resources.Triângulo,
                Properties.Resources.TriânguloVirada,
            };
            var bitmapNames = bitmaps.GetBitmapNames();
            int index = 0;
            foreach(var bitmap in bitmaps)
            {
                var nameBitmap = bitmapNames[index++];
                cardImages.Add(nameBitmap, bitmap);
            }
        }
    }

    public enum Suits{
        [Display(Name="Ouros")]
        Diamonds = 'O',
        [Display(Name = "Copas")]
        Heart = 'C',
        [Display(Name = "Espadas")]
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
