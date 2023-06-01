using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunShooter.Character
{
    public interface ICharacter
    {
        CharacterType CharacterType { get; }
    }
}
