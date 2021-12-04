using System;

namespace GoodAndEvil
{
    public class Constants
    {
        public const string tutorialText = @"[center]Tutorial
To get through this level you need to switch to the opposite room by pressing <SPACE>[/center]
[right]Press <Z> to Continue[/right]";
        public const string tutorialSecondText = @"[center]This door appears to be locked,
wonder where the key might be[/center]
        [right]Press <Z> to Continue[/right]";

        public const string heartBBCode = "[img=32x32]textures/gui/heart.png[/img]";
        public const string goodKeyBBCode = "[img=16x16]textures/gui/goodKey.png[/img]";
        public const string badKeyBBCode = "[img=16x16]textures/gui/badKey.png[/img]";

        public const string badDoorLockedText = @"[center]Door is locked!
Requires " + badKeyBBCode + @"x1 to open.
        [right]Press <Z> to Continue[/right]";
        
        public const string goodDoorLockedText = @"[center]Door is locked!
Requires " + goodKeyBBCode + @"x1 to open.
        [right]Press <Z> to Continue[/right]";
    }
}