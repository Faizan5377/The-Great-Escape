using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    [SerializeField]
    List<Transform> WayPoints;
    [SerializeField]
    float _time_To_Wait_Before_Moving;

    NavMeshAgent _navMeshAgent;
    Transform _current_WayPoint;
    int length;
    int index;
    bool isWaiting;
    bool isReversing;
    Animator _animation_Controller;
    bool stopMoving;
    internal Vector3 coinPos;


    void Start()
    {
        stopMoving = false;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animation_Controller = GetComponent<Animator>();
        length = WayPoints.Count;
        index = 0;
        isReversing = false;
        if (length > 0)
        {
            _current_WayPoint = WayPoints[index];
            _navMeshAgent.SetDestination(_current_WayPoint.position);
            _animation_Controller.SetBool("isWalking", true);
        }
    }

    void Update()
    {
        Debug.Log("Remaining Distance: " + _navMeshAgent.remainingDistance);
        //Debug.Log("Stop Moving: " + stopMoving);
        if (length > 0 && !isWaiting && _navMeshAgent.remainingDistance < 0.5f && stopMoving == false)
        {
            PlayWalkAnimation(false);
            StartCoroutine(WaitBeforeMoving());
        }
        else
        {
            if (stopMoving)
            {
                float _distance = Vector3.Distance(transform.position, coinPos);
                if(_distance <= _navMeshAgent.stoppingDistance)
                {
                    PlayWalkAnimation(false);
                }
            }
        }
    }

    IEnumerator WaitBeforeMoving()
    {
        isWaiting = true;
        yield return new WaitForSeconds(_time_To_Wait_Before_Moving);
        UpdateWaypoint();
        isWaiting = false;
    }

    internal void ChangeStoppingDistance(float val)
    {
        _navMeshAgent.stoppingDistance = val;
    }

    internal void StopMovingonCoinToss(bool val)
    {
        stopMoving = val;
    }
    internal void EnabledAutoBraking(bool val)
    {
        _navMeshAgent.autoBraking = val;
    }

    internal void PlayWalkAnimation(bool val)
    {
        _animation_Controller.SetBool("isWalking", val);
    }

    internal void SetDestination(Vector3 pos)
    {
        if(pos!=null)
        _navMeshAgent.SetDestination(pos);
    }

    void UpdateWaypoint()
    {
        if (isReversing)
        {
            index--;
        }
        else
        {
            index++;
        }

        if (index == length)
        {
            isReversing = true;
            index--;
        }
        else if(index == 0)
        {
            isReversing = false;
        }

        _current_WayPoint = WayPoints[index];
        if (stopMoving == false)
        {
            Debug.Log("I am here!");
            _navMeshAgent.SetDestination(_current_WayPoint.position);
            _animation_Controller.SetBool("isWalking", true);
        }
    }

}
