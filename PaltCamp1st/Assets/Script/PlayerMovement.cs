using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float laneDistance = 50f; // ���� �� x �Ÿ�
    public float forwardSpeed = 10f;
    public float laneChangeSpeed = 25f;

    private int currentLane = 0; // -1 = ����, 0 = ���, 1 = ������

    void Update()
    {
        // ����
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // �Է� ó��
        if (Input.GetKeyDown(KeyCode.A) && currentLane > -1)
        {
            currentLane--;
        }
        else if (Input.GetKeyDown(KeyCode.D) && currentLane < 1)
        {
            currentLane++;
        }

        // �̵� �� ��ġ
        float targetX = currentLane * laneDistance;
        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);

        // �̵� ���� ����
        transform.position = targetPosition;
    }


    private void OnTriggerEnter(Collider other) // ������Ʈ �� ����� �� (�±� Ư�� ����)
    {
        if (other.CompareTag("Enemy"))
        {
            //Debug.Log("Enemy gg");

        }

        Debug.Log(other.gameObject.name);
    }

    private void OnTriggerExit(Collider other) // ������Ʈ �� �������� �� (�±� Ư�� ����)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy bye");
        }
    }
}
