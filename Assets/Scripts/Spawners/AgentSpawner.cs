using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

namespace Spawners
{
    public class AgentSpawner : MonoBehaviour
    {
        [Header("Number of agents in area")]
        public int AgentCount;
        [Header("Agent to spawn")]
        public GameObject Agent;

        public List<GameObject> SpawnAgents(ObstacleAvoidanceType type, Vector3 areaCenter)
        {
            List<GameObject> agents = new List<GameObject>();
            for (int i = 0; i < AgentCount; i++)
            {
                Vector3 point = RandomPointOnNavMeshGetter.FindPointWithUnitSphere(areaCenter);
                GameObject spawnedAgent = Instantiate(Agent, point, Quaternion.identity);
                spawnedAgent.GetComponent<NavMeshAgent>().obstacleAvoidanceType = type;
                agents.Add(spawnedAgent);
            }

            return agents;
        }
    }
}
