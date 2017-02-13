using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFGenerator
{
    class Deck 
    {
        public List<Card> Cards { get; set; }

        public int widthCardPixel { get; set; }

        public int heightCardPixel { get; set; }
        public int widthPaperPixel { get; set; }

        public int heightPaperPixel { get; set; }

        public int dpi { get; set; }



        public Deck()
        {

            Cards = new List<Card>();
        }

        public int getDeckQuantity()
        {
            var quantity = 0;
            foreach(var card in this.Cards)
            {

                quantity = +card.quantity;
            }

            return quantity;

        }

    }


}
