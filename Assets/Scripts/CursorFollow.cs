using UnityEngine;

public class CursorFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }
}
