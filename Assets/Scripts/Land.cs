using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Land : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    


    // Start is called before the first frame update
    void Start()
    {
        
        meshRenderer = GetComponent<MeshRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        float speed = GameManager.Instance.gameSpeed / transform.localScale.x;
        meshRenderer.material.mainTextureOffset += speed * Time.deltaTime * Vector2.right;
        
    }

    
}
