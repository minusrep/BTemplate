using System;
using UnityEngine.UIElements;

namespace Root.UI
{
    public class UIButton : UIElement<Button>
    {
        public event Action OnClick;

        public UIButton(Button root) : base(root) 
        {
            root.clicked += OnClick;
        }
    }
}
