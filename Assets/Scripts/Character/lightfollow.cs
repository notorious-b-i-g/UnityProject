using UnityEngine;

public class LightFollow : MonoBehaviour
{
    public Transform player; // Переменная для хранения ссылки на трансформ игрока
    public Vector3 offset;   // Смещение света относительно игрока

    // Вызывается на каждый кадр
    void Update()
    {
        // Проверяем, задан ли игрок
        if (player != null)
        {
            // Перемещаем свет в позицию игрока с учетом смещения
            transform.position = player.position + offset;
        }
    }
}
