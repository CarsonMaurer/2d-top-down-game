using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _sideMoveSpeed = 5f;
    [SerializeField] private float _xRange = 4.8f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(LevelManager.Instance.StartGame())
      {
          CarMovement();
      }
    }

    private void CarMovement()
    {
          float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.up * _moveSpeed * Time.deltaTime);
            transform.Translate(Vector3.right * _sideMoveSpeed * horizontalInput * Time.deltaTime);
            if(transform.position.x > _xRange)
            {
                transform.position = new Vector3(_xRange, transform.position.y, transform.position.z);
           
            }
            if(transform.position.x < -_xRange)
            {
                transform.position = new Vector3(-_xRange, transform.position.y, transform.position.z);
            }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            LevelManager.Instance.GameOver();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Start Line"))
        {

        }
        if(other.gameObject.CompareTag("Finish Line"))
        {
            
        }
    }
}
