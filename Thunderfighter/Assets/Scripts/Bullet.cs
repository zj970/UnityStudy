using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public float yLimit = 6.3f;

    private void Update()
    {

        this.transform.position += Vector3.up * speed * Time.deltaTime;
        if (this.transform.position.y > yLimit)
        {
            Destroy(this.gameObject);
        }

    }
}