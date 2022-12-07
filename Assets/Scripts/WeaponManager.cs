using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    Actions input;
    [SerializeField]private GameObject Cam, particle;
    [SerializeField]float range = 100f,damage=20f,debugRange=5,HeatLimit=100;
    public float Heat = 30;
    private bool isReloading;
    [SerializeField]UIManager uIManager;
    #region InputActions
    private void OnEnable()
    {
        input = new Actions();
        input.Player.Enable();
        input.Player.Fire.performed += Fire;
        input.Player.Reload.performed += Relode;       
    }
    private void OnDisable()
    {
        input.Player.Disable();
        input.Player.Fire.performed -= Fire;
        input.Player.Reload.performed -= Relode;
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        uIManager.ammo = Heat;
    }
    void Relode(InputAction.CallbackContext context)
    {
        isReloading = true;
        Heat = 30;
        StartCoroutine(Reloading());
    }
    IEnumerator Reloading()
    {
        yield return new WaitForSeconds(3);
        isReloading = false;
    }
    void Fire(InputAction.CallbackContext context)
    {
        if (Heat <= HeatLimit&&!isReloading)
        {
           Instantiate(particle);
            particle.transform.position = gameObject.transform.position;
            RaycastHit hit;
            if (Physics.Raycast(Cam.transform.position, transform.forward, out hit, range))
            {
                Debug.DrawRay(Cam.transform.position, transform.forward * debugRange, Color.red, 5);
                Heat += 0.5f;

                EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();
                if (enemyManager != null)
                {

                    enemyManager.Hit(damage);
                    Debug.Log("hit");

                }
            }
        }
    }
}
