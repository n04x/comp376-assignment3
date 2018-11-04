using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
   public Transform cameraTransform;
   public float shakeTimer = 0.0f;
   public float shakeAmount = 0.7f;
   public float decreaseFactor = 1.0f;

   Vector3 originalPosition;

   private void Awake() {
       cameraTransform = GetComponent<Transform>();
   }
   private void OnEnable() {
       originalPosition = cameraTransform.localPosition;
   }

   private void Update() {
       if(shakeTimer > 0) {
           cameraTransform.localPosition = originalPosition + Random.insideUnitSphere * shakeAmount;
           shakeTimer -= Time.deltaTime * decreaseFactor;
       }
       else {
           shakeTimer = 0.0f;
           cameraTransform.localPosition = originalPosition;
       }
   }

   public void FoxIsHit() {
       shakeTimer = 1.5f;
   }
}
