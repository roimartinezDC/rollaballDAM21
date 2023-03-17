using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float velocidadRotacion;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Transform transformPersonaje;
    [SerializeField] private Camera camaraPersonaje;
    public static int puntuacion;

    private Vector3 movimiento;
    private float rotacionX;

    private void Start()
    {
        puntuacion = 0;
    }

    void MovimientoPersonaje()
    {
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");
        
        movimiento = transform.right * movX + transform.forward * movZ;
        characterController.SimpleMove(movimiento * velocidadMovimiento);
        
        
        if (Input.GetButtonDown("Jump") && (gameObject.transform.position.y <= 1))
        {   
            gameObject.transform.position += new Vector3(0, 0.7f, 0);
        }
        
    }

    void MovimientoCamara()
    {
        float ratonX = Input.GetAxis("Mouse X") * velocidadRotacion;
        float ratonY = Input.GetAxis("Mouse Y") * velocidadRotacion;

        rotacionX -= ratonY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);
        
        camaraPersonaje.transform.localRotation = Quaternion.Euler(rotacionX, 0, 0);
        transformPersonaje.Rotate(Vector3.up * ratonX);
    }
    
    void Update()
    {
        MovimientoPersonaje();
        MovimientoCamara();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            puntuacion++;
        } else if (other.gameObject.CompareTag("teleport"))
        {
            gameObject.transform.position = new Vector3(-3.7f, 0.5f, -14.8f);
            if (puntuacion < 3)
            {
                GameObject[] monedas = GameObject.FindGameObjectsWithTag("pickup");
                foreach(GameObject moneda in monedas) {
                    moneda.SetActive(true);
                }
                puntuacion = 0;
            }
            else
            {
                GameObject muro = GameObject.FindGameObjectWithTag("falsewall");
                muro.SetActive(false);
            }
        }
    }
}
