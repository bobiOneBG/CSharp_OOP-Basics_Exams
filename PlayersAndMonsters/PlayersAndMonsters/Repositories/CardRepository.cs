namespace PlayersAndMonsters.Repositories
{
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CardRepository : ICardRepository
    {
        private List<ICard> cards;

        public CardRepository()
        {
            this.cards = new List<ICard>();
        }

        public int Count => this.cards.Count;

        public IReadOnlyCollection<ICard> Cards => this.cards.AsReadOnly();

        public void Add(ICard card)
        {
            CardNullCheck(card);

            cards.Add(card);
        }        

        public ICard Find(string name)
        {
            ICard card = cards.FirstOrDefault(c => c.Name == name);

            return card;
        }

        public bool Remove(ICard card)
        {
            CardNullCheck(card);

            return cards.Remove(card);
        }

        private static void CardNullCheck(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
        }
    }
}
