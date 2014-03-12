using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using AzureConf;
using Java.IO;

namespace MonkeySpace
{
    public class SpeakersAdapter : BaseAdapter
    {
        private List<MonkeySpace.Core.Speaker> speakers;
        private Activity context;

        public SpeakersAdapter(Activity context, List<MonkeySpace.Core.Speaker> speakers)
        {
            this.context = context;
            this.speakers = speakers;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = (convertView
                            ?? context.LayoutInflater.Inflate(
                                    Resource.Layout.SpeakersItem, parent, false)
                        ) as RelativeLayout;
            var row = speakers.ElementAt(position);
            
            view.FindViewById<TextView>(Resource.Id.Name).Text = row.Name;
            view.FindViewById<TextView>(Resource.Id.Designation).Text = row.Tagline;
            try
            {
                if (!string.IsNullOrEmpty(row.HeadshotUrl))
                {
                    var url = row.HeadshotUrl.Replace("/images/speakers/", "speakers/");
                    var headshotDrawable = Drawable.CreateFromStream(context.Assets.Open(url), null);
                    var img = view.FindViewById<ImageView>(Resource.Id.Image);
                    img.SetImageDrawable(headshotDrawable);
                }
            }
            catch (FileNotFoundException ex)
            {

                
            }
            catch (Exception ex)
            {
                
            }
            

            return view;
        }

        public override int Count
        {
            get { return speakers.Count(); }
        }

        public MonkeySpace.Core.Speaker GetRow(int position)
        {
            return speakers.ElementAt(position);
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
    }
}