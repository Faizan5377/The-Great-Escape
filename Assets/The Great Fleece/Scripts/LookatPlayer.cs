using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookatPlayer : MonoBehaviour
{
    [SerializeField]
    Transform _player_Transform;
    [SerializeField]
    Transform _Start_Camera;

    private void Start()
    {
        transform.position = _Start_Camera.position;
        transform.rotation = _Start_Camera.rotation;
    }
    void Update()
    {
        transform.LookAt(_player_Transform);
    }
}
