using UnityEngine;
using Yarn.Unity;
using UnityEngine.InputSystem;

// [RequireComponent(typeof(CharacterControlsMap))]
public class PlayerControler : MonoBehaviour
{
    public float speed;
    public float groundDist;
    public Animator animator;
//    private CharacterControlsMap controller;
    public LayerMask terrainLayer;
    public Rigidbody rb;
    public float rotatespeed;
    
    private Vector2 movementInput = Vector2.zero;

    [SerializeField] private LineView lineView;
    
    private bool canMove;
    // Start is called before the first frame update
    void Awake()
    {
        //controller = new CharacterControlsMap();
        //controller.Enable();
        rb = gameObject.GetComponent<Rigidbody>();
        // Ziet de speler en maakt het lichaam
        canMove = true;
    }

    public void OnMove(InputAction.CallbackContext context){
        movementInput = context.ReadValue<Vector2>();
    }
    public void SetCanMove(bool value)
    {
        canMove = value;
    }

    public void OnDialogClicked(InputAction.CallbackContext context) {
        // if(!lineView.gameObject.active) return;
        // lineView.OnContinueClicked();
    }

    // Update is called once per frame
    void Update()
    {
        
        //dit gebruik je als je de interact knop samen wilt voegen met een andere interactie

        // Ziet hoogte en laagte verschillen in het 3d veld en zorgt dat hij en pixel boven de grond zweeft.
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;
        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            if (hit.collider != null) 
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundDist;
                transform.position = movePos;
            }
        }

        float x = 0.0f;
        float y = 0.0f;
        Vector3 moveDir = Vector3.zero;

        if( canMove) 
        {
            x = movementInput.x;
            y = movementInput.y;
            moveDir = new Vector3(movementInput.x, 0, movementInput.y);
            rb.velocity = moveDir * speed;    
        }
        
        animator.SetFloat("Speed",(Mathf.Abs(x) + Mathf.Abs(y))/2);

       
        if(moveDir == Vector3.zero) return;
        moveDir.Normalize();
        Quaternion toRotatation = Quaternion.LookRotation(moveDir,Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation,toRotatation,rotatespeed*Time.deltaTime);

        

    }
}