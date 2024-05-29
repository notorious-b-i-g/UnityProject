using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class TileInteraction : MonoBehaviour
{
    public Tilemap tilemap; // ������ �� �������� �����
    // ��������������, ��� oldTile1, newTile1 � �.�. - ��� ���������� �����, ������� �� �������� ����� ��������� Unity
    public TileBase oldTile1; // ������ ����, ������� ����� �������
    public TileBase newTile1; // ����� ����, �� ������� ����� ������� oldTile1
    public TileBase oldTile2;
    public TileBase newTile2;
    public TileBase oldTile3; // ������ ����, ������� ����� �������
    public TileBase newTile3; // ����� ����, �� ������� ����� ������� oldTile1
    public TileBase oldTile4;
    public TileBase newTile4;
    // ��� ������������� �������� �������������� ����� ��� ������

    private Dictionary<TileBase, TileBase> tileReplacements; // ������� ��� �������� ��� ���������� ������

    void Start()
    {
        // ������������� ������� ������������� ������ ��� ������
        tileReplacements = new Dictionary<TileBase, TileBase>
        {
            { oldTile1, newTile1 },
            { oldTile2, newTile2 },
            { oldTile3, newTile3 },
            { oldTile4, newTile4 }
            // �������� ������ ���� ������ ����
        };
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �������� �� ������������ � �������� ������
        if (collision.collider.GetComponent<TilemapCollider2D>())
        {
            // ��������� ����� ������������
            foreach (ContactPoint2D hit in collision.contacts)
            {
                Vector3 hitPosition = hit.point - (Vector2)(0.01f * hit.normal);
                ChangeSurroundingTiles(hitPosition);
            }
        }
    }

    void ChangeSurroundingTiles(Vector3 worldPosition)
    {
        Vector3Int originCell = tilemap.WorldToCell(worldPosition);

        // ������� � ������ ������ ������ ����� ������������
        CheckAndReplaceTile(originCell); // ��������� ����������� ����
        // ��������� � �������� �������� �����
        CheckAndReplaceTile(originCell + new Vector3Int(0, 1, 0)); // ������
        CheckAndReplaceTile(originCell + new Vector3Int(1, 0, 0)); // ������
        CheckAndReplaceTile(originCell + new Vector3Int(0, -1, 0)); // �����
        CheckAndReplaceTile(originCell + new Vector3Int(-1, 0, 0)); // �����
        CheckAndReplaceTile(originCell + new Vector3Int(1, 1, 0)); // ������
        CheckAndReplaceTile(originCell + new Vector3Int(-1, 1, 0)); // ������
        CheckAndReplaceTile(originCell + new Vector3Int(1, -1, 0)); // �����
        CheckAndReplaceTile(originCell + new Vector3Int(-1, -1, 0)); // �����
        // �������� ������ ����������� ��� �������������
    }

    void CheckAndReplaceTile(Vector3Int tilePosition)
    {
        TileBase currentTile = tilemap.GetTile(tilePosition);
        // �������� ������� �������� ����� � ������� ��� ������
        if (currentTile != null && tileReplacements.ContainsKey(currentTile))
        {
            TileBase newTile = tileReplacements[currentTile];
            tilemap.SetTile(tilePosition, newTile); // ������ �����
            // �����������: ���������� ���������� � ����������� �����
            //tilemap.SetColliderType(tilePosition, Tile.ColliderType.None);
            

        }
    }
}
