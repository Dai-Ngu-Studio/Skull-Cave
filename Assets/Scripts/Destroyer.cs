using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float lifeTime;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
