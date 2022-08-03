using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace neat
{
    /// <summary>
    /// �I����ͦ�����
    /// </summary>
    [RequireComponent(typeof(ARRaycastManager))]
    public class TapToSpawnObject : MonoBehaviour
    {
        #region ���
        [SerializeField, Header("�n�ͦ�������")]
        private GameObject goSpawnObject;

        private ARRaycastManager arManager;
        private Vector2 touchPoint;
        private List<ARRaycastHit> hits = new List<ARRaycastHit>();
        private TrackableType trackableType;
        #endregion

        private void Awake()
        {
            arManager = GetComponent<ARRaycastManager>();
        }


        private void Update()
        {
            TapAndSpawn();
        }
        /// <summary>
        /// �I���P�ͦ�
        /// </summary>
        private void TapAndSpawn() 
        {
            // �p�G  �I��  ����οù�
            if (Input.GetKeyDown(KeyCode.Mouse0)) 
            {
                // �x�s�I���y��
                touchPoint = Input.mousePosition;
                // �g�u�޲z���A�g�u�I��(�y�СB�I������M��B����)
                if (arManager.Raycast(touchPoint, hits, TrackableType.PlaneWithinPolygon)) 
                {
                    // �x�s�g�u�I������Ĥ@�����y�и�T
                    Pose pose = hits[0].pose;
                    // �ͦ�(����B�y�СB����)
                    GameObject temp = Instantiate(goSpawnObject, pose.position, Quaternion.identity);
                    // ��v���y��
                    Vector3 cameraPos = transform.position;
                    // ��v�� Y �ͦ����� ��Y
                    cameraPos.y = temp.transform.position.y;
                    // �ͦ�����  ���V(��v���y��)
                    temp.transform.LookAt(cameraPos);

                }
            }
        
        }

    }

}

