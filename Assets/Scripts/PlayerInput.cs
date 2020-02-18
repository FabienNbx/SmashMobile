using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector]
    public int direction;
    [HideInInspector]
    public bool jump;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = 0;
        direction += Input.GetKey(KeyCode.RightArrow)?1:0;
        direction += Input.GetKey(KeyCode.LeftArrow) ? -1 : 0;
        jump = Input.GetKey(KeyCode.Space);
    }
}
