using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;

namespace BattleShip
{
    enum ShipType { BattleShip, SupportingShip, MainShip}
    interface IMovable
    {
        void Move(int x, int y);
    }

    interface IShootable
    {
        void Shoot(int x, int y);
    }

    interface IRepairable
    {
        void Repair(int x, int y);
    }
    public class Field : IComparable<BaseShip>
    {
        public static List<BaseShip> Ships = new List<BaseShip>();
        BaseShip ship;
        public static int sX, sY;
        public static void MapSize(int x, int y)
        {
            sX = x;
            sY = y;
        }

        public int[,] map = new int[sX, sY];

        public void Create()
        {
            for (int i = 0; i < sX; i++)
                for (int j = 0; j < sY; j++)
                    map[i,j] = 0;
        }
        public static void AddShip(int x, int y, BaseShip ship)
        {
            ship.PositionX = x;
            ship.PositionY = y;
            Ships.Add(ship);
        }

        public int this[int x, int y] { get => map[x, y]; set => map[x, y] = value; }

        public string State()
        {
            return Convert.ToString(Ships.OrderByDescending(x => x.PositionX).ThenBy(x => ship.PositionY));
        }
      
        public int CompareTo(BaseShip other)
        {
            if (other.Length == ship.Length && other.Speed == ship.Speed && other.ShipType == ship.ShipType)
            {
                return 1;
            }
            else return 0;
        }
    }

    public abstract class BaseShip
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
        internal abstract ShipType ShipType { get; set; }

        public abstract string State();
    }

    public class BattleShip : BaseShip, IMovable, IShootable
    {
        Timer timer = new Timer(); 
       public BattleShip(int length, int range, int speed)
        {
            Length = length;
            Range = range;
            Speed = speed;
        }

        internal override ShipType ShipType { get => ShipType; set => ShipType = ShipType.BattleShip; }

        public void Move(int x, int y)
        {
            timer.Interval = Speed * 1000;
            PositionX += x;
            PositionY += y;
        }

        public void Shoot(int x, int y)
        {
            int shellX = PositionX; int shellY = PositionY;
            int distance = Convert.ToInt32(Math.Sqrt(x*x+y*y));
            if (Range > distance)
            {
                shellX = x;
                shellY = y;
            }
        }

        public override string State()
        {
            return $"Length {Length.ToString()} Range {Range.ToString()} Speed {Speed.ToString()}";
        }
    }

    public class SupportingShip : BaseShip, IMovable, IRepairable
    {
        Timer timer = new Timer();
        public SupportingShip(int length, int range, int speed)
        {
            Length = length;
            Range = range;
            Speed = speed;
        }

        internal override ShipType ShipType { get => ShipType; set => ShipType = ShipType.SupportingShip; }

        public void Move(int x, int y)
        {
            timer.Interval = Speed * 1000;
            PositionX += x;
            PositionY += y;
        }

        public void Repair(int x, int y)
        {
            int toolsX = PositionX; int toolsY = PositionY;
            int distance = Convert.ToInt32(Math.Sqrt(x * x + y * y));
            if (Range > distance)
            {
                toolsX = x;
                toolsY = y;
            }
        }

        public override string State()
        {
            return $"Length {Length.ToString()} Range {Range.ToString()} Speed {Speed.ToString()}";
        }
    }

    public class MainShip : BaseShip, IMovable, IShootable, IRepairable
    {
        Timer timer = new Timer();
        
        public MainShip(int length, int range, int speed)
        {
            Length = length;
            Range = range;
            Speed = speed;
        }

        internal override ShipType ShipType { get => ShipType; set => ShipType = ShipType.MainShip; }

        public void Move(int x, int y)
        {
            timer.Interval = Speed * 1000;
            PositionX += x;
            PositionY += y;
        }

        public void Repair(int x, int y)
        {
            int toolsX = PositionX; int toolsY = PositionY;
            int distance = Convert.ToInt32(Math.Sqrt(x * x + y * y));
            if (Range > distance)
            {
                toolsX = x;
                toolsY = y;
            }
        }

        public void Shoot(int x, int y)
        {
            int shellX = PositionX; int shellY = PositionY;
            int distance = Convert.ToInt32(Math.Sqrt(x * x + y * y));
            if (Range > distance)
            {
                shellX = x;
                shellY = y;
            }
        }

        public override string State()
        {
            return $"Length {Length.ToString()} Range {Range.ToString()} Speed {Speed.ToString()}";
        }
    }
}