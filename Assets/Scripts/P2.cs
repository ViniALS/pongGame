using UnityEngine;

public class P2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speedP2 = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         bool isWPressed = Input.GetKey(KeyCode.UpArrow);
        bool isSPressed = Input.GetKey(KeyCode.DownArrow);

        if (isWPressed)
        {
            transform.Translate(Vector2.up * Time.deltaTime * speedP2);
        }

        if (isSPressed)
        {
            transform.Translate(Vector2.down * Time.deltaTime * speedP2);
        }
    }
}
