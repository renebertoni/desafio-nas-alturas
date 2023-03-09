using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class SpriteStorage : MonoBehaviour
{
    [SerializeField]
    List<Sprite> _sprites; 

    public Sprite GetSprite( string spritName )
    {
        return _sprites.Where( obj => obj.name == spritName ).SingleOrDefault();
    }
}
