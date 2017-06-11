using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using Movement;

namespace Managers
{
    public class AgentSpawnManager : MonoBehaviour
    {
        [Header("Number of agents in area")]
        public int AgentCount;
        [Header("Unity-only agent - random movement")]
        public GameObject TestAgentRandom;
        [Header("Unity-only agent - list based movement")]
        public GameObject TestAgentList;
        [Header("Custom agent")]
        public GameObject ModifiedAgent;

        private List<Vector3> _spawnPoints;
        private List<List<Vector3>> _pathPoints;
        private List<GameObject> _agents;

        public List<GameObject> SpawnAgents(GameObject agent)
        {
            _agents = new List<GameObject>();
            for (int i = 0; i < AgentCount; i++)
            {
                Vector3 point = RandomPointOnNavMeshGetter.FindPointWithUnitSphere(Vector3.zero);
                //point.y = GlobalVariables.AGENT_Y_SPAWN_POS_OFFSET;
                GameObject spawnedAgent = Instantiate(agent, point, Quaternion.Euler(Vector3.zero));
                spawnedAgent.name = string.Format("{0}_{1}", agent.name, i);
                _agents.Add(spawnedAgent);
            }

            return _agents;
        }

        public List<GameObject> SpawnAgentWithListBasedMovement(GameObject agent, ObstacleAvoidanceType type)
        {
            _agents = new List<GameObject>();
            for (int i = 0; i < AgentCount; i++)
            {
                GameObject spawnedAgent = Instantiate(agent, _spawnPoints[i], Quaternion.Euler(Vector3.zero));
                spawnedAgent.name = string.Format("{0}_{1}", agent.name, i);
                spawnedAgent.GetComponent<NavMeshAgent>().obstacleAvoidanceType = type;
                ListBasedAgentMovement listMovement = spawnedAgent.GetComponent<ListBasedAgentMovement>();
                listMovement.StartingPoint = _spawnPoints[i];
                listMovement.PathPoints = _pathPoints[i];
                _agents.Add(spawnedAgent);
            }

            return _agents;
        }

        public void GetDataFromAgents()
        {
            _spawnPoints = new List<Vector3>();
            _pathPoints = new List<List<Vector3>>();
            for (int i = 0; i < _agents.Count; i++)
            {
                RandomAgentMovement randomMovement = _agents[i].GetComponent<RandomAgentMovement>();

                randomMovement.StopMovement();
                randomMovement.enabled = false;
                _spawnPoints.Add(randomMovement.StartingPoint);
                _pathPoints.Add(randomMovement.DestinationPoints);
            }
        }

        public void DespawnAgents()
        {
            for (int i = 0; i < _agents.Count; i++)
            {
                Destroy(_agents[i]);
            }
            _agents.Clear();
        }

        public void ClearAll()
        {
            DespawnAgents();
            _spawnPoints.Clear();
            _pathPoints.Clear();
        }
    }
}
