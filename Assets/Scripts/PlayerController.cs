using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private int roadWidth;

    [Header("Control")]
    [SerializeField] private float slidSpeed;
    private Vector3 clickScreenPosition;
    private Vector3 clickPlayerPositon;

    [SerializeField] private CrowdSystem crowdSystem;

    void Start()
    {

    }

    void Update()
    {
        MoveSpeedFroward();
        ManageControl();
    }

    private void MoveSpeedFroward()
    {
        transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
    }

    private void ManageControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickScreenPosition = Input.mousePosition;
            clickPlayerPositon = transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            float xScreenDifference = Input.mousePosition.x - clickScreenPosition.x;

            xScreenDifference /= Screen.width;
            xScreenDifference *= slidSpeed;

            Vector3 positon = transform.position;
            positon.x = clickPlayerPositon.x + xScreenDifference;

            positon.x = Mathf.Clamp(positon.x, -roadWidth / 2 + crowdSystem.GetCrowdRadius(), roadWidth / 2 - crowdSystem.GetCrowdRadius());

            transform.position = positon;

            // transform.position = clickPlayerPositon + Vector3.right * xScreenDifference;
        }
    }
}
