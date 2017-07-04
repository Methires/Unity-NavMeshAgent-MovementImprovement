using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Movement.Modifier
{
    public class MovementModifier : MonoBehaviour
    {
        private Vector3 _forward;
        private NavMeshAgent _nMA;
        private List<NavMeshAgent> _nMAs;

        private void Awake()
        {
            _nMA = GetComponentInParent<NavMeshAgent>();
            _nMAs = new List<NavMeshAgent>();
        }

        private void Update()
        {
            if (_nMAs.Count > 0)
            {
                _forward = transform.TransformDirection(Vector3.forward);
                Vector3 modifiedVelocity = _nMA.velocity;
                bool changed = false;
                foreach (NavMeshAgent agent in _nMAs)
                {
                    Vector3 thisToOther = agent.transform.position - transform.position;
                    Vector3 otherToThis = transform.position - agent.transform.position;
                    float thisToOtherValue = Vector3.Dot(_forward, thisToOther);
                    if (thisToOtherValue > 0.0f)
                    {
                        float otherToThisValue = Vector3.Dot(otherToThis, agent.velocity);
                        if (otherToThisValue > 0.0f)
                        {
                            Vector3 modifier = Vector3.Project(agent.velocity, otherToThis) * GlobalVariables.VELOCITY_FRACTION;
                            //modifiedVelocity = modifiedVelocity + (modifier * -1.0f);
                            modifiedVelocity = modifiedVelocity + modifier;
                            changed = true;
                        } 
                    }
                }

                if (changed)
                {
                    float a = modifiedVelocity.magnitude;
                    float b = (modifiedVelocity.normalized * _nMA.speed).magnitude;
                    float c = Mathf.Min(a, b);
                    if (c == a)
                    {
                        _nMA.velocity = modifiedVelocity;
                    }
                    else
                    {
                        _nMA.velocity = modifiedVelocity.normalized * _nMA.speed;
                    } 
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Agent"))
            {
                if (_nMAs != null)
                {
                    NavMeshAgent nMA = other.GetComponentInParent<NavMeshAgent>();
                    if (!_nMAs.Contains(nMA))
                    {
                        _nMAs.Add(nMA);
                    }
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Agent"))
            {
                if (_nMAs != null)
                {
                    NavMeshAgent nMA = other.GetComponentInParent<NavMeshAgent>();
                    if (_nMAs.Contains(nMA))
                    {
                        _nMAs.Remove(nMA);
                    }
                }
            }
        }
    } 
}
