using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Soldiers : Units
{
    public override bool[,] PossibleMove()
        {
            bool[,] r = new bool[20, 20];

            SoldierDirection(CurrentX + 1, CurrentY, ref r); // up
            SoldierDirection(CurrentX - 1, CurrentY, ref r); // down
            SoldierDirection(CurrentX, CurrentY - 1, ref r); // left
            SoldierDirection(CurrentX, CurrentY + 1, ref r); // right
            SoldierDirection(CurrentX + 1, CurrentY - 1, ref r); // up left
            SoldierDirection(CurrentX - 1, CurrentY - 1, ref r); // down left
            SoldierDirection(CurrentX + 1, CurrentY + 1, ref r); // up right
            SoldierDirection(CurrentX - 1, CurrentY + 1, ref r); // down right

            return r;
        }

        public void SoldierDirection(int x, int y, ref bool[,] r)
        {
            Units c;
            if (x >= 0 && x < 20 && y >= 0 && y < 20)
            {
                c = BoardManager.Instance.Unit[x, y];
                if (c == null)
                    r[x, y] = true;
                else if (isUSSR != c.isUSSR)
                    r[x, y] = true;
            }
        }
}
