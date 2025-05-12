using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField]
    Transform _new_Camera_Transform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Camera.main.transform.position = _new_Camera_Transform.position;
            Camera.main.transform.rotation = _new_Camera_Transform.rotation;
        }
    }
}
