using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //Player Stats/Info =======================
    [SerializeField]
    private float speed = 1f;
    public VectorValue startingPosition;
    public GameObject plot;
    public GameObject inventoryPanel;
    public GameObject buttonTip;
    public InventoryController inventoryController;
    //------------------------------------------

    //UI Canvases ------------------------------
    private GameObject inventoryMenu;
    private GameObject infoMenu;
    //------------------------------------------

    //UI Elemends ------------------------------
    private GameObject currentInv;
    private GameObject currentButton;
    private GameObject interactObject;
    //------------------------------------------

    private bool facingRight = false;
    private bool farm = false;
    private bool inv = false;

    private GameObject[] plots = new GameObject[9];
    private Vector3 mousePos = Vector3.zero;
    private Vector3 prevMouse = Vector3.zero;
    private Vector2 direction = Vector2.zero;
    private Vector2 velocity;

    private Rigidbody2D rb;
    public CircleCollider2D collider;
    public CircleCollider2D interactCheck;
    
    private Animator animator;
    //private InventoryMenu inventoryMenu;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        inventoryMenu = GameObject.Find("Inventory Menu");
        infoMenu = GameObject.Find("Info Menu");
        transform.position = startingPosition.initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        mousePos = Input.mousePosition;

        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mousePos);
        worldPoint.z = 0f;
        mousePos.z = 0f;

        if (Input.GetKeyDown(KeyCode.E) && interactObject != null){
            Interactable interactable = interactObject.GetComponent<Interactable>();
            interactable.Interact();
        }

        if (Input.GetKeyDown(KeyCode.T)){
            OpenInventory(mousePos);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (farm)
            {
                farm = false;
                for (int i = 0; i < plots.Length; i++)
                {
                    Destroy(plots[i]);
                }
            }
            else
            {
                farm = true;
                Vector3 temp = worldPoint;
                for (int i = 0; i < plots.Length; i++)
                {
                    switch (i)
                    {
                        case 1:
                            temp.x = worldPoint.x - 1;
                            temp.y = worldPoint.y + 1;
                            plots[i] = Instantiate(plot, temp, Quaternion.identity);
                            break;
                        case 2:
                            temp.x = worldPoint.x;
                            temp.y = worldPoint.y + 1;
                            plots[i] = Instantiate(plot, temp, Quaternion.identity);
                            break;
                        case 3:
                            temp.x = worldPoint.x + 1;
                            temp.y = worldPoint.y + 1;
                            plots[i] = Instantiate(plot, temp, Quaternion.identity);
                            break;
                        case 4:
                            temp.x = worldPoint.x - 1;
                            temp.y = worldPoint.y;
                            plots[i] = Instantiate(plot, temp, Quaternion.identity);
                            break;
                        case 5:
                            temp.x = worldPoint.x + 1;
                            temp.y = worldPoint.y;
                            plots[i] = Instantiate(plot, temp, Quaternion.identity);
                            break;
                        case 6:
                            temp.x = worldPoint.x - 1;
                            temp.y = worldPoint.y - 1;
                            plots[i] = Instantiate(plot, temp, Quaternion.identity);
                            break;
                        case 7:
                            temp.x = worldPoint.x;
                            temp.y = worldPoint.y - 1;
                            plots[i] = Instantiate(plot, temp, Quaternion.identity);
                            break;
                        case 8:
                            temp.x = worldPoint.x + 1;
                            temp.y = worldPoint.y - 1;
                            plots[i] = Instantiate(plot, temp, Quaternion.identity);
                            break;
                        default:
                            plots[i] = Instantiate(plot, worldPoint, Quaternion.identity);
                            break;
                    }
                }
            }
        }

        if (farm)
        {
            for(int i = 0; i < plots.Length; i++)
            {
                Vector3 temp = worldPoint - prevMouse;
                plots[i].transform.position += temp;
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (farm)
            {
                farm = false;
            }
        }

        prevMouse = worldPoint;
    }

    void FixedUpdate()
    {
        if ((facingRight && direction.x < -0.01) || (!facingRight && direction.x > 0.01)) Flip();

        velocity = direction.normalized * speed;

        animator.SetFloat("Movement", velocity.magnitude);
        animator.SetBool("facingRight", facingRight);

        rb.MovePosition((Vector2)transform.position + velocity * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Interactable")){
            if(interactObject != null){
                // Debug.Log("IM HERE");
                Interactable interactable = interactObject.GetComponent<Interactable>();
                interactable.RemoveTip();
            }
        }
    }

    public void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("Interactable")){
            // Debug.Log("IM THERE");
            interactObject = other.gameObject;
            Interactable interactable = other.gameObject.GetComponent<Interactable>();

            interactable.ShowTip();
        }
    }

    public void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Interactable")){
            Interactable interactable = other.gameObject.GetComponent<Interactable>();
            interactable.RemoveTip();
            interactObject = null;
        }
    }

    void Use(){

    }

    void OpenInventory(Vector3 mouse){
        Vector3 panelPos = Vector3.zero;

        if(!inv)
        {
            //inventoryMenu.SetActive(!inv);
            if(mouse.x + 235 > Screen.width){
                panelPos.x = mouse.x - 235/2;
            }else{
                panelPos.x = mouse.x + 235/2;
            }

            if(mousePos.y + 45 > Screen.height){
                panelPos.y = mouse.y - 45/2;
            }else{
                panelPos.y = mouse.y + 45/2;
            }
            currentInv = Instantiate(inventoryPanel, panelPos, Quaternion.identity);
            currentInv.transform.SetParent(inventoryMenu.transform);
        }
        else
        {
            Destroy(currentInv);
            //inventoryMenu.SetActive(inv);
        }
        inv = !inv;
    }

    void Flip()
    {
        facingRight = !facingRight;
    }
}