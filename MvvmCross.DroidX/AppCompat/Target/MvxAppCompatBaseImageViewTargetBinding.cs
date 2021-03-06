﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MS-PL license.
// See the LICENSE file in the project root for more information.

using System;
using Android.Graphics;
using AndroidX.AppCompat.Widget;
using MvvmCross.Binding;
using MvvmCross.Exceptions;
using MvvmCross.Platforms.Android.Binding.Target;

namespace MvvmCross.DroidX.AppCompat.Target
{
    public abstract class MvxAppCompatBaseImageViewTargetBinding
        : MvxAndroidTargetBinding
    {
        protected AppCompatImageView ImageView => (AppCompatImageView)Target;

        protected MvxAppCompatBaseImageViewTargetBinding(AppCompatImageView imageView)
            : base(imageView)
        {
        }

        public override MvxBindingMode DefaultMode => MvxBindingMode.OneWay;

        protected override void SetValueImpl(object target, object value)
        {
            var imageView = (AppCompatImageView)target;

            try
            {
                Bitmap bitmap;
                if (!GetBitmap(value, out bitmap))
                    return;
                SetImageBitmap(imageView, bitmap);
            }
            catch (Exception ex)
            {
                MvxBindingLog.Error(ex.ToLongString());
                throw;
            }
        }

        protected virtual void SetImageBitmap(AppCompatImageView imageView, Bitmap bitmap)
        {
            imageView.SetImageBitmap(bitmap);
        }

        protected abstract bool GetBitmap(object value, out Bitmap bitmap);
    }
}
