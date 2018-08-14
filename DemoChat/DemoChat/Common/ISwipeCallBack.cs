using System;
using System.Collections.Generic;
using System.Text;

using System;
using Xamarin.Forms;

namespace DemoChat.Common
{
    public interface ISwipeCallBack
    {
        void onLeftSwipe(View view, double translatedX , double translatedY);
        void onRightSwipe(View view, double translatedX, double translatedY);
        void onTopSwipe(View view, double translatedX, double translatedY);
        void onBottomSwipe(View view, double translatedX, double translatedY);
        void onNothingSwiped(View view, double translatedX, double translatedY);
    }
}
