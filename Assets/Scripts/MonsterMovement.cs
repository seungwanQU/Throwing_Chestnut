using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class MonsterMovement : MonoBehaviour
{
    public List<GameObject> monsterPrefabs = new List<GameObject>();
    private NavMeshAgent navMeshAgent;

    private bool isMoving = false;

    [SerializeField] private float minMoveDelay = 1f; // 최소 이동 딜레이
    [SerializeField] private float maxMoveDelay = 3f; // 최대 이동 딜레이

    private void Start()
    {
        // 처음에 이동을 시작하도록 호출
        StartCoroutine(MoveCoroutine());
    }

    private IEnumerator MoveCoroutine()
    {
        while (true)
        {
            if (!isMoving)
            {
                // 이동을 시작하기 전에 랜덤한 딜레이를 줍니다.
                float moveDelay = Random.Range(minMoveDelay, maxMoveDelay);
                yield return new WaitForSeconds(moveDelay);

                // 새로운 목표 지점을 선택하여 이동합니다.
                Vector3 targetPosition = GetRandomTargetPosition();
                MoveTo(targetPosition);
            }
            yield return null;
        }
    }

    private Vector3 GetRandomTargetPosition()
    {
        // 랜덤한 위치를 선택하여 반환합니다.
        Vector3 randomPosition = new Vector3(Random.Range(555f, 585f), 0f, Random.Range(335f, 375f));
        return randomPosition;
    }

    private void MoveTo(Vector3 targetPosition)
    {
        isMoving = true;
        navMeshAgent.SetDestination(targetPosition);
    }

    private void Update()
    {
        foreach (var monster in monsterPrefabs)
        {
            if (monster.activeSelf == true)
            {
                navMeshAgent = monster.GetComponent<NavMeshAgent>();
            }
        }

        if (isMoving && navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            // 이동이 완료되었을 때 이동 상태 해제
            isMoving = false;
        }
    }
}
