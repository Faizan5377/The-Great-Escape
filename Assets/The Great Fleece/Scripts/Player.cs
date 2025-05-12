using UnityEngine.AI;
using UnityEngine;

public class Player : MonoBehaviour
{
    NavMeshAgent _navmesh_agent;
    Camera _camera;
    Animator _player_Animator;
    Vector3 _TargetPos;

    [SerializeField]
    GameObject _Coin;

    [SerializeField]
    AudioClip _CoinTossAudio;

    [SerializeField]
    float moveSpeed = 5f;  // Movement speed for WASD controls

    bool isCoinTossed;
    bool isUsingMouseNavigation = false;  // Flag to track input method
    float inputH, inputV;  // Store horizontal and vertical input values

    void Start()
    {
        isCoinTossed = false;
        _player_Animator = GetComponentInChildren<Animator>();
        _camera = Camera.main;
        _navmesh_agent = GetComponent<NavMeshAgent>();
        _navmesh_agent.updateRotation = true;  // Let NavMesh handle rotation
    }

    void Update()
    {
        // Check for WASD input
        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        // If there's keyboard input, cancel any mouse navigation
        if (Mathf.Abs(inputH) > 0.1f || Mathf.Abs(inputV) > 0.1f)
        {
            isUsingMouseNavigation = false;
            _navmesh_agent.ResetPath();
            MoveWithKeyboard();
        }

        // Mouse click navigation (original functionality)
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Click!");
            Vector3 _mouse_Position = Input.mousePosition;
            Ray _ray = _camera.ScreenPointToRay(_mouse_Position);

            if (Physics.Raycast(_ray, out RaycastHit _hit))
            {
                _TargetPos = _hit.point;
                _navmesh_agent.SetDestination(_TargetPos);
                isUsingMouseNavigation = true;
                _player_Animator.SetBool("isWalking", true);
            }
        }

        // Coin toss functionality (unchanged)
        if (Input.GetMouseButtonDown(1) && !isCoinTossed)
        {
            Ray _ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out RaycastHit _hitPoint))
            {
                _player_Animator.SetTrigger("Throw");
                Instantiate(_Coin, _hitPoint.point, Quaternion.identity);
                isCoinTossed = true;
                AudioManager.Instance.PlayCoinThrowSoundOnce(_CoinTossAudio);
                SendAItoCoin(_hitPoint.point);
            }
        }

        // Handle animation state
        if (isUsingMouseNavigation)
        {
            // Check if reached destination (for mouse navigation)
            if (transform.position.x == _TargetPos.x && transform.position.z == _TargetPos.z)
            {
                _player_Animator.SetBool("isWalking", false);
            }
        }
        else
        {
            // For keyboard movement, set animation based on input
            _player_Animator.SetBool("isWalking", Mathf.Abs(inputH) > 0.1f || Mathf.Abs(inputV) > 0.1f);
        }
    }

    void MoveWithKeyboard()
    {
        // Calculate movement direction relative to camera
        Vector3 cameraForward = _camera.transform.forward;
        Vector3 cameraRight = _camera.transform.right;

        // Project vectors onto ground plane (y = 0)
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate move direction
        Vector3 moveDirection = (cameraForward * inputV + cameraRight * inputH).normalized;

        if (moveDirection.magnitude > 0.1f)
        {
            // Move the player using NavMeshAgent
            _navmesh_agent.velocity = moveDirection * moveSpeed;

            // Make the player face the movement direction
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), 0.15f);
        }
        else
        {
            // Stop movement if no input
            _navmesh_agent.velocity = Vector3.zero;
        }
    }

    void SendAItoCoin(Vector3 pos)
    {
        GameObject[] guards;
        guards = GameObject.FindGameObjectsWithTag("Guard1");

        for (int i = 0; i < guards.Length; i++)
        {
            Debug.Log("ddddddddd");
            GuardAI _GuardScript = guards[i].GetComponent<GuardAI>();
            _GuardScript.StopMovingonCoinToss(true);
            _GuardScript.coinPos = pos;
            _GuardScript.SetDestination(pos);
            _GuardScript.PlayWalkAnimation(true);
            _GuardScript.ChangeStoppingDistance(5.0f);
        }
    }
}