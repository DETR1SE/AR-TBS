using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.Tilemaps;
using Vector3 = UnityEngine.Vector3;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance { set; get; }
    private bool[,] allowedMoves { set; get; }

    public Units[,] Unit { set; get; }
    private Units selectedUnit;

    private const float Tile_size = 1f;
    private const float Tile_offset = 0.5f;

    private int selectionX = -1;
    private int selectionY = -1;

    public List<GameObject> units;
    private List<GameObject> activeUnits;

    public bool isPlayerTurn = true;

    private void Start()
    {
        Instance = this;
        SpawnStartUnits();
    }

    private void Update()
    {
        UpdateSelection();
        DrawBoard();

        if(Input.GetMouseButtonDown(0))
        {
            if(selectionX >= 0 && selectionY >= 0)
            {
                if(selectedUnit == null)
                {
                    SelectUnit(selectionX,selectionY);
                }
                else
                {
                    MoveUnit(selectionX, selectionY);
                }
            }
        }
    }

    private void SelectUnit(int x, int y)
    {
        if (Unit[x, y] == null)
            return;

        if (Unit[x, y].isUSSR != isPlayerTurn)
            return;

        allowedMoves = Unit[x, y].PossibleMove();
        selectedUnit = Unit[x, y];
        BoardHighlights.Instance.HighlightAllowedMoves(allowedMoves);
    }

    private void MoveUnit(int x, int y)
    {
        if (allowedMoves[x,y])
        {
            Units c = Unit[x, y];
            
            if(c != null && c.isUSSR != isPlayerTurn)
            {
                if(c.GetType() == typeof(Tank))
                {
                    return;
                }
                activeUnits.Remove(c.gameObject);
                Destroy (c.gameObject);
            }

            Unit[selectedUnit.CurrentX, selectedUnit.CurrentY] = null;
            selectedUnit.transform.position = GetTileCenter(x, y);
            selectedUnit.SetPosition(x, y);
            Unit[x, y] = selectedUnit;
            isPlayerTurn = !isPlayerTurn;
        }

        BoardHighlights.Instance.HideHighlights();
        selectedUnit = null;
    }

    private void UpdateSelection()
    {
        if (!Camera.main)
            return;

        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit, 50.0f, LayerMask.GetMask("Plane")))
        {
            selectionX = (int)hit.point.x;
            selectionY = (int)hit.point.z;
        }
        else
        {
            selectionX = -1;
            selectionY = -1;
        }
    }

    private void SpawnUnits(int index, int x, int y)
    {
        GameObject go = Instantiate(units[index], GetTileCenter(x,y), UnityEngine.Quaternion.identity) as GameObject;
        go.transform.SetParent(transform);
        Unit [x, y] = go.GetComponent<Units>();
        Unit [x, y].SetPosition(x, y);
        activeUnits.Add(go);
    }

    private void SpawnStartUnits()
    {
        activeUnits = new List<GameObject>();
        Unit = new Units[20, 20];

        //Spawn player#1 team
        SpawnUnits(0, 0, 1);
        SpawnUnits(0, 1, 1);
        SpawnUnits(0, 1, 0);
        SpawnUnits(1, 0, 0);

        //Spawn player#2 team
        SpawnUnits(2, 18, 19);
        SpawnUnits(2, 18, 18);
        SpawnUnits(2, 19, 18);
        SpawnUnits(3, 19, 19);
    }

    private Vector3 GetTileCenter(int x, int y)
    {
        Vector3 origin = Vector3.zero;
        origin.x += (Tile_size * x) + Tile_offset;
        origin.z += (Tile_size * y) + Tile_offset;
        return origin;
    }

    // Отрисовка поля

    private void DrawBoard()
    {
        Vector3 widthLine = Vector3.right * 20;
        Vector3 heightLine = Vector3.forward * 20;

        for (int i = 0; i <= 20; i++)
        {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine(start, start + widthLine);
            for (int j = 0; j <= 20; j++)
            {
                start = Vector3.right * j;
                Debug.DrawLine(start, start + heightLine);
            }
        }

        //Отрисовка выбранного поля

        if (selectionX >= 0 && selectionY >= 0)
        {
            Debug.DrawLine(
                Vector3.forward * selectionY + Vector3.right * selectionX,
                Vector3.forward * (selectionY + 1) + Vector3.right * (selectionX + 1));

            Debug.DrawLine(
                Vector3.forward * (selectionY + 1) + Vector3.right * selectionX,
                Vector3.forward * selectionY + Vector3.right * (selectionX + 1));
        }
    }
}
