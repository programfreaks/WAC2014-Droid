using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using AzureConf;
using MonkeySpace.Core;


namespace MonkeySpace
{
	/// <summary>
	/// Sessions adapter used in the Sessions list - 
	/// displays complete session details in each row View.
	/// </summary>
    public class SessionsAdapter : BaseAdapter
    {
        private List<Session> sessions;
        private Activity context;

        Dictionary<string, List<Session>> sessionsDictionary;
        private readonly IList<object> rows;

        public SessionsAdapter(Activity context, List<MonkeySpace.Core.Session> sessions)
        {
            this.context = context;
            this.sessions = sessions;
            this.sessionsDictionary = new Dictionary<string, List<Session>>();
            sessionsDictionary.Add("Keynote", new List<Session>());
            sessionsDictionary.Add("OPEN", new List<Session>());
            sessionsDictionary.Add("BROAD(Develop)", new List<Session>());
            sessionsDictionary.Add("FLEXIBLE(Deploy&Manage)", new List<Session>()); 
            sessionsDictionary.Add("Start-up Conclave", new List<Session>());
            sessionsDictionary.Add("MIC Champs Connect", new List<Session>());
            sessionsDictionary.Add("HOL", new List<Session>());
            
            //sessionsDictionary.Add("OPEN", new List<Session>());
            foreach (var session in sessions)
            {
                if (sessionsDictionary.ContainsKey(session.Location))
                {
                    sessionsDictionary[session.Location].Add(session);
                }
                else
                {
                    var tempSesions = new List<Session>();
                    tempSesions.Add(session);
                    sessionsDictionary.Add(session.Location, tempSesions);
                }
            }

            rows = new List<object>();
            foreach (var section in sessionsDictionary.Keys)
            {
                rows.Add(section);
                foreach (var session in sessionsDictionary[section])
                {
                    rows.Add(session);
                }
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = context.LayoutInflater.Inflate(Resource.Layout.SessionsItem, null) as LinearLayout;
                //(convertView ?? context.LayoutInflater.Inflate(Resource.Layout.SessionsItem, parent, false)) as LinearLayout;
            //var row = sessions.ElementAt(position);

            var temp = rows.ElementAt(position);

            if (temp is Session)
            {
                var row = temp as Session;
                view.FindViewById<TextView>(Resource.Id.Time).Text = row.DateTimeDisplay;

                view.FindViewById<TextView>(Resource.Id.Title).Text = row.Title;

                if (row.Location == "")
                    view.FindViewById<TextView>(Resource.Id.Room).Text = row.GetSpeakerList();
                else
                    view.FindViewById<TextView>(Resource.Id.Room).Text = row.LocationDisplay + "; " +
                                                                         row.GetSpeakerList();
            }
            else if(temp is string)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.SessionSectionHeader, null) as LinearLayout;
                view.Clickable = false;
                view.LongClickable = false;
                view.SetOnClickListener(null);
                view.FindViewById<TextView>(Resource.Id.sectionHeader).Text = (string)temp;
            }

            return view;
        }

        public override int Count
        {
            get { return sessions.Count(); }
        }

        public MonkeySpace.Core.Session GetRow(int position)
        {
            return sessions.ElementAt(position);
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