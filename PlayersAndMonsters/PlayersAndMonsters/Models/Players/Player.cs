﻿namespace PlayersAndMonsters.Models.Players
{
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories.Contracts;
    using System;

    public abstract class Player : IPlayer
    {
        private string username;
        private int health;

        protected Player(ICardRepository cardRepository, string username, int health)
        {
            this.CardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }

        public ICardRepository CardRepository { get; private set; }
        
        public string Username
        {
            get { return this.username; }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException
                        ("Player's username cannot be null or an empty string. ");
                }
                this.username = value;
            }
        }//      OK
        
        public int Health
        {
            get { return this.health; }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException
                        ("Player's health bonus cannot be less than zero. ");
                }
                this.health = value;
            }
        }//      OK

        public bool IsDead => this.Health==0;//    OK

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints<0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }

            this.Health = Math.Max(0, this.Health - damagePoints);
        }     
    }
}
