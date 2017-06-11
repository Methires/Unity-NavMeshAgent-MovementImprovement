using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;

namespace Movement
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class ListBasedAgentMovement : MonoBehaviour
    {
        private bool _isDone;
        private bool _shouldMove;
        [SerializeField]
        private int _nextPoint;
        [SerializeField]
        private Vector3 _startingPoint;
        [SerializeField]
        private List<Vector3> _pathPoints;
        private NavMeshAgent _nMA;

        public bool IsDone
        {
            get
            {
                return _isDone;
            }
        }
        public Vector3 StartingPoint
        {
            get
            {
                return _startingPoint;
            }
            set
            {
                _startingPoint = value;
            }
        }
        public List<Vector3> PathPoints
        {
            get
            {
                return _pathPoints;
            }
            set
            {
                _pathPoints = value;
            }
        }

        private void Awake()
        {
            _nMA = GetComponent<NavMeshAgent>();
            _nMA.updateRotation = GlobalVariables.UPDATE_ROTATION;
            _nMA.stoppingDistance = GlobalVariables.STOPPING_DISTANCE;
            _shouldMove = false;
        }

        private void Start()
        {
            StartCoroutine(StartMovement());
        }

        private void Update()
        {
            if (_shouldMove)
            {
                if (Vector2.Distance(new Vector2(transform.position.x, transform.position.z), new Vector2(_pathPoints[_nextPoint].x, _pathPoints[_nextPoint].z)) <= GlobalVariables.STOPPING_DISTANCE * 10.0f)
                {
                    if (_nextPoint < _pathPoints.Count - 1)
                    {
                        _nextPoint++;
                        _nMA.destination = _pathPoints[_nextPoint];
                    }
                    else
                    {
                        _isDone = true;
                        _nMA.enabled = false;
                    }
                }
                else
                {
                    _nMA.destination = _pathPoints[_nextPoint];
                }         
            }
        }


        private IEnumerator StartMovement()
        {
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            transform.position = _startingPoint;
            _shouldMove = true;
            _nMA.destination = _pathPoints[_nextPoint];
        }
    }
}
