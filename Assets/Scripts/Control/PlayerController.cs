using UnityEngine;
using RPG.Movement;
using RPG.Combat;
using System;
using System.Collections.Generic;

namespace RPG.Control 
{
    public class PlayerController : MonoBehaviour
    {

        void Update()
        {
            if(InteractWithCombat()) return;
            InteractWithMovement();
        }

        private bool InteractWithCombat()
        {
                bool hasTarget = Physics.Raycast(GetMouseRay(), out RaycastHit hit);
                if(hasTarget == false) return false;
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target != null)
                    {
                        if(Input.GetMouseButtonDown(0)) 
                        {
                        GetComponent<Fighter>().Attack(target);
                        }
                        return true;
                    }
                else
                    return false;
        }

        private void InteractWithMovement()
        {
            if(MoveToCursor()) return;
            print("nothing to do");
        }

        public bool MoveToCursor()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit)
            {
                    if (Input.GetMouseButton(0))
                    {
                        //GetComponent<Fighter>().Attack(null);
                        GetComponent<Mover>().ControllerMoveTo(hit.point);
                        return true;
                    }
                return true;
            }
            else
            return false;
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}

