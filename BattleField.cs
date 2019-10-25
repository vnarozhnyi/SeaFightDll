using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShip
{
    enum Quadrant { First, Second, Third, Fourth}
    public class BattleField
    {
        public List<BaseShip> Ships = new List<BaseShip>();
        public int X, Y, quadrant;
        public int[,] Map;
        public int[, ,] GetParams;

        public void InitMap(int x, int y)
        {
            Map = new int[X = x, Y = y];
            Create();
        }

        private void Create()
        {
                for (int i = 0; i < X; i++)
                    for (int j = 0; j < Y; j++)
                        Map[i, j] = 0;
        }

        public void AddShip(int x, int y, BaseShip ship)
        {
            if ( x < X && y < Y)
            {
                if (x > 0 && y > 0)
                {
                    quadrant = (int)Quadrant.First;
                }
                else if (x < 0 && y > 0)
                {
                    quadrant = (int)Quadrant.Second;
                }
                else if (x < 0 && y < 0)
                {
                    quadrant = (int)Quadrant.Third;
                }
                else
                {
                    quadrant = (int)Quadrant.Fourth;
                }

                Map[X = x,Y = y] = 1;

                if (Map[X, Y] != 0)
                {
                    Ships.Add(ship);
                }
            }
        }
        
        public int this[int x, int y, int quadrant] 
        {
            get => GetParams[x, y, quadrant]; 
            set => GetParams[x, y, quadrant] = value; 
        }

        public string GetState()
        {
            return string.Join(", ", Ships.OrderByDescending(ship => Map[X, 0] * Map[X, 0] + Map[0, Y] * Map[0, Y]).Reverse().ToList());
        }
    }
}
