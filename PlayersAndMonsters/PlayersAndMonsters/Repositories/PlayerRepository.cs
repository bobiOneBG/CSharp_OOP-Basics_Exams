namespace PlayersAndMonsters.Repositories
{
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> players;


        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }


        public int Count => this.players.Count;

        public IReadOnlyCollection<IPlayer> Players => this.players.AsReadOnly();


        public void Add(IPlayer player)
        {
            this.NullCheckPlayer(player);

            if (this.Players.Any(p => p.Username == player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }

            this.players.Add(player);
        }

        public IPlayer Find(string username)
        {
            IPlayer player = this.players.FirstOrDefault(p => p.Username == username);

            return player;
        }

        public bool Remove(IPlayer player)
        {
            this.NullCheckPlayer(player);

            return this.players.Remove(player);
        }

        private void NullCheckPlayer(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
        }
    }
}
