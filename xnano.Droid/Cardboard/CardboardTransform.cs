using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;



namespace xnano.Droid.Cardboard
{

    class CardboardTransform
    {
        private Context _context;
        private IntPtr _jvm;

        public CardboardTransform(Context context)
        {
            try
            {
                Java.Lang.JavaSystem.LoadLibrary("cardboard_jni");
                Java.Lang.JavaSystem.LoadLibrary("cardboard_api");
            }

            catch (Exception e)
            {
                
            }

            this._context = context;

            //this._jvm = GetJniEnv();

            nativeOnCreate(context.Handle, context.Assets.Handle);
            //Cardboard_initializeAndroid(this._jvm, Application.Context.Handle);
        }

        [DllImport("cardboard_jni")]
        private static extern IntPtr GetJniEnv();

        [DllImport("cardboard_jni", EntryPoint = "Java_com_google_cardboard_VrActivity_nativeOnCreate")]
        private static extern long nativeOnCreate(IntPtr context, IntPtr assets);

        [DllImport("cardboard_api")]
        private static extern void Cardboard_initializeAndroid(IntPtr vm, IntPtr context);
    }
}