using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Tank : Units
{
    public override bool[,] PossibleMove()
    {
        bool[,] r = new bool[20, 20];

        TankDirection(CurrentX + 1, CurrentY, ref r); // up
        TankDirection(CurrentX - 1, CurrentY, ref r); // down
        TankDirection(CurrentX, CurrentY - 1, ref r); // left
        TankDirection(CurrentX, CurrentY + 1, ref r); // right
        TankDirection(CurrentX + 1, CurrentY - 1, ref r); // up left
        TankDirection(CurrentX - 1, CurrentY - 1, ref r); // down left
        TankDirection(CurrentX + 1, CurrentY + 1, ref r); // up right
        TankDirection(CurrentX - 1, CurrentY + 1, ref r); // down right

        TankDirection(CurrentX + 2, CurrentY, ref r); // up
        TankDirection(CurrentX - 2, CurrentY, ref r); // down
        TankDirection(CurrentX, CurrentY - 2, ref r); // left
        TankDirection(CurrentX, CurrentY + 2, ref r); // right
        TankDirection(CurrentX + 2, CurrentY - 2, ref r); // up left
        TankDirection(CurrentX - 2, CurrentY - 2, ref r); // down left
        TankDirection(CurrentX + 2, CurrentY + 2, ref r); // up right
        TankDirection(CurrentX - 2, CurrentY + 2, ref r); // down right

        return r;
    }

    public void TankDirection(int x, int y, ref bool[,] r)
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
