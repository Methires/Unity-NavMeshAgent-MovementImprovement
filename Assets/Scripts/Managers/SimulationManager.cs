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

        private List<string> _text;

        private void Awake()
        {
            _spawner = GetComponent<AgentSpawnManager>();
            _pathTester = GetComponent<PathComleptionTester>();
            _timer = GetComponent<SimulationTimeManager>();
            _text = new List<string>();
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
            _text.Add("Test 1 - " + ObstacleAvoidanceType.NoObstacleAvoidance + " - time: " + (int)_timer.TestTime);
            _text.Add("Test Collisions - " + ObstacleAvoidanceType.NoObstacleAvoidance + " - collisions: " + CollisionCounter.Counter);
            Debug.Log("Test 1 - " + ObstacleAvoidanceType.NoObstacleAvoidance + " - time: " + (int)_timer.TestTime);
            Debug.Log("Test Collisions - " + ObstacleAvoidanceType.NoObstacleAvoidance + " - collisions: " + CollisionCounter.Counter);
            _spawner.GetDataFromAgents();
            _spawner.DespawnAgents();
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _pathTester.Agents = _spawner.SpawnAgentWithListBasedMovement(_spawner.TestAgentList, ObstacleAvoidanceType.LowQualityObstacleAvoidance);
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _timer.TestTime = 0.0f;
            yield return new WaitUntil(_pathTester.AreAllAgentsDone);
            _text.Add("Test 2 - " + ObstacleAvoidanceType.LowQualityObstacleAvoidance + " - time: " + (int)_timer.TestTime);
            Debug.Log("Test 2 - " + ObstacleAvoidanceType.LowQualityObstacleAvoidance + " - time: " + (int)_timer.TestTime);
            _spawner.DespawnAgents();
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _pathTester.Agents = _spawner.SpawnAgentWithListBasedMovement(_spawner.TestAgentList, ObstacleAvoidanceType.MedQualityObstacleAvoidance);
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _timer.TestTime = 0.0f;
            yield return new WaitUntil(_pathTester.AreAllAgentsDone);
            _text.Add("Test 3 - " + ObstacleAvoidanceType.MedQualityObstacleAvoidance + " - time: " + (int)_timer.TestTime);
            Debug.Log("Test 3 - " + ObstacleAvoidanceType.MedQualityObstacleAvoidance + " - time: " + (int)_timer.TestTime);
            _spawner.DespawnAgents();
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _pathTester.Agents = _spawner.SpawnAgentWithListBasedMovement(_spawner.TestAgentList, ObstacleAvoidanceType.GoodQualityObstacleAvoidance);
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _timer.TestTime = 0.0f;
            yield return new WaitUntil(_pathTester.AreAllAgentsDone);
            _text.Add("Test 4 - " + ObstacleAvoidanceType.GoodQualityObstacleAvoidance + " - time: " + (int)_timer.TestTime);
            Debug.Log("Test 4 - " + ObstacleAvoidanceType.GoodQualityObstacleAvoidance + " - time: " + (int)_timer.TestTime);
            _spawner.DespawnAgents();
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _pathTester.Agents = _spawner.SpawnAgentWithListBasedMovement(_spawner.TestAgentList, ObstacleAvoidanceType.HighQualityObstacleAvoidance);
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _timer.TestTime = 0.0f;
            yield return new WaitUntil(_pathTester.AreAllAgentsDone);
            _text.Add("Test 5 - " + ObstacleAvoidanceType.HighQualityObstacleAvoidance + " - time: " + (int)_timer.TestTime);
            Debug.Log("Test 5 - " + ObstacleAvoidanceType.HighQualityObstacleAvoidance + " - time: " + (int)_timer.TestTime);
            _spawner.DespawnAgents();
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _pathTester.Agents = _spawner.SpawnAgentWithListBasedMovement(_spawner.ModifiedAgent, ObstacleAvoidanceType.NoObstacleAvoidance);
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _timer.TestTime = 0.0f;
            CollisionCounter.Counter = 0;
            yield return new WaitUntil(_pathTester.AreAllAgentsDone);
            _text.Add("Modified 1 - " + ObstacleAvoidanceType.NoObstacleAvoidance + " - time: " + (int)_timer.TestTime);
            _text.Add("Modified Collisions - " + ObstacleAvoidanceType.NoObstacleAvoidance + " - collisions: " + CollisionCounter.Counter);
            Debug.Log("Modified 1 - " + ObstacleAvoidanceType.NoObstacleAvoidance + " - time: " + (int)_timer.TestTime);
            Debug.Log("Modified Collisions - " + ObstacleAvoidanceType.NoObstacleAvoidance + " - collisions: " + CollisionCounter.Counter);
            _spawner.DespawnAgents();
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _pathTester.Agents = _spawner.SpawnAgentWithListBasedMovement(_spawner.ModifiedAgent, ObstacleAvoidanceType.LowQualityObstacleAvoidance);
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _timer.TestTime = 0.0f;
            yield return new WaitUntil(_pathTester.AreAllAgentsDone);
            _text.Add("Modified 2 - " + ObstacleAvoidanceType.LowQualityObstacleAvoidance + " - time: " + (int)_timer.TestTime);
            Debug.Log("Modified 2 - " + ObstacleAvoidanceType.LowQualityObstacleAvoidance + " - time: " + (int)_timer.TestTime);
            _spawner.DespawnAgents();
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _pathTester.Agents = _spawner.SpawnAgentWithListBasedMovement(_spawner.ModifiedAgent, ObstacleAvoidanceType.MedQualityObstacleAvoidance);
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _timer.TestTime = 0.0f;
            yield return new WaitUntil(_pathTester.AreAllAgentsDone);
            _text.Add("Modified 3 - " + ObstacleAvoidanceType.MedQualityObstacleAvoidance + " - time: " + (int)_timer.TestTime);
            Debug.Log("Modified 3 - " + ObstacleAvoidanceType.MedQualityObstacleAvoidance + " - time: " + (int)_timer.TestTime);
            _spawner.DespawnAgents();
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _pathTester.Agents = _spawner.SpawnAgentWithListBasedMovement(_spawner.ModifiedAgent, ObstacleAvoidanceType.GoodQualityObstacleAvoidance);
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _timer.TestTime = 0.0f;
            yield return new WaitUntil(_pathTester.AreAllAgentsDone);
            _text.Add("Modified 4 - " + ObstacleAvoidanceType.GoodQualityObstacleAvoidance + " - time: " + (int)_timer.TestTime);
            Debug.Log("Modified 4 - " + ObstacleAvoidanceType.GoodQualityObstacleAvoidance + " - time: " + (int)_timer.TestTime);
            _spawner.DespawnAgents();
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _pathTester.Agents = _spawner.SpawnAgentWithListBasedMovement(_spawner.ModifiedAgent, ObstacleAvoidanceType.HighQualityObstacleAvoidance);
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _timer.TestTime = 0.0f;
            yield return new WaitUntil(_pathTester.AreAllAgentsDone);
            _text.Add("Modified 5 - " + ObstacleAvoidanceType.HighQualityObstacleAvoidance + " - time: " + (int)_timer.TestTime);
            Debug.Log("Modified 5 - " + ObstacleAvoidanceType.HighQualityObstacleAvoidance + " - time: " + (int)_timer.TestTime);

            StreamWriter file = new StreamWriter(GlobalVariables.SAVE_LOC + @"\Results_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + ".txt", false);
            foreach (string line in _text)
            {
                file.WriteLine(line);
            }
            file.Close();

            End();
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
