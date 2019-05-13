namespace PlayersAndMonsters.Models.BattleFields
{
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using System;
    using System.Linq;

    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }

            BeginnersBonus(attackPlayer);
            BeginnersBonus(enemyPlayer);

            GetBonusHealth(attackPlayer);
            GetBonusHealth(enemyPlayer);

            while (!attackPlayer.IsDead && !enemyPlayer.IsDead)
            {
                enemyPlayer.TakeDamage(attackPlayer.CardRepository.Cards.Sum(c => c.DamagePoints));

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyPlayer.CardRepository.Cards.Sum(c => c.DamagePoints));
            }
        }

        private void GetBonusHealth(IPlayer player)
        {
            int playerBonusHealth = player.CardRepository.Cards.Sum(c => c.HealthPoints);
            player.Health += playerBonusHealth;
        }

        private void BeginnersBonus(IPlayer player)
        {
            if (player.GetType().Name == "Beginner")
            {
                player.Health += 40;

                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }
    }
}
