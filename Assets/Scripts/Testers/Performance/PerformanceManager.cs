using UnityEngine;
using UnityEngine.AI;
using Spawners;
using System.Collections;

namespace Testers.Performance
{
    [RequireComponent(typeof(AgentSpawner))]
    [RequireComponent(typeof(PerformanceTester))]
    public class PerformanceManager : MonoBehaviour
    {
        [Header("Simulation Time [s]")]
        public float Time;
        [Header("Obstacle avoidance type")]
        public ObstacleAvoidanceType Type;

        private AgentSpawner _spawner;

        private PerformanceTester _tester;

        private void Awake()
        {
            _spawner = GetComponent<AgentSpawner>();
            _tester = GetComponent<PerformanceTester>();
        }

        private void Start()
        {
            StartCoroutine(StartSimulation());
        }

        private IEnumerator StartSimulation()
        {
            _spawner.SpawnAgents(Type, transform.position);
            _tester.StartMonitoringPerformance(Type);
            yield return new WaitForSeconds(Time);
            _tester.StopMonitoringPerformance();
        }
    } 
}
