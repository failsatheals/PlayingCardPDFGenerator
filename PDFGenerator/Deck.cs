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
