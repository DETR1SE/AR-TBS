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
        /*        //Top Side

                i = CurrentX - 1;
                j = CurrentY + 1;
                if(CurrentY !=19)
                {
                    for(int k = 0; k < 3; k++)
                    {
                        if(i >=1 || i < 20)
                        {
                            c = BoardManager.Instance.Unit[i, j];
                            if (c = null)
                                r[i, j] = true;
                           else if (isPlayer != c.isPlayer)
                                r[i, j] = true;
                        }
                        i++;
                    }
                }

                //Down Side

                i = CurrentX - 1;
                j = CurrentY - 1;
                if (CurrentY != 0)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (i >= 0 || i < 20)
                        {
                            c = BoardManager.Instance.Unit[i, j];
                            if (c = null)
                                r[i, j] = true;
                            else if (isPlayer != c.isPlayer)
                                r[i, j] = true;
                        }
                        i++;
                    }
                }

                //Middle Left
                if (CurrentX !=0)
                {
                    c = BoardManager.Instance.Unit[CurrentX - 1, CurrentY];
                    if (c == null)
                        r [CurrentX - 1, CurrentY] = true;
                    else if (isPlayer != c.isPlayer)
                        r[CurrentX - 1, CurrentY] = true;
                }

                //Middle Right
                if (CurrentX != 19)
                {
                    c = BoardManager.Instance.Unit[CurrentX + 1, CurrentY];
                    if (c == null)
                        r[CurrentX + 1, CurrentY] = true;
                    else if (isPlayer != c.isPlayer)
                        r[CurrentX + 1, CurrentY] = true;
                }*/






        /*if (CurrentY == 0)
        {
            c = BoardManager.Instance.Unit[CurrentX, CurrentY + 1];
            c2 = BoardManager.Instance.Unit[CurrentX - 1, CurrentY];
            c3 = BoardManager.Instance.Unit[CurrentX - 1, CurrentY + 1];
            c5 = BoardManager.Instance.Unit[CurrentX + 1, CurrentY];
            c6 = BoardManager.Instance.Unit[CurrentX + 1, CurrentY + 1];


            if (c == null)
            {
                r[CurrentX, CurrentY + 1] = true;
            }
            if (c2 == null)
            {
                r[CurrentX - 1, CurrentY] = true;
            }
            if (c3 == null)
            {
                r[CurrentX + -1, CurrentY + 1] = true;
            }

            if (c5 == null)
            {
                r[CurrentX + 1, CurrentY] = true;
            }
            if (c6 == null)
            {
                r[CurrentX + 1, CurrentY + 1] = true;
            }
        }
        if (CurrentY == 19)
        {
            c2 = BoardManager.Instance.Unit[CurrentX - 1, CurrentY];
            c4 = BoardManager.Instance.Unit[CurrentX - 1, CurrentY - 1];
            c5 = BoardManager.Instance.Unit[CurrentX + 1, CurrentY];
            c7 = BoardManager.Instance.Unit[CurrentX + 1, CurrentY - 1];
            c8 = BoardManager.Instance.Unit[CurrentX, CurrentY - 1];


            if (c2 == null)
            {
                r[CurrentX - 1, CurrentY] = true;
            }
            if (c4 == null)
            {
                r[CurrentX + -1, CurrentY - 1] = true;
            }
            if (c5 == null)
            {
                r[CurrentX + 1, CurrentY] = true;
            }
            if (c7 == null)
            {
                r[CurrentX + 1, CurrentY - 1] = true;
            }
            if (c8 == null)
            {
                r[CurrentX, CurrentY - 1] = true;
            }
        }
        if (CurrentX == 0)
        {
            c = BoardManager.Instance.Unit[CurrentX, CurrentY + 1];
            c5 = BoardManager.Instance.Unit[CurrentX + 1, CurrentY];
            c6 = BoardManager.Instance.Unit[CurrentX + 1, CurrentY + 1];
            c7 = BoardManager.Instance.Unit[CurrentX + 1, CurrentY - 1];
            c8 = BoardManager.Instance.Unit[CurrentX, CurrentY - 1];


            if (c == null)
            {
                r[CurrentX, CurrentY + 1] = true;
            }
            if (c5 == null)
            {
                r[CurrentX + 1, CurrentY] = true;
            }
            if (c6 == null)
            {
                r[CurrentX + 1, CurrentY + 1] = true;
            }
            if (c7 == null)
            {
                r[CurrentX + 1, CurrentY - 1] = true;
            }
            if (c8 == null)
            {
                r[CurrentX, CurrentY - 1] = true;
            }
        }
        if (CurrentX == 19)
        {
            c = BoardManager.Instance.Unit[CurrentX, CurrentY + 1];
            c2 = BoardManager.Instance.Unit[CurrentX - 1, CurrentY];
            c3 = BoardManager.Instance.Unit[CurrentX - 1, CurrentY + 1];
            c4 = BoardManager.Instance.Unit[CurrentX - 1, CurrentY - 1];
            c8 = BoardManager.Instance.Unit[CurrentX, CurrentY - 1];


            if (c == null)
            {
                r[CurrentX, CurrentY + 1] = true;
            }
            if (c2 == null)
            {
                r[CurrentX - 1, CurrentY] = true;
            }
            if (c3 == null)
            {
                r[CurrentX + -1, CurrentY + 1] = true;
            }
            if (c4 == null)
            {
                r[CurrentX + -1, CurrentY - 1] = true;
            }
            if (c8 == null)
            {
                r[CurrentX, CurrentY - 1] = true;
            }
        }
        if (CurrentY == 0 & CurrentX == 0)
        {
            c = BoardManager.Instance.Unit[CurrentX, CurrentY + 1];
            c5 = BoardManager.Instance.Unit[CurrentX + 1, CurrentY];
            c6 = BoardManager.Instance.Unit[CurrentX + 1, CurrentY + 1];


            if (c == null)
            {
                r[CurrentX, CurrentY + 1] = true;
            }
            if (c5 == null)
            {
                r[CurrentX + 1, CurrentY] = true;
            }
            if (c6 == null)
            {
                r[CurrentX + 1, CurrentY + 1] = true;
            }
        }
        if (CurrentY == 0 & CurrentX == 19)
        {
            c = BoardManager.Instance.Unit[CurrentX, CurrentY + 1];
            c2 = BoardManager.Instance.Unit[CurrentX - 1, CurrentY];
            c3 = BoardManager.Instance.Unit[CurrentX - 1, CurrentY + 1];


            if (c == null)
            {
                r[CurrentX, CurrentY + 1] = true;
            }
            if (c2 == null)
            {
                r[CurrentX - 1, CurrentY] = true;
            }
            if (c3 == null)
            {
                r[CurrentX + -1, CurrentY + 1] = true;
            }
        }
        if (CurrentY == 19 & CurrentX == 0)
        {
            c5 = BoardManager.Instance.Unit[CurrentX + 1, CurrentY];
            c7 = BoardManager.Instance.Unit[CurrentX + 1, CurrentY - 1];
            c8 = BoardManager.Instance.Unit[CurrentX, CurrentY - 1];

            if (c5 == null)
            {
                r[CurrentX + 1, CurrentY] = true;
            }
            if (c7 == null)
            {
                r[CurrentX + 1, CurrentY - 1] = true;
            }
            if (c8 == null)
            {
                r[CurrentX, CurrentY - 1] = true;
            }
        }
        if (CurrentY == 19 & CurrentX == 19)
        {
            c2 = BoardManager.Instance.Unit[CurrentX - 1, CurrentY];
            c4 = BoardManager.Instance.Unit[CurrentX - 1, CurrentY - 1];
            c8 = BoardManager.Instance.Unit[CurrentX, CurrentY - 1];


            if (c2 == null)
            {
                r[CurrentX - 1, CurrentY] = true;
            }
            if (c4 == null)
            {
                r[CurrentX + -1, CurrentY - 1] = true;
            }
            if (c8 == null)
            {
                r[CurrentX, CurrentY - 1] = true;
            }
        }
        if (CurrentX != 19 & CurrentX != 0 & CurrentY != 19 & CurrentY != 0) {
            c = BoardManager.Instance.Unit[CurrentX, CurrentY + 1];
            c2 = BoardManager.Instance.Unit[CurrentX - 1, CurrentY];
            c3 = BoardManager.Instance.Unit[CurrentX - 1, CurrentY + 1];
            c4 = BoardManager.Instance.Unit[CurrentX - 1, CurrentY - 1];
            c5 = BoardManager.Instance.Unit[CurrentX + 1, CurrentY];
            c6 = BoardManager.Instance.Unit[CurrentX + 1, CurrentY + 1];
            c7 = BoardManager.Instance.Unit[CurrentX + 1, CurrentY - 1];
            c8 = BoardManager.Instance.Unit[CurrentX, CurrentY - 1];


            if (c == null)
            {
                r[CurrentX, CurrentY + 1] = true;
            }
            if (c2 == null)
            {
                r[CurrentX - 1, CurrentY] = true;
            }
            if (c3 == null)
            {
                r[CurrentX + -1, CurrentY + 1] = true;
            }
            if (c4 == null)
            {
                r[CurrentX + -1, CurrentY - 1] = true;
            }
            if (c5 == null)
            {
                r[CurrentX + 1, CurrentY] = true;
            }
            if (c6 == null)
            {
                r[CurrentX + 1, CurrentY + 1] = true;
            }
            if (c7 == null)
            {
                r[CurrentX + 1, CurrentY - 1] = true;
            }
            if (c8 == null)
            {
                r[CurrentX, CurrentY - 1] = true;
            }
        }*/
}
