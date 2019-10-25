using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace BattleShip
{
    interface IShootable
    {
        void Shoot(int x, int y);
    }

    interface IRepairable
    {
        void Repair(int x, int y);
    }
}