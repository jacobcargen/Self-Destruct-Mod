using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Self_Destruct_Mod
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class SelfDestructController : MonoBehaviour
    {
        private Vessel ves;
        private KeyCode modifierKey = KeyCode.LeftAlt;
        private KeyCode explodeKey = KeyCode.Delete;

        private bool modifierPressed;

        private void Start()
        {
            Debug.Log("Self Destruct Ready!");
            ves = FlightGlobals.ActiveVessel;

            // Check if pressed at the start
            if (Input.GetKey(modifierKey))
            {
                modifierPressed = true;
            }
        }
        private void Update()
        {
            // Modifier Press
            if (Input.GetKeyDown(modifierKey))
            {
                // Disable abort while holding left alt
                modifierPressed = true;
            }
            // If self destruct key and modifier
            if (modifierPressed && Input.GetKeyDown(explodeKey))
            {
                // Self destruct the ship
                SelfDestruct();
            }
            // Modifier Release
            if (Input.GetKeyUp(modifierKey))
            {
                // Revert once alt is released
                modifierPressed = false;
            }
        }
        private void SelfDestruct()
        {
            Debug.Log("Self Destructing!");

            for (int i = ves.parts.Count - 1; i >= 0; i--)
            {
                Part part = ves.parts[i];
                part.explode();
            }
        }
    }
}