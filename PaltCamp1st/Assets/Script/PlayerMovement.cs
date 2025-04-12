using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float laneDistance = 50f; // 레인 간 x 거리
    public float forwardSpeed = 10f;
    public float laneChangeSpeed = 25f;

    private int currentLane = 0; // -1 = 왼쪽, 0 = 가운데, 1 = 오른쪽

    void Update()
    {
        // 전진
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        // 입력 처리
        if (Input.GetKeyDown(KeyCode.A) && currentLane > -1)
        {
            currentLane--;
        }
        else if (Input.GetKeyDown(KeyCode.D) && currentLane < 1)
        {
            currentLane++;
        }

        // 이동 후 위치
        float targetX = currentLane * laneDistance;
        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);

        // 이동 지역 변수
        transform.position = targetPosition;
    }


    private void OnTriggerEnter(Collider other) // 오브젝트 간 닿았을 때 (태그 특정 가능)
    {
        if (other.CompareTag("Enemy"))
        {
            //Debug.Log("Enemy gg");

        }

        Debug.Log(other.gameObject.name);
    }

    private void OnTriggerExit(Collider other) // 오브젝트 간 떨어졌을 때 (태그 특정 가능)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Enemy bye");
        }
    }
}
