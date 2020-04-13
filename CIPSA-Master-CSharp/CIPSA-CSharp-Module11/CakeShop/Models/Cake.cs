using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIPSA_CSharp_Module11.CakeShop.Enums;

namespace CIPSA_CSharp_Module11.CakeShop.Models
{
    public class Cake : CakeCommon
    {
        public SizeEnum Size { get; set; }
        public int NumberCandles { get; set; }
        public string TextToPaint { get; set; }

        public Cake(decimal price, FlavorEnum flavor, SizeEnum size, int numberCandles, string textToPaint)
        {
            Price = price;
            Flavor = flavor;
            Size = size;
            NumberCandles = numberCandles;
            TextToPaint = textToPaint;
        }

        public override string ToString()
        {
            return $"Característica del producto: {GetProductName()}" +
                   $"\n Tamaño: {Size}" +
                   $"\n Número de velas: {NumberCandles}" +
                   $"\n Texto que se debe pintar en el pastel: {TextToPaint} " +
                   "\n" + base.ToString();
        }

        private string GetProductName()
        {
            return "Pastel";
        }
    }
}
