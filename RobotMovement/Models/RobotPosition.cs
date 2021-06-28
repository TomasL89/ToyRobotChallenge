using System;

namespace RobotMovement.Models
{
    public class RobotPosition
    {
        private Tuple<int, int> tableTopLimit = new Tuple<int, int>(5, 5);

        public RobotPosition()
        {
            Position = new Tuple<int, int>(0,0);
            FacingPosition = Facing.North;
        }

        public void UpdatePosition(string x, string y, string facing)
        {
            var facingEnum = (Facing)Enum.Parse(typeof(Facing), facing, true);
            var xCoord = int.Parse(x);
            var yCoord = int.Parse(y);

            var newXCoord = Position.Item1 + xCoord;
            var newYCoord = Position.Item2 + yCoord;

            if (newXCoord > tableTopLimit.Item1 || newYCoord > tableTopLimit.Item2 || newXCoord < 0 || newYCoord < 0)
            {
                IsOffTable = true;
                Position = new Tuple<int, int>(0, 0);
                Console.WriteLine("Error, robot has fallen off");
                return;
            } 

            IsOffTable = false;
            Position = new Tuple<int, int>(newXCoord, newYCoord);
            FacingPosition = facingEnum;
        }

        public Tuple<int, int> Position { get; private set; }
        public Facing FacingPosition { get; private set; }
        public bool IsOffTable { get; private set; }
    }
}
