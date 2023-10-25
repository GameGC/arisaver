// <auto-generated/>
using UnityEngine;
using UnityEngine.Animations.Rigging;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

namespace UnityEngine.Animations.Rigging.Saving
{
    public class ChainIKConstraintSaver : MonoBehaviour
    {
        [SerializeField] private string[] transformPathes = new string[PropertyCount];
        [SerializeField] private  ChainIKConstraint target;
        
        private const int PropertyCount = 3;
    
        private void Awake()
        {
            var root = transform.root;
            
            if (!string.IsNullOrEmpty(transformPathes[0]))
                target.data.root = root.FindAnywhere(transformPathes[0]);
            if (!string.IsNullOrEmpty(transformPathes[1]))
                target.data.tip = root.FindAnywhere(transformPathes[1]);
            if (!string.IsNullOrEmpty(transformPathes[2]))
                target.data.target = root.FindAnywhere(transformPathes[2]);

            Destroy(this);
        }
        
    #if UNITY_EDITOR
        private void OnValidate()
        {
            if (!ComponentsHelpers.CouldValidate(target)) return;
            var trList = new[] {target.data.root,target.data.tip,target.data.target};
             for (int i = 0; i < PropertyCount; i++)
            {
                if(trList[i])
                    transformPathes[i] = AnimationUtility.CalculateTransformPath(trList[i], transform.root);
            }
           
        }
    
        private void Reset() => OnValidate();
    
        [MenuItem("CONTEXT/ChainIKConstraint/Transfer motion to smth", false, 612)]
        public static void TransferMotionToConstraint(MenuCommand command)
        {
            var sourceScript = command.context as ChainIKConstraint;
            var thisScript = sourceScript.gameObject.AddComponent< ChainIKConstraintSaver>();
            thisScript.target = sourceScript;
            thisScript.Reset();
        }

 		
    #endif
        }
    }