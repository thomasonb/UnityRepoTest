using System;
using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;
    private Quaternion originalRotation;
    // Use this for initialization
    void Start()
    {
        originalRotation = transform.rotation;
        if (!GameManager.instance.doingSetup)
        {
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }
            offset = transform.position - player.transform.position;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!GameManager.instance.doingSetup)
        {
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }
            else
            {
                //transform.rotation = player.transform.rotation;
                transform.position = player.transform.position + offset;
                offset = Quaternion.AngleAxis(Input.GetAxis("Horizontal")*player.GetComponent<PlayerController>().turnSpeed, Vector3.up)*offset;

                //transform.position = player.transform.position + offset;
                //transform.LookAt(player.transform);
                //transform.LookAt(player.transform);
            }
        }
    }
}
