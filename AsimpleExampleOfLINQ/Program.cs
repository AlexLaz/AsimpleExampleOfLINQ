using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsimpleExampleOfLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Clothe> myClothes = new List<Clothe>()
            {
                new Clothe() { Brand = "Lacoste", Composition = ClotheComposition.CV, Color = ClotheColor.Black, ClotheCost = 70, Year = 2009},
                new Clothe() { Brand = "Nike", Composition = ClotheComposition.PAN, Color = ClotheColor.Red, ClotheCost = 100, Year = 2010},
                new Clothe() { Brand = "Adidas", Composition = ClotheComposition.CO, Color = ClotheColor.Black, ClotheCost = 170, Year = 2012},
                new Clothe() { Brand = "Lacoste", Composition = ClotheComposition.CO, Color = ClotheColor.Yellow, ClotheCost = 200, Year = 2014},
                new Clothe() { Brand = "Reebok", Composition = ClotheComposition.PAN, Color = ClotheColor.Blue, ClotheCost = 120, Year = 20015}
            };

            Console.WriteLine("--Order my clothes by year(descent)--");
            var orderedClothe_des = myClothes.OrderByDescending(p => p.Year);

            foreach (var clothe in orderedClothe_des)
            {
                Console.WriteLine("{0} - {1} - {2} - {3} euro - {4}", clothe.Brand, clothe.Composition, clothe.Color, clothe.ClotheCost, clothe.Year); 
            }
            Console.WriteLine("----------------------");

            Console.WriteLine("--Order my clothes by cost--");
            var orderClothe = from clothe in myClothes
                              orderby clothe.ClotheCost
                              select clothe;

            foreach (var clothe in orderClothe)
            {
                Console.WriteLine("{0} - {1} - {2} - {3} euro - {4}", clothe.Brand, clothe.Composition, clothe.Color, clothe.ClotheCost, clothe.Year);
            }
            Console.WriteLine("----------------------");

            Console.WriteLine("--Display sum clothe cost--");
            var sumClothe = myClothes.Sum(p => p.ClotheCost);
            Console.WriteLine("{0} euro", sumClothe);
            Console.WriteLine("----------------------");

            Console.WriteLine("--Find my clothe--");
            var Find_Lacoste = from clothe in myClothes
                               where clothe.Brand == "Lacoste"
                               && clothe.Color == ClotheColor.Yellow
                               select clothe;

            foreach (var clothe in Find_Lacoste)
            {
                Console.WriteLine("{0} - {1} - {2} - {3} euro - {4}", clothe.Brand, clothe.Composition, clothe.Color, clothe.ClotheCost, clothe.Year);
            }
                        
            Console.ReadLine();
        }
    
    }


    class Clothe
    {
        public string Brand { get; set; }
        public ClotheComposition Composition { get; set; }
        public int Year { get; set; }
        public double ClotheCost { get; set; }
        public ClotheColor Color { get; set; }
    }

    enum ClotheComposition
    {
        PES,
        CV,
        CO,
        PAN
    }
    enum ClotheColor
    {
        White,
        Black,
        Red,
        Blue,
        Yellow
    }
}
