﻿using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PricesAndroid.Droid.TetraRenderers;
using PricesAndroid.TetraControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TetraEditor), typeof(TetraEditorRendererAndroid))]
namespace PricesAndroid.Droid.TetraRenderers
{
    public class TetraEditorRendererAndroid : EditorRenderer
    {
        public TetraEditorRendererAndroid(Context context) : base(context) { }
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
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