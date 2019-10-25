using System;

namespace BattleShip
{
    public class SupportingShip : BaseShip, IRepairable
    {
        public SupportingShip(int length, int range, int speed, Direction direction)
        {
            Length = length;
            Range = range;
            Speed = speed;
            Direction = direction;
        }

        internal override ShipType ShipType { get => ShipType.SupportingShip; }

        public void Repair(int x, int y)
        {
            int distance = Convert.ToInt32(Math.Sqrt(x * x + y * y));
            int toolX;
            int toolY;

            if (Range > distance)
            {
                toolX = x;
                toolY = y;
            }
        }
        public void GetMove()
        {
            Move();
        }
        public void GetState()
        {
            State();
        }
    }
}
