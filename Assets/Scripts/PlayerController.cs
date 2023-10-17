using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput; // переменная для считывания движения

    private Rigidbody2D rb;

    private bool facingRight = true; // игрок смотрит вправо

    private bool isGrounded; // приземлился ли игрок
    public Transform feetPos; // берем позицию ног игрока
    public float checkRadius; // берем радиус, насколько близко игрок должен находится к земле
    public LayerMask whatIsGround; // и что мы берем за землю?

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); // знакомим наш скрипт с компонентом игрока
    }

    private void FixedUpdate() // данная функция будет взаимодействовать с каждым кадром когда мы находимся в игре
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y); // скорость нашего компонента RigidBody2D

        if (facingRight == false && moveInput > 0)
            Flip();
        else if (facingRight == true && moveInput < 0)
            Flip();

        if (moveInput == 0)
            anim.SetBool("isRunning", false);
        else
            anim.SetBool("isRunning", true);
    }

    private void Update()
    {      // сюда мы записываем что приземление игрока это Physics2D.OverlapCircle()
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("takeOf");
        }

        if (isGrounded == true)
            anim.SetBool("isJumping", false);
        else
            anim.SetBool("isJumping", true);
    }

    private void Flip()
    {
        facingRight = !facingRight; // поворот игрока
        Vector3 Scaler = transform.localScale; // берем оригинальное положение нашего игрока
        Scaler.x *= -1; 
        transform.localScale = Scaler; // применяем наши изменения


        // делаем так чтобы наш персонаж поварачивался из-за бага после того как мы поставили анимации, 
        if (moveInput < 0)
            transform.eulerAngles = new Vector3(0, 180, 0);
        else if (moveInput > 0)
            transform.eulerAngles = new Vector3(0, 0, 0);
        
    }
}
