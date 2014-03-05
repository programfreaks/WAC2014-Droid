using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using AzureConf;

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
                        ) as LinearLayout;
            var row = speakers.ElementAt(position);

            view.FindViewById<TextView>(Resource.Id.Title).Text = row.Name;
            

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