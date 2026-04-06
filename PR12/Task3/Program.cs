using System;

namespace Task3
{
    public interface ICommand
    {
        void Execute();
    }

    public class RobotVacuum
    {
        public void StartCleaning()
        {
            Console.WriteLine("Робот: начинаю уборку");
        }

        public void StopCleaning()
        {
            Console.WriteLine("Робот: останавливаю уборку");
        }

        public void ReturnToBase()
        {
            Console.WriteLine("Робот: возвращаюсь на базу");
        }
    }

    public class StartCleaningCommand : ICommand
    {
        private readonly RobotVacuum robot;

        public StartCleaningCommand(RobotVacuum robot)
        {
            this.robot = robot;
        }

        public void Execute()
        {
            robot.StartCleaning();
        }
    }

    public class StopCleaningCommand : ICommand
    {
        private readonly RobotVacuum robot;

        public StopCleaningCommand(RobotVacuum robot)
        {
            this.robot = robot;
        }

        public void Execute()
        {
            robot.StopCleaning();
        }
    }

    public class ReturnToBaseCommand : ICommand
    {
        private readonly RobotVacuum robot;

        public ReturnToBaseCommand(RobotVacuum robot)
        {
            this.robot = robot;
        }

        public void Execute()
        {
            robot.ReturnToBase();
        }
    }

    public class RobotController
    {
        private ICommand command;

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void PressButton()
        {
            if (command != null)
                command.Execute();
        }
    }

    class Program
    {
        static void Main()
        {
            RobotVacuum robot = new RobotVacuum();
            RobotController controller = new RobotController();

            ICommand start = new StartCleaningCommand(robot);
            ICommand stop = new StopCleaningCommand(robot);
            ICommand toBase = new ReturnToBaseCommand(robot);

            controller.SetCommand(start);
            controller.PressButton();

            controller.SetCommand(stop);
            controller.PressButton();

            controller.SetCommand(toBase);
            controller.PressButton();
        }
    }
}