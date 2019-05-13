namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using IO;
    using IO.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();

            IManagerController managerController = new ManagerController();

            IEngine engine = new Engine(managerController, reader, writer);

            engine.Run();
        }
    }
}