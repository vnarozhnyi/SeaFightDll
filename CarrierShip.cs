using System;

namespace BattleShip
{
    public class CarrierShip : BaseShip, IShootable
    {
        public CarrierShip(int length, int range, int speed, Direction direction)
        {
            Length = length;
            Range = range;
            Speed = speed;
            Direction = direction;
        }

        internal override ShipType ShipType { get => ShipType.BattleShip; }

        public void Shoot(int x, int y)
        {
            int shellX;
            int shellY;
            int distance = Convert.ToInt32(Math.Sqrt(x * x + y * y));

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
