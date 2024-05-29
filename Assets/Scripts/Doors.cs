using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class TileInteraction : MonoBehaviour
{
    public Tilemap tilemap; // Ссылка на тайловую карту
    // Предполагается, что oldTile1, newTile1 и т.д. - это конкретные тайлы, которые вы добавите через инспектор Unity
    public TileBase oldTile1; // Старый тайл, который будет заменен
    public TileBase newTile1; // Новый тайл, на который будет заменен oldTile1
    public TileBase oldTile2;
    public TileBase newTile2;
    public TileBase oldTile3; // Старый тайл, который будет заменен
    public TileBase newTile3; // Новый тайл, на который будет заменен oldTile1
    public TileBase oldTile4;
    public TileBase newTile4;
    // При необходимости добавьте дополнительные тайлы для замены

    private Dictionary<TileBase, TileBase> tileReplacements; // Словарь для хранения пар заменяемых тайлов

    void Start()
    {
        // Инициализация словаря сопоставлений тайлов для замены
        tileReplacements = new Dictionary<TileBase, TileBase>
        {
            { oldTile1, newTile1 },
            { oldTile2, newTile2 },
            { oldTile3, newTile3 },
            { oldTile4, newTile4 }
            // Добавьте другие пары тайлов сюда
        };
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Проверка на столкновение с тайловой картой
        if (collision.collider.GetComponent<TilemapCollider2D>())
        {
            // Обработка точек столкновения
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

        // Перебор и замена тайлов вокруг точки столкновения
        CheckAndReplaceTile(originCell); // Проверяем центральный тайл
        // Проверяем и заменяем соседние тайлы
        CheckAndReplaceTile(originCell + new Vector3Int(0, 1, 0)); // сверху
        CheckAndReplaceTile(originCell + new Vector3Int(1, 0, 0)); // справа
        CheckAndReplaceTile(originCell + new Vector3Int(0, -1, 0)); // снизу
        CheckAndReplaceTile(originCell + new Vector3Int(-1, 0, 0)); // слева
        CheckAndReplaceTile(originCell + new Vector3Int(1, 1, 0)); // сверху
        CheckAndReplaceTile(originCell + new Vector3Int(-1, 1, 0)); // сверху
        CheckAndReplaceTile(originCell + new Vector3Int(1, -1, 0)); // снизу
        CheckAndReplaceTile(originCell + new Vector3Int(-1, -1, 0)); // снизу
        // Добавьте другие направления при необходимости
    }

    void CheckAndReplaceTile(Vector3Int tilePosition)
    {
        TileBase currentTile = tilemap.GetTile(tilePosition);
        // Проверка наличия текущего тайла в словаре для замены
        if (currentTile != null && tileReplacements.ContainsKey(currentTile))
        {
            TileBase newTile = tileReplacements[currentTile];
            tilemap.SetTile(tilePosition, newTile); // Замена тайла
            // Опционально: отключение коллайдера у замененного тайла
            //tilemap.SetColliderType(tilePosition, Tile.ColliderType.None);
            

        }
    }
}
