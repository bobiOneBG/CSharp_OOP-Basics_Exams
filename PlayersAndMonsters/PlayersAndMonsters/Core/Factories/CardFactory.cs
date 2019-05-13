namespace PlayersAndMonsters.Core.Factories
{
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            try
            {
                var cardType = Assembly
                        .GetCallingAssembly()
                        .GetTypes()
                        .FirstOrDefault(t => t.Name == type+"Card");

                var card = (ICard)Activator
                    .CreateInstance(cardType, name);

                return card;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
