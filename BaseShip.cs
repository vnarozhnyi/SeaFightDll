using System;

namespace BattleShip
{
    enum ShipType { BattleShip, SupportingShip, MainShip }
    public enum Direction { Up, Down, Left, Right }

    interface IMovable
    {
        void Move();
    }
    public abstract class BaseShip : IComparable<BaseShip>, IMovable
    {
        private int speed;
        private int length;
        private int range;

        BattleField field = new BattleField();

        public int Length { get => length; set => length = value; }
        public int Range { get => range; set => range = value; }
        public int Speed { get => speed; set => speed = value; }

        internal abstract ShipType ShipType { get; }

        public Direction Direction;
        public void Move()
        {
            switch (Direction)
            {
                case Direction.Up:
                    for (int i = 0; i < (Speed + 1); i++)
                    { field.Map[0, i] += Speed; };
                    break;
                case Direction.Down:
                    for (int i = 0; i < (Speed + 1); i++)
                    { field.Map[0, i] += Speed; };
                    break;
                case Direction.Left:
                    for (int i = 0; i < (Speed + 1); i++)
                    { field.Map[i, 0] += Speed; };
                    break;
                case Direction.Right:
                    for (int i = 0; i < (Speed + 1); i++)
                    { field.Map[i, 0] += Speed; };
                    break;
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
}
