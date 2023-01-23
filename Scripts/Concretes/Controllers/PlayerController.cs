using System.Collections;
using System.Collections.Generic;
using UdemyProject2.Abstracts.Inputs;
using UdemyProject2.Animations;
using UdemyProject2.Combats;
using UdemyProject2.Concretes.Combats;
using UdemyProject2.Concretes.input;
using UdemyProject2.Concretes.Movements;
using UdemyProject2.Inputs;
using UdemyProject2.Uİs;
using UnityEngine;

namespace UdemyProject2.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float speed = 5f;
        float _horizontal;
        float _vertical;
        SpriteRenderer _spriteRenderer;

        bool _isJump;
        Flip _flip;
        Mover _mover;
        IPlayerInput _input;
        Jump _jump;
        CharacterAnimation _characterAnimation;
        OnGround _onGround;
        Climbing _climbing;
        Damage _damage;
        Health _health;


        //hız 0 dan büyükse animasyonun içinde kalacak

        private void Awake()
        {
            _characterAnimation = GetComponent<CharacterAnimation>();
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>(); // player üzerinde sprite renderer  yok. childeren üzerinde var
                                                                        // child üzerindekine ulaşmak için "InChildren" kullandık
            _input = new MobileInput();
            _mover = GetComponent<Mover>();
            _jump = GetComponent<Jump>();
            _flip = GetComponent<Flip>();
            _climbing = GetComponent<Climbing>();
            _onGround = GetComponent<OnGround>();
            _health = GetComponent<Health>();
        }
        private void Start()
        {
            GameCanvas gameCanvas = FindObjectOfType<GameCanvas>();

            if(gameCanvas != null)
            {
                _health.OnDead += gameCanvas.ShowGameOverPanel;
            }

        }
        private void Update()  //update içerisinde okuma işlemleri yapılır
        {
            _horizontal = _input.Horizontal;
            _vertical = _input.Vertical;

            if (_input.IsJump && _onGround.IsOnGround && !_climbing.IsClimbing)
            {
                _isJump = true;
            }




            _characterAnimation.CharacterMove(_horizontal);
            _characterAnimation.CharacterJump(!_onGround.IsOnGround && _jump.isJumpAction);  //ilkinde onGround olup olmamasına göre animasyon döndürüyor // ikincisinde vector2 0 değilse zıplamasını istedik   
            _characterAnimation.CharacterClimb(_climbing.IsClimbing);




            //if (Input.GetKey(KeyCode.A)) {  
            //    transform.position += Vector3.left * Time.deltaTime * speed;
            //}
            //else if (Input.GetKey(KeyCode.D))                                 //karakterin yapacağı hareketi horizontal üzerinden alma
            //{
            //    transform.position += Vector3.right * Time.deltaTime * speed;
            //} // karakterin yapacağı hareket ile ilgili 

            //if (Mathf.Sign(horizontal) > 0)
            //{
            //    _spriteRenderer.flipX = false;
            //}
            //else
            //{
            //    _spriteRenderer.flipX = true;
            //}
            //_spriteRenderer.flipX = Mathf.Sign(horizontal) > 0 ? false : true; // karakterin yönü ile ilgili (_spriterenderer.flipX)

        }

        private void FixedUpdate()  //hareket işlemleri FixedUpdate de yapılır
        {

            _climbing.ClimbAction(_vertical);
            _mover.HorizontalMove(_horizontal);
            _flip.FlipCharacter(_horizontal);             // x ekseninde karakteri terse çevirme( LocaleScaler kullanarak)

            if (_isJump)
            {
                _jump.JumpAction();
                _isJump = false;
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Damage damage = collision.collider.GetComponent<Damage>();

            if (damage != null)
            {
                _health.TakeHit(damage); return;
            }



        }

    }


}

