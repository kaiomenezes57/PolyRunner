using PolyRunner.Core;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace PolyRunner.Core
{
    public class RunBlockActiveHandler : MonoBehaviour
    {
        private readonly List<RunBlock> _runBlockList = new();

        private async void Start()
        {
            await Task.Delay(100);
            _runBlockList.AddRange(GetComponentsInChildren<RunBlock>());
            StartCoroutine(ActiveRoutineLoop());
        }

        private IEnumerator ActiveRoutineLoop()
        {
            while (true)
            {
                List<RunBlock> runBlockToActive = _runBlockList.Where(r => r.transform.position.z <= 28f).ToList();
                List<RunBlock> runBlockToDesactive = _runBlockList.Where(r => r.transform.position.z > 28f).ToList();

                runBlockToActive.ForEach(r => r.SetActiveVisual(true));
                runBlockToDesactive.ForEach(r => r.SetActiveVisual(false));

                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
