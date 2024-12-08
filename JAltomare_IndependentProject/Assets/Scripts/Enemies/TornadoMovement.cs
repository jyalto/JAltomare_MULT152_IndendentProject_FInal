using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TornadoMovement : MonoBehaviour
{
    public Transform TornadoRoute;
    public List<Transform> Locations;

    private int locationIndex = 0;
    private NavMeshAgent agent;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InitializeTornadoMovement();
        MoveToNextTornadoLocation();
    }

    // Update is called once per frame
    private void Update()
    {
        if (agent.remainingDistance < 0.2f && !agent.pathPending) 
        {
            MoveToNextTornadoLocation();
        }
        if (gameManager.nestFilled == true)
        {
            Destroy(this.gameObject);
        }
    }
    void InitializeTornadoMovement()
    {
        foreach (Transform child in TornadoRoute)
        {
            Locations.Add(child);
        }
    }
    void MoveToNextTornadoLocation()
    {
        if (Locations.Count == 0)
            return;

        agent.destination = Locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % Locations.Count;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !GameManager.Instance.playerDead)
        {
            PlayerController.OnTakeDamage(50);
        }
    }
    void OnTriggerExit(Collider other)
    {
        
    }
}

