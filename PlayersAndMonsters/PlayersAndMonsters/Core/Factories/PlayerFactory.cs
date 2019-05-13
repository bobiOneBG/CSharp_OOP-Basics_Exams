namespace PlayersAndMonsters.Core.Factories
{
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using System;
    using System.Linq;
    using System.Reflection;

    public class PlayerFactory : IPlayerFactory
    {
        public IPlayer CreatePlayer(string type, string username)
        {
            try
            {
                var playerType = Assembly
                        .GetCallingAssembly()
                        .GetTypes()
                        .FirstOrDefault(t => t.Name == type);

                var player = (IPlayer)Activator
                    .CreateInstance(playerType, new CardRepository(), username);

                return player;
            }
            catch (Exception)
            {
                return null;
            }            
        }
    }
}
