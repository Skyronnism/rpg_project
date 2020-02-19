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
                //int position = 0;
                //var positionList = new List<int>();
                // RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
                // foreach(RaycastHit hit in hits)
                // {
                //     if (hit.transform.GetComponent<CombatTarget>() != null)
                //     {
                //         //positionList.Add(position);
                //         CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                //         GetComponent<Fighter>().Attack(target);
                //     }
                //     //position = position + 1;
                // }
                //RaycastHit Closer = MeasureDistance(positionList, hits);
        }

        // private RaycastHit MeasureDistance(List<int> positionList, RaycastHit[] hits)
        // {
        //     Vector3 playerPosition = GetComponent<Transform>().position;
        //     var distanceList = new List<float>();
        //     int listPos = 0;
        //     foreach(int position in positionList)
        //     {
        //         distanceList.Add(Vector3.Distance(hits[positionList[position]].transform.position, playerPosition));
        //     }
        //     distanceList.Sort();
        //     distanceList.ForEach(Console.WriteLine);
        //     listPos = 0;
        //     int closerPos = 0;
        //     foreach(int position in positionList)
        //     {
        //         if(Vector3.Distance(hits[positionList[listPos]].transform.position, playerPosition) == distanceList[0]){
        //         closerPos = listPos;
        //         }
        //         listPos = listPos + 1;
        //     }
        //     return (hits[positionList[closerPos]]);
        // }

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
                        GetComponent<Mover>().MoveTo(hit.point);
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

