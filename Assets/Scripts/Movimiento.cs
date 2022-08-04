using System;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] float velocidad = 2f;

    public void MovVertical(Vector3 direccion, Animator animacion)
    {
        animacion.SetFloat("Walk", Math.Abs(direccion.z));
        if (direccion.z > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.Translate(0, 0, direccion.z * Time.deltaTime * velocidad);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.Translate(0, 0, direccion.z * Time.deltaTime * -velocidad);
        }

    }
    public void MovHorizontal(Vector3 direccion, Animator animacion)
    {
        animacion.SetFloat("Walk", Math.Abs(direccion.x));
        if (direccion.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
            transform.Translate(0, 0, direccion.x * Time.deltaTime * velocidad);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 270, 0);
            transform.Translate(0, 0, direccion.x * Time.deltaTime * -velocidad);
        }
    }
}
