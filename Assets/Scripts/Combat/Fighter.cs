using System.Collections;
using System.Collections.Generic;
using RPG.Movement;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float weaponRange = 2f;
        Transform target;

        private void Update()
        {       
            if(target != null)
            {
                float distance = Vector3.Distance(GetComponent<NavMeshAgent>().transform.position, target.position);
                GetComponent<Mover>().MoveTo(target.position);
                if(distance <= weaponRange)
                {
                    GetComponent<Mover>().Stop();
                }
            }   
        }

        public void Attack(CombatTarget combatTarget)
        {
            if(combatTarget != null)
            target = combatTarget.transform;
            else
            target = null;
        }
    }
}
