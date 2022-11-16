using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slashScript : MonoBehaviour
{
    private Vector3 currentMousePosition;
    private Camera mainCamera;
    private Rigidbody2D rb;
    public float force;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsSolid;

    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        currentMousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = currentMousePosition - transform.position;
        Vector3 rotation = transform.position - currentMousePosition;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        Invoke("DestroyTenshou", lifeTime);
    }

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                Debug.Log("Enemy hit");

            }
            DestroyTenshou();
        }
    }


    void DestroyTenshou()
    {
        Destroy(gameObject);
    }
}
