using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MemoApp.Droid;
using MemoApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(ShareFilePermission))]
namespace MemoApp.Droid
{
    public class ShareFilePermission : IShareFilePermission
    {
        public void GrantPermission(string path, string mimeType)
        {
            //Intent intentShareFile = new Intent(Intent.ActionSend);
            Intent intentShareFile = new Intent();
            intentShareFile.SetAction(Intent.ActionSend);

            Java.IO.File file = new Java.IO.File(path);

            Android.Net.Uri uri;
            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.N)
            {
                uri = AndroidX.Core.Content.FileProvider.GetUriForFile(
                        Android.App.Application.Context,
                        string.Format("{0}{1}", Android.App.Application.Context.PackageName, ".fileprovider"),
                        file);
            }
            else
            {
                uri = Android.Net.Uri.FromFile(file);
            }

            intentShareFile.SetType(mimeType);
            intentShareFile.AddFlags(ActivityFlags.GrantReadUriPermission);

            //파일 mime-type
            //var type = Android.App.Application.Context.ContentResolver.GetType(uri);
            //System.Console.WriteLine(type);

            intentShareFile.PutExtra(Intent.ExtraStream, uri);
            intentShareFile.PutExtra(Intent.ExtraTitle, "Share");

            //intentShareFile.SetData(uri);
            //intentShareFile.SetDataAndType(uri, Android.App.Application.Context.ContentResolver.GetType(uri));

            ////안드로이 11 이후 추가
            IList<ResolveInfo> resInfoList = Android.App.Application.Context.PackageManager.QueryIntentActivities(intentShareFile, PackageInfoFlags.MatchDefaultOnly);
            foreach (ResolveInfo resInfo in resInfoList)
            {
                string packageName = resInfo.ActivityInfo.PackageName;
                Android.App.Application.Context.GrantUriPermission(packageName, uri, ActivityFlags.GrantReadUriPermission);
            }

            //ShareCompat.IntentBuilder shareBuilder = new ShareCompat.IntentBuilder(Android.App.Application.Context);
            //shareBuilder.SetType(mimeType);
            //shareBuilder.SetStream(uri);
            //shareBuilder.CreateChooserIntent();

            //Intent intent = shareBuilder.Intent;
            //intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);
            //Android.App.Application.Context.StartActivity(intent);

            Intent intent = Intent.CreateChooser(intentShareFile, "Share");
            var flags = ActivityFlags.ClearTop | ActivityFlags.NewTask;
            intent.SetFlags(flags);
            Android.App.Application.Context.StartActivity(intent);
        }
    }
}