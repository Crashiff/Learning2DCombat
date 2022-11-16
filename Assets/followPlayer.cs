using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public float cameraSpeed;
    public Transform targetToFollow;
    public float yOffset;
    Vector3 currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        currentPosition = new Vector3(targetToFollow.position.x, targetToFollow.position.y, -10f);
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition.x = targetToFollow.position.x;
        currentPosition.y = targetToFollow.position.y + yOffset;
        transform.position = Vector3.Slerp(transform.position, currentPosition, cameraSpeed * Time.deltaTime);
    }
}
