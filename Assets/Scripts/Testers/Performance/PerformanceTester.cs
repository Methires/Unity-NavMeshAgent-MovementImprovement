using UnityEngine;
using UnityEngine.AI;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace Testers.Performance
{
    public class PerformanceTester : MonoBehaviour
    {
        private PerformanceCounter _cpuCounter;
        private PerformanceCounter _ramCounter;

        private StreamWriter _writer;

        private bool _monitor;

        private List<string> _outLines;

        private void Start()
        {
            _cpuCounter = new PerformanceCounter()
            {
                CategoryName = "Processor",
                CounterName = "% Processor Time",
                InstanceName = "_Total"
            };
        }

        private void Update()
        {
            if (_monitor)
            {
                _outLines.Add(GetCurrentUsageCPU());
            }

            //UnityEngine.Debug.Log(getCurrentCpuUsage());
        }

        public void StartMonitoringPerformance(ObstacleAvoidanceType type)
        {
            _writer = new StreamWriter(GlobalVariables.SAVE_LOC + @"/CPU_" + type.ToString() + ".txt");
            _outLines = new List<string>();
            _monitor = true;
            //_cpuCounter.NextValue();
        }

        public void StopMonitoringPerformance()
        {
            _monitor = false;
            foreach (string line in _outLines)
            {
                _writer.WriteLine(line);
            }
        }

        public string GetCurrentUsageCPU()
        {
            return _cpuCounter.NextValue() + "%";
        }

        public string getAvailableRAM()
        {
            return _ramCounter.NextValue() + "MB";
        }
    } 
}
