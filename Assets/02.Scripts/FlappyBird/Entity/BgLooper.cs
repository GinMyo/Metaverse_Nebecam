using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{
    public int numBgCount = 5;

    public int obstacleCount = 0;
    public Vector3 obstacleLastPosition = Vector3.zero;     // 0, 0, 0 위치

    void Start()    // 처음에 모든 장애물들을 찾아와서 랜덤 배치 
    {
        /*
            - 씬에 존재하는 모든 오브젝트를 검사해서 Obstacle이 달려 있는지 찾아옴.
            - FindObject's'OfType s가 붙어야 모든 오브젝트를 찾아옴
            - 무거우니 Start()나 Awake()에 사용하는 것을 추천
         */
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
        obstacleLastPosition = obstacles[0].transform.position;
        obstacleCount = obstacles.Length;

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)     // 그 이후론 Trigger 충돌하는 것들을 랜덤 배치
    {
        Debug.Log("Triggerd: " + collision.name);

        // 태그로 찾는 방법
        if(collision.CompareTag("BackGround"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }

        // 컴포넌트로 찾는 방법
        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle)
        { 
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }
}
