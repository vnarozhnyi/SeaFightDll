using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace BattleShip
{
    enum ShipType { BattleShip, SupportingShip, MainShip }
    public enum Direction { Up, Down, Left, Right }

    interface IMovable
    {
        void Move();
    }

    interface IShootable
    {
        void Shoot(int x, int y);
    }

    interface IRepairable
    {
        void Repair(int x, int y);
    }

    public class BatteField
    {
        public List<BaseShip> Ships = new List<BaseShip>();
        public int X, Y;
        public int[,] Map;

        public void InitMap(int x, int y)
        {
            Map = new int[X = x, Y = y];
            Create();
        }

        private void Create()
        {
            if (X > 0 && Y > 0)
            {
                for (int i = 0; i < X; i++)
                    for (int j = 0; j < Y; j++)
                        Map[i, j] = 0;
            }
        }

        public void AddShip(int x, int y, BaseShip ship)
        { 
            ship.PositionX = x;
            ship.PositionY = y;
           if(Ships.All(ships => ships.PositionX != x && ships.PositionY != y))
            {
                Ships.Add(ship);
            }
        }

        public int this[int x, int y] { get => Map[x, y]; set => Map[x, y] = value; }

        public string GetState()
        {
            return string.Join(", ", Ships.OrderByDescending(ship => ship.PositionX * ship.PositionX + ship.PositionY * ship.PositionY).Reverse().ToList());
        }
    }

    public abstract class BaseShip : IComparable<BaseShip>, IMovable
    {
        private int speed;
        private int length;
        private int range;
        private int positionX;
        private int positionY;

        public int Length { get => length; set => length = value; }
        public int Range { get => range; set => range = value; }
        public int Speed { get => speed; set => speed = value; }
        public int PositionX { get => positionX; set => positionX = value; }
        public int PositionY { get => positionY; set => positionY = value; }
        internal abstract ShipType ShipType { get; }

        public Direction Direction;
        public void Move()
        {
            switch (Direction)
            {
                case Direction.Up: PositionY += Speed; break;
                case Direction.Down: PositionY -= Speed; break;
                case Direction.Left: PositionX += Speed; break;
                case Direction.Right: PositionX -= Speed; break;
            }
        }
        public int CompareTo(BaseShip other)
        {
            return other.Length == Length && other.Speed == Speed && other.ShipType == ShipType ? 1 : 0;
        }

        public string State()
        {
            return $"Length {Length.ToString()} Range {Range.ToString()} Speed {Speed.ToString()} Type {ShipType.ToString()}";
        }
    }

    public class CarrierShip : BaseShip, IShootable
    {
        Timer timer = new Timer();
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
            int shellX = PositionX;
            int shellY = PositionY;
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
            int toolX = PositionX;
            int toolY = PositionY;

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
        int toolX = PositionX;
        int toolY = PositionY;

        if (Range > distance)
        {
            toolX = x;
            toolY = y;
        }
    }

    public void Shoot(int x, int y)
    {
        int distance = Convert.ToInt32(Math.Sqrt(x * x + y * y));
        int shellX = PositionX;
        int shellY = PositionY;
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