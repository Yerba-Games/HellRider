using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    Actions input;
    [SerializeField]private GameObject Cam;
    [SerializeField] float range = 100f,damage=20f;
    #region InputActions
    private void OnEnable()
    {
        input = new Actions();
        input.Player.Enable();
        input.Player.Fire.performed += Fire;

    }
    private void OnDisable()
    {
        input.Player.Disable();
        input.Player.Fire.performed -= Fire;
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Fire(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        if (Physics.Raycast(Cam.transform.position, transform.forward, out hit, range))
        {
            EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();
            if (enemyManager!=null)
            {
                
                enemyManager.Hit(damage);
                Debug.Log("hit");

            }
        }
    }
}
