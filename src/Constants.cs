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
        public const string jaffaBBCode = "[img=16x16]textures/JaffaCake.png[/img]";

        public const string badDoorLockedText = @"[center]Door is locked!
Requires " + badKeyBBCode + @"x1 to open.
        [right]Press <Z> to Continue[/right]";
        
        public const string goodDoorLockedText = @"[center]Door is locked!
Requires " + goodKeyBBCode + @"x1 to open.
        [right]Press <Z> to Continue[/right]";

        public const string VictoryText = @"
[center]Congratulations!
You reunited Lewis and Simon!
You collected {0} out of {1} Jaffa Cakes!
Press any key to continue[/center]";

        public const string startingMessage1 = @"[center]Lewis and Simon have been sent to opposite dimensions after an accident with one of their experiments in YogLabs, your goal is to help them get back together in their original dimension.[/center]
[right]Press <Z> to Continue[/right]";

        public const string buttonPress = "sfx/button.wav";
        public const string pickup = "sfx/pickup.wav";
        public const string hurt = "sfx/hurt.wav";
        public const string teleport = "sfx/teleport.wav";
        public const string doorOpen = "sfx/metalLatch.ogg";
    }
}