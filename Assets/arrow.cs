using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class arrow : MonoBehaviour
{
    Rigidbody rigidBody;
    Collider arrowCollider;
    GameObject thisArrow;
    MeshRenderer m_Material;

    public string direction;
    int directionNum;
    public float speed;

    public Material upMaterial;
    public Material downMaterial;
    public Material leftMaterial;
    public Material rightMaterial;

    // Start is called before the first frame update
    void Start()
    {
        LaunchArrow();
        //InvokeRepeating("LaunchArrow", 2.0f, 1.5f);
    }

    void LaunchArrow()
    {
       
        thisArrow = GetComponent<GameObject>();

        m_Material = GetComponent<MeshRenderer>();
        directionNum = Random.Range(1, 4);
        if (directionNum == 1)
        {
            m_Material.material = downMaterial;
            direction = "down";
        }
        else if (directionNum == 2)
        {
            m_Material.material = upMaterial;
            direction = "up";
        }
        else if (directionNum == 3)
        {
            m_Material.material = leftMaterial;
            direction = "left";
        }
        if (directionNum == 4)
        {
            m_Material.material = rightMaterial;
            direction = "right";
        }
        rigidBody = GetComponent<Rigidbody>();
        arrowCollider = GetComponent<Collider>();
        print(direction);
    }

    // Update is called once per frame
    void Update()
    {
        this.rigidBody.position += Vector3.down * speed;
        hitKey();
    }

    public void hitKey()
    {

    }

    public void despawn(bool outside)
    {
        if (outside == true)
            Destroy(gameObject, 0.25f);
        else
            Destroy(gameObject);
    }
}