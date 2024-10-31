using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossStageInitionControllerSystem : MonoBehaviour
{
    [SerializeField] private HeroMovementController player;

    [SerializeField] private Transform pointAcive;

    [SerializeField] private CinemachineVirtualCamera cameraForBossStage;

    [SerializeField] private CinemachineVirtualCamera playerCamera;

    [SerializeField] private float deadZoneWidth;

    [SerializeField] private float deadZoneHeight;

    [SerializeField] private Transform limitLeftPoint;

    [SerializeField] private Transform limitRightPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= pointAcive.position.x)
        {

            SetUpDeadZoneForPlayerCamera(deadZoneWidth, deadZoneHeight);

            LimitMovementRangeOfPlayer();

            ChangeCamera();

        }
        else {
            SetUpDeadZoneForPlayerCamera(0, 0);
        }
       

    }

    private void SetUpDeadZoneForPlayerCamera(float width, float height) {
        if (playerCamera != null)
        {

            playerCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_DeadZoneWidth = width;

            playerCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_DeadZoneHeight = height;

        }

    }

    private void LimitMovementRangeOfPlayer() {
        if (player != null)
        {

            player.LimitLeftPoint = limitLeftPoint;

            player.LimitRightPoint = limitRightPoint;
        }
    }

    private void ChangeCamera() {
        if (cameraForBossStage != null) { 
            cameraForBossStage.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    
}
