using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 5;

    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;     // 0, 0, 0 ��ġ

    void Start()    // ó���� ��� ��ֹ����� ã�ƿͼ� ���� ��ġ 
    {
        /*
            - ���� �����ϴ� ��� ������Ʈ�� �˻��ؼ� Obstacle�� �޷� �ִ��� ã�ƿ�.
            - FindObject's'OfType s�� �پ�� ��� ������Ʈ�� ã�ƿ�
            - ���ſ�� Start()�� Awake()�� ����ϴ� ���� ��õ
         */
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)     // �� ���ķ� Trigger �浹�ϴ� �͵��� ���� ��ġ
    {
        Debug.Log("Triggerd: " + collision.name);

        // �±׷� ã�� ���
        if(collision.CompareTag("BackGround"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }

        // ������Ʈ�� ã�� ���
        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle)
        { 
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }
}
