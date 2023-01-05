using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Self_Destruct_Mod
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class SelfDestructController
    {
        private bool selfDestruct;

        public void Start()
        {
            Debug.Log("Self Destruct Ready!");
        }
        public void Update()
        {
            // If player tries to self destruct
            selfDestruct = Input.GetKeyDown(KeyCode.Backspace) && Input.GetKey(KeyCode.LeftControl)
                && Input.GetKey(KeyCode.RightControl);
            // Self destruct the ship
            if (selfDestruct) SelfDestruct();
        }
        private void SelfDestruct()
        {
            Vessel ves = FlightGlobals.ActiveVessel;
            Debug.Log("Self Destruct!");
        }
    }
}