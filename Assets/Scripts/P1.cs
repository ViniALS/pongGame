using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;

public class P1 : MonoBehaviour
{
    public float speedP1 = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isWPressed = Input.GetKey(KeyCode.W);
        bool isSPressed = Input.GetKey(KeyCode.S);

        if (isWPressed)
        {
            transform.Translate(Vector2.up * Time.deltaTime * speedP1);
        }

        if (isSPressed)
        {
            transform.Translate(Vector2.down * Time.deltaTime * speedP1);
        }
    }
}
