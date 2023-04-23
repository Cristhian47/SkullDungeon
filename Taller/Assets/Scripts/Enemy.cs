using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent _enemyAgent;

    // Start is called before the first frame update
    void Start()
    {
        _enemyAgent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _enemyAgent.SetDestination(GameManager.Instance.GetPlayer().transform.position);
    }
}
