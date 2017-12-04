// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

#if UNITY_EDITOR || UNITY_WSA
using UnityEngine.VR.WSA.Input;
#endif

namespace HoloToolkit.Examples.SpatialMappingComponent
{
    /// <summary>
    /// Simple test script for dropping cubes with physics to observe interactions
    /// </summary>
    public class DropCube : MonoBehaviour
    {
#if UNITY_EDITOR || UNITY_WSA
        GestureRecognizer recognizer;

        private void Start()
        {
            recognizer = new GestureRecognizer();
            recognizer.SetRecognizableGestures(GestureSettings.Tap);
            recognizer.TappedEvent += Recognizer_TappedEvent;
            recognizer.StartCapturingGestures();
        }

        private void OnDestroy()
        {
            recognizer.TappedEvent -= Recognizer_TappedEvent;
        }

        private void Recognizer_TappedEvent(InteractionSourceKind source, int tapCount, Ray headRay)
        {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube); // Create a cube
            cube.transform.localScale = Vector3.one * 0.3f; // Make the cube smaller
            cube.transform.position = Camera.main.transform.position + Camera.main.transform.forward; // Start to drop it in front of the camera
            cube.AddComponent<Rigidbody>(); // Apply physics
        }
#endif
    }
}