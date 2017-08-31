﻿using System.Collections.Generic;
using GameBaseArilox.API.Core;

namespace GameBaseArilox.API.Graphic
{
    public interface ITextSpriteAnimation : IEffectOverTime, IChangedOverTime,IEffectObject, INamed
    {
        ITextSprite AffectedTextSprite { get; set; }
        List<string> AnimationTexts { get; set; }
        bool IsSeesaw { get; set; }
    }
}
