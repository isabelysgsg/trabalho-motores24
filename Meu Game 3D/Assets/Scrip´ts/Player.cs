using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using MonoBehaviour = UnityEngine.MonoBehaviour;

public class Player : MonoBehaviour
{
    public int velocidade = 10;
    public Rigidbody rb;
    public int forcaPulo = 10;
    public bool noChao = true;

    void Start()
    {
        TryGetComponent(out rb);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "chão")
        {
            noChao = true;
        }
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        Vector3 direcao = new Vector3(h,0,v);
        rb.AddForce(direcao * velocidade * Time.deltaTime, ForceMode.Impulse);
        if (transform.position.y < -5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}



////-----------------------



