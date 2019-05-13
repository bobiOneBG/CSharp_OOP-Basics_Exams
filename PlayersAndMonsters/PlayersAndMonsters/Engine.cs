namespace PlayersAndMonsters
{
    
    using PlayersAndMonsters.Core.Contracts;
    using PlayersAndMonsters.IO.Contracts;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private IManagerController managerController;
        private IReader reader;
        private IWriter writer;

        public Engine(IManagerController managerController, IReader reader, IWriter writer)
        {
            this.managerController = managerController;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            string command = String.Empty;
            while ((command = this.reader.ReadLine()) != "Exit")
            {
                try
                {
                    this.ReadCommand(command);
                }
                catch (ArgumentException e)
                {
                    this.writer.WriteLine(e.Message);
                }
            }
        }

        private void ReadCommand(string command)
        {
            var tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var output = String.Empty;
            var arguments = tokens.Skip(1).ToArray();

            switch (tokens[0])
            {
                case "AddPlayer":
                    var playerType = arguments[0];
                    var username = arguments[1];
                    output = this.managerController.AddPlayer(playerType, username);
                    break;
                case "AddCard":
                    var cardType = arguments[0];
                    var name = arguments[1];
                    output = this.managerController.AddCard(cardType, name);
                    break;
                case "AddPlayerCard":
                    string playerName = arguments[0];
                    string cardName = arguments[1];
                    output = this.managerController.AddPlayerCard(playerName, cardName);
                    break;
                case "Fight":
                    string attackUser = arguments[0];
                    string enemyUser = arguments[1];
                    output = this.managerController.Fight(attackUser, enemyUser);
                    break;
                case "Report":
                    output = this.managerController.Report();
                    break;
            }

            if (output != string.Empty)
            {
                this.writer.WriteLine(output);
            }
        }
    }
}
