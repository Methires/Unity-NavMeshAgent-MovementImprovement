using UnityEngine;
using System;
using System.Collections.Generic;
using Movement;

namespace Testers
{
    public class PathComleptionTester : MonoBehaviour
    {
        public Func<bool> AreAllAgentsDone;

        private List<GameObject> _agents;

        public List<GameObject> Agents
        {
            get
            {
                return _agents;
            }
            set
            {
                _agents = value;
            }
        }

        private void Start()
        {
            AreAllAgentsDone += CheckAgents;
        }

        private bool CheckAgents()
        {
            foreach (GameObject agent in Agents)
            {
                if (!agent.GetComponent<ListBasedAgentMovement>().IsDone)
                {
                    return false;
                }
            }

            return true;
        }
    } 
}
