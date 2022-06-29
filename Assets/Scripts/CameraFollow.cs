using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTranform;

    public float speed;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = playerTranform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTranform != null)
        {
            float clampedX = Mathf.Clamp(playerTranform.position.x, minX, maxX);

            float clampedY = Mathf.Clamp(playerTranform.position.y, minY, maxY);

            transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX, clampedY), speed);
        }
    }
}
