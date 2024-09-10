using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using MonoBehaviour = UnityEngine.MonoBehaviour;

public class Player : MonoBehaviour
{
    public int velocidade = 10;
    public int forçaPulo = 7;
    public bool noChao;
    
    public Rigidbody rb;

    private AudioSource souce; 
    
    void Start()
    {
        TryGetComponent(out rb);

        TryGetComponent(out souce);

    }

    private void OnCollisionExit(Collision other)
    {
        if (!noChao && other.gameObject.tag == "Chão")
        {
            noChao = false;
        }
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Chão")
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

        if (Input.GetKeyDown(KeyCode.Space) &&  noChao)
        {
            //pulo
            
            souce.Play();
            
            
            rb.AddForce(Vector3.up * forçaPulo, ForceMode.Impulse);
            noChao = false;
        }
        
        
        
        
        if (transform.position.y < -5)
            
            
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}



////-----------------------



