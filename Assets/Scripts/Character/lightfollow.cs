using UnityEngine;

public class LightFollow : MonoBehaviour
{
    public Transform player; // ���������� ��� �������� ������ �� ��������� ������
    public Vector3 offset;   // �������� ����� ������������ ������

    // ���������� �� ������ ����
    void Update()
    {
        // ���������, ����� �� �����
        if (player != null)
        {
            // ���������� ���� � ������� ������ � ������ ��������
            transform.position = player.position + offset;
        }
    }
}
