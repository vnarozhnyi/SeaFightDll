using System;

namespace BattleShip
{
    public class MainShip : BaseShip, IShootable, IRepairable
    {
        public MainShip(int length, int range, int speed, Direction direction)
        {
            Length = length;
            Range = range;
            Speed = speed;
            Direction = direction;
        }

        internal override ShipType ShipType { get => ShipType.MainShip; }

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

        public void Shoot(int x, int y)
        {
            int distance = Convert.ToInt32(Math.Sqrt(x * x + y * y));
            int shellX;
            int shellY;
            if (Range > distance)
            {
                shellX = x;
                shellY = y;
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
