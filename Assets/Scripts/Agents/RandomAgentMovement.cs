using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Movement
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class RandomAgentMovement : MonoBehaviour
    {
        private bool _shouldMove;
        [SerializeField]
        private Vector3 _startingPoint;
        [SerializeField]
        private List<Vector3> _destinationPoints; 
        private NavMeshAgent _nMA;

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
        public List<Vector3> DestinationPoints
        {
            get
            {
                return _destinationPoints;
            }
            set
            {
                _destinationPoints = value;
            }
        }

        private void Awake()
        {
            _nMA = GetComponent<NavMeshAgent>();
            _nMA.updateRotation = GlobalVariables.UPDATE_ROTATION;
            _nMA.stoppingDistance = GlobalVariables.STOPPING_DISTANCE;
            _destinationPoints = new List<Vector3>();
        }

        private void Start()
        {
            _shouldMove = false;
            StartCoroutine(StartMovement());
        }

        private void Update()
        {
            if (_shouldMove)
            {
                if (_nMA.remainingDistance <= GlobalVariables.STOPPING_DISTANCE && _nMA.pathStatus.Equals(NavMeshPathStatus.PathComplete))
                {
                    StartCoroutine(SetNewDestination());
                }
            }
        }

        private IEnumerator SetNewDestination()
        {
            bool result = false;
            Vector3 point;
            while (!result)
            {
                point = RandomPointOnNavMeshGetter.FindPointWithUnitSphere(Vector3.zero);
                result = _nMA.SetDestination(point);
                yield return null;
            }
            if (!_destinationPoints.Contains(_nMA.destination))
            {
                _destinationPoints.Add(_nMA.destination); 
            }
        }

        public void StopMovement()
        {
            _nMA.ResetPath();
            _destinationPoints.Remove(_destinationPoints[_destinationPoints.Count - 1]);
            Vector3 point = transform.position;
            point.y = GlobalVariables.NAVMESH_POINT_Y;
            _destinationPoints.Add(point);
            _shouldMove = false;
        }

        private IEnumerator StartMovement()
        {
            yield return new WaitForSeconds(GlobalVariables.START_DELAY);
            _startingPoint = transform.position;
            _shouldMove = true;
            StartCoroutine(SetNewDestination());
        }
    } 
}
