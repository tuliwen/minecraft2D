using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class touchTilemap : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile baseTile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //销毁墙体
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 wordPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3Int cellPosition = tilemap.WorldToCell(wordPosition);
            //tilemap.SetTile(cellPosition, gameUI.GetSelectColor().colorData.mTile);
            TileBase tb = tilemap.GetTile(cellPosition);
            if (tb == null)
            {
                return;
            }
            //tb.hideFlags = HideFlags.None;
            Debug.Log("鼠标坐标" + mousePosition + "世界" + wordPosition + "cell" + cellPosition + "tb" + tb.name);
            //某个地方设置为空，就是把那个地方小格子销毁了
            // tilemap.SetTile(cellPosition, null);
            //tilemap.RefreshAllTiles();
        }

        //空白地方创造墙体
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 wordPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3Int cellPosition = tilemap.WorldToCell(wordPosition);
            //tilemap.SetTile(cellPosition, gameUI.GetSelectColor().colorData.mTile);
            TileBase tb = tilemap.GetTile(cellPosition);
            if (tb != null)
            {
                return;
            }
            //tb.hideFlags = HideFlags.None;
            //Debug.Log("鼠标坐标" + mousePosition + "世界" + wordPosition + "cell" + cellPosition + "tb" + tb.name);
            //格子填充
            // tilemap.SetTile(cellPosition, baseTile);
            //tilemap.RefreshAllTiles();
        }
    }
}
