﻿using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace DemoChat.Views.Controls
{
    public class CustomMap : Map
    {
        public List<CustomPin> CustomPins { get; set; }
    }
}
