using UnityEngine;

namespace Agent.Spawner
{
    public class AgentSpawner : MonoBehaviour
    {
        [Header("Number of agents on scene")]
        public int AgentCount;
        [Header("Agent to spawn")]
        public GameObject Agent;

        public void Start()
        {
            SpawnAgents(AgentCount);
        }

        private void SpawnAgents(int numberOfAgents)
        {
            for (int i = 0; i < numberOfAgents; i++)
            {
                GameObject agent = Instantiate(Agent, RandomPointOnNavMeshGetter.FindPoint(), Quaternion.identity);
            }
        }
    } 
}
