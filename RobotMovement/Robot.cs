using RobotMovement.Models;
using System;

namespace RobotMovement
{
    public class Robot
    {
        public Robot()
        {
            RobotPosition = new RobotPosition();
        }

        public void CaculateMovement(string command)
        {
            var moveEnum = (Command)Enum.Parse(typeof(Command), command, true);

            switch (moveEnum)
            {
                case Command.Move:
                    if (RobotPosition.FacingPosition == Facing.North) RobotPosition.UpdatePosition("0", "1", "north");
                    else if (RobotPosition.FacingPosition == Facing.East) RobotPosition.UpdatePosition("1", "0", "east");
                    else if (RobotPosition.FacingPosition == Facing.South) RobotPosition.UpdatePosition("0", "-1", "south");
                    else if (RobotPosition.FacingPosition == Facing.West) RobotPosition.UpdatePosition("-1", "0", "west");
                    break;
                case Command.Left:
                    if (RobotPosition.FacingPosition == Facing.North) RobotPosition.UpdatePosition("0", "0", "west");
                    else if (RobotPosition.FacingPosition == Facing.East) RobotPosition.UpdatePosition("0", "0", "north");
                    else if (RobotPosition.FacingPosition == Facing.South) RobotPosition.UpdatePosition("0", "0", "east");
                    else if (RobotPosition.FacingPosition == Facing.West) RobotPosition.UpdatePosition("0", "0", "south");
                    break;
                case Command.Right:
                    if (RobotPosition.FacingPosition == Facing.North) RobotPosition.UpdatePosition("0", "0", "east");
                    else if (RobotPosition.FacingPosition == Facing.East) RobotPosition.UpdatePosition("0", "0", "south");
                    else if (RobotPosition.FacingPosition == Facing.South) RobotPosition.UpdatePosition("0", "0", "west");
                    else if (RobotPosition.FacingPosition == Facing.West) RobotPosition.UpdatePosition("0", "0", "north");
                    break;
            }
        }

        public string GetReport()
        {
            return $"OUTPUT: {RobotPosition.Position.Item1}, {RobotPosition.Position.Item2}, {RobotPosition.FacingPosition}";
        }

        public RobotPosition RobotPosition { get; private set; }

    }
}
 