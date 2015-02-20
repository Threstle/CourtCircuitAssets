using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpikeTrapScript : MonoBehaviour {

    public GameObject reference ;
    public GameObject spike ;
	public List<SpikeScript> spikes ;

    public float
        decayX,
        decayY,
		decayZ,
        space,
        spikeWidth,
        spikeHeight ;

    public int
        number ;

	// Use this for initialization
	void Start ()
    {
		spikes = new List<SpikeScript> ();
        if (reference) build(reference) ;
	}

    void build (GameObject refr)
    {
        reference = refr ;

		Vector3 refPosition = reference.transform.position;
        float width = reference.renderer.bounds.size.x ;
        number = (int) ((width - decayX) / (spikeWidth + space)) ; 

		SpikeScript s ;
        for (int n=0 ; n<number ; n++) {
            s = ((Instantiate(spike)) as GameObject).GetComponent<SpikeScript>() ;

			s.x = refPosition.x - (width/2) + decayX + (n * (spikeWidth + space)) ;
			s.y = refPosition.y + decayY ;
			s.z = refPosition.z + decayZ ;
			s.width = 1 ;
			s.height = 1 ;

			s.transform.position = new Vector3(s.x, s.y, s.z) ;
            s.transform.parent = transform.parent ;

            spikes.Add(s);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	   
	}
}
