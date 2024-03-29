﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PricesAndroid.TetraControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using PricesAndroid.Droid.TetraRenderers;

[assembly: ExportRenderer(typeof(TetraPicker), typeof(TetraPickerRendererAndroid))]
namespace PricesAndroid.Droid.TetraRenderers
{
    public class TetraPickerRendererAndroid : PickerRenderer
    {
        public TetraPickerRendererAndroid(Context context) : base(context) { }
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var gb = new GradientDrawable();
                Control.SetBackground(gb);
            }
        }
    }
}