using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAnimationScript : MonoBehaviour
{
    public enum BlendMode
    {
        Opaque,
        Cutout,
        Fade,
        Transparent
    }

    //To Manage Shader transparency
    public Transform checkTransparency;
    public float transparencyRadius = 0.2f;
    public LayerMask transparencyMask;
    public bool transparencyActivated = false;
    public Collider[] transparencyColliders;
    Collider[] transparencyCollidersSaved;

    Animator anim;
	int walkTreeHash = Animator.StringToHash("Base Layer.WalkTree");
	int runTreeHash = Animator.StringToHash("Base Layer.RunTree");

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
        //Transparency
        transparencyColliders = Physics.OverlapSphere(checkTransparency.position, transparencyRadius, transparencyMask);
        if (transparencyColliders.Length > 0)
        {
            transparencyActivated = true;
        }
        else
        {
            transparencyActivated = false;
        }   
        if (transparencyActivated)
        {
            foreach (Collider collideIn in transparencyColliders)
            {
                if (collideIn.name == "Rock1A")
                {
                    ChangeRenderMode(collideIn.gameObject.GetComponent<MeshRenderer>().material, BlendMode.Transparent);
                }
            }
        }
        else
        {
            if (transparencyCollidersSaved != null && transparencyCollidersSaved.Length > 0)
            {
                foreach (Collider collideIn in transparencyCollidersSaved)
                {
                    if (collideIn.name == "Rock1A")
                    {
                        ChangeRenderMode(collideIn.gameObject.GetComponent<MeshRenderer>().material, BlendMode.Opaque);
                    }
                }
            }
        }
        transparencyCollidersSaved = transparencyColliders;

        //0 is the Base layer.
        AnimatorStateInfo animStateInfo = anim.GetCurrentAnimatorStateInfo (0);

		float velocity = Input.GetAxis ("Vertical");
		float velocityX = Input.GetAxis ("Horizontal");

		if (Input.GetKey (KeyCode.LeftShift) && velocity > 0.7f)
		{
			velocity = 0.6f;
		}

		anim.SetFloat ("Velocity", velocity);
		anim.SetFloat ("VelocityX", velocityX);

		Debug.Log ("VelocityX : " + velocityX);

		if (Input.GetKeyDown (KeyCode.Space) && (animStateInfo.fullPathHash == walkTreeHash || animStateInfo.fullPathHash == runTreeHash)  ) 
		{
			anim.SetTrigger ("Roll");
		}
		else if (Input.GetKeyDown (KeyCode.G) && (animStateInfo.fullPathHash == walkTreeHash || animStateInfo.fullPathHash == runTreeHash)  ) 
		{
			anim.SetTrigger ("Glasses");
		}
		else if (Input.GetKeyDown (KeyCode.L) && (animStateInfo.fullPathHash == walkTreeHash || animStateInfo.fullPathHash == runTreeHash)  ) 
		{
			anim.SetTrigger ("Grenade");
		}
	}

    public void ChangeRenderMode(Material standardShaderMaterial, BlendMode blendMode)
    {
        switch (blendMode)
        {
            case BlendMode.Opaque:
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                standardShaderMaterial.SetInt("_ZWrite", 1);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = -1;
                break;
            case BlendMode.Cutout:
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                standardShaderMaterial.SetInt("_ZWrite", 1);
                standardShaderMaterial.EnableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 2450;
                break;
            case BlendMode.Fade:
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                standardShaderMaterial.SetInt("_ZWrite", 0);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.EnableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 3000;
                break;
            case BlendMode.Transparent:
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                standardShaderMaterial.SetInt("_ZWrite", 0);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = 3000;
                break;
        }

    }
}
