using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { UP, DOWN, RIGHT, LEFT }

public class RoomTransition : MonoBehaviour
{
    public Vector2 cameraChange;
    public float playerChangeDist;
    private Vector3 playerChange;
    //public Direction direction;
    public Direction direction;

    private CameraMovement cam;
    
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerChange = Vector3.zero;
            if(direction == Direction.UP)
            {
                playerChange.y += playerChangeDist;
            }
            else if(direction == Direction.DOWN)
            {
                playerChange.y -= playerChangeDist;
            }
            else if(direction == Direction.LEFT)
            {
                playerChange.x -= playerChangeDist;
                cam.maxPos -= cameraChange;
                cam.minPos -= cameraChange;
            }
            else if(direction == Direction.RIGHT)
            {
                playerChange.x += playerChangeDist;
                cam.maxPos += cameraChange;
                cam.minPos += cameraChange;
            }

            other.transform.position += playerChange;
        }
    }
}
