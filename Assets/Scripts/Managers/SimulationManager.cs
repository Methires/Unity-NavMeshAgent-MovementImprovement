using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using Testers;
using Movement;

namespace Managers
{
    [RequireComponent(typeof(AgentSpawnManager))]
    [RequireComponent(typeof(PathComleptionTester))]
    [RequireComponent(typeof(SimulationTimeManager))]
    public class SimulationManager : MonoBehaviour
    {
        [Header("Initial test time in seconds")]
        public float Time;

        private AgentSpawnManager _spawner;
        private PathComleptionTester _pathTester;
        private SimulationTimeManager _timer;

        private void Awake()
        {
            _spawner = GetComponent<AgentSpawnManager>();
            _pathTester = GetComponent<PathComleptionTester>();
            _timer = GetComponent<SimulationTimeManager>();
        }

        private void Start()
        {
            StartCoroutine(StartTesting());
        }

        private IEnumerator StartTesting()
        {
            _spawner.SpawnAgents(_spawner.TestAgentRandom);
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _timer.TestTime = 0.0f;
            yield return new WaitForSeconds(Time);
            Debug.Log("Test 1: " + (int)_timer.TestTime);
            _spawner.GetDataFromAgents();
            _spawner.DespawnAgents();
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _pathTester.Agents = _spawner.SpawnAgentWithListBasedMovement(_spawner.TestAgentList, ObstacleAvoidanceType.LowQualityObstacleAvoidance);
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _timer.TestTime = 0.0f;
            yield return new WaitUntil(_pathTester.AreAllAgentsDone);
            Debug.Log("Test 2: " + (int)_timer.TestTime);
            _spawner.DespawnAgents();
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _pathTester.Agents = _spawner.SpawnAgentWithListBasedMovement(_spawner.TestAgentList, ObstacleAvoidanceType.MedQualityObstacleAvoidance);
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _timer.TestTime = 0.0f;
            yield return new WaitUntil(_pathTester.AreAllAgentsDone);
            Debug.Log("Test 3: " + (int)_timer.TestTime);
            _spawner.DespawnAgents();
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _pathTester.Agents = _spawner.SpawnAgentWithListBasedMovement(_spawner.TestAgentList, ObstacleAvoidanceType.GoodQualityObstacleAvoidance);
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _timer.TestTime = 0.0f;
            yield return new WaitUntil(_pathTester.AreAllAgentsDone);
            Debug.Log("Test 4: " + (int)_timer.TestTime);
            _spawner.DespawnAgents();
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _pathTester.Agents = _spawner.SpawnAgentWithListBasedMovement(_spawner.TestAgentList, ObstacleAvoidanceType.HighQualityObstacleAvoidance);
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _timer.TestTime = 0.0f;
            yield return new WaitUntil(_pathTester.AreAllAgentsDone);
            Debug.Log("Test 5: " + (int)_timer.TestTime);
            _spawner.DespawnAgents();
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _pathTester.Agents = _spawner.SpawnAgentWithListBasedMovement(_spawner.ModifiedAgent, ObstacleAvoidanceType.NoObstacleAvoidance);
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _timer.TestTime = 0.0f;
            yield return new WaitUntil(_pathTester.AreAllAgentsDone);
            Debug.Log("Modified 1: " + (int)_timer.TestTime);
            _spawner.DespawnAgents();
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _pathTester.Agents = _spawner.SpawnAgentWithListBasedMovement(_spawner.ModifiedAgent, ObstacleAvoidanceType.LowQualityObstacleAvoidance);
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _timer.TestTime = 0.0f;
            yield return new WaitUntil(_pathTester.AreAllAgentsDone);
            Debug.Log("Modified 2: " + (int)_timer.TestTime);
            _spawner.DespawnAgents();
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _pathTester.Agents = _spawner.SpawnAgentWithListBasedMovement(_spawner.ModifiedAgent, ObstacleAvoidanceType.MedQualityObstacleAvoidance);
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _timer.TestTime = 0.0f;
            yield return new WaitUntil(_pathTester.AreAllAgentsDone);
            Debug.Log("Modified 3: " + (int)_timer.TestTime);
            _spawner.DespawnAgents();
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _pathTester.Agents = _spawner.SpawnAgentWithListBasedMovement(_spawner.ModifiedAgent, ObstacleAvoidanceType.GoodQualityObstacleAvoidance);
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _timer.TestTime = 0.0f;
            yield return new WaitUntil(_pathTester.AreAllAgentsDone);
            Debug.Log("Modified 4: " + (int)_timer.TestTime);
            _spawner.DespawnAgents();
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _pathTester.Agents = _spawner.SpawnAgentWithListBasedMovement(_spawner.ModifiedAgent, ObstacleAvoidanceType.HighQualityObstacleAvoidance);
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _timer.TestTime = 0.0f;
            yield return new WaitUntil(_pathTester.AreAllAgentsDone);
            Debug.Log("Modified 5: " + (int)_timer.TestTime);






            //StreamWriter file = new StreamWriter(GlobalVariables.SAVE_LOC + @"\Results_" + _spawner.Agent.name + "_" + Type + ".txt", true);
            //file.WriteLine(string.Format("{0}", DateTime.Now));
            //file.WriteLine(string.Format("Number of agents: {0}", _spawner.AgentCount));
            //file.WriteLine(string.Format("Simulation time: {0}", Time));
            //file.WriteLine(string.Format("Avoidance Type: {0}", Type));
            //file.Close();

        }

        private void Pause(string text)
        {
#if UNITY_EDITOR
            Debug.Log(string.Format("Pausing - {0}", text));
            UnityEditor.EditorApplication.isPaused = true;
#endif
        }

        private void End()
        {
#if !UNITY_EDITOR
            Application.Quit();
#else
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}
