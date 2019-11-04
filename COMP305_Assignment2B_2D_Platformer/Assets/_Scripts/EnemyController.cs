using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Util
{
    public class EnemyController : MonoBehaviour
    {
        public Animator anim;
        public SpriteRenderer spriteRenderer;
        public float MoveSpeed;
        public Rigidbody2D rig;
        public Transform rayTarget;
        public Transform rayTarget2;
        public GameObject cherry;
        public bool FacingRight = true;
        public AudioSource deathSfx;

        public bool IsGrounded;
        public bool GroundAhead;
        public bool PlayerAbove;
      



        void Start()
        {

        }

        void Update()
        {

            PlayerCollide();
            IsGrounded = Physics2D.BoxCast(transform.position, new Vector2(1f, 0.5f), 0.0f, Vector2.down, 0.7f, 1 << LayerMask.NameToLayer("Grounded"));
            GroundAhead = Physics2D.Linecast(this.transform.position, rayTarget.position, 1 << LayerMask.NameToLayer("Grounded"));
          

            if (PlayerAbove)
            {

                Vector2 cherrySpawn = new Vector2(transform.position.x + 0.5f, transform.position.y + 1.0f);
                GameObject pickCherry = Instantiate(cherry, cherrySpawn, Quaternion.identity);
                Destroy(this.gameObject);

            }

            Physics2D.IgnoreLayerCollision(10, 10);

            Movement();
        }

        public bool PlayerCollide()
        {
            PlayerAbove = Physics2D.BoxCast(transform.position, new Vector2(0.5f, 0.8f), 0.0f, Vector2.up, 0.1f, 1 << LayerMask.NameToLayer("Player"));
            return PlayerAbove;
        }

        public void Movement()
        {
            if (!GroundAhead && IsGrounded)
            {
                this.transform.localScale = new Vector2(-this.transform.localScale.x, 3.0f);
                FacingRight = !FacingRight;
            }

            if (IsGrounded && FacingRight)
            {

                rig.velocity = new Vector2(MoveSpeed, 0.0f);

            }

            if (IsGrounded && !FacingRight)
            {

                rig.velocity = new Vector2(-MoveSpeed, 0.0f);

            }

        }
    }

}
