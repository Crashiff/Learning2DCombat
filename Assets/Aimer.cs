using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aimer : MonoBehaviour
{

    private Camera m_MainCam;
    private Vector3 m_CurrentMousePosition;
    public GameObject slash;
    public Transform GetsugaTenshou;
    public bool canFire;
    private float timeSinceSlash;
    public float slashCooldown;

    void Start()
    {
        m_MainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        m_CurrentMousePosition = m_MainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotationChange = m_CurrentMousePosition - transform.position;
        float zAxis = Mathf.Atan2(-rotationChange.y, -rotationChange.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, zAxis);

        if (!canFire)
        {
            timeSinceSlash += Time.deltaTime;
            if (timeSinceSlash > slashCooldown)
            {
                canFire = true;
                timeSinceSlash = 0;
            }
        }

        if (Input.GetMouseButton(1) && canFire)
        {
            Instantiate(slash, GetsugaTenshou.position, Quaternion.identity);
            canFire = false;
        }
    }
}
