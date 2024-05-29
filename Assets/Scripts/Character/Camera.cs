using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ÷ель, за которой следует камера (обычно ваш персонаж)
    public float smoothing = 5f; // —корость с которой камера будет следовать за персонажем

    Vector3 offset; // Ќачальное смещение между камерой и персонажем

    void Start()
    {
        // ¬ычисл€ем начальное смещение между камерой и целью
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // ÷елева€ позици€ камеры
        Vector3 targetCamPos = target.position + offset;
        // ѕлавно перемещаем камеру к целевой позиции
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
