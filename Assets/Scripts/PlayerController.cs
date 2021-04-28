using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] public float speed = 300.0f;
    public Vector2 lastMovement = Vector2.right;
    public static bool PlayerCreated;
    public string nextPlaceName;
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string Lasthorizontal = "LastHorizontal";
    private const string Lastvertical = "LastVertical";
    private const string Walking = "Walking";
    private Animator _animator;
    private Rigidbody2D _playerRigidBody;
    private bool _walking = false;
    private static readonly int AnimHorizontal = Animator.StringToHash(Horizontal);
    private static readonly int AnimVertical = Animator.StringToHash(Vertical);
    private static readonly int AnimWalking = Animator.StringToHash(Walking);
    private static readonly int AnimLastHorizontal = Animator.StringToHash(Lasthorizontal);
    private static readonly int AnimLastVertical = Animator.StringToHash(Lastvertical);
    private AudioSource[] _footstep;


    private void Start()
    { 
        
        _animator = GetComponent<Animator>();
        _playerRigidBody = GetComponent<Rigidbody2D>();

        //_playerRigidBody.isKinematic = false;
        _playerRigidBody.angularDrag = 0.0f;
        _playerRigidBody.gravityScale = 0.0f;

        _footstep = GetComponents<AudioSource>();
    }
    
    private void PlaySound(){
        _footstep[0].Play();
    }
    private void PlaySound2(){
        _footstep[1].Play();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _walking = false;
        if (Mathf.Abs(Input.GetAxisRaw(Horizontal)) >= 0.5f && Mathf.Abs(Input.GetAxisRaw(Vertical)) >= 0.5f)
        {
            _walking = true;
            lastMovement = new Vector2(Input.GetAxisRaw(Horizontal), Input.GetAxisRaw(Vertical));
        }
        else 
        {
            if (Mathf.Abs(Input.GetAxisRaw(Horizontal)) >= 0.5f)
            {
                _walking = true;
                lastMovement = new Vector2(Input.GetAxisRaw(Horizontal),0);
            }
            if (Mathf.Abs(Input.GetAxisRaw(Vertical)) >= 0.5f)
            {
                _walking = true;
                lastMovement = new Vector2(0,Input.GetAxisRaw(Vertical));
                
            }
        }

        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw(Horizontal), Input.GetAxisRaw(Vertical));
        _playerRigidBody.velocity = targetVelocity * (speed * Time.deltaTime);

        _animator.SetFloat(AnimHorizontal,Input.GetAxisRaw(Horizontal));
        _animator.SetFloat(AnimVertical,Input.GetAxisRaw(Vertical));
        _animator.SetBool(AnimWalking, _walking);
        _animator.SetFloat(AnimLastHorizontal, lastMovement.x);
        _animator.SetFloat(AnimLastVertical, lastMovement.y);

    }



    private void OnTriggerEnter2D(Collider2D collision) {

    }

    private void OnTriggerExit2D(Collider2D collision){

    }
}
